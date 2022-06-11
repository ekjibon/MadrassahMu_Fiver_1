using CoreWeb.Business.Common;
using Subscription.Business;
using Subscription.Business.Common;
using Subscription.Business.Dto;
using Subscription.Business.Dto.Subscription;
using Subscription.Business.Enums;
using Subscription.Business.ReturnType;
using Subscription.Data;
using Subscription.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Subscription.Service
{
    public partial class CustomerService : BaseService
    {
        public BusinessResponse<BaseListReturnType<Customer>> LoadCustomerList(CustomerListSortingPagingInfo sortingPagingInfo)
        {
            BusinessResponse<BaseListReturnType<Customer>> response = new BusinessResponse<BaseListReturnType<Customer>>();

            try
            {
                response.Result = LoadCustomerListRaw(sortingPagingInfo);
            }
            catch (Exception ex)
            {
                response.Result = null;
                response.Exception = new BusinessLayerException(ex.Message, ex);
            }

            return response;
        }

        internal BaseListReturnType<Customer> LoadCustomerListRaw(CustomerListSortingPagingInfo sortingPagingInfo)
        {
            //here
            List<string> includes = new List<string>() { 
                CustomerDatabaseReferences.PERSON,
                String.Format("{0}.{1}.{2}", CustomerDatabaseReferences.PERSON, PersonDatabaseReferences.PERSON_ADDRESS, Person_AddressDatabaseReferences.ADDRESS),
                String.Format("{0}.{1}.{2}", CustomerDatabaseReferences.PERSON, PersonDatabaseReferences.PERSON_CONTACTTYPE, Person_ContactTypeDatabaseReferences.CONTACTTYPE),
                String.Format("{0}.{1}",CustomerDatabaseReferences.PERSON,PersonDatabaseReferences.TITLE),
                // CustomerDatabaseReferences.TRANSACTIONS, 
               // String.Format("{0}.{1}", CustomerDatabaseReferences.TRANSACTIONS, TransactionDatabaseReferences.TRANSACTIONDETAILS), 
            };
            BaseListReturnType<Customer> dbCustomers = ServiceFactory.Instance.CustomerService.GetAllCustomersByPageRaw(sortingPagingInfo, null, includes);

            BaseListReturnType<Customer> customerList = new BaseListReturnType<Customer>();

            customerList.EntityList = dbCustomers.EntityList.Select(c => RemapCustomer(c)).ToList();
            customerList.TotalCount = dbCustomers.TotalCount;
            return customerList;
        }

        public BusinessResponse<GetAdministrationCustomerReturnType> GetAdministrationCustomer(long idCustomer)
        {
            BusinessResponse<GetAdministrationCustomerReturnType> response = new BusinessResponse<GetAdministrationCustomerReturnType>();

            try
            {
                response.Result = GetAdministrationCustomerRaw(idCustomer);
            }
            catch (Exception ex)
            {
                response.Result = null;
                response.Exception = new BusinessLayerException(ex.Message, ex);
            }

            return response;
        }

        internal GetAdministrationCustomerReturnType GetAdministrationCustomerRaw(long idCustomer)
        {
            GetAdministrationCustomerReturnType getAdministrationCustomerReturnType = new GetAdministrationCustomerReturnType();

            Expression<Func<Customer, bool>> expression = property => property.IsDeactivated != true && property.IdCustomer == idCustomer;
            List<string> includes = new List<string>()
            {
                CustomerDatabaseReferences.COMPANY,
                CustomerDatabaseReferences.PERSON,
                CustomerDatabaseReferences.CUSTOMERTYPE,
                String.Format("{0}.{1}.{2}.{3}",CustomerDatabaseReferences.COMPANY,CompanyDatabaseReferences.COMPANYLOCATIONS,CompanyLocationDatabaseReferences.ADDRESS,AddressDatabaseReferences.COUNTRY),
                String.Format("{0}.{1}.{2}.{3}",CustomerDatabaseReferences.PERSON,PersonDatabaseReferences.PERSON_ADDRESS,Person_AddressDatabaseReferences.ADDRESS,AddressDatabaseReferences.COUNTRY),
                String.Format("{0}.{1}",CustomerDatabaseReferences.PERSON,PersonDatabaseReferences.TITLE),
                String.Format("{0}.{1}.{2}",CustomerDatabaseReferences.PERSON,PersonDatabaseReferences.PERSON_CONTACTTYPE,Person_ContactTypeDatabaseReferences.CONTACTTYPE),
                String.Format("{0}.{1}.{2}",CustomerDatabaseReferences.COMPANY,CompanyDatabaseReferences.COMPANY_CONTACTTYPE,Company_ContactTypeDatabaseReferences.CONTACTTYPE)
            };

            Customer dbCustomer = daoFactory.CustomerDao.GetCustomerCustom(expression, includes);
            if (dbCustomer != null)
            {
                getAdministrationCustomerReturnType.Customer = RemapCustomer(dbCustomer);
            }
            else
            {
                throw new Exception("Customer cannot be found");
            }
            return getAdministrationCustomerReturnType;
        }

        public BusinessResponse<SaveAdministrationCustomerReturnType> SaveAdministrationCustomer(SaveAdministrationCustomerDto saveAdministrationCustomerDto)
        {
            BusinessResponse<SaveAdministrationCustomerReturnType> response = new BusinessResponse<SaveAdministrationCustomerReturnType>();
            UnitOfWork unitOfWork = new UnitOfWork();
            try
            {
                unitOfWork.Begin();
                response.Result = SaveAdministrationCustomerRaw(saveAdministrationCustomerDto, unitOfWork);
                unitOfWork.Commit();
                //PrepareForSync(saveAdministrationCustomerDto.Customer);
            }
            catch (Exception ex)
            {
                unitOfWork.RollbackTransaction();
                response.Result = null;
                response.Exception = new BusinessLayerException(ex.Message, ex);
            }

            return response;
        }
        internal void ValidateCustomerDetail(Customer customer)
        {

        }
        internal SaveAdministrationCustomerReturnType SaveAdministrationCustomerRaw(SaveAdministrationCustomerDto saveAdministrationCustomerDto, UnitOfWork unitOfWork)
        {
            SaveAdministrationCustomerReturnType saveAdministrationCustomerReturnType = new SaveAdministrationCustomerReturnType();
            ValidateCustomerDetail(saveAdministrationCustomerDto.Customer);
            bool isFirstTimeSave = saveAdministrationCustomerDto.Customer == null;
            //saveAdministrationCustomerDto.Customer.IdEntitySyncState = (long)EntityStateEnum.AWAITING_SYNC;

            string fullName = null;
            if (saveAdministrationCustomerDto.Customer.IdCustomerType == (long)CustomerTypeEnum.PERSON)
            {
                ServiceFactory.Instance.PersonService.SaveProfileAdminPersonRaw(new SaveProfileAdminPersonDto() { Person = saveAdministrationCustomerDto.Customer.Person }, unitOfWork);
                saveAdministrationCustomerDto.Customer.IdPerson = saveAdministrationCustomerDto.Customer.Person.IdPerson;
                fullName = String.Format("{0} {1}", saveAdministrationCustomerDto.Customer.Person.Firstname, saveAdministrationCustomerDto.Customer.Person.Lastname);
            }
            else if (saveAdministrationCustomerDto.Customer.IdCustomerType == (long)CustomerTypeEnum.COMPANY)
            {
                ServiceFactory.Instance.CompanyService.SaveCompanyAdminDetailCompanyRaw(new SaveCompanyAdminDetailCompanyDto() { Company = saveAdministrationCustomerDto.Customer.Company }, unitOfWork);
                saveAdministrationCustomerDto.Customer.IdCompany = saveAdministrationCustomerDto.Customer.Company.IdCompany;
                fullName = String.Format("{0}", saveAdministrationCustomerDto.Customer.Company.Name);
            }
            saveAdministrationCustomerDto.Customer.FullName = fullName;
            daoFactory.CustomerDao.SaveOnlyCustomer(saveAdministrationCustomerDto.Customer, unitOfWork.Db);

            saveAdministrationCustomerReturnType.Customer = saveAdministrationCustomerDto.Customer;
            return saveAdministrationCustomerReturnType;
        }

        //internal void PrepareForSync(Customer customer)
        //{
        //    ServiceFactory.Instance.SyncClientEntityService.SaveSyncClientEntityForClients(new SaveSyncClientEntityForClientsDto()
        //    {
        //        IdLocalId = customer.IdCustomer.ToString(),
        //        IdSyncEntityType = (long)SyncEntityTypeEnum.CUSTOMER,
        //        IdSyncState = (long)SyncStateEnum.AWAITING_SYNC
        //    });
        //}

        public BusinessResponse<BaseListReturnType<Customer>> LoadList(CustomerSortingPagingInfo sortingPagingInfo)
        {
            BusinessResponse<BaseListReturnType<Customer>> response = new BusinessResponse<BaseListReturnType<Customer>>();

            try
            {
                response.Result = LoadListRaw(sortingPagingInfo);
            }
            catch (Exception ex)
            {
                response.Result = null;
                response.Exception = new BusinessLayerException(ex.Message, ex);
            }

            return response;
        }

        internal BaseListReturnType<Customer> LoadListRaw(CustomerSortingPagingInfo sortingPagingInfo)
        {
            BaseListReturnType<Customer> dbCustomers = ServiceFactory.Instance.CustomerService.GetAllCustomersByPageRaw(sortingPagingInfo);

            BaseListReturnType<Customer> customers = new BaseListReturnType<Customer>();

            customers.EntityList = dbCustomers.EntityList.Select(c => Mapper.MapCustomerSingle(c, true)).ToList();
            customers.TotalCount = dbCustomers.TotalCount;
            return customers;
        }

        public BusinessResponse<BaseListReturnType<LoadListByNameAndAddressReturnType>> LoadListByNameAndAddress(CustomerSortingPagingInfo sortingPagingInfo)
        {
            BusinessResponse<BaseListReturnType<LoadListByNameAndAddressReturnType>> response = new BusinessResponse<BaseListReturnType<LoadListByNameAndAddressReturnType>>();

            try
            {
                response.Result = LoadListByNameAndAddressRaw(sortingPagingInfo);
            }
            catch (Exception ex)
            {
                response.Result = null;
                response.Exception = new BusinessLayerException(ex.Message, ex);
            }

            return response;
        }

        internal BaseListReturnType<LoadListByNameAndAddressReturnType> LoadListByNameAndAddressRaw(CustomerSortingPagingInfo sortingPagingInfo)
        {
            List<string> includes = new List<string>()
            {
                CustomerDatabaseReferences.COMPANY,
                CustomerDatabaseReferences.PERSON,
                String.Format("{0}.{1}.{2}",CustomerDatabaseReferences.COMPANY,CompanyDatabaseReferences.COMPANYLOCATIONS,CompanyLocationDatabaseReferences.ADDRESS),
                String.Format("{0}.{1}.{2}",CustomerDatabaseReferences.PERSON,PersonDatabaseReferences.PERSON_ADDRESS,Person_AddressDatabaseReferences.ADDRESS),
            };
            BaseListReturnType<Customer> dbCustomers = ServiceFactory.Instance.CustomerService.GetAllCustomersByPageRaw(sortingPagingInfo, c => c.FullName.StartsWith(sortingPagingInfo.Search), includes);

            BaseListReturnType<LoadListByNameAndAddressReturnType> customers = new BaseListReturnType<LoadListByNameAndAddressReturnType>();
            customers.TotalCount = dbCustomers.TotalCount;
            customers.EntityList = new List<LoadListByNameAndAddressReturnType>();
            dbCustomers.EntityList.ForEach(c =>
            {
                LoadListByNameAndAddressReturnType loadListByNameAndAddressReturnType = FormatCustomerForLoadListByNameAndAddress(c);
                customers.EntityList.Add(loadListByNameAndAddressReturnType);
            });
            return customers;
        }

        internal LoadListByNameAndAddressReturnType FormatCustomerForLoadListByNameAndAddress(Customer customer)
        {
            LoadListByNameAndAddressReturnType loadListByNameAndAddressReturnType = new LoadListByNameAndAddressReturnType();
            loadListByNameAndAddressReturnType.FullName = customer.FullName;
            loadListByNameAndAddressReturnType.FullAddress = "";
            loadListByNameAndAddressReturnType.Address1 = "";
            loadListByNameAndAddressReturnType.Address2 = "";
            loadListByNameAndAddressReturnType.Address3 = "";
            loadListByNameAndAddressReturnType.Address4 = "";
            loadListByNameAndAddressReturnType.City = "";
            Address address = null;
            if (customer.IdCustomerType == (long)CustomerTypeEnum.COMPANY && customer?.Company?.CompanyLocations?.FirstOrDefault()?.Address != null)
            {
                address = customer?.Company?.CompanyLocations?.FirstOrDefault()?.Address;
            }
            else if (customer.IdCustomerType == (long)CustomerTypeEnum.PERSON && customer?.Person?.Person_Address?.FirstOrDefault()?.Address != null)
            {
                address = customer?.Person?.Person_Address?.FirstOrDefault()?.Address;
            }

            if (address != null && address.AddressLine1 != null)
            {
                loadListByNameAndAddressReturnType.Address1 = address.AddressLine1;
                loadListByNameAndAddressReturnType.FullAddress += address.AddressLine1 + " ";
            }

            if (address != null && address.AddressLine2 != null)
            {
                loadListByNameAndAddressReturnType.Address2 = address.AddressLine2;
                loadListByNameAndAddressReturnType.FullAddress += address.AddressLine2 + " ";
            }

            if (address != null && address.AddressLine3 != null)
            {
                loadListByNameAndAddressReturnType.Address3 = address.AddressLine3;
                loadListByNameAndAddressReturnType.FullAddress += address.AddressLine3 + " ";
            }

            if (address != null && address.AddressLine4 != null)
            {
                loadListByNameAndAddressReturnType.Address4 = address.AddressLine4;
                loadListByNameAndAddressReturnType.FullAddress += address.AddressLine4 + " ";
            }

            if (address != null && address.City != null)
            {
                loadListByNameAndAddressReturnType.City = address.City;
                loadListByNameAndAddressReturnType.FullAddress += address.City + " ";
            }

            loadListByNameAndAddressReturnType.IdCustomer = customer.IdCustomer.Value;
            loadListByNameAndAddressReturnType.Customer = ServiceFactory.Instance.CustomerService.RemapCustomer(customer);
            return loadListByNameAndAddressReturnType;
        }


        public BusinessResponse<BaseListReturnType<Customer>> LoadListByName(CustomerSortingPagingInfo sortingPagingInfo)
        {
            BusinessResponse<BaseListReturnType<Customer>> response = new BusinessResponse<BaseListReturnType<Customer>>();

            try
            {
                response.Result = LoadListByNameRaw(sortingPagingInfo);
            }
            catch (Exception ex)
            {
                response.Result = null;
                response.Exception = new BusinessLayerException(ex.Message, ex);
            }

            return response;
        }

        internal BaseListReturnType<Customer> LoadListByNameRaw(CustomerSortingPagingInfo sortingPagingInfo)
        {
            Expression<Func<Customer, bool>> expression = property => property.IsDeactivated != true && property.FullName.StartsWith(sortingPagingInfo.Search);
            BaseListReturnType<Customer> dbCustomers = daoFactory.CustomerDao.GetAllCustomersByNameByPage(sortingPagingInfo, expression, null, true);
            return dbCustomers;
        }


        public BusinessResponse<GetCustomerByNidReturnType> GetCustomerByUniqueId(GetCustomerByUniqueIdDto getCustomerByUniqueIdDto)
        {
            BusinessResponse<GetCustomerByNidReturnType> response = new BusinessResponse<GetCustomerByNidReturnType>();

            try
            {
                response.Result = GetCustomerByUniqueIdRaw(getCustomerByUniqueIdDto);
            }
            catch (Exception ex)
            {
                response.Result = null;
                response.Exception = new BusinessLayerException(ex.Message, ex);
            }

            return response;
        }
        internal GetCustomerByNidReturnType GetCustomerByUniqueIdRaw(GetCustomerByUniqueIdDto getCustomerByUniqueIdDto)
        {
            GetCustomerByNidReturnType getCustomerByNidReturnType = new GetCustomerByNidReturnType();
            List<string> includes = new List<string>()
            {
                CustomerDatabaseReferences.COMPANY,
                CustomerDatabaseReferences.PERSON,
                String.Format("{0}.{1}.{2}",CustomerDatabaseReferences.COMPANY,CompanyDatabaseReferences.COMPANYLOCATIONS,CompanyLocationDatabaseReferences.ADDRESS),
                String.Format("{0}.{1}.{2}",CustomerDatabaseReferences.PERSON,PersonDatabaseReferences.PERSON_ADDRESS,Person_AddressDatabaseReferences.ADDRESS),
            };
            Customer dbCustomer = daoFactory.CustomerDao.GetCustomerCustom(c => c.Person.NationalIdentificationNumber != null && c.Person.NationalIdentificationNumber == getCustomerByUniqueIdDto.UniqueId);
            if (dbCustomer != null)
            {
                getCustomerByNidReturnType.Customer = FormatCustomerForLoadListByNameAndAddress(dbCustomer);
                getCustomerByNidReturnType.NationalIdentificationNumber = getCustomerByUniqueIdDto.UniqueId;
                getCustomerByNidReturnType.doesNidExists = true;
            }
            else
            {
                getCustomerByNidReturnType.doesNidExists = false;
            }

            return getCustomerByNidReturnType;
        }


        //public BusinessResponse<List<CustomerSyncReturnType>> GetDataToSync()
        //{
        //    BusinessResponse<List<CustomerSyncReturnType>> response = new BusinessResponse<List<CustomerSyncReturnType>>();
        //
        //    try
        //    {
        //        response.Result = GetDataToSyncRaw();
        //    }
        //    catch (Exception ex)
        //    {
        //        response.Result = null;
        //        response.Exception = new BusinessLayerException(ex.Message, ex);
        //    }
        //
        //    return response;
        //}
        //
        //internal List<CustomerSyncReturnType> GetDataToSyncRaw()
        //{
        //    List<CustomerSyncReturnType> customerSyncReturnTypes = new List<CustomerSyncReturnType>();
        //    long idUser = ServiceFactory.Instance.GlobalVariableService.UserLogged.Id;
        //    SyncClient syncClient = daoFactory.SyncClientDao.GetSyncClientCustom(c => c.IdUser == idUser);
        //    List<SyncClientEntity> syncClientEntities = daoFactory.SyncClientEntityDao
        //        .GetSyncClientEntityCustomList(c => c.IdSyncClient == syncClient.IdSyncClient && c.IdSyncEntityType == (long)SyncEntityTypeEnum.CUSTOMER
        //        && (c.IdSyncState == (long)SyncStateEnum.AWAITING_SYNC || c.IdSyncState == (long)SyncStateEnum.SYNC_ERROR_ON_CLIENT)).EntityList;
        //
        //    List<long> idCustomers = syncClientEntities.Select(s => long.Parse(s.IdLocalEntity)).ToList();
        //    List<string> includes = new List<string>() {
        //        CustomerDatabaseReferences.COMPANY,
        //        CustomerDatabaseReferences.PERSON,
        //        CustomerDatabaseReferences.CUSTOMERTYPE,
        //        String.Format("{0}.{1}.{2}.{3}",CustomerDatabaseReferences.COMPANY,CompanyDatabaseReferences.COMPANYLOCATIONS,CompanyLocationDatabaseReferences.ADDRESS,AddressDatabaseReferences.COUNTRY),
        //        String.Format("{0}.{1}.{2}.{3}",CustomerDatabaseReferences.PERSON,PersonDatabaseReferences.PERSON_ADDRESS,Person_AddressDatabaseReferences.ADDRESS,AddressDatabaseReferences.COUNTRY),
        //        String.Format("{0}.{1}",CustomerDatabaseReferences.PERSON,PersonDatabaseReferences.TITLE),
        //        String.Format("{0}.{1}.{2}",CustomerDatabaseReferences.PERSON,PersonDatabaseReferences.PERSON_CONTACTTYPE,Person_ContactTypeDatabaseReferences.CONTACTTYPE),
        //        String.Format("{0}.{1}.{2}",CustomerDatabaseReferences.COMPANY,CompanyDatabaseReferences.COMPANY_CONTACTTYPE,Company_ContactTypeDatabaseReferences.CONTACTTYPE)
        //    };
        //    List<Customer> customers = daoFactory.CustomerDao.GetCustomerCustomList(c => idCustomers.Contains(c.IdCustomer.Value), includes).EntityList;
        //
        //    syncClientEntities.ForEach(s =>
        //    {
        //        Customer customer = customers.Where(c => c.IdCustomer == long.Parse(s.IdLocalEntity)).First();
        //        Address address = null;
        //        List<CustomerContactSyncReturnType> customerContactSyncReturnTypes = new List<CustomerContactSyncReturnType>();
        //        if (customer.IdCustomerType == (long)CustomerTypeEnum.COMPANY)
        //        {
        //            address = customer.Company?.CompanyLocations?.FirstOrDefault()?.Address;
        //            customer.Company?.Company_ContactType?.ToList()?.ForEach(ct =>
        //            {
        //                CustomerContactSyncReturnType customerContactSyncReturnType = new CustomerContactSyncReturnType();
        //                customerContactSyncReturnType.IdContactType = ct?.IdContactType.Value;
        //                customerContactSyncReturnType.ContactKey = ct?.ContactType?.Description;
        //                customerContactSyncReturnType.ContactValue = ct?.Description;
        //                customerContactSyncReturnTypes.Add(customerContactSyncReturnType);
        //            });
        //        }
        //        else
        //        {
        //
        //            address = customer.Person?.Person_Address?.FirstOrDefault()?.Address;
        //            customer.Person?.Person_ContactType?.ToList()?.ForEach(ct =>
        //            {
        //                CustomerContactSyncReturnType customerContactSyncReturnType = new CustomerContactSyncReturnType();
        //                customerContactSyncReturnType.IdContactType = ct?.IdContactType.Value;
        //                customerContactSyncReturnType.ContactKey = ct?.ContactType?.Description;
        //                customerContactSyncReturnType.ContactValue = ct?.Description;
        //                customerContactSyncReturnTypes.Add(customerContactSyncReturnType);
        //            });
        //        }
        //
        //        CustomerSyncReturnType customerSyncReturnType = new CustomerSyncReturnType()
        //        {
        //            FullName = customer.FullName,
        //            CompanyName = customer.Company?.Name,
        //            Firstname = customer.Person?.Firstname,
        //            Lastname = customer.Person?.Lastname,
        //            Title = customer.Person?.Title?.Description,
        //            IdServerId = s.IdSyncClientEntity.ToString(),
        //            AddressLine1 = address?.AddressLine1,
        //            AddressLine2 = address?.AddressLine2,
        //            AddressLine3 = address?.AddressLine3,
        //            AddressLine4 = address?.AddressLine4,
        //            City = address?.City,
        //            Country = address?.Country?.Description,
        //            CustomerContactSyncReturnTypes = customerContactSyncReturnTypes
        //        };
        //
        //        customerSyncReturnTypes.Add(customerSyncReturnType);
        //    });
        //    return customerSyncReturnTypes;
        //}

        public Customer RemapCustomer(Customer customer)
        {
            Customer remappedCustomer = Mapper.MapCustomerSingle(customer, true);
            remappedCustomer.Transactions = new List<Transaction>();

            if (customer.Transactions != null)
            {
                customer.Transactions.ToList().ForEach(t =>
                {
                    Transaction transaction = Mapper.MapTransactionSingle(t, true);

                    if (t.TransactionDues != null)
                    {
                        t.TransactionDues.ToList().ForEach((td) =>
                        {
                            TransactionDue transactionDue = Mapper.MapTransactionDueSingle(td, true);
                            transaction.TransactionDues.Add(transactionDue);
                        });
                    }
                    remappedCustomer.Transactions.Add(transaction);
                });
            }
            if (customer.CustomerType != null)
            {
                remappedCustomer.CustomerType = Mapper.MapCustomerTypeSingle(customer.CustomerType, true);
            }
            if (customer.Company != null)
            {
                remappedCustomer.Company = ServiceFactory.Instance.CompanyService.RemapCompany(customer.Company);
            }

            if (customer.Person != null)
            {
                remappedCustomer.Person = ServiceFactory.Instance.PersonService.RemapPerson(customer.Person);
            }
            return remappedCustomer;
        }

    }
}
