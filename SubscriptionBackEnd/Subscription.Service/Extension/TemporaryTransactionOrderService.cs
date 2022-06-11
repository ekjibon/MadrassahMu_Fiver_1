using CoreWeb.Business.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Subscription.Business;
using Subscription.Business.Common;
using Subscription.Business.Dto;
//using Subscription.Business.Dto.Company;
//using Subscription.Business.Dto.HostedDomain;
using Subscription.Business.Enums;
using Subscription.Business.Report.Transaction;
using Subscription.Business.ReturnType;
using Subscription.Business.ReturnType.HostedDomain;
using Subscription.Data;

namespace Subscription.Service
{
    public partial class TemporaryTransactionOrderService : BaseService
    {
        public BusinessResponse<SaveTemporaryTransactionReturnType> SaveTemporaryTransaction(SaveTemporaryTransactionDto saveTemporaryTransactionDto)
        {
            BusinessResponse<SaveTemporaryTransactionReturnType> response = new BusinessResponse<SaveTemporaryTransactionReturnType>();
            UnitOfWork unitOfWork = new UnitOfWork();
            try
            {
                unitOfWork.Begin();
                response.Result = SaveTemporaryTransactionRaw(saveTemporaryTransactionDto, unitOfWork);
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

        internal SaveTemporaryTransactionReturnType SaveTemporaryTransactionRaw(SaveTemporaryTransactionDto saveTemporaryTransactionDto, UnitOfWork unitOfWork)
        {
            SaveTemporaryTransactionReturnType saveTemporaryTransactionReturnType = new SaveTemporaryTransactionReturnType();

            if (saveTemporaryTransactionDto.TemporaryTransaction.Document != null)
            {
                daoFactory.DocumentDao.SaveOnlyDocument(saveTemporaryTransactionDto.TemporaryTransaction.Document, unitOfWork.Db);
                saveTemporaryTransactionDto.TemporaryTransaction.IdSignatureDocument = saveTemporaryTransactionDto.TemporaryTransaction.Document.IdDocument;
            }

            //Transaction transaction = JsonConvert.DeserializeObject<Transaction>(saveTemporaryTransactionDto.TemporaryTransaction.TransactionJson);
            //List<long> idPaymentMethods = 
            //transaction.Payment?.PaymentDetails?.ToList()?.Where(pd => pd.PaymentMethod == null && pd.IdPaymentMethod != null)?.ToList()?.ForEach(pd =>
            //{

            //});
            //load transaction details
            //TODO
            //end load transaction details

            daoFactory.TemporaryTransactionOrderDao.SaveOnlyTemporaryTransactionOrder(saveTemporaryTransactionDto.TemporaryTransaction, unitOfWork.Db);

            saveTemporaryTransactionReturnType.TemporaryTransaction = saveTemporaryTransactionDto.TemporaryTransaction;

            return saveTemporaryTransactionReturnType;
        }

        public BusinessResponse<SaveTemporaryTransactionReturnType> SaveTemporaryTransaction(SaveTransactionPaymentDto saveTransactionSaleDto)
        {
            BusinessResponse<SaveTemporaryTransactionReturnType> response = new BusinessResponse<SaveTemporaryTransactionReturnType>();
            UnitOfWork unitOfWork = new UnitOfWork();
            try
            {
                unitOfWork.Begin();
                response.Result = SaveTemporaryTransactionRaw(saveTransactionSaleDto, unitOfWork);
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

        internal SaveTemporaryTransactionReturnType SaveTemporaryTransactionRaw(SaveTransactionPaymentDto saveTransactionSaleDto, UnitOfWork unitOfWork)
        {
            SaveTemporaryTransactionDto saveTemporaryTransactionDto = new SaveTemporaryTransactionDto();
            saveTemporaryTransactionDto.TemporaryTransaction = new TemporaryTransactionOrder()
            {
                IdTemporaryTransactionOrderState = (long)TemporaryTransactionOrderStateEnum.ORDER_DONE,
                TemporaryTransactionOrderDate = DateTime.Now,
                TransactionJson = JsonConvert.SerializeObject(saveTransactionSaleDto.Transaction)
            };


            SaveTemporaryTransactionReturnType saveTemporaryTransactionReturnType = SaveTemporaryTransactionRaw(saveTemporaryTransactionDto, unitOfWork);
            return saveTemporaryTransactionReturnType;
        }

        public BusinessResponse<GetTemporaryTransactionOrderForWorkstationReturnType> GetTemporaryTransactionOrderForWorkstation(GetTemporaryTransactionOrderForWorkstationDto getTemporaryTransactionOrderForWorkstationDto)
        {
            BusinessResponse<GetTemporaryTransactionOrderForWorkstationReturnType> response = new BusinessResponse<GetTemporaryTransactionOrderForWorkstationReturnType>();
            try
            {
                response.Result = GetTemporaryTransactionSignatureForWorkstationRaw(getTemporaryTransactionOrderForWorkstationDto);
            }
            catch (Exception ex)
            {
                response.Result = null;
                response.Exception = new BusinessLayerException(ex.Message, ex);
            }

            return response;
        }

        internal GetTemporaryTransactionOrderForWorkstationReturnType GetTemporaryTransactionSignatureForWorkstationRaw(GetTemporaryTransactionOrderForWorkstationDto getTemporaryTransactionOrderForWorkstationDto)
        {
            GetTemporaryTransactionOrderForWorkstationReturnType getTemporaryTransactionSignatureForWorkstationReturnType = new GetTemporaryTransactionOrderForWorkstationReturnType();

            getTemporaryTransactionSignatureForWorkstationReturnType.TemporaryTransaction = daoFactory.TemporaryTransactionOrderDao.GetTemporaryTransactionOrderForWorkstation(getTemporaryTransactionOrderForWorkstationDto.IdWorkstation);

            return getTemporaryTransactionSignatureForWorkstationReturnType;
        }


        public BusinessResponse<GetSignatureForTemporaryTransactionSignatureReturnType> GetSignatureForTemporaryTransactionSignature(GetSignatureForTemporaryTransactionSignatureDto getSignatureForTemporaryTransactionSignatureDto)
        {
            BusinessResponse<GetSignatureForTemporaryTransactionSignatureReturnType> response = new BusinessResponse<GetSignatureForTemporaryTransactionSignatureReturnType>();
            try
            {
                response.Result = GetSignatureForTemporaryTransactionSignatureRaw(getSignatureForTemporaryTransactionSignatureDto);
            }
            catch (Exception ex)
            {
                response.Result = null;
                response.Exception = new BusinessLayerException(ex.Message, ex);
            }

            return response;
        }

        internal GetSignatureForTemporaryTransactionSignatureReturnType GetSignatureForTemporaryTransactionSignatureRaw(GetSignatureForTemporaryTransactionSignatureDto getSignatureForTemporaryTransactionSignatureDto)
        {
            GetSignatureForTemporaryTransactionSignatureReturnType getSignatureForTemporaryTransactionSignatureReturnType = new GetSignatureForTemporaryTransactionSignatureReturnType();

            List<string> includes = new List<string>()
            {
                TemporaryTransactionOrderDatabaseReferences.DOCUMENT,
                String.Format("{0}.{1}",  TemporaryTransactionOrderDatabaseReferences.DOCUMENT,DocumentDatabaseReferences.PARAMETER1)
            };
            TemporaryTransactionOrder temporaryTransactionSignature = daoFactory.TemporaryTransactionOrderDao
                .GetTemporaryTransactionOrderCustom(s => s.IdTemporaryTransactionOrder == getSignatureForTemporaryTransactionSignatureDto.IdTemporaryTransaction, includes);

            getSignatureForTemporaryTransactionSignatureReturnType.SignatureDocument = ServiceFactory.Instance.DocumentService.MapDocument(temporaryTransactionSignature.Document);

            return getSignatureForTemporaryTransactionSignatureReturnType;
        }
    }
}
