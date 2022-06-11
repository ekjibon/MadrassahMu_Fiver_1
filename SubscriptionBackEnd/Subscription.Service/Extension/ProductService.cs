using CoreWeb.Business.Common;
using Subscription.Business;
using Subscription.Business.Common;
using Subscription.Business.Dto;
using Subscription.Business.Dto.Subscription;
using Subscription.Business.Enums;
using Subscription.Data;
using Subscription.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Subscription.Business.ReturnType;

namespace Subscription.Service
{
    public partial class ProductService : BaseService
    {
        public BusinessResponse<BaseListReturnType<Product>> LoadProductList(ProductListSortingPagingInfo sortingPagingInfo)
        {
            BusinessResponse<BaseListReturnType<Product>> response = new BusinessResponse<BaseListReturnType<Product>>();

            try
            {
                response.Result = LoadProductListRaw(sortingPagingInfo);
            }
            catch (Exception ex)
            {
                response.Result = null;
                response.Exception = new BusinessLayerException(ex.Message, ex);
            }

            return response;
        }

        internal BaseListReturnType<Product> LoadProductListRaw(ProductListSortingPagingInfo sortingPagingInfo)
        {
            //here
            List<string> includes = new List<string>() { ProductDatabaseReferences.TRANSACTIONDETAILS };
            BaseListReturnType<Product> dbProducts = ServiceFactory.Instance.ProductService.GetAllProductsByPageRaw(sortingPagingInfo, null, includes, true);

            BaseListReturnType<Product> productList = new BaseListReturnType<Product>();

            productList.EntityList = dbProducts.EntityList.Select(c => RemapProduct(c)).ToList();
            productList.TotalCount = dbProducts.TotalCount;
            return productList;
        }
        public Product RemapProduct(Product product)
        {
            if(product.ProductType != null)
            {
                product.ProductType = Mapper.MapProductTypeSingle(product.ProductType, true);
            //    product.ProductType = productType;
            }

            Product remappedProduct = Mapper.MapProductSingle(product);

            return remappedProduct;
        }

        public BusinessResponse<SaveAdministrationProductReturnType> SaveAdministrationProduct(SaveAdministrationProductDto saveAdministrationProductDto)
        {
            BusinessResponse<SaveAdministrationProductReturnType> response = new BusinessResponse<SaveAdministrationProductReturnType>();
            UnitOfWork unitOfWork = new UnitOfWork();
            try
            {
                unitOfWork.Begin();
                response.Result = SaveAdministrationProductRaw(saveAdministrationProductDto, unitOfWork);
                unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                unitOfWork.RollbackTransaction();
                response.Result = null;
                response.Exception = new BusinessLayerException(ex.Message, ex);
            }

            return response;
        }

        internal SaveAdministrationProductReturnType SaveAdministrationProductRaw(SaveAdministrationProductDto saveAdministrationProductDto, UnitOfWork unitOfWork)
        {
            SaveAdministrationProductReturnType saveAdministrationProductReturnType = new SaveAdministrationProductReturnType();
            //saveAdministrationProductDto.Product.IdEntitySyncState = (long)EntityStateEnum.AWAITING_SYNC;

            bool isFirstTimeSave = saveAdministrationProductDto.Product == null;

            daoFactory.ProductDao.SaveOnlyProduct(saveAdministrationProductDto.Product, unitOfWork.Db);

            saveAdministrationProductReturnType.Product = saveAdministrationProductDto.Product;
            return saveAdministrationProductReturnType;
        }

        public BusinessResponse<GetAdministrationProductReturnType> GetAdministrationProduct(long idProduct)
        {
            BusinessResponse<GetAdministrationProductReturnType> response = new BusinessResponse<GetAdministrationProductReturnType>();

            try
            {
                response.Result = GetAdministrationProductRaw(idProduct);
            }
            catch (Exception ex)
            {
                response.Result = null;
                response.Exception = new BusinessLayerException(ex.Message, ex);
            }

            return response;
        }

        internal GetAdministrationProductReturnType GetAdministrationProductRaw(long idProduct)
        {
            GetAdministrationProductReturnType getAdministrationProductReturnType = new GetAdministrationProductReturnType();

            Expression<Func<Product, bool>> expression = property => property.IsDeactivated != true && property.IdProduct == idProduct;
            List<string> includes = new List<string>()
            {
                ProductDatabaseReferences.PRODUCTTYPE,
            };

            Product dbProduct = daoFactory.ProductDao.GetProductCustom(expression, includes);
            if (dbProduct != null)
            {
                getAdministrationProductReturnType.Product = RemapProduct(dbProduct);
            }
            else
            {
                throw new Exception("Product cannot be found");
            }
            return getAdministrationProductReturnType;
        }

    }
}
