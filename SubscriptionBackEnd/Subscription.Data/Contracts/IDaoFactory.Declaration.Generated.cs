using System;
using Subscription.Business;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Subscription.Data.EntityFramework;
using Subscription.Business.Common;
using System.Linq.Expressions;

namespace Subscription.Data
{
 	public partial interface IAddressDao
	{
  List<Address> GetAllAddresses(bool shouldRemap = false);
  List<Address> GetAllAddresses(SubscriptionEntities db,bool shouldRemap = false);
  BaseListReturnType<Address> GetAllAddressesByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Address, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<Address, dynamic> orderExpression = null);
  BaseListReturnType<Address> GetAllAddressesByPage(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<Address, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<Address, dynamic> orderExpression = null);
  
  BaseListReturnType<Address> GetAllAddressesByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Address, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<Address, dynamic> orderExpression = null);
  BaseListReturnType<Address> GetAllAddressesByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<Address, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<Address, dynamic> orderExpression = null);

 BaseListReturnType<Address> GetAllAddressesWithCompanyLocationsDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Address, bool>> expression = null,bool shouldRemap = false, Func<Address, dynamic> orderExpression = null);
 BaseListReturnType<Address> GetAllAddressesWithCompanyLocationsDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Address, bool>> expression = null,bool shouldRemap = false, Func<Address, dynamic> orderExpression = null);

 BaseListReturnType<Address> GetAllAddressesWithCity1DetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Address, bool>> expression = null,bool shouldRemap = false, Func<Address, dynamic> orderExpression = null);
 BaseListReturnType<Address> GetAllAddressesWithCity1DetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Address, bool>> expression = null,bool shouldRemap = false, Func<Address, dynamic> orderExpression = null);






BaseListReturnType<Address> GetAllAddressListByCity1(long idCity1);

BaseListReturnType<Address> GetAllAddressListByCity1(long idCity1, SubscriptionEntities db);

BaseListReturnType<Address> GetAllAddressListByCity1ByPage(long idCity1, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<Address> GetAllAddressListByCity1ByPage(long idCity1, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);



 BaseListReturnType<Address> GetAllAddressesWithCountryDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Address, bool>> expression = null,bool shouldRemap = false, Func<Address, dynamic> orderExpression = null);
 BaseListReturnType<Address> GetAllAddressesWithCountryDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Address, bool>> expression = null,bool shouldRemap = false, Func<Address, dynamic> orderExpression = null);






BaseListReturnType<Address> GetAllAddressListByCountry(long idCountry);

BaseListReturnType<Address> GetAllAddressListByCountry(long idCountry, SubscriptionEntities db);

BaseListReturnType<Address> GetAllAddressListByCountryByPage(long idCountry, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<Address> GetAllAddressListByCountryByPage(long idCountry, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);



 BaseListReturnType<Address> GetAllAddressesWithContactsDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Address, bool>> expression = null,bool shouldRemap = false, Func<Address, dynamic> orderExpression = null);
 BaseListReturnType<Address> GetAllAddressesWithContactsDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Address, bool>> expression = null,bool shouldRemap = false, Func<Address, dynamic> orderExpression = null);

 BaseListReturnType<Address> GetAllAddressesWithPerson_AddressDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Address, bool>> expression = null,bool shouldRemap = false, Func<Address, dynamic> orderExpression = null);
 BaseListReturnType<Address> GetAllAddressesWithPerson_AddressDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Address, bool>> expression = null,bool shouldRemap = false, Func<Address, dynamic> orderExpression = null);


List<Address> GetAddressListByIdList(List<long> addressIds);

List<Address> GetAddressListByIdList(List<long> addressIds, SubscriptionEntities db);

 BaseListReturnType<Address> GetAllAddressesWithCompanyLocationsDetails(bool shouldRemap = false);
 BaseListReturnType<Address> GetAllAddressesWithCity1Details(bool shouldRemap = false);
 BaseListReturnType<Address> GetAllAddressesWithCountryDetails(bool shouldRemap = false);
 BaseListReturnType<Address> GetAllAddressesWithContactsDetails(bool shouldRemap = false);
 BaseListReturnType<Address> GetAllAddressesWithPerson_AddressDetails(bool shouldRemap = false);
 BaseListReturnType<Address> GetAllAddressWitDetails( List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<Address> GetAllAddressWitDetails( SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 Address GetAddress(long idAddress,bool shouldRemap = false);
 Address GetAddress(long idAddress, SubscriptionEntities db,bool shouldRemap = false);
 Address GetAddressWithCompanyLocationsDetails(long idAddress,bool shouldRemap = false);
           List<CompanyLocation> UpdateCompanyLocationsForAddressWithoutSavingNewItem(List<CompanyLocation> newCompanyLocations,long idAddress);
    List<CompanyLocation> UpdateCompanyLocationsForAddressWithoutSavingNewItem(List<CompanyLocation> newCompanyLocations,long idAddress,SubscriptionEntities db);
          

    List<CompanyLocation> UpdateCompanyLocationsForAddress(List<CompanyLocation> newCompanyLocations,long idAddress);
    List<CompanyLocation> UpdateCompanyLocationsForAddress(List<CompanyLocation> newCompanyLocations,long idAddress,SubscriptionEntities db);
                           



 Address GetAddressWithCity1Details(long idAddress,bool shouldRemap = false);
    


 Address GetAddressWithCountryDetails(long idAddress,bool shouldRemap = false);
    


 Address GetAddressWithContactsDetails(long idAddress,bool shouldRemap = false);
           List<Contact> UpdateContactsForAddressWithoutSavingNewItem(List<Contact> newContacts,long idAddress);
    List<Contact> UpdateContactsForAddressWithoutSavingNewItem(List<Contact> newContacts,long idAddress,SubscriptionEntities db);
          

    List<Contact> UpdateContactsForAddress(List<Contact> newContacts,long idAddress);
    List<Contact> UpdateContactsForAddress(List<Contact> newContacts,long idAddress,SubscriptionEntities db);
                           



 Address GetAddressWithPerson_AddressDetails(long idAddress,bool shouldRemap = false);
           List<Person_Address> UpdatePerson_AddressForAddressWithoutSavingNewItem(List<Person_Address> newPerson_Address,long idAddress);
    List<Person_Address> UpdatePerson_AddressForAddressWithoutSavingNewItem(List<Person_Address> newPerson_Address,long idAddress,SubscriptionEntities db);
          

    List<Person_Address> UpdatePerson_AddressForAddress(List<Person_Address> newPerson_Address,long idAddress);
    List<Person_Address> UpdatePerson_AddressForAddress(List<Person_Address> newPerson_Address,long idAddress,SubscriptionEntities db);
                           



 Address GetAddressCustom( Expression<Func<Address, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 Address GetAddressCustom(SubscriptionEntities db, Expression<Func<Address, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<Address> GetAddressCustomList( Expression<Func<Address, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<Address, dynamic> orderExpression = null);
 BaseListReturnType<Address> GetAddressCustomList( SubscriptionEntities db , Expression<Func<Address, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<Address, dynamic> orderExpression = null);
 Address GetAddressWithDetails(long idAddress, List<string> includes = null,bool shouldRemap = false);
 Address GetAddressWithDetails(long idAddress, SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 Address GetAddressWitDetails(long idAddress,bool shouldRemap = false);
 Address GetAddressWitDetails(long idAddress, SubscriptionEntities db,bool shouldRemap = false);
 void SaveAddress(Address address);
 void SaveAddress(Address address, SubscriptionEntities db);
 void SaveOnlyAddress(Address address);
 void SaveOnlyAddress(Address address, SubscriptionEntities db);
 void DeleteAddress(Address address);
 void DeleteAddress(Address address, SubscriptionEntities db);		
  void DeletePermanentlyAddress(Address address);
 void DeletePermanentlyAddress(Address address, SubscriptionEntities db);	
	}
 	public partial interface IApprovalMessageDao
	{
  List<ApprovalMessage> GetAllApprovalMessages(bool shouldRemap = false);
  List<ApprovalMessage> GetAllApprovalMessages(SubscriptionEntities db,bool shouldRemap = false);
  BaseListReturnType<ApprovalMessage> GetAllApprovalMessagesByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<ApprovalMessage, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<ApprovalMessage, dynamic> orderExpression = null);
  BaseListReturnType<ApprovalMessage> GetAllApprovalMessagesByPage(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<ApprovalMessage, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<ApprovalMessage, dynamic> orderExpression = null);
  
  BaseListReturnType<ApprovalMessage> GetAllApprovalMessagesByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<ApprovalMessage, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<ApprovalMessage, dynamic> orderExpression = null);
  BaseListReturnType<ApprovalMessage> GetAllApprovalMessagesByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<ApprovalMessage, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<ApprovalMessage, dynamic> orderExpression = null);

 BaseListReturnType<ApprovalMessage> GetAllApprovalMessagesWithWorkflowActionDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<ApprovalMessage, bool>> expression = null,bool shouldRemap = false, Func<ApprovalMessage, dynamic> orderExpression = null);
 BaseListReturnType<ApprovalMessage> GetAllApprovalMessagesWithWorkflowActionDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<ApprovalMessage, bool>> expression = null,bool shouldRemap = false, Func<ApprovalMessage, dynamic> orderExpression = null);






BaseListReturnType<ApprovalMessage> GetAllApprovalMessageListByWorkflowAction(long idWorkflowAction);

BaseListReturnType<ApprovalMessage> GetAllApprovalMessageListByWorkflowAction(long idWorkflowAction, SubscriptionEntities db);

BaseListReturnType<ApprovalMessage> GetAllApprovalMessageListByWorkflowActionByPage(long idWorkflowAction, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<ApprovalMessage> GetAllApprovalMessageListByWorkflowActionByPage(long idWorkflowAction, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);



 BaseListReturnType<ApprovalMessage> GetAllApprovalMessagesWithWorkflowDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<ApprovalMessage, bool>> expression = null,bool shouldRemap = false, Func<ApprovalMessage, dynamic> orderExpression = null);
 BaseListReturnType<ApprovalMessage> GetAllApprovalMessagesWithWorkflowDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<ApprovalMessage, bool>> expression = null,bool shouldRemap = false, Func<ApprovalMessage, dynamic> orderExpression = null);






BaseListReturnType<ApprovalMessage> GetAllApprovalMessageListByWorkflow(long idWorkflow);

BaseListReturnType<ApprovalMessage> GetAllApprovalMessageListByWorkflow(long idWorkflow, SubscriptionEntities db);

BaseListReturnType<ApprovalMessage> GetAllApprovalMessageListByWorkflowByPage(long idWorkflow, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<ApprovalMessage> GetAllApprovalMessageListByWorkflowByPage(long idWorkflow, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);




List<ApprovalMessage> GetApprovalMessageListByIdList(List<long> approvalMessageIds);

List<ApprovalMessage> GetApprovalMessageListByIdList(List<long> approvalMessageIds, SubscriptionEntities db);

 BaseListReturnType<ApprovalMessage> GetAllApprovalMessagesWithWorkflowActionDetails(bool shouldRemap = false);
 BaseListReturnType<ApprovalMessage> GetAllApprovalMessagesWithWorkflowDetails(bool shouldRemap = false);
 BaseListReturnType<ApprovalMessage> GetAllApprovalMessageWitDetails( List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<ApprovalMessage> GetAllApprovalMessageWitDetails( SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 ApprovalMessage GetApprovalMessage(long idApprovalMessage,bool shouldRemap = false);
 ApprovalMessage GetApprovalMessage(long idApprovalMessage, SubscriptionEntities db,bool shouldRemap = false);
 ApprovalMessage GetApprovalMessageWithWorkflowActionDetails(long idApprovalMessage,bool shouldRemap = false);
    


 ApprovalMessage GetApprovalMessageWithWorkflowDetails(long idApprovalMessage,bool shouldRemap = false);
    


 ApprovalMessage GetApprovalMessageCustom( Expression<Func<ApprovalMessage, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 ApprovalMessage GetApprovalMessageCustom(SubscriptionEntities db, Expression<Func<ApprovalMessage, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<ApprovalMessage> GetApprovalMessageCustomList( Expression<Func<ApprovalMessage, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<ApprovalMessage, dynamic> orderExpression = null);
 BaseListReturnType<ApprovalMessage> GetApprovalMessageCustomList( SubscriptionEntities db , Expression<Func<ApprovalMessage, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<ApprovalMessage, dynamic> orderExpression = null);
 ApprovalMessage GetApprovalMessageWithDetails(long idApprovalMessage, List<string> includes = null,bool shouldRemap = false);
 ApprovalMessage GetApprovalMessageWithDetails(long idApprovalMessage, SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 ApprovalMessage GetApprovalMessageWitDetails(long idApprovalMessage,bool shouldRemap = false);
 ApprovalMessage GetApprovalMessageWitDetails(long idApprovalMessage, SubscriptionEntities db,bool shouldRemap = false);
 void SaveApprovalMessage(ApprovalMessage approvalMessage);
 void SaveApprovalMessage(ApprovalMessage approvalMessage, SubscriptionEntities db);
 void SaveOnlyApprovalMessage(ApprovalMessage approvalMessage);
 void SaveOnlyApprovalMessage(ApprovalMessage approvalMessage, SubscriptionEntities db);
 void DeleteApprovalMessage(ApprovalMessage approvalMessage);
 void DeleteApprovalMessage(ApprovalMessage approvalMessage, SubscriptionEntities db);		
  void DeletePermanentlyApprovalMessage(ApprovalMessage approvalMessage);
 void DeletePermanentlyApprovalMessage(ApprovalMessage approvalMessage, SubscriptionEntities db);	
	}
 	public partial interface IBankDao
	{
  List<Bank> GetAllBanks(bool shouldRemap = false);
  List<Bank> GetAllBanks(SubscriptionEntities db,bool shouldRemap = false);
  BaseListReturnType<Bank> GetAllBanksByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Bank, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<Bank, dynamic> orderExpression = null);
  BaseListReturnType<Bank> GetAllBanksByPage(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<Bank, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<Bank, dynamic> orderExpression = null);
  
  BaseListReturnType<Bank> GetAllBanksByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Bank, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<Bank, dynamic> orderExpression = null);
  BaseListReturnType<Bank> GetAllBanksByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<Bank, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<Bank, dynamic> orderExpression = null);

 BaseListReturnType<Bank> GetAllBanksWithBankStatementStagingsDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Bank, bool>> expression = null,bool shouldRemap = false, Func<Bank, dynamic> orderExpression = null);
 BaseListReturnType<Bank> GetAllBanksWithBankStatementStagingsDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Bank, bool>> expression = null,bool shouldRemap = false, Func<Bank, dynamic> orderExpression = null);

 BaseListReturnType<Bank> GetAllBanksWithPaymentMethodDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Bank, bool>> expression = null,bool shouldRemap = false, Func<Bank, dynamic> orderExpression = null);
 BaseListReturnType<Bank> GetAllBanksWithPaymentMethodDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Bank, bool>> expression = null,bool shouldRemap = false, Func<Bank, dynamic> orderExpression = null);






BaseListReturnType<Bank> GetAllBankListByPaymentMethod(long idPaymentMethod);

BaseListReturnType<Bank> GetAllBankListByPaymentMethod(long idPaymentMethod, SubscriptionEntities db);

BaseListReturnType<Bank> GetAllBankListByPaymentMethodByPage(long idPaymentMethod, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<Bank> GetAllBankListByPaymentMethodByPage(long idPaymentMethod, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);



 BaseListReturnType<Bank> GetAllBanksWithTransactionAccountDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Bank, bool>> expression = null,bool shouldRemap = false, Func<Bank, dynamic> orderExpression = null);
 BaseListReturnType<Bank> GetAllBanksWithTransactionAccountDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Bank, bool>> expression = null,bool shouldRemap = false, Func<Bank, dynamic> orderExpression = null);






BaseListReturnType<Bank> GetAllBankListByTransactionAccount(long idTransactionAccount);

BaseListReturnType<Bank> GetAllBankListByTransactionAccount(long idTransactionAccount, SubscriptionEntities db);

BaseListReturnType<Bank> GetAllBankListByTransactionAccountByPage(long idTransactionAccount, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<Bank> GetAllBankListByTransactionAccountByPage(long idTransactionAccount, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);



 BaseListReturnType<Bank> GetAllBanksWithTransactionTemplateDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Bank, bool>> expression = null,bool shouldRemap = false, Func<Bank, dynamic> orderExpression = null);
 BaseListReturnType<Bank> GetAllBanksWithTransactionTemplateDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Bank, bool>> expression = null,bool shouldRemap = false, Func<Bank, dynamic> orderExpression = null);






BaseListReturnType<Bank> GetAllBankListByTransactionTemplate(long idTransactionTemplate);

BaseListReturnType<Bank> GetAllBankListByTransactionTemplate(long idTransactionTemplate, SubscriptionEntities db);

BaseListReturnType<Bank> GetAllBankListByTransactionTemplateByPage(long idTransactionTemplate, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<Bank> GetAllBankListByTransactionTemplateByPage(long idTransactionTemplate, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);



 BaseListReturnType<Bank> GetAllBanksWithPaymentDetailsDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Bank, bool>> expression = null,bool shouldRemap = false, Func<Bank, dynamic> orderExpression = null);
 BaseListReturnType<Bank> GetAllBanksWithPaymentDetailsDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Bank, bool>> expression = null,bool shouldRemap = false, Func<Bank, dynamic> orderExpression = null);


List<Bank> GetBankListByIdList(List<long> bankIds);

List<Bank> GetBankListByIdList(List<long> bankIds, SubscriptionEntities db);

 BaseListReturnType<Bank> GetAllBanksWithBankStatementStagingsDetails(bool shouldRemap = false);
 BaseListReturnType<Bank> GetAllBanksWithPaymentMethodDetails(bool shouldRemap = false);
 BaseListReturnType<Bank> GetAllBanksWithTransactionAccountDetails(bool shouldRemap = false);
 BaseListReturnType<Bank> GetAllBanksWithTransactionTemplateDetails(bool shouldRemap = false);
 BaseListReturnType<Bank> GetAllBanksWithPaymentDetailsDetails(bool shouldRemap = false);
 BaseListReturnType<Bank> GetAllBankWitDetails( List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<Bank> GetAllBankWitDetails( SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 Bank GetBank(long idBank,bool shouldRemap = false);
 Bank GetBank(long idBank, SubscriptionEntities db,bool shouldRemap = false);
 Bank GetBankWithBankStatementStagingsDetails(long idBank,bool shouldRemap = false);
           List<BankStatementStaging> UpdateBankStatementStagingsForBankWithoutSavingNewItem(List<BankStatementStaging> newBankStatementStagings,long idBank);
    List<BankStatementStaging> UpdateBankStatementStagingsForBankWithoutSavingNewItem(List<BankStatementStaging> newBankStatementStagings,long idBank,SubscriptionEntities db);
          

    List<BankStatementStaging> UpdateBankStatementStagingsForBank(List<BankStatementStaging> newBankStatementStagings,long idBank);
    List<BankStatementStaging> UpdateBankStatementStagingsForBank(List<BankStatementStaging> newBankStatementStagings,long idBank,SubscriptionEntities db);
                           



 Bank GetBankWithPaymentMethodDetails(long idBank,bool shouldRemap = false);
    


 Bank GetBankWithTransactionAccountDetails(long idBank,bool shouldRemap = false);
    


 Bank GetBankWithTransactionTemplateDetails(long idBank,bool shouldRemap = false);
    


 Bank GetBankWithPaymentDetailsDetails(long idBank,bool shouldRemap = false);
           List<PaymentDetail> UpdatePaymentDetailsForBankWithoutSavingNewItem(List<PaymentDetail> newPaymentDetails,long idBank);
    List<PaymentDetail> UpdatePaymentDetailsForBankWithoutSavingNewItem(List<PaymentDetail> newPaymentDetails,long idBank,SubscriptionEntities db);
          

    List<PaymentDetail> UpdatePaymentDetailsForBank(List<PaymentDetail> newPaymentDetails,long idBank);
    List<PaymentDetail> UpdatePaymentDetailsForBank(List<PaymentDetail> newPaymentDetails,long idBank,SubscriptionEntities db);
                           



 Bank GetBankCustom( Expression<Func<Bank, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 Bank GetBankCustom(SubscriptionEntities db, Expression<Func<Bank, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<Bank> GetBankCustomList( Expression<Func<Bank, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<Bank, dynamic> orderExpression = null);
 BaseListReturnType<Bank> GetBankCustomList( SubscriptionEntities db , Expression<Func<Bank, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<Bank, dynamic> orderExpression = null);
 Bank GetBankWithDetails(long idBank, List<string> includes = null,bool shouldRemap = false);
 Bank GetBankWithDetails(long idBank, SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 Bank GetBankWitDetails(long idBank,bool shouldRemap = false);
 Bank GetBankWitDetails(long idBank, SubscriptionEntities db,bool shouldRemap = false);
 void SaveBank(Bank bank);
 void SaveBank(Bank bank, SubscriptionEntities db);
 void SaveOnlyBank(Bank bank);
 void SaveOnlyBank(Bank bank, SubscriptionEntities db);
 void DeleteBank(Bank bank);
 void DeleteBank(Bank bank, SubscriptionEntities db);		
  void DeletePermanentlyBank(Bank bank);
 void DeletePermanentlyBank(Bank bank, SubscriptionEntities db);	
	}
 	public partial interface IBankReconHitTypeDao
	{
  List<BankReconHitType> GetAllBankReconHitTypes(bool shouldRemap = false);
  List<BankReconHitType> GetAllBankReconHitTypes(SubscriptionEntities db,bool shouldRemap = false);
  BaseListReturnType<BankReconHitType> GetAllBankReconHitTypesByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<BankReconHitType, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<BankReconHitType, dynamic> orderExpression = null);
  BaseListReturnType<BankReconHitType> GetAllBankReconHitTypesByPage(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<BankReconHitType, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<BankReconHitType, dynamic> orderExpression = null);
  
  BaseListReturnType<BankReconHitType> GetAllBankReconHitTypesByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<BankReconHitType, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<BankReconHitType, dynamic> orderExpression = null);
  BaseListReturnType<BankReconHitType> GetAllBankReconHitTypesByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<BankReconHitType, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<BankReconHitType, dynamic> orderExpression = null);

 BaseListReturnType<BankReconHitType> GetAllBankReconHitTypesWithBankStatementStagingHitsDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<BankReconHitType, bool>> expression = null,bool shouldRemap = false, Func<BankReconHitType, dynamic> orderExpression = null);
 BaseListReturnType<BankReconHitType> GetAllBankReconHitTypesWithBankStatementStagingHitsDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<BankReconHitType, bool>> expression = null,bool shouldRemap = false, Func<BankReconHitType, dynamic> orderExpression = null);


List<BankReconHitType> GetBankReconHitTypeListByIdList(List<long> bankReconHitTypeIds);

List<BankReconHitType> GetBankReconHitTypeListByIdList(List<long> bankReconHitTypeIds, SubscriptionEntities db);

 BaseListReturnType<BankReconHitType> GetAllBankReconHitTypesWithBankStatementStagingHitsDetails(bool shouldRemap = false);
 BaseListReturnType<BankReconHitType> GetAllBankReconHitTypeWitDetails( List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<BankReconHitType> GetAllBankReconHitTypeWitDetails( SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 BankReconHitType GetBankReconHitType(long idBankReconHitType,bool shouldRemap = false);
 BankReconHitType GetBankReconHitType(long idBankReconHitType, SubscriptionEntities db,bool shouldRemap = false);
 BankReconHitType GetBankReconHitTypeWithBankStatementStagingHitsDetails(long idBankReconHitType,bool shouldRemap = false);
           List<BankStatementStagingHit> UpdateBankStatementStagingHitsForBankReconHitTypeWithoutSavingNewItem(List<BankStatementStagingHit> newBankStatementStagingHits,long idBankReconHitType);
    List<BankStatementStagingHit> UpdateBankStatementStagingHitsForBankReconHitTypeWithoutSavingNewItem(List<BankStatementStagingHit> newBankStatementStagingHits,long idBankReconHitType,SubscriptionEntities db);
          

    List<BankStatementStagingHit> UpdateBankStatementStagingHitsForBankReconHitType(List<BankStatementStagingHit> newBankStatementStagingHits,long idBankReconHitType);
    List<BankStatementStagingHit> UpdateBankStatementStagingHitsForBankReconHitType(List<BankStatementStagingHit> newBankStatementStagingHits,long idBankReconHitType,SubscriptionEntities db);
                           



 BankReconHitType GetBankReconHitTypeCustom( Expression<Func<BankReconHitType, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 BankReconHitType GetBankReconHitTypeCustom(SubscriptionEntities db, Expression<Func<BankReconHitType, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<BankReconHitType> GetBankReconHitTypeCustomList( Expression<Func<BankReconHitType, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<BankReconHitType, dynamic> orderExpression = null);
 BaseListReturnType<BankReconHitType> GetBankReconHitTypeCustomList( SubscriptionEntities db , Expression<Func<BankReconHitType, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<BankReconHitType, dynamic> orderExpression = null);
 BankReconHitType GetBankReconHitTypeWithDetails(long idBankReconHitType, List<string> includes = null,bool shouldRemap = false);
 BankReconHitType GetBankReconHitTypeWithDetails(long idBankReconHitType, SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 BankReconHitType GetBankReconHitTypeWitDetails(long idBankReconHitType,bool shouldRemap = false);
 BankReconHitType GetBankReconHitTypeWitDetails(long idBankReconHitType, SubscriptionEntities db,bool shouldRemap = false);
 void SaveBankReconHitType(BankReconHitType bankReconHitType);
 void SaveBankReconHitType(BankReconHitType bankReconHitType, SubscriptionEntities db);
 void SaveOnlyBankReconHitType(BankReconHitType bankReconHitType);
 void SaveOnlyBankReconHitType(BankReconHitType bankReconHitType, SubscriptionEntities db);
 void DeleteBankReconHitType(BankReconHitType bankReconHitType);
 void DeleteBankReconHitType(BankReconHitType bankReconHitType, SubscriptionEntities db);		
  void DeletePermanentlyBankReconHitType(BankReconHitType bankReconHitType);
 void DeletePermanentlyBankReconHitType(BankReconHitType bankReconHitType, SubscriptionEntities db);	
	}
 	public partial interface IBankReconOrderProcessStateDao
	{
  List<BankReconOrderProcessState> GetAllBankReconOrderProcessStates(bool shouldRemap = false);
  List<BankReconOrderProcessState> GetAllBankReconOrderProcessStates(SubscriptionEntities db,bool shouldRemap = false);
  BaseListReturnType<BankReconOrderProcessState> GetAllBankReconOrderProcessStatesByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<BankReconOrderProcessState, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<BankReconOrderProcessState, dynamic> orderExpression = null);
  BaseListReturnType<BankReconOrderProcessState> GetAllBankReconOrderProcessStatesByPage(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<BankReconOrderProcessState, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<BankReconOrderProcessState, dynamic> orderExpression = null);
  
  BaseListReturnType<BankReconOrderProcessState> GetAllBankReconOrderProcessStatesByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<BankReconOrderProcessState, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<BankReconOrderProcessState, dynamic> orderExpression = null);
  BaseListReturnType<BankReconOrderProcessState> GetAllBankReconOrderProcessStatesByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<BankReconOrderProcessState, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<BankReconOrderProcessState, dynamic> orderExpression = null);

 BaseListReturnType<BankReconOrderProcessState> GetAllBankReconOrderProcessStatesWithBankStatementStagingsDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<BankReconOrderProcessState, bool>> expression = null,bool shouldRemap = false, Func<BankReconOrderProcessState, dynamic> orderExpression = null);
 BaseListReturnType<BankReconOrderProcessState> GetAllBankReconOrderProcessStatesWithBankStatementStagingsDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<BankReconOrderProcessState, bool>> expression = null,bool shouldRemap = false, Func<BankReconOrderProcessState, dynamic> orderExpression = null);


List<BankReconOrderProcessState> GetBankReconOrderProcessStateListByIdList(List<long> bankReconOrderProcessStateIds);

List<BankReconOrderProcessState> GetBankReconOrderProcessStateListByIdList(List<long> bankReconOrderProcessStateIds, SubscriptionEntities db);

 BaseListReturnType<BankReconOrderProcessState> GetAllBankReconOrderProcessStatesWithBankStatementStagingsDetails(bool shouldRemap = false);
 BaseListReturnType<BankReconOrderProcessState> GetAllBankReconOrderProcessStateWitDetails( List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<BankReconOrderProcessState> GetAllBankReconOrderProcessStateWitDetails( SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 BankReconOrderProcessState GetBankReconOrderProcessState(long idBankReconOrderProcessState,bool shouldRemap = false);
 BankReconOrderProcessState GetBankReconOrderProcessState(long idBankReconOrderProcessState, SubscriptionEntities db,bool shouldRemap = false);
 BankReconOrderProcessState GetBankReconOrderProcessStateWithBankStatementStagingsDetails(long idBankReconOrderProcessState,bool shouldRemap = false);
           List<BankStatementStaging> UpdateBankStatementStagingsForBankReconOrderProcessStateWithoutSavingNewItem(List<BankStatementStaging> newBankStatementStagings,long idBankReconOrderProcessState);
    List<BankStatementStaging> UpdateBankStatementStagingsForBankReconOrderProcessStateWithoutSavingNewItem(List<BankStatementStaging> newBankStatementStagings,long idBankReconOrderProcessState,SubscriptionEntities db);
          

    List<BankStatementStaging> UpdateBankStatementStagingsForBankReconOrderProcessState(List<BankStatementStaging> newBankStatementStagings,long idBankReconOrderProcessState);
    List<BankStatementStaging> UpdateBankStatementStagingsForBankReconOrderProcessState(List<BankStatementStaging> newBankStatementStagings,long idBankReconOrderProcessState,SubscriptionEntities db);
                           



 BankReconOrderProcessState GetBankReconOrderProcessStateCustom( Expression<Func<BankReconOrderProcessState, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 BankReconOrderProcessState GetBankReconOrderProcessStateCustom(SubscriptionEntities db, Expression<Func<BankReconOrderProcessState, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<BankReconOrderProcessState> GetBankReconOrderProcessStateCustomList( Expression<Func<BankReconOrderProcessState, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<BankReconOrderProcessState, dynamic> orderExpression = null);
 BaseListReturnType<BankReconOrderProcessState> GetBankReconOrderProcessStateCustomList( SubscriptionEntities db , Expression<Func<BankReconOrderProcessState, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<BankReconOrderProcessState, dynamic> orderExpression = null);
 BankReconOrderProcessState GetBankReconOrderProcessStateWithDetails(long idBankReconOrderProcessState, List<string> includes = null,bool shouldRemap = false);
 BankReconOrderProcessState GetBankReconOrderProcessStateWithDetails(long idBankReconOrderProcessState, SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 BankReconOrderProcessState GetBankReconOrderProcessStateWitDetails(long idBankReconOrderProcessState,bool shouldRemap = false);
 BankReconOrderProcessState GetBankReconOrderProcessStateWitDetails(long idBankReconOrderProcessState, SubscriptionEntities db,bool shouldRemap = false);
 void SaveBankReconOrderProcessState(BankReconOrderProcessState bankReconOrderProcessState);
 void SaveBankReconOrderProcessState(BankReconOrderProcessState bankReconOrderProcessState, SubscriptionEntities db);
 void SaveOnlyBankReconOrderProcessState(BankReconOrderProcessState bankReconOrderProcessState);
 void SaveOnlyBankReconOrderProcessState(BankReconOrderProcessState bankReconOrderProcessState, SubscriptionEntities db);
 void DeleteBankReconOrderProcessState(BankReconOrderProcessState bankReconOrderProcessState);
 void DeleteBankReconOrderProcessState(BankReconOrderProcessState bankReconOrderProcessState, SubscriptionEntities db);		
  void DeletePermanentlyBankReconOrderProcessState(BankReconOrderProcessState bankReconOrderProcessState);
 void DeletePermanentlyBankReconOrderProcessState(BankReconOrderProcessState bankReconOrderProcessState, SubscriptionEntities db);	
	}
 	public partial interface IBankReconOrderTypeDao
	{
  List<BankReconOrderType> GetAllBankReconOrderTypes(bool shouldRemap = false);
  List<BankReconOrderType> GetAllBankReconOrderTypes(SubscriptionEntities db,bool shouldRemap = false);
  BaseListReturnType<BankReconOrderType> GetAllBankReconOrderTypesByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<BankReconOrderType, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<BankReconOrderType, dynamic> orderExpression = null);
  BaseListReturnType<BankReconOrderType> GetAllBankReconOrderTypesByPage(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<BankReconOrderType, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<BankReconOrderType, dynamic> orderExpression = null);
  
  BaseListReturnType<BankReconOrderType> GetAllBankReconOrderTypesByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<BankReconOrderType, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<BankReconOrderType, dynamic> orderExpression = null);
  BaseListReturnType<BankReconOrderType> GetAllBankReconOrderTypesByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<BankReconOrderType, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<BankReconOrderType, dynamic> orderExpression = null);

 BaseListReturnType<BankReconOrderType> GetAllBankReconOrderTypesWithBankStatementStagingDetailsDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<BankReconOrderType, bool>> expression = null,bool shouldRemap = false, Func<BankReconOrderType, dynamic> orderExpression = null);
 BaseListReturnType<BankReconOrderType> GetAllBankReconOrderTypesWithBankStatementStagingDetailsDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<BankReconOrderType, bool>> expression = null,bool shouldRemap = false, Func<BankReconOrderType, dynamic> orderExpression = null);


List<BankReconOrderType> GetBankReconOrderTypeListByIdList(List<long> bankReconOrderTypeIds);

List<BankReconOrderType> GetBankReconOrderTypeListByIdList(List<long> bankReconOrderTypeIds, SubscriptionEntities db);

 BaseListReturnType<BankReconOrderType> GetAllBankReconOrderTypesWithBankStatementStagingDetailsDetails(bool shouldRemap = false);
 BaseListReturnType<BankReconOrderType> GetAllBankReconOrderTypeWitDetails( List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<BankReconOrderType> GetAllBankReconOrderTypeWitDetails( SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 BankReconOrderType GetBankReconOrderType(long idBankReconOrderType,bool shouldRemap = false);
 BankReconOrderType GetBankReconOrderType(long idBankReconOrderType, SubscriptionEntities db,bool shouldRemap = false);
 BankReconOrderType GetBankReconOrderTypeWithBankStatementStagingDetailsDetails(long idBankReconOrderType,bool shouldRemap = false);
           List<BankStatementStagingDetail> UpdateBankStatementStagingDetailsForBankReconOrderTypeWithoutSavingNewItem(List<BankStatementStagingDetail> newBankStatementStagingDetails,long idBankReconOrderType);
    List<BankStatementStagingDetail> UpdateBankStatementStagingDetailsForBankReconOrderTypeWithoutSavingNewItem(List<BankStatementStagingDetail> newBankStatementStagingDetails,long idBankReconOrderType,SubscriptionEntities db);
          

    List<BankStatementStagingDetail> UpdateBankStatementStagingDetailsForBankReconOrderType(List<BankStatementStagingDetail> newBankStatementStagingDetails,long idBankReconOrderType);
    List<BankStatementStagingDetail> UpdateBankStatementStagingDetailsForBankReconOrderType(List<BankStatementStagingDetail> newBankStatementStagingDetails,long idBankReconOrderType,SubscriptionEntities db);
                           



 BankReconOrderType GetBankReconOrderTypeCustom( Expression<Func<BankReconOrderType, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 BankReconOrderType GetBankReconOrderTypeCustom(SubscriptionEntities db, Expression<Func<BankReconOrderType, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<BankReconOrderType> GetBankReconOrderTypeCustomList( Expression<Func<BankReconOrderType, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<BankReconOrderType, dynamic> orderExpression = null);
 BaseListReturnType<BankReconOrderType> GetBankReconOrderTypeCustomList( SubscriptionEntities db , Expression<Func<BankReconOrderType, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<BankReconOrderType, dynamic> orderExpression = null);
 BankReconOrderType GetBankReconOrderTypeWithDetails(long idBankReconOrderType, List<string> includes = null,bool shouldRemap = false);
 BankReconOrderType GetBankReconOrderTypeWithDetails(long idBankReconOrderType, SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 BankReconOrderType GetBankReconOrderTypeWitDetails(long idBankReconOrderType,bool shouldRemap = false);
 BankReconOrderType GetBankReconOrderTypeWitDetails(long idBankReconOrderType, SubscriptionEntities db,bool shouldRemap = false);
 void SaveBankReconOrderType(BankReconOrderType bankReconOrderType);
 void SaveBankReconOrderType(BankReconOrderType bankReconOrderType, SubscriptionEntities db);
 void SaveOnlyBankReconOrderType(BankReconOrderType bankReconOrderType);
 void SaveOnlyBankReconOrderType(BankReconOrderType bankReconOrderType, SubscriptionEntities db);
 void DeleteBankReconOrderType(BankReconOrderType bankReconOrderType);
 void DeleteBankReconOrderType(BankReconOrderType bankReconOrderType, SubscriptionEntities db);		
  void DeletePermanentlyBankReconOrderType(BankReconOrderType bankReconOrderType);
 void DeletePermanentlyBankReconOrderType(BankReconOrderType bankReconOrderType, SubscriptionEntities db);	
	}
 	public partial interface IBankStatementHitListDao
	{
  List<BankStatementHitList> GetAllBankStatementHitLists(bool shouldRemap = false);
  List<BankStatementHitList> GetAllBankStatementHitLists(SubscriptionEntities db,bool shouldRemap = false);
  BaseListReturnType<BankStatementHitList> GetAllBankStatementHitListsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<BankStatementHitList, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<BankStatementHitList, dynamic> orderExpression = null);
  BaseListReturnType<BankStatementHitList> GetAllBankStatementHitListsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<BankStatementHitList, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<BankStatementHitList, dynamic> orderExpression = null);
  
  BaseListReturnType<BankStatementHitList> GetAllBankStatementHitListsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<BankStatementHitList, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<BankStatementHitList, dynamic> orderExpression = null);
  BaseListReturnType<BankStatementHitList> GetAllBankStatementHitListsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<BankStatementHitList, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<BankStatementHitList, dynamic> orderExpression = null);

 BaseListReturnType<BankStatementHitList> GetAllBankStatementHitListsWithBankStatementStagingDetailDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<BankStatementHitList, bool>> expression = null,bool shouldRemap = false, Func<BankStatementHitList, dynamic> orderExpression = null);
 BaseListReturnType<BankStatementHitList> GetAllBankStatementHitListsWithBankStatementStagingDetailDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<BankStatementHitList, bool>> expression = null,bool shouldRemap = false, Func<BankStatementHitList, dynamic> orderExpression = null);






BaseListReturnType<BankStatementHitList> GetAllBankStatementHitListListByBankStatementStagingDetail(long idBankStatementStagingDetail);

BaseListReturnType<BankStatementHitList> GetAllBankStatementHitListListByBankStatementStagingDetail(long idBankStatementStagingDetail, SubscriptionEntities db);

BaseListReturnType<BankStatementHitList> GetAllBankStatementHitListListByBankStatementStagingDetailByPage(long idBankStatementStagingDetail, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<BankStatementHitList> GetAllBankStatementHitListListByBankStatementStagingDetailByPage(long idBankStatementStagingDetail, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);



 BaseListReturnType<BankStatementHitList> GetAllBankStatementHitListsWithBankStatementHitList_TransactionPresetDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<BankStatementHitList, bool>> expression = null,bool shouldRemap = false, Func<BankStatementHitList, dynamic> orderExpression = null);
 BaseListReturnType<BankStatementHitList> GetAllBankStatementHitListsWithBankStatementHitList_TransactionPresetDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<BankStatementHitList, bool>> expression = null,bool shouldRemap = false, Func<BankStatementHitList, dynamic> orderExpression = null);

 BaseListReturnType<BankStatementHitList> GetAllBankStatementHitListsWithBankStatementStagingHitsDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<BankStatementHitList, bool>> expression = null,bool shouldRemap = false, Func<BankStatementHitList, dynamic> orderExpression = null);
 BaseListReturnType<BankStatementHitList> GetAllBankStatementHitListsWithBankStatementStagingHitsDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<BankStatementHitList, bool>> expression = null,bool shouldRemap = false, Func<BankStatementHitList, dynamic> orderExpression = null);

 BaseListReturnType<BankStatementHitList> GetAllBankStatementHitListsWithTemporaryTransactionsDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<BankStatementHitList, bool>> expression = null,bool shouldRemap = false, Func<BankStatementHitList, dynamic> orderExpression = null);
 BaseListReturnType<BankStatementHitList> GetAllBankStatementHitListsWithTemporaryTransactionsDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<BankStatementHitList, bool>> expression = null,bool shouldRemap = false, Func<BankStatementHitList, dynamic> orderExpression = null);


List<BankStatementHitList> GetBankStatementHitListListByIdList(List<long> bankStatementHitListIds);

List<BankStatementHitList> GetBankStatementHitListListByIdList(List<long> bankStatementHitListIds, SubscriptionEntities db);

 BaseListReturnType<BankStatementHitList> GetAllBankStatementHitListsWithBankStatementStagingDetailDetails(bool shouldRemap = false);
 BaseListReturnType<BankStatementHitList> GetAllBankStatementHitListsWithBankStatementHitList_TransactionPresetDetails(bool shouldRemap = false);
 BaseListReturnType<BankStatementHitList> GetAllBankStatementHitListsWithBankStatementStagingHitsDetails(bool shouldRemap = false);
 BaseListReturnType<BankStatementHitList> GetAllBankStatementHitListsWithTemporaryTransactionsDetails(bool shouldRemap = false);
 BaseListReturnType<BankStatementHitList> GetAllBankStatementHitListWitDetails( List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<BankStatementHitList> GetAllBankStatementHitListWitDetails( SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 BankStatementHitList GetBankStatementHitList(long idBankStatementHitList,bool shouldRemap = false);
 BankStatementHitList GetBankStatementHitList(long idBankStatementHitList, SubscriptionEntities db,bool shouldRemap = false);
 BankStatementHitList GetBankStatementHitListWithBankStatementStagingDetailDetails(long idBankStatementHitList,bool shouldRemap = false);
    


 BankStatementHitList GetBankStatementHitListWithBankStatementHitList_TransactionPresetDetails(long idBankStatementHitList,bool shouldRemap = false);
           List<BankStatementHitList_TransactionPreset> UpdateBankStatementHitList_TransactionPresetForBankStatementHitListWithoutSavingNewItem(List<BankStatementHitList_TransactionPreset> newBankStatementHitList_TransactionPreset,long idBankStatementHitList);
    List<BankStatementHitList_TransactionPreset> UpdateBankStatementHitList_TransactionPresetForBankStatementHitListWithoutSavingNewItem(List<BankStatementHitList_TransactionPreset> newBankStatementHitList_TransactionPreset,long idBankStatementHitList,SubscriptionEntities db);
          

    List<BankStatementHitList_TransactionPreset> UpdateBankStatementHitList_TransactionPresetForBankStatementHitList(List<BankStatementHitList_TransactionPreset> newBankStatementHitList_TransactionPreset,long idBankStatementHitList);
    List<BankStatementHitList_TransactionPreset> UpdateBankStatementHitList_TransactionPresetForBankStatementHitList(List<BankStatementHitList_TransactionPreset> newBankStatementHitList_TransactionPreset,long idBankStatementHitList,SubscriptionEntities db);
                           



 BankStatementHitList GetBankStatementHitListWithBankStatementStagingHitsDetails(long idBankStatementHitList,bool shouldRemap = false);
           List<BankStatementStagingHit> UpdateBankStatementStagingHitsForBankStatementHitListWithoutSavingNewItem(List<BankStatementStagingHit> newBankStatementStagingHits,long idBankStatementHitList);
    List<BankStatementStagingHit> UpdateBankStatementStagingHitsForBankStatementHitListWithoutSavingNewItem(List<BankStatementStagingHit> newBankStatementStagingHits,long idBankStatementHitList,SubscriptionEntities db);
          

    List<BankStatementStagingHit> UpdateBankStatementStagingHitsForBankStatementHitList(List<BankStatementStagingHit> newBankStatementStagingHits,long idBankStatementHitList);
    List<BankStatementStagingHit> UpdateBankStatementStagingHitsForBankStatementHitList(List<BankStatementStagingHit> newBankStatementStagingHits,long idBankStatementHitList,SubscriptionEntities db);
                           



 BankStatementHitList GetBankStatementHitListWithTemporaryTransactionsDetails(long idBankStatementHitList,bool shouldRemap = false);
           List<TemporaryTransaction> UpdateTemporaryTransactionsForBankStatementHitListWithoutSavingNewItem(List<TemporaryTransaction> newTemporaryTransactions,long idBankStatementHitList);
    List<TemporaryTransaction> UpdateTemporaryTransactionsForBankStatementHitListWithoutSavingNewItem(List<TemporaryTransaction> newTemporaryTransactions,long idBankStatementHitList,SubscriptionEntities db);
          

    List<TemporaryTransaction> UpdateTemporaryTransactionsForBankStatementHitList(List<TemporaryTransaction> newTemporaryTransactions,long idBankStatementHitList);
    List<TemporaryTransaction> UpdateTemporaryTransactionsForBankStatementHitList(List<TemporaryTransaction> newTemporaryTransactions,long idBankStatementHitList,SubscriptionEntities db);
                           



 BankStatementHitList GetBankStatementHitListCustom( Expression<Func<BankStatementHitList, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 BankStatementHitList GetBankStatementHitListCustom(SubscriptionEntities db, Expression<Func<BankStatementHitList, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<BankStatementHitList> GetBankStatementHitListCustomList( Expression<Func<BankStatementHitList, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<BankStatementHitList, dynamic> orderExpression = null);
 BaseListReturnType<BankStatementHitList> GetBankStatementHitListCustomList( SubscriptionEntities db , Expression<Func<BankStatementHitList, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<BankStatementHitList, dynamic> orderExpression = null);
 BankStatementHitList GetBankStatementHitListWithDetails(long idBankStatementHitList, List<string> includes = null,bool shouldRemap = false);
 BankStatementHitList GetBankStatementHitListWithDetails(long idBankStatementHitList, SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 BankStatementHitList GetBankStatementHitListWitDetails(long idBankStatementHitList,bool shouldRemap = false);
 BankStatementHitList GetBankStatementHitListWitDetails(long idBankStatementHitList, SubscriptionEntities db,bool shouldRemap = false);
 void SaveBankStatementHitList(BankStatementHitList bankStatementHitList);
 void SaveBankStatementHitList(BankStatementHitList bankStatementHitList, SubscriptionEntities db);
 void SaveOnlyBankStatementHitList(BankStatementHitList bankStatementHitList);
 void SaveOnlyBankStatementHitList(BankStatementHitList bankStatementHitList, SubscriptionEntities db);
 void DeleteBankStatementHitList(BankStatementHitList bankStatementHitList);
 void DeleteBankStatementHitList(BankStatementHitList bankStatementHitList, SubscriptionEntities db);		
  void DeletePermanentlyBankStatementHitList(BankStatementHitList bankStatementHitList);
 void DeletePermanentlyBankStatementHitList(BankStatementHitList bankStatementHitList, SubscriptionEntities db);	
	}
 	public partial interface IBankStatementHitList_TransactionPresetDao
	{
  List<BankStatementHitList_TransactionPreset> GetAllBankStatementHitList_TransactionPreset(bool shouldRemap = false);
  List<BankStatementHitList_TransactionPreset> GetAllBankStatementHitList_TransactionPreset(SubscriptionEntities db,bool shouldRemap = false);
  BaseListReturnType<BankStatementHitList_TransactionPreset> GetAllBankStatementHitList_TransactionPresetByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<BankStatementHitList_TransactionPreset, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<BankStatementHitList_TransactionPreset, dynamic> orderExpression = null);
  BaseListReturnType<BankStatementHitList_TransactionPreset> GetAllBankStatementHitList_TransactionPresetByPage(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<BankStatementHitList_TransactionPreset, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<BankStatementHitList_TransactionPreset, dynamic> orderExpression = null);
  
  BaseListReturnType<BankStatementHitList_TransactionPreset> GetAllBankStatementHitList_TransactionPresetByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<BankStatementHitList_TransactionPreset, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<BankStatementHitList_TransactionPreset, dynamic> orderExpression = null);
  BaseListReturnType<BankStatementHitList_TransactionPreset> GetAllBankStatementHitList_TransactionPresetByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<BankStatementHitList_TransactionPreset, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<BankStatementHitList_TransactionPreset, dynamic> orderExpression = null);

 BaseListReturnType<BankStatementHitList_TransactionPreset> GetAllBankStatementHitList_TransactionPresetWithBankStatementHitListDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<BankStatementHitList_TransactionPreset, bool>> expression = null,bool shouldRemap = false, Func<BankStatementHitList_TransactionPreset, dynamic> orderExpression = null);
 BaseListReturnType<BankStatementHitList_TransactionPreset> GetAllBankStatementHitList_TransactionPresetWithBankStatementHitListDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<BankStatementHitList_TransactionPreset, bool>> expression = null,bool shouldRemap = false, Func<BankStatementHitList_TransactionPreset, dynamic> orderExpression = null);






BaseListReturnType<BankStatementHitList_TransactionPreset> GetAllBankStatementHitList_TransactionPresetListByBankStatementHitList(long idBankStatementHitList);

BaseListReturnType<BankStatementHitList_TransactionPreset> GetAllBankStatementHitList_TransactionPresetListByBankStatementHitList(long idBankStatementHitList, SubscriptionEntities db);

BaseListReturnType<BankStatementHitList_TransactionPreset> GetAllBankStatementHitList_TransactionPresetListByBankStatementHitListByPage(long idBankStatementHitList, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<BankStatementHitList_TransactionPreset> GetAllBankStatementHitList_TransactionPresetListByBankStatementHitListByPage(long idBankStatementHitList, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);



 BaseListReturnType<BankStatementHitList_TransactionPreset> GetAllBankStatementHitList_TransactionPresetWithTransactionPresetDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<BankStatementHitList_TransactionPreset, bool>> expression = null,bool shouldRemap = false, Func<BankStatementHitList_TransactionPreset, dynamic> orderExpression = null);
 BaseListReturnType<BankStatementHitList_TransactionPreset> GetAllBankStatementHitList_TransactionPresetWithTransactionPresetDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<BankStatementHitList_TransactionPreset, bool>> expression = null,bool shouldRemap = false, Func<BankStatementHitList_TransactionPreset, dynamic> orderExpression = null);






BaseListReturnType<BankStatementHitList_TransactionPreset> GetAllBankStatementHitList_TransactionPresetListByTransactionPreset(long idTransactionPreset);

BaseListReturnType<BankStatementHitList_TransactionPreset> GetAllBankStatementHitList_TransactionPresetListByTransactionPreset(long idTransactionPreset, SubscriptionEntities db);

BaseListReturnType<BankStatementHitList_TransactionPreset> GetAllBankStatementHitList_TransactionPresetListByTransactionPresetByPage(long idTransactionPreset, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<BankStatementHitList_TransactionPreset> GetAllBankStatementHitList_TransactionPresetListByTransactionPresetByPage(long idTransactionPreset, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);




List<BankStatementHitList_TransactionPreset> GetBankStatementHitList_TransactionPresetListByIdList(List<long> bankStatementHitList_TransactionPresetIds);

List<BankStatementHitList_TransactionPreset> GetBankStatementHitList_TransactionPresetListByIdList(List<long> bankStatementHitList_TransactionPresetIds, SubscriptionEntities db);

 BaseListReturnType<BankStatementHitList_TransactionPreset> GetAllBankStatementHitList_TransactionPresetWithBankStatementHitListDetails(bool shouldRemap = false);
 BaseListReturnType<BankStatementHitList_TransactionPreset> GetAllBankStatementHitList_TransactionPresetWithTransactionPresetDetails(bool shouldRemap = false);
 BaseListReturnType<BankStatementHitList_TransactionPreset> GetAllBankStatementHitList_TransactionPresetWitDetails( List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<BankStatementHitList_TransactionPreset> GetAllBankStatementHitList_TransactionPresetWitDetails( SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 BankStatementHitList_TransactionPreset GetBankStatementHitList_TransactionPreset(long idBankStatementHitList_TransactionPreset,bool shouldRemap = false);
 BankStatementHitList_TransactionPreset GetBankStatementHitList_TransactionPreset(long idBankStatementHitList_TransactionPreset, SubscriptionEntities db,bool shouldRemap = false);
 BankStatementHitList_TransactionPreset GetBankStatementHitList_TransactionPresetWithBankStatementHitListDetails(long idBankStatementHitList_TransactionPreset,bool shouldRemap = false);
    


 BankStatementHitList_TransactionPreset GetBankStatementHitList_TransactionPresetWithTransactionPresetDetails(long idBankStatementHitList_TransactionPreset,bool shouldRemap = false);
    


 BankStatementHitList_TransactionPreset GetBankStatementHitList_TransactionPresetCustom( Expression<Func<BankStatementHitList_TransactionPreset, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 BankStatementHitList_TransactionPreset GetBankStatementHitList_TransactionPresetCustom(SubscriptionEntities db, Expression<Func<BankStatementHitList_TransactionPreset, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<BankStatementHitList_TransactionPreset> GetBankStatementHitList_TransactionPresetCustomList( Expression<Func<BankStatementHitList_TransactionPreset, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<BankStatementHitList_TransactionPreset, dynamic> orderExpression = null);
 BaseListReturnType<BankStatementHitList_TransactionPreset> GetBankStatementHitList_TransactionPresetCustomList( SubscriptionEntities db , Expression<Func<BankStatementHitList_TransactionPreset, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<BankStatementHitList_TransactionPreset, dynamic> orderExpression = null);
 BankStatementHitList_TransactionPreset GetBankStatementHitList_TransactionPresetWithDetails(long idBankStatementHitList_TransactionPreset, List<string> includes = null,bool shouldRemap = false);
 BankStatementHitList_TransactionPreset GetBankStatementHitList_TransactionPresetWithDetails(long idBankStatementHitList_TransactionPreset, SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 BankStatementHitList_TransactionPreset GetBankStatementHitList_TransactionPresetWitDetails(long idBankStatementHitList_TransactionPreset,bool shouldRemap = false);
 BankStatementHitList_TransactionPreset GetBankStatementHitList_TransactionPresetWitDetails(long idBankStatementHitList_TransactionPreset, SubscriptionEntities db,bool shouldRemap = false);
 void SaveBankStatementHitList_TransactionPreset(BankStatementHitList_TransactionPreset bankStatementHitList_TransactionPreset);
 void SaveBankStatementHitList_TransactionPreset(BankStatementHitList_TransactionPreset bankStatementHitList_TransactionPreset, SubscriptionEntities db);
 void SaveOnlyBankStatementHitList_TransactionPreset(BankStatementHitList_TransactionPreset bankStatementHitList_TransactionPreset);
 void SaveOnlyBankStatementHitList_TransactionPreset(BankStatementHitList_TransactionPreset bankStatementHitList_TransactionPreset, SubscriptionEntities db);
 void DeleteBankStatementHitList_TransactionPreset(BankStatementHitList_TransactionPreset bankStatementHitList_TransactionPreset);
 void DeleteBankStatementHitList_TransactionPreset(BankStatementHitList_TransactionPreset bankStatementHitList_TransactionPreset, SubscriptionEntities db);		
  void DeletePermanentlyBankStatementHitList_TransactionPreset(BankStatementHitList_TransactionPreset bankStatementHitList_TransactionPreset);
 void DeletePermanentlyBankStatementHitList_TransactionPreset(BankStatementHitList_TransactionPreset bankStatementHitList_TransactionPreset, SubscriptionEntities db);	
	}
 	public partial interface IBankStatementStagingDao
	{
  List<BankStatementStaging> GetAllBankStatementStagings(bool shouldRemap = false);
  List<BankStatementStaging> GetAllBankStatementStagings(SubscriptionEntities db,bool shouldRemap = false);
  BaseListReturnType<BankStatementStaging> GetAllBankStatementStagingsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<BankStatementStaging, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<BankStatementStaging, dynamic> orderExpression = null);
  BaseListReturnType<BankStatementStaging> GetAllBankStatementStagingsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<BankStatementStaging, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<BankStatementStaging, dynamic> orderExpression = null);
  
  BaseListReturnType<BankStatementStaging> GetAllBankStatementStagingsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<BankStatementStaging, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<BankStatementStaging, dynamic> orderExpression = null);
  BaseListReturnType<BankStatementStaging> GetAllBankStatementStagingsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<BankStatementStaging, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<BankStatementStaging, dynamic> orderExpression = null);

 BaseListReturnType<BankStatementStaging> GetAllBankStatementStagingsWithBankReconOrderProcessStateDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<BankStatementStaging, bool>> expression = null,bool shouldRemap = false, Func<BankStatementStaging, dynamic> orderExpression = null);
 BaseListReturnType<BankStatementStaging> GetAllBankStatementStagingsWithBankReconOrderProcessStateDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<BankStatementStaging, bool>> expression = null,bool shouldRemap = false, Func<BankStatementStaging, dynamic> orderExpression = null);






BaseListReturnType<BankStatementStaging> GetAllBankStatementStagingListByBankReconOrderProcessState(long idBankReconOrderProcessState);

BaseListReturnType<BankStatementStaging> GetAllBankStatementStagingListByBankReconOrderProcessState(long idBankReconOrderProcessState, SubscriptionEntities db);

BaseListReturnType<BankStatementStaging> GetAllBankStatementStagingListByBankReconOrderProcessStateByPage(long idBankReconOrderProcessState, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<BankStatementStaging> GetAllBankStatementStagingListByBankReconOrderProcessStateByPage(long idBankReconOrderProcessState, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);



 BaseListReturnType<BankStatementStaging> GetAllBankStatementStagingsWithBankDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<BankStatementStaging, bool>> expression = null,bool shouldRemap = false, Func<BankStatementStaging, dynamic> orderExpression = null);
 BaseListReturnType<BankStatementStaging> GetAllBankStatementStagingsWithBankDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<BankStatementStaging, bool>> expression = null,bool shouldRemap = false, Func<BankStatementStaging, dynamic> orderExpression = null);






BaseListReturnType<BankStatementStaging> GetAllBankStatementStagingListByBank(long idBank);

BaseListReturnType<BankStatementStaging> GetAllBankStatementStagingListByBank(long idBank, SubscriptionEntities db);

BaseListReturnType<BankStatementStaging> GetAllBankStatementStagingListByBankByPage(long idBank, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<BankStatementStaging> GetAllBankStatementStagingListByBankByPage(long idBank, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);



 BaseListReturnType<BankStatementStaging> GetAllBankStatementStagingsWithBankStatementStagingStateDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<BankStatementStaging, bool>> expression = null,bool shouldRemap = false, Func<BankStatementStaging, dynamic> orderExpression = null);
 BaseListReturnType<BankStatementStaging> GetAllBankStatementStagingsWithBankStatementStagingStateDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<BankStatementStaging, bool>> expression = null,bool shouldRemap = false, Func<BankStatementStaging, dynamic> orderExpression = null);






BaseListReturnType<BankStatementStaging> GetAllBankStatementStagingListByBankStatementStagingState(long idBankStatementStagingState);

BaseListReturnType<BankStatementStaging> GetAllBankStatementStagingListByBankStatementStagingState(long idBankStatementStagingState, SubscriptionEntities db);

BaseListReturnType<BankStatementStaging> GetAllBankStatementStagingListByBankStatementStagingStateByPage(long idBankStatementStagingState, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<BankStatementStaging> GetAllBankStatementStagingListByBankStatementStagingStateByPage(long idBankStatementStagingState, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);



 BaseListReturnType<BankStatementStaging> GetAllBankStatementStagingsWithDocumentDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<BankStatementStaging, bool>> expression = null,bool shouldRemap = false, Func<BankStatementStaging, dynamic> orderExpression = null);
 BaseListReturnType<BankStatementStaging> GetAllBankStatementStagingsWithDocumentDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<BankStatementStaging, bool>> expression = null,bool shouldRemap = false, Func<BankStatementStaging, dynamic> orderExpression = null);






BaseListReturnType<BankStatementStaging> GetAllBankStatementStagingListByDocument(long idDocument);

BaseListReturnType<BankStatementStaging> GetAllBankStatementStagingListByDocument(long idDocument, SubscriptionEntities db);

BaseListReturnType<BankStatementStaging> GetAllBankStatementStagingListByDocumentByPage(long idDocument, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<BankStatementStaging> GetAllBankStatementStagingListByDocumentByPage(long idDocument, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);



 BaseListReturnType<BankStatementStaging> GetAllBankStatementStagingsWithUserDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<BankStatementStaging, bool>> expression = null,bool shouldRemap = false, Func<BankStatementStaging, dynamic> orderExpression = null);
 BaseListReturnType<BankStatementStaging> GetAllBankStatementStagingsWithUserDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<BankStatementStaging, bool>> expression = null,bool shouldRemap = false, Func<BankStatementStaging, dynamic> orderExpression = null);






BaseListReturnType<BankStatementStaging> GetAllBankStatementStagingListByUser(long idUser);

BaseListReturnType<BankStatementStaging> GetAllBankStatementStagingListByUser(long idUser, SubscriptionEntities db);

BaseListReturnType<BankStatementStaging> GetAllBankStatementStagingListByUserByPage(long idUser, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<BankStatementStaging> GetAllBankStatementStagingListByUserByPage(long idUser, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);



 BaseListReturnType<BankStatementStaging> GetAllBankStatementStagingsWithBankStatementStagingDetailsDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<BankStatementStaging, bool>> expression = null,bool shouldRemap = false, Func<BankStatementStaging, dynamic> orderExpression = null);
 BaseListReturnType<BankStatementStaging> GetAllBankStatementStagingsWithBankStatementStagingDetailsDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<BankStatementStaging, bool>> expression = null,bool shouldRemap = false, Func<BankStatementStaging, dynamic> orderExpression = null);


List<BankStatementStaging> GetBankStatementStagingListByIdList(List<long> bankStatementStagingIds);

List<BankStatementStaging> GetBankStatementStagingListByIdList(List<long> bankStatementStagingIds, SubscriptionEntities db);

 BaseListReturnType<BankStatementStaging> GetAllBankStatementStagingsWithBankReconOrderProcessStateDetails(bool shouldRemap = false);
 BaseListReturnType<BankStatementStaging> GetAllBankStatementStagingsWithBankDetails(bool shouldRemap = false);
 BaseListReturnType<BankStatementStaging> GetAllBankStatementStagingsWithBankStatementStagingStateDetails(bool shouldRemap = false);
 BaseListReturnType<BankStatementStaging> GetAllBankStatementStagingsWithDocumentDetails(bool shouldRemap = false);
 BaseListReturnType<BankStatementStaging> GetAllBankStatementStagingsWithUserDetails(bool shouldRemap = false);
 BaseListReturnType<BankStatementStaging> GetAllBankStatementStagingsWithBankStatementStagingDetailsDetails(bool shouldRemap = false);
 BaseListReturnType<BankStatementStaging> GetAllBankStatementStagingWitDetails( List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<BankStatementStaging> GetAllBankStatementStagingWitDetails( SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 BankStatementStaging GetBankStatementStaging(long idBankStatementStaging,bool shouldRemap = false);
 BankStatementStaging GetBankStatementStaging(long idBankStatementStaging, SubscriptionEntities db,bool shouldRemap = false);
 BankStatementStaging GetBankStatementStagingWithBankReconOrderProcessStateDetails(long idBankStatementStaging,bool shouldRemap = false);
    


 BankStatementStaging GetBankStatementStagingWithBankDetails(long idBankStatementStaging,bool shouldRemap = false);
    


 BankStatementStaging GetBankStatementStagingWithBankStatementStagingStateDetails(long idBankStatementStaging,bool shouldRemap = false);
    


 BankStatementStaging GetBankStatementStagingWithDocumentDetails(long idBankStatementStaging,bool shouldRemap = false);
    


 BankStatementStaging GetBankStatementStagingWithUserDetails(long idBankStatementStaging,bool shouldRemap = false);
    


 BankStatementStaging GetBankStatementStagingWithBankStatementStagingDetailsDetails(long idBankStatementStaging,bool shouldRemap = false);
           List<BankStatementStagingDetail> UpdateBankStatementStagingDetailsForBankStatementStagingWithoutSavingNewItem(List<BankStatementStagingDetail> newBankStatementStagingDetails,long idBankStatementStaging);
    List<BankStatementStagingDetail> UpdateBankStatementStagingDetailsForBankStatementStagingWithoutSavingNewItem(List<BankStatementStagingDetail> newBankStatementStagingDetails,long idBankStatementStaging,SubscriptionEntities db);
          

    List<BankStatementStagingDetail> UpdateBankStatementStagingDetailsForBankStatementStaging(List<BankStatementStagingDetail> newBankStatementStagingDetails,long idBankStatementStaging);
    List<BankStatementStagingDetail> UpdateBankStatementStagingDetailsForBankStatementStaging(List<BankStatementStagingDetail> newBankStatementStagingDetails,long idBankStatementStaging,SubscriptionEntities db);
                           



 BankStatementStaging GetBankStatementStagingCustom( Expression<Func<BankStatementStaging, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 BankStatementStaging GetBankStatementStagingCustom(SubscriptionEntities db, Expression<Func<BankStatementStaging, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<BankStatementStaging> GetBankStatementStagingCustomList( Expression<Func<BankStatementStaging, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<BankStatementStaging, dynamic> orderExpression = null);
 BaseListReturnType<BankStatementStaging> GetBankStatementStagingCustomList( SubscriptionEntities db , Expression<Func<BankStatementStaging, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<BankStatementStaging, dynamic> orderExpression = null);
 BankStatementStaging GetBankStatementStagingWithDetails(long idBankStatementStaging, List<string> includes = null,bool shouldRemap = false);
 BankStatementStaging GetBankStatementStagingWithDetails(long idBankStatementStaging, SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 BankStatementStaging GetBankStatementStagingWitDetails(long idBankStatementStaging,bool shouldRemap = false);
 BankStatementStaging GetBankStatementStagingWitDetails(long idBankStatementStaging, SubscriptionEntities db,bool shouldRemap = false);
 void SaveBankStatementStaging(BankStatementStaging bankStatementStaging);
 void SaveBankStatementStaging(BankStatementStaging bankStatementStaging, SubscriptionEntities db);
 void SaveOnlyBankStatementStaging(BankStatementStaging bankStatementStaging);
 void SaveOnlyBankStatementStaging(BankStatementStaging bankStatementStaging, SubscriptionEntities db);
 void DeleteBankStatementStaging(BankStatementStaging bankStatementStaging);
 void DeleteBankStatementStaging(BankStatementStaging bankStatementStaging, SubscriptionEntities db);		
  void DeletePermanentlyBankStatementStaging(BankStatementStaging bankStatementStaging);
 void DeletePermanentlyBankStatementStaging(BankStatementStaging bankStatementStaging, SubscriptionEntities db);	
	}
 	public partial interface IBankStatementStagingDetailDao
	{
  List<BankStatementStagingDetail> GetAllBankStatementStagingDetails(bool shouldRemap = false);
  List<BankStatementStagingDetail> GetAllBankStatementStagingDetails(SubscriptionEntities db,bool shouldRemap = false);
  BaseListReturnType<BankStatementStagingDetail> GetAllBankStatementStagingDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<BankStatementStagingDetail, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<BankStatementStagingDetail, dynamic> orderExpression = null);
  BaseListReturnType<BankStatementStagingDetail> GetAllBankStatementStagingDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<BankStatementStagingDetail, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<BankStatementStagingDetail, dynamic> orderExpression = null);
  
  BaseListReturnType<BankStatementStagingDetail> GetAllBankStatementStagingDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<BankStatementStagingDetail, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<BankStatementStagingDetail, dynamic> orderExpression = null);
  BaseListReturnType<BankStatementStagingDetail> GetAllBankStatementStagingDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<BankStatementStagingDetail, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<BankStatementStagingDetail, dynamic> orderExpression = null);

 BaseListReturnType<BankStatementStagingDetail> GetAllBankStatementStagingDetailsWithBankReconOrderTypeDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<BankStatementStagingDetail, bool>> expression = null,bool shouldRemap = false, Func<BankStatementStagingDetail, dynamic> orderExpression = null);
 BaseListReturnType<BankStatementStagingDetail> GetAllBankStatementStagingDetailsWithBankReconOrderTypeDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<BankStatementStagingDetail, bool>> expression = null,bool shouldRemap = false, Func<BankStatementStagingDetail, dynamic> orderExpression = null);






BaseListReturnType<BankStatementStagingDetail> GetAllBankStatementStagingDetailListByBankReconOrderType(long idBankReconOrderType);

BaseListReturnType<BankStatementStagingDetail> GetAllBankStatementStagingDetailListByBankReconOrderType(long idBankReconOrderType, SubscriptionEntities db);

BaseListReturnType<BankStatementStagingDetail> GetAllBankStatementStagingDetailListByBankReconOrderTypeByPage(long idBankReconOrderType, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<BankStatementStagingDetail> GetAllBankStatementStagingDetailListByBankReconOrderTypeByPage(long idBankReconOrderType, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);



 BaseListReturnType<BankStatementStagingDetail> GetAllBankStatementStagingDetailsWithBankStatementHitListsDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<BankStatementStagingDetail, bool>> expression = null,bool shouldRemap = false, Func<BankStatementStagingDetail, dynamic> orderExpression = null);
 BaseListReturnType<BankStatementStagingDetail> GetAllBankStatementStagingDetailsWithBankStatementHitListsDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<BankStatementStagingDetail, bool>> expression = null,bool shouldRemap = false, Func<BankStatementStagingDetail, dynamic> orderExpression = null);

 BaseListReturnType<BankStatementStagingDetail> GetAllBankStatementStagingDetailsWithBankStatementStagingDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<BankStatementStagingDetail, bool>> expression = null,bool shouldRemap = false, Func<BankStatementStagingDetail, dynamic> orderExpression = null);
 BaseListReturnType<BankStatementStagingDetail> GetAllBankStatementStagingDetailsWithBankStatementStagingDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<BankStatementStagingDetail, bool>> expression = null,bool shouldRemap = false, Func<BankStatementStagingDetail, dynamic> orderExpression = null);






BaseListReturnType<BankStatementStagingDetail> GetAllBankStatementStagingDetailListByBankStatementStaging(long idBankStatementStaging);

BaseListReturnType<BankStatementStagingDetail> GetAllBankStatementStagingDetailListByBankStatementStaging(long idBankStatementStaging, SubscriptionEntities db);

BaseListReturnType<BankStatementStagingDetail> GetAllBankStatementStagingDetailListByBankStatementStagingByPage(long idBankStatementStaging, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<BankStatementStagingDetail> GetAllBankStatementStagingDetailListByBankStatementStagingByPage(long idBankStatementStaging, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);



 BaseListReturnType<BankStatementStagingDetail> GetAllBankStatementStagingDetailsWithBankStatementStagingDetailBatchDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<BankStatementStagingDetail, bool>> expression = null,bool shouldRemap = false, Func<BankStatementStagingDetail, dynamic> orderExpression = null);
 BaseListReturnType<BankStatementStagingDetail> GetAllBankStatementStagingDetailsWithBankStatementStagingDetailBatchDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<BankStatementStagingDetail, bool>> expression = null,bool shouldRemap = false, Func<BankStatementStagingDetail, dynamic> orderExpression = null);






BaseListReturnType<BankStatementStagingDetail> GetAllBankStatementStagingDetailListByBankStatementStagingDetailBatch(long idBankStatementStagingDetailBatch);

BaseListReturnType<BankStatementStagingDetail> GetAllBankStatementStagingDetailListByBankStatementStagingDetailBatch(long idBankStatementStagingDetailBatch, SubscriptionEntities db);

BaseListReturnType<BankStatementStagingDetail> GetAllBankStatementStagingDetailListByBankStatementStagingDetailBatchByPage(long idBankStatementStagingDetailBatch, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<BankStatementStagingDetail> GetAllBankStatementStagingDetailListByBankStatementStagingDetailBatchByPage(long idBankStatementStagingDetailBatch, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);



 BaseListReturnType<BankStatementStagingDetail> GetAllBankStatementStagingDetailsWithBankStatementStagingHitsDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<BankStatementStagingDetail, bool>> expression = null,bool shouldRemap = false, Func<BankStatementStagingDetail, dynamic> orderExpression = null);
 BaseListReturnType<BankStatementStagingDetail> GetAllBankStatementStagingDetailsWithBankStatementStagingHitsDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<BankStatementStagingDetail, bool>> expression = null,bool shouldRemap = false, Func<BankStatementStagingDetail, dynamic> orderExpression = null);

 BaseListReturnType<BankStatementStagingDetail> GetAllBankStatementStagingDetailsWithTemporaryTransactionsDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<BankStatementStagingDetail, bool>> expression = null,bool shouldRemap = false, Func<BankStatementStagingDetail, dynamic> orderExpression = null);
 BaseListReturnType<BankStatementStagingDetail> GetAllBankStatementStagingDetailsWithTemporaryTransactionsDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<BankStatementStagingDetail, bool>> expression = null,bool shouldRemap = false, Func<BankStatementStagingDetail, dynamic> orderExpression = null);

 BaseListReturnType<BankStatementStagingDetail> GetAllBankStatementStagingDetailsWithTransaction_BankStatementStagingDetailDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<BankStatementStagingDetail, bool>> expression = null,bool shouldRemap = false, Func<BankStatementStagingDetail, dynamic> orderExpression = null);
 BaseListReturnType<BankStatementStagingDetail> GetAllBankStatementStagingDetailsWithTransaction_BankStatementStagingDetailDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<BankStatementStagingDetail, bool>> expression = null,bool shouldRemap = false, Func<BankStatementStagingDetail, dynamic> orderExpression = null);


List<BankStatementStagingDetail> GetBankStatementStagingDetailListByIdList(List<long> bankStatementStagingDetailIds);

List<BankStatementStagingDetail> GetBankStatementStagingDetailListByIdList(List<long> bankStatementStagingDetailIds, SubscriptionEntities db);

 BaseListReturnType<BankStatementStagingDetail> GetAllBankStatementStagingDetailsWithBankReconOrderTypeDetails(bool shouldRemap = false);
 BaseListReturnType<BankStatementStagingDetail> GetAllBankStatementStagingDetailsWithBankStatementHitListsDetails(bool shouldRemap = false);
 BaseListReturnType<BankStatementStagingDetail> GetAllBankStatementStagingDetailsWithBankStatementStagingDetails(bool shouldRemap = false);
 BaseListReturnType<BankStatementStagingDetail> GetAllBankStatementStagingDetailsWithBankStatementStagingDetailBatchDetails(bool shouldRemap = false);
 BaseListReturnType<BankStatementStagingDetail> GetAllBankStatementStagingDetailsWithBankStatementStagingHitsDetails(bool shouldRemap = false);
 BaseListReturnType<BankStatementStagingDetail> GetAllBankStatementStagingDetailsWithTemporaryTransactionsDetails(bool shouldRemap = false);
 BaseListReturnType<BankStatementStagingDetail> GetAllBankStatementStagingDetailsWithTransaction_BankStatementStagingDetailDetails(bool shouldRemap = false);
 BaseListReturnType<BankStatementStagingDetail> GetAllBankStatementStagingDetailWitDetails( List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<BankStatementStagingDetail> GetAllBankStatementStagingDetailWitDetails( SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 BankStatementStagingDetail GetBankStatementStagingDetail(long idBankStatementStagingDetail,bool shouldRemap = false);
 BankStatementStagingDetail GetBankStatementStagingDetail(long idBankStatementStagingDetail, SubscriptionEntities db,bool shouldRemap = false);
 BankStatementStagingDetail GetBankStatementStagingDetailWithBankReconOrderTypeDetails(long idBankStatementStagingDetail,bool shouldRemap = false);
    


 BankStatementStagingDetail GetBankStatementStagingDetailWithBankStatementHitListsDetails(long idBankStatementStagingDetail,bool shouldRemap = false);
           List<BankStatementHitList> UpdateBankStatementHitListsForBankStatementStagingDetailWithoutSavingNewItem(List<BankStatementHitList> newBankStatementHitLists,long idBankStatementStagingDetail);
    List<BankStatementHitList> UpdateBankStatementHitListsForBankStatementStagingDetailWithoutSavingNewItem(List<BankStatementHitList> newBankStatementHitLists,long idBankStatementStagingDetail,SubscriptionEntities db);
          

    List<BankStatementHitList> UpdateBankStatementHitListsForBankStatementStagingDetail(List<BankStatementHitList> newBankStatementHitLists,long idBankStatementStagingDetail);
    List<BankStatementHitList> UpdateBankStatementHitListsForBankStatementStagingDetail(List<BankStatementHitList> newBankStatementHitLists,long idBankStatementStagingDetail,SubscriptionEntities db);
                           



 BankStatementStagingDetail GetBankStatementStagingDetailWithBankStatementStagingDetails(long idBankStatementStagingDetail,bool shouldRemap = false);
    


 BankStatementStagingDetail GetBankStatementStagingDetailWithBankStatementStagingDetailBatchDetails(long idBankStatementStagingDetail,bool shouldRemap = false);
    


 BankStatementStagingDetail GetBankStatementStagingDetailWithBankStatementStagingHitsDetails(long idBankStatementStagingDetail,bool shouldRemap = false);
           List<BankStatementStagingHit> UpdateBankStatementStagingHitsForBankStatementStagingDetailWithoutSavingNewItem(List<BankStatementStagingHit> newBankStatementStagingHits,long idBankStatementStagingDetail);
    List<BankStatementStagingHit> UpdateBankStatementStagingHitsForBankStatementStagingDetailWithoutSavingNewItem(List<BankStatementStagingHit> newBankStatementStagingHits,long idBankStatementStagingDetail,SubscriptionEntities db);
          

    List<BankStatementStagingHit> UpdateBankStatementStagingHitsForBankStatementStagingDetail(List<BankStatementStagingHit> newBankStatementStagingHits,long idBankStatementStagingDetail);
    List<BankStatementStagingHit> UpdateBankStatementStagingHitsForBankStatementStagingDetail(List<BankStatementStagingHit> newBankStatementStagingHits,long idBankStatementStagingDetail,SubscriptionEntities db);
                           



 BankStatementStagingDetail GetBankStatementStagingDetailWithTemporaryTransactionsDetails(long idBankStatementStagingDetail,bool shouldRemap = false);
           List<TemporaryTransaction> UpdateTemporaryTransactionsForBankStatementStagingDetailWithoutSavingNewItem(List<TemporaryTransaction> newTemporaryTransactions,long idBankStatementStagingDetail);
    List<TemporaryTransaction> UpdateTemporaryTransactionsForBankStatementStagingDetailWithoutSavingNewItem(List<TemporaryTransaction> newTemporaryTransactions,long idBankStatementStagingDetail,SubscriptionEntities db);
          

    List<TemporaryTransaction> UpdateTemporaryTransactionsForBankStatementStagingDetail(List<TemporaryTransaction> newTemporaryTransactions,long idBankStatementStagingDetail);
    List<TemporaryTransaction> UpdateTemporaryTransactionsForBankStatementStagingDetail(List<TemporaryTransaction> newTemporaryTransactions,long idBankStatementStagingDetail,SubscriptionEntities db);
                           



 BankStatementStagingDetail GetBankStatementStagingDetailWithTransaction_BankStatementStagingDetailDetails(long idBankStatementStagingDetail,bool shouldRemap = false);
           List<Transaction_BankStatementStagingDetail> UpdateTransaction_BankStatementStagingDetailForBankStatementStagingDetailWithoutSavingNewItem(List<Transaction_BankStatementStagingDetail> newTransaction_BankStatementStagingDetail,long idBankStatementStagingDetail);
    List<Transaction_BankStatementStagingDetail> UpdateTransaction_BankStatementStagingDetailForBankStatementStagingDetailWithoutSavingNewItem(List<Transaction_BankStatementStagingDetail> newTransaction_BankStatementStagingDetail,long idBankStatementStagingDetail,SubscriptionEntities db);
          

    List<Transaction_BankStatementStagingDetail> UpdateTransaction_BankStatementStagingDetailForBankStatementStagingDetail(List<Transaction_BankStatementStagingDetail> newTransaction_BankStatementStagingDetail,long idBankStatementStagingDetail);
    List<Transaction_BankStatementStagingDetail> UpdateTransaction_BankStatementStagingDetailForBankStatementStagingDetail(List<Transaction_BankStatementStagingDetail> newTransaction_BankStatementStagingDetail,long idBankStatementStagingDetail,SubscriptionEntities db);
                           



 BankStatementStagingDetail GetBankStatementStagingDetailCustom( Expression<Func<BankStatementStagingDetail, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 BankStatementStagingDetail GetBankStatementStagingDetailCustom(SubscriptionEntities db, Expression<Func<BankStatementStagingDetail, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<BankStatementStagingDetail> GetBankStatementStagingDetailCustomList( Expression<Func<BankStatementStagingDetail, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<BankStatementStagingDetail, dynamic> orderExpression = null);
 BaseListReturnType<BankStatementStagingDetail> GetBankStatementStagingDetailCustomList( SubscriptionEntities db , Expression<Func<BankStatementStagingDetail, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<BankStatementStagingDetail, dynamic> orderExpression = null);
 BankStatementStagingDetail GetBankStatementStagingDetailWithDetails(long idBankStatementStagingDetail, List<string> includes = null,bool shouldRemap = false);
 BankStatementStagingDetail GetBankStatementStagingDetailWithDetails(long idBankStatementStagingDetail, SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 BankStatementStagingDetail GetBankStatementStagingDetailWitDetails(long idBankStatementStagingDetail,bool shouldRemap = false);
 BankStatementStagingDetail GetBankStatementStagingDetailWitDetails(long idBankStatementStagingDetail, SubscriptionEntities db,bool shouldRemap = false);
 void SaveBankStatementStagingDetail(BankStatementStagingDetail bankStatementStagingDetail);
 void SaveBankStatementStagingDetail(BankStatementStagingDetail bankStatementStagingDetail, SubscriptionEntities db);
 void SaveOnlyBankStatementStagingDetail(BankStatementStagingDetail bankStatementStagingDetail);
 void SaveOnlyBankStatementStagingDetail(BankStatementStagingDetail bankStatementStagingDetail, SubscriptionEntities db);
 void DeleteBankStatementStagingDetail(BankStatementStagingDetail bankStatementStagingDetail);
 void DeleteBankStatementStagingDetail(BankStatementStagingDetail bankStatementStagingDetail, SubscriptionEntities db);		
  void DeletePermanentlyBankStatementStagingDetail(BankStatementStagingDetail bankStatementStagingDetail);
 void DeletePermanentlyBankStatementStagingDetail(BankStatementStagingDetail bankStatementStagingDetail, SubscriptionEntities db);	
	}
 	public partial interface IBankStatementStagingDetailBatchDao
	{
  List<BankStatementStagingDetailBatch> GetAllBankStatementStagingDetailBatches(bool shouldRemap = false);
  List<BankStatementStagingDetailBatch> GetAllBankStatementStagingDetailBatches(SubscriptionEntities db,bool shouldRemap = false);
  BaseListReturnType<BankStatementStagingDetailBatch> GetAllBankStatementStagingDetailBatchesByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<BankStatementStagingDetailBatch, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<BankStatementStagingDetailBatch, dynamic> orderExpression = null);
  BaseListReturnType<BankStatementStagingDetailBatch> GetAllBankStatementStagingDetailBatchesByPage(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<BankStatementStagingDetailBatch, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<BankStatementStagingDetailBatch, dynamic> orderExpression = null);
  
  BaseListReturnType<BankStatementStagingDetailBatch> GetAllBankStatementStagingDetailBatchesByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<BankStatementStagingDetailBatch, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<BankStatementStagingDetailBatch, dynamic> orderExpression = null);
  BaseListReturnType<BankStatementStagingDetailBatch> GetAllBankStatementStagingDetailBatchesByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<BankStatementStagingDetailBatch, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<BankStatementStagingDetailBatch, dynamic> orderExpression = null);

 BaseListReturnType<BankStatementStagingDetailBatch> GetAllBankStatementStagingDetailBatchesWithBankStatementStagingDetailsDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<BankStatementStagingDetailBatch, bool>> expression = null,bool shouldRemap = false, Func<BankStatementStagingDetailBatch, dynamic> orderExpression = null);
 BaseListReturnType<BankStatementStagingDetailBatch> GetAllBankStatementStagingDetailBatchesWithBankStatementStagingDetailsDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<BankStatementStagingDetailBatch, bool>> expression = null,bool shouldRemap = false, Func<BankStatementStagingDetailBatch, dynamic> orderExpression = null);

 BaseListReturnType<BankStatementStagingDetailBatch> GetAllBankStatementStagingDetailBatchesWithBankStatementStagingStateDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<BankStatementStagingDetailBatch, bool>> expression = null,bool shouldRemap = false, Func<BankStatementStagingDetailBatch, dynamic> orderExpression = null);
 BaseListReturnType<BankStatementStagingDetailBatch> GetAllBankStatementStagingDetailBatchesWithBankStatementStagingStateDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<BankStatementStagingDetailBatch, bool>> expression = null,bool shouldRemap = false, Func<BankStatementStagingDetailBatch, dynamic> orderExpression = null);






BaseListReturnType<BankStatementStagingDetailBatch> GetAllBankStatementStagingDetailBatchListByBankStatementStagingState(long idBankStatementStagingState);

BaseListReturnType<BankStatementStagingDetailBatch> GetAllBankStatementStagingDetailBatchListByBankStatementStagingState(long idBankStatementStagingState, SubscriptionEntities db);

BaseListReturnType<BankStatementStagingDetailBatch> GetAllBankStatementStagingDetailBatchListByBankStatementStagingStateByPage(long idBankStatementStagingState, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<BankStatementStagingDetailBatch> GetAllBankStatementStagingDetailBatchListByBankStatementStagingStateByPage(long idBankStatementStagingState, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);




List<BankStatementStagingDetailBatch> GetBankStatementStagingDetailBatchListByIdList(List<long> bankStatementStagingDetailBatchIds);

List<BankStatementStagingDetailBatch> GetBankStatementStagingDetailBatchListByIdList(List<long> bankStatementStagingDetailBatchIds, SubscriptionEntities db);

 BaseListReturnType<BankStatementStagingDetailBatch> GetAllBankStatementStagingDetailBatchesWithBankStatementStagingDetailsDetails(bool shouldRemap = false);
 BaseListReturnType<BankStatementStagingDetailBatch> GetAllBankStatementStagingDetailBatchesWithBankStatementStagingStateDetails(bool shouldRemap = false);
 BaseListReturnType<BankStatementStagingDetailBatch> GetAllBankStatementStagingDetailBatchWitDetails( List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<BankStatementStagingDetailBatch> GetAllBankStatementStagingDetailBatchWitDetails( SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 BankStatementStagingDetailBatch GetBankStatementStagingDetailBatch(long idBankStatementStagingDetailBatch,bool shouldRemap = false);
 BankStatementStagingDetailBatch GetBankStatementStagingDetailBatch(long idBankStatementStagingDetailBatch, SubscriptionEntities db,bool shouldRemap = false);
 BankStatementStagingDetailBatch GetBankStatementStagingDetailBatchWithBankStatementStagingDetailsDetails(long idBankStatementStagingDetailBatch,bool shouldRemap = false);
           List<BankStatementStagingDetail> UpdateBankStatementStagingDetailsForBankStatementStagingDetailBatchWithoutSavingNewItem(List<BankStatementStagingDetail> newBankStatementStagingDetails,long idBankStatementStagingDetailBatch);
    List<BankStatementStagingDetail> UpdateBankStatementStagingDetailsForBankStatementStagingDetailBatchWithoutSavingNewItem(List<BankStatementStagingDetail> newBankStatementStagingDetails,long idBankStatementStagingDetailBatch,SubscriptionEntities db);
          

    List<BankStatementStagingDetail> UpdateBankStatementStagingDetailsForBankStatementStagingDetailBatch(List<BankStatementStagingDetail> newBankStatementStagingDetails,long idBankStatementStagingDetailBatch);
    List<BankStatementStagingDetail> UpdateBankStatementStagingDetailsForBankStatementStagingDetailBatch(List<BankStatementStagingDetail> newBankStatementStagingDetails,long idBankStatementStagingDetailBatch,SubscriptionEntities db);
                           



 BankStatementStagingDetailBatch GetBankStatementStagingDetailBatchWithBankStatementStagingStateDetails(long idBankStatementStagingDetailBatch,bool shouldRemap = false);
    


 BankStatementStagingDetailBatch GetBankStatementStagingDetailBatchCustom( Expression<Func<BankStatementStagingDetailBatch, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 BankStatementStagingDetailBatch GetBankStatementStagingDetailBatchCustom(SubscriptionEntities db, Expression<Func<BankStatementStagingDetailBatch, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<BankStatementStagingDetailBatch> GetBankStatementStagingDetailBatchCustomList( Expression<Func<BankStatementStagingDetailBatch, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<BankStatementStagingDetailBatch, dynamic> orderExpression = null);
 BaseListReturnType<BankStatementStagingDetailBatch> GetBankStatementStagingDetailBatchCustomList( SubscriptionEntities db , Expression<Func<BankStatementStagingDetailBatch, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<BankStatementStagingDetailBatch, dynamic> orderExpression = null);
 BankStatementStagingDetailBatch GetBankStatementStagingDetailBatchWithDetails(long idBankStatementStagingDetailBatch, List<string> includes = null,bool shouldRemap = false);
 BankStatementStagingDetailBatch GetBankStatementStagingDetailBatchWithDetails(long idBankStatementStagingDetailBatch, SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 BankStatementStagingDetailBatch GetBankStatementStagingDetailBatchWitDetails(long idBankStatementStagingDetailBatch,bool shouldRemap = false);
 BankStatementStagingDetailBatch GetBankStatementStagingDetailBatchWitDetails(long idBankStatementStagingDetailBatch, SubscriptionEntities db,bool shouldRemap = false);
 void SaveBankStatementStagingDetailBatch(BankStatementStagingDetailBatch bankStatementStagingDetailBatch);
 void SaveBankStatementStagingDetailBatch(BankStatementStagingDetailBatch bankStatementStagingDetailBatch, SubscriptionEntities db);
 void SaveOnlyBankStatementStagingDetailBatch(BankStatementStagingDetailBatch bankStatementStagingDetailBatch);
 void SaveOnlyBankStatementStagingDetailBatch(BankStatementStagingDetailBatch bankStatementStagingDetailBatch, SubscriptionEntities db);
 void DeleteBankStatementStagingDetailBatch(BankStatementStagingDetailBatch bankStatementStagingDetailBatch);
 void DeleteBankStatementStagingDetailBatch(BankStatementStagingDetailBatch bankStatementStagingDetailBatch, SubscriptionEntities db);		
  void DeletePermanentlyBankStatementStagingDetailBatch(BankStatementStagingDetailBatch bankStatementStagingDetailBatch);
 void DeletePermanentlyBankStatementStagingDetailBatch(BankStatementStagingDetailBatch bankStatementStagingDetailBatch, SubscriptionEntities db);	
	}
 	public partial interface IBankStatementStagingHitDao
	{
  List<BankStatementStagingHit> GetAllBankStatementStagingHits(bool shouldRemap = false);
  List<BankStatementStagingHit> GetAllBankStatementStagingHits(SubscriptionEntities db,bool shouldRemap = false);
  BaseListReturnType<BankStatementStagingHit> GetAllBankStatementStagingHitsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<BankStatementStagingHit, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<BankStatementStagingHit, dynamic> orderExpression = null);
  BaseListReturnType<BankStatementStagingHit> GetAllBankStatementStagingHitsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<BankStatementStagingHit, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<BankStatementStagingHit, dynamic> orderExpression = null);
  
  BaseListReturnType<BankStatementStagingHit> GetAllBankStatementStagingHitsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<BankStatementStagingHit, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<BankStatementStagingHit, dynamic> orderExpression = null);
  BaseListReturnType<BankStatementStagingHit> GetAllBankStatementStagingHitsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<BankStatementStagingHit, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<BankStatementStagingHit, dynamic> orderExpression = null);

 BaseListReturnType<BankStatementStagingHit> GetAllBankStatementStagingHitsWithBankStatementHitListDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<BankStatementStagingHit, bool>> expression = null,bool shouldRemap = false, Func<BankStatementStagingHit, dynamic> orderExpression = null);
 BaseListReturnType<BankStatementStagingHit> GetAllBankStatementStagingHitsWithBankStatementHitListDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<BankStatementStagingHit, bool>> expression = null,bool shouldRemap = false, Func<BankStatementStagingHit, dynamic> orderExpression = null);






BaseListReturnType<BankStatementStagingHit> GetAllBankStatementStagingHitListByBankStatementHitList(long idBankStatementHitList);

BaseListReturnType<BankStatementStagingHit> GetAllBankStatementStagingHitListByBankStatementHitList(long idBankStatementHitList, SubscriptionEntities db);

BaseListReturnType<BankStatementStagingHit> GetAllBankStatementStagingHitListByBankStatementHitListByPage(long idBankStatementHitList, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<BankStatementStagingHit> GetAllBankStatementStagingHitListByBankStatementHitListByPage(long idBankStatementHitList, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);



 BaseListReturnType<BankStatementStagingHit> GetAllBankStatementStagingHitsWithBankStatementStagingDetailDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<BankStatementStagingHit, bool>> expression = null,bool shouldRemap = false, Func<BankStatementStagingHit, dynamic> orderExpression = null);
 BaseListReturnType<BankStatementStagingHit> GetAllBankStatementStagingHitsWithBankStatementStagingDetailDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<BankStatementStagingHit, bool>> expression = null,bool shouldRemap = false, Func<BankStatementStagingHit, dynamic> orderExpression = null);






BaseListReturnType<BankStatementStagingHit> GetAllBankStatementStagingHitListByBankStatementStagingDetail(long idBankStatementStagingDetail);

BaseListReturnType<BankStatementStagingHit> GetAllBankStatementStagingHitListByBankStatementStagingDetail(long idBankStatementStagingDetail, SubscriptionEntities db);

BaseListReturnType<BankStatementStagingHit> GetAllBankStatementStagingHitListByBankStatementStagingDetailByPage(long idBankStatementStagingDetail, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<BankStatementStagingHit> GetAllBankStatementStagingHitListByBankStatementStagingDetailByPage(long idBankStatementStagingDetail, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);



 BaseListReturnType<BankStatementStagingHit> GetAllBankStatementStagingHitsWithBankReconHitTypeDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<BankStatementStagingHit, bool>> expression = null,bool shouldRemap = false, Func<BankStatementStagingHit, dynamic> orderExpression = null);
 BaseListReturnType<BankStatementStagingHit> GetAllBankStatementStagingHitsWithBankReconHitTypeDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<BankStatementStagingHit, bool>> expression = null,bool shouldRemap = false, Func<BankStatementStagingHit, dynamic> orderExpression = null);






BaseListReturnType<BankStatementStagingHit> GetAllBankStatementStagingHitListByBankReconHitType(long idBankReconHitType);

BaseListReturnType<BankStatementStagingHit> GetAllBankStatementStagingHitListByBankReconHitType(long idBankReconHitType, SubscriptionEntities db);

BaseListReturnType<BankStatementStagingHit> GetAllBankStatementStagingHitListByBankReconHitTypeByPage(long idBankReconHitType, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<BankStatementStagingHit> GetAllBankStatementStagingHitListByBankReconHitTypeByPage(long idBankReconHitType, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);



 BaseListReturnType<BankStatementStagingHit> GetAllBankStatementStagingHitsWithOrderDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<BankStatementStagingHit, bool>> expression = null,bool shouldRemap = false, Func<BankStatementStagingHit, dynamic> orderExpression = null);
 BaseListReturnType<BankStatementStagingHit> GetAllBankStatementStagingHitsWithOrderDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<BankStatementStagingHit, bool>> expression = null,bool shouldRemap = false, Func<BankStatementStagingHit, dynamic> orderExpression = null);






BaseListReturnType<BankStatementStagingHit> GetAllBankStatementStagingHitListByOrder(long idOrder);

BaseListReturnType<BankStatementStagingHit> GetAllBankStatementStagingHitListByOrder(long idOrder, SubscriptionEntities db);

BaseListReturnType<BankStatementStagingHit> GetAllBankStatementStagingHitListByOrderByPage(long idOrder, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<BankStatementStagingHit> GetAllBankStatementStagingHitListByOrderByPage(long idOrder, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);



 BaseListReturnType<BankStatementStagingHit> GetAllBankStatementStagingHitsWithBankStatementStagingHit_TransactionPresetDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<BankStatementStagingHit, bool>> expression = null,bool shouldRemap = false, Func<BankStatementStagingHit, dynamic> orderExpression = null);
 BaseListReturnType<BankStatementStagingHit> GetAllBankStatementStagingHitsWithBankStatementStagingHit_TransactionPresetDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<BankStatementStagingHit, bool>> expression = null,bool shouldRemap = false, Func<BankStatementStagingHit, dynamic> orderExpression = null);

 BaseListReturnType<BankStatementStagingHit> GetAllBankStatementStagingHitsWithTemporaryTransactionsDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<BankStatementStagingHit, bool>> expression = null,bool shouldRemap = false, Func<BankStatementStagingHit, dynamic> orderExpression = null);
 BaseListReturnType<BankStatementStagingHit> GetAllBankStatementStagingHitsWithTemporaryTransactionsDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<BankStatementStagingHit, bool>> expression = null,bool shouldRemap = false, Func<BankStatementStagingHit, dynamic> orderExpression = null);


List<BankStatementStagingHit> GetBankStatementStagingHitListByIdList(List<long> bankStatementStagingHitIds);

List<BankStatementStagingHit> GetBankStatementStagingHitListByIdList(List<long> bankStatementStagingHitIds, SubscriptionEntities db);

 BaseListReturnType<BankStatementStagingHit> GetAllBankStatementStagingHitsWithBankStatementHitListDetails(bool shouldRemap = false);
 BaseListReturnType<BankStatementStagingHit> GetAllBankStatementStagingHitsWithBankStatementStagingDetailDetails(bool shouldRemap = false);
 BaseListReturnType<BankStatementStagingHit> GetAllBankStatementStagingHitsWithBankReconHitTypeDetails(bool shouldRemap = false);
 BaseListReturnType<BankStatementStagingHit> GetAllBankStatementStagingHitsWithOrderDetails(bool shouldRemap = false);
 BaseListReturnType<BankStatementStagingHit> GetAllBankStatementStagingHitsWithBankStatementStagingHit_TransactionPresetDetails(bool shouldRemap = false);
 BaseListReturnType<BankStatementStagingHit> GetAllBankStatementStagingHitsWithTemporaryTransactionsDetails(bool shouldRemap = false);
 BaseListReturnType<BankStatementStagingHit> GetAllBankStatementStagingHitWitDetails( List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<BankStatementStagingHit> GetAllBankStatementStagingHitWitDetails( SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 BankStatementStagingHit GetBankStatementStagingHit(long idBankStatementStagingHit,bool shouldRemap = false);
 BankStatementStagingHit GetBankStatementStagingHit(long idBankStatementStagingHit, SubscriptionEntities db,bool shouldRemap = false);
 BankStatementStagingHit GetBankStatementStagingHitWithBankStatementHitListDetails(long idBankStatementStagingHit,bool shouldRemap = false);
    


 BankStatementStagingHit GetBankStatementStagingHitWithBankStatementStagingDetailDetails(long idBankStatementStagingHit,bool shouldRemap = false);
    


 BankStatementStagingHit GetBankStatementStagingHitWithBankReconHitTypeDetails(long idBankStatementStagingHit,bool shouldRemap = false);
    


 BankStatementStagingHit GetBankStatementStagingHitWithOrderDetails(long idBankStatementStagingHit,bool shouldRemap = false);
    


 BankStatementStagingHit GetBankStatementStagingHitWithBankStatementStagingHit_TransactionPresetDetails(long idBankStatementStagingHit,bool shouldRemap = false);
           List<BankStatementStagingHit_TransactionPreset> UpdateBankStatementStagingHit_TransactionPresetForBankStatementStagingHitWithoutSavingNewItem(List<BankStatementStagingHit_TransactionPreset> newBankStatementStagingHit_TransactionPreset,long idBankStatementStagingHit);
    List<BankStatementStagingHit_TransactionPreset> UpdateBankStatementStagingHit_TransactionPresetForBankStatementStagingHitWithoutSavingNewItem(List<BankStatementStagingHit_TransactionPreset> newBankStatementStagingHit_TransactionPreset,long idBankStatementStagingHit,SubscriptionEntities db);
          

    List<BankStatementStagingHit_TransactionPreset> UpdateBankStatementStagingHit_TransactionPresetForBankStatementStagingHit(List<BankStatementStagingHit_TransactionPreset> newBankStatementStagingHit_TransactionPreset,long idBankStatementStagingHit);
    List<BankStatementStagingHit_TransactionPreset> UpdateBankStatementStagingHit_TransactionPresetForBankStatementStagingHit(List<BankStatementStagingHit_TransactionPreset> newBankStatementStagingHit_TransactionPreset,long idBankStatementStagingHit,SubscriptionEntities db);
                           



 BankStatementStagingHit GetBankStatementStagingHitWithTemporaryTransactionsDetails(long idBankStatementStagingHit,bool shouldRemap = false);
           List<TemporaryTransaction> UpdateTemporaryTransactionsForBankStatementStagingHitWithoutSavingNewItem(List<TemporaryTransaction> newTemporaryTransactions,long idBankStatementStagingHit);
    List<TemporaryTransaction> UpdateTemporaryTransactionsForBankStatementStagingHitWithoutSavingNewItem(List<TemporaryTransaction> newTemporaryTransactions,long idBankStatementStagingHit,SubscriptionEntities db);
          

    List<TemporaryTransaction> UpdateTemporaryTransactionsForBankStatementStagingHit(List<TemporaryTransaction> newTemporaryTransactions,long idBankStatementStagingHit);
    List<TemporaryTransaction> UpdateTemporaryTransactionsForBankStatementStagingHit(List<TemporaryTransaction> newTemporaryTransactions,long idBankStatementStagingHit,SubscriptionEntities db);
                           



 BankStatementStagingHit GetBankStatementStagingHitCustom( Expression<Func<BankStatementStagingHit, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 BankStatementStagingHit GetBankStatementStagingHitCustom(SubscriptionEntities db, Expression<Func<BankStatementStagingHit, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<BankStatementStagingHit> GetBankStatementStagingHitCustomList( Expression<Func<BankStatementStagingHit, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<BankStatementStagingHit, dynamic> orderExpression = null);
 BaseListReturnType<BankStatementStagingHit> GetBankStatementStagingHitCustomList( SubscriptionEntities db , Expression<Func<BankStatementStagingHit, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<BankStatementStagingHit, dynamic> orderExpression = null);
 BankStatementStagingHit GetBankStatementStagingHitWithDetails(long idBankStatementStagingHit, List<string> includes = null,bool shouldRemap = false);
 BankStatementStagingHit GetBankStatementStagingHitWithDetails(long idBankStatementStagingHit, SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 BankStatementStagingHit GetBankStatementStagingHitWitDetails(long idBankStatementStagingHit,bool shouldRemap = false);
 BankStatementStagingHit GetBankStatementStagingHitWitDetails(long idBankStatementStagingHit, SubscriptionEntities db,bool shouldRemap = false);
 void SaveBankStatementStagingHit(BankStatementStagingHit bankStatementStagingHit);
 void SaveBankStatementStagingHit(BankStatementStagingHit bankStatementStagingHit, SubscriptionEntities db);
 void SaveOnlyBankStatementStagingHit(BankStatementStagingHit bankStatementStagingHit);
 void SaveOnlyBankStatementStagingHit(BankStatementStagingHit bankStatementStagingHit, SubscriptionEntities db);
 void DeleteBankStatementStagingHit(BankStatementStagingHit bankStatementStagingHit);
 void DeleteBankStatementStagingHit(BankStatementStagingHit bankStatementStagingHit, SubscriptionEntities db);		
  void DeletePermanentlyBankStatementStagingHit(BankStatementStagingHit bankStatementStagingHit);
 void DeletePermanentlyBankStatementStagingHit(BankStatementStagingHit bankStatementStagingHit, SubscriptionEntities db);	
	}
 	public partial interface IBankStatementStagingHit_TransactionPresetDao
	{
  List<BankStatementStagingHit_TransactionPreset> GetAllBankStatementStagingHit_TransactionPreset(bool shouldRemap = false);
  List<BankStatementStagingHit_TransactionPreset> GetAllBankStatementStagingHit_TransactionPreset(SubscriptionEntities db,bool shouldRemap = false);
  BaseListReturnType<BankStatementStagingHit_TransactionPreset> GetAllBankStatementStagingHit_TransactionPresetByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<BankStatementStagingHit_TransactionPreset, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<BankStatementStagingHit_TransactionPreset, dynamic> orderExpression = null);
  BaseListReturnType<BankStatementStagingHit_TransactionPreset> GetAllBankStatementStagingHit_TransactionPresetByPage(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<BankStatementStagingHit_TransactionPreset, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<BankStatementStagingHit_TransactionPreset, dynamic> orderExpression = null);
  
  BaseListReturnType<BankStatementStagingHit_TransactionPreset> GetAllBankStatementStagingHit_TransactionPresetByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<BankStatementStagingHit_TransactionPreset, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<BankStatementStagingHit_TransactionPreset, dynamic> orderExpression = null);
  BaseListReturnType<BankStatementStagingHit_TransactionPreset> GetAllBankStatementStagingHit_TransactionPresetByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<BankStatementStagingHit_TransactionPreset, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<BankStatementStagingHit_TransactionPreset, dynamic> orderExpression = null);

 BaseListReturnType<BankStatementStagingHit_TransactionPreset> GetAllBankStatementStagingHit_TransactionPresetWithBankStatementStagingHitDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<BankStatementStagingHit_TransactionPreset, bool>> expression = null,bool shouldRemap = false, Func<BankStatementStagingHit_TransactionPreset, dynamic> orderExpression = null);
 BaseListReturnType<BankStatementStagingHit_TransactionPreset> GetAllBankStatementStagingHit_TransactionPresetWithBankStatementStagingHitDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<BankStatementStagingHit_TransactionPreset, bool>> expression = null,bool shouldRemap = false, Func<BankStatementStagingHit_TransactionPreset, dynamic> orderExpression = null);






BaseListReturnType<BankStatementStagingHit_TransactionPreset> GetAllBankStatementStagingHit_TransactionPresetListByBankStatementStagingHit(long idBankStatementStagingHit);

BaseListReturnType<BankStatementStagingHit_TransactionPreset> GetAllBankStatementStagingHit_TransactionPresetListByBankStatementStagingHit(long idBankStatementStagingHit, SubscriptionEntities db);

BaseListReturnType<BankStatementStagingHit_TransactionPreset> GetAllBankStatementStagingHit_TransactionPresetListByBankStatementStagingHitByPage(long idBankStatementStagingHit, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<BankStatementStagingHit_TransactionPreset> GetAllBankStatementStagingHit_TransactionPresetListByBankStatementStagingHitByPage(long idBankStatementStagingHit, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);



 BaseListReturnType<BankStatementStagingHit_TransactionPreset> GetAllBankStatementStagingHit_TransactionPresetWithTransactionPresetDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<BankStatementStagingHit_TransactionPreset, bool>> expression = null,bool shouldRemap = false, Func<BankStatementStagingHit_TransactionPreset, dynamic> orderExpression = null);
 BaseListReturnType<BankStatementStagingHit_TransactionPreset> GetAllBankStatementStagingHit_TransactionPresetWithTransactionPresetDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<BankStatementStagingHit_TransactionPreset, bool>> expression = null,bool shouldRemap = false, Func<BankStatementStagingHit_TransactionPreset, dynamic> orderExpression = null);






BaseListReturnType<BankStatementStagingHit_TransactionPreset> GetAllBankStatementStagingHit_TransactionPresetListByTransactionPreset(long idTransactionPreset);

BaseListReturnType<BankStatementStagingHit_TransactionPreset> GetAllBankStatementStagingHit_TransactionPresetListByTransactionPreset(long idTransactionPreset, SubscriptionEntities db);

BaseListReturnType<BankStatementStagingHit_TransactionPreset> GetAllBankStatementStagingHit_TransactionPresetListByTransactionPresetByPage(long idTransactionPreset, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<BankStatementStagingHit_TransactionPreset> GetAllBankStatementStagingHit_TransactionPresetListByTransactionPresetByPage(long idTransactionPreset, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);




List<BankStatementStagingHit_TransactionPreset> GetBankStatementStagingHit_TransactionPresetListByIdList(List<long> bankStatementStagingHit_TransactionPresetIds);

List<BankStatementStagingHit_TransactionPreset> GetBankStatementStagingHit_TransactionPresetListByIdList(List<long> bankStatementStagingHit_TransactionPresetIds, SubscriptionEntities db);

 BaseListReturnType<BankStatementStagingHit_TransactionPreset> GetAllBankStatementStagingHit_TransactionPresetWithBankStatementStagingHitDetails(bool shouldRemap = false);
 BaseListReturnType<BankStatementStagingHit_TransactionPreset> GetAllBankStatementStagingHit_TransactionPresetWithTransactionPresetDetails(bool shouldRemap = false);
 BaseListReturnType<BankStatementStagingHit_TransactionPreset> GetAllBankStatementStagingHit_TransactionPresetWitDetails( List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<BankStatementStagingHit_TransactionPreset> GetAllBankStatementStagingHit_TransactionPresetWitDetails( SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 BankStatementStagingHit_TransactionPreset GetBankStatementStagingHit_TransactionPreset(long idBankStatementStagingHit_TransactionPreset,bool shouldRemap = false);
 BankStatementStagingHit_TransactionPreset GetBankStatementStagingHit_TransactionPreset(long idBankStatementStagingHit_TransactionPreset, SubscriptionEntities db,bool shouldRemap = false);
 BankStatementStagingHit_TransactionPreset GetBankStatementStagingHit_TransactionPresetWithBankStatementStagingHitDetails(long idBankStatementStagingHit_TransactionPreset,bool shouldRemap = false);
    


 BankStatementStagingHit_TransactionPreset GetBankStatementStagingHit_TransactionPresetWithTransactionPresetDetails(long idBankStatementStagingHit_TransactionPreset,bool shouldRemap = false);
    


 BankStatementStagingHit_TransactionPreset GetBankStatementStagingHit_TransactionPresetCustom( Expression<Func<BankStatementStagingHit_TransactionPreset, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 BankStatementStagingHit_TransactionPreset GetBankStatementStagingHit_TransactionPresetCustom(SubscriptionEntities db, Expression<Func<BankStatementStagingHit_TransactionPreset, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<BankStatementStagingHit_TransactionPreset> GetBankStatementStagingHit_TransactionPresetCustomList( Expression<Func<BankStatementStagingHit_TransactionPreset, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<BankStatementStagingHit_TransactionPreset, dynamic> orderExpression = null);
 BaseListReturnType<BankStatementStagingHit_TransactionPreset> GetBankStatementStagingHit_TransactionPresetCustomList( SubscriptionEntities db , Expression<Func<BankStatementStagingHit_TransactionPreset, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<BankStatementStagingHit_TransactionPreset, dynamic> orderExpression = null);
 BankStatementStagingHit_TransactionPreset GetBankStatementStagingHit_TransactionPresetWithDetails(long idBankStatementStagingHit_TransactionPreset, List<string> includes = null,bool shouldRemap = false);
 BankStatementStagingHit_TransactionPreset GetBankStatementStagingHit_TransactionPresetWithDetails(long idBankStatementStagingHit_TransactionPreset, SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 BankStatementStagingHit_TransactionPreset GetBankStatementStagingHit_TransactionPresetWitDetails(long idBankStatementStagingHit_TransactionPreset,bool shouldRemap = false);
 BankStatementStagingHit_TransactionPreset GetBankStatementStagingHit_TransactionPresetWitDetails(long idBankStatementStagingHit_TransactionPreset, SubscriptionEntities db,bool shouldRemap = false);
 void SaveBankStatementStagingHit_TransactionPreset(BankStatementStagingHit_TransactionPreset bankStatementStagingHit_TransactionPreset);
 void SaveBankStatementStagingHit_TransactionPreset(BankStatementStagingHit_TransactionPreset bankStatementStagingHit_TransactionPreset, SubscriptionEntities db);
 void SaveOnlyBankStatementStagingHit_TransactionPreset(BankStatementStagingHit_TransactionPreset bankStatementStagingHit_TransactionPreset);
 void SaveOnlyBankStatementStagingHit_TransactionPreset(BankStatementStagingHit_TransactionPreset bankStatementStagingHit_TransactionPreset, SubscriptionEntities db);
 void DeleteBankStatementStagingHit_TransactionPreset(BankStatementStagingHit_TransactionPreset bankStatementStagingHit_TransactionPreset);
 void DeleteBankStatementStagingHit_TransactionPreset(BankStatementStagingHit_TransactionPreset bankStatementStagingHit_TransactionPreset, SubscriptionEntities db);		
  void DeletePermanentlyBankStatementStagingHit_TransactionPreset(BankStatementStagingHit_TransactionPreset bankStatementStagingHit_TransactionPreset);
 void DeletePermanentlyBankStatementStagingHit_TransactionPreset(BankStatementStagingHit_TransactionPreset bankStatementStagingHit_TransactionPreset, SubscriptionEntities db);	
	}
 	public partial interface IBankStatementStagingStateDao
	{
  List<BankStatementStagingState> GetAllBankStatementStagingStates(bool shouldRemap = false);
  List<BankStatementStagingState> GetAllBankStatementStagingStates(SubscriptionEntities db,bool shouldRemap = false);
  BaseListReturnType<BankStatementStagingState> GetAllBankStatementStagingStatesByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<BankStatementStagingState, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<BankStatementStagingState, dynamic> orderExpression = null);
  BaseListReturnType<BankStatementStagingState> GetAllBankStatementStagingStatesByPage(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<BankStatementStagingState, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<BankStatementStagingState, dynamic> orderExpression = null);
  
  BaseListReturnType<BankStatementStagingState> GetAllBankStatementStagingStatesByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<BankStatementStagingState, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<BankStatementStagingState, dynamic> orderExpression = null);
  BaseListReturnType<BankStatementStagingState> GetAllBankStatementStagingStatesByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<BankStatementStagingState, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<BankStatementStagingState, dynamic> orderExpression = null);

 BaseListReturnType<BankStatementStagingState> GetAllBankStatementStagingStatesWithBankStatementStagingsDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<BankStatementStagingState, bool>> expression = null,bool shouldRemap = false, Func<BankStatementStagingState, dynamic> orderExpression = null);
 BaseListReturnType<BankStatementStagingState> GetAllBankStatementStagingStatesWithBankStatementStagingsDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<BankStatementStagingState, bool>> expression = null,bool shouldRemap = false, Func<BankStatementStagingState, dynamic> orderExpression = null);

 BaseListReturnType<BankStatementStagingState> GetAllBankStatementStagingStatesWithBankStatementStagingDetailBatchesDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<BankStatementStagingState, bool>> expression = null,bool shouldRemap = false, Func<BankStatementStagingState, dynamic> orderExpression = null);
 BaseListReturnType<BankStatementStagingState> GetAllBankStatementStagingStatesWithBankStatementStagingDetailBatchesDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<BankStatementStagingState, bool>> expression = null,bool shouldRemap = false, Func<BankStatementStagingState, dynamic> orderExpression = null);


List<BankStatementStagingState> GetBankStatementStagingStateListByIdList(List<long> bankStatementStagingStateIds);

List<BankStatementStagingState> GetBankStatementStagingStateListByIdList(List<long> bankStatementStagingStateIds, SubscriptionEntities db);

 BaseListReturnType<BankStatementStagingState> GetAllBankStatementStagingStatesWithBankStatementStagingsDetails(bool shouldRemap = false);
 BaseListReturnType<BankStatementStagingState> GetAllBankStatementStagingStatesWithBankStatementStagingDetailBatchesDetails(bool shouldRemap = false);
 BaseListReturnType<BankStatementStagingState> GetAllBankStatementStagingStateWitDetails( List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<BankStatementStagingState> GetAllBankStatementStagingStateWitDetails( SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 BankStatementStagingState GetBankStatementStagingState(long idBankStatementStagingState,bool shouldRemap = false);
 BankStatementStagingState GetBankStatementStagingState(long idBankStatementStagingState, SubscriptionEntities db,bool shouldRemap = false);
 BankStatementStagingState GetBankStatementStagingStateWithBankStatementStagingsDetails(long idBankStatementStagingState,bool shouldRemap = false);
           List<BankStatementStaging> UpdateBankStatementStagingsForBankStatementStagingStateWithoutSavingNewItem(List<BankStatementStaging> newBankStatementStagings,long idBankStatementStagingState);
    List<BankStatementStaging> UpdateBankStatementStagingsForBankStatementStagingStateWithoutSavingNewItem(List<BankStatementStaging> newBankStatementStagings,long idBankStatementStagingState,SubscriptionEntities db);
          

    List<BankStatementStaging> UpdateBankStatementStagingsForBankStatementStagingState(List<BankStatementStaging> newBankStatementStagings,long idBankStatementStagingState);
    List<BankStatementStaging> UpdateBankStatementStagingsForBankStatementStagingState(List<BankStatementStaging> newBankStatementStagings,long idBankStatementStagingState,SubscriptionEntities db);
                           



 BankStatementStagingState GetBankStatementStagingStateWithBankStatementStagingDetailBatchesDetails(long idBankStatementStagingState,bool shouldRemap = false);
           List<BankStatementStagingDetailBatch> UpdateBankStatementStagingDetailBatchesForBankStatementStagingStateWithoutSavingNewItem(List<BankStatementStagingDetailBatch> newBankStatementStagingDetailBatches,long idBankStatementStagingState);
    List<BankStatementStagingDetailBatch> UpdateBankStatementStagingDetailBatchesForBankStatementStagingStateWithoutSavingNewItem(List<BankStatementStagingDetailBatch> newBankStatementStagingDetailBatches,long idBankStatementStagingState,SubscriptionEntities db);
          

    List<BankStatementStagingDetailBatch> UpdateBankStatementStagingDetailBatchesForBankStatementStagingState(List<BankStatementStagingDetailBatch> newBankStatementStagingDetailBatches,long idBankStatementStagingState);
    List<BankStatementStagingDetailBatch> UpdateBankStatementStagingDetailBatchesForBankStatementStagingState(List<BankStatementStagingDetailBatch> newBankStatementStagingDetailBatches,long idBankStatementStagingState,SubscriptionEntities db);
                           



 BankStatementStagingState GetBankStatementStagingStateCustom( Expression<Func<BankStatementStagingState, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 BankStatementStagingState GetBankStatementStagingStateCustom(SubscriptionEntities db, Expression<Func<BankStatementStagingState, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<BankStatementStagingState> GetBankStatementStagingStateCustomList( Expression<Func<BankStatementStagingState, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<BankStatementStagingState, dynamic> orderExpression = null);
 BaseListReturnType<BankStatementStagingState> GetBankStatementStagingStateCustomList( SubscriptionEntities db , Expression<Func<BankStatementStagingState, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<BankStatementStagingState, dynamic> orderExpression = null);
 BankStatementStagingState GetBankStatementStagingStateWithDetails(long idBankStatementStagingState, List<string> includes = null,bool shouldRemap = false);
 BankStatementStagingState GetBankStatementStagingStateWithDetails(long idBankStatementStagingState, SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 BankStatementStagingState GetBankStatementStagingStateWitDetails(long idBankStatementStagingState,bool shouldRemap = false);
 BankStatementStagingState GetBankStatementStagingStateWitDetails(long idBankStatementStagingState, SubscriptionEntities db,bool shouldRemap = false);
 void SaveBankStatementStagingState(BankStatementStagingState bankStatementStagingState);
 void SaveBankStatementStagingState(BankStatementStagingState bankStatementStagingState, SubscriptionEntities db);
 void SaveOnlyBankStatementStagingState(BankStatementStagingState bankStatementStagingState);
 void SaveOnlyBankStatementStagingState(BankStatementStagingState bankStatementStagingState, SubscriptionEntities db);
 void DeleteBankStatementStagingState(BankStatementStagingState bankStatementStagingState);
 void DeleteBankStatementStagingState(BankStatementStagingState bankStatementStagingState, SubscriptionEntities db);		
  void DeletePermanentlyBankStatementStagingState(BankStatementStagingState bankStatementStagingState);
 void DeletePermanentlyBankStatementStagingState(BankStatementStagingState bankStatementStagingState, SubscriptionEntities db);	
	}
 	public partial interface ICityDao
	{
  List<City> GetAllCities(bool shouldRemap = false);
  List<City> GetAllCities(SubscriptionEntities db,bool shouldRemap = false);
  BaseListReturnType<City> GetAllCitiesByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<City, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<City, dynamic> orderExpression = null);
  BaseListReturnType<City> GetAllCitiesByPage(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<City, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<City, dynamic> orderExpression = null);
  
  BaseListReturnType<City> GetAllCitiesByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<City, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<City, dynamic> orderExpression = null);
  BaseListReturnType<City> GetAllCitiesByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<City, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<City, dynamic> orderExpression = null);

 BaseListReturnType<City> GetAllCitiesWithAddressesDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<City, bool>> expression = null,bool shouldRemap = false, Func<City, dynamic> orderExpression = null);
 BaseListReturnType<City> GetAllCitiesWithAddressesDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<City, bool>> expression = null,bool shouldRemap = false, Func<City, dynamic> orderExpression = null);

 BaseListReturnType<City> GetAllCitiesWithCountryDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<City, bool>> expression = null,bool shouldRemap = false, Func<City, dynamic> orderExpression = null);
 BaseListReturnType<City> GetAllCitiesWithCountryDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<City, bool>> expression = null,bool shouldRemap = false, Func<City, dynamic> orderExpression = null);






BaseListReturnType<City> GetAllCityListByCountry(long idCountry);

BaseListReturnType<City> GetAllCityListByCountry(long idCountry, SubscriptionEntities db);

BaseListReturnType<City> GetAllCityListByCountryByPage(long idCountry, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<City> GetAllCityListByCountryByPage(long idCountry, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);




List<City> GetCityListByIdList(List<long> cityIds);

List<City> GetCityListByIdList(List<long> cityIds, SubscriptionEntities db);

 BaseListReturnType<City> GetAllCitiesWithAddressesDetails(bool shouldRemap = false);
 BaseListReturnType<City> GetAllCitiesWithCountryDetails(bool shouldRemap = false);
 BaseListReturnType<City> GetAllCityWitDetails( List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<City> GetAllCityWitDetails( SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 City GetCity(long idCity,bool shouldRemap = false);
 City GetCity(long idCity, SubscriptionEntities db,bool shouldRemap = false);
 City GetCityWithAddressesDetails(long idCity,bool shouldRemap = false);
           List<Address> UpdateAddressesForCityWithoutSavingNewItem(List<Address> newAddresses,long idCity);
    List<Address> UpdateAddressesForCityWithoutSavingNewItem(List<Address> newAddresses,long idCity,SubscriptionEntities db);
          

    List<Address> UpdateAddressesForCity(List<Address> newAddresses,long idCity);
    List<Address> UpdateAddressesForCity(List<Address> newAddresses,long idCity,SubscriptionEntities db);
                           



 City GetCityWithCountryDetails(long idCity,bool shouldRemap = false);
    


 City GetCityCustom( Expression<Func<City, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 City GetCityCustom(SubscriptionEntities db, Expression<Func<City, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<City> GetCityCustomList( Expression<Func<City, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<City, dynamic> orderExpression = null);
 BaseListReturnType<City> GetCityCustomList( SubscriptionEntities db , Expression<Func<City, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<City, dynamic> orderExpression = null);
 City GetCityWithDetails(long idCity, List<string> includes = null,bool shouldRemap = false);
 City GetCityWithDetails(long idCity, SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 City GetCityWitDetails(long idCity,bool shouldRemap = false);
 City GetCityWitDetails(long idCity, SubscriptionEntities db,bool shouldRemap = false);
 void SaveCity(City city);
 void SaveCity(City city, SubscriptionEntities db);
 void SaveOnlyCity(City city);
 void SaveOnlyCity(City city, SubscriptionEntities db);
 void DeleteCity(City city);
 void DeleteCity(City city, SubscriptionEntities db);		
  void DeletePermanentlyCity(City city);
 void DeletePermanentlyCity(City city, SubscriptionEntities db);	
	}
 	public partial interface ICompanyDao
	{
  List<Company> GetAllCompanies(bool shouldRemap = false);
  List<Company> GetAllCompanies(SubscriptionEntities db,bool shouldRemap = false);
  BaseListReturnType<Company> GetAllCompaniesByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Company, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<Company, dynamic> orderExpression = null);
  BaseListReturnType<Company> GetAllCompaniesByPage(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<Company, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<Company, dynamic> orderExpression = null);
  
  BaseListReturnType<Company> GetAllCompaniesByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Company, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<Company, dynamic> orderExpression = null);
  BaseListReturnType<Company> GetAllCompaniesByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<Company, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<Company, dynamic> orderExpression = null);

 BaseListReturnType<Company> GetAllCompaniesWithCompany_ContactTypeDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Company, bool>> expression = null,bool shouldRemap = false, Func<Company, dynamic> orderExpression = null);
 BaseListReturnType<Company> GetAllCompaniesWithCompany_ContactTypeDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Company, bool>> expression = null,bool shouldRemap = false, Func<Company, dynamic> orderExpression = null);

 BaseListReturnType<Company> GetAllCompaniesWithCustomersDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Company, bool>> expression = null,bool shouldRemap = false, Func<Company, dynamic> orderExpression = null);
 BaseListReturnType<Company> GetAllCompaniesWithCustomersDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Company, bool>> expression = null,bool shouldRemap = false, Func<Company, dynamic> orderExpression = null);

 BaseListReturnType<Company> GetAllCompaniesWithConceptDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Company, bool>> expression = null,bool shouldRemap = false, Func<Company, dynamic> orderExpression = null);
 BaseListReturnType<Company> GetAllCompaniesWithConceptDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Company, bool>> expression = null,bool shouldRemap = false, Func<Company, dynamic> orderExpression = null);






BaseListReturnType<Company> GetAllCompanyListByConcept(long idConcept);

BaseListReturnType<Company> GetAllCompanyListByConcept(long idConcept, SubscriptionEntities db);

BaseListReturnType<Company> GetAllCompanyListByConceptByPage(long idConcept, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<Company> GetAllCompanyListByConceptByPage(long idConcept, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);



 BaseListReturnType<Company> GetAllCompaniesWithDocumentDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Company, bool>> expression = null,bool shouldRemap = false, Func<Company, dynamic> orderExpression = null);
 BaseListReturnType<Company> GetAllCompaniesWithDocumentDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Company, bool>> expression = null,bool shouldRemap = false, Func<Company, dynamic> orderExpression = null);






BaseListReturnType<Company> GetAllCompanyListByDocument(long idDocument);

BaseListReturnType<Company> GetAllCompanyListByDocument(long idDocument, SubscriptionEntities db);

BaseListReturnType<Company> GetAllCompanyListByDocumentByPage(long idDocument, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<Company> GetAllCompanyListByDocumentByPage(long idDocument, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);



 BaseListReturnType<Company> GetAllCompaniesWithCompanyLocationsDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Company, bool>> expression = null,bool shouldRemap = false, Func<Company, dynamic> orderExpression = null);
 BaseListReturnType<Company> GetAllCompaniesWithCompanyLocationsDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Company, bool>> expression = null,bool shouldRemap = false, Func<Company, dynamic> orderExpression = null);

 BaseListReturnType<Company> GetAllCompaniesWithConceptsDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Company, bool>> expression = null,bool shouldRemap = false, Func<Company, dynamic> orderExpression = null);
 BaseListReturnType<Company> GetAllCompaniesWithConceptsDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Company, bool>> expression = null,bool shouldRemap = false, Func<Company, dynamic> orderExpression = null);


List<Company> GetCompanyListByIdList(List<long> companyIds);

List<Company> GetCompanyListByIdList(List<long> companyIds, SubscriptionEntities db);

 BaseListReturnType<Company> GetAllCompaniesWithCompany_ContactTypeDetails(bool shouldRemap = false);
 BaseListReturnType<Company> GetAllCompaniesWithCustomersDetails(bool shouldRemap = false);
 BaseListReturnType<Company> GetAllCompaniesWithConceptDetails(bool shouldRemap = false);
 BaseListReturnType<Company> GetAllCompaniesWithDocumentDetails(bool shouldRemap = false);
 BaseListReturnType<Company> GetAllCompaniesWithCompanyLocationsDetails(bool shouldRemap = false);
 BaseListReturnType<Company> GetAllCompaniesWithConceptsDetails(bool shouldRemap = false);
 BaseListReturnType<Company> GetAllCompanyWitDetails( List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<Company> GetAllCompanyWitDetails( SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 Company GetCompany(long idCompany,bool shouldRemap = false);
 Company GetCompany(long idCompany, SubscriptionEntities db,bool shouldRemap = false);
 Company GetCompanyWithCompany_ContactTypeDetails(long idCompany,bool shouldRemap = false);
           List<Company_ContactType> UpdateCompany_ContactTypeForCompanyWithoutSavingNewItem(List<Company_ContactType> newCompany_ContactType,long idCompany);
    List<Company_ContactType> UpdateCompany_ContactTypeForCompanyWithoutSavingNewItem(List<Company_ContactType> newCompany_ContactType,long idCompany,SubscriptionEntities db);
          

    List<Company_ContactType> UpdateCompany_ContactTypeForCompany(List<Company_ContactType> newCompany_ContactType,long idCompany);
    List<Company_ContactType> UpdateCompany_ContactTypeForCompany(List<Company_ContactType> newCompany_ContactType,long idCompany,SubscriptionEntities db);
                           



 Company GetCompanyWithCustomersDetails(long idCompany,bool shouldRemap = false);
           List<Customer> UpdateCustomersForCompanyWithoutSavingNewItem(List<Customer> newCustomers,long idCompany);
    List<Customer> UpdateCustomersForCompanyWithoutSavingNewItem(List<Customer> newCustomers,long idCompany,SubscriptionEntities db);
          

    List<Customer> UpdateCustomersForCompany(List<Customer> newCustomers,long idCompany);
    List<Customer> UpdateCustomersForCompany(List<Customer> newCustomers,long idCompany,SubscriptionEntities db);
                           



 Company GetCompanyWithConceptDetails(long idCompany,bool shouldRemap = false);
    


 Company GetCompanyWithDocumentDetails(long idCompany,bool shouldRemap = false);
    


 Company GetCompanyWithCompanyLocationsDetails(long idCompany,bool shouldRemap = false);
           List<CompanyLocation> UpdateCompanyLocationsForCompanyWithoutSavingNewItem(List<CompanyLocation> newCompanyLocations,long idCompany);
    List<CompanyLocation> UpdateCompanyLocationsForCompanyWithoutSavingNewItem(List<CompanyLocation> newCompanyLocations,long idCompany,SubscriptionEntities db);
          

    List<CompanyLocation> UpdateCompanyLocationsForCompany(List<CompanyLocation> newCompanyLocations,long idCompany);
    List<CompanyLocation> UpdateCompanyLocationsForCompany(List<CompanyLocation> newCompanyLocations,long idCompany,SubscriptionEntities db);
                           



 Company GetCompanyWithConceptsDetails(long idCompany,bool shouldRemap = false);
           List<Concept> UpdateConceptsForCompanyWithoutSavingNewItem(List<Concept> newConcepts,long idCompany);
    List<Concept> UpdateConceptsForCompanyWithoutSavingNewItem(List<Concept> newConcepts,long idCompany,SubscriptionEntities db);
          

    List<Concept> UpdateConceptsForCompany(List<Concept> newConcepts,long idCompany);
    List<Concept> UpdateConceptsForCompany(List<Concept> newConcepts,long idCompany,SubscriptionEntities db);
                           



 Company GetCompanyCustom( Expression<Func<Company, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 Company GetCompanyCustom(SubscriptionEntities db, Expression<Func<Company, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<Company> GetCompanyCustomList( Expression<Func<Company, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<Company, dynamic> orderExpression = null);
 BaseListReturnType<Company> GetCompanyCustomList( SubscriptionEntities db , Expression<Func<Company, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<Company, dynamic> orderExpression = null);
 Company GetCompanyWithDetails(long idCompany, List<string> includes = null,bool shouldRemap = false);
 Company GetCompanyWithDetails(long idCompany, SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 Company GetCompanyWitDetails(long idCompany,bool shouldRemap = false);
 Company GetCompanyWitDetails(long idCompany, SubscriptionEntities db,bool shouldRemap = false);
 void SaveCompany(Company company);
 void SaveCompany(Company company, SubscriptionEntities db);
 void SaveOnlyCompany(Company company);
 void SaveOnlyCompany(Company company, SubscriptionEntities db);
 void DeleteCompany(Company company);
 void DeleteCompany(Company company, SubscriptionEntities db);		
  void DeletePermanentlyCompany(Company company);
 void DeletePermanentlyCompany(Company company, SubscriptionEntities db);	
	}
 	public partial interface ICompany_ContactTypeDao
	{
  List<Company_ContactType> GetAllCompany_ContactType(bool shouldRemap = false);
  List<Company_ContactType> GetAllCompany_ContactType(SubscriptionEntities db,bool shouldRemap = false);
  BaseListReturnType<Company_ContactType> GetAllCompany_ContactTypeByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Company_ContactType, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<Company_ContactType, dynamic> orderExpression = null);
  BaseListReturnType<Company_ContactType> GetAllCompany_ContactTypeByPage(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<Company_ContactType, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<Company_ContactType, dynamic> orderExpression = null);
  
  BaseListReturnType<Company_ContactType> GetAllCompany_ContactTypeByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Company_ContactType, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<Company_ContactType, dynamic> orderExpression = null);
  BaseListReturnType<Company_ContactType> GetAllCompany_ContactTypeByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<Company_ContactType, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<Company_ContactType, dynamic> orderExpression = null);

 BaseListReturnType<Company_ContactType> GetAllCompany_ContactTypeWithCompanyDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Company_ContactType, bool>> expression = null,bool shouldRemap = false, Func<Company_ContactType, dynamic> orderExpression = null);
 BaseListReturnType<Company_ContactType> GetAllCompany_ContactTypeWithCompanyDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Company_ContactType, bool>> expression = null,bool shouldRemap = false, Func<Company_ContactType, dynamic> orderExpression = null);






BaseListReturnType<Company_ContactType> GetAllCompany_ContactTypeListByCompany(long idCompany);

BaseListReturnType<Company_ContactType> GetAllCompany_ContactTypeListByCompany(long idCompany, SubscriptionEntities db);

BaseListReturnType<Company_ContactType> GetAllCompany_ContactTypeListByCompanyByPage(long idCompany, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<Company_ContactType> GetAllCompany_ContactTypeListByCompanyByPage(long idCompany, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);



 BaseListReturnType<Company_ContactType> GetAllCompany_ContactTypeWithContactTypeDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Company_ContactType, bool>> expression = null,bool shouldRemap = false, Func<Company_ContactType, dynamic> orderExpression = null);
 BaseListReturnType<Company_ContactType> GetAllCompany_ContactTypeWithContactTypeDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Company_ContactType, bool>> expression = null,bool shouldRemap = false, Func<Company_ContactType, dynamic> orderExpression = null);






BaseListReturnType<Company_ContactType> GetAllCompany_ContactTypeListByContactType(long idContactType);

BaseListReturnType<Company_ContactType> GetAllCompany_ContactTypeListByContactType(long idContactType, SubscriptionEntities db);

BaseListReturnType<Company_ContactType> GetAllCompany_ContactTypeListByContactTypeByPage(long idContactType, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<Company_ContactType> GetAllCompany_ContactTypeListByContactTypeByPage(long idContactType, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);




List<Company_ContactType> GetCompany_ContactTypeListByIdList(List<long> company_ContactTypeIds);

List<Company_ContactType> GetCompany_ContactTypeListByIdList(List<long> company_ContactTypeIds, SubscriptionEntities db);

 BaseListReturnType<Company_ContactType> GetAllCompany_ContactTypeWithCompanyDetails(bool shouldRemap = false);
 BaseListReturnType<Company_ContactType> GetAllCompany_ContactTypeWithContactTypeDetails(bool shouldRemap = false);
 BaseListReturnType<Company_ContactType> GetAllCompany_ContactTypeWitDetails( List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<Company_ContactType> GetAllCompany_ContactTypeWitDetails( SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 Company_ContactType GetCompany_ContactType(long idCompany_ContactType,bool shouldRemap = false);
 Company_ContactType GetCompany_ContactType(long idCompany_ContactType, SubscriptionEntities db,bool shouldRemap = false);
 Company_ContactType GetCompany_ContactTypeWithCompanyDetails(long idCompany_ContactType,bool shouldRemap = false);
    


 Company_ContactType GetCompany_ContactTypeWithContactTypeDetails(long idCompany_ContactType,bool shouldRemap = false);
    


 Company_ContactType GetCompany_ContactTypeCustom( Expression<Func<Company_ContactType, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 Company_ContactType GetCompany_ContactTypeCustom(SubscriptionEntities db, Expression<Func<Company_ContactType, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<Company_ContactType> GetCompany_ContactTypeCustomList( Expression<Func<Company_ContactType, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<Company_ContactType, dynamic> orderExpression = null);
 BaseListReturnType<Company_ContactType> GetCompany_ContactTypeCustomList( SubscriptionEntities db , Expression<Func<Company_ContactType, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<Company_ContactType, dynamic> orderExpression = null);
 Company_ContactType GetCompany_ContactTypeWithDetails(long idCompany_ContactType, List<string> includes = null,bool shouldRemap = false);
 Company_ContactType GetCompany_ContactTypeWithDetails(long idCompany_ContactType, SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 Company_ContactType GetCompany_ContactTypeWitDetails(long idCompany_ContactType,bool shouldRemap = false);
 Company_ContactType GetCompany_ContactTypeWitDetails(long idCompany_ContactType, SubscriptionEntities db,bool shouldRemap = false);
 void SaveCompany_ContactType(Company_ContactType company_ContactType);
 void SaveCompany_ContactType(Company_ContactType company_ContactType, SubscriptionEntities db);
 void SaveOnlyCompany_ContactType(Company_ContactType company_ContactType);
 void SaveOnlyCompany_ContactType(Company_ContactType company_ContactType, SubscriptionEntities db);
 void DeleteCompany_ContactType(Company_ContactType company_ContactType);
 void DeleteCompany_ContactType(Company_ContactType company_ContactType, SubscriptionEntities db);		
  void DeletePermanentlyCompany_ContactType(Company_ContactType company_ContactType);
 void DeletePermanentlyCompany_ContactType(Company_ContactType company_ContactType, SubscriptionEntities db);	
	}
 	public partial interface ICompanyLocationDao
	{
  List<CompanyLocation> GetAllCompanyLocations(bool shouldRemap = false);
  List<CompanyLocation> GetAllCompanyLocations(SubscriptionEntities db,bool shouldRemap = false);
  BaseListReturnType<CompanyLocation> GetAllCompanyLocationsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<CompanyLocation, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<CompanyLocation, dynamic> orderExpression = null);
  BaseListReturnType<CompanyLocation> GetAllCompanyLocationsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<CompanyLocation, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<CompanyLocation, dynamic> orderExpression = null);
  
  BaseListReturnType<CompanyLocation> GetAllCompanyLocationsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<CompanyLocation, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<CompanyLocation, dynamic> orderExpression = null);
  BaseListReturnType<CompanyLocation> GetAllCompanyLocationsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<CompanyLocation, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<CompanyLocation, dynamic> orderExpression = null);

 BaseListReturnType<CompanyLocation> GetAllCompanyLocationsWithCompanyDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<CompanyLocation, bool>> expression = null,bool shouldRemap = false, Func<CompanyLocation, dynamic> orderExpression = null);
 BaseListReturnType<CompanyLocation> GetAllCompanyLocationsWithCompanyDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<CompanyLocation, bool>> expression = null,bool shouldRemap = false, Func<CompanyLocation, dynamic> orderExpression = null);






BaseListReturnType<CompanyLocation> GetAllCompanyLocationListByCompany(long idCompany);

BaseListReturnType<CompanyLocation> GetAllCompanyLocationListByCompany(long idCompany, SubscriptionEntities db);

BaseListReturnType<CompanyLocation> GetAllCompanyLocationListByCompanyByPage(long idCompany, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<CompanyLocation> GetAllCompanyLocationListByCompanyByPage(long idCompany, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);



 BaseListReturnType<CompanyLocation> GetAllCompanyLocationsWithAddressDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<CompanyLocation, bool>> expression = null,bool shouldRemap = false, Func<CompanyLocation, dynamic> orderExpression = null);
 BaseListReturnType<CompanyLocation> GetAllCompanyLocationsWithAddressDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<CompanyLocation, bool>> expression = null,bool shouldRemap = false, Func<CompanyLocation, dynamic> orderExpression = null);






BaseListReturnType<CompanyLocation> GetAllCompanyLocationListByAddress(long idAddress);

BaseListReturnType<CompanyLocation> GetAllCompanyLocationListByAddress(long idAddress, SubscriptionEntities db);

BaseListReturnType<CompanyLocation> GetAllCompanyLocationListByAddressByPage(long idAddress, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<CompanyLocation> GetAllCompanyLocationListByAddressByPage(long idAddress, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);




List<CompanyLocation> GetCompanyLocationListByIdList(List<long> companyLocationIds);

List<CompanyLocation> GetCompanyLocationListByIdList(List<long> companyLocationIds, SubscriptionEntities db);

 BaseListReturnType<CompanyLocation> GetAllCompanyLocationsWithCompanyDetails(bool shouldRemap = false);
 BaseListReturnType<CompanyLocation> GetAllCompanyLocationsWithAddressDetails(bool shouldRemap = false);
 BaseListReturnType<CompanyLocation> GetAllCompanyLocationWitDetails( List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<CompanyLocation> GetAllCompanyLocationWitDetails( SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 CompanyLocation GetCompanyLocation(long idCompanyLocation,bool shouldRemap = false);
 CompanyLocation GetCompanyLocation(long idCompanyLocation, SubscriptionEntities db,bool shouldRemap = false);
 CompanyLocation GetCompanyLocationWithCompanyDetails(long idCompanyLocation,bool shouldRemap = false);
    


 CompanyLocation GetCompanyLocationWithAddressDetails(long idCompanyLocation,bool shouldRemap = false);
    


 CompanyLocation GetCompanyLocationCustom( Expression<Func<CompanyLocation, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 CompanyLocation GetCompanyLocationCustom(SubscriptionEntities db, Expression<Func<CompanyLocation, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<CompanyLocation> GetCompanyLocationCustomList( Expression<Func<CompanyLocation, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<CompanyLocation, dynamic> orderExpression = null);
 BaseListReturnType<CompanyLocation> GetCompanyLocationCustomList( SubscriptionEntities db , Expression<Func<CompanyLocation, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<CompanyLocation, dynamic> orderExpression = null);
 CompanyLocation GetCompanyLocationWithDetails(long idCompanyLocation, List<string> includes = null,bool shouldRemap = false);
 CompanyLocation GetCompanyLocationWithDetails(long idCompanyLocation, SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 CompanyLocation GetCompanyLocationWitDetails(long idCompanyLocation,bool shouldRemap = false);
 CompanyLocation GetCompanyLocationWitDetails(long idCompanyLocation, SubscriptionEntities db,bool shouldRemap = false);
 void SaveCompanyLocation(CompanyLocation companyLocation);
 void SaveCompanyLocation(CompanyLocation companyLocation, SubscriptionEntities db);
 void SaveOnlyCompanyLocation(CompanyLocation companyLocation);
 void SaveOnlyCompanyLocation(CompanyLocation companyLocation, SubscriptionEntities db);
 void DeleteCompanyLocation(CompanyLocation companyLocation);
 void DeleteCompanyLocation(CompanyLocation companyLocation, SubscriptionEntities db);		
  void DeletePermanentlyCompanyLocation(CompanyLocation companyLocation);
 void DeletePermanentlyCompanyLocation(CompanyLocation companyLocation, SubscriptionEntities db);	
	}
 	public partial interface IConceptDao
	{
  List<Concept> GetAllConcepts(bool shouldRemap = false);
  List<Concept> GetAllConcepts(SubscriptionEntities db,bool shouldRemap = false);
  BaseListReturnType<Concept> GetAllConceptsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Concept, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<Concept, dynamic> orderExpression = null);
  BaseListReturnType<Concept> GetAllConceptsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<Concept, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<Concept, dynamic> orderExpression = null);
  
  BaseListReturnType<Concept> GetAllConceptsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Concept, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<Concept, dynamic> orderExpression = null);
  BaseListReturnType<Concept> GetAllConceptsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<Concept, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<Concept, dynamic> orderExpression = null);

 BaseListReturnType<Concept> GetAllConceptsWithCompaniesDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Concept, bool>> expression = null,bool shouldRemap = false, Func<Concept, dynamic> orderExpression = null);
 BaseListReturnType<Concept> GetAllConceptsWithCompaniesDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Concept, bool>> expression = null,bool shouldRemap = false, Func<Concept, dynamic> orderExpression = null);

 BaseListReturnType<Concept> GetAllConceptsWithCompanyDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Concept, bool>> expression = null,bool shouldRemap = false, Func<Concept, dynamic> orderExpression = null);
 BaseListReturnType<Concept> GetAllConceptsWithCompanyDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Concept, bool>> expression = null,bool shouldRemap = false, Func<Concept, dynamic> orderExpression = null);






BaseListReturnType<Concept> GetAllConceptListByCompany(long idCompany);

BaseListReturnType<Concept> GetAllConceptListByCompany(long idCompany, SubscriptionEntities db);

BaseListReturnType<Concept> GetAllConceptListByCompanyByPage(long idCompany, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<Concept> GetAllConceptListByCompanyByPage(long idCompany, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);



 BaseListReturnType<Concept> GetAllConceptsWithConcept_AddressDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Concept, bool>> expression = null,bool shouldRemap = false, Func<Concept, dynamic> orderExpression = null);
 BaseListReturnType<Concept> GetAllConceptsWithConcept_AddressDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Concept, bool>> expression = null,bool shouldRemap = false, Func<Concept, dynamic> orderExpression = null);

 BaseListReturnType<Concept> GetAllConceptsWithConcept_ContactTypeDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Concept, bool>> expression = null,bool shouldRemap = false, Func<Concept, dynamic> orderExpression = null);
 BaseListReturnType<Concept> GetAllConceptsWithConcept_ContactTypeDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Concept, bool>> expression = null,bool shouldRemap = false, Func<Concept, dynamic> orderExpression = null);

 BaseListReturnType<Concept> GetAllConceptsWithConcept1DetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Concept, bool>> expression = null,bool shouldRemap = false, Func<Concept, dynamic> orderExpression = null);
 BaseListReturnType<Concept> GetAllConceptsWithConcept1DetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Concept, bool>> expression = null,bool shouldRemap = false, Func<Concept, dynamic> orderExpression = null);






BaseListReturnType<Concept> GetAllConceptListByConcept1(long idConcept1);

BaseListReturnType<Concept> GetAllConceptListByConcept1(long idConcept1, SubscriptionEntities db);

BaseListReturnType<Concept> GetAllConceptListByConcept1ByPage(long idConcept1, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<Concept> GetAllConceptListByConcept1ByPage(long idConcept1, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);



 BaseListReturnType<Concept> GetAllConceptsWithConcept2DetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Concept, bool>> expression = null,bool shouldRemap = false, Func<Concept, dynamic> orderExpression = null);
 BaseListReturnType<Concept> GetAllConceptsWithConcept2DetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Concept, bool>> expression = null,bool shouldRemap = false, Func<Concept, dynamic> orderExpression = null);

 BaseListReturnType<Concept> GetAllConceptsWithPersonDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Concept, bool>> expression = null,bool shouldRemap = false, Func<Concept, dynamic> orderExpression = null);
 BaseListReturnType<Concept> GetAllConceptsWithPersonDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Concept, bool>> expression = null,bool shouldRemap = false, Func<Concept, dynamic> orderExpression = null);






BaseListReturnType<Concept> GetAllConceptListByPerson(long idPerson);

BaseListReturnType<Concept> GetAllConceptListByPerson(long idPerson, SubscriptionEntities db);

BaseListReturnType<Concept> GetAllConceptListByPersonByPage(long idPerson, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<Concept> GetAllConceptListByPersonByPage(long idPerson, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);



 BaseListReturnType<Concept> GetAllConceptsWithCustomersDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Concept, bool>> expression = null,bool shouldRemap = false, Func<Concept, dynamic> orderExpression = null);
 BaseListReturnType<Concept> GetAllConceptsWithCustomersDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Concept, bool>> expression = null,bool shouldRemap = false, Func<Concept, dynamic> orderExpression = null);


List<Concept> GetConceptListByIdList(List<long> conceptIds);

List<Concept> GetConceptListByIdList(List<long> conceptIds, SubscriptionEntities db);

 BaseListReturnType<Concept> GetAllConceptsWithCompaniesDetails(bool shouldRemap = false);
 BaseListReturnType<Concept> GetAllConceptsWithCompanyDetails(bool shouldRemap = false);
 BaseListReturnType<Concept> GetAllConceptsWithConcept_AddressDetails(bool shouldRemap = false);
 BaseListReturnType<Concept> GetAllConceptsWithConcept_ContactTypeDetails(bool shouldRemap = false);
 BaseListReturnType<Concept> GetAllConceptsWithConcept1Details(bool shouldRemap = false);
 BaseListReturnType<Concept> GetAllConceptsWithConcept2Details(bool shouldRemap = false);
 BaseListReturnType<Concept> GetAllConceptsWithPersonDetails(bool shouldRemap = false);
 BaseListReturnType<Concept> GetAllConceptsWithCustomersDetails(bool shouldRemap = false);
 BaseListReturnType<Concept> GetAllConceptWitDetails( List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<Concept> GetAllConceptWitDetails( SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 Concept GetConcept(long idConcept,bool shouldRemap = false);
 Concept GetConcept(long idConcept, SubscriptionEntities db,bool shouldRemap = false);
 Concept GetConceptWithCompaniesDetails(long idConcept,bool shouldRemap = false);
           List<Company> UpdateCompaniesForConceptWithoutSavingNewItem(List<Company> newCompanies,long idConcept);
    List<Company> UpdateCompaniesForConceptWithoutSavingNewItem(List<Company> newCompanies,long idConcept,SubscriptionEntities db);
          

    List<Company> UpdateCompaniesForConcept(List<Company> newCompanies,long idConcept);
    List<Company> UpdateCompaniesForConcept(List<Company> newCompanies,long idConcept,SubscriptionEntities db);
                           



 Concept GetConceptWithCompanyDetails(long idConcept,bool shouldRemap = false);
    


 Concept GetConceptWithConcept_AddressDetails(long idConcept,bool shouldRemap = false);
           List<Concept_Address> UpdateConcept_AddressForConceptWithoutSavingNewItem(List<Concept_Address> newConcept_Address,long idConcept);
    List<Concept_Address> UpdateConcept_AddressForConceptWithoutSavingNewItem(List<Concept_Address> newConcept_Address,long idConcept,SubscriptionEntities db);
          

    List<Concept_Address> UpdateConcept_AddressForConcept(List<Concept_Address> newConcept_Address,long idConcept);
    List<Concept_Address> UpdateConcept_AddressForConcept(List<Concept_Address> newConcept_Address,long idConcept,SubscriptionEntities db);
                           



 Concept GetConceptWithConcept_ContactTypeDetails(long idConcept,bool shouldRemap = false);
           List<Concept_ContactType> UpdateConcept_ContactTypeForConceptWithoutSavingNewItem(List<Concept_ContactType> newConcept_ContactType,long idConcept);
    List<Concept_ContactType> UpdateConcept_ContactTypeForConceptWithoutSavingNewItem(List<Concept_ContactType> newConcept_ContactType,long idConcept,SubscriptionEntities db);
          

    List<Concept_ContactType> UpdateConcept_ContactTypeForConcept(List<Concept_ContactType> newConcept_ContactType,long idConcept);
    List<Concept_ContactType> UpdateConcept_ContactTypeForConcept(List<Concept_ContactType> newConcept_ContactType,long idConcept,SubscriptionEntities db);
                           



 Concept GetConceptWithConcept1Details(long idConcept,bool shouldRemap = false);
    


 Concept GetConceptWithConcept2Details(long idConcept,bool shouldRemap = false);
    


 Concept GetConceptWithPersonDetails(long idConcept,bool shouldRemap = false);
    


 Concept GetConceptWithCustomersDetails(long idConcept,bool shouldRemap = false);
           List<Customer> UpdateCustomersForConceptWithoutSavingNewItem(List<Customer> newCustomers,long idConcept);
    List<Customer> UpdateCustomersForConceptWithoutSavingNewItem(List<Customer> newCustomers,long idConcept,SubscriptionEntities db);
          

    List<Customer> UpdateCustomersForConcept(List<Customer> newCustomers,long idConcept);
    List<Customer> UpdateCustomersForConcept(List<Customer> newCustomers,long idConcept,SubscriptionEntities db);
                           



 Concept GetConceptCustom( Expression<Func<Concept, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 Concept GetConceptCustom(SubscriptionEntities db, Expression<Func<Concept, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<Concept> GetConceptCustomList( Expression<Func<Concept, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<Concept, dynamic> orderExpression = null);
 BaseListReturnType<Concept> GetConceptCustomList( SubscriptionEntities db , Expression<Func<Concept, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<Concept, dynamic> orderExpression = null);
 Concept GetConceptWithDetails(long idConcept, List<string> includes = null,bool shouldRemap = false);
 Concept GetConceptWithDetails(long idConcept, SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 Concept GetConceptWitDetails(long idConcept,bool shouldRemap = false);
 Concept GetConceptWitDetails(long idConcept, SubscriptionEntities db,bool shouldRemap = false);
 void SaveConcept(Concept concept);
 void SaveConcept(Concept concept, SubscriptionEntities db);
 void SaveOnlyConcept(Concept concept);
 void SaveOnlyConcept(Concept concept, SubscriptionEntities db);
 void DeleteConcept(Concept concept);
 void DeleteConcept(Concept concept, SubscriptionEntities db);		
  void DeletePermanentlyConcept(Concept concept);
 void DeletePermanentlyConcept(Concept concept, SubscriptionEntities db);	
	}
 	public partial interface IConcept_AddressDao
	{
  List<Concept_Address> GetAllConcept_Address(bool shouldRemap = false);
  List<Concept_Address> GetAllConcept_Address(SubscriptionEntities db,bool shouldRemap = false);
  BaseListReturnType<Concept_Address> GetAllConcept_AddressByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Concept_Address, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<Concept_Address, dynamic> orderExpression = null);
  BaseListReturnType<Concept_Address> GetAllConcept_AddressByPage(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<Concept_Address, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<Concept_Address, dynamic> orderExpression = null);
  
  BaseListReturnType<Concept_Address> GetAllConcept_AddressByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Concept_Address, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<Concept_Address, dynamic> orderExpression = null);
  BaseListReturnType<Concept_Address> GetAllConcept_AddressByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<Concept_Address, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<Concept_Address, dynamic> orderExpression = null);

 BaseListReturnType<Concept_Address> GetAllConcept_AddressWithConceptDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Concept_Address, bool>> expression = null,bool shouldRemap = false, Func<Concept_Address, dynamic> orderExpression = null);
 BaseListReturnType<Concept_Address> GetAllConcept_AddressWithConceptDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Concept_Address, bool>> expression = null,bool shouldRemap = false, Func<Concept_Address, dynamic> orderExpression = null);






BaseListReturnType<Concept_Address> GetAllConcept_AddressListByConcept(long idConcept);

BaseListReturnType<Concept_Address> GetAllConcept_AddressListByConcept(long idConcept, SubscriptionEntities db);

BaseListReturnType<Concept_Address> GetAllConcept_AddressListByConceptByPage(long idConcept, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<Concept_Address> GetAllConcept_AddressListByConceptByPage(long idConcept, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);




List<Concept_Address> GetConcept_AddressListByIdList(List<long> concept_AddressIds);

List<Concept_Address> GetConcept_AddressListByIdList(List<long> concept_AddressIds, SubscriptionEntities db);

 BaseListReturnType<Concept_Address> GetAllConcept_AddressWithConceptDetails(bool shouldRemap = false);
 BaseListReturnType<Concept_Address> GetAllConcept_AddressWitDetails( List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<Concept_Address> GetAllConcept_AddressWitDetails( SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 Concept_Address GetConcept_Address(long idConcept_Address,bool shouldRemap = false);
 Concept_Address GetConcept_Address(long idConcept_Address, SubscriptionEntities db,bool shouldRemap = false);
 Concept_Address GetConcept_AddressWithConceptDetails(long idConcept_Address,bool shouldRemap = false);
    


 Concept_Address GetConcept_AddressCustom( Expression<Func<Concept_Address, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 Concept_Address GetConcept_AddressCustom(SubscriptionEntities db, Expression<Func<Concept_Address, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<Concept_Address> GetConcept_AddressCustomList( Expression<Func<Concept_Address, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<Concept_Address, dynamic> orderExpression = null);
 BaseListReturnType<Concept_Address> GetConcept_AddressCustomList( SubscriptionEntities db , Expression<Func<Concept_Address, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<Concept_Address, dynamic> orderExpression = null);
 Concept_Address GetConcept_AddressWithDetails(long idConcept_Address, List<string> includes = null,bool shouldRemap = false);
 Concept_Address GetConcept_AddressWithDetails(long idConcept_Address, SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 Concept_Address GetConcept_AddressWitDetails(long idConcept_Address,bool shouldRemap = false);
 Concept_Address GetConcept_AddressWitDetails(long idConcept_Address, SubscriptionEntities db,bool shouldRemap = false);
 void SaveConcept_Address(Concept_Address concept_Address);
 void SaveConcept_Address(Concept_Address concept_Address, SubscriptionEntities db);
 void SaveOnlyConcept_Address(Concept_Address concept_Address);
 void SaveOnlyConcept_Address(Concept_Address concept_Address, SubscriptionEntities db);
 void DeleteConcept_Address(Concept_Address concept_Address);
 void DeleteConcept_Address(Concept_Address concept_Address, SubscriptionEntities db);		
  void DeletePermanentlyConcept_Address(Concept_Address concept_Address);
 void DeletePermanentlyConcept_Address(Concept_Address concept_Address, SubscriptionEntities db);	
	}
 	public partial interface IConcept_ContactTypeDao
	{
  List<Concept_ContactType> GetAllConcept_ContactType(bool shouldRemap = false);
  List<Concept_ContactType> GetAllConcept_ContactType(SubscriptionEntities db,bool shouldRemap = false);
  BaseListReturnType<Concept_ContactType> GetAllConcept_ContactTypeByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Concept_ContactType, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<Concept_ContactType, dynamic> orderExpression = null);
  BaseListReturnType<Concept_ContactType> GetAllConcept_ContactTypeByPage(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<Concept_ContactType, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<Concept_ContactType, dynamic> orderExpression = null);
  
  BaseListReturnType<Concept_ContactType> GetAllConcept_ContactTypeByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Concept_ContactType, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<Concept_ContactType, dynamic> orderExpression = null);
  BaseListReturnType<Concept_ContactType> GetAllConcept_ContactTypeByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<Concept_ContactType, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<Concept_ContactType, dynamic> orderExpression = null);

 BaseListReturnType<Concept_ContactType> GetAllConcept_ContactTypeWithContactTypeDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Concept_ContactType, bool>> expression = null,bool shouldRemap = false, Func<Concept_ContactType, dynamic> orderExpression = null);
 BaseListReturnType<Concept_ContactType> GetAllConcept_ContactTypeWithContactTypeDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Concept_ContactType, bool>> expression = null,bool shouldRemap = false, Func<Concept_ContactType, dynamic> orderExpression = null);






BaseListReturnType<Concept_ContactType> GetAllConcept_ContactTypeListByContactType(long idContactType);

BaseListReturnType<Concept_ContactType> GetAllConcept_ContactTypeListByContactType(long idContactType, SubscriptionEntities db);

BaseListReturnType<Concept_ContactType> GetAllConcept_ContactTypeListByContactTypeByPage(long idContactType, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<Concept_ContactType> GetAllConcept_ContactTypeListByContactTypeByPage(long idContactType, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);



 BaseListReturnType<Concept_ContactType> GetAllConcept_ContactTypeWithConceptDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Concept_ContactType, bool>> expression = null,bool shouldRemap = false, Func<Concept_ContactType, dynamic> orderExpression = null);
 BaseListReturnType<Concept_ContactType> GetAllConcept_ContactTypeWithConceptDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Concept_ContactType, bool>> expression = null,bool shouldRemap = false, Func<Concept_ContactType, dynamic> orderExpression = null);






BaseListReturnType<Concept_ContactType> GetAllConcept_ContactTypeListByConcept(long idConcept);

BaseListReturnType<Concept_ContactType> GetAllConcept_ContactTypeListByConcept(long idConcept, SubscriptionEntities db);

BaseListReturnType<Concept_ContactType> GetAllConcept_ContactTypeListByConceptByPage(long idConcept, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<Concept_ContactType> GetAllConcept_ContactTypeListByConceptByPage(long idConcept, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);




List<Concept_ContactType> GetConcept_ContactTypeListByIdList(List<long> concept_ContactTypeIds);

List<Concept_ContactType> GetConcept_ContactTypeListByIdList(List<long> concept_ContactTypeIds, SubscriptionEntities db);

 BaseListReturnType<Concept_ContactType> GetAllConcept_ContactTypeWithContactTypeDetails(bool shouldRemap = false);
 BaseListReturnType<Concept_ContactType> GetAllConcept_ContactTypeWithConceptDetails(bool shouldRemap = false);
 BaseListReturnType<Concept_ContactType> GetAllConcept_ContactTypeWitDetails( List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<Concept_ContactType> GetAllConcept_ContactTypeWitDetails( SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 Concept_ContactType GetConcept_ContactType(long idConcept_ContactType,bool shouldRemap = false);
 Concept_ContactType GetConcept_ContactType(long idConcept_ContactType, SubscriptionEntities db,bool shouldRemap = false);
 Concept_ContactType GetConcept_ContactTypeWithContactTypeDetails(long idConcept_ContactType,bool shouldRemap = false);
    


 Concept_ContactType GetConcept_ContactTypeWithConceptDetails(long idConcept_ContactType,bool shouldRemap = false);
    


 Concept_ContactType GetConcept_ContactTypeCustom( Expression<Func<Concept_ContactType, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 Concept_ContactType GetConcept_ContactTypeCustom(SubscriptionEntities db, Expression<Func<Concept_ContactType, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<Concept_ContactType> GetConcept_ContactTypeCustomList( Expression<Func<Concept_ContactType, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<Concept_ContactType, dynamic> orderExpression = null);
 BaseListReturnType<Concept_ContactType> GetConcept_ContactTypeCustomList( SubscriptionEntities db , Expression<Func<Concept_ContactType, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<Concept_ContactType, dynamic> orderExpression = null);
 Concept_ContactType GetConcept_ContactTypeWithDetails(long idConcept_ContactType, List<string> includes = null,bool shouldRemap = false);
 Concept_ContactType GetConcept_ContactTypeWithDetails(long idConcept_ContactType, SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 Concept_ContactType GetConcept_ContactTypeWitDetails(long idConcept_ContactType,bool shouldRemap = false);
 Concept_ContactType GetConcept_ContactTypeWitDetails(long idConcept_ContactType, SubscriptionEntities db,bool shouldRemap = false);
 void SaveConcept_ContactType(Concept_ContactType concept_ContactType);
 void SaveConcept_ContactType(Concept_ContactType concept_ContactType, SubscriptionEntities db);
 void SaveOnlyConcept_ContactType(Concept_ContactType concept_ContactType);
 void SaveOnlyConcept_ContactType(Concept_ContactType concept_ContactType, SubscriptionEntities db);
 void DeleteConcept_ContactType(Concept_ContactType concept_ContactType);
 void DeleteConcept_ContactType(Concept_ContactType concept_ContactType, SubscriptionEntities db);		
  void DeletePermanentlyConcept_ContactType(Concept_ContactType concept_ContactType);
 void DeletePermanentlyConcept_ContactType(Concept_ContactType concept_ContactType, SubscriptionEntities db);	
	}
 	public partial interface IContactDao
	{
  List<Contact> GetAllContacts(bool shouldRemap = false);
  List<Contact> GetAllContacts(SubscriptionEntities db,bool shouldRemap = false);
  BaseListReturnType<Contact> GetAllContactsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Contact, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<Contact, dynamic> orderExpression = null);
  BaseListReturnType<Contact> GetAllContactsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<Contact, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<Contact, dynamic> orderExpression = null);
  
  BaseListReturnType<Contact> GetAllContactsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Contact, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<Contact, dynamic> orderExpression = null);
  BaseListReturnType<Contact> GetAllContactsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<Contact, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<Contact, dynamic> orderExpression = null);

 BaseListReturnType<Contact> GetAllContactsWithAddressDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Contact, bool>> expression = null,bool shouldRemap = false, Func<Contact, dynamic> orderExpression = null);
 BaseListReturnType<Contact> GetAllContactsWithAddressDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Contact, bool>> expression = null,bool shouldRemap = false, Func<Contact, dynamic> orderExpression = null);






BaseListReturnType<Contact> GetAllContactListByAddress(long idAddress);

BaseListReturnType<Contact> GetAllContactListByAddress(long idAddress, SubscriptionEntities db);

BaseListReturnType<Contact> GetAllContactListByAddressByPage(long idAddress, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<Contact> GetAllContactListByAddressByPage(long idAddress, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);




List<Contact> GetContactListByIdList(List<long> contactIds);

List<Contact> GetContactListByIdList(List<long> contactIds, SubscriptionEntities db);

 BaseListReturnType<Contact> GetAllContactsWithAddressDetails(bool shouldRemap = false);
 BaseListReturnType<Contact> GetAllContactWitDetails( List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<Contact> GetAllContactWitDetails( SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 Contact GetContact(long idContact,bool shouldRemap = false);
 Contact GetContact(long idContact, SubscriptionEntities db,bool shouldRemap = false);
 Contact GetContactWithAddressDetails(long idContact,bool shouldRemap = false);
    


 Contact GetContactCustom( Expression<Func<Contact, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 Contact GetContactCustom(SubscriptionEntities db, Expression<Func<Contact, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<Contact> GetContactCustomList( Expression<Func<Contact, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<Contact, dynamic> orderExpression = null);
 BaseListReturnType<Contact> GetContactCustomList( SubscriptionEntities db , Expression<Func<Contact, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<Contact, dynamic> orderExpression = null);
 Contact GetContactWithDetails(long idContact, List<string> includes = null,bool shouldRemap = false);
 Contact GetContactWithDetails(long idContact, SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 Contact GetContactWitDetails(long idContact,bool shouldRemap = false);
 Contact GetContactWitDetails(long idContact, SubscriptionEntities db,bool shouldRemap = false);
 void SaveContact(Contact contact);
 void SaveContact(Contact contact, SubscriptionEntities db);
 void SaveOnlyContact(Contact contact);
 void SaveOnlyContact(Contact contact, SubscriptionEntities db);
 void DeleteContact(Contact contact);
 void DeleteContact(Contact contact, SubscriptionEntities db);		
  void DeletePermanentlyContact(Contact contact);
 void DeletePermanentlyContact(Contact contact, SubscriptionEntities db);	
	}
 	public partial interface IContactTypeDao
	{
  List<ContactType> GetAllContactTypes(bool shouldRemap = false);
  List<ContactType> GetAllContactTypes(SubscriptionEntities db,bool shouldRemap = false);
  BaseListReturnType<ContactType> GetAllContactTypesByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<ContactType, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<ContactType, dynamic> orderExpression = null);
  BaseListReturnType<ContactType> GetAllContactTypesByPage(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<ContactType, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<ContactType, dynamic> orderExpression = null);
  
  BaseListReturnType<ContactType> GetAllContactTypesByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<ContactType, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<ContactType, dynamic> orderExpression = null);
  BaseListReturnType<ContactType> GetAllContactTypesByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<ContactType, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<ContactType, dynamic> orderExpression = null);

 BaseListReturnType<ContactType> GetAllContactTypesWithCompany_ContactTypeDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<ContactType, bool>> expression = null,bool shouldRemap = false, Func<ContactType, dynamic> orderExpression = null);
 BaseListReturnType<ContactType> GetAllContactTypesWithCompany_ContactTypeDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<ContactType, bool>> expression = null,bool shouldRemap = false, Func<ContactType, dynamic> orderExpression = null);

 BaseListReturnType<ContactType> GetAllContactTypesWithConcept_ContactTypeDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<ContactType, bool>> expression = null,bool shouldRemap = false, Func<ContactType, dynamic> orderExpression = null);
 BaseListReturnType<ContactType> GetAllContactTypesWithConcept_ContactTypeDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<ContactType, bool>> expression = null,bool shouldRemap = false, Func<ContactType, dynamic> orderExpression = null);

 BaseListReturnType<ContactType> GetAllContactTypesWithContactType1DetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<ContactType, bool>> expression = null,bool shouldRemap = false, Func<ContactType, dynamic> orderExpression = null);
 BaseListReturnType<ContactType> GetAllContactTypesWithContactType1DetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<ContactType, bool>> expression = null,bool shouldRemap = false, Func<ContactType, dynamic> orderExpression = null);

 BaseListReturnType<ContactType> GetAllContactTypesWithContactType2DetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<ContactType, bool>> expression = null,bool shouldRemap = false, Func<ContactType, dynamic> orderExpression = null);
 BaseListReturnType<ContactType> GetAllContactTypesWithContactType2DetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<ContactType, bool>> expression = null,bool shouldRemap = false, Func<ContactType, dynamic> orderExpression = null);






BaseListReturnType<ContactType> GetAllContactTypeListByContactType2(long idContactType2);

BaseListReturnType<ContactType> GetAllContactTypeListByContactType2(long idContactType2, SubscriptionEntities db);

BaseListReturnType<ContactType> GetAllContactTypeListByContactType2ByPage(long idContactType2, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<ContactType> GetAllContactTypeListByContactType2ByPage(long idContactType2, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);



 BaseListReturnType<ContactType> GetAllContactTypesWithOrderConcept_ContactTypeDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<ContactType, bool>> expression = null,bool shouldRemap = false, Func<ContactType, dynamic> orderExpression = null);
 BaseListReturnType<ContactType> GetAllContactTypesWithOrderConcept_ContactTypeDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<ContactType, bool>> expression = null,bool shouldRemap = false, Func<ContactType, dynamic> orderExpression = null);

 BaseListReturnType<ContactType> GetAllContactTypesWithPerson_ContactTypeDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<ContactType, bool>> expression = null,bool shouldRemap = false, Func<ContactType, dynamic> orderExpression = null);
 BaseListReturnType<ContactType> GetAllContactTypesWithPerson_ContactTypeDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<ContactType, bool>> expression = null,bool shouldRemap = false, Func<ContactType, dynamic> orderExpression = null);


List<ContactType> GetContactTypeListByIdList(List<long> contactTypeIds);

List<ContactType> GetContactTypeListByIdList(List<long> contactTypeIds, SubscriptionEntities db);

 BaseListReturnType<ContactType> GetAllContactTypesWithCompany_ContactTypeDetails(bool shouldRemap = false);
 BaseListReturnType<ContactType> GetAllContactTypesWithConcept_ContactTypeDetails(bool shouldRemap = false);
 BaseListReturnType<ContactType> GetAllContactTypesWithContactType1Details(bool shouldRemap = false);
 BaseListReturnType<ContactType> GetAllContactTypesWithContactType2Details(bool shouldRemap = false);
 BaseListReturnType<ContactType> GetAllContactTypesWithOrderConcept_ContactTypeDetails(bool shouldRemap = false);
 BaseListReturnType<ContactType> GetAllContactTypesWithPerson_ContactTypeDetails(bool shouldRemap = false);
 BaseListReturnType<ContactType> GetAllContactTypeWitDetails( List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<ContactType> GetAllContactTypeWitDetails( SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 ContactType GetContactType(long idContactType,bool shouldRemap = false);
 ContactType GetContactType(long idContactType, SubscriptionEntities db,bool shouldRemap = false);
 ContactType GetContactTypeWithCompany_ContactTypeDetails(long idContactType,bool shouldRemap = false);
           List<Company_ContactType> UpdateCompany_ContactTypeForContactTypeWithoutSavingNewItem(List<Company_ContactType> newCompany_ContactType,long idContactType);
    List<Company_ContactType> UpdateCompany_ContactTypeForContactTypeWithoutSavingNewItem(List<Company_ContactType> newCompany_ContactType,long idContactType,SubscriptionEntities db);
          

    List<Company_ContactType> UpdateCompany_ContactTypeForContactType(List<Company_ContactType> newCompany_ContactType,long idContactType);
    List<Company_ContactType> UpdateCompany_ContactTypeForContactType(List<Company_ContactType> newCompany_ContactType,long idContactType,SubscriptionEntities db);
                           



 ContactType GetContactTypeWithConcept_ContactTypeDetails(long idContactType,bool shouldRemap = false);
           List<Concept_ContactType> UpdateConcept_ContactTypeForContactTypeWithoutSavingNewItem(List<Concept_ContactType> newConcept_ContactType,long idContactType);
    List<Concept_ContactType> UpdateConcept_ContactTypeForContactTypeWithoutSavingNewItem(List<Concept_ContactType> newConcept_ContactType,long idContactType,SubscriptionEntities db);
          

    List<Concept_ContactType> UpdateConcept_ContactTypeForContactType(List<Concept_ContactType> newConcept_ContactType,long idContactType);
    List<Concept_ContactType> UpdateConcept_ContactTypeForContactType(List<Concept_ContactType> newConcept_ContactType,long idContactType,SubscriptionEntities db);
                           



 ContactType GetContactTypeWithContactType1Details(long idContactType,bool shouldRemap = false);
           List<ContactType> UpdateContactType1ForContactTypeWithoutSavingNewItem(List<ContactType> newContactType1,long idContactType);
    List<ContactType> UpdateContactType1ForContactTypeWithoutSavingNewItem(List<ContactType> newContactType1,long idContactType,SubscriptionEntities db);
          

    List<ContactType> UpdateContactType1ForContactType(List<ContactType> newContactType1,long idContactType);
    List<ContactType> UpdateContactType1ForContactType(List<ContactType> newContactType1,long idContactType,SubscriptionEntities db);
                           



 ContactType GetContactTypeWithContactType2Details(long idContactType,bool shouldRemap = false);
    


 ContactType GetContactTypeWithOrderConcept_ContactTypeDetails(long idContactType,bool shouldRemap = false);
           List<OrderConcept_ContactType> UpdateOrderConcept_ContactTypeForContactTypeWithoutSavingNewItem(List<OrderConcept_ContactType> newOrderConcept_ContactType,long idContactType);
    List<OrderConcept_ContactType> UpdateOrderConcept_ContactTypeForContactTypeWithoutSavingNewItem(List<OrderConcept_ContactType> newOrderConcept_ContactType,long idContactType,SubscriptionEntities db);
          

    List<OrderConcept_ContactType> UpdateOrderConcept_ContactTypeForContactType(List<OrderConcept_ContactType> newOrderConcept_ContactType,long idContactType);
    List<OrderConcept_ContactType> UpdateOrderConcept_ContactTypeForContactType(List<OrderConcept_ContactType> newOrderConcept_ContactType,long idContactType,SubscriptionEntities db);
                           



 ContactType GetContactTypeWithPerson_ContactTypeDetails(long idContactType,bool shouldRemap = false);
           List<Person_ContactType> UpdatePerson_ContactTypeForContactTypeWithoutSavingNewItem(List<Person_ContactType> newPerson_ContactType,long idContactType);
    List<Person_ContactType> UpdatePerson_ContactTypeForContactTypeWithoutSavingNewItem(List<Person_ContactType> newPerson_ContactType,long idContactType,SubscriptionEntities db);
          

    List<Person_ContactType> UpdatePerson_ContactTypeForContactType(List<Person_ContactType> newPerson_ContactType,long idContactType);
    List<Person_ContactType> UpdatePerson_ContactTypeForContactType(List<Person_ContactType> newPerson_ContactType,long idContactType,SubscriptionEntities db);
                           



 ContactType GetContactTypeCustom( Expression<Func<ContactType, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 ContactType GetContactTypeCustom(SubscriptionEntities db, Expression<Func<ContactType, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<ContactType> GetContactTypeCustomList( Expression<Func<ContactType, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<ContactType, dynamic> orderExpression = null);
 BaseListReturnType<ContactType> GetContactTypeCustomList( SubscriptionEntities db , Expression<Func<ContactType, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<ContactType, dynamic> orderExpression = null);
 ContactType GetContactTypeWithDetails(long idContactType, List<string> includes = null,bool shouldRemap = false);
 ContactType GetContactTypeWithDetails(long idContactType, SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 ContactType GetContactTypeWitDetails(long idContactType,bool shouldRemap = false);
 ContactType GetContactTypeWitDetails(long idContactType, SubscriptionEntities db,bool shouldRemap = false);
 void SaveContactType(ContactType contactType);
 void SaveContactType(ContactType contactType, SubscriptionEntities db);
 void SaveOnlyContactType(ContactType contactType);
 void SaveOnlyContactType(ContactType contactType, SubscriptionEntities db);
 void DeleteContactType(ContactType contactType);
 void DeleteContactType(ContactType contactType, SubscriptionEntities db);		
  void DeletePermanentlyContactType(ContactType contactType);
 void DeletePermanentlyContactType(ContactType contactType, SubscriptionEntities db);	
	}
 	public partial interface ICountryDao
	{
  List<Country> GetAllCountries(bool shouldRemap = false);
  List<Country> GetAllCountries(SubscriptionEntities db,bool shouldRemap = false);
  BaseListReturnType<Country> GetAllCountriesByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Country, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<Country, dynamic> orderExpression = null);
  BaseListReturnType<Country> GetAllCountriesByPage(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<Country, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<Country, dynamic> orderExpression = null);
  
  BaseListReturnType<Country> GetAllCountriesByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Country, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<Country, dynamic> orderExpression = null);
  BaseListReturnType<Country> GetAllCountriesByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<Country, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<Country, dynamic> orderExpression = null);

 BaseListReturnType<Country> GetAllCountriesWithAddressesDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Country, bool>> expression = null,bool shouldRemap = false, Func<Country, dynamic> orderExpression = null);
 BaseListReturnType<Country> GetAllCountriesWithAddressesDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Country, bool>> expression = null,bool shouldRemap = false, Func<Country, dynamic> orderExpression = null);

 BaseListReturnType<Country> GetAllCountriesWithCitiesDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Country, bool>> expression = null,bool shouldRemap = false, Func<Country, dynamic> orderExpression = null);
 BaseListReturnType<Country> GetAllCountriesWithCitiesDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Country, bool>> expression = null,bool shouldRemap = false, Func<Country, dynamic> orderExpression = null);


List<Country> GetCountryListByIdList(List<long> countryIds);

List<Country> GetCountryListByIdList(List<long> countryIds, SubscriptionEntities db);

 BaseListReturnType<Country> GetAllCountriesWithAddressesDetails(bool shouldRemap = false);
 BaseListReturnType<Country> GetAllCountriesWithCitiesDetails(bool shouldRemap = false);
 BaseListReturnType<Country> GetAllCountryWitDetails( List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<Country> GetAllCountryWitDetails( SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 Country GetCountry(long idCountry,bool shouldRemap = false);
 Country GetCountry(long idCountry, SubscriptionEntities db,bool shouldRemap = false);
 Country GetCountryWithAddressesDetails(long idCountry,bool shouldRemap = false);
           List<Address> UpdateAddressesForCountryWithoutSavingNewItem(List<Address> newAddresses,long idCountry);
    List<Address> UpdateAddressesForCountryWithoutSavingNewItem(List<Address> newAddresses,long idCountry,SubscriptionEntities db);
          

    List<Address> UpdateAddressesForCountry(List<Address> newAddresses,long idCountry);
    List<Address> UpdateAddressesForCountry(List<Address> newAddresses,long idCountry,SubscriptionEntities db);
                           



 Country GetCountryWithCitiesDetails(long idCountry,bool shouldRemap = false);
           List<City> UpdateCitiesForCountryWithoutSavingNewItem(List<City> newCities,long idCountry);
    List<City> UpdateCitiesForCountryWithoutSavingNewItem(List<City> newCities,long idCountry,SubscriptionEntities db);
          

    List<City> UpdateCitiesForCountry(List<City> newCities,long idCountry);
    List<City> UpdateCitiesForCountry(List<City> newCities,long idCountry,SubscriptionEntities db);
                           



 Country GetCountryCustom( Expression<Func<Country, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 Country GetCountryCustom(SubscriptionEntities db, Expression<Func<Country, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<Country> GetCountryCustomList( Expression<Func<Country, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<Country, dynamic> orderExpression = null);
 BaseListReturnType<Country> GetCountryCustomList( SubscriptionEntities db , Expression<Func<Country, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<Country, dynamic> orderExpression = null);
 Country GetCountryWithDetails(long idCountry, List<string> includes = null,bool shouldRemap = false);
 Country GetCountryWithDetails(long idCountry, SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 Country GetCountryWitDetails(long idCountry,bool shouldRemap = false);
 Country GetCountryWitDetails(long idCountry, SubscriptionEntities db,bool shouldRemap = false);
 void SaveCountry(Country country);
 void SaveCountry(Country country, SubscriptionEntities db);
 void SaveOnlyCountry(Country country);
 void SaveOnlyCountry(Country country, SubscriptionEntities db);
 void DeleteCountry(Country country);
 void DeleteCountry(Country country, SubscriptionEntities db);		
  void DeletePermanentlyCountry(Country country);
 void DeletePermanentlyCountry(Country country, SubscriptionEntities db);	
	}
 	public partial interface ICustomerDao
	{
  List<Customer> GetAllCustomers(bool shouldRemap = false);
  List<Customer> GetAllCustomers(SubscriptionEntities db,bool shouldRemap = false);
  BaseListReturnType<Customer> GetAllCustomersByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Customer, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<Customer, dynamic> orderExpression = null);
  BaseListReturnType<Customer> GetAllCustomersByPage(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<Customer, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<Customer, dynamic> orderExpression = null);
  
  BaseListReturnType<Customer> GetAllCustomersByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Customer, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<Customer, dynamic> orderExpression = null);
  BaseListReturnType<Customer> GetAllCustomersByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<Customer, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<Customer, dynamic> orderExpression = null);

 BaseListReturnType<Customer> GetAllCustomersWithTransactionPresetsDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Customer, bool>> expression = null,bool shouldRemap = false, Func<Customer, dynamic> orderExpression = null);
 BaseListReturnType<Customer> GetAllCustomersWithTransactionPresetsDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Customer, bool>> expression = null,bool shouldRemap = false, Func<Customer, dynamic> orderExpression = null);

 BaseListReturnType<Customer> GetAllCustomersWithCompanyDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Customer, bool>> expression = null,bool shouldRemap = false, Func<Customer, dynamic> orderExpression = null);
 BaseListReturnType<Customer> GetAllCustomersWithCompanyDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Customer, bool>> expression = null,bool shouldRemap = false, Func<Customer, dynamic> orderExpression = null);






BaseListReturnType<Customer> GetAllCustomerListByCompany(long idCompany);

BaseListReturnType<Customer> GetAllCustomerListByCompany(long idCompany, SubscriptionEntities db);

BaseListReturnType<Customer> GetAllCustomerListByCompanyByPage(long idCompany, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<Customer> GetAllCustomerListByCompanyByPage(long idCompany, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);



 BaseListReturnType<Customer> GetAllCustomersWithCustomerTypeDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Customer, bool>> expression = null,bool shouldRemap = false, Func<Customer, dynamic> orderExpression = null);
 BaseListReturnType<Customer> GetAllCustomersWithCustomerTypeDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Customer, bool>> expression = null,bool shouldRemap = false, Func<Customer, dynamic> orderExpression = null);






BaseListReturnType<Customer> GetAllCustomerListByCustomerType(long idCustomerType);

BaseListReturnType<Customer> GetAllCustomerListByCustomerType(long idCustomerType, SubscriptionEntities db);

BaseListReturnType<Customer> GetAllCustomerListByCustomerTypeByPage(long idCustomerType, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<Customer> GetAllCustomerListByCustomerTypeByPage(long idCustomerType, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);



 BaseListReturnType<Customer> GetAllCustomersWithConceptDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Customer, bool>> expression = null,bool shouldRemap = false, Func<Customer, dynamic> orderExpression = null);
 BaseListReturnType<Customer> GetAllCustomersWithConceptDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Customer, bool>> expression = null,bool shouldRemap = false, Func<Customer, dynamic> orderExpression = null);






BaseListReturnType<Customer> GetAllCustomerListByConcept(long idConcept);

BaseListReturnType<Customer> GetAllCustomerListByConcept(long idConcept, SubscriptionEntities db);

BaseListReturnType<Customer> GetAllCustomerListByConceptByPage(long idConcept, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<Customer> GetAllCustomerListByConceptByPage(long idConcept, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);



 BaseListReturnType<Customer> GetAllCustomersWithPersonDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Customer, bool>> expression = null,bool shouldRemap = false, Func<Customer, dynamic> orderExpression = null);
 BaseListReturnType<Customer> GetAllCustomersWithPersonDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Customer, bool>> expression = null,bool shouldRemap = false, Func<Customer, dynamic> orderExpression = null);






BaseListReturnType<Customer> GetAllCustomerListByPerson(long idPerson);

BaseListReturnType<Customer> GetAllCustomerListByPerson(long idPerson, SubscriptionEntities db);

BaseListReturnType<Customer> GetAllCustomerListByPersonByPage(long idPerson, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<Customer> GetAllCustomerListByPersonByPage(long idPerson, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);



 BaseListReturnType<Customer> GetAllCustomersWithTransactionsDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Customer, bool>> expression = null,bool shouldRemap = false, Func<Customer, dynamic> orderExpression = null);
 BaseListReturnType<Customer> GetAllCustomersWithTransactionsDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Customer, bool>> expression = null,bool shouldRemap = false, Func<Customer, dynamic> orderExpression = null);


List<Customer> GetCustomerListByIdList(List<long> customerIds);

List<Customer> GetCustomerListByIdList(List<long> customerIds, SubscriptionEntities db);

 BaseListReturnType<Customer> GetAllCustomersWithTransactionPresetsDetails(bool shouldRemap = false);
 BaseListReturnType<Customer> GetAllCustomersWithCompanyDetails(bool shouldRemap = false);
 BaseListReturnType<Customer> GetAllCustomersWithCustomerTypeDetails(bool shouldRemap = false);
 BaseListReturnType<Customer> GetAllCustomersWithConceptDetails(bool shouldRemap = false);
 BaseListReturnType<Customer> GetAllCustomersWithPersonDetails(bool shouldRemap = false);
 BaseListReturnType<Customer> GetAllCustomersWithTransactionsDetails(bool shouldRemap = false);
 BaseListReturnType<Customer> GetAllCustomerWitDetails( List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<Customer> GetAllCustomerWitDetails( SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 Customer GetCustomer(long idCustomer,bool shouldRemap = false);
 Customer GetCustomer(long idCustomer, SubscriptionEntities db,bool shouldRemap = false);
 Customer GetCustomerWithTransactionPresetsDetails(long idCustomer,bool shouldRemap = false);
           List<TransactionPreset> UpdateTransactionPresetsForCustomerWithoutSavingNewItem(List<TransactionPreset> newTransactionPresets,long idCustomer);
    List<TransactionPreset> UpdateTransactionPresetsForCustomerWithoutSavingNewItem(List<TransactionPreset> newTransactionPresets,long idCustomer,SubscriptionEntities db);
          

    List<TransactionPreset> UpdateTransactionPresetsForCustomer(List<TransactionPreset> newTransactionPresets,long idCustomer);
    List<TransactionPreset> UpdateTransactionPresetsForCustomer(List<TransactionPreset> newTransactionPresets,long idCustomer,SubscriptionEntities db);
                           



 Customer GetCustomerWithCompanyDetails(long idCustomer,bool shouldRemap = false);
    


 Customer GetCustomerWithCustomerTypeDetails(long idCustomer,bool shouldRemap = false);
    


 Customer GetCustomerWithConceptDetails(long idCustomer,bool shouldRemap = false);
    


 Customer GetCustomerWithPersonDetails(long idCustomer,bool shouldRemap = false);
    


 Customer GetCustomerWithTransactionsDetails(long idCustomer,bool shouldRemap = false);
           List<Transaction> UpdateTransactionsForCustomerWithoutSavingNewItem(List<Transaction> newTransactions,long idCustomer);
    List<Transaction> UpdateTransactionsForCustomerWithoutSavingNewItem(List<Transaction> newTransactions,long idCustomer,SubscriptionEntities db);
          

    List<Transaction> UpdateTransactionsForCustomer(List<Transaction> newTransactions,long idCustomer);
    List<Transaction> UpdateTransactionsForCustomer(List<Transaction> newTransactions,long idCustomer,SubscriptionEntities db);
                           



 Customer GetCustomerCustom( Expression<Func<Customer, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 Customer GetCustomerCustom(SubscriptionEntities db, Expression<Func<Customer, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<Customer> GetCustomerCustomList( Expression<Func<Customer, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<Customer, dynamic> orderExpression = null);
 BaseListReturnType<Customer> GetCustomerCustomList( SubscriptionEntities db , Expression<Func<Customer, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<Customer, dynamic> orderExpression = null);
 Customer GetCustomerWithDetails(long idCustomer, List<string> includes = null,bool shouldRemap = false);
 Customer GetCustomerWithDetails(long idCustomer, SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 Customer GetCustomerWitDetails(long idCustomer,bool shouldRemap = false);
 Customer GetCustomerWitDetails(long idCustomer, SubscriptionEntities db,bool shouldRemap = false);
 void SaveCustomer(Customer customer);
 void SaveCustomer(Customer customer, SubscriptionEntities db);
 void SaveOnlyCustomer(Customer customer);
 void SaveOnlyCustomer(Customer customer, SubscriptionEntities db);
 void DeleteCustomer(Customer customer);
 void DeleteCustomer(Customer customer, SubscriptionEntities db);		
  void DeletePermanentlyCustomer(Customer customer);
 void DeletePermanentlyCustomer(Customer customer, SubscriptionEntities db);	
	}
 	public partial interface ICustomerTypeDao
	{
  List<CustomerType> GetAllCustomerTypes(bool shouldRemap = false);
  List<CustomerType> GetAllCustomerTypes(SubscriptionEntities db,bool shouldRemap = false);
  BaseListReturnType<CustomerType> GetAllCustomerTypesByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<CustomerType, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<CustomerType, dynamic> orderExpression = null);
  BaseListReturnType<CustomerType> GetAllCustomerTypesByPage(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<CustomerType, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<CustomerType, dynamic> orderExpression = null);
  
  BaseListReturnType<CustomerType> GetAllCustomerTypesByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<CustomerType, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<CustomerType, dynamic> orderExpression = null);
  BaseListReturnType<CustomerType> GetAllCustomerTypesByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<CustomerType, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<CustomerType, dynamic> orderExpression = null);

 BaseListReturnType<CustomerType> GetAllCustomerTypesWithCustomersDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<CustomerType, bool>> expression = null,bool shouldRemap = false, Func<CustomerType, dynamic> orderExpression = null);
 BaseListReturnType<CustomerType> GetAllCustomerTypesWithCustomersDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<CustomerType, bool>> expression = null,bool shouldRemap = false, Func<CustomerType, dynamic> orderExpression = null);


List<CustomerType> GetCustomerTypeListByIdList(List<long> customerTypeIds);

List<CustomerType> GetCustomerTypeListByIdList(List<long> customerTypeIds, SubscriptionEntities db);

 BaseListReturnType<CustomerType> GetAllCustomerTypesWithCustomersDetails(bool shouldRemap = false);
 BaseListReturnType<CustomerType> GetAllCustomerTypeWitDetails( List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<CustomerType> GetAllCustomerTypeWitDetails( SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 CustomerType GetCustomerType(long idCustomerType,bool shouldRemap = false);
 CustomerType GetCustomerType(long idCustomerType, SubscriptionEntities db,bool shouldRemap = false);
 CustomerType GetCustomerTypeWithCustomersDetails(long idCustomerType,bool shouldRemap = false);
           List<Customer> UpdateCustomersForCustomerTypeWithoutSavingNewItem(List<Customer> newCustomers,long idCustomerType);
    List<Customer> UpdateCustomersForCustomerTypeWithoutSavingNewItem(List<Customer> newCustomers,long idCustomerType,SubscriptionEntities db);
          

    List<Customer> UpdateCustomersForCustomerType(List<Customer> newCustomers,long idCustomerType);
    List<Customer> UpdateCustomersForCustomerType(List<Customer> newCustomers,long idCustomerType,SubscriptionEntities db);
                           



 CustomerType GetCustomerTypeCustom( Expression<Func<CustomerType, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 CustomerType GetCustomerTypeCustom(SubscriptionEntities db, Expression<Func<CustomerType, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<CustomerType> GetCustomerTypeCustomList( Expression<Func<CustomerType, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<CustomerType, dynamic> orderExpression = null);
 BaseListReturnType<CustomerType> GetCustomerTypeCustomList( SubscriptionEntities db , Expression<Func<CustomerType, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<CustomerType, dynamic> orderExpression = null);
 CustomerType GetCustomerTypeWithDetails(long idCustomerType, List<string> includes = null,bool shouldRemap = false);
 CustomerType GetCustomerTypeWithDetails(long idCustomerType, SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 CustomerType GetCustomerTypeWitDetails(long idCustomerType,bool shouldRemap = false);
 CustomerType GetCustomerTypeWitDetails(long idCustomerType, SubscriptionEntities db,bool shouldRemap = false);
 void SaveCustomerType(CustomerType customerType);
 void SaveCustomerType(CustomerType customerType, SubscriptionEntities db);
 void SaveOnlyCustomerType(CustomerType customerType);
 void SaveOnlyCustomerType(CustomerType customerType, SubscriptionEntities db);
 void DeleteCustomerType(CustomerType customerType);
 void DeleteCustomerType(CustomerType customerType, SubscriptionEntities db);		
  void DeletePermanentlyCustomerType(CustomerType customerType);
 void DeletePermanentlyCustomerType(CustomerType customerType, SubscriptionEntities db);	
	}
 	public partial interface IDocumentDao
	{
  List<Document> GetAllDocuments(bool shouldRemap = false);
  List<Document> GetAllDocuments(SubscriptionEntities db,bool shouldRemap = false);
  BaseListReturnType<Document> GetAllDocumentsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Document, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<Document, dynamic> orderExpression = null);
  BaseListReturnType<Document> GetAllDocumentsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<Document, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<Document, dynamic> orderExpression = null);
  
  BaseListReturnType<Document> GetAllDocumentsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Document, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<Document, dynamic> orderExpression = null);
  BaseListReturnType<Document> GetAllDocumentsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<Document, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<Document, dynamic> orderExpression = null);

 BaseListReturnType<Document> GetAllDocumentsWithBankStatementStagingsDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Document, bool>> expression = null,bool shouldRemap = false, Func<Document, dynamic> orderExpression = null);
 BaseListReturnType<Document> GetAllDocumentsWithBankStatementStagingsDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Document, bool>> expression = null,bool shouldRemap = false, Func<Document, dynamic> orderExpression = null);

 BaseListReturnType<Document> GetAllDocumentsWithCompaniesDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Document, bool>> expression = null,bool shouldRemap = false, Func<Document, dynamic> orderExpression = null);
 BaseListReturnType<Document> GetAllDocumentsWithCompaniesDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Document, bool>> expression = null,bool shouldRemap = false, Func<Document, dynamic> orderExpression = null);

 BaseListReturnType<Document> GetAllDocumentsWithDocumentTypeDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Document, bool>> expression = null,bool shouldRemap = false, Func<Document, dynamic> orderExpression = null);
 BaseListReturnType<Document> GetAllDocumentsWithDocumentTypeDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Document, bool>> expression = null,bool shouldRemap = false, Func<Document, dynamic> orderExpression = null);






BaseListReturnType<Document> GetAllDocumentListByDocumentType(long idDocumentType);

BaseListReturnType<Document> GetAllDocumentListByDocumentType(long idDocumentType, SubscriptionEntities db);

BaseListReturnType<Document> GetAllDocumentListByDocumentTypeByPage(long idDocumentType, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<Document> GetAllDocumentListByDocumentTypeByPage(long idDocumentType, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);



 BaseListReturnType<Document> GetAllDocumentsWithParameterDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Document, bool>> expression = null,bool shouldRemap = false, Func<Document, dynamic> orderExpression = null);
 BaseListReturnType<Document> GetAllDocumentsWithParameterDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Document, bool>> expression = null,bool shouldRemap = false, Func<Document, dynamic> orderExpression = null);






BaseListReturnType<Document> GetAllDocumentListByParameter(long idParameter);

BaseListReturnType<Document> GetAllDocumentListByParameter(long idParameter, SubscriptionEntities db);

BaseListReturnType<Document> GetAllDocumentListByParameterByPage(long idParameter, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<Document> GetAllDocumentListByParameterByPage(long idParameter, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);



 BaseListReturnType<Document> GetAllDocumentsWithParameter1DetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Document, bool>> expression = null,bool shouldRemap = false, Func<Document, dynamic> orderExpression = null);
 BaseListReturnType<Document> GetAllDocumentsWithParameter1DetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Document, bool>> expression = null,bool shouldRemap = false, Func<Document, dynamic> orderExpression = null);






BaseListReturnType<Document> GetAllDocumentListByParameter1(long idParameter1);

BaseListReturnType<Document> GetAllDocumentListByParameter1(long idParameter1, SubscriptionEntities db);

BaseListReturnType<Document> GetAllDocumentListByParameter1ByPage(long idParameter1, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<Document> GetAllDocumentListByParameter1ByPage(long idParameter1, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);



 BaseListReturnType<Document> GetAllDocumentsWithTemporaryTransactionOrdersDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Document, bool>> expression = null,bool shouldRemap = false, Func<Document, dynamic> orderExpression = null);
 BaseListReturnType<Document> GetAllDocumentsWithTemporaryTransactionOrdersDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Document, bool>> expression = null,bool shouldRemap = false, Func<Document, dynamic> orderExpression = null);

 BaseListReturnType<Document> GetAllDocumentsWithTransactionsDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Document, bool>> expression = null,bool shouldRemap = false, Func<Document, dynamic> orderExpression = null);
 BaseListReturnType<Document> GetAllDocumentsWithTransactionsDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Document, bool>> expression = null,bool shouldRemap = false, Func<Document, dynamic> orderExpression = null);


List<Document> GetDocumentListByIdList(List<long> documentIds);

List<Document> GetDocumentListByIdList(List<long> documentIds, SubscriptionEntities db);

 BaseListReturnType<Document> GetAllDocumentsWithBankStatementStagingsDetails(bool shouldRemap = false);
 BaseListReturnType<Document> GetAllDocumentsWithCompaniesDetails(bool shouldRemap = false);
 BaseListReturnType<Document> GetAllDocumentsWithDocumentTypeDetails(bool shouldRemap = false);
 BaseListReturnType<Document> GetAllDocumentsWithParameterDetails(bool shouldRemap = false);
 BaseListReturnType<Document> GetAllDocumentsWithParameter1Details(bool shouldRemap = false);
 BaseListReturnType<Document> GetAllDocumentsWithTemporaryTransactionOrdersDetails(bool shouldRemap = false);
 BaseListReturnType<Document> GetAllDocumentsWithTransactionsDetails(bool shouldRemap = false);
 BaseListReturnType<Document> GetAllDocumentWitDetails( List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<Document> GetAllDocumentWitDetails( SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 Document GetDocument(long idDocument,bool shouldRemap = false);
 Document GetDocument(long idDocument, SubscriptionEntities db,bool shouldRemap = false);
 Document GetDocumentWithBankStatementStagingsDetails(long idDocument,bool shouldRemap = false);
           List<BankStatementStaging> UpdateBankStatementStagingsForDocumentWithoutSavingNewItem(List<BankStatementStaging> newBankStatementStagings,long idDocument);
    List<BankStatementStaging> UpdateBankStatementStagingsForDocumentWithoutSavingNewItem(List<BankStatementStaging> newBankStatementStagings,long idDocument,SubscriptionEntities db);
          

    List<BankStatementStaging> UpdateBankStatementStagingsForDocument(List<BankStatementStaging> newBankStatementStagings,long idDocument);
    List<BankStatementStaging> UpdateBankStatementStagingsForDocument(List<BankStatementStaging> newBankStatementStagings,long idDocument,SubscriptionEntities db);
                           



 Document GetDocumentWithCompaniesDetails(long idDocument,bool shouldRemap = false);
           List<Company> UpdateCompaniesForDocumentWithoutSavingNewItem(List<Company> newCompanies,long idDocument);
    List<Company> UpdateCompaniesForDocumentWithoutSavingNewItem(List<Company> newCompanies,long idDocument,SubscriptionEntities db);
          

    List<Company> UpdateCompaniesForDocument(List<Company> newCompanies,long idDocument);
    List<Company> UpdateCompaniesForDocument(List<Company> newCompanies,long idDocument,SubscriptionEntities db);
                           



 Document GetDocumentWithDocumentTypeDetails(long idDocument,bool shouldRemap = false);
    


 Document GetDocumentWithParameterDetails(long idDocument,bool shouldRemap = false);
    


 Document GetDocumentWithParameter1Details(long idDocument,bool shouldRemap = false);
    


 Document GetDocumentWithTemporaryTransactionOrdersDetails(long idDocument,bool shouldRemap = false);
           List<TemporaryTransactionOrder> UpdateTemporaryTransactionOrdersForDocumentWithoutSavingNewItem(List<TemporaryTransactionOrder> newTemporaryTransactionOrders,long idDocument);
    List<TemporaryTransactionOrder> UpdateTemporaryTransactionOrdersForDocumentWithoutSavingNewItem(List<TemporaryTransactionOrder> newTemporaryTransactionOrders,long idDocument,SubscriptionEntities db);
          

    List<TemporaryTransactionOrder> UpdateTemporaryTransactionOrdersForDocument(List<TemporaryTransactionOrder> newTemporaryTransactionOrders,long idDocument);
    List<TemporaryTransactionOrder> UpdateTemporaryTransactionOrdersForDocument(List<TemporaryTransactionOrder> newTemporaryTransactionOrders,long idDocument,SubscriptionEntities db);
                           



 Document GetDocumentWithTransactionsDetails(long idDocument,bool shouldRemap = false);
           List<Transaction> UpdateTransactionsForDocumentWithoutSavingNewItem(List<Transaction> newTransactions,long idDocument);
    List<Transaction> UpdateTransactionsForDocumentWithoutSavingNewItem(List<Transaction> newTransactions,long idDocument,SubscriptionEntities db);
          

    List<Transaction> UpdateTransactionsForDocument(List<Transaction> newTransactions,long idDocument);
    List<Transaction> UpdateTransactionsForDocument(List<Transaction> newTransactions,long idDocument,SubscriptionEntities db);
                           



 Document GetDocumentCustom( Expression<Func<Document, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 Document GetDocumentCustom(SubscriptionEntities db, Expression<Func<Document, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<Document> GetDocumentCustomList( Expression<Func<Document, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<Document, dynamic> orderExpression = null);
 BaseListReturnType<Document> GetDocumentCustomList( SubscriptionEntities db , Expression<Func<Document, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<Document, dynamic> orderExpression = null);
 Document GetDocumentWithDetails(long idDocument, List<string> includes = null,bool shouldRemap = false);
 Document GetDocumentWithDetails(long idDocument, SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 Document GetDocumentWitDetails(long idDocument,bool shouldRemap = false);
 Document GetDocumentWitDetails(long idDocument, SubscriptionEntities db,bool shouldRemap = false);
 void SaveDocument(Document document);
 void SaveDocument(Document document, SubscriptionEntities db);
 void SaveOnlyDocument(Document document);
 void SaveOnlyDocument(Document document, SubscriptionEntities db);
 void DeleteDocument(Document document);
 void DeleteDocument(Document document, SubscriptionEntities db);		
  void DeletePermanentlyDocument(Document document);
 void DeletePermanentlyDocument(Document document, SubscriptionEntities db);	
	}
 	public partial interface IDocumentTypeDao
	{
  List<DocumentType> GetAllDocumentTypes(bool shouldRemap = false);
  List<DocumentType> GetAllDocumentTypes(SubscriptionEntities db,bool shouldRemap = false);
  BaseListReturnType<DocumentType> GetAllDocumentTypesByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<DocumentType, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<DocumentType, dynamic> orderExpression = null);
  BaseListReturnType<DocumentType> GetAllDocumentTypesByPage(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<DocumentType, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<DocumentType, dynamic> orderExpression = null);
  
  BaseListReturnType<DocumentType> GetAllDocumentTypesByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<DocumentType, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<DocumentType, dynamic> orderExpression = null);
  BaseListReturnType<DocumentType> GetAllDocumentTypesByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<DocumentType, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<DocumentType, dynamic> orderExpression = null);

 BaseListReturnType<DocumentType> GetAllDocumentTypesWithDocumentsDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<DocumentType, bool>> expression = null,bool shouldRemap = false, Func<DocumentType, dynamic> orderExpression = null);
 BaseListReturnType<DocumentType> GetAllDocumentTypesWithDocumentsDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<DocumentType, bool>> expression = null,bool shouldRemap = false, Func<DocumentType, dynamic> orderExpression = null);


List<DocumentType> GetDocumentTypeListByIdList(List<long> documentTypeIds);

List<DocumentType> GetDocumentTypeListByIdList(List<long> documentTypeIds, SubscriptionEntities db);

 BaseListReturnType<DocumentType> GetAllDocumentTypesWithDocumentsDetails(bool shouldRemap = false);
 BaseListReturnType<DocumentType> GetAllDocumentTypeWitDetails( List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<DocumentType> GetAllDocumentTypeWitDetails( SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 DocumentType GetDocumentType(long idDocumentType,bool shouldRemap = false);
 DocumentType GetDocumentType(long idDocumentType, SubscriptionEntities db,bool shouldRemap = false);
 DocumentType GetDocumentTypeWithDocumentsDetails(long idDocumentType,bool shouldRemap = false);
           List<Document> UpdateDocumentsForDocumentTypeWithoutSavingNewItem(List<Document> newDocuments,long idDocumentType);
    List<Document> UpdateDocumentsForDocumentTypeWithoutSavingNewItem(List<Document> newDocuments,long idDocumentType,SubscriptionEntities db);
          

    List<Document> UpdateDocumentsForDocumentType(List<Document> newDocuments,long idDocumentType);
    List<Document> UpdateDocumentsForDocumentType(List<Document> newDocuments,long idDocumentType,SubscriptionEntities db);
                           



 DocumentType GetDocumentTypeCustom( Expression<Func<DocumentType, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 DocumentType GetDocumentTypeCustom(SubscriptionEntities db, Expression<Func<DocumentType, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<DocumentType> GetDocumentTypeCustomList( Expression<Func<DocumentType, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<DocumentType, dynamic> orderExpression = null);
 BaseListReturnType<DocumentType> GetDocumentTypeCustomList( SubscriptionEntities db , Expression<Func<DocumentType, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<DocumentType, dynamic> orderExpression = null);
 DocumentType GetDocumentTypeWithDetails(long idDocumentType, List<string> includes = null,bool shouldRemap = false);
 DocumentType GetDocumentTypeWithDetails(long idDocumentType, SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 DocumentType GetDocumentTypeWitDetails(long idDocumentType,bool shouldRemap = false);
 DocumentType GetDocumentTypeWitDetails(long idDocumentType, SubscriptionEntities db,bool shouldRemap = false);
 void SaveDocumentType(DocumentType documentType);
 void SaveDocumentType(DocumentType documentType, SubscriptionEntities db);
 void SaveOnlyDocumentType(DocumentType documentType);
 void SaveOnlyDocumentType(DocumentType documentType, SubscriptionEntities db);
 void DeleteDocumentType(DocumentType documentType);
 void DeleteDocumentType(DocumentType documentType, SubscriptionEntities db);		
  void DeletePermanentlyDocumentType(DocumentType documentType);
 void DeletePermanentlyDocumentType(DocumentType documentType, SubscriptionEntities db);	
	}
 	public partial interface IEndTypeDao
	{
  List<EndType> GetAllEndTypes(bool shouldRemap = false);
  List<EndType> GetAllEndTypes(SubscriptionEntities db,bool shouldRemap = false);
  BaseListReturnType<EndType> GetAllEndTypesByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<EndType, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<EndType, dynamic> orderExpression = null);
  BaseListReturnType<EndType> GetAllEndTypesByPage(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<EndType, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<EndType, dynamic> orderExpression = null);
  
  BaseListReturnType<EndType> GetAllEndTypesByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<EndType, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<EndType, dynamic> orderExpression = null);
  BaseListReturnType<EndType> GetAllEndTypesByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<EndType, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<EndType, dynamic> orderExpression = null);


List<EndType> GetEndTypeListByIdList(List<long> endTypeIds);

List<EndType> GetEndTypeListByIdList(List<long> endTypeIds, SubscriptionEntities db);

 BaseListReturnType<EndType> GetAllEndTypeWitDetails( List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<EndType> GetAllEndTypeWitDetails( SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 EndType GetEndType(long idEndType,bool shouldRemap = false);
 EndType GetEndType(long idEndType, SubscriptionEntities db,bool shouldRemap = false);
 EndType GetEndTypeCustom( Expression<Func<EndType, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 EndType GetEndTypeCustom(SubscriptionEntities db, Expression<Func<EndType, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<EndType> GetEndTypeCustomList( Expression<Func<EndType, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<EndType, dynamic> orderExpression = null);
 BaseListReturnType<EndType> GetEndTypeCustomList( SubscriptionEntities db , Expression<Func<EndType, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<EndType, dynamic> orderExpression = null);
 EndType GetEndTypeWithDetails(long idEndType, List<string> includes = null,bool shouldRemap = false);
 EndType GetEndTypeWithDetails(long idEndType, SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 EndType GetEndTypeWitDetails(long idEndType,bool shouldRemap = false);
 EndType GetEndTypeWitDetails(long idEndType, SubscriptionEntities db,bool shouldRemap = false);
 void SaveEndType(EndType endType);
 void SaveEndType(EndType endType, SubscriptionEntities db);
 void SaveOnlyEndType(EndType endType);
 void SaveOnlyEndType(EndType endType, SubscriptionEntities db);
 void DeleteEndType(EndType endType);
 void DeleteEndType(EndType endType, SubscriptionEntities db);		
  void DeletePermanentlyEndType(EndType endType);
 void DeletePermanentlyEndType(EndType endType, SubscriptionEntities db);	
	}
 	public partial interface IFrequencyDao
	{
  List<Frequency> GetAllFrequencies(bool shouldRemap = false);
  List<Frequency> GetAllFrequencies(SubscriptionEntities db,bool shouldRemap = false);
  BaseListReturnType<Frequency> GetAllFrequenciesByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Frequency, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<Frequency, dynamic> orderExpression = null);
  BaseListReturnType<Frequency> GetAllFrequenciesByPage(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<Frequency, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<Frequency, dynamic> orderExpression = null);
  
  BaseListReturnType<Frequency> GetAllFrequenciesByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Frequency, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<Frequency, dynamic> orderExpression = null);
  BaseListReturnType<Frequency> GetAllFrequenciesByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<Frequency, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<Frequency, dynamic> orderExpression = null);

 BaseListReturnType<Frequency> GetAllFrequenciesWithScheduleSettingsDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Frequency, bool>> expression = null,bool shouldRemap = false, Func<Frequency, dynamic> orderExpression = null);
 BaseListReturnType<Frequency> GetAllFrequenciesWithScheduleSettingsDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Frequency, bool>> expression = null,bool shouldRemap = false, Func<Frequency, dynamic> orderExpression = null);


List<Frequency> GetFrequencyListByIdList(List<long> frequencyIds);

List<Frequency> GetFrequencyListByIdList(List<long> frequencyIds, SubscriptionEntities db);

 BaseListReturnType<Frequency> GetAllFrequenciesWithScheduleSettingsDetails(bool shouldRemap = false);
 BaseListReturnType<Frequency> GetAllFrequencyWitDetails( List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<Frequency> GetAllFrequencyWitDetails( SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 Frequency GetFrequency(long idFrequency,bool shouldRemap = false);
 Frequency GetFrequency(long idFrequency, SubscriptionEntities db,bool shouldRemap = false);
 Frequency GetFrequencyWithScheduleSettingsDetails(long idFrequency,bool shouldRemap = false);
           List<ScheduleSetting> UpdateScheduleSettingsForFrequencyWithoutSavingNewItem(List<ScheduleSetting> newScheduleSettings,long idFrequency);
    List<ScheduleSetting> UpdateScheduleSettingsForFrequencyWithoutSavingNewItem(List<ScheduleSetting> newScheduleSettings,long idFrequency,SubscriptionEntities db);
          

    List<ScheduleSetting> UpdateScheduleSettingsForFrequency(List<ScheduleSetting> newScheduleSettings,long idFrequency);
    List<ScheduleSetting> UpdateScheduleSettingsForFrequency(List<ScheduleSetting> newScheduleSettings,long idFrequency,SubscriptionEntities db);
                           



 Frequency GetFrequencyCustom( Expression<Func<Frequency, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 Frequency GetFrequencyCustom(SubscriptionEntities db, Expression<Func<Frequency, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<Frequency> GetFrequencyCustomList( Expression<Func<Frequency, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<Frequency, dynamic> orderExpression = null);
 BaseListReturnType<Frequency> GetFrequencyCustomList( SubscriptionEntities db , Expression<Func<Frequency, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<Frequency, dynamic> orderExpression = null);
 Frequency GetFrequencyWithDetails(long idFrequency, List<string> includes = null,bool shouldRemap = false);
 Frequency GetFrequencyWithDetails(long idFrequency, SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 Frequency GetFrequencyWitDetails(long idFrequency,bool shouldRemap = false);
 Frequency GetFrequencyWitDetails(long idFrequency, SubscriptionEntities db,bool shouldRemap = false);
 void SaveFrequency(Frequency frequency);
 void SaveFrequency(Frequency frequency, SubscriptionEntities db);
 void SaveOnlyFrequency(Frequency frequency);
 void SaveOnlyFrequency(Frequency frequency, SubscriptionEntities db);
 void DeleteFrequency(Frequency frequency);
 void DeleteFrequency(Frequency frequency, SubscriptionEntities db);		
  void DeletePermanentlyFrequency(Frequency frequency);
 void DeletePermanentlyFrequency(Frequency frequency, SubscriptionEntities db);	
	}
 	public partial interface IMailRecipientDao
	{
  List<MailRecipient> GetAllMailRecipients(bool shouldRemap = false);
  List<MailRecipient> GetAllMailRecipients(SubscriptionEntities db,bool shouldRemap = false);
  BaseListReturnType<MailRecipient> GetAllMailRecipientsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<MailRecipient, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<MailRecipient, dynamic> orderExpression = null);
  BaseListReturnType<MailRecipient> GetAllMailRecipientsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<MailRecipient, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<MailRecipient, dynamic> orderExpression = null);
  
  BaseListReturnType<MailRecipient> GetAllMailRecipientsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<MailRecipient, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<MailRecipient, dynamic> orderExpression = null);
  BaseListReturnType<MailRecipient> GetAllMailRecipientsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<MailRecipient, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<MailRecipient, dynamic> orderExpression = null);

 BaseListReturnType<MailRecipient> GetAllMailRecipientsWithMailRecipientTypeDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<MailRecipient, bool>> expression = null,bool shouldRemap = false, Func<MailRecipient, dynamic> orderExpression = null);
 BaseListReturnType<MailRecipient> GetAllMailRecipientsWithMailRecipientTypeDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<MailRecipient, bool>> expression = null,bool shouldRemap = false, Func<MailRecipient, dynamic> orderExpression = null);






BaseListReturnType<MailRecipient> GetAllMailRecipientListByMailRecipientType(long idMailRecipientType);

BaseListReturnType<MailRecipient> GetAllMailRecipientListByMailRecipientType(long idMailRecipientType, SubscriptionEntities db);

BaseListReturnType<MailRecipient> GetAllMailRecipientListByMailRecipientTypeByPage(long idMailRecipientType, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<MailRecipient> GetAllMailRecipientListByMailRecipientTypeByPage(long idMailRecipientType, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);



 BaseListReturnType<MailRecipient> GetAllMailRecipientsWithMailStatuDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<MailRecipient, bool>> expression = null,bool shouldRemap = false, Func<MailRecipient, dynamic> orderExpression = null);
 BaseListReturnType<MailRecipient> GetAllMailRecipientsWithMailStatuDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<MailRecipient, bool>> expression = null,bool shouldRemap = false, Func<MailRecipient, dynamic> orderExpression = null);






BaseListReturnType<MailRecipient> GetAllMailRecipientListByMailStatu(long idMailStatu);

BaseListReturnType<MailRecipient> GetAllMailRecipientListByMailStatu(long idMailStatu, SubscriptionEntities db);

BaseListReturnType<MailRecipient> GetAllMailRecipientListByMailStatuByPage(long idMailStatu, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<MailRecipient> GetAllMailRecipientListByMailStatuByPage(long idMailStatu, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);



 BaseListReturnType<MailRecipient> GetAllMailRecipientsWithMailToSendDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<MailRecipient, bool>> expression = null,bool shouldRemap = false, Func<MailRecipient, dynamic> orderExpression = null);
 BaseListReturnType<MailRecipient> GetAllMailRecipientsWithMailToSendDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<MailRecipient, bool>> expression = null,bool shouldRemap = false, Func<MailRecipient, dynamic> orderExpression = null);






BaseListReturnType<MailRecipient> GetAllMailRecipientListByMailToSend(long idMailToSend);

BaseListReturnType<MailRecipient> GetAllMailRecipientListByMailToSend(long idMailToSend, SubscriptionEntities db);

BaseListReturnType<MailRecipient> GetAllMailRecipientListByMailToSendByPage(long idMailToSend, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<MailRecipient> GetAllMailRecipientListByMailToSendByPage(long idMailToSend, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);




List<MailRecipient> GetMailRecipientListByIdList(List<long> mailRecipientIds);

List<MailRecipient> GetMailRecipientListByIdList(List<long> mailRecipientIds, SubscriptionEntities db);

 BaseListReturnType<MailRecipient> GetAllMailRecipientsWithMailRecipientTypeDetails(bool shouldRemap = false);
 BaseListReturnType<MailRecipient> GetAllMailRecipientsWithMailStatuDetails(bool shouldRemap = false);
 BaseListReturnType<MailRecipient> GetAllMailRecipientsWithMailToSendDetails(bool shouldRemap = false);
 BaseListReturnType<MailRecipient> GetAllMailRecipientWitDetails( List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<MailRecipient> GetAllMailRecipientWitDetails( SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 MailRecipient GetMailRecipient(long idMailRecipient,bool shouldRemap = false);
 MailRecipient GetMailRecipient(long idMailRecipient, SubscriptionEntities db,bool shouldRemap = false);
 MailRecipient GetMailRecipientWithMailRecipientTypeDetails(long idMailRecipient,bool shouldRemap = false);
    


 MailRecipient GetMailRecipientWithMailStatuDetails(long idMailRecipient,bool shouldRemap = false);
    


 MailRecipient GetMailRecipientWithMailToSendDetails(long idMailRecipient,bool shouldRemap = false);
    


 MailRecipient GetMailRecipientCustom( Expression<Func<MailRecipient, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 MailRecipient GetMailRecipientCustom(SubscriptionEntities db, Expression<Func<MailRecipient, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<MailRecipient> GetMailRecipientCustomList( Expression<Func<MailRecipient, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<MailRecipient, dynamic> orderExpression = null);
 BaseListReturnType<MailRecipient> GetMailRecipientCustomList( SubscriptionEntities db , Expression<Func<MailRecipient, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<MailRecipient, dynamic> orderExpression = null);
 MailRecipient GetMailRecipientWithDetails(long idMailRecipient, List<string> includes = null,bool shouldRemap = false);
 MailRecipient GetMailRecipientWithDetails(long idMailRecipient, SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 MailRecipient GetMailRecipientWitDetails(long idMailRecipient,bool shouldRemap = false);
 MailRecipient GetMailRecipientWitDetails(long idMailRecipient, SubscriptionEntities db,bool shouldRemap = false);
 void SaveMailRecipient(MailRecipient mailRecipient);
 void SaveMailRecipient(MailRecipient mailRecipient, SubscriptionEntities db);
 void SaveOnlyMailRecipient(MailRecipient mailRecipient);
 void SaveOnlyMailRecipient(MailRecipient mailRecipient, SubscriptionEntities db);
 void DeleteMailRecipient(MailRecipient mailRecipient);
 void DeleteMailRecipient(MailRecipient mailRecipient, SubscriptionEntities db);		
  void DeletePermanentlyMailRecipient(MailRecipient mailRecipient);
 void DeletePermanentlyMailRecipient(MailRecipient mailRecipient, SubscriptionEntities db);	
	}
 	public partial interface IMailRecipientTypeDao
	{
  List<MailRecipientType> GetAllMailRecipientTypes(bool shouldRemap = false);
  List<MailRecipientType> GetAllMailRecipientTypes(SubscriptionEntities db,bool shouldRemap = false);
  BaseListReturnType<MailRecipientType> GetAllMailRecipientTypesByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<MailRecipientType, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<MailRecipientType, dynamic> orderExpression = null);
  BaseListReturnType<MailRecipientType> GetAllMailRecipientTypesByPage(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<MailRecipientType, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<MailRecipientType, dynamic> orderExpression = null);
  
  BaseListReturnType<MailRecipientType> GetAllMailRecipientTypesByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<MailRecipientType, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<MailRecipientType, dynamic> orderExpression = null);
  BaseListReturnType<MailRecipientType> GetAllMailRecipientTypesByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<MailRecipientType, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<MailRecipientType, dynamic> orderExpression = null);

 BaseListReturnType<MailRecipientType> GetAllMailRecipientTypesWithMailRecipientsDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<MailRecipientType, bool>> expression = null,bool shouldRemap = false, Func<MailRecipientType, dynamic> orderExpression = null);
 BaseListReturnType<MailRecipientType> GetAllMailRecipientTypesWithMailRecipientsDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<MailRecipientType, bool>> expression = null,bool shouldRemap = false, Func<MailRecipientType, dynamic> orderExpression = null);


List<MailRecipientType> GetMailRecipientTypeListByIdList(List<long> mailRecipientTypeIds);

List<MailRecipientType> GetMailRecipientTypeListByIdList(List<long> mailRecipientTypeIds, SubscriptionEntities db);

 BaseListReturnType<MailRecipientType> GetAllMailRecipientTypesWithMailRecipientsDetails(bool shouldRemap = false);
 BaseListReturnType<MailRecipientType> GetAllMailRecipientTypeWitDetails( List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<MailRecipientType> GetAllMailRecipientTypeWitDetails( SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 MailRecipientType GetMailRecipientType(long idMailRecipientType,bool shouldRemap = false);
 MailRecipientType GetMailRecipientType(long idMailRecipientType, SubscriptionEntities db,bool shouldRemap = false);
 MailRecipientType GetMailRecipientTypeWithMailRecipientsDetails(long idMailRecipientType,bool shouldRemap = false);
           List<MailRecipient> UpdateMailRecipientsForMailRecipientTypeWithoutSavingNewItem(List<MailRecipient> newMailRecipients,long idMailRecipientType);
    List<MailRecipient> UpdateMailRecipientsForMailRecipientTypeWithoutSavingNewItem(List<MailRecipient> newMailRecipients,long idMailRecipientType,SubscriptionEntities db);
          

    List<MailRecipient> UpdateMailRecipientsForMailRecipientType(List<MailRecipient> newMailRecipients,long idMailRecipientType);
    List<MailRecipient> UpdateMailRecipientsForMailRecipientType(List<MailRecipient> newMailRecipients,long idMailRecipientType,SubscriptionEntities db);
                           



 MailRecipientType GetMailRecipientTypeCustom( Expression<Func<MailRecipientType, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 MailRecipientType GetMailRecipientTypeCustom(SubscriptionEntities db, Expression<Func<MailRecipientType, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<MailRecipientType> GetMailRecipientTypeCustomList( Expression<Func<MailRecipientType, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<MailRecipientType, dynamic> orderExpression = null);
 BaseListReturnType<MailRecipientType> GetMailRecipientTypeCustomList( SubscriptionEntities db , Expression<Func<MailRecipientType, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<MailRecipientType, dynamic> orderExpression = null);
 MailRecipientType GetMailRecipientTypeWithDetails(long idMailRecipientType, List<string> includes = null,bool shouldRemap = false);
 MailRecipientType GetMailRecipientTypeWithDetails(long idMailRecipientType, SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 MailRecipientType GetMailRecipientTypeWitDetails(long idMailRecipientType,bool shouldRemap = false);
 MailRecipientType GetMailRecipientTypeWitDetails(long idMailRecipientType, SubscriptionEntities db,bool shouldRemap = false);
 void SaveMailRecipientType(MailRecipientType mailRecipientType);
 void SaveMailRecipientType(MailRecipientType mailRecipientType, SubscriptionEntities db);
 void SaveOnlyMailRecipientType(MailRecipientType mailRecipientType);
 void SaveOnlyMailRecipientType(MailRecipientType mailRecipientType, SubscriptionEntities db);
 void DeleteMailRecipientType(MailRecipientType mailRecipientType);
 void DeleteMailRecipientType(MailRecipientType mailRecipientType, SubscriptionEntities db);		
  void DeletePermanentlyMailRecipientType(MailRecipientType mailRecipientType);
 void DeletePermanentlyMailRecipientType(MailRecipientType mailRecipientType, SubscriptionEntities db);	
	}
 	public partial interface IMailServerSettingDao
	{
  List<MailServerSetting> GetAllMailServerSettings(bool shouldRemap = false);
  List<MailServerSetting> GetAllMailServerSettings(SubscriptionEntities db,bool shouldRemap = false);
  BaseListReturnType<MailServerSetting> GetAllMailServerSettingsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<MailServerSetting, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<MailServerSetting, dynamic> orderExpression = null);
  BaseListReturnType<MailServerSetting> GetAllMailServerSettingsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<MailServerSetting, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<MailServerSetting, dynamic> orderExpression = null);
  
  BaseListReturnType<MailServerSetting> GetAllMailServerSettingsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<MailServerSetting, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<MailServerSetting, dynamic> orderExpression = null);
  BaseListReturnType<MailServerSetting> GetAllMailServerSettingsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<MailServerSetting, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<MailServerSetting, dynamic> orderExpression = null);

 BaseListReturnType<MailServerSetting> GetAllMailServerSettingsWithMailToSendsDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<MailServerSetting, bool>> expression = null,bool shouldRemap = false, Func<MailServerSetting, dynamic> orderExpression = null);
 BaseListReturnType<MailServerSetting> GetAllMailServerSettingsWithMailToSendsDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<MailServerSetting, bool>> expression = null,bool shouldRemap = false, Func<MailServerSetting, dynamic> orderExpression = null);


List<MailServerSetting> GetMailServerSettingListByIdList(List<long> mailServerSettingIds);

List<MailServerSetting> GetMailServerSettingListByIdList(List<long> mailServerSettingIds, SubscriptionEntities db);

 BaseListReturnType<MailServerSetting> GetAllMailServerSettingsWithMailToSendsDetails(bool shouldRemap = false);
 BaseListReturnType<MailServerSetting> GetAllMailServerSettingWitDetails( List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<MailServerSetting> GetAllMailServerSettingWitDetails( SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 MailServerSetting GetMailServerSetting(long idMailServerSetting,bool shouldRemap = false);
 MailServerSetting GetMailServerSetting(long idMailServerSetting, SubscriptionEntities db,bool shouldRemap = false);
 MailServerSetting GetMailServerSettingWithMailToSendsDetails(long idMailServerSetting,bool shouldRemap = false);
           List<MailToSend> UpdateMailToSendsForMailServerSettingWithoutSavingNewItem(List<MailToSend> newMailToSends,long idMailServerSetting);
    List<MailToSend> UpdateMailToSendsForMailServerSettingWithoutSavingNewItem(List<MailToSend> newMailToSends,long idMailServerSetting,SubscriptionEntities db);
          

    List<MailToSend> UpdateMailToSendsForMailServerSetting(List<MailToSend> newMailToSends,long idMailServerSetting);
    List<MailToSend> UpdateMailToSendsForMailServerSetting(List<MailToSend> newMailToSends,long idMailServerSetting,SubscriptionEntities db);
                           



 MailServerSetting GetMailServerSettingCustom( Expression<Func<MailServerSetting, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 MailServerSetting GetMailServerSettingCustom(SubscriptionEntities db, Expression<Func<MailServerSetting, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<MailServerSetting> GetMailServerSettingCustomList( Expression<Func<MailServerSetting, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<MailServerSetting, dynamic> orderExpression = null);
 BaseListReturnType<MailServerSetting> GetMailServerSettingCustomList( SubscriptionEntities db , Expression<Func<MailServerSetting, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<MailServerSetting, dynamic> orderExpression = null);
 MailServerSetting GetMailServerSettingWithDetails(long idMailServerSetting, List<string> includes = null,bool shouldRemap = false);
 MailServerSetting GetMailServerSettingWithDetails(long idMailServerSetting, SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 MailServerSetting GetMailServerSettingWitDetails(long idMailServerSetting,bool shouldRemap = false);
 MailServerSetting GetMailServerSettingWitDetails(long idMailServerSetting, SubscriptionEntities db,bool shouldRemap = false);
 void SaveMailServerSetting(MailServerSetting mailServerSetting);
 void SaveMailServerSetting(MailServerSetting mailServerSetting, SubscriptionEntities db);
 void SaveOnlyMailServerSetting(MailServerSetting mailServerSetting);
 void SaveOnlyMailServerSetting(MailServerSetting mailServerSetting, SubscriptionEntities db);
 void DeleteMailServerSetting(MailServerSetting mailServerSetting);
 void DeleteMailServerSetting(MailServerSetting mailServerSetting, SubscriptionEntities db);		
  void DeletePermanentlyMailServerSetting(MailServerSetting mailServerSetting);
 void DeletePermanentlyMailServerSetting(MailServerSetting mailServerSetting, SubscriptionEntities db);	
	}
 	public partial interface IMailStatuDao
	{
  List<MailStatu> GetAllMailStatus(bool shouldRemap = false);
  List<MailStatu> GetAllMailStatus(SubscriptionEntities db,bool shouldRemap = false);
  BaseListReturnType<MailStatu> GetAllMailStatusByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<MailStatu, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<MailStatu, dynamic> orderExpression = null);
  BaseListReturnType<MailStatu> GetAllMailStatusByPage(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<MailStatu, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<MailStatu, dynamic> orderExpression = null);
  
  BaseListReturnType<MailStatu> GetAllMailStatusByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<MailStatu, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<MailStatu, dynamic> orderExpression = null);
  BaseListReturnType<MailStatu> GetAllMailStatusByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<MailStatu, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<MailStatu, dynamic> orderExpression = null);

 BaseListReturnType<MailStatu> GetAllMailStatusWithMailRecipientsDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<MailStatu, bool>> expression = null,bool shouldRemap = false, Func<MailStatu, dynamic> orderExpression = null);
 BaseListReturnType<MailStatu> GetAllMailStatusWithMailRecipientsDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<MailStatu, bool>> expression = null,bool shouldRemap = false, Func<MailStatu, dynamic> orderExpression = null);

 BaseListReturnType<MailStatu> GetAllMailStatusWithMailToSendsDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<MailStatu, bool>> expression = null,bool shouldRemap = false, Func<MailStatu, dynamic> orderExpression = null);
 BaseListReturnType<MailStatu> GetAllMailStatusWithMailToSendsDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<MailStatu, bool>> expression = null,bool shouldRemap = false, Func<MailStatu, dynamic> orderExpression = null);


List<MailStatu> GetMailStatuListByIdList(List<long> mailStatuIds);

List<MailStatu> GetMailStatuListByIdList(List<long> mailStatuIds, SubscriptionEntities db);

 BaseListReturnType<MailStatu> GetAllMailStatusWithMailRecipientsDetails(bool shouldRemap = false);
 BaseListReturnType<MailStatu> GetAllMailStatusWithMailToSendsDetails(bool shouldRemap = false);
 BaseListReturnType<MailStatu> GetAllMailStatuWitDetails( List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<MailStatu> GetAllMailStatuWitDetails( SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 MailStatu GetMailStatu(long idMailStatu,bool shouldRemap = false);
 MailStatu GetMailStatu(long idMailStatu, SubscriptionEntities db,bool shouldRemap = false);
 MailStatu GetMailStatuWithMailRecipientsDetails(long idMailStatu,bool shouldRemap = false);
           List<MailRecipient> UpdateMailRecipientsForMailStatuWithoutSavingNewItem(List<MailRecipient> newMailRecipients,long idMailStatu);
    List<MailRecipient> UpdateMailRecipientsForMailStatuWithoutSavingNewItem(List<MailRecipient> newMailRecipients,long idMailStatu,SubscriptionEntities db);
          

    List<MailRecipient> UpdateMailRecipientsForMailStatu(List<MailRecipient> newMailRecipients,long idMailStatu);
    List<MailRecipient> UpdateMailRecipientsForMailStatu(List<MailRecipient> newMailRecipients,long idMailStatu,SubscriptionEntities db);
                           



 MailStatu GetMailStatuWithMailToSendsDetails(long idMailStatu,bool shouldRemap = false);
           List<MailToSend> UpdateMailToSendsForMailStatuWithoutSavingNewItem(List<MailToSend> newMailToSends,long idMailStatu);
    List<MailToSend> UpdateMailToSendsForMailStatuWithoutSavingNewItem(List<MailToSend> newMailToSends,long idMailStatu,SubscriptionEntities db);
          

    List<MailToSend> UpdateMailToSendsForMailStatu(List<MailToSend> newMailToSends,long idMailStatu);
    List<MailToSend> UpdateMailToSendsForMailStatu(List<MailToSend> newMailToSends,long idMailStatu,SubscriptionEntities db);
                           



 MailStatu GetMailStatuCustom( Expression<Func<MailStatu, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 MailStatu GetMailStatuCustom(SubscriptionEntities db, Expression<Func<MailStatu, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<MailStatu> GetMailStatuCustomList( Expression<Func<MailStatu, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<MailStatu, dynamic> orderExpression = null);
 BaseListReturnType<MailStatu> GetMailStatuCustomList( SubscriptionEntities db , Expression<Func<MailStatu, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<MailStatu, dynamic> orderExpression = null);
 MailStatu GetMailStatuWithDetails(long idMailStatu, List<string> includes = null,bool shouldRemap = false);
 MailStatu GetMailStatuWithDetails(long idMailStatu, SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 MailStatu GetMailStatuWitDetails(long idMailStatu,bool shouldRemap = false);
 MailStatu GetMailStatuWitDetails(long idMailStatu, SubscriptionEntities db,bool shouldRemap = false);
 void SaveMailStatu(MailStatu mailStatu);
 void SaveMailStatu(MailStatu mailStatu, SubscriptionEntities db);
 void SaveOnlyMailStatu(MailStatu mailStatu);
 void SaveOnlyMailStatu(MailStatu mailStatu, SubscriptionEntities db);
 void DeleteMailStatu(MailStatu mailStatu);
 void DeleteMailStatu(MailStatu mailStatu, SubscriptionEntities db);		
  void DeletePermanentlyMailStatu(MailStatu mailStatu);
 void DeletePermanentlyMailStatu(MailStatu mailStatu, SubscriptionEntities db);	
	}
 	public partial interface IMailToSendDao
	{
  List<MailToSend> GetAllMailToSends(bool shouldRemap = false);
  List<MailToSend> GetAllMailToSends(SubscriptionEntities db,bool shouldRemap = false);
  BaseListReturnType<MailToSend> GetAllMailToSendsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<MailToSend, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<MailToSend, dynamic> orderExpression = null);
  BaseListReturnType<MailToSend> GetAllMailToSendsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<MailToSend, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<MailToSend, dynamic> orderExpression = null);
  
  BaseListReturnType<MailToSend> GetAllMailToSendsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<MailToSend, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<MailToSend, dynamic> orderExpression = null);
  BaseListReturnType<MailToSend> GetAllMailToSendsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<MailToSend, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<MailToSend, dynamic> orderExpression = null);

 BaseListReturnType<MailToSend> GetAllMailToSendsWithMailRecipientsDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<MailToSend, bool>> expression = null,bool shouldRemap = false, Func<MailToSend, dynamic> orderExpression = null);
 BaseListReturnType<MailToSend> GetAllMailToSendsWithMailRecipientsDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<MailToSend, bool>> expression = null,bool shouldRemap = false, Func<MailToSend, dynamic> orderExpression = null);

 BaseListReturnType<MailToSend> GetAllMailToSendsWithMailServerSettingDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<MailToSend, bool>> expression = null,bool shouldRemap = false, Func<MailToSend, dynamic> orderExpression = null);
 BaseListReturnType<MailToSend> GetAllMailToSendsWithMailServerSettingDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<MailToSend, bool>> expression = null,bool shouldRemap = false, Func<MailToSend, dynamic> orderExpression = null);






BaseListReturnType<MailToSend> GetAllMailToSendListByMailServerSetting(long idMailServerSetting);

BaseListReturnType<MailToSend> GetAllMailToSendListByMailServerSetting(long idMailServerSetting, SubscriptionEntities db);

BaseListReturnType<MailToSend> GetAllMailToSendListByMailServerSettingByPage(long idMailServerSetting, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<MailToSend> GetAllMailToSendListByMailServerSettingByPage(long idMailServerSetting, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);



 BaseListReturnType<MailToSend> GetAllMailToSendsWithMailStatuDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<MailToSend, bool>> expression = null,bool shouldRemap = false, Func<MailToSend, dynamic> orderExpression = null);
 BaseListReturnType<MailToSend> GetAllMailToSendsWithMailStatuDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<MailToSend, bool>> expression = null,bool shouldRemap = false, Func<MailToSend, dynamic> orderExpression = null);






BaseListReturnType<MailToSend> GetAllMailToSendListByMailStatu(long idMailStatu);

BaseListReturnType<MailToSend> GetAllMailToSendListByMailStatu(long idMailStatu, SubscriptionEntities db);

BaseListReturnType<MailToSend> GetAllMailToSendListByMailStatuByPage(long idMailStatu, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<MailToSend> GetAllMailToSendListByMailStatuByPage(long idMailStatu, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);



 BaseListReturnType<MailToSend> GetAllMailToSendsWithMailToSendDocumentsDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<MailToSend, bool>> expression = null,bool shouldRemap = false, Func<MailToSend, dynamic> orderExpression = null);
 BaseListReturnType<MailToSend> GetAllMailToSendsWithMailToSendDocumentsDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<MailToSend, bool>> expression = null,bool shouldRemap = false, Func<MailToSend, dynamic> orderExpression = null);

 BaseListReturnType<MailToSend> GetAllMailToSendsWithTransaction_MailToSendDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<MailToSend, bool>> expression = null,bool shouldRemap = false, Func<MailToSend, dynamic> orderExpression = null);
 BaseListReturnType<MailToSend> GetAllMailToSendsWithTransaction_MailToSendDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<MailToSend, bool>> expression = null,bool shouldRemap = false, Func<MailToSend, dynamic> orderExpression = null);


List<MailToSend> GetMailToSendListByIdList(List<long> mailToSendIds);

List<MailToSend> GetMailToSendListByIdList(List<long> mailToSendIds, SubscriptionEntities db);

 BaseListReturnType<MailToSend> GetAllMailToSendsWithMailRecipientsDetails(bool shouldRemap = false);
 BaseListReturnType<MailToSend> GetAllMailToSendsWithMailServerSettingDetails(bool shouldRemap = false);
 BaseListReturnType<MailToSend> GetAllMailToSendsWithMailStatuDetails(bool shouldRemap = false);
 BaseListReturnType<MailToSend> GetAllMailToSendsWithMailToSendDocumentsDetails(bool shouldRemap = false);
 BaseListReturnType<MailToSend> GetAllMailToSendsWithTransaction_MailToSendDetails(bool shouldRemap = false);
 BaseListReturnType<MailToSend> GetAllMailToSendWitDetails( List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<MailToSend> GetAllMailToSendWitDetails( SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 MailToSend GetMailToSend(long idMailToSend,bool shouldRemap = false);
 MailToSend GetMailToSend(long idMailToSend, SubscriptionEntities db,bool shouldRemap = false);
 MailToSend GetMailToSendWithMailRecipientsDetails(long idMailToSend,bool shouldRemap = false);
           List<MailRecipient> UpdateMailRecipientsForMailToSendWithoutSavingNewItem(List<MailRecipient> newMailRecipients,long idMailToSend);
    List<MailRecipient> UpdateMailRecipientsForMailToSendWithoutSavingNewItem(List<MailRecipient> newMailRecipients,long idMailToSend,SubscriptionEntities db);
          

    List<MailRecipient> UpdateMailRecipientsForMailToSend(List<MailRecipient> newMailRecipients,long idMailToSend);
    List<MailRecipient> UpdateMailRecipientsForMailToSend(List<MailRecipient> newMailRecipients,long idMailToSend,SubscriptionEntities db);
                           



 MailToSend GetMailToSendWithMailServerSettingDetails(long idMailToSend,bool shouldRemap = false);
    


 MailToSend GetMailToSendWithMailStatuDetails(long idMailToSend,bool shouldRemap = false);
    


 MailToSend GetMailToSendWithMailToSendDocumentsDetails(long idMailToSend,bool shouldRemap = false);
           List<MailToSendDocument> UpdateMailToSendDocumentsForMailToSendWithoutSavingNewItem(List<MailToSendDocument> newMailToSendDocuments,long idMailToSend);
    List<MailToSendDocument> UpdateMailToSendDocumentsForMailToSendWithoutSavingNewItem(List<MailToSendDocument> newMailToSendDocuments,long idMailToSend,SubscriptionEntities db);
          

    List<MailToSendDocument> UpdateMailToSendDocumentsForMailToSend(List<MailToSendDocument> newMailToSendDocuments,long idMailToSend);
    List<MailToSendDocument> UpdateMailToSendDocumentsForMailToSend(List<MailToSendDocument> newMailToSendDocuments,long idMailToSend,SubscriptionEntities db);
                           



 MailToSend GetMailToSendWithTransaction_MailToSendDetails(long idMailToSend,bool shouldRemap = false);
           List<Transaction_MailToSend> UpdateTransaction_MailToSendForMailToSendWithoutSavingNewItem(List<Transaction_MailToSend> newTransaction_MailToSend,long idMailToSend);
    List<Transaction_MailToSend> UpdateTransaction_MailToSendForMailToSendWithoutSavingNewItem(List<Transaction_MailToSend> newTransaction_MailToSend,long idMailToSend,SubscriptionEntities db);
          

    List<Transaction_MailToSend> UpdateTransaction_MailToSendForMailToSend(List<Transaction_MailToSend> newTransaction_MailToSend,long idMailToSend);
    List<Transaction_MailToSend> UpdateTransaction_MailToSendForMailToSend(List<Transaction_MailToSend> newTransaction_MailToSend,long idMailToSend,SubscriptionEntities db);
                           



 MailToSend GetMailToSendCustom( Expression<Func<MailToSend, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 MailToSend GetMailToSendCustom(SubscriptionEntities db, Expression<Func<MailToSend, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<MailToSend> GetMailToSendCustomList( Expression<Func<MailToSend, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<MailToSend, dynamic> orderExpression = null);
 BaseListReturnType<MailToSend> GetMailToSendCustomList( SubscriptionEntities db , Expression<Func<MailToSend, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<MailToSend, dynamic> orderExpression = null);
 MailToSend GetMailToSendWithDetails(long idMailToSend, List<string> includes = null,bool shouldRemap = false);
 MailToSend GetMailToSendWithDetails(long idMailToSend, SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 MailToSend GetMailToSendWitDetails(long idMailToSend,bool shouldRemap = false);
 MailToSend GetMailToSendWitDetails(long idMailToSend, SubscriptionEntities db,bool shouldRemap = false);
 void SaveMailToSend(MailToSend mailToSend);
 void SaveMailToSend(MailToSend mailToSend, SubscriptionEntities db);
 void SaveOnlyMailToSend(MailToSend mailToSend);
 void SaveOnlyMailToSend(MailToSend mailToSend, SubscriptionEntities db);
 void DeleteMailToSend(MailToSend mailToSend);
 void DeleteMailToSend(MailToSend mailToSend, SubscriptionEntities db);		
  void DeletePermanentlyMailToSend(MailToSend mailToSend);
 void DeletePermanentlyMailToSend(MailToSend mailToSend, SubscriptionEntities db);	
	}
 	public partial interface IMailToSendDocumentDao
	{
  List<MailToSendDocument> GetAllMailToSendDocuments(bool shouldRemap = false);
  List<MailToSendDocument> GetAllMailToSendDocuments(SubscriptionEntities db,bool shouldRemap = false);
  BaseListReturnType<MailToSendDocument> GetAllMailToSendDocumentsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<MailToSendDocument, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<MailToSendDocument, dynamic> orderExpression = null);
  BaseListReturnType<MailToSendDocument> GetAllMailToSendDocumentsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<MailToSendDocument, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<MailToSendDocument, dynamic> orderExpression = null);
  
  BaseListReturnType<MailToSendDocument> GetAllMailToSendDocumentsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<MailToSendDocument, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<MailToSendDocument, dynamic> orderExpression = null);
  BaseListReturnType<MailToSendDocument> GetAllMailToSendDocumentsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<MailToSendDocument, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<MailToSendDocument, dynamic> orderExpression = null);

 BaseListReturnType<MailToSendDocument> GetAllMailToSendDocumentsWithMailToSendDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<MailToSendDocument, bool>> expression = null,bool shouldRemap = false, Func<MailToSendDocument, dynamic> orderExpression = null);
 BaseListReturnType<MailToSendDocument> GetAllMailToSendDocumentsWithMailToSendDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<MailToSendDocument, bool>> expression = null,bool shouldRemap = false, Func<MailToSendDocument, dynamic> orderExpression = null);






BaseListReturnType<MailToSendDocument> GetAllMailToSendDocumentListByMailToSend(long idMailToSend);

BaseListReturnType<MailToSendDocument> GetAllMailToSendDocumentListByMailToSend(long idMailToSend, SubscriptionEntities db);

BaseListReturnType<MailToSendDocument> GetAllMailToSendDocumentListByMailToSendByPage(long idMailToSend, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<MailToSendDocument> GetAllMailToSendDocumentListByMailToSendByPage(long idMailToSend, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);




List<MailToSendDocument> GetMailToSendDocumentListByIdList(List<long> mailToSendDocumentIds);

List<MailToSendDocument> GetMailToSendDocumentListByIdList(List<long> mailToSendDocumentIds, SubscriptionEntities db);

 BaseListReturnType<MailToSendDocument> GetAllMailToSendDocumentsWithMailToSendDetails(bool shouldRemap = false);
 BaseListReturnType<MailToSendDocument> GetAllMailToSendDocumentWitDetails( List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<MailToSendDocument> GetAllMailToSendDocumentWitDetails( SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 MailToSendDocument GetMailToSendDocument(long idMailToSendDocument,bool shouldRemap = false);
 MailToSendDocument GetMailToSendDocument(long idMailToSendDocument, SubscriptionEntities db,bool shouldRemap = false);
 MailToSendDocument GetMailToSendDocumentWithMailToSendDetails(long idMailToSendDocument,bool shouldRemap = false);
    


 MailToSendDocument GetMailToSendDocumentCustom( Expression<Func<MailToSendDocument, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 MailToSendDocument GetMailToSendDocumentCustom(SubscriptionEntities db, Expression<Func<MailToSendDocument, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<MailToSendDocument> GetMailToSendDocumentCustomList( Expression<Func<MailToSendDocument, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<MailToSendDocument, dynamic> orderExpression = null);
 BaseListReturnType<MailToSendDocument> GetMailToSendDocumentCustomList( SubscriptionEntities db , Expression<Func<MailToSendDocument, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<MailToSendDocument, dynamic> orderExpression = null);
 MailToSendDocument GetMailToSendDocumentWithDetails(long idMailToSendDocument, List<string> includes = null,bool shouldRemap = false);
 MailToSendDocument GetMailToSendDocumentWithDetails(long idMailToSendDocument, SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 MailToSendDocument GetMailToSendDocumentWitDetails(long idMailToSendDocument,bool shouldRemap = false);
 MailToSendDocument GetMailToSendDocumentWitDetails(long idMailToSendDocument, SubscriptionEntities db,bool shouldRemap = false);
 void SaveMailToSendDocument(MailToSendDocument mailToSendDocument);
 void SaveMailToSendDocument(MailToSendDocument mailToSendDocument, SubscriptionEntities db);
 void SaveOnlyMailToSendDocument(MailToSendDocument mailToSendDocument);
 void SaveOnlyMailToSendDocument(MailToSendDocument mailToSendDocument, SubscriptionEntities db);
 void DeleteMailToSendDocument(MailToSendDocument mailToSendDocument);
 void DeleteMailToSendDocument(MailToSendDocument mailToSendDocument, SubscriptionEntities db);		
  void DeletePermanentlyMailToSendDocument(MailToSendDocument mailToSendDocument);
 void DeletePermanentlyMailToSendDocument(MailToSendDocument mailToSendDocument, SubscriptionEntities db);	
	}
 	public partial interface INLogDetailDao
	{
  List<NLogDetail> GetAllNLogDetails(bool shouldRemap = false);
  List<NLogDetail> GetAllNLogDetails(SubscriptionEntities db,bool shouldRemap = false);
  BaseListReturnType<NLogDetail> GetAllNLogDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<NLogDetail, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<NLogDetail, dynamic> orderExpression = null);
  BaseListReturnType<NLogDetail> GetAllNLogDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<NLogDetail, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<NLogDetail, dynamic> orderExpression = null);
  
  BaseListReturnType<NLogDetail> GetAllNLogDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<NLogDetail, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<NLogDetail, dynamic> orderExpression = null);
  BaseListReturnType<NLogDetail> GetAllNLogDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<NLogDetail, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<NLogDetail, dynamic> orderExpression = null);


List<NLogDetail> GetNLogDetailListByIdList(List<long> nLogDetailIds);

List<NLogDetail> GetNLogDetailListByIdList(List<long> nLogDetailIds, SubscriptionEntities db);

 BaseListReturnType<NLogDetail> GetAllNLogDetailWitDetails( List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<NLogDetail> GetAllNLogDetailWitDetails( SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 NLogDetail GetNLogDetail(long idNLogDetail,bool shouldRemap = false);
 NLogDetail GetNLogDetail(long idNLogDetail, SubscriptionEntities db,bool shouldRemap = false);
 NLogDetail GetNLogDetailCustom( Expression<Func<NLogDetail, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 NLogDetail GetNLogDetailCustom(SubscriptionEntities db, Expression<Func<NLogDetail, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<NLogDetail> GetNLogDetailCustomList( Expression<Func<NLogDetail, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<NLogDetail, dynamic> orderExpression = null);
 BaseListReturnType<NLogDetail> GetNLogDetailCustomList( SubscriptionEntities db , Expression<Func<NLogDetail, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<NLogDetail, dynamic> orderExpression = null);
 NLogDetail GetNLogDetailWithDetails(long idNLogDetail, List<string> includes = null,bool shouldRemap = false);
 NLogDetail GetNLogDetailWithDetails(long idNLogDetail, SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 NLogDetail GetNLogDetailWitDetails(long idNLogDetail,bool shouldRemap = false);
 NLogDetail GetNLogDetailWitDetails(long idNLogDetail, SubscriptionEntities db,bool shouldRemap = false);
 void SaveNLogDetail(NLogDetail nLogDetail);
 void SaveNLogDetail(NLogDetail nLogDetail, SubscriptionEntities db);
 void SaveOnlyNLogDetail(NLogDetail nLogDetail);
 void SaveOnlyNLogDetail(NLogDetail nLogDetail, SubscriptionEntities db);
 void DeleteNLogDetail(NLogDetail nLogDetail);
 void DeleteNLogDetail(NLogDetail nLogDetail, SubscriptionEntities db);		
  void DeletePermanentlyNLogDetail(NLogDetail nLogDetail);
 void DeletePermanentlyNLogDetail(NLogDetail nLogDetail, SubscriptionEntities db);	
	}
 	public partial interface IOrderDao
	{
  List<Order> GetAllOrders(bool shouldRemap = false);
  List<Order> GetAllOrders(SubscriptionEntities db,bool shouldRemap = false);
  BaseListReturnType<Order> GetAllOrdersByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Order, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<Order, dynamic> orderExpression = null);
  BaseListReturnType<Order> GetAllOrdersByPage(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<Order, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<Order, dynamic> orderExpression = null);
  
  BaseListReturnType<Order> GetAllOrdersByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Order, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<Order, dynamic> orderExpression = null);
  BaseListReturnType<Order> GetAllOrdersByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<Order, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<Order, dynamic> orderExpression = null);

 BaseListReturnType<Order> GetAllOrdersWithBankStatementStagingHitsDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Order, bool>> expression = null,bool shouldRemap = false, Func<Order, dynamic> orderExpression = null);
 BaseListReturnType<Order> GetAllOrdersWithBankStatementStagingHitsDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Order, bool>> expression = null,bool shouldRemap = false, Func<Order, dynamic> orderExpression = null);

 BaseListReturnType<Order> GetAllOrdersWithUserDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Order, bool>> expression = null,bool shouldRemap = false, Func<Order, dynamic> orderExpression = null);
 BaseListReturnType<Order> GetAllOrdersWithUserDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Order, bool>> expression = null,bool shouldRemap = false, Func<Order, dynamic> orderExpression = null);






BaseListReturnType<Order> GetAllOrderListByUser(long idUser);

BaseListReturnType<Order> GetAllOrderListByUser(long idUser, SubscriptionEntities db);

BaseListReturnType<Order> GetAllOrderListByUserByPage(long idUser, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<Order> GetAllOrderListByUserByPage(long idUser, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);



 BaseListReturnType<Order> GetAllOrdersWithOrderConceptDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Order, bool>> expression = null,bool shouldRemap = false, Func<Order, dynamic> orderExpression = null);
 BaseListReturnType<Order> GetAllOrdersWithOrderConceptDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Order, bool>> expression = null,bool shouldRemap = false, Func<Order, dynamic> orderExpression = null);






BaseListReturnType<Order> GetAllOrderListByOrderConcept(long idOrderConcept);

BaseListReturnType<Order> GetAllOrderListByOrderConcept(long idOrderConcept, SubscriptionEntities db);

BaseListReturnType<Order> GetAllOrderListByOrderConceptByPage(long idOrderConcept, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<Order> GetAllOrderListByOrderConceptByPage(long idOrderConcept, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);



 BaseListReturnType<Order> GetAllOrdersWithOrderStateDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Order, bool>> expression = null,bool shouldRemap = false, Func<Order, dynamic> orderExpression = null);
 BaseListReturnType<Order> GetAllOrdersWithOrderStateDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Order, bool>> expression = null,bool shouldRemap = false, Func<Order, dynamic> orderExpression = null);






BaseListReturnType<Order> GetAllOrderListByOrderState(long idOrderState);

BaseListReturnType<Order> GetAllOrderListByOrderState(long idOrderState, SubscriptionEntities db);

BaseListReturnType<Order> GetAllOrderListByOrderStateByPage(long idOrderState, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<Order> GetAllOrderListByOrderStateByPage(long idOrderState, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);



 BaseListReturnType<Order> GetAllOrdersWithOrderDetailsDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Order, bool>> expression = null,bool shouldRemap = false, Func<Order, dynamic> orderExpression = null);
 BaseListReturnType<Order> GetAllOrdersWithOrderDetailsDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Order, bool>> expression = null,bool shouldRemap = false, Func<Order, dynamic> orderExpression = null);


List<Order> GetOrderListByIdList(List<long> orderIds);

List<Order> GetOrderListByIdList(List<long> orderIds, SubscriptionEntities db);

 BaseListReturnType<Order> GetAllOrdersWithBankStatementStagingHitsDetails(bool shouldRemap = false);
 BaseListReturnType<Order> GetAllOrdersWithUserDetails(bool shouldRemap = false);
 BaseListReturnType<Order> GetAllOrdersWithOrderConceptDetails(bool shouldRemap = false);
 BaseListReturnType<Order> GetAllOrdersWithOrderStateDetails(bool shouldRemap = false);
 BaseListReturnType<Order> GetAllOrdersWithOrderDetailsDetails(bool shouldRemap = false);
 BaseListReturnType<Order> GetAllOrderWitDetails( List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<Order> GetAllOrderWitDetails( SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 Order GetOrder(long idOrder,bool shouldRemap = false);
 Order GetOrder(long idOrder, SubscriptionEntities db,bool shouldRemap = false);
 Order GetOrderWithBankStatementStagingHitsDetails(long idOrder,bool shouldRemap = false);
           List<BankStatementStagingHit> UpdateBankStatementStagingHitsForOrderWithoutSavingNewItem(List<BankStatementStagingHit> newBankStatementStagingHits,long idOrder);
    List<BankStatementStagingHit> UpdateBankStatementStagingHitsForOrderWithoutSavingNewItem(List<BankStatementStagingHit> newBankStatementStagingHits,long idOrder,SubscriptionEntities db);
          

    List<BankStatementStagingHit> UpdateBankStatementStagingHitsForOrder(List<BankStatementStagingHit> newBankStatementStagingHits,long idOrder);
    List<BankStatementStagingHit> UpdateBankStatementStagingHitsForOrder(List<BankStatementStagingHit> newBankStatementStagingHits,long idOrder,SubscriptionEntities db);
                           



 Order GetOrderWithUserDetails(long idOrder,bool shouldRemap = false);
    


 Order GetOrderWithOrderConceptDetails(long idOrder,bool shouldRemap = false);
    


 Order GetOrderWithOrderStateDetails(long idOrder,bool shouldRemap = false);
    


 Order GetOrderWithOrderDetailsDetails(long idOrder,bool shouldRemap = false);
           List<OrderDetail> UpdateOrderDetailsForOrderWithoutSavingNewItem(List<OrderDetail> newOrderDetails,long idOrder);
    List<OrderDetail> UpdateOrderDetailsForOrderWithoutSavingNewItem(List<OrderDetail> newOrderDetails,long idOrder,SubscriptionEntities db);
          

    List<OrderDetail> UpdateOrderDetailsForOrder(List<OrderDetail> newOrderDetails,long idOrder);
    List<OrderDetail> UpdateOrderDetailsForOrder(List<OrderDetail> newOrderDetails,long idOrder,SubscriptionEntities db);
                           



 Order GetOrderCustom( Expression<Func<Order, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 Order GetOrderCustom(SubscriptionEntities db, Expression<Func<Order, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<Order> GetOrderCustomList( Expression<Func<Order, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<Order, dynamic> orderExpression = null);
 BaseListReturnType<Order> GetOrderCustomList( SubscriptionEntities db , Expression<Func<Order, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<Order, dynamic> orderExpression = null);
 Order GetOrderWithDetails(long idOrder, List<string> includes = null,bool shouldRemap = false);
 Order GetOrderWithDetails(long idOrder, SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 Order GetOrderWitDetails(long idOrder,bool shouldRemap = false);
 Order GetOrderWitDetails(long idOrder, SubscriptionEntities db,bool shouldRemap = false);
 void SaveOrder(Order order);
 void SaveOrder(Order order, SubscriptionEntities db);
 void SaveOnlyOrder(Order order);
 void SaveOnlyOrder(Order order, SubscriptionEntities db);
 void DeleteOrder(Order order);
 void DeleteOrder(Order order, SubscriptionEntities db);		
  void DeletePermanentlyOrder(Order order);
 void DeletePermanentlyOrder(Order order, SubscriptionEntities db);	
	}
 	public partial interface IOrderAddressDao
	{
  List<OrderAddress> GetAllOrderAddresses(bool shouldRemap = false);
  List<OrderAddress> GetAllOrderAddresses(SubscriptionEntities db,bool shouldRemap = false);
  BaseListReturnType<OrderAddress> GetAllOrderAddressesByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<OrderAddress, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<OrderAddress, dynamic> orderExpression = null);
  BaseListReturnType<OrderAddress> GetAllOrderAddressesByPage(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<OrderAddress, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<OrderAddress, dynamic> orderExpression = null);
  
  BaseListReturnType<OrderAddress> GetAllOrderAddressesByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<OrderAddress, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<OrderAddress, dynamic> orderExpression = null);
  BaseListReturnType<OrderAddress> GetAllOrderAddressesByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<OrderAddress, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<OrderAddress, dynamic> orderExpression = null);

 BaseListReturnType<OrderAddress> GetAllOrderAddressesWithOrderConcept_OrderAddressDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<OrderAddress, bool>> expression = null,bool shouldRemap = false, Func<OrderAddress, dynamic> orderExpression = null);
 BaseListReturnType<OrderAddress> GetAllOrderAddressesWithOrderConcept_OrderAddressDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<OrderAddress, bool>> expression = null,bool shouldRemap = false, Func<OrderAddress, dynamic> orderExpression = null);


List<OrderAddress> GetOrderAddressListByIdList(List<long> orderAddressIds);

List<OrderAddress> GetOrderAddressListByIdList(List<long> orderAddressIds, SubscriptionEntities db);

 BaseListReturnType<OrderAddress> GetAllOrderAddressesWithOrderConcept_OrderAddressDetails(bool shouldRemap = false);
 BaseListReturnType<OrderAddress> GetAllOrderAddressWitDetails( List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<OrderAddress> GetAllOrderAddressWitDetails( SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 OrderAddress GetOrderAddress(long idOrderAddress,bool shouldRemap = false);
 OrderAddress GetOrderAddress(long idOrderAddress, SubscriptionEntities db,bool shouldRemap = false);
 OrderAddress GetOrderAddressWithOrderConcept_OrderAddressDetails(long idOrderAddress,bool shouldRemap = false);
           List<OrderConcept_OrderAddress> UpdateOrderConcept_OrderAddressForOrderAddressWithoutSavingNewItem(List<OrderConcept_OrderAddress> newOrderConcept_OrderAddress,long idOrderAddress);
    List<OrderConcept_OrderAddress> UpdateOrderConcept_OrderAddressForOrderAddressWithoutSavingNewItem(List<OrderConcept_OrderAddress> newOrderConcept_OrderAddress,long idOrderAddress,SubscriptionEntities db);
          

    List<OrderConcept_OrderAddress> UpdateOrderConcept_OrderAddressForOrderAddress(List<OrderConcept_OrderAddress> newOrderConcept_OrderAddress,long idOrderAddress);
    List<OrderConcept_OrderAddress> UpdateOrderConcept_OrderAddressForOrderAddress(List<OrderConcept_OrderAddress> newOrderConcept_OrderAddress,long idOrderAddress,SubscriptionEntities db);
                           



 OrderAddress GetOrderAddressCustom( Expression<Func<OrderAddress, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 OrderAddress GetOrderAddressCustom(SubscriptionEntities db, Expression<Func<OrderAddress, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<OrderAddress> GetOrderAddressCustomList( Expression<Func<OrderAddress, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<OrderAddress, dynamic> orderExpression = null);
 BaseListReturnType<OrderAddress> GetOrderAddressCustomList( SubscriptionEntities db , Expression<Func<OrderAddress, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<OrderAddress, dynamic> orderExpression = null);
 OrderAddress GetOrderAddressWithDetails(long idOrderAddress, List<string> includes = null,bool shouldRemap = false);
 OrderAddress GetOrderAddressWithDetails(long idOrderAddress, SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 OrderAddress GetOrderAddressWitDetails(long idOrderAddress,bool shouldRemap = false);
 OrderAddress GetOrderAddressWitDetails(long idOrderAddress, SubscriptionEntities db,bool shouldRemap = false);
 void SaveOrderAddress(OrderAddress orderAddress);
 void SaveOrderAddress(OrderAddress orderAddress, SubscriptionEntities db);
 void SaveOnlyOrderAddress(OrderAddress orderAddress);
 void SaveOnlyOrderAddress(OrderAddress orderAddress, SubscriptionEntities db);
 void DeleteOrderAddress(OrderAddress orderAddress);
 void DeleteOrderAddress(OrderAddress orderAddress, SubscriptionEntities db);		
  void DeletePermanentlyOrderAddress(OrderAddress orderAddress);
 void DeletePermanentlyOrderAddress(OrderAddress orderAddress, SubscriptionEntities db);	
	}
 	public partial interface IOrderCompanyDao
	{
  List<OrderCompany> GetAllOrderCompanies(bool shouldRemap = false);
  List<OrderCompany> GetAllOrderCompanies(SubscriptionEntities db,bool shouldRemap = false);
  BaseListReturnType<OrderCompany> GetAllOrderCompaniesByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<OrderCompany, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<OrderCompany, dynamic> orderExpression = null);
  BaseListReturnType<OrderCompany> GetAllOrderCompaniesByPage(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<OrderCompany, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<OrderCompany, dynamic> orderExpression = null);
  
  BaseListReturnType<OrderCompany> GetAllOrderCompaniesByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<OrderCompany, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<OrderCompany, dynamic> orderExpression = null);
  BaseListReturnType<OrderCompany> GetAllOrderCompaniesByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<OrderCompany, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<OrderCompany, dynamic> orderExpression = null);

 BaseListReturnType<OrderCompany> GetAllOrderCompaniesWithOrderConceptsDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<OrderCompany, bool>> expression = null,bool shouldRemap = false, Func<OrderCompany, dynamic> orderExpression = null);
 BaseListReturnType<OrderCompany> GetAllOrderCompaniesWithOrderConceptsDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<OrderCompany, bool>> expression = null,bool shouldRemap = false, Func<OrderCompany, dynamic> orderExpression = null);


List<OrderCompany> GetOrderCompanyListByIdList(List<long> orderCompanyIds);

List<OrderCompany> GetOrderCompanyListByIdList(List<long> orderCompanyIds, SubscriptionEntities db);

 BaseListReturnType<OrderCompany> GetAllOrderCompaniesWithOrderConceptsDetails(bool shouldRemap = false);
 BaseListReturnType<OrderCompany> GetAllOrderCompanyWitDetails( List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<OrderCompany> GetAllOrderCompanyWitDetails( SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 OrderCompany GetOrderCompany(long idOrderCompany,bool shouldRemap = false);
 OrderCompany GetOrderCompany(long idOrderCompany, SubscriptionEntities db,bool shouldRemap = false);
 OrderCompany GetOrderCompanyWithOrderConceptsDetails(long idOrderCompany,bool shouldRemap = false);
           List<OrderConcept> UpdateOrderConceptsForOrderCompanyWithoutSavingNewItem(List<OrderConcept> newOrderConcepts,long idOrderCompany);
    List<OrderConcept> UpdateOrderConceptsForOrderCompanyWithoutSavingNewItem(List<OrderConcept> newOrderConcepts,long idOrderCompany,SubscriptionEntities db);
          

    List<OrderConcept> UpdateOrderConceptsForOrderCompany(List<OrderConcept> newOrderConcepts,long idOrderCompany);
    List<OrderConcept> UpdateOrderConceptsForOrderCompany(List<OrderConcept> newOrderConcepts,long idOrderCompany,SubscriptionEntities db);
                           



 OrderCompany GetOrderCompanyCustom( Expression<Func<OrderCompany, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 OrderCompany GetOrderCompanyCustom(SubscriptionEntities db, Expression<Func<OrderCompany, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<OrderCompany> GetOrderCompanyCustomList( Expression<Func<OrderCompany, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<OrderCompany, dynamic> orderExpression = null);
 BaseListReturnType<OrderCompany> GetOrderCompanyCustomList( SubscriptionEntities db , Expression<Func<OrderCompany, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<OrderCompany, dynamic> orderExpression = null);
 OrderCompany GetOrderCompanyWithDetails(long idOrderCompany, List<string> includes = null,bool shouldRemap = false);
 OrderCompany GetOrderCompanyWithDetails(long idOrderCompany, SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 OrderCompany GetOrderCompanyWitDetails(long idOrderCompany,bool shouldRemap = false);
 OrderCompany GetOrderCompanyWitDetails(long idOrderCompany, SubscriptionEntities db,bool shouldRemap = false);
 void SaveOrderCompany(OrderCompany orderCompany);
 void SaveOrderCompany(OrderCompany orderCompany, SubscriptionEntities db);
 void SaveOnlyOrderCompany(OrderCompany orderCompany);
 void SaveOnlyOrderCompany(OrderCompany orderCompany, SubscriptionEntities db);
 void DeleteOrderCompany(OrderCompany orderCompany);
 void DeleteOrderCompany(OrderCompany orderCompany, SubscriptionEntities db);		
  void DeletePermanentlyOrderCompany(OrderCompany orderCompany);
 void DeletePermanentlyOrderCompany(OrderCompany orderCompany, SubscriptionEntities db);	
	}
 	public partial interface IOrderConceptDao
	{
  List<OrderConcept> GetAllOrderConcepts(bool shouldRemap = false);
  List<OrderConcept> GetAllOrderConcepts(SubscriptionEntities db,bool shouldRemap = false);
  BaseListReturnType<OrderConcept> GetAllOrderConceptsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<OrderConcept, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<OrderConcept, dynamic> orderExpression = null);
  BaseListReturnType<OrderConcept> GetAllOrderConceptsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<OrderConcept, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<OrderConcept, dynamic> orderExpression = null);
  
  BaseListReturnType<OrderConcept> GetAllOrderConceptsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<OrderConcept, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<OrderConcept, dynamic> orderExpression = null);
  BaseListReturnType<OrderConcept> GetAllOrderConceptsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<OrderConcept, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<OrderConcept, dynamic> orderExpression = null);

 BaseListReturnType<OrderConcept> GetAllOrderConceptsWithOrdersDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<OrderConcept, bool>> expression = null,bool shouldRemap = false, Func<OrderConcept, dynamic> orderExpression = null);
 BaseListReturnType<OrderConcept> GetAllOrderConceptsWithOrdersDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<OrderConcept, bool>> expression = null,bool shouldRemap = false, Func<OrderConcept, dynamic> orderExpression = null);

 BaseListReturnType<OrderConcept> GetAllOrderConceptsWithOrderCompanyDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<OrderConcept, bool>> expression = null,bool shouldRemap = false, Func<OrderConcept, dynamic> orderExpression = null);
 BaseListReturnType<OrderConcept> GetAllOrderConceptsWithOrderCompanyDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<OrderConcept, bool>> expression = null,bool shouldRemap = false, Func<OrderConcept, dynamic> orderExpression = null);






BaseListReturnType<OrderConcept> GetAllOrderConceptListByOrderCompany(long idOrderCompany);

BaseListReturnType<OrderConcept> GetAllOrderConceptListByOrderCompany(long idOrderCompany, SubscriptionEntities db);

BaseListReturnType<OrderConcept> GetAllOrderConceptListByOrderCompanyByPage(long idOrderCompany, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<OrderConcept> GetAllOrderConceptListByOrderCompanyByPage(long idOrderCompany, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);



 BaseListReturnType<OrderConcept> GetAllOrderConceptsWithOrderConcept_ContactTypeDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<OrderConcept, bool>> expression = null,bool shouldRemap = false, Func<OrderConcept, dynamic> orderExpression = null);
 BaseListReturnType<OrderConcept> GetAllOrderConceptsWithOrderConcept_ContactTypeDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<OrderConcept, bool>> expression = null,bool shouldRemap = false, Func<OrderConcept, dynamic> orderExpression = null);

 BaseListReturnType<OrderConcept> GetAllOrderConceptsWithOrderPersonDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<OrderConcept, bool>> expression = null,bool shouldRemap = false, Func<OrderConcept, dynamic> orderExpression = null);
 BaseListReturnType<OrderConcept> GetAllOrderConceptsWithOrderPersonDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<OrderConcept, bool>> expression = null,bool shouldRemap = false, Func<OrderConcept, dynamic> orderExpression = null);






BaseListReturnType<OrderConcept> GetAllOrderConceptListByOrderPerson(long idOrderPerson);

BaseListReturnType<OrderConcept> GetAllOrderConceptListByOrderPerson(long idOrderPerson, SubscriptionEntities db);

BaseListReturnType<OrderConcept> GetAllOrderConceptListByOrderPersonByPage(long idOrderPerson, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<OrderConcept> GetAllOrderConceptListByOrderPersonByPage(long idOrderPerson, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);



 BaseListReturnType<OrderConcept> GetAllOrderConceptsWithOrderConcept_OrderAddressDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<OrderConcept, bool>> expression = null,bool shouldRemap = false, Func<OrderConcept, dynamic> orderExpression = null);
 BaseListReturnType<OrderConcept> GetAllOrderConceptsWithOrderConcept_OrderAddressDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<OrderConcept, bool>> expression = null,bool shouldRemap = false, Func<OrderConcept, dynamic> orderExpression = null);


List<OrderConcept> GetOrderConceptListByIdList(List<long> orderConceptIds);

List<OrderConcept> GetOrderConceptListByIdList(List<long> orderConceptIds, SubscriptionEntities db);

 BaseListReturnType<OrderConcept> GetAllOrderConceptsWithOrdersDetails(bool shouldRemap = false);
 BaseListReturnType<OrderConcept> GetAllOrderConceptsWithOrderCompanyDetails(bool shouldRemap = false);
 BaseListReturnType<OrderConcept> GetAllOrderConceptsWithOrderConcept_ContactTypeDetails(bool shouldRemap = false);
 BaseListReturnType<OrderConcept> GetAllOrderConceptsWithOrderPersonDetails(bool shouldRemap = false);
 BaseListReturnType<OrderConcept> GetAllOrderConceptsWithOrderConcept_OrderAddressDetails(bool shouldRemap = false);
 BaseListReturnType<OrderConcept> GetAllOrderConceptWitDetails( List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<OrderConcept> GetAllOrderConceptWitDetails( SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 OrderConcept GetOrderConcept(long idOrderConcept,bool shouldRemap = false);
 OrderConcept GetOrderConcept(long idOrderConcept, SubscriptionEntities db,bool shouldRemap = false);
 OrderConcept GetOrderConceptWithOrdersDetails(long idOrderConcept,bool shouldRemap = false);
           List<Order> UpdateOrdersForOrderConceptWithoutSavingNewItem(List<Order> newOrders,long idOrderConcept);
    List<Order> UpdateOrdersForOrderConceptWithoutSavingNewItem(List<Order> newOrders,long idOrderConcept,SubscriptionEntities db);
          

    List<Order> UpdateOrdersForOrderConcept(List<Order> newOrders,long idOrderConcept);
    List<Order> UpdateOrdersForOrderConcept(List<Order> newOrders,long idOrderConcept,SubscriptionEntities db);
                           



 OrderConcept GetOrderConceptWithOrderCompanyDetails(long idOrderConcept,bool shouldRemap = false);
    


 OrderConcept GetOrderConceptWithOrderConcept_ContactTypeDetails(long idOrderConcept,bool shouldRemap = false);
           List<OrderConcept_ContactType> UpdateOrderConcept_ContactTypeForOrderConceptWithoutSavingNewItem(List<OrderConcept_ContactType> newOrderConcept_ContactType,long idOrderConcept);
    List<OrderConcept_ContactType> UpdateOrderConcept_ContactTypeForOrderConceptWithoutSavingNewItem(List<OrderConcept_ContactType> newOrderConcept_ContactType,long idOrderConcept,SubscriptionEntities db);
          

    List<OrderConcept_ContactType> UpdateOrderConcept_ContactTypeForOrderConcept(List<OrderConcept_ContactType> newOrderConcept_ContactType,long idOrderConcept);
    List<OrderConcept_ContactType> UpdateOrderConcept_ContactTypeForOrderConcept(List<OrderConcept_ContactType> newOrderConcept_ContactType,long idOrderConcept,SubscriptionEntities db);
                           



 OrderConcept GetOrderConceptWithOrderPersonDetails(long idOrderConcept,bool shouldRemap = false);
    


 OrderConcept GetOrderConceptWithOrderConcept_OrderAddressDetails(long idOrderConcept,bool shouldRemap = false);
           List<OrderConcept_OrderAddress> UpdateOrderConcept_OrderAddressForOrderConceptWithoutSavingNewItem(List<OrderConcept_OrderAddress> newOrderConcept_OrderAddress,long idOrderConcept);
    List<OrderConcept_OrderAddress> UpdateOrderConcept_OrderAddressForOrderConceptWithoutSavingNewItem(List<OrderConcept_OrderAddress> newOrderConcept_OrderAddress,long idOrderConcept,SubscriptionEntities db);
          

    List<OrderConcept_OrderAddress> UpdateOrderConcept_OrderAddressForOrderConcept(List<OrderConcept_OrderAddress> newOrderConcept_OrderAddress,long idOrderConcept);
    List<OrderConcept_OrderAddress> UpdateOrderConcept_OrderAddressForOrderConcept(List<OrderConcept_OrderAddress> newOrderConcept_OrderAddress,long idOrderConcept,SubscriptionEntities db);
                           



 OrderConcept GetOrderConceptCustom( Expression<Func<OrderConcept, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 OrderConcept GetOrderConceptCustom(SubscriptionEntities db, Expression<Func<OrderConcept, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<OrderConcept> GetOrderConceptCustomList( Expression<Func<OrderConcept, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<OrderConcept, dynamic> orderExpression = null);
 BaseListReturnType<OrderConcept> GetOrderConceptCustomList( SubscriptionEntities db , Expression<Func<OrderConcept, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<OrderConcept, dynamic> orderExpression = null);
 OrderConcept GetOrderConceptWithDetails(long idOrderConcept, List<string> includes = null,bool shouldRemap = false);
 OrderConcept GetOrderConceptWithDetails(long idOrderConcept, SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 OrderConcept GetOrderConceptWitDetails(long idOrderConcept,bool shouldRemap = false);
 OrderConcept GetOrderConceptWitDetails(long idOrderConcept, SubscriptionEntities db,bool shouldRemap = false);
 void SaveOrderConcept(OrderConcept orderConcept);
 void SaveOrderConcept(OrderConcept orderConcept, SubscriptionEntities db);
 void SaveOnlyOrderConcept(OrderConcept orderConcept);
 void SaveOnlyOrderConcept(OrderConcept orderConcept, SubscriptionEntities db);
 void DeleteOrderConcept(OrderConcept orderConcept);
 void DeleteOrderConcept(OrderConcept orderConcept, SubscriptionEntities db);		
  void DeletePermanentlyOrderConcept(OrderConcept orderConcept);
 void DeletePermanentlyOrderConcept(OrderConcept orderConcept, SubscriptionEntities db);	
	}
 	public partial interface IOrderConcept_ContactTypeDao
	{
  List<OrderConcept_ContactType> GetAllOrderConcept_ContactType(bool shouldRemap = false);
  List<OrderConcept_ContactType> GetAllOrderConcept_ContactType(SubscriptionEntities db,bool shouldRemap = false);
  BaseListReturnType<OrderConcept_ContactType> GetAllOrderConcept_ContactTypeByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<OrderConcept_ContactType, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<OrderConcept_ContactType, dynamic> orderExpression = null);
  BaseListReturnType<OrderConcept_ContactType> GetAllOrderConcept_ContactTypeByPage(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<OrderConcept_ContactType, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<OrderConcept_ContactType, dynamic> orderExpression = null);
  
  BaseListReturnType<OrderConcept_ContactType> GetAllOrderConcept_ContactTypeByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<OrderConcept_ContactType, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<OrderConcept_ContactType, dynamic> orderExpression = null);
  BaseListReturnType<OrderConcept_ContactType> GetAllOrderConcept_ContactTypeByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<OrderConcept_ContactType, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<OrderConcept_ContactType, dynamic> orderExpression = null);

 BaseListReturnType<OrderConcept_ContactType> GetAllOrderConcept_ContactTypeWithContactTypeDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<OrderConcept_ContactType, bool>> expression = null,bool shouldRemap = false, Func<OrderConcept_ContactType, dynamic> orderExpression = null);
 BaseListReturnType<OrderConcept_ContactType> GetAllOrderConcept_ContactTypeWithContactTypeDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<OrderConcept_ContactType, bool>> expression = null,bool shouldRemap = false, Func<OrderConcept_ContactType, dynamic> orderExpression = null);






BaseListReturnType<OrderConcept_ContactType> GetAllOrderConcept_ContactTypeListByContactType(long idContactType);

BaseListReturnType<OrderConcept_ContactType> GetAllOrderConcept_ContactTypeListByContactType(long idContactType, SubscriptionEntities db);

BaseListReturnType<OrderConcept_ContactType> GetAllOrderConcept_ContactTypeListByContactTypeByPage(long idContactType, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<OrderConcept_ContactType> GetAllOrderConcept_ContactTypeListByContactTypeByPage(long idContactType, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);



 BaseListReturnType<OrderConcept_ContactType> GetAllOrderConcept_ContactTypeWithOrderConceptDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<OrderConcept_ContactType, bool>> expression = null,bool shouldRemap = false, Func<OrderConcept_ContactType, dynamic> orderExpression = null);
 BaseListReturnType<OrderConcept_ContactType> GetAllOrderConcept_ContactTypeWithOrderConceptDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<OrderConcept_ContactType, bool>> expression = null,bool shouldRemap = false, Func<OrderConcept_ContactType, dynamic> orderExpression = null);






BaseListReturnType<OrderConcept_ContactType> GetAllOrderConcept_ContactTypeListByOrderConcept(long idOrderConcept);

BaseListReturnType<OrderConcept_ContactType> GetAllOrderConcept_ContactTypeListByOrderConcept(long idOrderConcept, SubscriptionEntities db);

BaseListReturnType<OrderConcept_ContactType> GetAllOrderConcept_ContactTypeListByOrderConceptByPage(long idOrderConcept, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<OrderConcept_ContactType> GetAllOrderConcept_ContactTypeListByOrderConceptByPage(long idOrderConcept, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);




List<OrderConcept_ContactType> GetOrderConcept_ContactTypeListByIdList(List<long> orderConcept_ContactTypeIds);

List<OrderConcept_ContactType> GetOrderConcept_ContactTypeListByIdList(List<long> orderConcept_ContactTypeIds, SubscriptionEntities db);

 BaseListReturnType<OrderConcept_ContactType> GetAllOrderConcept_ContactTypeWithContactTypeDetails(bool shouldRemap = false);
 BaseListReturnType<OrderConcept_ContactType> GetAllOrderConcept_ContactTypeWithOrderConceptDetails(bool shouldRemap = false);
 BaseListReturnType<OrderConcept_ContactType> GetAllOrderConcept_ContactTypeWitDetails( List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<OrderConcept_ContactType> GetAllOrderConcept_ContactTypeWitDetails( SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 OrderConcept_ContactType GetOrderConcept_ContactType(long idOrderConcept_ContactType,bool shouldRemap = false);
 OrderConcept_ContactType GetOrderConcept_ContactType(long idOrderConcept_ContactType, SubscriptionEntities db,bool shouldRemap = false);
 OrderConcept_ContactType GetOrderConcept_ContactTypeWithContactTypeDetails(long idOrderConcept_ContactType,bool shouldRemap = false);
    


 OrderConcept_ContactType GetOrderConcept_ContactTypeWithOrderConceptDetails(long idOrderConcept_ContactType,bool shouldRemap = false);
    


 OrderConcept_ContactType GetOrderConcept_ContactTypeCustom( Expression<Func<OrderConcept_ContactType, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 OrderConcept_ContactType GetOrderConcept_ContactTypeCustom(SubscriptionEntities db, Expression<Func<OrderConcept_ContactType, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<OrderConcept_ContactType> GetOrderConcept_ContactTypeCustomList( Expression<Func<OrderConcept_ContactType, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<OrderConcept_ContactType, dynamic> orderExpression = null);
 BaseListReturnType<OrderConcept_ContactType> GetOrderConcept_ContactTypeCustomList( SubscriptionEntities db , Expression<Func<OrderConcept_ContactType, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<OrderConcept_ContactType, dynamic> orderExpression = null);
 OrderConcept_ContactType GetOrderConcept_ContactTypeWithDetails(long idOrderConcept_ContactType, List<string> includes = null,bool shouldRemap = false);
 OrderConcept_ContactType GetOrderConcept_ContactTypeWithDetails(long idOrderConcept_ContactType, SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 OrderConcept_ContactType GetOrderConcept_ContactTypeWitDetails(long idOrderConcept_ContactType,bool shouldRemap = false);
 OrderConcept_ContactType GetOrderConcept_ContactTypeWitDetails(long idOrderConcept_ContactType, SubscriptionEntities db,bool shouldRemap = false);
 void SaveOrderConcept_ContactType(OrderConcept_ContactType orderConcept_ContactType);
 void SaveOrderConcept_ContactType(OrderConcept_ContactType orderConcept_ContactType, SubscriptionEntities db);
 void SaveOnlyOrderConcept_ContactType(OrderConcept_ContactType orderConcept_ContactType);
 void SaveOnlyOrderConcept_ContactType(OrderConcept_ContactType orderConcept_ContactType, SubscriptionEntities db);
 void DeleteOrderConcept_ContactType(OrderConcept_ContactType orderConcept_ContactType);
 void DeleteOrderConcept_ContactType(OrderConcept_ContactType orderConcept_ContactType, SubscriptionEntities db);		
  void DeletePermanentlyOrderConcept_ContactType(OrderConcept_ContactType orderConcept_ContactType);
 void DeletePermanentlyOrderConcept_ContactType(OrderConcept_ContactType orderConcept_ContactType, SubscriptionEntities db);	
	}
 	public partial interface IOrderConcept_OrderAddressDao
	{
  List<OrderConcept_OrderAddress> GetAllOrderConcept_OrderAddress(bool shouldRemap = false);
  List<OrderConcept_OrderAddress> GetAllOrderConcept_OrderAddress(SubscriptionEntities db,bool shouldRemap = false);
  BaseListReturnType<OrderConcept_OrderAddress> GetAllOrderConcept_OrderAddressByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<OrderConcept_OrderAddress, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<OrderConcept_OrderAddress, dynamic> orderExpression = null);
  BaseListReturnType<OrderConcept_OrderAddress> GetAllOrderConcept_OrderAddressByPage(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<OrderConcept_OrderAddress, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<OrderConcept_OrderAddress, dynamic> orderExpression = null);
  
  BaseListReturnType<OrderConcept_OrderAddress> GetAllOrderConcept_OrderAddressByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<OrderConcept_OrderAddress, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<OrderConcept_OrderAddress, dynamic> orderExpression = null);
  BaseListReturnType<OrderConcept_OrderAddress> GetAllOrderConcept_OrderAddressByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<OrderConcept_OrderAddress, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<OrderConcept_OrderAddress, dynamic> orderExpression = null);

 BaseListReturnType<OrderConcept_OrderAddress> GetAllOrderConcept_OrderAddressWithOrderAddressDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<OrderConcept_OrderAddress, bool>> expression = null,bool shouldRemap = false, Func<OrderConcept_OrderAddress, dynamic> orderExpression = null);
 BaseListReturnType<OrderConcept_OrderAddress> GetAllOrderConcept_OrderAddressWithOrderAddressDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<OrderConcept_OrderAddress, bool>> expression = null,bool shouldRemap = false, Func<OrderConcept_OrderAddress, dynamic> orderExpression = null);






BaseListReturnType<OrderConcept_OrderAddress> GetAllOrderConcept_OrderAddressListByOrderAddress(long idOrderAddress);

BaseListReturnType<OrderConcept_OrderAddress> GetAllOrderConcept_OrderAddressListByOrderAddress(long idOrderAddress, SubscriptionEntities db);

BaseListReturnType<OrderConcept_OrderAddress> GetAllOrderConcept_OrderAddressListByOrderAddressByPage(long idOrderAddress, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<OrderConcept_OrderAddress> GetAllOrderConcept_OrderAddressListByOrderAddressByPage(long idOrderAddress, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);



 BaseListReturnType<OrderConcept_OrderAddress> GetAllOrderConcept_OrderAddressWithOrderConceptDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<OrderConcept_OrderAddress, bool>> expression = null,bool shouldRemap = false, Func<OrderConcept_OrderAddress, dynamic> orderExpression = null);
 BaseListReturnType<OrderConcept_OrderAddress> GetAllOrderConcept_OrderAddressWithOrderConceptDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<OrderConcept_OrderAddress, bool>> expression = null,bool shouldRemap = false, Func<OrderConcept_OrderAddress, dynamic> orderExpression = null);






BaseListReturnType<OrderConcept_OrderAddress> GetAllOrderConcept_OrderAddressListByOrderConcept(long idOrderConcept);

BaseListReturnType<OrderConcept_OrderAddress> GetAllOrderConcept_OrderAddressListByOrderConcept(long idOrderConcept, SubscriptionEntities db);

BaseListReturnType<OrderConcept_OrderAddress> GetAllOrderConcept_OrderAddressListByOrderConceptByPage(long idOrderConcept, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<OrderConcept_OrderAddress> GetAllOrderConcept_OrderAddressListByOrderConceptByPage(long idOrderConcept, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);




List<OrderConcept_OrderAddress> GetOrderConcept_OrderAddressListByIdList(List<long> orderConcept_OrderAddressIds);

List<OrderConcept_OrderAddress> GetOrderConcept_OrderAddressListByIdList(List<long> orderConcept_OrderAddressIds, SubscriptionEntities db);

 BaseListReturnType<OrderConcept_OrderAddress> GetAllOrderConcept_OrderAddressWithOrderAddressDetails(bool shouldRemap = false);
 BaseListReturnType<OrderConcept_OrderAddress> GetAllOrderConcept_OrderAddressWithOrderConceptDetails(bool shouldRemap = false);
 BaseListReturnType<OrderConcept_OrderAddress> GetAllOrderConcept_OrderAddressWitDetails( List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<OrderConcept_OrderAddress> GetAllOrderConcept_OrderAddressWitDetails( SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 OrderConcept_OrderAddress GetOrderConcept_OrderAddress(long idOrderConcept_OrderAddress,bool shouldRemap = false);
 OrderConcept_OrderAddress GetOrderConcept_OrderAddress(long idOrderConcept_OrderAddress, SubscriptionEntities db,bool shouldRemap = false);
 OrderConcept_OrderAddress GetOrderConcept_OrderAddressWithOrderAddressDetails(long idOrderConcept_OrderAddress,bool shouldRemap = false);
    


 OrderConcept_OrderAddress GetOrderConcept_OrderAddressWithOrderConceptDetails(long idOrderConcept_OrderAddress,bool shouldRemap = false);
    


 OrderConcept_OrderAddress GetOrderConcept_OrderAddressCustom( Expression<Func<OrderConcept_OrderAddress, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 OrderConcept_OrderAddress GetOrderConcept_OrderAddressCustom(SubscriptionEntities db, Expression<Func<OrderConcept_OrderAddress, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<OrderConcept_OrderAddress> GetOrderConcept_OrderAddressCustomList( Expression<Func<OrderConcept_OrderAddress, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<OrderConcept_OrderAddress, dynamic> orderExpression = null);
 BaseListReturnType<OrderConcept_OrderAddress> GetOrderConcept_OrderAddressCustomList( SubscriptionEntities db , Expression<Func<OrderConcept_OrderAddress, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<OrderConcept_OrderAddress, dynamic> orderExpression = null);
 OrderConcept_OrderAddress GetOrderConcept_OrderAddressWithDetails(long idOrderConcept_OrderAddress, List<string> includes = null,bool shouldRemap = false);
 OrderConcept_OrderAddress GetOrderConcept_OrderAddressWithDetails(long idOrderConcept_OrderAddress, SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 OrderConcept_OrderAddress GetOrderConcept_OrderAddressWitDetails(long idOrderConcept_OrderAddress,bool shouldRemap = false);
 OrderConcept_OrderAddress GetOrderConcept_OrderAddressWitDetails(long idOrderConcept_OrderAddress, SubscriptionEntities db,bool shouldRemap = false);
 void SaveOrderConcept_OrderAddress(OrderConcept_OrderAddress orderConcept_OrderAddress);
 void SaveOrderConcept_OrderAddress(OrderConcept_OrderAddress orderConcept_OrderAddress, SubscriptionEntities db);
 void SaveOnlyOrderConcept_OrderAddress(OrderConcept_OrderAddress orderConcept_OrderAddress);
 void SaveOnlyOrderConcept_OrderAddress(OrderConcept_OrderAddress orderConcept_OrderAddress, SubscriptionEntities db);
 void DeleteOrderConcept_OrderAddress(OrderConcept_OrderAddress orderConcept_OrderAddress);
 void DeleteOrderConcept_OrderAddress(OrderConcept_OrderAddress orderConcept_OrderAddress, SubscriptionEntities db);		
  void DeletePermanentlyOrderConcept_OrderAddress(OrderConcept_OrderAddress orderConcept_OrderAddress);
 void DeletePermanentlyOrderConcept_OrderAddress(OrderConcept_OrderAddress orderConcept_OrderAddress, SubscriptionEntities db);	
	}
 	public partial interface IOrderDetailDao
	{
  List<OrderDetail> GetAllOrderDetails(bool shouldRemap = false);
  List<OrderDetail> GetAllOrderDetails(SubscriptionEntities db,bool shouldRemap = false);
  BaseListReturnType<OrderDetail> GetAllOrderDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<OrderDetail, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<OrderDetail, dynamic> orderExpression = null);
  BaseListReturnType<OrderDetail> GetAllOrderDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<OrderDetail, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<OrderDetail, dynamic> orderExpression = null);
  
  BaseListReturnType<OrderDetail> GetAllOrderDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<OrderDetail, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<OrderDetail, dynamic> orderExpression = null);
  BaseListReturnType<OrderDetail> GetAllOrderDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<OrderDetail, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<OrderDetail, dynamic> orderExpression = null);

 BaseListReturnType<OrderDetail> GetAllOrderDetailsWithProductDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<OrderDetail, bool>> expression = null,bool shouldRemap = false, Func<OrderDetail, dynamic> orderExpression = null);
 BaseListReturnType<OrderDetail> GetAllOrderDetailsWithProductDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<OrderDetail, bool>> expression = null,bool shouldRemap = false, Func<OrderDetail, dynamic> orderExpression = null);






BaseListReturnType<OrderDetail> GetAllOrderDetailListByProduct(long idProduct);

BaseListReturnType<OrderDetail> GetAllOrderDetailListByProduct(long idProduct, SubscriptionEntities db);

BaseListReturnType<OrderDetail> GetAllOrderDetailListByProductByPage(long idProduct, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<OrderDetail> GetAllOrderDetailListByProductByPage(long idProduct, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);



 BaseListReturnType<OrderDetail> GetAllOrderDetailsWithOrderDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<OrderDetail, bool>> expression = null,bool shouldRemap = false, Func<OrderDetail, dynamic> orderExpression = null);
 BaseListReturnType<OrderDetail> GetAllOrderDetailsWithOrderDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<OrderDetail, bool>> expression = null,bool shouldRemap = false, Func<OrderDetail, dynamic> orderExpression = null);






BaseListReturnType<OrderDetail> GetAllOrderDetailListByOrder(long idOrder);

BaseListReturnType<OrderDetail> GetAllOrderDetailListByOrder(long idOrder, SubscriptionEntities db);

BaseListReturnType<OrderDetail> GetAllOrderDetailListByOrderByPage(long idOrder, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<OrderDetail> GetAllOrderDetailListByOrderByPage(long idOrder, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);




List<OrderDetail> GetOrderDetailListByIdList(List<long> orderDetailIds);

List<OrderDetail> GetOrderDetailListByIdList(List<long> orderDetailIds, SubscriptionEntities db);

 BaseListReturnType<OrderDetail> GetAllOrderDetailsWithProductDetails(bool shouldRemap = false);
 BaseListReturnType<OrderDetail> GetAllOrderDetailsWithOrderDetails(bool shouldRemap = false);
 BaseListReturnType<OrderDetail> GetAllOrderDetailWitDetails( List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<OrderDetail> GetAllOrderDetailWitDetails( SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 OrderDetail GetOrderDetail(long idOrderDetail,bool shouldRemap = false);
 OrderDetail GetOrderDetail(long idOrderDetail, SubscriptionEntities db,bool shouldRemap = false);
 OrderDetail GetOrderDetailWithProductDetails(long idOrderDetail,bool shouldRemap = false);
    


 OrderDetail GetOrderDetailWithOrderDetails(long idOrderDetail,bool shouldRemap = false);
    


 OrderDetail GetOrderDetailCustom( Expression<Func<OrderDetail, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 OrderDetail GetOrderDetailCustom(SubscriptionEntities db, Expression<Func<OrderDetail, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<OrderDetail> GetOrderDetailCustomList( Expression<Func<OrderDetail, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<OrderDetail, dynamic> orderExpression = null);
 BaseListReturnType<OrderDetail> GetOrderDetailCustomList( SubscriptionEntities db , Expression<Func<OrderDetail, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<OrderDetail, dynamic> orderExpression = null);
 OrderDetail GetOrderDetailWithDetails(long idOrderDetail, List<string> includes = null,bool shouldRemap = false);
 OrderDetail GetOrderDetailWithDetails(long idOrderDetail, SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 OrderDetail GetOrderDetailWitDetails(long idOrderDetail,bool shouldRemap = false);
 OrderDetail GetOrderDetailWitDetails(long idOrderDetail, SubscriptionEntities db,bool shouldRemap = false);
 void SaveOrderDetail(OrderDetail orderDetail);
 void SaveOrderDetail(OrderDetail orderDetail, SubscriptionEntities db);
 void SaveOnlyOrderDetail(OrderDetail orderDetail);
 void SaveOnlyOrderDetail(OrderDetail orderDetail, SubscriptionEntities db);
 void DeleteOrderDetail(OrderDetail orderDetail);
 void DeleteOrderDetail(OrderDetail orderDetail, SubscriptionEntities db);		
  void DeletePermanentlyOrderDetail(OrderDetail orderDetail);
 void DeletePermanentlyOrderDetail(OrderDetail orderDetail, SubscriptionEntities db);	
	}
 	public partial interface IOrderPersonDao
	{
  List<OrderPerson> GetAllOrderPersons(bool shouldRemap = false);
  List<OrderPerson> GetAllOrderPersons(SubscriptionEntities db,bool shouldRemap = false);
  BaseListReturnType<OrderPerson> GetAllOrderPersonsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<OrderPerson, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<OrderPerson, dynamic> orderExpression = null);
  BaseListReturnType<OrderPerson> GetAllOrderPersonsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<OrderPerson, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<OrderPerson, dynamic> orderExpression = null);
  
  BaseListReturnType<OrderPerson> GetAllOrderPersonsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<OrderPerson, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<OrderPerson, dynamic> orderExpression = null);
  BaseListReturnType<OrderPerson> GetAllOrderPersonsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<OrderPerson, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<OrderPerson, dynamic> orderExpression = null);

 BaseListReturnType<OrderPerson> GetAllOrderPersonsWithTitleDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<OrderPerson, bool>> expression = null,bool shouldRemap = false, Func<OrderPerson, dynamic> orderExpression = null);
 BaseListReturnType<OrderPerson> GetAllOrderPersonsWithTitleDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<OrderPerson, bool>> expression = null,bool shouldRemap = false, Func<OrderPerson, dynamic> orderExpression = null);






BaseListReturnType<OrderPerson> GetAllOrderPersonListByTitle(long idTitle);

BaseListReturnType<OrderPerson> GetAllOrderPersonListByTitle(long idTitle, SubscriptionEntities db);

BaseListReturnType<OrderPerson> GetAllOrderPersonListByTitleByPage(long idTitle, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<OrderPerson> GetAllOrderPersonListByTitleByPage(long idTitle, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);



 BaseListReturnType<OrderPerson> GetAllOrderPersonsWithOrderConceptsDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<OrderPerson, bool>> expression = null,bool shouldRemap = false, Func<OrderPerson, dynamic> orderExpression = null);
 BaseListReturnType<OrderPerson> GetAllOrderPersonsWithOrderConceptsDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<OrderPerson, bool>> expression = null,bool shouldRemap = false, Func<OrderPerson, dynamic> orderExpression = null);


List<OrderPerson> GetOrderPersonListByIdList(List<long> orderPersonIds);

List<OrderPerson> GetOrderPersonListByIdList(List<long> orderPersonIds, SubscriptionEntities db);

 BaseListReturnType<OrderPerson> GetAllOrderPersonsWithTitleDetails(bool shouldRemap = false);
 BaseListReturnType<OrderPerson> GetAllOrderPersonsWithOrderConceptsDetails(bool shouldRemap = false);
 BaseListReturnType<OrderPerson> GetAllOrderPersonWitDetails( List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<OrderPerson> GetAllOrderPersonWitDetails( SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 OrderPerson GetOrderPerson(long idOrderPerson,bool shouldRemap = false);
 OrderPerson GetOrderPerson(long idOrderPerson, SubscriptionEntities db,bool shouldRemap = false);
 OrderPerson GetOrderPersonWithTitleDetails(long idOrderPerson,bool shouldRemap = false);
    


 OrderPerson GetOrderPersonWithOrderConceptsDetails(long idOrderPerson,bool shouldRemap = false);
           List<OrderConcept> UpdateOrderConceptsForOrderPersonWithoutSavingNewItem(List<OrderConcept> newOrderConcepts,long idOrderPerson);
    List<OrderConcept> UpdateOrderConceptsForOrderPersonWithoutSavingNewItem(List<OrderConcept> newOrderConcepts,long idOrderPerson,SubscriptionEntities db);
          

    List<OrderConcept> UpdateOrderConceptsForOrderPerson(List<OrderConcept> newOrderConcepts,long idOrderPerson);
    List<OrderConcept> UpdateOrderConceptsForOrderPerson(List<OrderConcept> newOrderConcepts,long idOrderPerson,SubscriptionEntities db);
                           



 OrderPerson GetOrderPersonCustom( Expression<Func<OrderPerson, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 OrderPerson GetOrderPersonCustom(SubscriptionEntities db, Expression<Func<OrderPerson, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<OrderPerson> GetOrderPersonCustomList( Expression<Func<OrderPerson, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<OrderPerson, dynamic> orderExpression = null);
 BaseListReturnType<OrderPerson> GetOrderPersonCustomList( SubscriptionEntities db , Expression<Func<OrderPerson, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<OrderPerson, dynamic> orderExpression = null);
 OrderPerson GetOrderPersonWithDetails(long idOrderPerson, List<string> includes = null,bool shouldRemap = false);
 OrderPerson GetOrderPersonWithDetails(long idOrderPerson, SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 OrderPerson GetOrderPersonWitDetails(long idOrderPerson,bool shouldRemap = false);
 OrderPerson GetOrderPersonWitDetails(long idOrderPerson, SubscriptionEntities db,bool shouldRemap = false);
 void SaveOrderPerson(OrderPerson orderPerson);
 void SaveOrderPerson(OrderPerson orderPerson, SubscriptionEntities db);
 void SaveOnlyOrderPerson(OrderPerson orderPerson);
 void SaveOnlyOrderPerson(OrderPerson orderPerson, SubscriptionEntities db);
 void DeleteOrderPerson(OrderPerson orderPerson);
 void DeleteOrderPerson(OrderPerson orderPerson, SubscriptionEntities db);		
  void DeletePermanentlyOrderPerson(OrderPerson orderPerson);
 void DeletePermanentlyOrderPerson(OrderPerson orderPerson, SubscriptionEntities db);	
	}
 	public partial interface IOrderStateDao
	{
  List<OrderState> GetAllOrderStates(bool shouldRemap = false);
  List<OrderState> GetAllOrderStates(SubscriptionEntities db,bool shouldRemap = false);
  BaseListReturnType<OrderState> GetAllOrderStatesByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<OrderState, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<OrderState, dynamic> orderExpression = null);
  BaseListReturnType<OrderState> GetAllOrderStatesByPage(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<OrderState, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<OrderState, dynamic> orderExpression = null);
  
  BaseListReturnType<OrderState> GetAllOrderStatesByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<OrderState, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<OrderState, dynamic> orderExpression = null);
  BaseListReturnType<OrderState> GetAllOrderStatesByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<OrderState, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<OrderState, dynamic> orderExpression = null);

 BaseListReturnType<OrderState> GetAllOrderStatesWithOrdersDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<OrderState, bool>> expression = null,bool shouldRemap = false, Func<OrderState, dynamic> orderExpression = null);
 BaseListReturnType<OrderState> GetAllOrderStatesWithOrdersDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<OrderState, bool>> expression = null,bool shouldRemap = false, Func<OrderState, dynamic> orderExpression = null);


List<OrderState> GetOrderStateListByIdList(List<long> orderStateIds);

List<OrderState> GetOrderStateListByIdList(List<long> orderStateIds, SubscriptionEntities db);

 BaseListReturnType<OrderState> GetAllOrderStatesWithOrdersDetails(bool shouldRemap = false);
 BaseListReturnType<OrderState> GetAllOrderStateWitDetails( List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<OrderState> GetAllOrderStateWitDetails( SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 OrderState GetOrderState(long idOrderState,bool shouldRemap = false);
 OrderState GetOrderState(long idOrderState, SubscriptionEntities db,bool shouldRemap = false);
 OrderState GetOrderStateWithOrdersDetails(long idOrderState,bool shouldRemap = false);
           List<Order> UpdateOrdersForOrderStateWithoutSavingNewItem(List<Order> newOrders,long idOrderState);
    List<Order> UpdateOrdersForOrderStateWithoutSavingNewItem(List<Order> newOrders,long idOrderState,SubscriptionEntities db);
          

    List<Order> UpdateOrdersForOrderState(List<Order> newOrders,long idOrderState);
    List<Order> UpdateOrdersForOrderState(List<Order> newOrders,long idOrderState,SubscriptionEntities db);
                           



 OrderState GetOrderStateCustom( Expression<Func<OrderState, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 OrderState GetOrderStateCustom(SubscriptionEntities db, Expression<Func<OrderState, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<OrderState> GetOrderStateCustomList( Expression<Func<OrderState, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<OrderState, dynamic> orderExpression = null);
 BaseListReturnType<OrderState> GetOrderStateCustomList( SubscriptionEntities db , Expression<Func<OrderState, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<OrderState, dynamic> orderExpression = null);
 OrderState GetOrderStateWithDetails(long idOrderState, List<string> includes = null,bool shouldRemap = false);
 OrderState GetOrderStateWithDetails(long idOrderState, SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 OrderState GetOrderStateWitDetails(long idOrderState,bool shouldRemap = false);
 OrderState GetOrderStateWitDetails(long idOrderState, SubscriptionEntities db,bool shouldRemap = false);
 void SaveOrderState(OrderState orderState);
 void SaveOrderState(OrderState orderState, SubscriptionEntities db);
 void SaveOnlyOrderState(OrderState orderState);
 void SaveOnlyOrderState(OrderState orderState, SubscriptionEntities db);
 void DeleteOrderState(OrderState orderState);
 void DeleteOrderState(OrderState orderState, SubscriptionEntities db);		
  void DeletePermanentlyOrderState(OrderState orderState);
 void DeletePermanentlyOrderState(OrderState orderState, SubscriptionEntities db);	
	}
 	public partial interface IParameterDao
	{
  List<Parameter> GetAllParameters(bool shouldRemap = false);
  List<Parameter> GetAllParameters(SubscriptionEntities db,bool shouldRemap = false);
  BaseListReturnType<Parameter> GetAllParametersByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Parameter, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<Parameter, dynamic> orderExpression = null);
  BaseListReturnType<Parameter> GetAllParametersByPage(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<Parameter, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<Parameter, dynamic> orderExpression = null);
  
  BaseListReturnType<Parameter> GetAllParametersByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Parameter, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<Parameter, dynamic> orderExpression = null);
  BaseListReturnType<Parameter> GetAllParametersByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<Parameter, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<Parameter, dynamic> orderExpression = null);

 BaseListReturnType<Parameter> GetAllParametersWithDocumentsDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Parameter, bool>> expression = null,bool shouldRemap = false, Func<Parameter, dynamic> orderExpression = null);
 BaseListReturnType<Parameter> GetAllParametersWithDocumentsDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Parameter, bool>> expression = null,bool shouldRemap = false, Func<Parameter, dynamic> orderExpression = null);

 BaseListReturnType<Parameter> GetAllParametersWithDocuments1DetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Parameter, bool>> expression = null,bool shouldRemap = false, Func<Parameter, dynamic> orderExpression = null);
 BaseListReturnType<Parameter> GetAllParametersWithDocuments1DetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Parameter, bool>> expression = null,bool shouldRemap = false, Func<Parameter, dynamic> orderExpression = null);


List<Parameter> GetParameterListByIdList(List<long> parameterIds);

List<Parameter> GetParameterListByIdList(List<long> parameterIds, SubscriptionEntities db);

 BaseListReturnType<Parameter> GetAllParametersWithDocumentsDetails(bool shouldRemap = false);
 BaseListReturnType<Parameter> GetAllParametersWithDocuments1Details(bool shouldRemap = false);
 BaseListReturnType<Parameter> GetAllParameterWitDetails( List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<Parameter> GetAllParameterWitDetails( SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 Parameter GetParameter(long idParameter,bool shouldRemap = false);
 Parameter GetParameter(long idParameter, SubscriptionEntities db,bool shouldRemap = false);
     Parameter GetParameterByCode(long code, SubscriptionEntities db,bool shouldRemap = false);
     Parameter GetParameterByCode(long code,bool shouldRemap = false);
 Parameter GetParameterWithDocumentsDetails(long idParameter,bool shouldRemap = false);
           List<Document> UpdateDocumentsForParameterWithoutSavingNewItem(List<Document> newDocuments,long idParameter);
    List<Document> UpdateDocumentsForParameterWithoutSavingNewItem(List<Document> newDocuments,long idParameter,SubscriptionEntities db);
          

    List<Document> UpdateDocumentsForParameter(List<Document> newDocuments,long idParameter);
    List<Document> UpdateDocumentsForParameter(List<Document> newDocuments,long idParameter,SubscriptionEntities db);
                           



 Parameter GetParameterWithDocuments1Details(long idParameter,bool shouldRemap = false);
           List<Document> UpdateDocuments1ForParameterWithoutSavingNewItem(List<Document> newDocuments,long idParameter);
    List<Document> UpdateDocuments1ForParameterWithoutSavingNewItem(List<Document> newDocuments,long idParameter,SubscriptionEntities db);
          

    List<Document> UpdateDocuments1ForParameter(List<Document> newDocuments,long idParameter);
    List<Document> UpdateDocuments1ForParameter(List<Document> newDocuments,long idParameter,SubscriptionEntities db);
                           



 Parameter GetParameterCustom( Expression<Func<Parameter, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 Parameter GetParameterCustom(SubscriptionEntities db, Expression<Func<Parameter, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<Parameter> GetParameterCustomList( Expression<Func<Parameter, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<Parameter, dynamic> orderExpression = null);
 BaseListReturnType<Parameter> GetParameterCustomList( SubscriptionEntities db , Expression<Func<Parameter, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<Parameter, dynamic> orderExpression = null);
 Parameter GetParameterWithDetails(long idParameter, List<string> includes = null,bool shouldRemap = false);
 Parameter GetParameterWithDetails(long idParameter, SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 Parameter GetParameterWitDetails(long idParameter,bool shouldRemap = false);
 Parameter GetParameterWitDetails(long idParameter, SubscriptionEntities db,bool shouldRemap = false);
 void SaveParameter(Parameter parameter);
 void SaveParameter(Parameter parameter, SubscriptionEntities db);
 void SaveOnlyParameter(Parameter parameter);
 void SaveOnlyParameter(Parameter parameter, SubscriptionEntities db);
 void DeleteParameter(Parameter parameter);
 void DeleteParameter(Parameter parameter, SubscriptionEntities db);		
  void DeletePermanentlyParameter(Parameter parameter);
 void DeletePermanentlyParameter(Parameter parameter, SubscriptionEntities db);	
	}
 	public partial interface IPaymentDao
	{
  List<Payment> GetAllPayments(bool shouldRemap = false);
  List<Payment> GetAllPayments(SubscriptionEntities db,bool shouldRemap = false);
  BaseListReturnType<Payment> GetAllPaymentsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Payment, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<Payment, dynamic> orderExpression = null);
  BaseListReturnType<Payment> GetAllPaymentsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<Payment, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<Payment, dynamic> orderExpression = null);
  
  BaseListReturnType<Payment> GetAllPaymentsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Payment, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<Payment, dynamic> orderExpression = null);
  BaseListReturnType<Payment> GetAllPaymentsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<Payment, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<Payment, dynamic> orderExpression = null);

 BaseListReturnType<Payment> GetAllPaymentsWithUserDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Payment, bool>> expression = null,bool shouldRemap = false, Func<Payment, dynamic> orderExpression = null);
 BaseListReturnType<Payment> GetAllPaymentsWithUserDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Payment, bool>> expression = null,bool shouldRemap = false, Func<Payment, dynamic> orderExpression = null);






BaseListReturnType<Payment> GetAllPaymentListByUser(long idUser);

BaseListReturnType<Payment> GetAllPaymentListByUser(long idUser, SubscriptionEntities db);

BaseListReturnType<Payment> GetAllPaymentListByUserByPage(long idUser, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<Payment> GetAllPaymentListByUserByPage(long idUser, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);



 BaseListReturnType<Payment> GetAllPaymentsWithTransactionDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Payment, bool>> expression = null,bool shouldRemap = false, Func<Payment, dynamic> orderExpression = null);
 BaseListReturnType<Payment> GetAllPaymentsWithTransactionDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Payment, bool>> expression = null,bool shouldRemap = false, Func<Payment, dynamic> orderExpression = null);






BaseListReturnType<Payment> GetAllPaymentListByTransaction(long idTransaction);

BaseListReturnType<Payment> GetAllPaymentListByTransaction(long idTransaction, SubscriptionEntities db);

BaseListReturnType<Payment> GetAllPaymentListByTransactionByPage(long idTransaction, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<Payment> GetAllPaymentListByTransactionByPage(long idTransaction, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);



 BaseListReturnType<Payment> GetAllPaymentsWithPaymentDetailsDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Payment, bool>> expression = null,bool shouldRemap = false, Func<Payment, dynamic> orderExpression = null);
 BaseListReturnType<Payment> GetAllPaymentsWithPaymentDetailsDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Payment, bool>> expression = null,bool shouldRemap = false, Func<Payment, dynamic> orderExpression = null);

 BaseListReturnType<Payment> GetAllPaymentsWithTransactionsDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Payment, bool>> expression = null,bool shouldRemap = false, Func<Payment, dynamic> orderExpression = null);
 BaseListReturnType<Payment> GetAllPaymentsWithTransactionsDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Payment, bool>> expression = null,bool shouldRemap = false, Func<Payment, dynamic> orderExpression = null);

 BaseListReturnType<Payment> GetAllPaymentsWithTransaction_PaymentDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Payment, bool>> expression = null,bool shouldRemap = false, Func<Payment, dynamic> orderExpression = null);
 BaseListReturnType<Payment> GetAllPaymentsWithTransaction_PaymentDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Payment, bool>> expression = null,bool shouldRemap = false, Func<Payment, dynamic> orderExpression = null);


List<Payment> GetPaymentListByIdList(List<long> paymentIds);

List<Payment> GetPaymentListByIdList(List<long> paymentIds, SubscriptionEntities db);

 BaseListReturnType<Payment> GetAllPaymentsWithUserDetails(bool shouldRemap = false);
 BaseListReturnType<Payment> GetAllPaymentsWithTransactionDetails(bool shouldRemap = false);
 BaseListReturnType<Payment> GetAllPaymentsWithPaymentDetailsDetails(bool shouldRemap = false);
 BaseListReturnType<Payment> GetAllPaymentsWithTransactionsDetails(bool shouldRemap = false);
 BaseListReturnType<Payment> GetAllPaymentsWithTransaction_PaymentDetails(bool shouldRemap = false);
 BaseListReturnType<Payment> GetAllPaymentWitDetails( List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<Payment> GetAllPaymentWitDetails( SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 Payment GetPayment(long idPayment,bool shouldRemap = false);
 Payment GetPayment(long idPayment, SubscriptionEntities db,bool shouldRemap = false);
 Payment GetPaymentWithUserDetails(long idPayment,bool shouldRemap = false);
    


 Payment GetPaymentWithTransactionDetails(long idPayment,bool shouldRemap = false);
    


 Payment GetPaymentWithPaymentDetailsDetails(long idPayment,bool shouldRemap = false);
           List<PaymentDetail> UpdatePaymentDetailsForPaymentWithoutSavingNewItem(List<PaymentDetail> newPaymentDetails,long idPayment);
    List<PaymentDetail> UpdatePaymentDetailsForPaymentWithoutSavingNewItem(List<PaymentDetail> newPaymentDetails,long idPayment,SubscriptionEntities db);
          

    List<PaymentDetail> UpdatePaymentDetailsForPayment(List<PaymentDetail> newPaymentDetails,long idPayment);
    List<PaymentDetail> UpdatePaymentDetailsForPayment(List<PaymentDetail> newPaymentDetails,long idPayment,SubscriptionEntities db);
                           



 Payment GetPaymentWithTransactionsDetails(long idPayment,bool shouldRemap = false);
           List<Transaction> UpdateTransactionsForPaymentWithoutSavingNewItem(List<Transaction> newTransactions,long idPayment);
    List<Transaction> UpdateTransactionsForPaymentWithoutSavingNewItem(List<Transaction> newTransactions,long idPayment,SubscriptionEntities db);
          

    List<Transaction> UpdateTransactionsForPayment(List<Transaction> newTransactions,long idPayment);
    List<Transaction> UpdateTransactionsForPayment(List<Transaction> newTransactions,long idPayment,SubscriptionEntities db);
                           



 Payment GetPaymentWithTransaction_PaymentDetails(long idPayment,bool shouldRemap = false);
           List<Transaction_Payment> UpdateTransaction_PaymentForPaymentWithoutSavingNewItem(List<Transaction_Payment> newTransaction_Payment,long idPayment);
    List<Transaction_Payment> UpdateTransaction_PaymentForPaymentWithoutSavingNewItem(List<Transaction_Payment> newTransaction_Payment,long idPayment,SubscriptionEntities db);
          

    List<Transaction_Payment> UpdateTransaction_PaymentForPayment(List<Transaction_Payment> newTransaction_Payment,long idPayment);
    List<Transaction_Payment> UpdateTransaction_PaymentForPayment(List<Transaction_Payment> newTransaction_Payment,long idPayment,SubscriptionEntities db);
                           



 Payment GetPaymentCustom( Expression<Func<Payment, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 Payment GetPaymentCustom(SubscriptionEntities db, Expression<Func<Payment, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<Payment> GetPaymentCustomList( Expression<Func<Payment, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<Payment, dynamic> orderExpression = null);
 BaseListReturnType<Payment> GetPaymentCustomList( SubscriptionEntities db , Expression<Func<Payment, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<Payment, dynamic> orderExpression = null);
 Payment GetPaymentWithDetails(long idPayment, List<string> includes = null,bool shouldRemap = false);
 Payment GetPaymentWithDetails(long idPayment, SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 Payment GetPaymentWitDetails(long idPayment,bool shouldRemap = false);
 Payment GetPaymentWitDetails(long idPayment, SubscriptionEntities db,bool shouldRemap = false);
 void SavePayment(Payment payment);
 void SavePayment(Payment payment, SubscriptionEntities db);
 void SaveOnlyPayment(Payment payment);
 void SaveOnlyPayment(Payment payment, SubscriptionEntities db);
 void DeletePayment(Payment payment);
 void DeletePayment(Payment payment, SubscriptionEntities db);		
  void DeletePermanentlyPayment(Payment payment);
 void DeletePermanentlyPayment(Payment payment, SubscriptionEntities db);	
	}
 	public partial interface IPaymentDetailDao
	{
  List<PaymentDetail> GetAllPaymentDetails(bool shouldRemap = false);
  List<PaymentDetail> GetAllPaymentDetails(SubscriptionEntities db,bool shouldRemap = false);
  BaseListReturnType<PaymentDetail> GetAllPaymentDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<PaymentDetail, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<PaymentDetail, dynamic> orderExpression = null);
  BaseListReturnType<PaymentDetail> GetAllPaymentDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<PaymentDetail, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<PaymentDetail, dynamic> orderExpression = null);
  
  BaseListReturnType<PaymentDetail> GetAllPaymentDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<PaymentDetail, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<PaymentDetail, dynamic> orderExpression = null);
  BaseListReturnType<PaymentDetail> GetAllPaymentDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<PaymentDetail, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<PaymentDetail, dynamic> orderExpression = null);

 BaseListReturnType<PaymentDetail> GetAllPaymentDetailsWithBankDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<PaymentDetail, bool>> expression = null,bool shouldRemap = false, Func<PaymentDetail, dynamic> orderExpression = null);
 BaseListReturnType<PaymentDetail> GetAllPaymentDetailsWithBankDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<PaymentDetail, bool>> expression = null,bool shouldRemap = false, Func<PaymentDetail, dynamic> orderExpression = null);






BaseListReturnType<PaymentDetail> GetAllPaymentDetailListByBank(long idBank);

BaseListReturnType<PaymentDetail> GetAllPaymentDetailListByBank(long idBank, SubscriptionEntities db);

BaseListReturnType<PaymentDetail> GetAllPaymentDetailListByBankByPage(long idBank, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<PaymentDetail> GetAllPaymentDetailListByBankByPage(long idBank, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);



 BaseListReturnType<PaymentDetail> GetAllPaymentDetailsWithPaymentMethodDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<PaymentDetail, bool>> expression = null,bool shouldRemap = false, Func<PaymentDetail, dynamic> orderExpression = null);
 BaseListReturnType<PaymentDetail> GetAllPaymentDetailsWithPaymentMethodDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<PaymentDetail, bool>> expression = null,bool shouldRemap = false, Func<PaymentDetail, dynamic> orderExpression = null);






BaseListReturnType<PaymentDetail> GetAllPaymentDetailListByPaymentMethod(long idPaymentMethod);

BaseListReturnType<PaymentDetail> GetAllPaymentDetailListByPaymentMethod(long idPaymentMethod, SubscriptionEntities db);

BaseListReturnType<PaymentDetail> GetAllPaymentDetailListByPaymentMethodByPage(long idPaymentMethod, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<PaymentDetail> GetAllPaymentDetailListByPaymentMethodByPage(long idPaymentMethod, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);



 BaseListReturnType<PaymentDetail> GetAllPaymentDetailsWithPaymentDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<PaymentDetail, bool>> expression = null,bool shouldRemap = false, Func<PaymentDetail, dynamic> orderExpression = null);
 BaseListReturnType<PaymentDetail> GetAllPaymentDetailsWithPaymentDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<PaymentDetail, bool>> expression = null,bool shouldRemap = false, Func<PaymentDetail, dynamic> orderExpression = null);






BaseListReturnType<PaymentDetail> GetAllPaymentDetailListByPayment(long idPayment);

BaseListReturnType<PaymentDetail> GetAllPaymentDetailListByPayment(long idPayment, SubscriptionEntities db);

BaseListReturnType<PaymentDetail> GetAllPaymentDetailListByPaymentByPage(long idPayment, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<PaymentDetail> GetAllPaymentDetailListByPaymentByPage(long idPayment, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);




List<PaymentDetail> GetPaymentDetailListByIdList(List<long> paymentDetailIds);

List<PaymentDetail> GetPaymentDetailListByIdList(List<long> paymentDetailIds, SubscriptionEntities db);

 BaseListReturnType<PaymentDetail> GetAllPaymentDetailsWithBankDetails(bool shouldRemap = false);
 BaseListReturnType<PaymentDetail> GetAllPaymentDetailsWithPaymentMethodDetails(bool shouldRemap = false);
 BaseListReturnType<PaymentDetail> GetAllPaymentDetailsWithPaymentDetails(bool shouldRemap = false);
 BaseListReturnType<PaymentDetail> GetAllPaymentDetailWitDetails( List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<PaymentDetail> GetAllPaymentDetailWitDetails( SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 PaymentDetail GetPaymentDetail(long idPaymentDetail,bool shouldRemap = false);
 PaymentDetail GetPaymentDetail(long idPaymentDetail, SubscriptionEntities db,bool shouldRemap = false);
 PaymentDetail GetPaymentDetailWithBankDetails(long idPaymentDetail,bool shouldRemap = false);
    


 PaymentDetail GetPaymentDetailWithPaymentMethodDetails(long idPaymentDetail,bool shouldRemap = false);
    


 PaymentDetail GetPaymentDetailWithPaymentDetails(long idPaymentDetail,bool shouldRemap = false);
    


 PaymentDetail GetPaymentDetailCustom( Expression<Func<PaymentDetail, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 PaymentDetail GetPaymentDetailCustom(SubscriptionEntities db, Expression<Func<PaymentDetail, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<PaymentDetail> GetPaymentDetailCustomList( Expression<Func<PaymentDetail, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<PaymentDetail, dynamic> orderExpression = null);
 BaseListReturnType<PaymentDetail> GetPaymentDetailCustomList( SubscriptionEntities db , Expression<Func<PaymentDetail, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<PaymentDetail, dynamic> orderExpression = null);
 PaymentDetail GetPaymentDetailWithDetails(long idPaymentDetail, List<string> includes = null,bool shouldRemap = false);
 PaymentDetail GetPaymentDetailWithDetails(long idPaymentDetail, SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 PaymentDetail GetPaymentDetailWitDetails(long idPaymentDetail,bool shouldRemap = false);
 PaymentDetail GetPaymentDetailWitDetails(long idPaymentDetail, SubscriptionEntities db,bool shouldRemap = false);
 void SavePaymentDetail(PaymentDetail paymentDetail);
 void SavePaymentDetail(PaymentDetail paymentDetail, SubscriptionEntities db);
 void SaveOnlyPaymentDetail(PaymentDetail paymentDetail);
 void SaveOnlyPaymentDetail(PaymentDetail paymentDetail, SubscriptionEntities db);
 void DeletePaymentDetail(PaymentDetail paymentDetail);
 void DeletePaymentDetail(PaymentDetail paymentDetail, SubscriptionEntities db);		
  void DeletePermanentlyPaymentDetail(PaymentDetail paymentDetail);
 void DeletePermanentlyPaymentDetail(PaymentDetail paymentDetail, SubscriptionEntities db);	
	}
 	public partial interface IPaymentDueStateDao
	{
  List<PaymentDueState> GetAllPaymentDueStates(bool shouldRemap = false);
  List<PaymentDueState> GetAllPaymentDueStates(SubscriptionEntities db,bool shouldRemap = false);
  BaseListReturnType<PaymentDueState> GetAllPaymentDueStatesByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<PaymentDueState, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<PaymentDueState, dynamic> orderExpression = null);
  BaseListReturnType<PaymentDueState> GetAllPaymentDueStatesByPage(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<PaymentDueState, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<PaymentDueState, dynamic> orderExpression = null);
  
  BaseListReturnType<PaymentDueState> GetAllPaymentDueStatesByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<PaymentDueState, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<PaymentDueState, dynamic> orderExpression = null);
  BaseListReturnType<PaymentDueState> GetAllPaymentDueStatesByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<PaymentDueState, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<PaymentDueState, dynamic> orderExpression = null);


List<PaymentDueState> GetPaymentDueStateListByIdList(List<long> paymentDueStateIds);

List<PaymentDueState> GetPaymentDueStateListByIdList(List<long> paymentDueStateIds, SubscriptionEntities db);

 BaseListReturnType<PaymentDueState> GetAllPaymentDueStateWitDetails( List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<PaymentDueState> GetAllPaymentDueStateWitDetails( SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 PaymentDueState GetPaymentDueState(long idPaymentDueState,bool shouldRemap = false);
 PaymentDueState GetPaymentDueState(long idPaymentDueState, SubscriptionEntities db,bool shouldRemap = false);
 PaymentDueState GetPaymentDueStateCustom( Expression<Func<PaymentDueState, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 PaymentDueState GetPaymentDueStateCustom(SubscriptionEntities db, Expression<Func<PaymentDueState, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<PaymentDueState> GetPaymentDueStateCustomList( Expression<Func<PaymentDueState, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<PaymentDueState, dynamic> orderExpression = null);
 BaseListReturnType<PaymentDueState> GetPaymentDueStateCustomList( SubscriptionEntities db , Expression<Func<PaymentDueState, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<PaymentDueState, dynamic> orderExpression = null);
 PaymentDueState GetPaymentDueStateWithDetails(long idPaymentDueState, List<string> includes = null,bool shouldRemap = false);
 PaymentDueState GetPaymentDueStateWithDetails(long idPaymentDueState, SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 PaymentDueState GetPaymentDueStateWitDetails(long idPaymentDueState,bool shouldRemap = false);
 PaymentDueState GetPaymentDueStateWitDetails(long idPaymentDueState, SubscriptionEntities db,bool shouldRemap = false);
 void SavePaymentDueState(PaymentDueState paymentDueState);
 void SavePaymentDueState(PaymentDueState paymentDueState, SubscriptionEntities db);
 void SaveOnlyPaymentDueState(PaymentDueState paymentDueState);
 void SaveOnlyPaymentDueState(PaymentDueState paymentDueState, SubscriptionEntities db);
 void DeletePaymentDueState(PaymentDueState paymentDueState);
 void DeletePaymentDueState(PaymentDueState paymentDueState, SubscriptionEntities db);		
  void DeletePermanentlyPaymentDueState(PaymentDueState paymentDueState);
 void DeletePermanentlyPaymentDueState(PaymentDueState paymentDueState, SubscriptionEntities db);	
	}
 	public partial interface IPaymentMethodDao
	{
  List<PaymentMethod> GetAllPaymentMethods(bool shouldRemap = false);
  List<PaymentMethod> GetAllPaymentMethods(SubscriptionEntities db,bool shouldRemap = false);
  BaseListReturnType<PaymentMethod> GetAllPaymentMethodsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<PaymentMethod, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<PaymentMethod, dynamic> orderExpression = null);
  BaseListReturnType<PaymentMethod> GetAllPaymentMethodsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<PaymentMethod, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<PaymentMethod, dynamic> orderExpression = null);
  
  BaseListReturnType<PaymentMethod> GetAllPaymentMethodsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<PaymentMethod, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<PaymentMethod, dynamic> orderExpression = null);
  BaseListReturnType<PaymentMethod> GetAllPaymentMethodsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<PaymentMethod, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<PaymentMethod, dynamic> orderExpression = null);

 BaseListReturnType<PaymentMethod> GetAllPaymentMethodsWithBanksDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<PaymentMethod, bool>> expression = null,bool shouldRemap = false, Func<PaymentMethod, dynamic> orderExpression = null);
 BaseListReturnType<PaymentMethod> GetAllPaymentMethodsWithBanksDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<PaymentMethod, bool>> expression = null,bool shouldRemap = false, Func<PaymentMethod, dynamic> orderExpression = null);

 BaseListReturnType<PaymentMethod> GetAllPaymentMethodsWithPaymentDetailsDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<PaymentMethod, bool>> expression = null,bool shouldRemap = false, Func<PaymentMethod, dynamic> orderExpression = null);
 BaseListReturnType<PaymentMethod> GetAllPaymentMethodsWithPaymentDetailsDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<PaymentMethod, bool>> expression = null,bool shouldRemap = false, Func<PaymentMethod, dynamic> orderExpression = null);


List<PaymentMethod> GetPaymentMethodListByIdList(List<long> paymentMethodIds);

List<PaymentMethod> GetPaymentMethodListByIdList(List<long> paymentMethodIds, SubscriptionEntities db);

 BaseListReturnType<PaymentMethod> GetAllPaymentMethodsWithBanksDetails(bool shouldRemap = false);
 BaseListReturnType<PaymentMethod> GetAllPaymentMethodsWithPaymentDetailsDetails(bool shouldRemap = false);
 BaseListReturnType<PaymentMethod> GetAllPaymentMethodWitDetails( List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<PaymentMethod> GetAllPaymentMethodWitDetails( SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 PaymentMethod GetPaymentMethod(long idPaymentMethod,bool shouldRemap = false);
 PaymentMethod GetPaymentMethod(long idPaymentMethod, SubscriptionEntities db,bool shouldRemap = false);
 PaymentMethod GetPaymentMethodWithBanksDetails(long idPaymentMethod,bool shouldRemap = false);
           List<Bank> UpdateBanksForPaymentMethodWithoutSavingNewItem(List<Bank> newBanks,long idPaymentMethod);
    List<Bank> UpdateBanksForPaymentMethodWithoutSavingNewItem(List<Bank> newBanks,long idPaymentMethod,SubscriptionEntities db);
          

    List<Bank> UpdateBanksForPaymentMethod(List<Bank> newBanks,long idPaymentMethod);
    List<Bank> UpdateBanksForPaymentMethod(List<Bank> newBanks,long idPaymentMethod,SubscriptionEntities db);
                           



 PaymentMethod GetPaymentMethodWithPaymentDetailsDetails(long idPaymentMethod,bool shouldRemap = false);
           List<PaymentDetail> UpdatePaymentDetailsForPaymentMethodWithoutSavingNewItem(List<PaymentDetail> newPaymentDetails,long idPaymentMethod);
    List<PaymentDetail> UpdatePaymentDetailsForPaymentMethodWithoutSavingNewItem(List<PaymentDetail> newPaymentDetails,long idPaymentMethod,SubscriptionEntities db);
          

    List<PaymentDetail> UpdatePaymentDetailsForPaymentMethod(List<PaymentDetail> newPaymentDetails,long idPaymentMethod);
    List<PaymentDetail> UpdatePaymentDetailsForPaymentMethod(List<PaymentDetail> newPaymentDetails,long idPaymentMethod,SubscriptionEntities db);
                           



 PaymentMethod GetPaymentMethodCustom( Expression<Func<PaymentMethod, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 PaymentMethod GetPaymentMethodCustom(SubscriptionEntities db, Expression<Func<PaymentMethod, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<PaymentMethod> GetPaymentMethodCustomList( Expression<Func<PaymentMethod, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<PaymentMethod, dynamic> orderExpression = null);
 BaseListReturnType<PaymentMethod> GetPaymentMethodCustomList( SubscriptionEntities db , Expression<Func<PaymentMethod, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<PaymentMethod, dynamic> orderExpression = null);
 PaymentMethod GetPaymentMethodWithDetails(long idPaymentMethod, List<string> includes = null,bool shouldRemap = false);
 PaymentMethod GetPaymentMethodWithDetails(long idPaymentMethod, SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 PaymentMethod GetPaymentMethodWitDetails(long idPaymentMethod,bool shouldRemap = false);
 PaymentMethod GetPaymentMethodWitDetails(long idPaymentMethod, SubscriptionEntities db,bool shouldRemap = false);
 void SavePaymentMethod(PaymentMethod paymentMethod);
 void SavePaymentMethod(PaymentMethod paymentMethod, SubscriptionEntities db);
 void SaveOnlyPaymentMethod(PaymentMethod paymentMethod);
 void SaveOnlyPaymentMethod(PaymentMethod paymentMethod, SubscriptionEntities db);
 void DeletePaymentMethod(PaymentMethod paymentMethod);
 void DeletePaymentMethod(PaymentMethod paymentMethod, SubscriptionEntities db);		
  void DeletePermanentlyPaymentMethod(PaymentMethod paymentMethod);
 void DeletePermanentlyPaymentMethod(PaymentMethod paymentMethod, SubscriptionEntities db);	
	}
 	public partial interface IPermissionDao
	{
  List<Permission> GetAllPermissions(bool shouldRemap = false);
  List<Permission> GetAllPermissions(SubscriptionEntities db,bool shouldRemap = false);
  BaseListReturnType<Permission> GetAllPermissionsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Permission, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<Permission, dynamic> orderExpression = null);
  BaseListReturnType<Permission> GetAllPermissionsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<Permission, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<Permission, dynamic> orderExpression = null);
  
  BaseListReturnType<Permission> GetAllPermissionsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Permission, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<Permission, dynamic> orderExpression = null);
  BaseListReturnType<Permission> GetAllPermissionsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<Permission, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<Permission, dynamic> orderExpression = null);

 BaseListReturnType<Permission> GetAllPermissionsWithRole_PermissionDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Permission, bool>> expression = null,bool shouldRemap = false, Func<Permission, dynamic> orderExpression = null);
 BaseListReturnType<Permission> GetAllPermissionsWithRole_PermissionDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Permission, bool>> expression = null,bool shouldRemap = false, Func<Permission, dynamic> orderExpression = null);

 BaseListReturnType<Permission> GetAllPermissionsWithUser_PermissionDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Permission, bool>> expression = null,bool shouldRemap = false, Func<Permission, dynamic> orderExpression = null);
 BaseListReturnType<Permission> GetAllPermissionsWithUser_PermissionDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Permission, bool>> expression = null,bool shouldRemap = false, Func<Permission, dynamic> orderExpression = null);


List<Permission> GetPermissionListByIdList(List<long> permissionIds);

List<Permission> GetPermissionListByIdList(List<long> permissionIds, SubscriptionEntities db);

 BaseListReturnType<Permission> GetAllPermissionsWithRole_PermissionDetails(bool shouldRemap = false);
 BaseListReturnType<Permission> GetAllPermissionsWithUser_PermissionDetails(bool shouldRemap = false);
 BaseListReturnType<Permission> GetAllPermissionWitDetails( List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<Permission> GetAllPermissionWitDetails( SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 Permission GetPermission(long idPermission,bool shouldRemap = false);
 Permission GetPermission(long idPermission, SubscriptionEntities db,bool shouldRemap = false);
 Permission GetPermissionWithRole_PermissionDetails(long idPermission,bool shouldRemap = false);
           List<Role_Permission> UpdateRole_PermissionForPermissionWithoutSavingNewItem(List<Role_Permission> newRole_Permission,long idPermission);
    List<Role_Permission> UpdateRole_PermissionForPermissionWithoutSavingNewItem(List<Role_Permission> newRole_Permission,long idPermission,SubscriptionEntities db);
          

    List<Role_Permission> UpdateRole_PermissionForPermission(List<Role_Permission> newRole_Permission,long idPermission);
    List<Role_Permission> UpdateRole_PermissionForPermission(List<Role_Permission> newRole_Permission,long idPermission,SubscriptionEntities db);
                           



 Permission GetPermissionWithUser_PermissionDetails(long idPermission,bool shouldRemap = false);
           List<User_Permission> UpdateUser_PermissionForPermissionWithoutSavingNewItem(List<User_Permission> newUser_Permission,long idPermission);
    List<User_Permission> UpdateUser_PermissionForPermissionWithoutSavingNewItem(List<User_Permission> newUser_Permission,long idPermission,SubscriptionEntities db);
          

    List<User_Permission> UpdateUser_PermissionForPermission(List<User_Permission> newUser_Permission,long idPermission);
    List<User_Permission> UpdateUser_PermissionForPermission(List<User_Permission> newUser_Permission,long idPermission,SubscriptionEntities db);
                           



 Permission GetPermissionCustom( Expression<Func<Permission, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 Permission GetPermissionCustom(SubscriptionEntities db, Expression<Func<Permission, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<Permission> GetPermissionCustomList( Expression<Func<Permission, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<Permission, dynamic> orderExpression = null);
 BaseListReturnType<Permission> GetPermissionCustomList( SubscriptionEntities db , Expression<Func<Permission, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<Permission, dynamic> orderExpression = null);
 Permission GetPermissionWithDetails(long idPermission, List<string> includes = null,bool shouldRemap = false);
 Permission GetPermissionWithDetails(long idPermission, SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 Permission GetPermissionWitDetails(long idPermission,bool shouldRemap = false);
 Permission GetPermissionWitDetails(long idPermission, SubscriptionEntities db,bool shouldRemap = false);
 void SavePermission(Permission permission);
 void SavePermission(Permission permission, SubscriptionEntities db);
 void SaveOnlyPermission(Permission permission);
 void SaveOnlyPermission(Permission permission, SubscriptionEntities db);
 void DeletePermission(Permission permission);
 void DeletePermission(Permission permission, SubscriptionEntities db);		
  void DeletePermanentlyPermission(Permission permission);
 void DeletePermanentlyPermission(Permission permission, SubscriptionEntities db);	
	}
 	public partial interface IPersonDao
	{
  List<Person> GetAllPeople(bool shouldRemap = false);
  List<Person> GetAllPeople(SubscriptionEntities db,bool shouldRemap = false);
  BaseListReturnType<Person> GetAllPeopleByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Person, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<Person, dynamic> orderExpression = null);
  BaseListReturnType<Person> GetAllPeopleByPage(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<Person, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<Person, dynamic> orderExpression = null);
  
  BaseListReturnType<Person> GetAllPeopleByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Person, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<Person, dynamic> orderExpression = null);
  BaseListReturnType<Person> GetAllPeopleByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<Person, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<Person, dynamic> orderExpression = null);

 BaseListReturnType<Person> GetAllPeopleWithUsersDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Person, bool>> expression = null,bool shouldRemap = false, Func<Person, dynamic> orderExpression = null);
 BaseListReturnType<Person> GetAllPeopleWithUsersDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Person, bool>> expression = null,bool shouldRemap = false, Func<Person, dynamic> orderExpression = null);

 BaseListReturnType<Person> GetAllPeopleWithTitleDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Person, bool>> expression = null,bool shouldRemap = false, Func<Person, dynamic> orderExpression = null);
 BaseListReturnType<Person> GetAllPeopleWithTitleDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Person, bool>> expression = null,bool shouldRemap = false, Func<Person, dynamic> orderExpression = null);






BaseListReturnType<Person> GetAllPersonListByTitle(long idTitle);

BaseListReturnType<Person> GetAllPersonListByTitle(long idTitle, SubscriptionEntities db);

BaseListReturnType<Person> GetAllPersonListByTitleByPage(long idTitle, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<Person> GetAllPersonListByTitleByPage(long idTitle, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);



 BaseListReturnType<Person> GetAllPeopleWithConceptsDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Person, bool>> expression = null,bool shouldRemap = false, Func<Person, dynamic> orderExpression = null);
 BaseListReturnType<Person> GetAllPeopleWithConceptsDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Person, bool>> expression = null,bool shouldRemap = false, Func<Person, dynamic> orderExpression = null);

 BaseListReturnType<Person> GetAllPeopleWithCustomersDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Person, bool>> expression = null,bool shouldRemap = false, Func<Person, dynamic> orderExpression = null);
 BaseListReturnType<Person> GetAllPeopleWithCustomersDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Person, bool>> expression = null,bool shouldRemap = false, Func<Person, dynamic> orderExpression = null);

 BaseListReturnType<Person> GetAllPeopleWithPerson_AddressDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Person, bool>> expression = null,bool shouldRemap = false, Func<Person, dynamic> orderExpression = null);
 BaseListReturnType<Person> GetAllPeopleWithPerson_AddressDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Person, bool>> expression = null,bool shouldRemap = false, Func<Person, dynamic> orderExpression = null);

 BaseListReturnType<Person> GetAllPeopleWithPerson_ContactTypeDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Person, bool>> expression = null,bool shouldRemap = false, Func<Person, dynamic> orderExpression = null);
 BaseListReturnType<Person> GetAllPeopleWithPerson_ContactTypeDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Person, bool>> expression = null,bool shouldRemap = false, Func<Person, dynamic> orderExpression = null);


List<Person> GetPersonListByIdList(List<long> personIds);

List<Person> GetPersonListByIdList(List<long> personIds, SubscriptionEntities db);

 BaseListReturnType<Person> GetAllPeopleWithUsersDetails(bool shouldRemap = false);
 BaseListReturnType<Person> GetAllPeopleWithTitleDetails(bool shouldRemap = false);
 BaseListReturnType<Person> GetAllPeopleWithConceptsDetails(bool shouldRemap = false);
 BaseListReturnType<Person> GetAllPeopleWithCustomersDetails(bool shouldRemap = false);
 BaseListReturnType<Person> GetAllPeopleWithPerson_AddressDetails(bool shouldRemap = false);
 BaseListReturnType<Person> GetAllPeopleWithPerson_ContactTypeDetails(bool shouldRemap = false);
 BaseListReturnType<Person> GetAllPersonWitDetails( List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<Person> GetAllPersonWitDetails( SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 Person GetPerson(long idPerson,bool shouldRemap = false);
 Person GetPerson(long idPerson, SubscriptionEntities db,bool shouldRemap = false);
 Person GetPersonWithUsersDetails(long idPerson,bool shouldRemap = false);
           List<User> UpdateUsersForPersonWithoutSavingNewItem(List<User> newUsers,long idPerson);
    List<User> UpdateUsersForPersonWithoutSavingNewItem(List<User> newUsers,long idPerson,SubscriptionEntities db);
          

    List<User> UpdateUsersForPerson(List<User> newUsers,long idPerson);
    List<User> UpdateUsersForPerson(List<User> newUsers,long idPerson,SubscriptionEntities db);
                           



 Person GetPersonWithTitleDetails(long idPerson,bool shouldRemap = false);
    


 Person GetPersonWithConceptsDetails(long idPerson,bool shouldRemap = false);
           List<Concept> UpdateConceptsForPersonWithoutSavingNewItem(List<Concept> newConcepts,long idPerson);
    List<Concept> UpdateConceptsForPersonWithoutSavingNewItem(List<Concept> newConcepts,long idPerson,SubscriptionEntities db);
          

    List<Concept> UpdateConceptsForPerson(List<Concept> newConcepts,long idPerson);
    List<Concept> UpdateConceptsForPerson(List<Concept> newConcepts,long idPerson,SubscriptionEntities db);
                           



 Person GetPersonWithCustomersDetails(long idPerson,bool shouldRemap = false);
           List<Customer> UpdateCustomersForPersonWithoutSavingNewItem(List<Customer> newCustomers,long idPerson);
    List<Customer> UpdateCustomersForPersonWithoutSavingNewItem(List<Customer> newCustomers,long idPerson,SubscriptionEntities db);
          

    List<Customer> UpdateCustomersForPerson(List<Customer> newCustomers,long idPerson);
    List<Customer> UpdateCustomersForPerson(List<Customer> newCustomers,long idPerson,SubscriptionEntities db);
                           



 Person GetPersonWithPerson_AddressDetails(long idPerson,bool shouldRemap = false);
           List<Person_Address> UpdatePerson_AddressForPersonWithoutSavingNewItem(List<Person_Address> newPerson_Address,long idPerson);
    List<Person_Address> UpdatePerson_AddressForPersonWithoutSavingNewItem(List<Person_Address> newPerson_Address,long idPerson,SubscriptionEntities db);
          

    List<Person_Address> UpdatePerson_AddressForPerson(List<Person_Address> newPerson_Address,long idPerson);
    List<Person_Address> UpdatePerson_AddressForPerson(List<Person_Address> newPerson_Address,long idPerson,SubscriptionEntities db);
                           



 Person GetPersonWithPerson_ContactTypeDetails(long idPerson,bool shouldRemap = false);
           List<Person_ContactType> UpdatePerson_ContactTypeForPersonWithoutSavingNewItem(List<Person_ContactType> newPerson_ContactType,long idPerson);
    List<Person_ContactType> UpdatePerson_ContactTypeForPersonWithoutSavingNewItem(List<Person_ContactType> newPerson_ContactType,long idPerson,SubscriptionEntities db);
          

    List<Person_ContactType> UpdatePerson_ContactTypeForPerson(List<Person_ContactType> newPerson_ContactType,long idPerson);
    List<Person_ContactType> UpdatePerson_ContactTypeForPerson(List<Person_ContactType> newPerson_ContactType,long idPerson,SubscriptionEntities db);
                           



 Person GetPersonCustom( Expression<Func<Person, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 Person GetPersonCustom(SubscriptionEntities db, Expression<Func<Person, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<Person> GetPersonCustomList( Expression<Func<Person, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<Person, dynamic> orderExpression = null);
 BaseListReturnType<Person> GetPersonCustomList( SubscriptionEntities db , Expression<Func<Person, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<Person, dynamic> orderExpression = null);
 Person GetPersonWithDetails(long idPerson, List<string> includes = null,bool shouldRemap = false);
 Person GetPersonWithDetails(long idPerson, SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 Person GetPersonWitDetails(long idPerson,bool shouldRemap = false);
 Person GetPersonWitDetails(long idPerson, SubscriptionEntities db,bool shouldRemap = false);
 void SavePerson(Person person);
 void SavePerson(Person person, SubscriptionEntities db);
 void SaveOnlyPerson(Person person);
 void SaveOnlyPerson(Person person, SubscriptionEntities db);
 void DeletePerson(Person person);
 void DeletePerson(Person person, SubscriptionEntities db);		
  void DeletePermanentlyPerson(Person person);
 void DeletePermanentlyPerson(Person person, SubscriptionEntities db);	
	}
 	public partial interface IPerson_AddressDao
	{
  List<Person_Address> GetAllPerson_Address(bool shouldRemap = false);
  List<Person_Address> GetAllPerson_Address(SubscriptionEntities db,bool shouldRemap = false);
  BaseListReturnType<Person_Address> GetAllPerson_AddressByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Person_Address, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<Person_Address, dynamic> orderExpression = null);
  BaseListReturnType<Person_Address> GetAllPerson_AddressByPage(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<Person_Address, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<Person_Address, dynamic> orderExpression = null);
  
  BaseListReturnType<Person_Address> GetAllPerson_AddressByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Person_Address, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<Person_Address, dynamic> orderExpression = null);
  BaseListReturnType<Person_Address> GetAllPerson_AddressByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<Person_Address, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<Person_Address, dynamic> orderExpression = null);

 BaseListReturnType<Person_Address> GetAllPerson_AddressWithAddressDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Person_Address, bool>> expression = null,bool shouldRemap = false, Func<Person_Address, dynamic> orderExpression = null);
 BaseListReturnType<Person_Address> GetAllPerson_AddressWithAddressDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Person_Address, bool>> expression = null,bool shouldRemap = false, Func<Person_Address, dynamic> orderExpression = null);






BaseListReturnType<Person_Address> GetAllPerson_AddressListByAddress(long idAddress);

BaseListReturnType<Person_Address> GetAllPerson_AddressListByAddress(long idAddress, SubscriptionEntities db);

BaseListReturnType<Person_Address> GetAllPerson_AddressListByAddressByPage(long idAddress, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<Person_Address> GetAllPerson_AddressListByAddressByPage(long idAddress, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);



 BaseListReturnType<Person_Address> GetAllPerson_AddressWithPersonDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Person_Address, bool>> expression = null,bool shouldRemap = false, Func<Person_Address, dynamic> orderExpression = null);
 BaseListReturnType<Person_Address> GetAllPerson_AddressWithPersonDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Person_Address, bool>> expression = null,bool shouldRemap = false, Func<Person_Address, dynamic> orderExpression = null);






BaseListReturnType<Person_Address> GetAllPerson_AddressListByPerson(long idPerson);

BaseListReturnType<Person_Address> GetAllPerson_AddressListByPerson(long idPerson, SubscriptionEntities db);

BaseListReturnType<Person_Address> GetAllPerson_AddressListByPersonByPage(long idPerson, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<Person_Address> GetAllPerson_AddressListByPersonByPage(long idPerson, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);




List<Person_Address> GetPerson_AddressListByIdList(List<long> person_AddressIds);

List<Person_Address> GetPerson_AddressListByIdList(List<long> person_AddressIds, SubscriptionEntities db);

 BaseListReturnType<Person_Address> GetAllPerson_AddressWithAddressDetails(bool shouldRemap = false);
 BaseListReturnType<Person_Address> GetAllPerson_AddressWithPersonDetails(bool shouldRemap = false);
 BaseListReturnType<Person_Address> GetAllPerson_AddressWitDetails( List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<Person_Address> GetAllPerson_AddressWitDetails( SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 Person_Address GetPerson_Address(long idPerson_Address,bool shouldRemap = false);
 Person_Address GetPerson_Address(long idPerson_Address, SubscriptionEntities db,bool shouldRemap = false);
 Person_Address GetPerson_AddressWithAddressDetails(long idPerson_Address,bool shouldRemap = false);
    


 Person_Address GetPerson_AddressWithPersonDetails(long idPerson_Address,bool shouldRemap = false);
    


 Person_Address GetPerson_AddressCustom( Expression<Func<Person_Address, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 Person_Address GetPerson_AddressCustom(SubscriptionEntities db, Expression<Func<Person_Address, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<Person_Address> GetPerson_AddressCustomList( Expression<Func<Person_Address, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<Person_Address, dynamic> orderExpression = null);
 BaseListReturnType<Person_Address> GetPerson_AddressCustomList( SubscriptionEntities db , Expression<Func<Person_Address, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<Person_Address, dynamic> orderExpression = null);
 Person_Address GetPerson_AddressWithDetails(long idPerson_Address, List<string> includes = null,bool shouldRemap = false);
 Person_Address GetPerson_AddressWithDetails(long idPerson_Address, SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 Person_Address GetPerson_AddressWitDetails(long idPerson_Address,bool shouldRemap = false);
 Person_Address GetPerson_AddressWitDetails(long idPerson_Address, SubscriptionEntities db,bool shouldRemap = false);
 void SavePerson_Address(Person_Address person_Address);
 void SavePerson_Address(Person_Address person_Address, SubscriptionEntities db);
 void SaveOnlyPerson_Address(Person_Address person_Address);
 void SaveOnlyPerson_Address(Person_Address person_Address, SubscriptionEntities db);
 void DeletePerson_Address(Person_Address person_Address);
 void DeletePerson_Address(Person_Address person_Address, SubscriptionEntities db);		
  void DeletePermanentlyPerson_Address(Person_Address person_Address);
 void DeletePermanentlyPerson_Address(Person_Address person_Address, SubscriptionEntities db);	
	}
 	public partial interface IPerson_ContactTypeDao
	{
  List<Person_ContactType> GetAllPerson_ContactType(bool shouldRemap = false);
  List<Person_ContactType> GetAllPerson_ContactType(SubscriptionEntities db,bool shouldRemap = false);
  BaseListReturnType<Person_ContactType> GetAllPerson_ContactTypeByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Person_ContactType, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<Person_ContactType, dynamic> orderExpression = null);
  BaseListReturnType<Person_ContactType> GetAllPerson_ContactTypeByPage(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<Person_ContactType, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<Person_ContactType, dynamic> orderExpression = null);
  
  BaseListReturnType<Person_ContactType> GetAllPerson_ContactTypeByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Person_ContactType, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<Person_ContactType, dynamic> orderExpression = null);
  BaseListReturnType<Person_ContactType> GetAllPerson_ContactTypeByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<Person_ContactType, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<Person_ContactType, dynamic> orderExpression = null);

 BaseListReturnType<Person_ContactType> GetAllPerson_ContactTypeWithContactTypeDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Person_ContactType, bool>> expression = null,bool shouldRemap = false, Func<Person_ContactType, dynamic> orderExpression = null);
 BaseListReturnType<Person_ContactType> GetAllPerson_ContactTypeWithContactTypeDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Person_ContactType, bool>> expression = null,bool shouldRemap = false, Func<Person_ContactType, dynamic> orderExpression = null);






BaseListReturnType<Person_ContactType> GetAllPerson_ContactTypeListByContactType(long idContactType);

BaseListReturnType<Person_ContactType> GetAllPerson_ContactTypeListByContactType(long idContactType, SubscriptionEntities db);

BaseListReturnType<Person_ContactType> GetAllPerson_ContactTypeListByContactTypeByPage(long idContactType, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<Person_ContactType> GetAllPerson_ContactTypeListByContactTypeByPage(long idContactType, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);



 BaseListReturnType<Person_ContactType> GetAllPerson_ContactTypeWithPersonDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Person_ContactType, bool>> expression = null,bool shouldRemap = false, Func<Person_ContactType, dynamic> orderExpression = null);
 BaseListReturnType<Person_ContactType> GetAllPerson_ContactTypeWithPersonDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Person_ContactType, bool>> expression = null,bool shouldRemap = false, Func<Person_ContactType, dynamic> orderExpression = null);






BaseListReturnType<Person_ContactType> GetAllPerson_ContactTypeListByPerson(long idPerson);

BaseListReturnType<Person_ContactType> GetAllPerson_ContactTypeListByPerson(long idPerson, SubscriptionEntities db);

BaseListReturnType<Person_ContactType> GetAllPerson_ContactTypeListByPersonByPage(long idPerson, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<Person_ContactType> GetAllPerson_ContactTypeListByPersonByPage(long idPerson, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);




List<Person_ContactType> GetPerson_ContactTypeListByIdList(List<long> person_ContactTypeIds);

List<Person_ContactType> GetPerson_ContactTypeListByIdList(List<long> person_ContactTypeIds, SubscriptionEntities db);

 BaseListReturnType<Person_ContactType> GetAllPerson_ContactTypeWithContactTypeDetails(bool shouldRemap = false);
 BaseListReturnType<Person_ContactType> GetAllPerson_ContactTypeWithPersonDetails(bool shouldRemap = false);
 BaseListReturnType<Person_ContactType> GetAllPerson_ContactTypeWitDetails( List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<Person_ContactType> GetAllPerson_ContactTypeWitDetails( SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 Person_ContactType GetPerson_ContactType(long idPerson_ContactType,bool shouldRemap = false);
 Person_ContactType GetPerson_ContactType(long idPerson_ContactType, SubscriptionEntities db,bool shouldRemap = false);
 Person_ContactType GetPerson_ContactTypeWithContactTypeDetails(long idPerson_ContactType,bool shouldRemap = false);
    


 Person_ContactType GetPerson_ContactTypeWithPersonDetails(long idPerson_ContactType,bool shouldRemap = false);
    


 Person_ContactType GetPerson_ContactTypeCustom( Expression<Func<Person_ContactType, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 Person_ContactType GetPerson_ContactTypeCustom(SubscriptionEntities db, Expression<Func<Person_ContactType, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<Person_ContactType> GetPerson_ContactTypeCustomList( Expression<Func<Person_ContactType, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<Person_ContactType, dynamic> orderExpression = null);
 BaseListReturnType<Person_ContactType> GetPerson_ContactTypeCustomList( SubscriptionEntities db , Expression<Func<Person_ContactType, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<Person_ContactType, dynamic> orderExpression = null);
 Person_ContactType GetPerson_ContactTypeWithDetails(long idPerson_ContactType, List<string> includes = null,bool shouldRemap = false);
 Person_ContactType GetPerson_ContactTypeWithDetails(long idPerson_ContactType, SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 Person_ContactType GetPerson_ContactTypeWitDetails(long idPerson_ContactType,bool shouldRemap = false);
 Person_ContactType GetPerson_ContactTypeWitDetails(long idPerson_ContactType, SubscriptionEntities db,bool shouldRemap = false);
 void SavePerson_ContactType(Person_ContactType person_ContactType);
 void SavePerson_ContactType(Person_ContactType person_ContactType, SubscriptionEntities db);
 void SaveOnlyPerson_ContactType(Person_ContactType person_ContactType);
 void SaveOnlyPerson_ContactType(Person_ContactType person_ContactType, SubscriptionEntities db);
 void DeletePerson_ContactType(Person_ContactType person_ContactType);
 void DeletePerson_ContactType(Person_ContactType person_ContactType, SubscriptionEntities db);		
  void DeletePermanentlyPerson_ContactType(Person_ContactType person_ContactType);
 void DeletePermanentlyPerson_ContactType(Person_ContactType person_ContactType, SubscriptionEntities db);	
	}
 	public partial interface IProductDao
	{
  List<Product> GetAllProducts(bool shouldRemap = false);
  List<Product> GetAllProducts(SubscriptionEntities db,bool shouldRemap = false);
  BaseListReturnType<Product> GetAllProductsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Product, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<Product, dynamic> orderExpression = null);
  BaseListReturnType<Product> GetAllProductsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<Product, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<Product, dynamic> orderExpression = null);
  
  BaseListReturnType<Product> GetAllProductsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Product, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<Product, dynamic> orderExpression = null);
  BaseListReturnType<Product> GetAllProductsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<Product, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<Product, dynamic> orderExpression = null);

 BaseListReturnType<Product> GetAllProductsWithTransactionDetailPresetsDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Product, bool>> expression = null,bool shouldRemap = false, Func<Product, dynamic> orderExpression = null);
 BaseListReturnType<Product> GetAllProductsWithTransactionDetailPresetsDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Product, bool>> expression = null,bool shouldRemap = false, Func<Product, dynamic> orderExpression = null);

 BaseListReturnType<Product> GetAllProductsWithProductTypeDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Product, bool>> expression = null,bool shouldRemap = false, Func<Product, dynamic> orderExpression = null);
 BaseListReturnType<Product> GetAllProductsWithProductTypeDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Product, bool>> expression = null,bool shouldRemap = false, Func<Product, dynamic> orderExpression = null);






BaseListReturnType<Product> GetAllProductListByProductType(long idProductType);

BaseListReturnType<Product> GetAllProductListByProductType(long idProductType, SubscriptionEntities db);

BaseListReturnType<Product> GetAllProductListByProductTypeByPage(long idProductType, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<Product> GetAllProductListByProductTypeByPage(long idProductType, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);



 BaseListReturnType<Product> GetAllProductsWithOrderDetailsDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Product, bool>> expression = null,bool shouldRemap = false, Func<Product, dynamic> orderExpression = null);
 BaseListReturnType<Product> GetAllProductsWithOrderDetailsDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Product, bool>> expression = null,bool shouldRemap = false, Func<Product, dynamic> orderExpression = null);

 BaseListReturnType<Product> GetAllProductsWithProduct1DetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Product, bool>> expression = null,bool shouldRemap = false, Func<Product, dynamic> orderExpression = null);
 BaseListReturnType<Product> GetAllProductsWithProduct1DetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Product, bool>> expression = null,bool shouldRemap = false, Func<Product, dynamic> orderExpression = null);

 BaseListReturnType<Product> GetAllProductsWithProduct2DetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Product, bool>> expression = null,bool shouldRemap = false, Func<Product, dynamic> orderExpression = null);
 BaseListReturnType<Product> GetAllProductsWithProduct2DetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Product, bool>> expression = null,bool shouldRemap = false, Func<Product, dynamic> orderExpression = null);






BaseListReturnType<Product> GetAllProductListByProduct2(long idProduct2);

BaseListReturnType<Product> GetAllProductListByProduct2(long idProduct2, SubscriptionEntities db);

BaseListReturnType<Product> GetAllProductListByProduct2ByPage(long idProduct2, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<Product> GetAllProductListByProduct2ByPage(long idProduct2, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);



 BaseListReturnType<Product> GetAllProductsWithTransactionDetailsDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Product, bool>> expression = null,bool shouldRemap = false, Func<Product, dynamic> orderExpression = null);
 BaseListReturnType<Product> GetAllProductsWithTransactionDetailsDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Product, bool>> expression = null,bool shouldRemap = false, Func<Product, dynamic> orderExpression = null);


List<Product> GetProductListByIdList(List<long> productIds);

List<Product> GetProductListByIdList(List<long> productIds, SubscriptionEntities db);

 BaseListReturnType<Product> GetAllProductsWithTransactionDetailPresetsDetails(bool shouldRemap = false);
 BaseListReturnType<Product> GetAllProductsWithProductTypeDetails(bool shouldRemap = false);
 BaseListReturnType<Product> GetAllProductsWithOrderDetailsDetails(bool shouldRemap = false);
 BaseListReturnType<Product> GetAllProductsWithProduct1Details(bool shouldRemap = false);
 BaseListReturnType<Product> GetAllProductsWithProduct2Details(bool shouldRemap = false);
 BaseListReturnType<Product> GetAllProductsWithTransactionDetailsDetails(bool shouldRemap = false);
 BaseListReturnType<Product> GetAllProductWitDetails( List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<Product> GetAllProductWitDetails( SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 Product GetProduct(long idProduct,bool shouldRemap = false);
 Product GetProduct(long idProduct, SubscriptionEntities db,bool shouldRemap = false);
 Product GetProductWithTransactionDetailPresetsDetails(long idProduct,bool shouldRemap = false);
           List<TransactionDetailPreset> UpdateTransactionDetailPresetsForProductWithoutSavingNewItem(List<TransactionDetailPreset> newTransactionDetailPresets,long idProduct);
    List<TransactionDetailPreset> UpdateTransactionDetailPresetsForProductWithoutSavingNewItem(List<TransactionDetailPreset> newTransactionDetailPresets,long idProduct,SubscriptionEntities db);
          

    List<TransactionDetailPreset> UpdateTransactionDetailPresetsForProduct(List<TransactionDetailPreset> newTransactionDetailPresets,long idProduct);
    List<TransactionDetailPreset> UpdateTransactionDetailPresetsForProduct(List<TransactionDetailPreset> newTransactionDetailPresets,long idProduct,SubscriptionEntities db);
                           



 Product GetProductWithProductTypeDetails(long idProduct,bool shouldRemap = false);
    


 Product GetProductWithOrderDetailsDetails(long idProduct,bool shouldRemap = false);
           List<OrderDetail> UpdateOrderDetailsForProductWithoutSavingNewItem(List<OrderDetail> newOrderDetails,long idProduct);
    List<OrderDetail> UpdateOrderDetailsForProductWithoutSavingNewItem(List<OrderDetail> newOrderDetails,long idProduct,SubscriptionEntities db);
          

    List<OrderDetail> UpdateOrderDetailsForProduct(List<OrderDetail> newOrderDetails,long idProduct);
    List<OrderDetail> UpdateOrderDetailsForProduct(List<OrderDetail> newOrderDetails,long idProduct,SubscriptionEntities db);
                           



 Product GetProductWithProduct1Details(long idProduct,bool shouldRemap = false);
           List<Product> UpdateProduct1ForProductWithoutSavingNewItem(List<Product> newProduct1,long idProduct);
    List<Product> UpdateProduct1ForProductWithoutSavingNewItem(List<Product> newProduct1,long idProduct,SubscriptionEntities db);
          

    List<Product> UpdateProduct1ForProduct(List<Product> newProduct1,long idProduct);
    List<Product> UpdateProduct1ForProduct(List<Product> newProduct1,long idProduct,SubscriptionEntities db);
                           



 Product GetProductWithProduct2Details(long idProduct,bool shouldRemap = false);
    


 Product GetProductWithTransactionDetailsDetails(long idProduct,bool shouldRemap = false);
           List<TransactionDetail> UpdateTransactionDetailsForProductWithoutSavingNewItem(List<TransactionDetail> newTransactionDetails,long idProduct);
    List<TransactionDetail> UpdateTransactionDetailsForProductWithoutSavingNewItem(List<TransactionDetail> newTransactionDetails,long idProduct,SubscriptionEntities db);
          

    List<TransactionDetail> UpdateTransactionDetailsForProduct(List<TransactionDetail> newTransactionDetails,long idProduct);
    List<TransactionDetail> UpdateTransactionDetailsForProduct(List<TransactionDetail> newTransactionDetails,long idProduct,SubscriptionEntities db);
                           



 Product GetProductCustom( Expression<Func<Product, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 Product GetProductCustom(SubscriptionEntities db, Expression<Func<Product, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<Product> GetProductCustomList( Expression<Func<Product, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<Product, dynamic> orderExpression = null);
 BaseListReturnType<Product> GetProductCustomList( SubscriptionEntities db , Expression<Func<Product, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<Product, dynamic> orderExpression = null);
 Product GetProductWithDetails(long idProduct, List<string> includes = null,bool shouldRemap = false);
 Product GetProductWithDetails(long idProduct, SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 Product GetProductWitDetails(long idProduct,bool shouldRemap = false);
 Product GetProductWitDetails(long idProduct, SubscriptionEntities db,bool shouldRemap = false);
 void SaveProduct(Product product);
 void SaveProduct(Product product, SubscriptionEntities db);
 void SaveOnlyProduct(Product product);
 void SaveOnlyProduct(Product product, SubscriptionEntities db);
 void DeleteProduct(Product product);
 void DeleteProduct(Product product, SubscriptionEntities db);		
  void DeletePermanentlyProduct(Product product);
 void DeletePermanentlyProduct(Product product, SubscriptionEntities db);	
	}
 	public partial interface IProductTypeDao
	{
  List<ProductType> GetAllProductTypes(bool shouldRemap = false);
  List<ProductType> GetAllProductTypes(SubscriptionEntities db,bool shouldRemap = false);
  BaseListReturnType<ProductType> GetAllProductTypesByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<ProductType, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<ProductType, dynamic> orderExpression = null);
  BaseListReturnType<ProductType> GetAllProductTypesByPage(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<ProductType, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<ProductType, dynamic> orderExpression = null);
  
  BaseListReturnType<ProductType> GetAllProductTypesByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<ProductType, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<ProductType, dynamic> orderExpression = null);
  BaseListReturnType<ProductType> GetAllProductTypesByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<ProductType, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<ProductType, dynamic> orderExpression = null);

 BaseListReturnType<ProductType> GetAllProductTypesWithProductsDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<ProductType, bool>> expression = null,bool shouldRemap = false, Func<ProductType, dynamic> orderExpression = null);
 BaseListReturnType<ProductType> GetAllProductTypesWithProductsDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<ProductType, bool>> expression = null,bool shouldRemap = false, Func<ProductType, dynamic> orderExpression = null);


List<ProductType> GetProductTypeListByIdList(List<long> productTypeIds);

List<ProductType> GetProductTypeListByIdList(List<long> productTypeIds, SubscriptionEntities db);

 BaseListReturnType<ProductType> GetAllProductTypesWithProductsDetails(bool shouldRemap = false);
 BaseListReturnType<ProductType> GetAllProductTypeWitDetails( List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<ProductType> GetAllProductTypeWitDetails( SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 ProductType GetProductType(long idProductType,bool shouldRemap = false);
 ProductType GetProductType(long idProductType, SubscriptionEntities db,bool shouldRemap = false);
 ProductType GetProductTypeWithProductsDetails(long idProductType,bool shouldRemap = false);
           List<Product> UpdateProductsForProductTypeWithoutSavingNewItem(List<Product> newProducts,long idProductType);
    List<Product> UpdateProductsForProductTypeWithoutSavingNewItem(List<Product> newProducts,long idProductType,SubscriptionEntities db);
          

    List<Product> UpdateProductsForProductType(List<Product> newProducts,long idProductType);
    List<Product> UpdateProductsForProductType(List<Product> newProducts,long idProductType,SubscriptionEntities db);
                           



 ProductType GetProductTypeCustom( Expression<Func<ProductType, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 ProductType GetProductTypeCustom(SubscriptionEntities db, Expression<Func<ProductType, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<ProductType> GetProductTypeCustomList( Expression<Func<ProductType, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<ProductType, dynamic> orderExpression = null);
 BaseListReturnType<ProductType> GetProductTypeCustomList( SubscriptionEntities db , Expression<Func<ProductType, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<ProductType, dynamic> orderExpression = null);
 ProductType GetProductTypeWithDetails(long idProductType, List<string> includes = null,bool shouldRemap = false);
 ProductType GetProductTypeWithDetails(long idProductType, SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 ProductType GetProductTypeWitDetails(long idProductType,bool shouldRemap = false);
 ProductType GetProductTypeWitDetails(long idProductType, SubscriptionEntities db,bool shouldRemap = false);
 void SaveProductType(ProductType productType);
 void SaveProductType(ProductType productType, SubscriptionEntities db);
 void SaveOnlyProductType(ProductType productType);
 void SaveOnlyProductType(ProductType productType, SubscriptionEntities db);
 void DeleteProductType(ProductType productType);
 void DeleteProductType(ProductType productType, SubscriptionEntities db);		
  void DeletePermanentlyProductType(ProductType productType);
 void DeletePermanentlyProductType(ProductType productType, SubscriptionEntities db);	
	}
 	public partial interface IReceiptDao
	{
  List<Receipt> GetAllReceipts(bool shouldRemap = false);
  List<Receipt> GetAllReceipts(SubscriptionEntities db,bool shouldRemap = false);
  BaseListReturnType<Receipt> GetAllReceiptsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Receipt, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<Receipt, dynamic> orderExpression = null);
  BaseListReturnType<Receipt> GetAllReceiptsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<Receipt, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<Receipt, dynamic> orderExpression = null);
  
  BaseListReturnType<Receipt> GetAllReceiptsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Receipt, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<Receipt, dynamic> orderExpression = null);
  BaseListReturnType<Receipt> GetAllReceiptsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<Receipt, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<Receipt, dynamic> orderExpression = null);

 BaseListReturnType<Receipt> GetAllReceiptsWithUserDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Receipt, bool>> expression = null,bool shouldRemap = false, Func<Receipt, dynamic> orderExpression = null);
 BaseListReturnType<Receipt> GetAllReceiptsWithUserDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Receipt, bool>> expression = null,bool shouldRemap = false, Func<Receipt, dynamic> orderExpression = null);






BaseListReturnType<Receipt> GetAllReceiptListByUser(long idUser);

BaseListReturnType<Receipt> GetAllReceiptListByUser(long idUser, SubscriptionEntities db);

BaseListReturnType<Receipt> GetAllReceiptListByUserByPage(long idUser, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<Receipt> GetAllReceiptListByUserByPage(long idUser, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);




List<Receipt> GetReceiptListByIdList(List<long> receiptIds);

List<Receipt> GetReceiptListByIdList(List<long> receiptIds, SubscriptionEntities db);

 BaseListReturnType<Receipt> GetAllReceiptsWithUserDetails(bool shouldRemap = false);
 BaseListReturnType<Receipt> GetAllReceiptWitDetails( List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<Receipt> GetAllReceiptWitDetails( SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 Receipt GetReceipt(long idReceipt,bool shouldRemap = false);
 Receipt GetReceipt(long idReceipt, SubscriptionEntities db,bool shouldRemap = false);
 Receipt GetReceiptWithUserDetails(long idReceipt,bool shouldRemap = false);
    


 Receipt GetReceiptCustom( Expression<Func<Receipt, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 Receipt GetReceiptCustom(SubscriptionEntities db, Expression<Func<Receipt, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<Receipt> GetReceiptCustomList( Expression<Func<Receipt, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<Receipt, dynamic> orderExpression = null);
 BaseListReturnType<Receipt> GetReceiptCustomList( SubscriptionEntities db , Expression<Func<Receipt, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<Receipt, dynamic> orderExpression = null);
 Receipt GetReceiptWithDetails(long idReceipt, List<string> includes = null,bool shouldRemap = false);
 Receipt GetReceiptWithDetails(long idReceipt, SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 Receipt GetReceiptWitDetails(long idReceipt,bool shouldRemap = false);
 Receipt GetReceiptWitDetails(long idReceipt, SubscriptionEntities db,bool shouldRemap = false);
 void SaveReceipt(Receipt receipt);
 void SaveReceipt(Receipt receipt, SubscriptionEntities db);
 void SaveOnlyReceipt(Receipt receipt);
 void SaveOnlyReceipt(Receipt receipt, SubscriptionEntities db);
 void DeleteReceipt(Receipt receipt);
 void DeleteReceipt(Receipt receipt, SubscriptionEntities db);		
  void DeletePermanentlyReceipt(Receipt receipt);
 void DeletePermanentlyReceipt(Receipt receipt, SubscriptionEntities db);	
	}
 	public partial interface IRequestDao
	{
  List<Request> GetAllRequests(bool shouldRemap = false);
  List<Request> GetAllRequests(SubscriptionEntities db,bool shouldRemap = false);
  BaseListReturnType<Request> GetAllRequestsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Request, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<Request, dynamic> orderExpression = null);
  BaseListReturnType<Request> GetAllRequestsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<Request, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<Request, dynamic> orderExpression = null);
  
  BaseListReturnType<Request> GetAllRequestsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Request, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<Request, dynamic> orderExpression = null);
  BaseListReturnType<Request> GetAllRequestsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<Request, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<Request, dynamic> orderExpression = null);

 BaseListReturnType<Request> GetAllRequestsWithRequestTypeDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Request, bool>> expression = null,bool shouldRemap = false, Func<Request, dynamic> orderExpression = null);
 BaseListReturnType<Request> GetAllRequestsWithRequestTypeDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Request, bool>> expression = null,bool shouldRemap = false, Func<Request, dynamic> orderExpression = null);






BaseListReturnType<Request> GetAllRequestListByRequestType(long idRequestType);

BaseListReturnType<Request> GetAllRequestListByRequestType(long idRequestType, SubscriptionEntities db);

BaseListReturnType<Request> GetAllRequestListByRequestTypeByPage(long idRequestType, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<Request> GetAllRequestListByRequestTypeByPage(long idRequestType, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);



 BaseListReturnType<Request> GetAllRequestsWithWorkflowStateDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Request, bool>> expression = null,bool shouldRemap = false, Func<Request, dynamic> orderExpression = null);
 BaseListReturnType<Request> GetAllRequestsWithWorkflowStateDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Request, bool>> expression = null,bool shouldRemap = false, Func<Request, dynamic> orderExpression = null);






BaseListReturnType<Request> GetAllRequestListByWorkflowState(long idWorkflowState);

BaseListReturnType<Request> GetAllRequestListByWorkflowState(long idWorkflowState, SubscriptionEntities db);

BaseListReturnType<Request> GetAllRequestListByWorkflowStateByPage(long idWorkflowState, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<Request> GetAllRequestListByWorkflowStateByPage(long idWorkflowState, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);



 BaseListReturnType<Request> GetAllRequestsWithRequestMessageQueuesDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Request, bool>> expression = null,bool shouldRemap = false, Func<Request, dynamic> orderExpression = null);
 BaseListReturnType<Request> GetAllRequestsWithRequestMessageQueuesDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Request, bool>> expression = null,bool shouldRemap = false, Func<Request, dynamic> orderExpression = null);


List<Request> GetRequestListByIdList(List<long> requestIds);

List<Request> GetRequestListByIdList(List<long> requestIds, SubscriptionEntities db);

 BaseListReturnType<Request> GetAllRequestsWithRequestTypeDetails(bool shouldRemap = false);
 BaseListReturnType<Request> GetAllRequestsWithWorkflowStateDetails(bool shouldRemap = false);
 BaseListReturnType<Request> GetAllRequestsWithRequestMessageQueuesDetails(bool shouldRemap = false);
 BaseListReturnType<Request> GetAllRequestWitDetails( List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<Request> GetAllRequestWitDetails( SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 Request GetRequest(long idRequest,bool shouldRemap = false);
 Request GetRequest(long idRequest, SubscriptionEntities db,bool shouldRemap = false);
 Request GetRequestWithRequestTypeDetails(long idRequest,bool shouldRemap = false);
    


 Request GetRequestWithWorkflowStateDetails(long idRequest,bool shouldRemap = false);
    


 Request GetRequestWithRequestMessageQueuesDetails(long idRequest,bool shouldRemap = false);
           List<RequestMessageQueue> UpdateRequestMessageQueuesForRequestWithoutSavingNewItem(List<RequestMessageQueue> newRequestMessageQueues,long idRequest);
    List<RequestMessageQueue> UpdateRequestMessageQueuesForRequestWithoutSavingNewItem(List<RequestMessageQueue> newRequestMessageQueues,long idRequest,SubscriptionEntities db);
          

    List<RequestMessageQueue> UpdateRequestMessageQueuesForRequest(List<RequestMessageQueue> newRequestMessageQueues,long idRequest);
    List<RequestMessageQueue> UpdateRequestMessageQueuesForRequest(List<RequestMessageQueue> newRequestMessageQueues,long idRequest,SubscriptionEntities db);
                           



 Request GetRequestCustom( Expression<Func<Request, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 Request GetRequestCustom(SubscriptionEntities db, Expression<Func<Request, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<Request> GetRequestCustomList( Expression<Func<Request, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<Request, dynamic> orderExpression = null);
 BaseListReturnType<Request> GetRequestCustomList( SubscriptionEntities db , Expression<Func<Request, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<Request, dynamic> orderExpression = null);
 Request GetRequestWithDetails(long idRequest, List<string> includes = null,bool shouldRemap = false);
 Request GetRequestWithDetails(long idRequest, SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 Request GetRequestWitDetails(long idRequest,bool shouldRemap = false);
 Request GetRequestWitDetails(long idRequest, SubscriptionEntities db,bool shouldRemap = false);
 void SaveRequest(Request request);
 void SaveRequest(Request request, SubscriptionEntities db);
 void SaveOnlyRequest(Request request);
 void SaveOnlyRequest(Request request, SubscriptionEntities db);
 void DeleteRequest(Request request);
 void DeleteRequest(Request request, SubscriptionEntities db);		
  void DeletePermanentlyRequest(Request request);
 void DeletePermanentlyRequest(Request request, SubscriptionEntities db);	
	}
 	public partial interface IRequestMessageQueueDao
	{
  List<RequestMessageQueue> GetAllRequestMessageQueues(bool shouldRemap = false);
  List<RequestMessageQueue> GetAllRequestMessageQueues(SubscriptionEntities db,bool shouldRemap = false);
  BaseListReturnType<RequestMessageQueue> GetAllRequestMessageQueuesByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<RequestMessageQueue, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<RequestMessageQueue, dynamic> orderExpression = null);
  BaseListReturnType<RequestMessageQueue> GetAllRequestMessageQueuesByPage(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<RequestMessageQueue, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<RequestMessageQueue, dynamic> orderExpression = null);
  
  BaseListReturnType<RequestMessageQueue> GetAllRequestMessageQueuesByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<RequestMessageQueue, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<RequestMessageQueue, dynamic> orderExpression = null);
  BaseListReturnType<RequestMessageQueue> GetAllRequestMessageQueuesByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<RequestMessageQueue, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<RequestMessageQueue, dynamic> orderExpression = null);

 BaseListReturnType<RequestMessageQueue> GetAllRequestMessageQueuesWithRequestDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<RequestMessageQueue, bool>> expression = null,bool shouldRemap = false, Func<RequestMessageQueue, dynamic> orderExpression = null);
 BaseListReturnType<RequestMessageQueue> GetAllRequestMessageQueuesWithRequestDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<RequestMessageQueue, bool>> expression = null,bool shouldRemap = false, Func<RequestMessageQueue, dynamic> orderExpression = null);






BaseListReturnType<RequestMessageQueue> GetAllRequestMessageQueueListByRequest(long idRequest);

BaseListReturnType<RequestMessageQueue> GetAllRequestMessageQueueListByRequest(long idRequest, SubscriptionEntities db);

BaseListReturnType<RequestMessageQueue> GetAllRequestMessageQueueListByRequestByPage(long idRequest, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<RequestMessageQueue> GetAllRequestMessageQueueListByRequestByPage(long idRequest, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);




List<RequestMessageQueue> GetRequestMessageQueueListByIdList(List<long> requestMessageQueueIds);

List<RequestMessageQueue> GetRequestMessageQueueListByIdList(List<long> requestMessageQueueIds, SubscriptionEntities db);

 BaseListReturnType<RequestMessageQueue> GetAllRequestMessageQueuesWithRequestDetails(bool shouldRemap = false);
 BaseListReturnType<RequestMessageQueue> GetAllRequestMessageQueueWitDetails( List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<RequestMessageQueue> GetAllRequestMessageQueueWitDetails( SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 RequestMessageQueue GetRequestMessageQueue(long idRequestMessageQueue,bool shouldRemap = false);
 RequestMessageQueue GetRequestMessageQueue(long idRequestMessageQueue, SubscriptionEntities db,bool shouldRemap = false);
 RequestMessageQueue GetRequestMessageQueueWithRequestDetails(long idRequestMessageQueue,bool shouldRemap = false);
    


 RequestMessageQueue GetRequestMessageQueueCustom( Expression<Func<RequestMessageQueue, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 RequestMessageQueue GetRequestMessageQueueCustom(SubscriptionEntities db, Expression<Func<RequestMessageQueue, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<RequestMessageQueue> GetRequestMessageQueueCustomList( Expression<Func<RequestMessageQueue, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<RequestMessageQueue, dynamic> orderExpression = null);
 BaseListReturnType<RequestMessageQueue> GetRequestMessageQueueCustomList( SubscriptionEntities db , Expression<Func<RequestMessageQueue, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<RequestMessageQueue, dynamic> orderExpression = null);
 RequestMessageQueue GetRequestMessageQueueWithDetails(long idRequestMessageQueue, List<string> includes = null,bool shouldRemap = false);
 RequestMessageQueue GetRequestMessageQueueWithDetails(long idRequestMessageQueue, SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 RequestMessageQueue GetRequestMessageQueueWitDetails(long idRequestMessageQueue,bool shouldRemap = false);
 RequestMessageQueue GetRequestMessageQueueWitDetails(long idRequestMessageQueue, SubscriptionEntities db,bool shouldRemap = false);
 void SaveRequestMessageQueue(RequestMessageQueue requestMessageQueue);
 void SaveRequestMessageQueue(RequestMessageQueue requestMessageQueue, SubscriptionEntities db);
 void SaveOnlyRequestMessageQueue(RequestMessageQueue requestMessageQueue);
 void SaveOnlyRequestMessageQueue(RequestMessageQueue requestMessageQueue, SubscriptionEntities db);
 void DeleteRequestMessageQueue(RequestMessageQueue requestMessageQueue);
 void DeleteRequestMessageQueue(RequestMessageQueue requestMessageQueue, SubscriptionEntities db);		
  void DeletePermanentlyRequestMessageQueue(RequestMessageQueue requestMessageQueue);
 void DeletePermanentlyRequestMessageQueue(RequestMessageQueue requestMessageQueue, SubscriptionEntities db);	
	}
 	public partial interface IRequestTypeDao
	{
  List<RequestType> GetAllRequestTypes(bool shouldRemap = false);
  List<RequestType> GetAllRequestTypes(SubscriptionEntities db,bool shouldRemap = false);
  BaseListReturnType<RequestType> GetAllRequestTypesByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<RequestType, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<RequestType, dynamic> orderExpression = null);
  BaseListReturnType<RequestType> GetAllRequestTypesByPage(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<RequestType, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<RequestType, dynamic> orderExpression = null);
  
  BaseListReturnType<RequestType> GetAllRequestTypesByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<RequestType, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<RequestType, dynamic> orderExpression = null);
  BaseListReturnType<RequestType> GetAllRequestTypesByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<RequestType, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<RequestType, dynamic> orderExpression = null);

 BaseListReturnType<RequestType> GetAllRequestTypesWithRequestsDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<RequestType, bool>> expression = null,bool shouldRemap = false, Func<RequestType, dynamic> orderExpression = null);
 BaseListReturnType<RequestType> GetAllRequestTypesWithRequestsDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<RequestType, bool>> expression = null,bool shouldRemap = false, Func<RequestType, dynamic> orderExpression = null);

 BaseListReturnType<RequestType> GetAllRequestTypesWithWorkflowDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<RequestType, bool>> expression = null,bool shouldRemap = false, Func<RequestType, dynamic> orderExpression = null);
 BaseListReturnType<RequestType> GetAllRequestTypesWithWorkflowDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<RequestType, bool>> expression = null,bool shouldRemap = false, Func<RequestType, dynamic> orderExpression = null);






BaseListReturnType<RequestType> GetAllRequestTypeListByWorkflow(long idWorkflow);

BaseListReturnType<RequestType> GetAllRequestTypeListByWorkflow(long idWorkflow, SubscriptionEntities db);

BaseListReturnType<RequestType> GetAllRequestTypeListByWorkflowByPage(long idWorkflow, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<RequestType> GetAllRequestTypeListByWorkflowByPage(long idWorkflow, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);



 BaseListReturnType<RequestType> GetAllRequestTypesWithRequestType_UserDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<RequestType, bool>> expression = null,bool shouldRemap = false, Func<RequestType, dynamic> orderExpression = null);
 BaseListReturnType<RequestType> GetAllRequestTypesWithRequestType_UserDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<RequestType, bool>> expression = null,bool shouldRemap = false, Func<RequestType, dynamic> orderExpression = null);


List<RequestType> GetRequestTypeListByIdList(List<long> requestTypeIds);

List<RequestType> GetRequestTypeListByIdList(List<long> requestTypeIds, SubscriptionEntities db);

 BaseListReturnType<RequestType> GetAllRequestTypesWithRequestsDetails(bool shouldRemap = false);
 BaseListReturnType<RequestType> GetAllRequestTypesWithWorkflowDetails(bool shouldRemap = false);
 BaseListReturnType<RequestType> GetAllRequestTypesWithRequestType_UserDetails(bool shouldRemap = false);
 BaseListReturnType<RequestType> GetAllRequestTypeWitDetails( List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<RequestType> GetAllRequestTypeWitDetails( SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 RequestType GetRequestType(long idRequestType,bool shouldRemap = false);
 RequestType GetRequestType(long idRequestType, SubscriptionEntities db,bool shouldRemap = false);
 RequestType GetRequestTypeWithRequestsDetails(long idRequestType,bool shouldRemap = false);
           List<Request> UpdateRequestsForRequestTypeWithoutSavingNewItem(List<Request> newRequests,long idRequestType);
    List<Request> UpdateRequestsForRequestTypeWithoutSavingNewItem(List<Request> newRequests,long idRequestType,SubscriptionEntities db);
          

    List<Request> UpdateRequestsForRequestType(List<Request> newRequests,long idRequestType);
    List<Request> UpdateRequestsForRequestType(List<Request> newRequests,long idRequestType,SubscriptionEntities db);
                           



 RequestType GetRequestTypeWithWorkflowDetails(long idRequestType,bool shouldRemap = false);
    


 RequestType GetRequestTypeWithRequestType_UserDetails(long idRequestType,bool shouldRemap = false);
           List<RequestType_User> UpdateRequestType_UserForRequestTypeWithoutSavingNewItem(List<RequestType_User> newRequestType_User,long idRequestType);
    List<RequestType_User> UpdateRequestType_UserForRequestTypeWithoutSavingNewItem(List<RequestType_User> newRequestType_User,long idRequestType,SubscriptionEntities db);
          

    List<RequestType_User> UpdateRequestType_UserForRequestType(List<RequestType_User> newRequestType_User,long idRequestType);
    List<RequestType_User> UpdateRequestType_UserForRequestType(List<RequestType_User> newRequestType_User,long idRequestType,SubscriptionEntities db);
                           



 RequestType GetRequestTypeCustom( Expression<Func<RequestType, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 RequestType GetRequestTypeCustom(SubscriptionEntities db, Expression<Func<RequestType, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<RequestType> GetRequestTypeCustomList( Expression<Func<RequestType, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<RequestType, dynamic> orderExpression = null);
 BaseListReturnType<RequestType> GetRequestTypeCustomList( SubscriptionEntities db , Expression<Func<RequestType, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<RequestType, dynamic> orderExpression = null);
 RequestType GetRequestTypeWithDetails(long idRequestType, List<string> includes = null,bool shouldRemap = false);
 RequestType GetRequestTypeWithDetails(long idRequestType, SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 RequestType GetRequestTypeWitDetails(long idRequestType,bool shouldRemap = false);
 RequestType GetRequestTypeWitDetails(long idRequestType, SubscriptionEntities db,bool shouldRemap = false);
 void SaveRequestType(RequestType requestType);
 void SaveRequestType(RequestType requestType, SubscriptionEntities db);
 void SaveOnlyRequestType(RequestType requestType);
 void SaveOnlyRequestType(RequestType requestType, SubscriptionEntities db);
 void DeleteRequestType(RequestType requestType);
 void DeleteRequestType(RequestType requestType, SubscriptionEntities db);		
  void DeletePermanentlyRequestType(RequestType requestType);
 void DeletePermanentlyRequestType(RequestType requestType, SubscriptionEntities db);	
	}
 	public partial interface IRequestType_UserDao
	{
  List<RequestType_User> GetAllRequestType_User(bool shouldRemap = false);
  List<RequestType_User> GetAllRequestType_User(SubscriptionEntities db,bool shouldRemap = false);
  BaseListReturnType<RequestType_User> GetAllRequestType_UserByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<RequestType_User, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<RequestType_User, dynamic> orderExpression = null);
  BaseListReturnType<RequestType_User> GetAllRequestType_UserByPage(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<RequestType_User, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<RequestType_User, dynamic> orderExpression = null);
  
  BaseListReturnType<RequestType_User> GetAllRequestType_UserByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<RequestType_User, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<RequestType_User, dynamic> orderExpression = null);
  BaseListReturnType<RequestType_User> GetAllRequestType_UserByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<RequestType_User, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<RequestType_User, dynamic> orderExpression = null);

 BaseListReturnType<RequestType_User> GetAllRequestType_UserWithUserDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<RequestType_User, bool>> expression = null,bool shouldRemap = false, Func<RequestType_User, dynamic> orderExpression = null);
 BaseListReturnType<RequestType_User> GetAllRequestType_UserWithUserDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<RequestType_User, bool>> expression = null,bool shouldRemap = false, Func<RequestType_User, dynamic> orderExpression = null);






BaseListReturnType<RequestType_User> GetAllRequestType_UserListByUser(long idUser);

BaseListReturnType<RequestType_User> GetAllRequestType_UserListByUser(long idUser, SubscriptionEntities db);

BaseListReturnType<RequestType_User> GetAllRequestType_UserListByUserByPage(long idUser, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<RequestType_User> GetAllRequestType_UserListByUserByPage(long idUser, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);



 BaseListReturnType<RequestType_User> GetAllRequestType_UserWithRequestTypeDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<RequestType_User, bool>> expression = null,bool shouldRemap = false, Func<RequestType_User, dynamic> orderExpression = null);
 BaseListReturnType<RequestType_User> GetAllRequestType_UserWithRequestTypeDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<RequestType_User, bool>> expression = null,bool shouldRemap = false, Func<RequestType_User, dynamic> orderExpression = null);






BaseListReturnType<RequestType_User> GetAllRequestType_UserListByRequestType(long idRequestType);

BaseListReturnType<RequestType_User> GetAllRequestType_UserListByRequestType(long idRequestType, SubscriptionEntities db);

BaseListReturnType<RequestType_User> GetAllRequestType_UserListByRequestTypeByPage(long idRequestType, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<RequestType_User> GetAllRequestType_UserListByRequestTypeByPage(long idRequestType, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);



 BaseListReturnType<RequestType_User> GetAllRequestType_UserWithRequestType_User1DetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<RequestType_User, bool>> expression = null,bool shouldRemap = false, Func<RequestType_User, dynamic> orderExpression = null);
 BaseListReturnType<RequestType_User> GetAllRequestType_UserWithRequestType_User1DetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<RequestType_User, bool>> expression = null,bool shouldRemap = false, Func<RequestType_User, dynamic> orderExpression = null);

 BaseListReturnType<RequestType_User> GetAllRequestType_UserWithRequestType_User2DetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<RequestType_User, bool>> expression = null,bool shouldRemap = false, Func<RequestType_User, dynamic> orderExpression = null);
 BaseListReturnType<RequestType_User> GetAllRequestType_UserWithRequestType_User2DetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<RequestType_User, bool>> expression = null,bool shouldRemap = false, Func<RequestType_User, dynamic> orderExpression = null);






BaseListReturnType<RequestType_User> GetAllRequestType_UserListByRequestType_User2(long idRequestType_User2);

BaseListReturnType<RequestType_User> GetAllRequestType_UserListByRequestType_User2(long idRequestType_User2, SubscriptionEntities db);

BaseListReturnType<RequestType_User> GetAllRequestType_UserListByRequestType_User2ByPage(long idRequestType_User2, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<RequestType_User> GetAllRequestType_UserListByRequestType_User2ByPage(long idRequestType_User2, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);




List<RequestType_User> GetRequestType_UserListByIdList(List<long> requestType_UserIds);

List<RequestType_User> GetRequestType_UserListByIdList(List<long> requestType_UserIds, SubscriptionEntities db);

 BaseListReturnType<RequestType_User> GetAllRequestType_UserWithUserDetails(bool shouldRemap = false);
 BaseListReturnType<RequestType_User> GetAllRequestType_UserWithRequestTypeDetails(bool shouldRemap = false);
 BaseListReturnType<RequestType_User> GetAllRequestType_UserWithRequestType_User1Details(bool shouldRemap = false);
 BaseListReturnType<RequestType_User> GetAllRequestType_UserWithRequestType_User2Details(bool shouldRemap = false);
 BaseListReturnType<RequestType_User> GetAllRequestType_UserWitDetails( List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<RequestType_User> GetAllRequestType_UserWitDetails( SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 RequestType_User GetRequestType_User(long idRequestType_User,bool shouldRemap = false);
 RequestType_User GetRequestType_User(long idRequestType_User, SubscriptionEntities db,bool shouldRemap = false);
 RequestType_User GetRequestType_UserWithUserDetails(long idRequestType_User,bool shouldRemap = false);
    


 RequestType_User GetRequestType_UserWithRequestTypeDetails(long idRequestType_User,bool shouldRemap = false);
    


 RequestType_User GetRequestType_UserWithRequestType_User1Details(long idRequestType_User,bool shouldRemap = false);
           List<RequestType_User> UpdateRequestType_User1ForRequestType_UserWithoutSavingNewItem(List<RequestType_User> newRequestType_User1,long idRequestType_User);
    List<RequestType_User> UpdateRequestType_User1ForRequestType_UserWithoutSavingNewItem(List<RequestType_User> newRequestType_User1,long idRequestType_User,SubscriptionEntities db);
          

    List<RequestType_User> UpdateRequestType_User1ForRequestType_User(List<RequestType_User> newRequestType_User1,long idRequestType_User);
    List<RequestType_User> UpdateRequestType_User1ForRequestType_User(List<RequestType_User> newRequestType_User1,long idRequestType_User,SubscriptionEntities db);
                           



 RequestType_User GetRequestType_UserWithRequestType_User2Details(long idRequestType_User,bool shouldRemap = false);
    


 RequestType_User GetRequestType_UserCustom( Expression<Func<RequestType_User, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 RequestType_User GetRequestType_UserCustom(SubscriptionEntities db, Expression<Func<RequestType_User, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<RequestType_User> GetRequestType_UserCustomList( Expression<Func<RequestType_User, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<RequestType_User, dynamic> orderExpression = null);
 BaseListReturnType<RequestType_User> GetRequestType_UserCustomList( SubscriptionEntities db , Expression<Func<RequestType_User, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<RequestType_User, dynamic> orderExpression = null);
 RequestType_User GetRequestType_UserWithDetails(long idRequestType_User, List<string> includes = null,bool shouldRemap = false);
 RequestType_User GetRequestType_UserWithDetails(long idRequestType_User, SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 RequestType_User GetRequestType_UserWitDetails(long idRequestType_User,bool shouldRemap = false);
 RequestType_User GetRequestType_UserWitDetails(long idRequestType_User, SubscriptionEntities db,bool shouldRemap = false);
 void SaveRequestType_User(RequestType_User requestType_User);
 void SaveRequestType_User(RequestType_User requestType_User, SubscriptionEntities db);
 void SaveOnlyRequestType_User(RequestType_User requestType_User);
 void SaveOnlyRequestType_User(RequestType_User requestType_User, SubscriptionEntities db);
 void DeleteRequestType_User(RequestType_User requestType_User);
 void DeleteRequestType_User(RequestType_User requestType_User, SubscriptionEntities db);		
  void DeletePermanentlyRequestType_User(RequestType_User requestType_User);
 void DeletePermanentlyRequestType_User(RequestType_User requestType_User, SubscriptionEntities db);	
	}
 	public partial interface IRoleDao
	{
  List<Role> GetAllRoles(bool shouldRemap = false);
  List<Role> GetAllRoles(SubscriptionEntities db,bool shouldRemap = false);
  BaseListReturnType<Role> GetAllRolesByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Role, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<Role, dynamic> orderExpression = null);
  BaseListReturnType<Role> GetAllRolesByPage(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<Role, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<Role, dynamic> orderExpression = null);
  
  BaseListReturnType<Role> GetAllRolesByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Role, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<Role, dynamic> orderExpression = null);
  BaseListReturnType<Role> GetAllRolesByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<Role, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<Role, dynamic> orderExpression = null);

 BaseListReturnType<Role> GetAllRolesWithRole_PermissionDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Role, bool>> expression = null,bool shouldRemap = false, Func<Role, dynamic> orderExpression = null);
 BaseListReturnType<Role> GetAllRolesWithRole_PermissionDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Role, bool>> expression = null,bool shouldRemap = false, Func<Role, dynamic> orderExpression = null);

 BaseListReturnType<Role> GetAllRolesWithUser_RoleDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Role, bool>> expression = null,bool shouldRemap = false, Func<Role, dynamic> orderExpression = null);
 BaseListReturnType<Role> GetAllRolesWithUser_RoleDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Role, bool>> expression = null,bool shouldRemap = false, Func<Role, dynamic> orderExpression = null);


List<Role> GetRoleListByIdList(List<long> roleIds);

List<Role> GetRoleListByIdList(List<long> roleIds, SubscriptionEntities db);

 BaseListReturnType<Role> GetAllRolesWithRole_PermissionDetails(bool shouldRemap = false);
 BaseListReturnType<Role> GetAllRolesWithUser_RoleDetails(bool shouldRemap = false);
 BaseListReturnType<Role> GetAllRoleWitDetails( List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<Role> GetAllRoleWitDetails( SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 Role GetRole(long idRole,bool shouldRemap = false);
 Role GetRole(long idRole, SubscriptionEntities db,bool shouldRemap = false);
 Role GetRoleWithRole_PermissionDetails(long idRole,bool shouldRemap = false);
           List<Role_Permission> UpdateRole_PermissionForRoleWithoutSavingNewItem(List<Role_Permission> newRole_Permission,long idRole);
    List<Role_Permission> UpdateRole_PermissionForRoleWithoutSavingNewItem(List<Role_Permission> newRole_Permission,long idRole,SubscriptionEntities db);
          

    List<Role_Permission> UpdateRole_PermissionForRole(List<Role_Permission> newRole_Permission,long idRole);
    List<Role_Permission> UpdateRole_PermissionForRole(List<Role_Permission> newRole_Permission,long idRole,SubscriptionEntities db);
                           



 Role GetRoleWithUser_RoleDetails(long idRole,bool shouldRemap = false);
           List<User_Role> UpdateUser_RoleForRoleWithoutSavingNewItem(List<User_Role> newUser_Role,long idRole);
    List<User_Role> UpdateUser_RoleForRoleWithoutSavingNewItem(List<User_Role> newUser_Role,long idRole,SubscriptionEntities db);
          

    List<User_Role> UpdateUser_RoleForRole(List<User_Role> newUser_Role,long idRole);
    List<User_Role> UpdateUser_RoleForRole(List<User_Role> newUser_Role,long idRole,SubscriptionEntities db);
                           



 Role GetRoleCustom( Expression<Func<Role, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 Role GetRoleCustom(SubscriptionEntities db, Expression<Func<Role, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<Role> GetRoleCustomList( Expression<Func<Role, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<Role, dynamic> orderExpression = null);
 BaseListReturnType<Role> GetRoleCustomList( SubscriptionEntities db , Expression<Func<Role, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<Role, dynamic> orderExpression = null);
 Role GetRoleWithDetails(long idRole, List<string> includes = null,bool shouldRemap = false);
 Role GetRoleWithDetails(long idRole, SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 Role GetRoleWitDetails(long idRole,bool shouldRemap = false);
 Role GetRoleWitDetails(long idRole, SubscriptionEntities db,bool shouldRemap = false);
 void SaveRole(Role role);
 void SaveRole(Role role, SubscriptionEntities db);
 void SaveOnlyRole(Role role);
 void SaveOnlyRole(Role role, SubscriptionEntities db);
 void DeleteRole(Role role);
 void DeleteRole(Role role, SubscriptionEntities db);		
  void DeletePermanentlyRole(Role role);
 void DeletePermanentlyRole(Role role, SubscriptionEntities db);	
	}
 	public partial interface IRole_PermissionDao
	{
  List<Role_Permission> GetAllRole_Permission(bool shouldRemap = false);
  List<Role_Permission> GetAllRole_Permission(SubscriptionEntities db,bool shouldRemap = false);
  BaseListReturnType<Role_Permission> GetAllRole_PermissionByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Role_Permission, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<Role_Permission, dynamic> orderExpression = null);
  BaseListReturnType<Role_Permission> GetAllRole_PermissionByPage(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<Role_Permission, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<Role_Permission, dynamic> orderExpression = null);
  
  BaseListReturnType<Role_Permission> GetAllRole_PermissionByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Role_Permission, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<Role_Permission, dynamic> orderExpression = null);
  BaseListReturnType<Role_Permission> GetAllRole_PermissionByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<Role_Permission, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<Role_Permission, dynamic> orderExpression = null);

 BaseListReturnType<Role_Permission> GetAllRole_PermissionWithPermissionDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Role_Permission, bool>> expression = null,bool shouldRemap = false, Func<Role_Permission, dynamic> orderExpression = null);
 BaseListReturnType<Role_Permission> GetAllRole_PermissionWithPermissionDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Role_Permission, bool>> expression = null,bool shouldRemap = false, Func<Role_Permission, dynamic> orderExpression = null);






BaseListReturnType<Role_Permission> GetAllRole_PermissionListByPermission(long idPermission);

BaseListReturnType<Role_Permission> GetAllRole_PermissionListByPermission(long idPermission, SubscriptionEntities db);

BaseListReturnType<Role_Permission> GetAllRole_PermissionListByPermissionByPage(long idPermission, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<Role_Permission> GetAllRole_PermissionListByPermissionByPage(long idPermission, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);



 BaseListReturnType<Role_Permission> GetAllRole_PermissionWithRoleDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Role_Permission, bool>> expression = null,bool shouldRemap = false, Func<Role_Permission, dynamic> orderExpression = null);
 BaseListReturnType<Role_Permission> GetAllRole_PermissionWithRoleDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Role_Permission, bool>> expression = null,bool shouldRemap = false, Func<Role_Permission, dynamic> orderExpression = null);






BaseListReturnType<Role_Permission> GetAllRole_PermissionListByRole(long idRole);

BaseListReturnType<Role_Permission> GetAllRole_PermissionListByRole(long idRole, SubscriptionEntities db);

BaseListReturnType<Role_Permission> GetAllRole_PermissionListByRoleByPage(long idRole, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<Role_Permission> GetAllRole_PermissionListByRoleByPage(long idRole, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);




List<Role_Permission> GetRole_PermissionListByIdList(List<long> role_PermissionIds);

List<Role_Permission> GetRole_PermissionListByIdList(List<long> role_PermissionIds, SubscriptionEntities db);

 BaseListReturnType<Role_Permission> GetAllRole_PermissionWithPermissionDetails(bool shouldRemap = false);
 BaseListReturnType<Role_Permission> GetAllRole_PermissionWithRoleDetails(bool shouldRemap = false);
 BaseListReturnType<Role_Permission> GetAllRole_PermissionWitDetails( List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<Role_Permission> GetAllRole_PermissionWitDetails( SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 Role_Permission GetRole_Permission(long idRole_Permission,bool shouldRemap = false);
 Role_Permission GetRole_Permission(long idRole_Permission, SubscriptionEntities db,bool shouldRemap = false);
 Role_Permission GetRole_PermissionWithPermissionDetails(long idRole_Permission,bool shouldRemap = false);
    


 Role_Permission GetRole_PermissionWithRoleDetails(long idRole_Permission,bool shouldRemap = false);
    


 Role_Permission GetRole_PermissionCustom( Expression<Func<Role_Permission, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 Role_Permission GetRole_PermissionCustom(SubscriptionEntities db, Expression<Func<Role_Permission, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<Role_Permission> GetRole_PermissionCustomList( Expression<Func<Role_Permission, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<Role_Permission, dynamic> orderExpression = null);
 BaseListReturnType<Role_Permission> GetRole_PermissionCustomList( SubscriptionEntities db , Expression<Func<Role_Permission, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<Role_Permission, dynamic> orderExpression = null);
 Role_Permission GetRole_PermissionWithDetails(long idRole_Permission, List<string> includes = null,bool shouldRemap = false);
 Role_Permission GetRole_PermissionWithDetails(long idRole_Permission, SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 Role_Permission GetRole_PermissionWitDetails(long idRole_Permission,bool shouldRemap = false);
 Role_Permission GetRole_PermissionWitDetails(long idRole_Permission, SubscriptionEntities db,bool shouldRemap = false);
 void SaveRole_Permission(Role_Permission role_Permission);
 void SaveRole_Permission(Role_Permission role_Permission, SubscriptionEntities db);
 void SaveOnlyRole_Permission(Role_Permission role_Permission);
 void SaveOnlyRole_Permission(Role_Permission role_Permission, SubscriptionEntities db);
 void DeleteRole_Permission(Role_Permission role_Permission);
 void DeleteRole_Permission(Role_Permission role_Permission, SubscriptionEntities db);		
  void DeletePermanentlyRole_Permission(Role_Permission role_Permission);
 void DeletePermanentlyRole_Permission(Role_Permission role_Permission, SubscriptionEntities db);	
	}
 	public partial interface IScheduleSettingDao
	{
  List<ScheduleSetting> GetAllScheduleSettings(bool shouldRemap = false);
  List<ScheduleSetting> GetAllScheduleSettings(SubscriptionEntities db,bool shouldRemap = false);
  BaseListReturnType<ScheduleSetting> GetAllScheduleSettingsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<ScheduleSetting, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<ScheduleSetting, dynamic> orderExpression = null);
  BaseListReturnType<ScheduleSetting> GetAllScheduleSettingsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<ScheduleSetting, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<ScheduleSetting, dynamic> orderExpression = null);
  
  BaseListReturnType<ScheduleSetting> GetAllScheduleSettingsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<ScheduleSetting, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<ScheduleSetting, dynamic> orderExpression = null);
  BaseListReturnType<ScheduleSetting> GetAllScheduleSettingsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<ScheduleSetting, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<ScheduleSetting, dynamic> orderExpression = null);

 BaseListReturnType<ScheduleSetting> GetAllScheduleSettingsWithFrequencyDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<ScheduleSetting, bool>> expression = null,bool shouldRemap = false, Func<ScheduleSetting, dynamic> orderExpression = null);
 BaseListReturnType<ScheduleSetting> GetAllScheduleSettingsWithFrequencyDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<ScheduleSetting, bool>> expression = null,bool shouldRemap = false, Func<ScheduleSetting, dynamic> orderExpression = null);






BaseListReturnType<ScheduleSetting> GetAllScheduleSettingListByFrequency(long idFrequency);

BaseListReturnType<ScheduleSetting> GetAllScheduleSettingListByFrequency(long idFrequency, SubscriptionEntities db);

BaseListReturnType<ScheduleSetting> GetAllScheduleSettingListByFrequencyByPage(long idFrequency, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<ScheduleSetting> GetAllScheduleSettingListByFrequencyByPage(long idFrequency, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);



 BaseListReturnType<ScheduleSetting> GetAllScheduleSettingsWithTransactionDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<ScheduleSetting, bool>> expression = null,bool shouldRemap = false, Func<ScheduleSetting, dynamic> orderExpression = null);
 BaseListReturnType<ScheduleSetting> GetAllScheduleSettingsWithTransactionDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<ScheduleSetting, bool>> expression = null,bool shouldRemap = false, Func<ScheduleSetting, dynamic> orderExpression = null);






BaseListReturnType<ScheduleSetting> GetAllScheduleSettingListByTransaction(long idTransaction);

BaseListReturnType<ScheduleSetting> GetAllScheduleSettingListByTransaction(long idTransaction, SubscriptionEntities db);

BaseListReturnType<ScheduleSetting> GetAllScheduleSettingListByTransactionByPage(long idTransaction, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<ScheduleSetting> GetAllScheduleSettingListByTransactionByPage(long idTransaction, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);




List<ScheduleSetting> GetScheduleSettingListByIdList(List<long> scheduleSettingIds);

List<ScheduleSetting> GetScheduleSettingListByIdList(List<long> scheduleSettingIds, SubscriptionEntities db);

 BaseListReturnType<ScheduleSetting> GetAllScheduleSettingsWithFrequencyDetails(bool shouldRemap = false);
 BaseListReturnType<ScheduleSetting> GetAllScheduleSettingsWithTransactionDetails(bool shouldRemap = false);
 BaseListReturnType<ScheduleSetting> GetAllScheduleSettingWitDetails( List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<ScheduleSetting> GetAllScheduleSettingWitDetails( SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 ScheduleSetting GetScheduleSetting(long idScheduleSetting,bool shouldRemap = false);
 ScheduleSetting GetScheduleSetting(long idScheduleSetting, SubscriptionEntities db,bool shouldRemap = false);
 ScheduleSetting GetScheduleSettingWithFrequencyDetails(long idScheduleSetting,bool shouldRemap = false);
    


 ScheduleSetting GetScheduleSettingWithTransactionDetails(long idScheduleSetting,bool shouldRemap = false);
    


 ScheduleSetting GetScheduleSettingCustom( Expression<Func<ScheduleSetting, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 ScheduleSetting GetScheduleSettingCustom(SubscriptionEntities db, Expression<Func<ScheduleSetting, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<ScheduleSetting> GetScheduleSettingCustomList( Expression<Func<ScheduleSetting, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<ScheduleSetting, dynamic> orderExpression = null);
 BaseListReturnType<ScheduleSetting> GetScheduleSettingCustomList( SubscriptionEntities db , Expression<Func<ScheduleSetting, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<ScheduleSetting, dynamic> orderExpression = null);
 ScheduleSetting GetScheduleSettingWithDetails(long idScheduleSetting, List<string> includes = null,bool shouldRemap = false);
 ScheduleSetting GetScheduleSettingWithDetails(long idScheduleSetting, SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 ScheduleSetting GetScheduleSettingWitDetails(long idScheduleSetting,bool shouldRemap = false);
 ScheduleSetting GetScheduleSettingWitDetails(long idScheduleSetting, SubscriptionEntities db,bool shouldRemap = false);
 void SaveScheduleSetting(ScheduleSetting scheduleSetting);
 void SaveScheduleSetting(ScheduleSetting scheduleSetting, SubscriptionEntities db);
 void SaveOnlyScheduleSetting(ScheduleSetting scheduleSetting);
 void SaveOnlyScheduleSetting(ScheduleSetting scheduleSetting, SubscriptionEntities db);
 void DeleteScheduleSetting(ScheduleSetting scheduleSetting);
 void DeleteScheduleSetting(ScheduleSetting scheduleSetting, SubscriptionEntities db);		
  void DeletePermanentlyScheduleSetting(ScheduleSetting scheduleSetting);
 void DeletePermanentlyScheduleSetting(ScheduleSetting scheduleSetting, SubscriptionEntities db);	
	}
 	public partial interface IStockLocationDao
	{
  List<StockLocation> GetAllStockLocations(bool shouldRemap = false);
  List<StockLocation> GetAllStockLocations(SubscriptionEntities db,bool shouldRemap = false);
  BaseListReturnType<StockLocation> GetAllStockLocationsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<StockLocation, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<StockLocation, dynamic> orderExpression = null);
  BaseListReturnType<StockLocation> GetAllStockLocationsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<StockLocation, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<StockLocation, dynamic> orderExpression = null);
  
  BaseListReturnType<StockLocation> GetAllStockLocationsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<StockLocation, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<StockLocation, dynamic> orderExpression = null);
  BaseListReturnType<StockLocation> GetAllStockLocationsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<StockLocation, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<StockLocation, dynamic> orderExpression = null);


List<StockLocation> GetStockLocationListByIdList(List<long> stockLocationIds);

List<StockLocation> GetStockLocationListByIdList(List<long> stockLocationIds, SubscriptionEntities db);

 BaseListReturnType<StockLocation> GetAllStockLocationWitDetails( List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<StockLocation> GetAllStockLocationWitDetails( SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 StockLocation GetStockLocation(long idStockLocation,bool shouldRemap = false);
 StockLocation GetStockLocation(long idStockLocation, SubscriptionEntities db,bool shouldRemap = false);
 StockLocation GetStockLocationCustom( Expression<Func<StockLocation, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 StockLocation GetStockLocationCustom(SubscriptionEntities db, Expression<Func<StockLocation, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<StockLocation> GetStockLocationCustomList( Expression<Func<StockLocation, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<StockLocation, dynamic> orderExpression = null);
 BaseListReturnType<StockLocation> GetStockLocationCustomList( SubscriptionEntities db , Expression<Func<StockLocation, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<StockLocation, dynamic> orderExpression = null);
 StockLocation GetStockLocationWithDetails(long idStockLocation, List<string> includes = null,bool shouldRemap = false);
 StockLocation GetStockLocationWithDetails(long idStockLocation, SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 StockLocation GetStockLocationWitDetails(long idStockLocation,bool shouldRemap = false);
 StockLocation GetStockLocationWitDetails(long idStockLocation, SubscriptionEntities db,bool shouldRemap = false);
 void SaveStockLocation(StockLocation stockLocation);
 void SaveStockLocation(StockLocation stockLocation, SubscriptionEntities db);
 void SaveOnlyStockLocation(StockLocation stockLocation);
 void SaveOnlyStockLocation(StockLocation stockLocation, SubscriptionEntities db);
 void DeleteStockLocation(StockLocation stockLocation);
 void DeleteStockLocation(StockLocation stockLocation, SubscriptionEntities db);		
  void DeletePermanentlyStockLocation(StockLocation stockLocation);
 void DeletePermanentlyStockLocation(StockLocation stockLocation, SubscriptionEntities db);	
	}
 	public partial interface ITemporaryPaymentDao
	{
  List<TemporaryPayment> GetAllTemporaryPayments(bool shouldRemap = false);
  List<TemporaryPayment> GetAllTemporaryPayments(SubscriptionEntities db,bool shouldRemap = false);
  BaseListReturnType<TemporaryPayment> GetAllTemporaryPaymentsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<TemporaryPayment, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<TemporaryPayment, dynamic> orderExpression = null);
  BaseListReturnType<TemporaryPayment> GetAllTemporaryPaymentsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<TemporaryPayment, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<TemporaryPayment, dynamic> orderExpression = null);
  
  BaseListReturnType<TemporaryPayment> GetAllTemporaryPaymentsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<TemporaryPayment, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<TemporaryPayment, dynamic> orderExpression = null);
  BaseListReturnType<TemporaryPayment> GetAllTemporaryPaymentsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<TemporaryPayment, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<TemporaryPayment, dynamic> orderExpression = null);

 BaseListReturnType<TemporaryPayment> GetAllTemporaryPaymentsWithTemporaryPaymentDetailsDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<TemporaryPayment, bool>> expression = null,bool shouldRemap = false, Func<TemporaryPayment, dynamic> orderExpression = null);
 BaseListReturnType<TemporaryPayment> GetAllTemporaryPaymentsWithTemporaryPaymentDetailsDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<TemporaryPayment, bool>> expression = null,bool shouldRemap = false, Func<TemporaryPayment, dynamic> orderExpression = null);

 BaseListReturnType<TemporaryPayment> GetAllTemporaryPaymentsWithTemporaryTransactionsDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<TemporaryPayment, bool>> expression = null,bool shouldRemap = false, Func<TemporaryPayment, dynamic> orderExpression = null);
 BaseListReturnType<TemporaryPayment> GetAllTemporaryPaymentsWithTemporaryTransactionsDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<TemporaryPayment, bool>> expression = null,bool shouldRemap = false, Func<TemporaryPayment, dynamic> orderExpression = null);


List<TemporaryPayment> GetTemporaryPaymentListByIdList(List<long> temporaryPaymentIds);

List<TemporaryPayment> GetTemporaryPaymentListByIdList(List<long> temporaryPaymentIds, SubscriptionEntities db);

 BaseListReturnType<TemporaryPayment> GetAllTemporaryPaymentsWithTemporaryPaymentDetailsDetails(bool shouldRemap = false);
 BaseListReturnType<TemporaryPayment> GetAllTemporaryPaymentsWithTemporaryTransactionsDetails(bool shouldRemap = false);
 BaseListReturnType<TemporaryPayment> GetAllTemporaryPaymentWitDetails( List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<TemporaryPayment> GetAllTemporaryPaymentWitDetails( SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 TemporaryPayment GetTemporaryPayment(long idTemporaryPayment,bool shouldRemap = false);
 TemporaryPayment GetTemporaryPayment(long idTemporaryPayment, SubscriptionEntities db,bool shouldRemap = false);
 TemporaryPayment GetTemporaryPaymentWithTemporaryPaymentDetailsDetails(long idTemporaryPayment,bool shouldRemap = false);
           List<TemporaryPaymentDetail> UpdateTemporaryPaymentDetailsForTemporaryPaymentWithoutSavingNewItem(List<TemporaryPaymentDetail> newTemporaryPaymentDetails,long idTemporaryPayment);
    List<TemporaryPaymentDetail> UpdateTemporaryPaymentDetailsForTemporaryPaymentWithoutSavingNewItem(List<TemporaryPaymentDetail> newTemporaryPaymentDetails,long idTemporaryPayment,SubscriptionEntities db);
          

    List<TemporaryPaymentDetail> UpdateTemporaryPaymentDetailsForTemporaryPayment(List<TemporaryPaymentDetail> newTemporaryPaymentDetails,long idTemporaryPayment);
    List<TemporaryPaymentDetail> UpdateTemporaryPaymentDetailsForTemporaryPayment(List<TemporaryPaymentDetail> newTemporaryPaymentDetails,long idTemporaryPayment,SubscriptionEntities db);
                           



 TemporaryPayment GetTemporaryPaymentWithTemporaryTransactionsDetails(long idTemporaryPayment,bool shouldRemap = false);
           List<TemporaryTransaction> UpdateTemporaryTransactionsForTemporaryPaymentWithoutSavingNewItem(List<TemporaryTransaction> newTemporaryTransactions,long idTemporaryPayment);
    List<TemporaryTransaction> UpdateTemporaryTransactionsForTemporaryPaymentWithoutSavingNewItem(List<TemporaryTransaction> newTemporaryTransactions,long idTemporaryPayment,SubscriptionEntities db);
          

    List<TemporaryTransaction> UpdateTemporaryTransactionsForTemporaryPayment(List<TemporaryTransaction> newTemporaryTransactions,long idTemporaryPayment);
    List<TemporaryTransaction> UpdateTemporaryTransactionsForTemporaryPayment(List<TemporaryTransaction> newTemporaryTransactions,long idTemporaryPayment,SubscriptionEntities db);
                           



 TemporaryPayment GetTemporaryPaymentCustom( Expression<Func<TemporaryPayment, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 TemporaryPayment GetTemporaryPaymentCustom(SubscriptionEntities db, Expression<Func<TemporaryPayment, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<TemporaryPayment> GetTemporaryPaymentCustomList( Expression<Func<TemporaryPayment, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<TemporaryPayment, dynamic> orderExpression = null);
 BaseListReturnType<TemporaryPayment> GetTemporaryPaymentCustomList( SubscriptionEntities db , Expression<Func<TemporaryPayment, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<TemporaryPayment, dynamic> orderExpression = null);
 TemporaryPayment GetTemporaryPaymentWithDetails(long idTemporaryPayment, List<string> includes = null,bool shouldRemap = false);
 TemporaryPayment GetTemporaryPaymentWithDetails(long idTemporaryPayment, SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 TemporaryPayment GetTemporaryPaymentWitDetails(long idTemporaryPayment,bool shouldRemap = false);
 TemporaryPayment GetTemporaryPaymentWitDetails(long idTemporaryPayment, SubscriptionEntities db,bool shouldRemap = false);
 void SaveTemporaryPayment(TemporaryPayment temporaryPayment);
 void SaveTemporaryPayment(TemporaryPayment temporaryPayment, SubscriptionEntities db);
 void SaveOnlyTemporaryPayment(TemporaryPayment temporaryPayment);
 void SaveOnlyTemporaryPayment(TemporaryPayment temporaryPayment, SubscriptionEntities db);
 void DeleteTemporaryPayment(TemporaryPayment temporaryPayment);
 void DeleteTemporaryPayment(TemporaryPayment temporaryPayment, SubscriptionEntities db);		
  void DeletePermanentlyTemporaryPayment(TemporaryPayment temporaryPayment);
 void DeletePermanentlyTemporaryPayment(TemporaryPayment temporaryPayment, SubscriptionEntities db);	
	}
 	public partial interface ITemporaryPaymentDetailDao
	{
  List<TemporaryPaymentDetail> GetAllTemporaryPaymentDetails(bool shouldRemap = false);
  List<TemporaryPaymentDetail> GetAllTemporaryPaymentDetails(SubscriptionEntities db,bool shouldRemap = false);
  BaseListReturnType<TemporaryPaymentDetail> GetAllTemporaryPaymentDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<TemporaryPaymentDetail, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<TemporaryPaymentDetail, dynamic> orderExpression = null);
  BaseListReturnType<TemporaryPaymentDetail> GetAllTemporaryPaymentDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<TemporaryPaymentDetail, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<TemporaryPaymentDetail, dynamic> orderExpression = null);
  
  BaseListReturnType<TemporaryPaymentDetail> GetAllTemporaryPaymentDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<TemporaryPaymentDetail, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<TemporaryPaymentDetail, dynamic> orderExpression = null);
  BaseListReturnType<TemporaryPaymentDetail> GetAllTemporaryPaymentDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<TemporaryPaymentDetail, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<TemporaryPaymentDetail, dynamic> orderExpression = null);

 BaseListReturnType<TemporaryPaymentDetail> GetAllTemporaryPaymentDetailsWithTemporaryPaymentDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<TemporaryPaymentDetail, bool>> expression = null,bool shouldRemap = false, Func<TemporaryPaymentDetail, dynamic> orderExpression = null);
 BaseListReturnType<TemporaryPaymentDetail> GetAllTemporaryPaymentDetailsWithTemporaryPaymentDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<TemporaryPaymentDetail, bool>> expression = null,bool shouldRemap = false, Func<TemporaryPaymentDetail, dynamic> orderExpression = null);






BaseListReturnType<TemporaryPaymentDetail> GetAllTemporaryPaymentDetailListByTemporaryPayment(long idTemporaryPayment);

BaseListReturnType<TemporaryPaymentDetail> GetAllTemporaryPaymentDetailListByTemporaryPayment(long idTemporaryPayment, SubscriptionEntities db);

BaseListReturnType<TemporaryPaymentDetail> GetAllTemporaryPaymentDetailListByTemporaryPaymentByPage(long idTemporaryPayment, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<TemporaryPaymentDetail> GetAllTemporaryPaymentDetailListByTemporaryPaymentByPage(long idTemporaryPayment, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);




List<TemporaryPaymentDetail> GetTemporaryPaymentDetailListByIdList(List<long> temporaryPaymentDetailIds);

List<TemporaryPaymentDetail> GetTemporaryPaymentDetailListByIdList(List<long> temporaryPaymentDetailIds, SubscriptionEntities db);

 BaseListReturnType<TemporaryPaymentDetail> GetAllTemporaryPaymentDetailsWithTemporaryPaymentDetails(bool shouldRemap = false);
 BaseListReturnType<TemporaryPaymentDetail> GetAllTemporaryPaymentDetailWitDetails( List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<TemporaryPaymentDetail> GetAllTemporaryPaymentDetailWitDetails( SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 TemporaryPaymentDetail GetTemporaryPaymentDetail(long idTemporaryPaymentDetail,bool shouldRemap = false);
 TemporaryPaymentDetail GetTemporaryPaymentDetail(long idTemporaryPaymentDetail, SubscriptionEntities db,bool shouldRemap = false);
 TemporaryPaymentDetail GetTemporaryPaymentDetailWithTemporaryPaymentDetails(long idTemporaryPaymentDetail,bool shouldRemap = false);
    


 TemporaryPaymentDetail GetTemporaryPaymentDetailCustom( Expression<Func<TemporaryPaymentDetail, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 TemporaryPaymentDetail GetTemporaryPaymentDetailCustom(SubscriptionEntities db, Expression<Func<TemporaryPaymentDetail, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<TemporaryPaymentDetail> GetTemporaryPaymentDetailCustomList( Expression<Func<TemporaryPaymentDetail, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<TemporaryPaymentDetail, dynamic> orderExpression = null);
 BaseListReturnType<TemporaryPaymentDetail> GetTemporaryPaymentDetailCustomList( SubscriptionEntities db , Expression<Func<TemporaryPaymentDetail, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<TemporaryPaymentDetail, dynamic> orderExpression = null);
 TemporaryPaymentDetail GetTemporaryPaymentDetailWithDetails(long idTemporaryPaymentDetail, List<string> includes = null,bool shouldRemap = false);
 TemporaryPaymentDetail GetTemporaryPaymentDetailWithDetails(long idTemporaryPaymentDetail, SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 TemporaryPaymentDetail GetTemporaryPaymentDetailWitDetails(long idTemporaryPaymentDetail,bool shouldRemap = false);
 TemporaryPaymentDetail GetTemporaryPaymentDetailWitDetails(long idTemporaryPaymentDetail, SubscriptionEntities db,bool shouldRemap = false);
 void SaveTemporaryPaymentDetail(TemporaryPaymentDetail temporaryPaymentDetail);
 void SaveTemporaryPaymentDetail(TemporaryPaymentDetail temporaryPaymentDetail, SubscriptionEntities db);
 void SaveOnlyTemporaryPaymentDetail(TemporaryPaymentDetail temporaryPaymentDetail);
 void SaveOnlyTemporaryPaymentDetail(TemporaryPaymentDetail temporaryPaymentDetail, SubscriptionEntities db);
 void DeleteTemporaryPaymentDetail(TemporaryPaymentDetail temporaryPaymentDetail);
 void DeleteTemporaryPaymentDetail(TemporaryPaymentDetail temporaryPaymentDetail, SubscriptionEntities db);		
  void DeletePermanentlyTemporaryPaymentDetail(TemporaryPaymentDetail temporaryPaymentDetail);
 void DeletePermanentlyTemporaryPaymentDetail(TemporaryPaymentDetail temporaryPaymentDetail, SubscriptionEntities db);	
	}
 	public partial interface ITemporaryTransactionDao
	{
  List<TemporaryTransaction> GetAllTemporaryTransactions(bool shouldRemap = false);
  List<TemporaryTransaction> GetAllTemporaryTransactions(SubscriptionEntities db,bool shouldRemap = false);
  BaseListReturnType<TemporaryTransaction> GetAllTemporaryTransactionsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<TemporaryTransaction, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<TemporaryTransaction, dynamic> orderExpression = null);
  BaseListReturnType<TemporaryTransaction> GetAllTemporaryTransactionsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<TemporaryTransaction, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<TemporaryTransaction, dynamic> orderExpression = null);
  
  BaseListReturnType<TemporaryTransaction> GetAllTemporaryTransactionsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<TemporaryTransaction, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<TemporaryTransaction, dynamic> orderExpression = null);
  BaseListReturnType<TemporaryTransaction> GetAllTemporaryTransactionsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<TemporaryTransaction, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<TemporaryTransaction, dynamic> orderExpression = null);

 BaseListReturnType<TemporaryTransaction> GetAllTemporaryTransactionsWithBankStatementHitListDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<TemporaryTransaction, bool>> expression = null,bool shouldRemap = false, Func<TemporaryTransaction, dynamic> orderExpression = null);
 BaseListReturnType<TemporaryTransaction> GetAllTemporaryTransactionsWithBankStatementHitListDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<TemporaryTransaction, bool>> expression = null,bool shouldRemap = false, Func<TemporaryTransaction, dynamic> orderExpression = null);






BaseListReturnType<TemporaryTransaction> GetAllTemporaryTransactionListByBankStatementHitList(long idBankStatementHitList);

BaseListReturnType<TemporaryTransaction> GetAllTemporaryTransactionListByBankStatementHitList(long idBankStatementHitList, SubscriptionEntities db);

BaseListReturnType<TemporaryTransaction> GetAllTemporaryTransactionListByBankStatementHitListByPage(long idBankStatementHitList, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<TemporaryTransaction> GetAllTemporaryTransactionListByBankStatementHitListByPage(long idBankStatementHitList, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);



 BaseListReturnType<TemporaryTransaction> GetAllTemporaryTransactionsWithBankStatementStagingDetailDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<TemporaryTransaction, bool>> expression = null,bool shouldRemap = false, Func<TemporaryTransaction, dynamic> orderExpression = null);
 BaseListReturnType<TemporaryTransaction> GetAllTemporaryTransactionsWithBankStatementStagingDetailDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<TemporaryTransaction, bool>> expression = null,bool shouldRemap = false, Func<TemporaryTransaction, dynamic> orderExpression = null);






BaseListReturnType<TemporaryTransaction> GetAllTemporaryTransactionListByBankStatementStagingDetail(long idBankStatementStagingDetail);

BaseListReturnType<TemporaryTransaction> GetAllTemporaryTransactionListByBankStatementStagingDetail(long idBankStatementStagingDetail, SubscriptionEntities db);

BaseListReturnType<TemporaryTransaction> GetAllTemporaryTransactionListByBankStatementStagingDetailByPage(long idBankStatementStagingDetail, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<TemporaryTransaction> GetAllTemporaryTransactionListByBankStatementStagingDetailByPage(long idBankStatementStagingDetail, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);



 BaseListReturnType<TemporaryTransaction> GetAllTemporaryTransactionsWithBankStatementStagingHitDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<TemporaryTransaction, bool>> expression = null,bool shouldRemap = false, Func<TemporaryTransaction, dynamic> orderExpression = null);
 BaseListReturnType<TemporaryTransaction> GetAllTemporaryTransactionsWithBankStatementStagingHitDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<TemporaryTransaction, bool>> expression = null,bool shouldRemap = false, Func<TemporaryTransaction, dynamic> orderExpression = null);






BaseListReturnType<TemporaryTransaction> GetAllTemporaryTransactionListByBankStatementStagingHit(long idBankStatementStagingHit);

BaseListReturnType<TemporaryTransaction> GetAllTemporaryTransactionListByBankStatementStagingHit(long idBankStatementStagingHit, SubscriptionEntities db);

BaseListReturnType<TemporaryTransaction> GetAllTemporaryTransactionListByBankStatementStagingHitByPage(long idBankStatementStagingHit, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<TemporaryTransaction> GetAllTemporaryTransactionListByBankStatementStagingHitByPage(long idBankStatementStagingHit, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);



 BaseListReturnType<TemporaryTransaction> GetAllTemporaryTransactionsWithTemporaryPaymentDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<TemporaryTransaction, bool>> expression = null,bool shouldRemap = false, Func<TemporaryTransaction, dynamic> orderExpression = null);
 BaseListReturnType<TemporaryTransaction> GetAllTemporaryTransactionsWithTemporaryPaymentDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<TemporaryTransaction, bool>> expression = null,bool shouldRemap = false, Func<TemporaryTransaction, dynamic> orderExpression = null);






BaseListReturnType<TemporaryTransaction> GetAllTemporaryTransactionListByTemporaryPayment(long idTemporaryPayment);

BaseListReturnType<TemporaryTransaction> GetAllTemporaryTransactionListByTemporaryPayment(long idTemporaryPayment, SubscriptionEntities db);

BaseListReturnType<TemporaryTransaction> GetAllTemporaryTransactionListByTemporaryPaymentByPage(long idTemporaryPayment, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<TemporaryTransaction> GetAllTemporaryTransactionListByTemporaryPaymentByPage(long idTemporaryPayment, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);



 BaseListReturnType<TemporaryTransaction> GetAllTemporaryTransactionsWithTemporaryTransactionDetailsDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<TemporaryTransaction, bool>> expression = null,bool shouldRemap = false, Func<TemporaryTransaction, dynamic> orderExpression = null);
 BaseListReturnType<TemporaryTransaction> GetAllTemporaryTransactionsWithTemporaryTransactionDetailsDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<TemporaryTransaction, bool>> expression = null,bool shouldRemap = false, Func<TemporaryTransaction, dynamic> orderExpression = null);


List<TemporaryTransaction> GetTemporaryTransactionListByIdList(List<long> temporaryTransactionIds);

List<TemporaryTransaction> GetTemporaryTransactionListByIdList(List<long> temporaryTransactionIds, SubscriptionEntities db);

 BaseListReturnType<TemporaryTransaction> GetAllTemporaryTransactionsWithBankStatementHitListDetails(bool shouldRemap = false);
 BaseListReturnType<TemporaryTransaction> GetAllTemporaryTransactionsWithBankStatementStagingDetailDetails(bool shouldRemap = false);
 BaseListReturnType<TemporaryTransaction> GetAllTemporaryTransactionsWithBankStatementStagingHitDetails(bool shouldRemap = false);
 BaseListReturnType<TemporaryTransaction> GetAllTemporaryTransactionsWithTemporaryPaymentDetails(bool shouldRemap = false);
 BaseListReturnType<TemporaryTransaction> GetAllTemporaryTransactionsWithTemporaryTransactionDetailsDetails(bool shouldRemap = false);
 BaseListReturnType<TemporaryTransaction> GetAllTemporaryTransactionWitDetails( List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<TemporaryTransaction> GetAllTemporaryTransactionWitDetails( SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 TemporaryTransaction GetTemporaryTransaction(long idTemporaryTransaction,bool shouldRemap = false);
 TemporaryTransaction GetTemporaryTransaction(long idTemporaryTransaction, SubscriptionEntities db,bool shouldRemap = false);
 TemporaryTransaction GetTemporaryTransactionWithBankStatementHitListDetails(long idTemporaryTransaction,bool shouldRemap = false);
    


 TemporaryTransaction GetTemporaryTransactionWithBankStatementStagingDetailDetails(long idTemporaryTransaction,bool shouldRemap = false);
    


 TemporaryTransaction GetTemporaryTransactionWithBankStatementStagingHitDetails(long idTemporaryTransaction,bool shouldRemap = false);
    


 TemporaryTransaction GetTemporaryTransactionWithTemporaryPaymentDetails(long idTemporaryTransaction,bool shouldRemap = false);
    


 TemporaryTransaction GetTemporaryTransactionWithTemporaryTransactionDetailsDetails(long idTemporaryTransaction,bool shouldRemap = false);
           List<TemporaryTransactionDetail> UpdateTemporaryTransactionDetailsForTemporaryTransactionWithoutSavingNewItem(List<TemporaryTransactionDetail> newTemporaryTransactionDetails,long idTemporaryTransaction);
    List<TemporaryTransactionDetail> UpdateTemporaryTransactionDetailsForTemporaryTransactionWithoutSavingNewItem(List<TemporaryTransactionDetail> newTemporaryTransactionDetails,long idTemporaryTransaction,SubscriptionEntities db);
          

    List<TemporaryTransactionDetail> UpdateTemporaryTransactionDetailsForTemporaryTransaction(List<TemporaryTransactionDetail> newTemporaryTransactionDetails,long idTemporaryTransaction);
    List<TemporaryTransactionDetail> UpdateTemporaryTransactionDetailsForTemporaryTransaction(List<TemporaryTransactionDetail> newTemporaryTransactionDetails,long idTemporaryTransaction,SubscriptionEntities db);
                           



 TemporaryTransaction GetTemporaryTransactionCustom( Expression<Func<TemporaryTransaction, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 TemporaryTransaction GetTemporaryTransactionCustom(SubscriptionEntities db, Expression<Func<TemporaryTransaction, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<TemporaryTransaction> GetTemporaryTransactionCustomList( Expression<Func<TemporaryTransaction, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<TemporaryTransaction, dynamic> orderExpression = null);
 BaseListReturnType<TemporaryTransaction> GetTemporaryTransactionCustomList( SubscriptionEntities db , Expression<Func<TemporaryTransaction, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<TemporaryTransaction, dynamic> orderExpression = null);
 TemporaryTransaction GetTemporaryTransactionWithDetails(long idTemporaryTransaction, List<string> includes = null,bool shouldRemap = false);
 TemporaryTransaction GetTemporaryTransactionWithDetails(long idTemporaryTransaction, SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 TemporaryTransaction GetTemporaryTransactionWitDetails(long idTemporaryTransaction,bool shouldRemap = false);
 TemporaryTransaction GetTemporaryTransactionWitDetails(long idTemporaryTransaction, SubscriptionEntities db,bool shouldRemap = false);
 void SaveTemporaryTransaction(TemporaryTransaction temporaryTransaction);
 void SaveTemporaryTransaction(TemporaryTransaction temporaryTransaction, SubscriptionEntities db);
 void SaveOnlyTemporaryTransaction(TemporaryTransaction temporaryTransaction);
 void SaveOnlyTemporaryTransaction(TemporaryTransaction temporaryTransaction, SubscriptionEntities db);
 void DeleteTemporaryTransaction(TemporaryTransaction temporaryTransaction);
 void DeleteTemporaryTransaction(TemporaryTransaction temporaryTransaction, SubscriptionEntities db);		
  void DeletePermanentlyTemporaryTransaction(TemporaryTransaction temporaryTransaction);
 void DeletePermanentlyTemporaryTransaction(TemporaryTransaction temporaryTransaction, SubscriptionEntities db);	
	}
 	public partial interface ITemporaryTransactionDetailDao
	{
  List<TemporaryTransactionDetail> GetAllTemporaryTransactionDetails(bool shouldRemap = false);
  List<TemporaryTransactionDetail> GetAllTemporaryTransactionDetails(SubscriptionEntities db,bool shouldRemap = false);
  BaseListReturnType<TemporaryTransactionDetail> GetAllTemporaryTransactionDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<TemporaryTransactionDetail, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<TemporaryTransactionDetail, dynamic> orderExpression = null);
  BaseListReturnType<TemporaryTransactionDetail> GetAllTemporaryTransactionDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<TemporaryTransactionDetail, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<TemporaryTransactionDetail, dynamic> orderExpression = null);
  
  BaseListReturnType<TemporaryTransactionDetail> GetAllTemporaryTransactionDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<TemporaryTransactionDetail, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<TemporaryTransactionDetail, dynamic> orderExpression = null);
  BaseListReturnType<TemporaryTransactionDetail> GetAllTemporaryTransactionDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<TemporaryTransactionDetail, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<TemporaryTransactionDetail, dynamic> orderExpression = null);

 BaseListReturnType<TemporaryTransactionDetail> GetAllTemporaryTransactionDetailsWithTemporaryTransactionDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<TemporaryTransactionDetail, bool>> expression = null,bool shouldRemap = false, Func<TemporaryTransactionDetail, dynamic> orderExpression = null);
 BaseListReturnType<TemporaryTransactionDetail> GetAllTemporaryTransactionDetailsWithTemporaryTransactionDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<TemporaryTransactionDetail, bool>> expression = null,bool shouldRemap = false, Func<TemporaryTransactionDetail, dynamic> orderExpression = null);






BaseListReturnType<TemporaryTransactionDetail> GetAllTemporaryTransactionDetailListByTemporaryTransaction(long idTemporaryTransaction);

BaseListReturnType<TemporaryTransactionDetail> GetAllTemporaryTransactionDetailListByTemporaryTransaction(long idTemporaryTransaction, SubscriptionEntities db);

BaseListReturnType<TemporaryTransactionDetail> GetAllTemporaryTransactionDetailListByTemporaryTransactionByPage(long idTemporaryTransaction, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<TemporaryTransactionDetail> GetAllTemporaryTransactionDetailListByTemporaryTransactionByPage(long idTemporaryTransaction, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);




List<TemporaryTransactionDetail> GetTemporaryTransactionDetailListByIdList(List<long> temporaryTransactionDetailIds);

List<TemporaryTransactionDetail> GetTemporaryTransactionDetailListByIdList(List<long> temporaryTransactionDetailIds, SubscriptionEntities db);

 BaseListReturnType<TemporaryTransactionDetail> GetAllTemporaryTransactionDetailsWithTemporaryTransactionDetails(bool shouldRemap = false);
 BaseListReturnType<TemporaryTransactionDetail> GetAllTemporaryTransactionDetailWitDetails( List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<TemporaryTransactionDetail> GetAllTemporaryTransactionDetailWitDetails( SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 TemporaryTransactionDetail GetTemporaryTransactionDetail(long idTemporaryTransactionDetail,bool shouldRemap = false);
 TemporaryTransactionDetail GetTemporaryTransactionDetail(long idTemporaryTransactionDetail, SubscriptionEntities db,bool shouldRemap = false);
 TemporaryTransactionDetail GetTemporaryTransactionDetailWithTemporaryTransactionDetails(long idTemporaryTransactionDetail,bool shouldRemap = false);
    


 TemporaryTransactionDetail GetTemporaryTransactionDetailCustom( Expression<Func<TemporaryTransactionDetail, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 TemporaryTransactionDetail GetTemporaryTransactionDetailCustom(SubscriptionEntities db, Expression<Func<TemporaryTransactionDetail, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<TemporaryTransactionDetail> GetTemporaryTransactionDetailCustomList( Expression<Func<TemporaryTransactionDetail, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<TemporaryTransactionDetail, dynamic> orderExpression = null);
 BaseListReturnType<TemporaryTransactionDetail> GetTemporaryTransactionDetailCustomList( SubscriptionEntities db , Expression<Func<TemporaryTransactionDetail, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<TemporaryTransactionDetail, dynamic> orderExpression = null);
 TemporaryTransactionDetail GetTemporaryTransactionDetailWithDetails(long idTemporaryTransactionDetail, List<string> includes = null,bool shouldRemap = false);
 TemporaryTransactionDetail GetTemporaryTransactionDetailWithDetails(long idTemporaryTransactionDetail, SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 TemporaryTransactionDetail GetTemporaryTransactionDetailWitDetails(long idTemporaryTransactionDetail,bool shouldRemap = false);
 TemporaryTransactionDetail GetTemporaryTransactionDetailWitDetails(long idTemporaryTransactionDetail, SubscriptionEntities db,bool shouldRemap = false);
 void SaveTemporaryTransactionDetail(TemporaryTransactionDetail temporaryTransactionDetail);
 void SaveTemporaryTransactionDetail(TemporaryTransactionDetail temporaryTransactionDetail, SubscriptionEntities db);
 void SaveOnlyTemporaryTransactionDetail(TemporaryTransactionDetail temporaryTransactionDetail);
 void SaveOnlyTemporaryTransactionDetail(TemporaryTransactionDetail temporaryTransactionDetail, SubscriptionEntities db);
 void DeleteTemporaryTransactionDetail(TemporaryTransactionDetail temporaryTransactionDetail);
 void DeleteTemporaryTransactionDetail(TemporaryTransactionDetail temporaryTransactionDetail, SubscriptionEntities db);		
  void DeletePermanentlyTemporaryTransactionDetail(TemporaryTransactionDetail temporaryTransactionDetail);
 void DeletePermanentlyTemporaryTransactionDetail(TemporaryTransactionDetail temporaryTransactionDetail, SubscriptionEntities db);	
	}
 	public partial interface ITemporaryTransactionOrderDao
	{
  List<TemporaryTransactionOrder> GetAllTemporaryTransactionOrders(bool shouldRemap = false);
  List<TemporaryTransactionOrder> GetAllTemporaryTransactionOrders(SubscriptionEntities db,bool shouldRemap = false);
  BaseListReturnType<TemporaryTransactionOrder> GetAllTemporaryTransactionOrdersByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<TemporaryTransactionOrder, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<TemporaryTransactionOrder, dynamic> orderExpression = null);
  BaseListReturnType<TemporaryTransactionOrder> GetAllTemporaryTransactionOrdersByPage(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<TemporaryTransactionOrder, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<TemporaryTransactionOrder, dynamic> orderExpression = null);
  
  BaseListReturnType<TemporaryTransactionOrder> GetAllTemporaryTransactionOrdersByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<TemporaryTransactionOrder, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<TemporaryTransactionOrder, dynamic> orderExpression = null);
  BaseListReturnType<TemporaryTransactionOrder> GetAllTemporaryTransactionOrdersByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<TemporaryTransactionOrder, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<TemporaryTransactionOrder, dynamic> orderExpression = null);

 BaseListReturnType<TemporaryTransactionOrder> GetAllTemporaryTransactionOrdersWithTemporaryTransactionOrderStateDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<TemporaryTransactionOrder, bool>> expression = null,bool shouldRemap = false, Func<TemporaryTransactionOrder, dynamic> orderExpression = null);
 BaseListReturnType<TemporaryTransactionOrder> GetAllTemporaryTransactionOrdersWithTemporaryTransactionOrderStateDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<TemporaryTransactionOrder, bool>> expression = null,bool shouldRemap = false, Func<TemporaryTransactionOrder, dynamic> orderExpression = null);






BaseListReturnType<TemporaryTransactionOrder> GetAllTemporaryTransactionOrderListByTemporaryTransactionOrderState(long idTemporaryTransactionOrderState);

BaseListReturnType<TemporaryTransactionOrder> GetAllTemporaryTransactionOrderListByTemporaryTransactionOrderState(long idTemporaryTransactionOrderState, SubscriptionEntities db);

BaseListReturnType<TemporaryTransactionOrder> GetAllTemporaryTransactionOrderListByTemporaryTransactionOrderStateByPage(long idTemporaryTransactionOrderState, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<TemporaryTransactionOrder> GetAllTemporaryTransactionOrderListByTemporaryTransactionOrderStateByPage(long idTemporaryTransactionOrderState, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);



 BaseListReturnType<TemporaryTransactionOrder> GetAllTemporaryTransactionOrdersWithDocumentDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<TemporaryTransactionOrder, bool>> expression = null,bool shouldRemap = false, Func<TemporaryTransactionOrder, dynamic> orderExpression = null);
 BaseListReturnType<TemporaryTransactionOrder> GetAllTemporaryTransactionOrdersWithDocumentDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<TemporaryTransactionOrder, bool>> expression = null,bool shouldRemap = false, Func<TemporaryTransactionOrder, dynamic> orderExpression = null);






BaseListReturnType<TemporaryTransactionOrder> GetAllTemporaryTransactionOrderListByDocument(long idDocument);

BaseListReturnType<TemporaryTransactionOrder> GetAllTemporaryTransactionOrderListByDocument(long idDocument, SubscriptionEntities db);

BaseListReturnType<TemporaryTransactionOrder> GetAllTemporaryTransactionOrderListByDocumentByPage(long idDocument, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<TemporaryTransactionOrder> GetAllTemporaryTransactionOrderListByDocumentByPage(long idDocument, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);




List<TemporaryTransactionOrder> GetTemporaryTransactionOrderListByIdList(List<long> temporaryTransactionOrderIds);

List<TemporaryTransactionOrder> GetTemporaryTransactionOrderListByIdList(List<long> temporaryTransactionOrderIds, SubscriptionEntities db);

 BaseListReturnType<TemporaryTransactionOrder> GetAllTemporaryTransactionOrdersWithTemporaryTransactionOrderStateDetails(bool shouldRemap = false);
 BaseListReturnType<TemporaryTransactionOrder> GetAllTemporaryTransactionOrdersWithDocumentDetails(bool shouldRemap = false);
 BaseListReturnType<TemporaryTransactionOrder> GetAllTemporaryTransactionOrderWitDetails( List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<TemporaryTransactionOrder> GetAllTemporaryTransactionOrderWitDetails( SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 TemporaryTransactionOrder GetTemporaryTransactionOrder(long idTemporaryTransactionOrder,bool shouldRemap = false);
 TemporaryTransactionOrder GetTemporaryTransactionOrder(long idTemporaryTransactionOrder, SubscriptionEntities db,bool shouldRemap = false);
 TemporaryTransactionOrder GetTemporaryTransactionOrderWithTemporaryTransactionOrderStateDetails(long idTemporaryTransactionOrder,bool shouldRemap = false);
    


 TemporaryTransactionOrder GetTemporaryTransactionOrderWithDocumentDetails(long idTemporaryTransactionOrder,bool shouldRemap = false);
    


 TemporaryTransactionOrder GetTemporaryTransactionOrderCustom( Expression<Func<TemporaryTransactionOrder, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 TemporaryTransactionOrder GetTemporaryTransactionOrderCustom(SubscriptionEntities db, Expression<Func<TemporaryTransactionOrder, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<TemporaryTransactionOrder> GetTemporaryTransactionOrderCustomList( Expression<Func<TemporaryTransactionOrder, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<TemporaryTransactionOrder, dynamic> orderExpression = null);
 BaseListReturnType<TemporaryTransactionOrder> GetTemporaryTransactionOrderCustomList( SubscriptionEntities db , Expression<Func<TemporaryTransactionOrder, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<TemporaryTransactionOrder, dynamic> orderExpression = null);
 TemporaryTransactionOrder GetTemporaryTransactionOrderWithDetails(long idTemporaryTransactionOrder, List<string> includes = null,bool shouldRemap = false);
 TemporaryTransactionOrder GetTemporaryTransactionOrderWithDetails(long idTemporaryTransactionOrder, SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 TemporaryTransactionOrder GetTemporaryTransactionOrderWitDetails(long idTemporaryTransactionOrder,bool shouldRemap = false);
 TemporaryTransactionOrder GetTemporaryTransactionOrderWitDetails(long idTemporaryTransactionOrder, SubscriptionEntities db,bool shouldRemap = false);
 void SaveTemporaryTransactionOrder(TemporaryTransactionOrder temporaryTransactionOrder);
 void SaveTemporaryTransactionOrder(TemporaryTransactionOrder temporaryTransactionOrder, SubscriptionEntities db);
 void SaveOnlyTemporaryTransactionOrder(TemporaryTransactionOrder temporaryTransactionOrder);
 void SaveOnlyTemporaryTransactionOrder(TemporaryTransactionOrder temporaryTransactionOrder, SubscriptionEntities db);
 void DeleteTemporaryTransactionOrder(TemporaryTransactionOrder temporaryTransactionOrder);
 void DeleteTemporaryTransactionOrder(TemporaryTransactionOrder temporaryTransactionOrder, SubscriptionEntities db);		
  void DeletePermanentlyTemporaryTransactionOrder(TemporaryTransactionOrder temporaryTransactionOrder);
 void DeletePermanentlyTemporaryTransactionOrder(TemporaryTransactionOrder temporaryTransactionOrder, SubscriptionEntities db);	
	}
 	public partial interface ITemporaryTransactionOrderStateDao
	{
  List<TemporaryTransactionOrderState> GetAllTemporaryTransactionOrderStates(bool shouldRemap = false);
  List<TemporaryTransactionOrderState> GetAllTemporaryTransactionOrderStates(SubscriptionEntities db,bool shouldRemap = false);
  BaseListReturnType<TemporaryTransactionOrderState> GetAllTemporaryTransactionOrderStatesByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<TemporaryTransactionOrderState, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<TemporaryTransactionOrderState, dynamic> orderExpression = null);
  BaseListReturnType<TemporaryTransactionOrderState> GetAllTemporaryTransactionOrderStatesByPage(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<TemporaryTransactionOrderState, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<TemporaryTransactionOrderState, dynamic> orderExpression = null);
  
  BaseListReturnType<TemporaryTransactionOrderState> GetAllTemporaryTransactionOrderStatesByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<TemporaryTransactionOrderState, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<TemporaryTransactionOrderState, dynamic> orderExpression = null);
  BaseListReturnType<TemporaryTransactionOrderState> GetAllTemporaryTransactionOrderStatesByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<TemporaryTransactionOrderState, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<TemporaryTransactionOrderState, dynamic> orderExpression = null);

 BaseListReturnType<TemporaryTransactionOrderState> GetAllTemporaryTransactionOrderStatesWithTemporaryTransactionOrdersDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<TemporaryTransactionOrderState, bool>> expression = null,bool shouldRemap = false, Func<TemporaryTransactionOrderState, dynamic> orderExpression = null);
 BaseListReturnType<TemporaryTransactionOrderState> GetAllTemporaryTransactionOrderStatesWithTemporaryTransactionOrdersDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<TemporaryTransactionOrderState, bool>> expression = null,bool shouldRemap = false, Func<TemporaryTransactionOrderState, dynamic> orderExpression = null);


List<TemporaryTransactionOrderState> GetTemporaryTransactionOrderStateListByIdList(List<long> temporaryTransactionOrderStateIds);

List<TemporaryTransactionOrderState> GetTemporaryTransactionOrderStateListByIdList(List<long> temporaryTransactionOrderStateIds, SubscriptionEntities db);

 BaseListReturnType<TemporaryTransactionOrderState> GetAllTemporaryTransactionOrderStatesWithTemporaryTransactionOrdersDetails(bool shouldRemap = false);
 BaseListReturnType<TemporaryTransactionOrderState> GetAllTemporaryTransactionOrderStateWitDetails( List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<TemporaryTransactionOrderState> GetAllTemporaryTransactionOrderStateWitDetails( SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 TemporaryTransactionOrderState GetTemporaryTransactionOrderState(long idTemporaryTransactionOrderState,bool shouldRemap = false);
 TemporaryTransactionOrderState GetTemporaryTransactionOrderState(long idTemporaryTransactionOrderState, SubscriptionEntities db,bool shouldRemap = false);
 TemporaryTransactionOrderState GetTemporaryTransactionOrderStateWithTemporaryTransactionOrdersDetails(long idTemporaryTransactionOrderState,bool shouldRemap = false);
           List<TemporaryTransactionOrder> UpdateTemporaryTransactionOrdersForTemporaryTransactionOrderStateWithoutSavingNewItem(List<TemporaryTransactionOrder> newTemporaryTransactionOrders,long idTemporaryTransactionOrderState);
    List<TemporaryTransactionOrder> UpdateTemporaryTransactionOrdersForTemporaryTransactionOrderStateWithoutSavingNewItem(List<TemporaryTransactionOrder> newTemporaryTransactionOrders,long idTemporaryTransactionOrderState,SubscriptionEntities db);
          

    List<TemporaryTransactionOrder> UpdateTemporaryTransactionOrdersForTemporaryTransactionOrderState(List<TemporaryTransactionOrder> newTemporaryTransactionOrders,long idTemporaryTransactionOrderState);
    List<TemporaryTransactionOrder> UpdateTemporaryTransactionOrdersForTemporaryTransactionOrderState(List<TemporaryTransactionOrder> newTemporaryTransactionOrders,long idTemporaryTransactionOrderState,SubscriptionEntities db);
                           



 TemporaryTransactionOrderState GetTemporaryTransactionOrderStateCustom( Expression<Func<TemporaryTransactionOrderState, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 TemporaryTransactionOrderState GetTemporaryTransactionOrderStateCustom(SubscriptionEntities db, Expression<Func<TemporaryTransactionOrderState, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<TemporaryTransactionOrderState> GetTemporaryTransactionOrderStateCustomList( Expression<Func<TemporaryTransactionOrderState, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<TemporaryTransactionOrderState, dynamic> orderExpression = null);
 BaseListReturnType<TemporaryTransactionOrderState> GetTemporaryTransactionOrderStateCustomList( SubscriptionEntities db , Expression<Func<TemporaryTransactionOrderState, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<TemporaryTransactionOrderState, dynamic> orderExpression = null);
 TemporaryTransactionOrderState GetTemporaryTransactionOrderStateWithDetails(long idTemporaryTransactionOrderState, List<string> includes = null,bool shouldRemap = false);
 TemporaryTransactionOrderState GetTemporaryTransactionOrderStateWithDetails(long idTemporaryTransactionOrderState, SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 TemporaryTransactionOrderState GetTemporaryTransactionOrderStateWitDetails(long idTemporaryTransactionOrderState,bool shouldRemap = false);
 TemporaryTransactionOrderState GetTemporaryTransactionOrderStateWitDetails(long idTemporaryTransactionOrderState, SubscriptionEntities db,bool shouldRemap = false);
 void SaveTemporaryTransactionOrderState(TemporaryTransactionOrderState temporaryTransactionOrderState);
 void SaveTemporaryTransactionOrderState(TemporaryTransactionOrderState temporaryTransactionOrderState, SubscriptionEntities db);
 void SaveOnlyTemporaryTransactionOrderState(TemporaryTransactionOrderState temporaryTransactionOrderState);
 void SaveOnlyTemporaryTransactionOrderState(TemporaryTransactionOrderState temporaryTransactionOrderState, SubscriptionEntities db);
 void DeleteTemporaryTransactionOrderState(TemporaryTransactionOrderState temporaryTransactionOrderState);
 void DeleteTemporaryTransactionOrderState(TemporaryTransactionOrderState temporaryTransactionOrderState, SubscriptionEntities db);		
  void DeletePermanentlyTemporaryTransactionOrderState(TemporaryTransactionOrderState temporaryTransactionOrderState);
 void DeletePermanentlyTemporaryTransactionOrderState(TemporaryTransactionOrderState temporaryTransactionOrderState, SubscriptionEntities db);	
	}
 	public partial interface ITitleDao
	{
  List<Title> GetAllTitles(bool shouldRemap = false);
  List<Title> GetAllTitles(SubscriptionEntities db,bool shouldRemap = false);
  BaseListReturnType<Title> GetAllTitlesByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Title, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<Title, dynamic> orderExpression = null);
  BaseListReturnType<Title> GetAllTitlesByPage(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<Title, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<Title, dynamic> orderExpression = null);
  
  BaseListReturnType<Title> GetAllTitlesByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Title, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<Title, dynamic> orderExpression = null);
  BaseListReturnType<Title> GetAllTitlesByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<Title, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<Title, dynamic> orderExpression = null);

 BaseListReturnType<Title> GetAllTitlesWithOrderPersonsDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Title, bool>> expression = null,bool shouldRemap = false, Func<Title, dynamic> orderExpression = null);
 BaseListReturnType<Title> GetAllTitlesWithOrderPersonsDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Title, bool>> expression = null,bool shouldRemap = false, Func<Title, dynamic> orderExpression = null);

 BaseListReturnType<Title> GetAllTitlesWithPeopleDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Title, bool>> expression = null,bool shouldRemap = false, Func<Title, dynamic> orderExpression = null);
 BaseListReturnType<Title> GetAllTitlesWithPeopleDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Title, bool>> expression = null,bool shouldRemap = false, Func<Title, dynamic> orderExpression = null);


List<Title> GetTitleListByIdList(List<long> titleIds);

List<Title> GetTitleListByIdList(List<long> titleIds, SubscriptionEntities db);

 BaseListReturnType<Title> GetAllTitlesWithOrderPersonsDetails(bool shouldRemap = false);
 BaseListReturnType<Title> GetAllTitlesWithPeopleDetails(bool shouldRemap = false);
 BaseListReturnType<Title> GetAllTitleWitDetails( List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<Title> GetAllTitleWitDetails( SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 Title GetTitle(long idTitle,bool shouldRemap = false);
 Title GetTitle(long idTitle, SubscriptionEntities db,bool shouldRemap = false);
 Title GetTitleWithOrderPersonsDetails(long idTitle,bool shouldRemap = false);
           List<OrderPerson> UpdateOrderPersonsForTitleWithoutSavingNewItem(List<OrderPerson> newOrderPersons,long idTitle);
    List<OrderPerson> UpdateOrderPersonsForTitleWithoutSavingNewItem(List<OrderPerson> newOrderPersons,long idTitle,SubscriptionEntities db);
          

    List<OrderPerson> UpdateOrderPersonsForTitle(List<OrderPerson> newOrderPersons,long idTitle);
    List<OrderPerson> UpdateOrderPersonsForTitle(List<OrderPerson> newOrderPersons,long idTitle,SubscriptionEntities db);
                           



 Title GetTitleWithPeopleDetails(long idTitle,bool shouldRemap = false);
           List<Person> UpdatePeopleForTitleWithoutSavingNewItem(List<Person> newPeople,long idTitle);
    List<Person> UpdatePeopleForTitleWithoutSavingNewItem(List<Person> newPeople,long idTitle,SubscriptionEntities db);
          

    List<Person> UpdatePeopleForTitle(List<Person> newPeople,long idTitle);
    List<Person> UpdatePeopleForTitle(List<Person> newPeople,long idTitle,SubscriptionEntities db);
                           



 Title GetTitleCustom( Expression<Func<Title, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 Title GetTitleCustom(SubscriptionEntities db, Expression<Func<Title, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<Title> GetTitleCustomList( Expression<Func<Title, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<Title, dynamic> orderExpression = null);
 BaseListReturnType<Title> GetTitleCustomList( SubscriptionEntities db , Expression<Func<Title, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<Title, dynamic> orderExpression = null);
 Title GetTitleWithDetails(long idTitle, List<string> includes = null,bool shouldRemap = false);
 Title GetTitleWithDetails(long idTitle, SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 Title GetTitleWitDetails(long idTitle,bool shouldRemap = false);
 Title GetTitleWitDetails(long idTitle, SubscriptionEntities db,bool shouldRemap = false);
 void SaveTitle(Title title);
 void SaveTitle(Title title, SubscriptionEntities db);
 void SaveOnlyTitle(Title title);
 void SaveOnlyTitle(Title title, SubscriptionEntities db);
 void DeleteTitle(Title title);
 void DeleteTitle(Title title, SubscriptionEntities db);		
  void DeletePermanentlyTitle(Title title);
 void DeletePermanentlyTitle(Title title, SubscriptionEntities db);	
	}
 	public partial interface ITransactionDao
	{
  List<Transaction> GetAllTransactions(bool shouldRemap = false);
  List<Transaction> GetAllTransactions(SubscriptionEntities db,bool shouldRemap = false);
  BaseListReturnType<Transaction> GetAllTransactionsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Transaction, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<Transaction, dynamic> orderExpression = null);
  BaseListReturnType<Transaction> GetAllTransactionsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<Transaction, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<Transaction, dynamic> orderExpression = null);
  
  BaseListReturnType<Transaction> GetAllTransactionsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Transaction, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<Transaction, dynamic> orderExpression = null);
  BaseListReturnType<Transaction> GetAllTransactionsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<Transaction, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<Transaction, dynamic> orderExpression = null);

 BaseListReturnType<Transaction> GetAllTransactionsWithUserDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Transaction, bool>> expression = null,bool shouldRemap = false, Func<Transaction, dynamic> orderExpression = null);
 BaseListReturnType<Transaction> GetAllTransactionsWithUserDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Transaction, bool>> expression = null,bool shouldRemap = false, Func<Transaction, dynamic> orderExpression = null);






BaseListReturnType<Transaction> GetAllTransactionListByUser(long idUser);

BaseListReturnType<Transaction> GetAllTransactionListByUser(long idUser, SubscriptionEntities db);

BaseListReturnType<Transaction> GetAllTransactionListByUserByPage(long idUser, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<Transaction> GetAllTransactionListByUserByPage(long idUser, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);



 BaseListReturnType<Transaction> GetAllTransactionsWithTransactionStateDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Transaction, bool>> expression = null,bool shouldRemap = false, Func<Transaction, dynamic> orderExpression = null);
 BaseListReturnType<Transaction> GetAllTransactionsWithTransactionStateDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Transaction, bool>> expression = null,bool shouldRemap = false, Func<Transaction, dynamic> orderExpression = null);






BaseListReturnType<Transaction> GetAllTransactionListByTransactionState(long idTransactionState);

BaseListReturnType<Transaction> GetAllTransactionListByTransactionState(long idTransactionState, SubscriptionEntities db);

BaseListReturnType<Transaction> GetAllTransactionListByTransactionStateByPage(long idTransactionState, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<Transaction> GetAllTransactionListByTransactionStateByPage(long idTransactionState, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);



 BaseListReturnType<Transaction> GetAllTransactionsWithTransactionTypeDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Transaction, bool>> expression = null,bool shouldRemap = false, Func<Transaction, dynamic> orderExpression = null);
 BaseListReturnType<Transaction> GetAllTransactionsWithTransactionTypeDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Transaction, bool>> expression = null,bool shouldRemap = false, Func<Transaction, dynamic> orderExpression = null);






BaseListReturnType<Transaction> GetAllTransactionListByTransactionType(long idTransactionType);

BaseListReturnType<Transaction> GetAllTransactionListByTransactionType(long idTransactionType, SubscriptionEntities db);

BaseListReturnType<Transaction> GetAllTransactionListByTransactionTypeByPage(long idTransactionType, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<Transaction> GetAllTransactionListByTransactionTypeByPage(long idTransactionType, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);



 BaseListReturnType<Transaction> GetAllTransactionsWithCustomerDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Transaction, bool>> expression = null,bool shouldRemap = false, Func<Transaction, dynamic> orderExpression = null);
 BaseListReturnType<Transaction> GetAllTransactionsWithCustomerDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Transaction, bool>> expression = null,bool shouldRemap = false, Func<Transaction, dynamic> orderExpression = null);






BaseListReturnType<Transaction> GetAllTransactionListByCustomer(long idCustomer);

BaseListReturnType<Transaction> GetAllTransactionListByCustomer(long idCustomer, SubscriptionEntities db);

BaseListReturnType<Transaction> GetAllTransactionListByCustomerByPage(long idCustomer, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<Transaction> GetAllTransactionListByCustomerByPage(long idCustomer, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);



 BaseListReturnType<Transaction> GetAllTransactionsWithDocumentDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Transaction, bool>> expression = null,bool shouldRemap = false, Func<Transaction, dynamic> orderExpression = null);
 BaseListReturnType<Transaction> GetAllTransactionsWithDocumentDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Transaction, bool>> expression = null,bool shouldRemap = false, Func<Transaction, dynamic> orderExpression = null);






BaseListReturnType<Transaction> GetAllTransactionListByDocument(long idDocument);

BaseListReturnType<Transaction> GetAllTransactionListByDocument(long idDocument, SubscriptionEntities db);

BaseListReturnType<Transaction> GetAllTransactionListByDocumentByPage(long idDocument, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<Transaction> GetAllTransactionListByDocumentByPage(long idDocument, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);



 BaseListReturnType<Transaction> GetAllTransactionsWithScheduleSettingsDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Transaction, bool>> expression = null,bool shouldRemap = false, Func<Transaction, dynamic> orderExpression = null);
 BaseListReturnType<Transaction> GetAllTransactionsWithScheduleSettingsDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Transaction, bool>> expression = null,bool shouldRemap = false, Func<Transaction, dynamic> orderExpression = null);

 BaseListReturnType<Transaction> GetAllTransactionsWithTransactionDuesDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Transaction, bool>> expression = null,bool shouldRemap = false, Func<Transaction, dynamic> orderExpression = null);
 BaseListReturnType<Transaction> GetAllTransactionsWithTransactionDuesDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Transaction, bool>> expression = null,bool shouldRemap = false, Func<Transaction, dynamic> orderExpression = null);

 BaseListReturnType<Transaction> GetAllTransactionsWithTransactionDue_TransactionDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Transaction, bool>> expression = null,bool shouldRemap = false, Func<Transaction, dynamic> orderExpression = null);
 BaseListReturnType<Transaction> GetAllTransactionsWithTransactionDue_TransactionDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Transaction, bool>> expression = null,bool shouldRemap = false, Func<Transaction, dynamic> orderExpression = null);

 BaseListReturnType<Transaction> GetAllTransactionsWithPaymentsDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Transaction, bool>> expression = null,bool shouldRemap = false, Func<Transaction, dynamic> orderExpression = null);
 BaseListReturnType<Transaction> GetAllTransactionsWithPaymentsDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Transaction, bool>> expression = null,bool shouldRemap = false, Func<Transaction, dynamic> orderExpression = null);

 BaseListReturnType<Transaction> GetAllTransactionsWithPaymentDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Transaction, bool>> expression = null,bool shouldRemap = false, Func<Transaction, dynamic> orderExpression = null);
 BaseListReturnType<Transaction> GetAllTransactionsWithPaymentDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Transaction, bool>> expression = null,bool shouldRemap = false, Func<Transaction, dynamic> orderExpression = null);






BaseListReturnType<Transaction> GetAllTransactionListByPayment(long idPayment);

BaseListReturnType<Transaction> GetAllTransactionListByPayment(long idPayment, SubscriptionEntities db);

BaseListReturnType<Transaction> GetAllTransactionListByPaymentByPage(long idPayment, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<Transaction> GetAllTransactionListByPaymentByPage(long idPayment, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);



 BaseListReturnType<Transaction> GetAllTransactionsWithTransaction1DetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Transaction, bool>> expression = null,bool shouldRemap = false, Func<Transaction, dynamic> orderExpression = null);
 BaseListReturnType<Transaction> GetAllTransactionsWithTransaction1DetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Transaction, bool>> expression = null,bool shouldRemap = false, Func<Transaction, dynamic> orderExpression = null);






BaseListReturnType<Transaction> GetAllTransactionListByTransaction1(long idTransaction1);

BaseListReturnType<Transaction> GetAllTransactionListByTransaction1(long idTransaction1, SubscriptionEntities db);

BaseListReturnType<Transaction> GetAllTransactionListByTransaction1ByPage(long idTransaction1, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<Transaction> GetAllTransactionListByTransaction1ByPage(long idTransaction1, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);



 BaseListReturnType<Transaction> GetAllTransactionsWithTransaction2DetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Transaction, bool>> expression = null,bool shouldRemap = false, Func<Transaction, dynamic> orderExpression = null);
 BaseListReturnType<Transaction> GetAllTransactionsWithTransaction2DetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Transaction, bool>> expression = null,bool shouldRemap = false, Func<Transaction, dynamic> orderExpression = null);

 BaseListReturnType<Transaction> GetAllTransactionsWithTransaction11DetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Transaction, bool>> expression = null,bool shouldRemap = false, Func<Transaction, dynamic> orderExpression = null);
 BaseListReturnType<Transaction> GetAllTransactionsWithTransaction11DetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Transaction, bool>> expression = null,bool shouldRemap = false, Func<Transaction, dynamic> orderExpression = null);






BaseListReturnType<Transaction> GetAllTransactionListByTransaction11(long idTransaction11);

BaseListReturnType<Transaction> GetAllTransactionListByTransaction11(long idTransaction11, SubscriptionEntities db);

BaseListReturnType<Transaction> GetAllTransactionListByTransaction11ByPage(long idTransaction11, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<Transaction> GetAllTransactionListByTransaction11ByPage(long idTransaction11, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);



 BaseListReturnType<Transaction> GetAllTransactionsWithTransaction3DetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Transaction, bool>> expression = null,bool shouldRemap = false, Func<Transaction, dynamic> orderExpression = null);
 BaseListReturnType<Transaction> GetAllTransactionsWithTransaction3DetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Transaction, bool>> expression = null,bool shouldRemap = false, Func<Transaction, dynamic> orderExpression = null);

 BaseListReturnType<Transaction> GetAllTransactionsWithTransaction_PaymentDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Transaction, bool>> expression = null,bool shouldRemap = false, Func<Transaction, dynamic> orderExpression = null);
 BaseListReturnType<Transaction> GetAllTransactionsWithTransaction_PaymentDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Transaction, bool>> expression = null,bool shouldRemap = false, Func<Transaction, dynamic> orderExpression = null);

 BaseListReturnType<Transaction> GetAllTransactionsWithTransactionDetailsDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Transaction, bool>> expression = null,bool shouldRemap = false, Func<Transaction, dynamic> orderExpression = null);
 BaseListReturnType<Transaction> GetAllTransactionsWithTransactionDetailsDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Transaction, bool>> expression = null,bool shouldRemap = false, Func<Transaction, dynamic> orderExpression = null);

 BaseListReturnType<Transaction> GetAllTransactionsWithTransaction_MailToSendDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Transaction, bool>> expression = null,bool shouldRemap = false, Func<Transaction, dynamic> orderExpression = null);
 BaseListReturnType<Transaction> GetAllTransactionsWithTransaction_MailToSendDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Transaction, bool>> expression = null,bool shouldRemap = false, Func<Transaction, dynamic> orderExpression = null);

 BaseListReturnType<Transaction> GetAllTransactionsWithTransaction_BankStatementStagingDetailDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Transaction, bool>> expression = null,bool shouldRemap = false, Func<Transaction, dynamic> orderExpression = null);
 BaseListReturnType<Transaction> GetAllTransactionsWithTransaction_BankStatementStagingDetailDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Transaction, bool>> expression = null,bool shouldRemap = false, Func<Transaction, dynamic> orderExpression = null);

 BaseListReturnType<Transaction> GetAllTransactionsWithTransactionAccountDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Transaction, bool>> expression = null,bool shouldRemap = false, Func<Transaction, dynamic> orderExpression = null);
 BaseListReturnType<Transaction> GetAllTransactionsWithTransactionAccountDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Transaction, bool>> expression = null,bool shouldRemap = false, Func<Transaction, dynamic> orderExpression = null);






BaseListReturnType<Transaction> GetAllTransactionListByTransactionAccount(long idTransactionAccount);

BaseListReturnType<Transaction> GetAllTransactionListByTransactionAccount(long idTransactionAccount, SubscriptionEntities db);

BaseListReturnType<Transaction> GetAllTransactionListByTransactionAccountByPage(long idTransactionAccount, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<Transaction> GetAllTransactionListByTransactionAccountByPage(long idTransactionAccount, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);



 BaseListReturnType<Transaction> GetAllTransactionsWithTransactionClassDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Transaction, bool>> expression = null,bool shouldRemap = false, Func<Transaction, dynamic> orderExpression = null);
 BaseListReturnType<Transaction> GetAllTransactionsWithTransactionClassDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Transaction, bool>> expression = null,bool shouldRemap = false, Func<Transaction, dynamic> orderExpression = null);






BaseListReturnType<Transaction> GetAllTransactionListByTransactionClass(long idTransactionClass);

BaseListReturnType<Transaction> GetAllTransactionListByTransactionClass(long idTransactionClass, SubscriptionEntities db);

BaseListReturnType<Transaction> GetAllTransactionListByTransactionClassByPage(long idTransactionClass, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<Transaction> GetAllTransactionListByTransactionClassByPage(long idTransactionClass, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);



 BaseListReturnType<Transaction> GetAllTransactionsWithTransactionTemplateDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Transaction, bool>> expression = null,bool shouldRemap = false, Func<Transaction, dynamic> orderExpression = null);
 BaseListReturnType<Transaction> GetAllTransactionsWithTransactionTemplateDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Transaction, bool>> expression = null,bool shouldRemap = false, Func<Transaction, dynamic> orderExpression = null);






BaseListReturnType<Transaction> GetAllTransactionListByTransactionTemplate(long idTransactionTemplate);

BaseListReturnType<Transaction> GetAllTransactionListByTransactionTemplate(long idTransactionTemplate, SubscriptionEntities db);

BaseListReturnType<Transaction> GetAllTransactionListByTransactionTemplateByPage(long idTransactionTemplate, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<Transaction> GetAllTransactionListByTransactionTemplateByPage(long idTransactionTemplate, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);




List<Transaction> GetTransactionListByIdList(List<long> transactionIds);

List<Transaction> GetTransactionListByIdList(List<long> transactionIds, SubscriptionEntities db);

 BaseListReturnType<Transaction> GetAllTransactionsWithUserDetails(bool shouldRemap = false);
 BaseListReturnType<Transaction> GetAllTransactionsWithTransactionStateDetails(bool shouldRemap = false);
 BaseListReturnType<Transaction> GetAllTransactionsWithTransactionTypeDetails(bool shouldRemap = false);
 BaseListReturnType<Transaction> GetAllTransactionsWithCustomerDetails(bool shouldRemap = false);
 BaseListReturnType<Transaction> GetAllTransactionsWithDocumentDetails(bool shouldRemap = false);
 BaseListReturnType<Transaction> GetAllTransactionsWithScheduleSettingsDetails(bool shouldRemap = false);
 BaseListReturnType<Transaction> GetAllTransactionsWithTransactionDuesDetails(bool shouldRemap = false);
 BaseListReturnType<Transaction> GetAllTransactionsWithTransactionDue_TransactionDetails(bool shouldRemap = false);
 BaseListReturnType<Transaction> GetAllTransactionsWithPaymentsDetails(bool shouldRemap = false);
 BaseListReturnType<Transaction> GetAllTransactionsWithPaymentDetails(bool shouldRemap = false);
 BaseListReturnType<Transaction> GetAllTransactionsWithTransaction1Details(bool shouldRemap = false);
 BaseListReturnType<Transaction> GetAllTransactionsWithTransaction2Details(bool shouldRemap = false);
 BaseListReturnType<Transaction> GetAllTransactionsWithTransaction11Details(bool shouldRemap = false);
 BaseListReturnType<Transaction> GetAllTransactionsWithTransaction3Details(bool shouldRemap = false);
 BaseListReturnType<Transaction> GetAllTransactionsWithTransaction_PaymentDetails(bool shouldRemap = false);
 BaseListReturnType<Transaction> GetAllTransactionsWithTransactionDetailsDetails(bool shouldRemap = false);
 BaseListReturnType<Transaction> GetAllTransactionsWithTransaction_MailToSendDetails(bool shouldRemap = false);
 BaseListReturnType<Transaction> GetAllTransactionsWithTransaction_BankStatementStagingDetailDetails(bool shouldRemap = false);
 BaseListReturnType<Transaction> GetAllTransactionsWithTransactionAccountDetails(bool shouldRemap = false);
 BaseListReturnType<Transaction> GetAllTransactionsWithTransactionClassDetails(bool shouldRemap = false);
 BaseListReturnType<Transaction> GetAllTransactionsWithTransactionTemplateDetails(bool shouldRemap = false);
 BaseListReturnType<Transaction> GetAllTransactionWitDetails( List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<Transaction> GetAllTransactionWitDetails( SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 Transaction GetTransaction(long idTransaction,bool shouldRemap = false);
 Transaction GetTransaction(long idTransaction, SubscriptionEntities db,bool shouldRemap = false);
 Transaction GetTransactionWithUserDetails(long idTransaction,bool shouldRemap = false);
    


 Transaction GetTransactionWithTransactionStateDetails(long idTransaction,bool shouldRemap = false);
    


 Transaction GetTransactionWithTransactionTypeDetails(long idTransaction,bool shouldRemap = false);
    


 Transaction GetTransactionWithCustomerDetails(long idTransaction,bool shouldRemap = false);
    


 Transaction GetTransactionWithDocumentDetails(long idTransaction,bool shouldRemap = false);
    


 Transaction GetTransactionWithScheduleSettingsDetails(long idTransaction,bool shouldRemap = false);
           List<ScheduleSetting> UpdateScheduleSettingsForTransactionWithoutSavingNewItem(List<ScheduleSetting> newScheduleSettings,long idTransaction);
    List<ScheduleSetting> UpdateScheduleSettingsForTransactionWithoutSavingNewItem(List<ScheduleSetting> newScheduleSettings,long idTransaction,SubscriptionEntities db);
          

    List<ScheduleSetting> UpdateScheduleSettingsForTransaction(List<ScheduleSetting> newScheduleSettings,long idTransaction);
    List<ScheduleSetting> UpdateScheduleSettingsForTransaction(List<ScheduleSetting> newScheduleSettings,long idTransaction,SubscriptionEntities db);
                           



 Transaction GetTransactionWithTransactionDuesDetails(long idTransaction,bool shouldRemap = false);
           List<TransactionDue> UpdateTransactionDuesForTransactionWithoutSavingNewItem(List<TransactionDue> newTransactionDues,long idTransaction);
    List<TransactionDue> UpdateTransactionDuesForTransactionWithoutSavingNewItem(List<TransactionDue> newTransactionDues,long idTransaction,SubscriptionEntities db);
          

    List<TransactionDue> UpdateTransactionDuesForTransaction(List<TransactionDue> newTransactionDues,long idTransaction);
    List<TransactionDue> UpdateTransactionDuesForTransaction(List<TransactionDue> newTransactionDues,long idTransaction,SubscriptionEntities db);
                           



 Transaction GetTransactionWithTransactionDue_TransactionDetails(long idTransaction,bool shouldRemap = false);
           List<TransactionDue_Transaction> UpdateTransactionDue_TransactionForTransactionWithoutSavingNewItem(List<TransactionDue_Transaction> newTransactionDue_Transaction,long idTransaction);
    List<TransactionDue_Transaction> UpdateTransactionDue_TransactionForTransactionWithoutSavingNewItem(List<TransactionDue_Transaction> newTransactionDue_Transaction,long idTransaction,SubscriptionEntities db);
          

    List<TransactionDue_Transaction> UpdateTransactionDue_TransactionForTransaction(List<TransactionDue_Transaction> newTransactionDue_Transaction,long idTransaction);
    List<TransactionDue_Transaction> UpdateTransactionDue_TransactionForTransaction(List<TransactionDue_Transaction> newTransactionDue_Transaction,long idTransaction,SubscriptionEntities db);
                           



 Transaction GetTransactionWithPaymentsDetails(long idTransaction,bool shouldRemap = false);
           List<Payment> UpdatePaymentsForTransactionWithoutSavingNewItem(List<Payment> newPayments,long idTransaction);
    List<Payment> UpdatePaymentsForTransactionWithoutSavingNewItem(List<Payment> newPayments,long idTransaction,SubscriptionEntities db);
          

    List<Payment> UpdatePaymentsForTransaction(List<Payment> newPayments,long idTransaction);
    List<Payment> UpdatePaymentsForTransaction(List<Payment> newPayments,long idTransaction,SubscriptionEntities db);
                           



 Transaction GetTransactionWithPaymentDetails(long idTransaction,bool shouldRemap = false);
    


 Transaction GetTransactionWithTransaction1Details(long idTransaction,bool shouldRemap = false);
    


 Transaction GetTransactionWithTransaction2Details(long idTransaction,bool shouldRemap = false);
    


 Transaction GetTransactionWithTransaction11Details(long idTransaction,bool shouldRemap = false);
    


 Transaction GetTransactionWithTransaction3Details(long idTransaction,bool shouldRemap = false);
    


 Transaction GetTransactionWithTransaction_PaymentDetails(long idTransaction,bool shouldRemap = false);
           List<Transaction_Payment> UpdateTransaction_PaymentForTransactionWithoutSavingNewItem(List<Transaction_Payment> newTransaction_Payment,long idTransaction);
    List<Transaction_Payment> UpdateTransaction_PaymentForTransactionWithoutSavingNewItem(List<Transaction_Payment> newTransaction_Payment,long idTransaction,SubscriptionEntities db);
          

    List<Transaction_Payment> UpdateTransaction_PaymentForTransaction(List<Transaction_Payment> newTransaction_Payment,long idTransaction);
    List<Transaction_Payment> UpdateTransaction_PaymentForTransaction(List<Transaction_Payment> newTransaction_Payment,long idTransaction,SubscriptionEntities db);
                           



 Transaction GetTransactionWithTransactionDetailsDetails(long idTransaction,bool shouldRemap = false);
           List<TransactionDetail> UpdateTransactionDetailsForTransactionWithoutSavingNewItem(List<TransactionDetail> newTransactionDetails,long idTransaction);
    List<TransactionDetail> UpdateTransactionDetailsForTransactionWithoutSavingNewItem(List<TransactionDetail> newTransactionDetails,long idTransaction,SubscriptionEntities db);
          

    List<TransactionDetail> UpdateTransactionDetailsForTransaction(List<TransactionDetail> newTransactionDetails,long idTransaction);
    List<TransactionDetail> UpdateTransactionDetailsForTransaction(List<TransactionDetail> newTransactionDetails,long idTransaction,SubscriptionEntities db);
                           



 Transaction GetTransactionWithTransaction_MailToSendDetails(long idTransaction,bool shouldRemap = false);
           List<Transaction_MailToSend> UpdateTransaction_MailToSendForTransactionWithoutSavingNewItem(List<Transaction_MailToSend> newTransaction_MailToSend,long idTransaction);
    List<Transaction_MailToSend> UpdateTransaction_MailToSendForTransactionWithoutSavingNewItem(List<Transaction_MailToSend> newTransaction_MailToSend,long idTransaction,SubscriptionEntities db);
          

    List<Transaction_MailToSend> UpdateTransaction_MailToSendForTransaction(List<Transaction_MailToSend> newTransaction_MailToSend,long idTransaction);
    List<Transaction_MailToSend> UpdateTransaction_MailToSendForTransaction(List<Transaction_MailToSend> newTransaction_MailToSend,long idTransaction,SubscriptionEntities db);
                           



 Transaction GetTransactionWithTransaction_BankStatementStagingDetailDetails(long idTransaction,bool shouldRemap = false);
           List<Transaction_BankStatementStagingDetail> UpdateTransaction_BankStatementStagingDetailForTransactionWithoutSavingNewItem(List<Transaction_BankStatementStagingDetail> newTransaction_BankStatementStagingDetail,long idTransaction);
    List<Transaction_BankStatementStagingDetail> UpdateTransaction_BankStatementStagingDetailForTransactionWithoutSavingNewItem(List<Transaction_BankStatementStagingDetail> newTransaction_BankStatementStagingDetail,long idTransaction,SubscriptionEntities db);
          

    List<Transaction_BankStatementStagingDetail> UpdateTransaction_BankStatementStagingDetailForTransaction(List<Transaction_BankStatementStagingDetail> newTransaction_BankStatementStagingDetail,long idTransaction);
    List<Transaction_BankStatementStagingDetail> UpdateTransaction_BankStatementStagingDetailForTransaction(List<Transaction_BankStatementStagingDetail> newTransaction_BankStatementStagingDetail,long idTransaction,SubscriptionEntities db);
                           



 Transaction GetTransactionWithTransactionAccountDetails(long idTransaction,bool shouldRemap = false);
    


 Transaction GetTransactionWithTransactionClassDetails(long idTransaction,bool shouldRemap = false);
    


 Transaction GetTransactionWithTransactionTemplateDetails(long idTransaction,bool shouldRemap = false);
    


 Transaction GetTransactionCustom( Expression<Func<Transaction, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 Transaction GetTransactionCustom(SubscriptionEntities db, Expression<Func<Transaction, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<Transaction> GetTransactionCustomList( Expression<Func<Transaction, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<Transaction, dynamic> orderExpression = null);
 BaseListReturnType<Transaction> GetTransactionCustomList( SubscriptionEntities db , Expression<Func<Transaction, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<Transaction, dynamic> orderExpression = null);
 Transaction GetTransactionWithDetails(long idTransaction, List<string> includes = null,bool shouldRemap = false);
 Transaction GetTransactionWithDetails(long idTransaction, SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 Transaction GetTransactionWitDetails(long idTransaction,bool shouldRemap = false);
 Transaction GetTransactionWitDetails(long idTransaction, SubscriptionEntities db,bool shouldRemap = false);
 void SaveTransaction(Transaction transaction);
 void SaveTransaction(Transaction transaction, SubscriptionEntities db);
 void SaveOnlyTransaction(Transaction transaction);
 void SaveOnlyTransaction(Transaction transaction, SubscriptionEntities db);
 void DeleteTransaction(Transaction transaction);
 void DeleteTransaction(Transaction transaction, SubscriptionEntities db);		
  void DeletePermanentlyTransaction(Transaction transaction);
 void DeletePermanentlyTransaction(Transaction transaction, SubscriptionEntities db);	
	}
 	public partial interface ITransaction_BankStatementStagingDetailDao
	{
  List<Transaction_BankStatementStagingDetail> GetAllTransaction_BankStatementStagingDetail(bool shouldRemap = false);
  List<Transaction_BankStatementStagingDetail> GetAllTransaction_BankStatementStagingDetail(SubscriptionEntities db,bool shouldRemap = false);
  BaseListReturnType<Transaction_BankStatementStagingDetail> GetAllTransaction_BankStatementStagingDetailByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Transaction_BankStatementStagingDetail, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<Transaction_BankStatementStagingDetail, dynamic> orderExpression = null);
  BaseListReturnType<Transaction_BankStatementStagingDetail> GetAllTransaction_BankStatementStagingDetailByPage(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<Transaction_BankStatementStagingDetail, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<Transaction_BankStatementStagingDetail, dynamic> orderExpression = null);
  
  BaseListReturnType<Transaction_BankStatementStagingDetail> GetAllTransaction_BankStatementStagingDetailByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Transaction_BankStatementStagingDetail, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<Transaction_BankStatementStagingDetail, dynamic> orderExpression = null);
  BaseListReturnType<Transaction_BankStatementStagingDetail> GetAllTransaction_BankStatementStagingDetailByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<Transaction_BankStatementStagingDetail, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<Transaction_BankStatementStagingDetail, dynamic> orderExpression = null);

 BaseListReturnType<Transaction_BankStatementStagingDetail> GetAllTransaction_BankStatementStagingDetailWithBankStatementStagingDetailDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Transaction_BankStatementStagingDetail, bool>> expression = null,bool shouldRemap = false, Func<Transaction_BankStatementStagingDetail, dynamic> orderExpression = null);
 BaseListReturnType<Transaction_BankStatementStagingDetail> GetAllTransaction_BankStatementStagingDetailWithBankStatementStagingDetailDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Transaction_BankStatementStagingDetail, bool>> expression = null,bool shouldRemap = false, Func<Transaction_BankStatementStagingDetail, dynamic> orderExpression = null);






BaseListReturnType<Transaction_BankStatementStagingDetail> GetAllTransaction_BankStatementStagingDetailListByBankStatementStagingDetail(long idBankStatementStagingDetail);

BaseListReturnType<Transaction_BankStatementStagingDetail> GetAllTransaction_BankStatementStagingDetailListByBankStatementStagingDetail(long idBankStatementStagingDetail, SubscriptionEntities db);

BaseListReturnType<Transaction_BankStatementStagingDetail> GetAllTransaction_BankStatementStagingDetailListByBankStatementStagingDetailByPage(long idBankStatementStagingDetail, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<Transaction_BankStatementStagingDetail> GetAllTransaction_BankStatementStagingDetailListByBankStatementStagingDetailByPage(long idBankStatementStagingDetail, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);



 BaseListReturnType<Transaction_BankStatementStagingDetail> GetAllTransaction_BankStatementStagingDetailWithTransactionDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Transaction_BankStatementStagingDetail, bool>> expression = null,bool shouldRemap = false, Func<Transaction_BankStatementStagingDetail, dynamic> orderExpression = null);
 BaseListReturnType<Transaction_BankStatementStagingDetail> GetAllTransaction_BankStatementStagingDetailWithTransactionDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Transaction_BankStatementStagingDetail, bool>> expression = null,bool shouldRemap = false, Func<Transaction_BankStatementStagingDetail, dynamic> orderExpression = null);






BaseListReturnType<Transaction_BankStatementStagingDetail> GetAllTransaction_BankStatementStagingDetailListByTransaction(long idTransaction);

BaseListReturnType<Transaction_BankStatementStagingDetail> GetAllTransaction_BankStatementStagingDetailListByTransaction(long idTransaction, SubscriptionEntities db);

BaseListReturnType<Transaction_BankStatementStagingDetail> GetAllTransaction_BankStatementStagingDetailListByTransactionByPage(long idTransaction, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<Transaction_BankStatementStagingDetail> GetAllTransaction_BankStatementStagingDetailListByTransactionByPage(long idTransaction, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);




List<Transaction_BankStatementStagingDetail> GetTransaction_BankStatementStagingDetailListByIdList(List<long> transaction_BankStatementStagingDetailIds);

List<Transaction_BankStatementStagingDetail> GetTransaction_BankStatementStagingDetailListByIdList(List<long> transaction_BankStatementStagingDetailIds, SubscriptionEntities db);

 BaseListReturnType<Transaction_BankStatementStagingDetail> GetAllTransaction_BankStatementStagingDetailWithBankStatementStagingDetailDetails(bool shouldRemap = false);
 BaseListReturnType<Transaction_BankStatementStagingDetail> GetAllTransaction_BankStatementStagingDetailWithTransactionDetails(bool shouldRemap = false);
 BaseListReturnType<Transaction_BankStatementStagingDetail> GetAllTransaction_BankStatementStagingDetailWitDetails( List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<Transaction_BankStatementStagingDetail> GetAllTransaction_BankStatementStagingDetailWitDetails( SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 Transaction_BankStatementStagingDetail GetTransaction_BankStatementStagingDetail(long idTransaction_BankStatementStagingDetail,bool shouldRemap = false);
 Transaction_BankStatementStagingDetail GetTransaction_BankStatementStagingDetail(long idTransaction_BankStatementStagingDetail, SubscriptionEntities db,bool shouldRemap = false);
 Transaction_BankStatementStagingDetail GetTransaction_BankStatementStagingDetailWithBankStatementStagingDetailDetails(long idTransaction_BankStatementStagingDetail,bool shouldRemap = false);
    


 Transaction_BankStatementStagingDetail GetTransaction_BankStatementStagingDetailWithTransactionDetails(long idTransaction_BankStatementStagingDetail,bool shouldRemap = false);
    


 Transaction_BankStatementStagingDetail GetTransaction_BankStatementStagingDetailCustom( Expression<Func<Transaction_BankStatementStagingDetail, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 Transaction_BankStatementStagingDetail GetTransaction_BankStatementStagingDetailCustom(SubscriptionEntities db, Expression<Func<Transaction_BankStatementStagingDetail, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<Transaction_BankStatementStagingDetail> GetTransaction_BankStatementStagingDetailCustomList( Expression<Func<Transaction_BankStatementStagingDetail, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<Transaction_BankStatementStagingDetail, dynamic> orderExpression = null);
 BaseListReturnType<Transaction_BankStatementStagingDetail> GetTransaction_BankStatementStagingDetailCustomList( SubscriptionEntities db , Expression<Func<Transaction_BankStatementStagingDetail, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<Transaction_BankStatementStagingDetail, dynamic> orderExpression = null);
 Transaction_BankStatementStagingDetail GetTransaction_BankStatementStagingDetailWithDetails(long idTransaction_BankStatementStagingDetail, List<string> includes = null,bool shouldRemap = false);
 Transaction_BankStatementStagingDetail GetTransaction_BankStatementStagingDetailWithDetails(long idTransaction_BankStatementStagingDetail, SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 Transaction_BankStatementStagingDetail GetTransaction_BankStatementStagingDetailWitDetails(long idTransaction_BankStatementStagingDetail,bool shouldRemap = false);
 Transaction_BankStatementStagingDetail GetTransaction_BankStatementStagingDetailWitDetails(long idTransaction_BankStatementStagingDetail, SubscriptionEntities db,bool shouldRemap = false);
 void SaveTransaction_BankStatementStagingDetail(Transaction_BankStatementStagingDetail transaction_BankStatementStagingDetail);
 void SaveTransaction_BankStatementStagingDetail(Transaction_BankStatementStagingDetail transaction_BankStatementStagingDetail, SubscriptionEntities db);
 void SaveOnlyTransaction_BankStatementStagingDetail(Transaction_BankStatementStagingDetail transaction_BankStatementStagingDetail);
 void SaveOnlyTransaction_BankStatementStagingDetail(Transaction_BankStatementStagingDetail transaction_BankStatementStagingDetail, SubscriptionEntities db);
 void DeleteTransaction_BankStatementStagingDetail(Transaction_BankStatementStagingDetail transaction_BankStatementStagingDetail);
 void DeleteTransaction_BankStatementStagingDetail(Transaction_BankStatementStagingDetail transaction_BankStatementStagingDetail, SubscriptionEntities db);		
  void DeletePermanentlyTransaction_BankStatementStagingDetail(Transaction_BankStatementStagingDetail transaction_BankStatementStagingDetail);
 void DeletePermanentlyTransaction_BankStatementStagingDetail(Transaction_BankStatementStagingDetail transaction_BankStatementStagingDetail, SubscriptionEntities db);	
	}
 	public partial interface ITransaction_MailToSendDao
	{
  List<Transaction_MailToSend> GetAllTransaction_MailToSend(bool shouldRemap = false);
  List<Transaction_MailToSend> GetAllTransaction_MailToSend(SubscriptionEntities db,bool shouldRemap = false);
  BaseListReturnType<Transaction_MailToSend> GetAllTransaction_MailToSendByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Transaction_MailToSend, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<Transaction_MailToSend, dynamic> orderExpression = null);
  BaseListReturnType<Transaction_MailToSend> GetAllTransaction_MailToSendByPage(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<Transaction_MailToSend, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<Transaction_MailToSend, dynamic> orderExpression = null);
  
  BaseListReturnType<Transaction_MailToSend> GetAllTransaction_MailToSendByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Transaction_MailToSend, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<Transaction_MailToSend, dynamic> orderExpression = null);
  BaseListReturnType<Transaction_MailToSend> GetAllTransaction_MailToSendByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<Transaction_MailToSend, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<Transaction_MailToSend, dynamic> orderExpression = null);

 BaseListReturnType<Transaction_MailToSend> GetAllTransaction_MailToSendWithMailToSendDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Transaction_MailToSend, bool>> expression = null,bool shouldRemap = false, Func<Transaction_MailToSend, dynamic> orderExpression = null);
 BaseListReturnType<Transaction_MailToSend> GetAllTransaction_MailToSendWithMailToSendDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Transaction_MailToSend, bool>> expression = null,bool shouldRemap = false, Func<Transaction_MailToSend, dynamic> orderExpression = null);






BaseListReturnType<Transaction_MailToSend> GetAllTransaction_MailToSendListByMailToSend(long idMailToSend);

BaseListReturnType<Transaction_MailToSend> GetAllTransaction_MailToSendListByMailToSend(long idMailToSend, SubscriptionEntities db);

BaseListReturnType<Transaction_MailToSend> GetAllTransaction_MailToSendListByMailToSendByPage(long idMailToSend, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<Transaction_MailToSend> GetAllTransaction_MailToSendListByMailToSendByPage(long idMailToSend, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);



 BaseListReturnType<Transaction_MailToSend> GetAllTransaction_MailToSendWithTransactionDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Transaction_MailToSend, bool>> expression = null,bool shouldRemap = false, Func<Transaction_MailToSend, dynamic> orderExpression = null);
 BaseListReturnType<Transaction_MailToSend> GetAllTransaction_MailToSendWithTransactionDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Transaction_MailToSend, bool>> expression = null,bool shouldRemap = false, Func<Transaction_MailToSend, dynamic> orderExpression = null);






BaseListReturnType<Transaction_MailToSend> GetAllTransaction_MailToSendListByTransaction(long idTransaction);

BaseListReturnType<Transaction_MailToSend> GetAllTransaction_MailToSendListByTransaction(long idTransaction, SubscriptionEntities db);

BaseListReturnType<Transaction_MailToSend> GetAllTransaction_MailToSendListByTransactionByPage(long idTransaction, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<Transaction_MailToSend> GetAllTransaction_MailToSendListByTransactionByPage(long idTransaction, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);




List<Transaction_MailToSend> GetTransaction_MailToSendListByIdList(List<long> transaction_MailToSendIds);

List<Transaction_MailToSend> GetTransaction_MailToSendListByIdList(List<long> transaction_MailToSendIds, SubscriptionEntities db);

 BaseListReturnType<Transaction_MailToSend> GetAllTransaction_MailToSendWithMailToSendDetails(bool shouldRemap = false);
 BaseListReturnType<Transaction_MailToSend> GetAllTransaction_MailToSendWithTransactionDetails(bool shouldRemap = false);
 BaseListReturnType<Transaction_MailToSend> GetAllTransaction_MailToSendWitDetails( List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<Transaction_MailToSend> GetAllTransaction_MailToSendWitDetails( SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 Transaction_MailToSend GetTransaction_MailToSend(long idTransaction_MailToSend,bool shouldRemap = false);
 Transaction_MailToSend GetTransaction_MailToSend(long idTransaction_MailToSend, SubscriptionEntities db,bool shouldRemap = false);
 Transaction_MailToSend GetTransaction_MailToSendWithMailToSendDetails(long idTransaction_MailToSend,bool shouldRemap = false);
    


 Transaction_MailToSend GetTransaction_MailToSendWithTransactionDetails(long idTransaction_MailToSend,bool shouldRemap = false);
    


 Transaction_MailToSend GetTransaction_MailToSendCustom( Expression<Func<Transaction_MailToSend, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 Transaction_MailToSend GetTransaction_MailToSendCustom(SubscriptionEntities db, Expression<Func<Transaction_MailToSend, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<Transaction_MailToSend> GetTransaction_MailToSendCustomList( Expression<Func<Transaction_MailToSend, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<Transaction_MailToSend, dynamic> orderExpression = null);
 BaseListReturnType<Transaction_MailToSend> GetTransaction_MailToSendCustomList( SubscriptionEntities db , Expression<Func<Transaction_MailToSend, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<Transaction_MailToSend, dynamic> orderExpression = null);
 Transaction_MailToSend GetTransaction_MailToSendWithDetails(long idTransaction_MailToSend, List<string> includes = null,bool shouldRemap = false);
 Transaction_MailToSend GetTransaction_MailToSendWithDetails(long idTransaction_MailToSend, SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 Transaction_MailToSend GetTransaction_MailToSendWitDetails(long idTransaction_MailToSend,bool shouldRemap = false);
 Transaction_MailToSend GetTransaction_MailToSendWitDetails(long idTransaction_MailToSend, SubscriptionEntities db,bool shouldRemap = false);
 void SaveTransaction_MailToSend(Transaction_MailToSend transaction_MailToSend);
 void SaveTransaction_MailToSend(Transaction_MailToSend transaction_MailToSend, SubscriptionEntities db);
 void SaveOnlyTransaction_MailToSend(Transaction_MailToSend transaction_MailToSend);
 void SaveOnlyTransaction_MailToSend(Transaction_MailToSend transaction_MailToSend, SubscriptionEntities db);
 void DeleteTransaction_MailToSend(Transaction_MailToSend transaction_MailToSend);
 void DeleteTransaction_MailToSend(Transaction_MailToSend transaction_MailToSend, SubscriptionEntities db);		
  void DeletePermanentlyTransaction_MailToSend(Transaction_MailToSend transaction_MailToSend);
 void DeletePermanentlyTransaction_MailToSend(Transaction_MailToSend transaction_MailToSend, SubscriptionEntities db);	
	}
 	public partial interface ITransaction_PaymentDao
	{
  List<Transaction_Payment> GetAllTransaction_Payment(bool shouldRemap = false);
  List<Transaction_Payment> GetAllTransaction_Payment(SubscriptionEntities db,bool shouldRemap = false);
  BaseListReturnType<Transaction_Payment> GetAllTransaction_PaymentByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Transaction_Payment, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<Transaction_Payment, dynamic> orderExpression = null);
  BaseListReturnType<Transaction_Payment> GetAllTransaction_PaymentByPage(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<Transaction_Payment, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<Transaction_Payment, dynamic> orderExpression = null);
  
  BaseListReturnType<Transaction_Payment> GetAllTransaction_PaymentByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Transaction_Payment, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<Transaction_Payment, dynamic> orderExpression = null);
  BaseListReturnType<Transaction_Payment> GetAllTransaction_PaymentByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<Transaction_Payment, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<Transaction_Payment, dynamic> orderExpression = null);

 BaseListReturnType<Transaction_Payment> GetAllTransaction_PaymentWithPaymentDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Transaction_Payment, bool>> expression = null,bool shouldRemap = false, Func<Transaction_Payment, dynamic> orderExpression = null);
 BaseListReturnType<Transaction_Payment> GetAllTransaction_PaymentWithPaymentDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Transaction_Payment, bool>> expression = null,bool shouldRemap = false, Func<Transaction_Payment, dynamic> orderExpression = null);






BaseListReturnType<Transaction_Payment> GetAllTransaction_PaymentListByPayment(long idPayment);

BaseListReturnType<Transaction_Payment> GetAllTransaction_PaymentListByPayment(long idPayment, SubscriptionEntities db);

BaseListReturnType<Transaction_Payment> GetAllTransaction_PaymentListByPaymentByPage(long idPayment, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<Transaction_Payment> GetAllTransaction_PaymentListByPaymentByPage(long idPayment, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);



 BaseListReturnType<Transaction_Payment> GetAllTransaction_PaymentWithTransactionDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Transaction_Payment, bool>> expression = null,bool shouldRemap = false, Func<Transaction_Payment, dynamic> orderExpression = null);
 BaseListReturnType<Transaction_Payment> GetAllTransaction_PaymentWithTransactionDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Transaction_Payment, bool>> expression = null,bool shouldRemap = false, Func<Transaction_Payment, dynamic> orderExpression = null);






BaseListReturnType<Transaction_Payment> GetAllTransaction_PaymentListByTransaction(long idTransaction);

BaseListReturnType<Transaction_Payment> GetAllTransaction_PaymentListByTransaction(long idTransaction, SubscriptionEntities db);

BaseListReturnType<Transaction_Payment> GetAllTransaction_PaymentListByTransactionByPage(long idTransaction, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<Transaction_Payment> GetAllTransaction_PaymentListByTransactionByPage(long idTransaction, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);




List<Transaction_Payment> GetTransaction_PaymentListByIdList(List<long> transaction_PaymentIds);

List<Transaction_Payment> GetTransaction_PaymentListByIdList(List<long> transaction_PaymentIds, SubscriptionEntities db);

 BaseListReturnType<Transaction_Payment> GetAllTransaction_PaymentWithPaymentDetails(bool shouldRemap = false);
 BaseListReturnType<Transaction_Payment> GetAllTransaction_PaymentWithTransactionDetails(bool shouldRemap = false);
 BaseListReturnType<Transaction_Payment> GetAllTransaction_PaymentWitDetails( List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<Transaction_Payment> GetAllTransaction_PaymentWitDetails( SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 Transaction_Payment GetTransaction_Payment(long idTransaction_Payment,bool shouldRemap = false);
 Transaction_Payment GetTransaction_Payment(long idTransaction_Payment, SubscriptionEntities db,bool shouldRemap = false);
 Transaction_Payment GetTransaction_PaymentWithPaymentDetails(long idTransaction_Payment,bool shouldRemap = false);
    


 Transaction_Payment GetTransaction_PaymentWithTransactionDetails(long idTransaction_Payment,bool shouldRemap = false);
    


 Transaction_Payment GetTransaction_PaymentCustom( Expression<Func<Transaction_Payment, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 Transaction_Payment GetTransaction_PaymentCustom(SubscriptionEntities db, Expression<Func<Transaction_Payment, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<Transaction_Payment> GetTransaction_PaymentCustomList( Expression<Func<Transaction_Payment, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<Transaction_Payment, dynamic> orderExpression = null);
 BaseListReturnType<Transaction_Payment> GetTransaction_PaymentCustomList( SubscriptionEntities db , Expression<Func<Transaction_Payment, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<Transaction_Payment, dynamic> orderExpression = null);
 Transaction_Payment GetTransaction_PaymentWithDetails(long idTransaction_Payment, List<string> includes = null,bool shouldRemap = false);
 Transaction_Payment GetTransaction_PaymentWithDetails(long idTransaction_Payment, SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 Transaction_Payment GetTransaction_PaymentWitDetails(long idTransaction_Payment,bool shouldRemap = false);
 Transaction_Payment GetTransaction_PaymentWitDetails(long idTransaction_Payment, SubscriptionEntities db,bool shouldRemap = false);
 void SaveTransaction_Payment(Transaction_Payment transaction_Payment);
 void SaveTransaction_Payment(Transaction_Payment transaction_Payment, SubscriptionEntities db);
 void SaveOnlyTransaction_Payment(Transaction_Payment transaction_Payment);
 void SaveOnlyTransaction_Payment(Transaction_Payment transaction_Payment, SubscriptionEntities db);
 void DeleteTransaction_Payment(Transaction_Payment transaction_Payment);
 void DeleteTransaction_Payment(Transaction_Payment transaction_Payment, SubscriptionEntities db);		
  void DeletePermanentlyTransaction_Payment(Transaction_Payment transaction_Payment);
 void DeletePermanentlyTransaction_Payment(Transaction_Payment transaction_Payment, SubscriptionEntities db);	
	}
 	public partial interface ITransactionAccountDao
	{
  List<TransactionAccount> GetAllTransactionAccounts(bool shouldRemap = false);
  List<TransactionAccount> GetAllTransactionAccounts(SubscriptionEntities db,bool shouldRemap = false);
  BaseListReturnType<TransactionAccount> GetAllTransactionAccountsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<TransactionAccount, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<TransactionAccount, dynamic> orderExpression = null);
  BaseListReturnType<TransactionAccount> GetAllTransactionAccountsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<TransactionAccount, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<TransactionAccount, dynamic> orderExpression = null);
  
  BaseListReturnType<TransactionAccount> GetAllTransactionAccountsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<TransactionAccount, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<TransactionAccount, dynamic> orderExpression = null);
  BaseListReturnType<TransactionAccount> GetAllTransactionAccountsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<TransactionAccount, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<TransactionAccount, dynamic> orderExpression = null);

 BaseListReturnType<TransactionAccount> GetAllTransactionAccountsWithTransactionPresetsDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<TransactionAccount, bool>> expression = null,bool shouldRemap = false, Func<TransactionAccount, dynamic> orderExpression = null);
 BaseListReturnType<TransactionAccount> GetAllTransactionAccountsWithTransactionPresetsDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<TransactionAccount, bool>> expression = null,bool shouldRemap = false, Func<TransactionAccount, dynamic> orderExpression = null);

 BaseListReturnType<TransactionAccount> GetAllTransactionAccountsWithBanksDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<TransactionAccount, bool>> expression = null,bool shouldRemap = false, Func<TransactionAccount, dynamic> orderExpression = null);
 BaseListReturnType<TransactionAccount> GetAllTransactionAccountsWithBanksDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<TransactionAccount, bool>> expression = null,bool shouldRemap = false, Func<TransactionAccount, dynamic> orderExpression = null);

 BaseListReturnType<TransactionAccount> GetAllTransactionAccountsWithTransactionAccountTypeDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<TransactionAccount, bool>> expression = null,bool shouldRemap = false, Func<TransactionAccount, dynamic> orderExpression = null);
 BaseListReturnType<TransactionAccount> GetAllTransactionAccountsWithTransactionAccountTypeDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<TransactionAccount, bool>> expression = null,bool shouldRemap = false, Func<TransactionAccount, dynamic> orderExpression = null);






BaseListReturnType<TransactionAccount> GetAllTransactionAccountListByTransactionAccountType(long idTransactionAccountType);

BaseListReturnType<TransactionAccount> GetAllTransactionAccountListByTransactionAccountType(long idTransactionAccountType, SubscriptionEntities db);

BaseListReturnType<TransactionAccount> GetAllTransactionAccountListByTransactionAccountTypeByPage(long idTransactionAccountType, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<TransactionAccount> GetAllTransactionAccountListByTransactionAccountTypeByPage(long idTransactionAccountType, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);



 BaseListReturnType<TransactionAccount> GetAllTransactionAccountsWithTransactionsDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<TransactionAccount, bool>> expression = null,bool shouldRemap = false, Func<TransactionAccount, dynamic> orderExpression = null);
 BaseListReturnType<TransactionAccount> GetAllTransactionAccountsWithTransactionsDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<TransactionAccount, bool>> expression = null,bool shouldRemap = false, Func<TransactionAccount, dynamic> orderExpression = null);


List<TransactionAccount> GetTransactionAccountListByIdList(List<long> transactionAccountIds);

List<TransactionAccount> GetTransactionAccountListByIdList(List<long> transactionAccountIds, SubscriptionEntities db);

 BaseListReturnType<TransactionAccount> GetAllTransactionAccountsWithTransactionPresetsDetails(bool shouldRemap = false);
 BaseListReturnType<TransactionAccount> GetAllTransactionAccountsWithBanksDetails(bool shouldRemap = false);
 BaseListReturnType<TransactionAccount> GetAllTransactionAccountsWithTransactionAccountTypeDetails(bool shouldRemap = false);
 BaseListReturnType<TransactionAccount> GetAllTransactionAccountsWithTransactionsDetails(bool shouldRemap = false);
 BaseListReturnType<TransactionAccount> GetAllTransactionAccountWitDetails( List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<TransactionAccount> GetAllTransactionAccountWitDetails( SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 TransactionAccount GetTransactionAccount(long idTransactionAccount,bool shouldRemap = false);
 TransactionAccount GetTransactionAccount(long idTransactionAccount, SubscriptionEntities db,bool shouldRemap = false);
 TransactionAccount GetTransactionAccountWithTransactionPresetsDetails(long idTransactionAccount,bool shouldRemap = false);
           List<TransactionPreset> UpdateTransactionPresetsForTransactionAccountWithoutSavingNewItem(List<TransactionPreset> newTransactionPresets,long idTransactionAccount);
    List<TransactionPreset> UpdateTransactionPresetsForTransactionAccountWithoutSavingNewItem(List<TransactionPreset> newTransactionPresets,long idTransactionAccount,SubscriptionEntities db);
          

    List<TransactionPreset> UpdateTransactionPresetsForTransactionAccount(List<TransactionPreset> newTransactionPresets,long idTransactionAccount);
    List<TransactionPreset> UpdateTransactionPresetsForTransactionAccount(List<TransactionPreset> newTransactionPresets,long idTransactionAccount,SubscriptionEntities db);
                           



 TransactionAccount GetTransactionAccountWithBanksDetails(long idTransactionAccount,bool shouldRemap = false);
           List<Bank> UpdateBanksForTransactionAccountWithoutSavingNewItem(List<Bank> newBanks,long idTransactionAccount);
    List<Bank> UpdateBanksForTransactionAccountWithoutSavingNewItem(List<Bank> newBanks,long idTransactionAccount,SubscriptionEntities db);
          

    List<Bank> UpdateBanksForTransactionAccount(List<Bank> newBanks,long idTransactionAccount);
    List<Bank> UpdateBanksForTransactionAccount(List<Bank> newBanks,long idTransactionAccount,SubscriptionEntities db);
                           



 TransactionAccount GetTransactionAccountWithTransactionAccountTypeDetails(long idTransactionAccount,bool shouldRemap = false);
    


 TransactionAccount GetTransactionAccountWithTransactionsDetails(long idTransactionAccount,bool shouldRemap = false);
           List<Transaction> UpdateTransactionsForTransactionAccountWithoutSavingNewItem(List<Transaction> newTransactions,long idTransactionAccount);
    List<Transaction> UpdateTransactionsForTransactionAccountWithoutSavingNewItem(List<Transaction> newTransactions,long idTransactionAccount,SubscriptionEntities db);
          

    List<Transaction> UpdateTransactionsForTransactionAccount(List<Transaction> newTransactions,long idTransactionAccount);
    List<Transaction> UpdateTransactionsForTransactionAccount(List<Transaction> newTransactions,long idTransactionAccount,SubscriptionEntities db);
                           



 TransactionAccount GetTransactionAccountCustom( Expression<Func<TransactionAccount, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 TransactionAccount GetTransactionAccountCustom(SubscriptionEntities db, Expression<Func<TransactionAccount, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<TransactionAccount> GetTransactionAccountCustomList( Expression<Func<TransactionAccount, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<TransactionAccount, dynamic> orderExpression = null);
 BaseListReturnType<TransactionAccount> GetTransactionAccountCustomList( SubscriptionEntities db , Expression<Func<TransactionAccount, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<TransactionAccount, dynamic> orderExpression = null);
 TransactionAccount GetTransactionAccountWithDetails(long idTransactionAccount, List<string> includes = null,bool shouldRemap = false);
 TransactionAccount GetTransactionAccountWithDetails(long idTransactionAccount, SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 TransactionAccount GetTransactionAccountWitDetails(long idTransactionAccount,bool shouldRemap = false);
 TransactionAccount GetTransactionAccountWitDetails(long idTransactionAccount, SubscriptionEntities db,bool shouldRemap = false);
 void SaveTransactionAccount(TransactionAccount transactionAccount);
 void SaveTransactionAccount(TransactionAccount transactionAccount, SubscriptionEntities db);
 void SaveOnlyTransactionAccount(TransactionAccount transactionAccount);
 void SaveOnlyTransactionAccount(TransactionAccount transactionAccount, SubscriptionEntities db);
 void DeleteTransactionAccount(TransactionAccount transactionAccount);
 void DeleteTransactionAccount(TransactionAccount transactionAccount, SubscriptionEntities db);		
  void DeletePermanentlyTransactionAccount(TransactionAccount transactionAccount);
 void DeletePermanentlyTransactionAccount(TransactionAccount transactionAccount, SubscriptionEntities db);	
	}
 	public partial interface ITransactionAccountTypeDao
	{
  List<TransactionAccountType> GetAllTransactionAccountTypes(bool shouldRemap = false);
  List<TransactionAccountType> GetAllTransactionAccountTypes(SubscriptionEntities db,bool shouldRemap = false);
  BaseListReturnType<TransactionAccountType> GetAllTransactionAccountTypesByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<TransactionAccountType, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<TransactionAccountType, dynamic> orderExpression = null);
  BaseListReturnType<TransactionAccountType> GetAllTransactionAccountTypesByPage(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<TransactionAccountType, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<TransactionAccountType, dynamic> orderExpression = null);
  
  BaseListReturnType<TransactionAccountType> GetAllTransactionAccountTypesByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<TransactionAccountType, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<TransactionAccountType, dynamic> orderExpression = null);
  BaseListReturnType<TransactionAccountType> GetAllTransactionAccountTypesByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<TransactionAccountType, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<TransactionAccountType, dynamic> orderExpression = null);

 BaseListReturnType<TransactionAccountType> GetAllTransactionAccountTypesWithTransactionAccountsDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<TransactionAccountType, bool>> expression = null,bool shouldRemap = false, Func<TransactionAccountType, dynamic> orderExpression = null);
 BaseListReturnType<TransactionAccountType> GetAllTransactionAccountTypesWithTransactionAccountsDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<TransactionAccountType, bool>> expression = null,bool shouldRemap = false, Func<TransactionAccountType, dynamic> orderExpression = null);


List<TransactionAccountType> GetTransactionAccountTypeListByIdList(List<long> transactionAccountTypeIds);

List<TransactionAccountType> GetTransactionAccountTypeListByIdList(List<long> transactionAccountTypeIds, SubscriptionEntities db);

 BaseListReturnType<TransactionAccountType> GetAllTransactionAccountTypesWithTransactionAccountsDetails(bool shouldRemap = false);
 BaseListReturnType<TransactionAccountType> GetAllTransactionAccountTypeWitDetails( List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<TransactionAccountType> GetAllTransactionAccountTypeWitDetails( SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 TransactionAccountType GetTransactionAccountType(long idTransactionAccountType,bool shouldRemap = false);
 TransactionAccountType GetTransactionAccountType(long idTransactionAccountType, SubscriptionEntities db,bool shouldRemap = false);
 TransactionAccountType GetTransactionAccountTypeWithTransactionAccountsDetails(long idTransactionAccountType,bool shouldRemap = false);
           List<TransactionAccount> UpdateTransactionAccountsForTransactionAccountTypeWithoutSavingNewItem(List<TransactionAccount> newTransactionAccounts,long idTransactionAccountType);
    List<TransactionAccount> UpdateTransactionAccountsForTransactionAccountTypeWithoutSavingNewItem(List<TransactionAccount> newTransactionAccounts,long idTransactionAccountType,SubscriptionEntities db);
          

    List<TransactionAccount> UpdateTransactionAccountsForTransactionAccountType(List<TransactionAccount> newTransactionAccounts,long idTransactionAccountType);
    List<TransactionAccount> UpdateTransactionAccountsForTransactionAccountType(List<TransactionAccount> newTransactionAccounts,long idTransactionAccountType,SubscriptionEntities db);
                           



 TransactionAccountType GetTransactionAccountTypeCustom( Expression<Func<TransactionAccountType, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 TransactionAccountType GetTransactionAccountTypeCustom(SubscriptionEntities db, Expression<Func<TransactionAccountType, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<TransactionAccountType> GetTransactionAccountTypeCustomList( Expression<Func<TransactionAccountType, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<TransactionAccountType, dynamic> orderExpression = null);
 BaseListReturnType<TransactionAccountType> GetTransactionAccountTypeCustomList( SubscriptionEntities db , Expression<Func<TransactionAccountType, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<TransactionAccountType, dynamic> orderExpression = null);
 TransactionAccountType GetTransactionAccountTypeWithDetails(long idTransactionAccountType, List<string> includes = null,bool shouldRemap = false);
 TransactionAccountType GetTransactionAccountTypeWithDetails(long idTransactionAccountType, SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 TransactionAccountType GetTransactionAccountTypeWitDetails(long idTransactionAccountType,bool shouldRemap = false);
 TransactionAccountType GetTransactionAccountTypeWitDetails(long idTransactionAccountType, SubscriptionEntities db,bool shouldRemap = false);
 void SaveTransactionAccountType(TransactionAccountType transactionAccountType);
 void SaveTransactionAccountType(TransactionAccountType transactionAccountType, SubscriptionEntities db);
 void SaveOnlyTransactionAccountType(TransactionAccountType transactionAccountType);
 void SaveOnlyTransactionAccountType(TransactionAccountType transactionAccountType, SubscriptionEntities db);
 void DeleteTransactionAccountType(TransactionAccountType transactionAccountType);
 void DeleteTransactionAccountType(TransactionAccountType transactionAccountType, SubscriptionEntities db);		
  void DeletePermanentlyTransactionAccountType(TransactionAccountType transactionAccountType);
 void DeletePermanentlyTransactionAccountType(TransactionAccountType transactionAccountType, SubscriptionEntities db);	
	}
 	public partial interface ITransactionClassDao
	{
  List<TransactionClass> GetAllTransactionClasses(bool shouldRemap = false);
  List<TransactionClass> GetAllTransactionClasses(SubscriptionEntities db,bool shouldRemap = false);
  BaseListReturnType<TransactionClass> GetAllTransactionClassesByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<TransactionClass, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<TransactionClass, dynamic> orderExpression = null);
  BaseListReturnType<TransactionClass> GetAllTransactionClassesByPage(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<TransactionClass, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<TransactionClass, dynamic> orderExpression = null);
  
  BaseListReturnType<TransactionClass> GetAllTransactionClassesByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<TransactionClass, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<TransactionClass, dynamic> orderExpression = null);
  BaseListReturnType<TransactionClass> GetAllTransactionClassesByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<TransactionClass, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<TransactionClass, dynamic> orderExpression = null);

 BaseListReturnType<TransactionClass> GetAllTransactionClassesWithTransactionDetailPresetsDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<TransactionClass, bool>> expression = null,bool shouldRemap = false, Func<TransactionClass, dynamic> orderExpression = null);
 BaseListReturnType<TransactionClass> GetAllTransactionClassesWithTransactionDetailPresetsDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<TransactionClass, bool>> expression = null,bool shouldRemap = false, Func<TransactionClass, dynamic> orderExpression = null);

 BaseListReturnType<TransactionClass> GetAllTransactionClassesWithTransactionPresetsDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<TransactionClass, bool>> expression = null,bool shouldRemap = false, Func<TransactionClass, dynamic> orderExpression = null);
 BaseListReturnType<TransactionClass> GetAllTransactionClassesWithTransactionPresetsDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<TransactionClass, bool>> expression = null,bool shouldRemap = false, Func<TransactionClass, dynamic> orderExpression = null);

 BaseListReturnType<TransactionClass> GetAllTransactionClassesWithTransactionClass1DetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<TransactionClass, bool>> expression = null,bool shouldRemap = false, Func<TransactionClass, dynamic> orderExpression = null);
 BaseListReturnType<TransactionClass> GetAllTransactionClassesWithTransactionClass1DetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<TransactionClass, bool>> expression = null,bool shouldRemap = false, Func<TransactionClass, dynamic> orderExpression = null);

 BaseListReturnType<TransactionClass> GetAllTransactionClassesWithTransactionClass2DetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<TransactionClass, bool>> expression = null,bool shouldRemap = false, Func<TransactionClass, dynamic> orderExpression = null);
 BaseListReturnType<TransactionClass> GetAllTransactionClassesWithTransactionClass2DetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<TransactionClass, bool>> expression = null,bool shouldRemap = false, Func<TransactionClass, dynamic> orderExpression = null);






BaseListReturnType<TransactionClass> GetAllTransactionClassListByTransactionClass2(long idTransactionClass2);

BaseListReturnType<TransactionClass> GetAllTransactionClassListByTransactionClass2(long idTransactionClass2, SubscriptionEntities db);

BaseListReturnType<TransactionClass> GetAllTransactionClassListByTransactionClass2ByPage(long idTransactionClass2, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<TransactionClass> GetAllTransactionClassListByTransactionClass2ByPage(long idTransactionClass2, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);



 BaseListReturnType<TransactionClass> GetAllTransactionClassesWithTransactionDetailsDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<TransactionClass, bool>> expression = null,bool shouldRemap = false, Func<TransactionClass, dynamic> orderExpression = null);
 BaseListReturnType<TransactionClass> GetAllTransactionClassesWithTransactionDetailsDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<TransactionClass, bool>> expression = null,bool shouldRemap = false, Func<TransactionClass, dynamic> orderExpression = null);

 BaseListReturnType<TransactionClass> GetAllTransactionClassesWithTransactionsDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<TransactionClass, bool>> expression = null,bool shouldRemap = false, Func<TransactionClass, dynamic> orderExpression = null);
 BaseListReturnType<TransactionClass> GetAllTransactionClassesWithTransactionsDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<TransactionClass, bool>> expression = null,bool shouldRemap = false, Func<TransactionClass, dynamic> orderExpression = null);


List<TransactionClass> GetTransactionClassListByIdList(List<long> transactionClassIds);

List<TransactionClass> GetTransactionClassListByIdList(List<long> transactionClassIds, SubscriptionEntities db);

 BaseListReturnType<TransactionClass> GetAllTransactionClassesWithTransactionDetailPresetsDetails(bool shouldRemap = false);
 BaseListReturnType<TransactionClass> GetAllTransactionClassesWithTransactionPresetsDetails(bool shouldRemap = false);
 BaseListReturnType<TransactionClass> GetAllTransactionClassesWithTransactionClass1Details(bool shouldRemap = false);
 BaseListReturnType<TransactionClass> GetAllTransactionClassesWithTransactionClass2Details(bool shouldRemap = false);
 BaseListReturnType<TransactionClass> GetAllTransactionClassesWithTransactionDetailsDetails(bool shouldRemap = false);
 BaseListReturnType<TransactionClass> GetAllTransactionClassesWithTransactionsDetails(bool shouldRemap = false);
 BaseListReturnType<TransactionClass> GetAllTransactionClassWitDetails( List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<TransactionClass> GetAllTransactionClassWitDetails( SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 TransactionClass GetTransactionClass(long idTransactionClass,bool shouldRemap = false);
 TransactionClass GetTransactionClass(long idTransactionClass, SubscriptionEntities db,bool shouldRemap = false);
 TransactionClass GetTransactionClassWithTransactionDetailPresetsDetails(long idTransactionClass,bool shouldRemap = false);
           List<TransactionDetailPreset> UpdateTransactionDetailPresetsForTransactionClassWithoutSavingNewItem(List<TransactionDetailPreset> newTransactionDetailPresets,long idTransactionClass);
    List<TransactionDetailPreset> UpdateTransactionDetailPresetsForTransactionClassWithoutSavingNewItem(List<TransactionDetailPreset> newTransactionDetailPresets,long idTransactionClass,SubscriptionEntities db);
          

    List<TransactionDetailPreset> UpdateTransactionDetailPresetsForTransactionClass(List<TransactionDetailPreset> newTransactionDetailPresets,long idTransactionClass);
    List<TransactionDetailPreset> UpdateTransactionDetailPresetsForTransactionClass(List<TransactionDetailPreset> newTransactionDetailPresets,long idTransactionClass,SubscriptionEntities db);
                           



 TransactionClass GetTransactionClassWithTransactionPresetsDetails(long idTransactionClass,bool shouldRemap = false);
           List<TransactionPreset> UpdateTransactionPresetsForTransactionClassWithoutSavingNewItem(List<TransactionPreset> newTransactionPresets,long idTransactionClass);
    List<TransactionPreset> UpdateTransactionPresetsForTransactionClassWithoutSavingNewItem(List<TransactionPreset> newTransactionPresets,long idTransactionClass,SubscriptionEntities db);
          

    List<TransactionPreset> UpdateTransactionPresetsForTransactionClass(List<TransactionPreset> newTransactionPresets,long idTransactionClass);
    List<TransactionPreset> UpdateTransactionPresetsForTransactionClass(List<TransactionPreset> newTransactionPresets,long idTransactionClass,SubscriptionEntities db);
                           



 TransactionClass GetTransactionClassWithTransactionClass1Details(long idTransactionClass,bool shouldRemap = false);
           List<TransactionClass> UpdateTransactionClass1ForTransactionClassWithoutSavingNewItem(List<TransactionClass> newTransactionClass1,long idTransactionClass);
    List<TransactionClass> UpdateTransactionClass1ForTransactionClassWithoutSavingNewItem(List<TransactionClass> newTransactionClass1,long idTransactionClass,SubscriptionEntities db);
          

    List<TransactionClass> UpdateTransactionClass1ForTransactionClass(List<TransactionClass> newTransactionClass1,long idTransactionClass);
    List<TransactionClass> UpdateTransactionClass1ForTransactionClass(List<TransactionClass> newTransactionClass1,long idTransactionClass,SubscriptionEntities db);
                           



 TransactionClass GetTransactionClassWithTransactionClass2Details(long idTransactionClass,bool shouldRemap = false);
    


 TransactionClass GetTransactionClassWithTransactionDetailsDetails(long idTransactionClass,bool shouldRemap = false);
           List<TransactionDetail> UpdateTransactionDetailsForTransactionClassWithoutSavingNewItem(List<TransactionDetail> newTransactionDetails,long idTransactionClass);
    List<TransactionDetail> UpdateTransactionDetailsForTransactionClassWithoutSavingNewItem(List<TransactionDetail> newTransactionDetails,long idTransactionClass,SubscriptionEntities db);
          

    List<TransactionDetail> UpdateTransactionDetailsForTransactionClass(List<TransactionDetail> newTransactionDetails,long idTransactionClass);
    List<TransactionDetail> UpdateTransactionDetailsForTransactionClass(List<TransactionDetail> newTransactionDetails,long idTransactionClass,SubscriptionEntities db);
                           



 TransactionClass GetTransactionClassWithTransactionsDetails(long idTransactionClass,bool shouldRemap = false);
           List<Transaction> UpdateTransactionsForTransactionClassWithoutSavingNewItem(List<Transaction> newTransactions,long idTransactionClass);
    List<Transaction> UpdateTransactionsForTransactionClassWithoutSavingNewItem(List<Transaction> newTransactions,long idTransactionClass,SubscriptionEntities db);
          

    List<Transaction> UpdateTransactionsForTransactionClass(List<Transaction> newTransactions,long idTransactionClass);
    List<Transaction> UpdateTransactionsForTransactionClass(List<Transaction> newTransactions,long idTransactionClass,SubscriptionEntities db);
                           



 TransactionClass GetTransactionClassCustom( Expression<Func<TransactionClass, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 TransactionClass GetTransactionClassCustom(SubscriptionEntities db, Expression<Func<TransactionClass, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<TransactionClass> GetTransactionClassCustomList( Expression<Func<TransactionClass, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<TransactionClass, dynamic> orderExpression = null);
 BaseListReturnType<TransactionClass> GetTransactionClassCustomList( SubscriptionEntities db , Expression<Func<TransactionClass, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<TransactionClass, dynamic> orderExpression = null);
 TransactionClass GetTransactionClassWithDetails(long idTransactionClass, List<string> includes = null,bool shouldRemap = false);
 TransactionClass GetTransactionClassWithDetails(long idTransactionClass, SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 TransactionClass GetTransactionClassWitDetails(long idTransactionClass,bool shouldRemap = false);
 TransactionClass GetTransactionClassWitDetails(long idTransactionClass, SubscriptionEntities db,bool shouldRemap = false);
 void SaveTransactionClass(TransactionClass transactionClass);
 void SaveTransactionClass(TransactionClass transactionClass, SubscriptionEntities db);
 void SaveOnlyTransactionClass(TransactionClass transactionClass);
 void SaveOnlyTransactionClass(TransactionClass transactionClass, SubscriptionEntities db);
 void DeleteTransactionClass(TransactionClass transactionClass);
 void DeleteTransactionClass(TransactionClass transactionClass, SubscriptionEntities db);		
  void DeletePermanentlyTransactionClass(TransactionClass transactionClass);
 void DeletePermanentlyTransactionClass(TransactionClass transactionClass, SubscriptionEntities db);	
	}
 	public partial interface ITransactionDetailDao
	{
  List<TransactionDetail> GetAllTransactionDetails(bool shouldRemap = false);
  List<TransactionDetail> GetAllTransactionDetails(SubscriptionEntities db,bool shouldRemap = false);
  BaseListReturnType<TransactionDetail> GetAllTransactionDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<TransactionDetail, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<TransactionDetail, dynamic> orderExpression = null);
  BaseListReturnType<TransactionDetail> GetAllTransactionDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<TransactionDetail, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<TransactionDetail, dynamic> orderExpression = null);
  
  BaseListReturnType<TransactionDetail> GetAllTransactionDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<TransactionDetail, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<TransactionDetail, dynamic> orderExpression = null);
  BaseListReturnType<TransactionDetail> GetAllTransactionDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<TransactionDetail, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<TransactionDetail, dynamic> orderExpression = null);

 BaseListReturnType<TransactionDetail> GetAllTransactionDetailsWithProductDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<TransactionDetail, bool>> expression = null,bool shouldRemap = false, Func<TransactionDetail, dynamic> orderExpression = null);
 BaseListReturnType<TransactionDetail> GetAllTransactionDetailsWithProductDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<TransactionDetail, bool>> expression = null,bool shouldRemap = false, Func<TransactionDetail, dynamic> orderExpression = null);






BaseListReturnType<TransactionDetail> GetAllTransactionDetailListByProduct(long idProduct);

BaseListReturnType<TransactionDetail> GetAllTransactionDetailListByProduct(long idProduct, SubscriptionEntities db);

BaseListReturnType<TransactionDetail> GetAllTransactionDetailListByProductByPage(long idProduct, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<TransactionDetail> GetAllTransactionDetailListByProductByPage(long idProduct, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);



 BaseListReturnType<TransactionDetail> GetAllTransactionDetailsWithTransactionDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<TransactionDetail, bool>> expression = null,bool shouldRemap = false, Func<TransactionDetail, dynamic> orderExpression = null);
 BaseListReturnType<TransactionDetail> GetAllTransactionDetailsWithTransactionDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<TransactionDetail, bool>> expression = null,bool shouldRemap = false, Func<TransactionDetail, dynamic> orderExpression = null);






BaseListReturnType<TransactionDetail> GetAllTransactionDetailListByTransaction(long idTransaction);

BaseListReturnType<TransactionDetail> GetAllTransactionDetailListByTransaction(long idTransaction, SubscriptionEntities db);

BaseListReturnType<TransactionDetail> GetAllTransactionDetailListByTransactionByPage(long idTransaction, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<TransactionDetail> GetAllTransactionDetailListByTransactionByPage(long idTransaction, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);



 BaseListReturnType<TransactionDetail> GetAllTransactionDetailsWithTransactionClassDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<TransactionDetail, bool>> expression = null,bool shouldRemap = false, Func<TransactionDetail, dynamic> orderExpression = null);
 BaseListReturnType<TransactionDetail> GetAllTransactionDetailsWithTransactionClassDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<TransactionDetail, bool>> expression = null,bool shouldRemap = false, Func<TransactionDetail, dynamic> orderExpression = null);






BaseListReturnType<TransactionDetail> GetAllTransactionDetailListByTransactionClass(long idTransactionClass);

BaseListReturnType<TransactionDetail> GetAllTransactionDetailListByTransactionClass(long idTransactionClass, SubscriptionEntities db);

BaseListReturnType<TransactionDetail> GetAllTransactionDetailListByTransactionClassByPage(long idTransactionClass, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<TransactionDetail> GetAllTransactionDetailListByTransactionClassByPage(long idTransactionClass, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);




List<TransactionDetail> GetTransactionDetailListByIdList(List<long> transactionDetailIds);

List<TransactionDetail> GetTransactionDetailListByIdList(List<long> transactionDetailIds, SubscriptionEntities db);

 BaseListReturnType<TransactionDetail> GetAllTransactionDetailsWithProductDetails(bool shouldRemap = false);
 BaseListReturnType<TransactionDetail> GetAllTransactionDetailsWithTransactionDetails(bool shouldRemap = false);
 BaseListReturnType<TransactionDetail> GetAllTransactionDetailsWithTransactionClassDetails(bool shouldRemap = false);
 BaseListReturnType<TransactionDetail> GetAllTransactionDetailWitDetails( List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<TransactionDetail> GetAllTransactionDetailWitDetails( SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 TransactionDetail GetTransactionDetail(long idTransactionDetail,bool shouldRemap = false);
 TransactionDetail GetTransactionDetail(long idTransactionDetail, SubscriptionEntities db,bool shouldRemap = false);
 TransactionDetail GetTransactionDetailWithProductDetails(long idTransactionDetail,bool shouldRemap = false);
    


 TransactionDetail GetTransactionDetailWithTransactionDetails(long idTransactionDetail,bool shouldRemap = false);
    


 TransactionDetail GetTransactionDetailWithTransactionClassDetails(long idTransactionDetail,bool shouldRemap = false);
    


 TransactionDetail GetTransactionDetailCustom( Expression<Func<TransactionDetail, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 TransactionDetail GetTransactionDetailCustom(SubscriptionEntities db, Expression<Func<TransactionDetail, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<TransactionDetail> GetTransactionDetailCustomList( Expression<Func<TransactionDetail, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<TransactionDetail, dynamic> orderExpression = null);
 BaseListReturnType<TransactionDetail> GetTransactionDetailCustomList( SubscriptionEntities db , Expression<Func<TransactionDetail, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<TransactionDetail, dynamic> orderExpression = null);
 TransactionDetail GetTransactionDetailWithDetails(long idTransactionDetail, List<string> includes = null,bool shouldRemap = false);
 TransactionDetail GetTransactionDetailWithDetails(long idTransactionDetail, SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 TransactionDetail GetTransactionDetailWitDetails(long idTransactionDetail,bool shouldRemap = false);
 TransactionDetail GetTransactionDetailWitDetails(long idTransactionDetail, SubscriptionEntities db,bool shouldRemap = false);
 void SaveTransactionDetail(TransactionDetail transactionDetail);
 void SaveTransactionDetail(TransactionDetail transactionDetail, SubscriptionEntities db);
 void SaveOnlyTransactionDetail(TransactionDetail transactionDetail);
 void SaveOnlyTransactionDetail(TransactionDetail transactionDetail, SubscriptionEntities db);
 void DeleteTransactionDetail(TransactionDetail transactionDetail);
 void DeleteTransactionDetail(TransactionDetail transactionDetail, SubscriptionEntities db);		
  void DeletePermanentlyTransactionDetail(TransactionDetail transactionDetail);
 void DeletePermanentlyTransactionDetail(TransactionDetail transactionDetail, SubscriptionEntities db);	
	}
 	public partial interface ITransactionDetailPresetDao
	{
  List<TransactionDetailPreset> GetAllTransactionDetailPresets(bool shouldRemap = false);
  List<TransactionDetailPreset> GetAllTransactionDetailPresets(SubscriptionEntities db,bool shouldRemap = false);
  BaseListReturnType<TransactionDetailPreset> GetAllTransactionDetailPresetsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<TransactionDetailPreset, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<TransactionDetailPreset, dynamic> orderExpression = null);
  BaseListReturnType<TransactionDetailPreset> GetAllTransactionDetailPresetsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<TransactionDetailPreset, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<TransactionDetailPreset, dynamic> orderExpression = null);
  
  BaseListReturnType<TransactionDetailPreset> GetAllTransactionDetailPresetsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<TransactionDetailPreset, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<TransactionDetailPreset, dynamic> orderExpression = null);
  BaseListReturnType<TransactionDetailPreset> GetAllTransactionDetailPresetsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<TransactionDetailPreset, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<TransactionDetailPreset, dynamic> orderExpression = null);

 BaseListReturnType<TransactionDetailPreset> GetAllTransactionDetailPresetsWithProductDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<TransactionDetailPreset, bool>> expression = null,bool shouldRemap = false, Func<TransactionDetailPreset, dynamic> orderExpression = null);
 BaseListReturnType<TransactionDetailPreset> GetAllTransactionDetailPresetsWithProductDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<TransactionDetailPreset, bool>> expression = null,bool shouldRemap = false, Func<TransactionDetailPreset, dynamic> orderExpression = null);






BaseListReturnType<TransactionDetailPreset> GetAllTransactionDetailPresetListByProduct(long idProduct);

BaseListReturnType<TransactionDetailPreset> GetAllTransactionDetailPresetListByProduct(long idProduct, SubscriptionEntities db);

BaseListReturnType<TransactionDetailPreset> GetAllTransactionDetailPresetListByProductByPage(long idProduct, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<TransactionDetailPreset> GetAllTransactionDetailPresetListByProductByPage(long idProduct, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);



 BaseListReturnType<TransactionDetailPreset> GetAllTransactionDetailPresetsWithTransactionPresetDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<TransactionDetailPreset, bool>> expression = null,bool shouldRemap = false, Func<TransactionDetailPreset, dynamic> orderExpression = null);
 BaseListReturnType<TransactionDetailPreset> GetAllTransactionDetailPresetsWithTransactionPresetDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<TransactionDetailPreset, bool>> expression = null,bool shouldRemap = false, Func<TransactionDetailPreset, dynamic> orderExpression = null);






BaseListReturnType<TransactionDetailPreset> GetAllTransactionDetailPresetListByTransactionPreset(long idTransactionPreset);

BaseListReturnType<TransactionDetailPreset> GetAllTransactionDetailPresetListByTransactionPreset(long idTransactionPreset, SubscriptionEntities db);

BaseListReturnType<TransactionDetailPreset> GetAllTransactionDetailPresetListByTransactionPresetByPage(long idTransactionPreset, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<TransactionDetailPreset> GetAllTransactionDetailPresetListByTransactionPresetByPage(long idTransactionPreset, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);



 BaseListReturnType<TransactionDetailPreset> GetAllTransactionDetailPresetsWithTransactionClassDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<TransactionDetailPreset, bool>> expression = null,bool shouldRemap = false, Func<TransactionDetailPreset, dynamic> orderExpression = null);
 BaseListReturnType<TransactionDetailPreset> GetAllTransactionDetailPresetsWithTransactionClassDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<TransactionDetailPreset, bool>> expression = null,bool shouldRemap = false, Func<TransactionDetailPreset, dynamic> orderExpression = null);






BaseListReturnType<TransactionDetailPreset> GetAllTransactionDetailPresetListByTransactionClass(long idTransactionClass);

BaseListReturnType<TransactionDetailPreset> GetAllTransactionDetailPresetListByTransactionClass(long idTransactionClass, SubscriptionEntities db);

BaseListReturnType<TransactionDetailPreset> GetAllTransactionDetailPresetListByTransactionClassByPage(long idTransactionClass, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<TransactionDetailPreset> GetAllTransactionDetailPresetListByTransactionClassByPage(long idTransactionClass, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);




List<TransactionDetailPreset> GetTransactionDetailPresetListByIdList(List<long> transactionDetailPresetIds);

List<TransactionDetailPreset> GetTransactionDetailPresetListByIdList(List<long> transactionDetailPresetIds, SubscriptionEntities db);

 BaseListReturnType<TransactionDetailPreset> GetAllTransactionDetailPresetsWithProductDetails(bool shouldRemap = false);
 BaseListReturnType<TransactionDetailPreset> GetAllTransactionDetailPresetsWithTransactionPresetDetails(bool shouldRemap = false);
 BaseListReturnType<TransactionDetailPreset> GetAllTransactionDetailPresetsWithTransactionClassDetails(bool shouldRemap = false);
 BaseListReturnType<TransactionDetailPreset> GetAllTransactionDetailPresetWitDetails( List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<TransactionDetailPreset> GetAllTransactionDetailPresetWitDetails( SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 TransactionDetailPreset GetTransactionDetailPreset(long idTransactionDetailPreset,bool shouldRemap = false);
 TransactionDetailPreset GetTransactionDetailPreset(long idTransactionDetailPreset, SubscriptionEntities db,bool shouldRemap = false);
 TransactionDetailPreset GetTransactionDetailPresetWithProductDetails(long idTransactionDetailPreset,bool shouldRemap = false);
    


 TransactionDetailPreset GetTransactionDetailPresetWithTransactionPresetDetails(long idTransactionDetailPreset,bool shouldRemap = false);
    


 TransactionDetailPreset GetTransactionDetailPresetWithTransactionClassDetails(long idTransactionDetailPreset,bool shouldRemap = false);
    


 TransactionDetailPreset GetTransactionDetailPresetCustom( Expression<Func<TransactionDetailPreset, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 TransactionDetailPreset GetTransactionDetailPresetCustom(SubscriptionEntities db, Expression<Func<TransactionDetailPreset, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<TransactionDetailPreset> GetTransactionDetailPresetCustomList( Expression<Func<TransactionDetailPreset, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<TransactionDetailPreset, dynamic> orderExpression = null);
 BaseListReturnType<TransactionDetailPreset> GetTransactionDetailPresetCustomList( SubscriptionEntities db , Expression<Func<TransactionDetailPreset, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<TransactionDetailPreset, dynamic> orderExpression = null);
 TransactionDetailPreset GetTransactionDetailPresetWithDetails(long idTransactionDetailPreset, List<string> includes = null,bool shouldRemap = false);
 TransactionDetailPreset GetTransactionDetailPresetWithDetails(long idTransactionDetailPreset, SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 TransactionDetailPreset GetTransactionDetailPresetWitDetails(long idTransactionDetailPreset,bool shouldRemap = false);
 TransactionDetailPreset GetTransactionDetailPresetWitDetails(long idTransactionDetailPreset, SubscriptionEntities db,bool shouldRemap = false);
 void SaveTransactionDetailPreset(TransactionDetailPreset transactionDetailPreset);
 void SaveTransactionDetailPreset(TransactionDetailPreset transactionDetailPreset, SubscriptionEntities db);
 void SaveOnlyTransactionDetailPreset(TransactionDetailPreset transactionDetailPreset);
 void SaveOnlyTransactionDetailPreset(TransactionDetailPreset transactionDetailPreset, SubscriptionEntities db);
 void DeleteTransactionDetailPreset(TransactionDetailPreset transactionDetailPreset);
 void DeleteTransactionDetailPreset(TransactionDetailPreset transactionDetailPreset, SubscriptionEntities db);		
  void DeletePermanentlyTransactionDetailPreset(TransactionDetailPreset transactionDetailPreset);
 void DeletePermanentlyTransactionDetailPreset(TransactionDetailPreset transactionDetailPreset, SubscriptionEntities db);	
	}
 	public partial interface ITransactionDueDao
	{
  List<TransactionDue> GetAllTransactionDues(bool shouldRemap = false);
  List<TransactionDue> GetAllTransactionDues(SubscriptionEntities db,bool shouldRemap = false);
  BaseListReturnType<TransactionDue> GetAllTransactionDuesByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<TransactionDue, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<TransactionDue, dynamic> orderExpression = null);
  BaseListReturnType<TransactionDue> GetAllTransactionDuesByPage(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<TransactionDue, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<TransactionDue, dynamic> orderExpression = null);
  
  BaseListReturnType<TransactionDue> GetAllTransactionDuesByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<TransactionDue, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<TransactionDue, dynamic> orderExpression = null);
  BaseListReturnType<TransactionDue> GetAllTransactionDuesByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<TransactionDue, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<TransactionDue, dynamic> orderExpression = null);

 BaseListReturnType<TransactionDue> GetAllTransactionDuesWithTransactionDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<TransactionDue, bool>> expression = null,bool shouldRemap = false, Func<TransactionDue, dynamic> orderExpression = null);
 BaseListReturnType<TransactionDue> GetAllTransactionDuesWithTransactionDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<TransactionDue, bool>> expression = null,bool shouldRemap = false, Func<TransactionDue, dynamic> orderExpression = null);






BaseListReturnType<TransactionDue> GetAllTransactionDueListByTransaction(long idTransaction);

BaseListReturnType<TransactionDue> GetAllTransactionDueListByTransaction(long idTransaction, SubscriptionEntities db);

BaseListReturnType<TransactionDue> GetAllTransactionDueListByTransactionByPage(long idTransaction, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<TransactionDue> GetAllTransactionDueListByTransactionByPage(long idTransaction, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);



 BaseListReturnType<TransactionDue> GetAllTransactionDuesWithTransactionDue_TransactionDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<TransactionDue, bool>> expression = null,bool shouldRemap = false, Func<TransactionDue, dynamic> orderExpression = null);
 BaseListReturnType<TransactionDue> GetAllTransactionDuesWithTransactionDue_TransactionDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<TransactionDue, bool>> expression = null,bool shouldRemap = false, Func<TransactionDue, dynamic> orderExpression = null);


List<TransactionDue> GetTransactionDueListByIdList(List<long> transactionDueIds);

List<TransactionDue> GetTransactionDueListByIdList(List<long> transactionDueIds, SubscriptionEntities db);

 BaseListReturnType<TransactionDue> GetAllTransactionDuesWithTransactionDetails(bool shouldRemap = false);
 BaseListReturnType<TransactionDue> GetAllTransactionDuesWithTransactionDue_TransactionDetails(bool shouldRemap = false);
 BaseListReturnType<TransactionDue> GetAllTransactionDueWitDetails( List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<TransactionDue> GetAllTransactionDueWitDetails( SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 TransactionDue GetTransactionDue(long idTransactionDue,bool shouldRemap = false);
 TransactionDue GetTransactionDue(long idTransactionDue, SubscriptionEntities db,bool shouldRemap = false);
 TransactionDue GetTransactionDueWithTransactionDetails(long idTransactionDue,bool shouldRemap = false);
    


 TransactionDue GetTransactionDueWithTransactionDue_TransactionDetails(long idTransactionDue,bool shouldRemap = false);
           List<TransactionDue_Transaction> UpdateTransactionDue_TransactionForTransactionDueWithoutSavingNewItem(List<TransactionDue_Transaction> newTransactionDue_Transaction,long idTransactionDue);
    List<TransactionDue_Transaction> UpdateTransactionDue_TransactionForTransactionDueWithoutSavingNewItem(List<TransactionDue_Transaction> newTransactionDue_Transaction,long idTransactionDue,SubscriptionEntities db);
          

    List<TransactionDue_Transaction> UpdateTransactionDue_TransactionForTransactionDue(List<TransactionDue_Transaction> newTransactionDue_Transaction,long idTransactionDue);
    List<TransactionDue_Transaction> UpdateTransactionDue_TransactionForTransactionDue(List<TransactionDue_Transaction> newTransactionDue_Transaction,long idTransactionDue,SubscriptionEntities db);
                           



 TransactionDue GetTransactionDueCustom( Expression<Func<TransactionDue, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 TransactionDue GetTransactionDueCustom(SubscriptionEntities db, Expression<Func<TransactionDue, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<TransactionDue> GetTransactionDueCustomList( Expression<Func<TransactionDue, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<TransactionDue, dynamic> orderExpression = null);
 BaseListReturnType<TransactionDue> GetTransactionDueCustomList( SubscriptionEntities db , Expression<Func<TransactionDue, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<TransactionDue, dynamic> orderExpression = null);
 TransactionDue GetTransactionDueWithDetails(long idTransactionDue, List<string> includes = null,bool shouldRemap = false);
 TransactionDue GetTransactionDueWithDetails(long idTransactionDue, SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 TransactionDue GetTransactionDueWitDetails(long idTransactionDue,bool shouldRemap = false);
 TransactionDue GetTransactionDueWitDetails(long idTransactionDue, SubscriptionEntities db,bool shouldRemap = false);
 void SaveTransactionDue(TransactionDue transactionDue);
 void SaveTransactionDue(TransactionDue transactionDue, SubscriptionEntities db);
 void SaveOnlyTransactionDue(TransactionDue transactionDue);
 void SaveOnlyTransactionDue(TransactionDue transactionDue, SubscriptionEntities db);
 void DeleteTransactionDue(TransactionDue transactionDue);
 void DeleteTransactionDue(TransactionDue transactionDue, SubscriptionEntities db);		
  void DeletePermanentlyTransactionDue(TransactionDue transactionDue);
 void DeletePermanentlyTransactionDue(TransactionDue transactionDue, SubscriptionEntities db);	
	}
 	public partial interface ITransactionDue_TransactionDao
	{
  List<TransactionDue_Transaction> GetAllTransactionDue_Transaction(bool shouldRemap = false);
  List<TransactionDue_Transaction> GetAllTransactionDue_Transaction(SubscriptionEntities db,bool shouldRemap = false);
  BaseListReturnType<TransactionDue_Transaction> GetAllTransactionDue_TransactionByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<TransactionDue_Transaction, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<TransactionDue_Transaction, dynamic> orderExpression = null);
  BaseListReturnType<TransactionDue_Transaction> GetAllTransactionDue_TransactionByPage(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<TransactionDue_Transaction, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<TransactionDue_Transaction, dynamic> orderExpression = null);
  
  BaseListReturnType<TransactionDue_Transaction> GetAllTransactionDue_TransactionByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<TransactionDue_Transaction, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<TransactionDue_Transaction, dynamic> orderExpression = null);
  BaseListReturnType<TransactionDue_Transaction> GetAllTransactionDue_TransactionByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<TransactionDue_Transaction, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<TransactionDue_Transaction, dynamic> orderExpression = null);

 BaseListReturnType<TransactionDue_Transaction> GetAllTransactionDue_TransactionWithTransactionDueDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<TransactionDue_Transaction, bool>> expression = null,bool shouldRemap = false, Func<TransactionDue_Transaction, dynamic> orderExpression = null);
 BaseListReturnType<TransactionDue_Transaction> GetAllTransactionDue_TransactionWithTransactionDueDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<TransactionDue_Transaction, bool>> expression = null,bool shouldRemap = false, Func<TransactionDue_Transaction, dynamic> orderExpression = null);






BaseListReturnType<TransactionDue_Transaction> GetAllTransactionDue_TransactionListByTransactionDue(long idTransactionDue);

BaseListReturnType<TransactionDue_Transaction> GetAllTransactionDue_TransactionListByTransactionDue(long idTransactionDue, SubscriptionEntities db);

BaseListReturnType<TransactionDue_Transaction> GetAllTransactionDue_TransactionListByTransactionDueByPage(long idTransactionDue, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<TransactionDue_Transaction> GetAllTransactionDue_TransactionListByTransactionDueByPage(long idTransactionDue, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);



 BaseListReturnType<TransactionDue_Transaction> GetAllTransactionDue_TransactionWithTransactionDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<TransactionDue_Transaction, bool>> expression = null,bool shouldRemap = false, Func<TransactionDue_Transaction, dynamic> orderExpression = null);
 BaseListReturnType<TransactionDue_Transaction> GetAllTransactionDue_TransactionWithTransactionDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<TransactionDue_Transaction, bool>> expression = null,bool shouldRemap = false, Func<TransactionDue_Transaction, dynamic> orderExpression = null);






BaseListReturnType<TransactionDue_Transaction> GetAllTransactionDue_TransactionListByTransaction(long idTransaction);

BaseListReturnType<TransactionDue_Transaction> GetAllTransactionDue_TransactionListByTransaction(long idTransaction, SubscriptionEntities db);

BaseListReturnType<TransactionDue_Transaction> GetAllTransactionDue_TransactionListByTransactionByPage(long idTransaction, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<TransactionDue_Transaction> GetAllTransactionDue_TransactionListByTransactionByPage(long idTransaction, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);




List<TransactionDue_Transaction> GetTransactionDue_TransactionListByIdList(List<long> transactionDue_TransactionIds);

List<TransactionDue_Transaction> GetTransactionDue_TransactionListByIdList(List<long> transactionDue_TransactionIds, SubscriptionEntities db);

 BaseListReturnType<TransactionDue_Transaction> GetAllTransactionDue_TransactionWithTransactionDueDetails(bool shouldRemap = false);
 BaseListReturnType<TransactionDue_Transaction> GetAllTransactionDue_TransactionWithTransactionDetails(bool shouldRemap = false);
 BaseListReturnType<TransactionDue_Transaction> GetAllTransactionDue_TransactionWitDetails( List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<TransactionDue_Transaction> GetAllTransactionDue_TransactionWitDetails( SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 TransactionDue_Transaction GetTransactionDue_Transaction(long idTransactionDue_Transaction,bool shouldRemap = false);
 TransactionDue_Transaction GetTransactionDue_Transaction(long idTransactionDue_Transaction, SubscriptionEntities db,bool shouldRemap = false);
 TransactionDue_Transaction GetTransactionDue_TransactionWithTransactionDueDetails(long idTransactionDue_Transaction,bool shouldRemap = false);
    


 TransactionDue_Transaction GetTransactionDue_TransactionWithTransactionDetails(long idTransactionDue_Transaction,bool shouldRemap = false);
    


 TransactionDue_Transaction GetTransactionDue_TransactionCustom( Expression<Func<TransactionDue_Transaction, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 TransactionDue_Transaction GetTransactionDue_TransactionCustom(SubscriptionEntities db, Expression<Func<TransactionDue_Transaction, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<TransactionDue_Transaction> GetTransactionDue_TransactionCustomList( Expression<Func<TransactionDue_Transaction, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<TransactionDue_Transaction, dynamic> orderExpression = null);
 BaseListReturnType<TransactionDue_Transaction> GetTransactionDue_TransactionCustomList( SubscriptionEntities db , Expression<Func<TransactionDue_Transaction, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<TransactionDue_Transaction, dynamic> orderExpression = null);
 TransactionDue_Transaction GetTransactionDue_TransactionWithDetails(long idTransactionDue_Transaction, List<string> includes = null,bool shouldRemap = false);
 TransactionDue_Transaction GetTransactionDue_TransactionWithDetails(long idTransactionDue_Transaction, SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 TransactionDue_Transaction GetTransactionDue_TransactionWitDetails(long idTransactionDue_Transaction,bool shouldRemap = false);
 TransactionDue_Transaction GetTransactionDue_TransactionWitDetails(long idTransactionDue_Transaction, SubscriptionEntities db,bool shouldRemap = false);
 void SaveTransactionDue_Transaction(TransactionDue_Transaction transactionDue_Transaction);
 void SaveTransactionDue_Transaction(TransactionDue_Transaction transactionDue_Transaction, SubscriptionEntities db);
 void SaveOnlyTransactionDue_Transaction(TransactionDue_Transaction transactionDue_Transaction);
 void SaveOnlyTransactionDue_Transaction(TransactionDue_Transaction transactionDue_Transaction, SubscriptionEntities db);
 void DeleteTransactionDue_Transaction(TransactionDue_Transaction transactionDue_Transaction);
 void DeleteTransactionDue_Transaction(TransactionDue_Transaction transactionDue_Transaction, SubscriptionEntities db);		
  void DeletePermanentlyTransactionDue_Transaction(TransactionDue_Transaction transactionDue_Transaction);
 void DeletePermanentlyTransactionDue_Transaction(TransactionDue_Transaction transactionDue_Transaction, SubscriptionEntities db);	
	}
 	public partial interface ITransactionPresetDao
	{
  List<TransactionPreset> GetAllTransactionPresets(bool shouldRemap = false);
  List<TransactionPreset> GetAllTransactionPresets(SubscriptionEntities db,bool shouldRemap = false);
  BaseListReturnType<TransactionPreset> GetAllTransactionPresetsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<TransactionPreset, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<TransactionPreset, dynamic> orderExpression = null);
  BaseListReturnType<TransactionPreset> GetAllTransactionPresetsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<TransactionPreset, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<TransactionPreset, dynamic> orderExpression = null);
  
  BaseListReturnType<TransactionPreset> GetAllTransactionPresetsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<TransactionPreset, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<TransactionPreset, dynamic> orderExpression = null);
  BaseListReturnType<TransactionPreset> GetAllTransactionPresetsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<TransactionPreset, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<TransactionPreset, dynamic> orderExpression = null);

 BaseListReturnType<TransactionPreset> GetAllTransactionPresetsWithBankStatementHitList_TransactionPresetDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<TransactionPreset, bool>> expression = null,bool shouldRemap = false, Func<TransactionPreset, dynamic> orderExpression = null);
 BaseListReturnType<TransactionPreset> GetAllTransactionPresetsWithBankStatementHitList_TransactionPresetDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<TransactionPreset, bool>> expression = null,bool shouldRemap = false, Func<TransactionPreset, dynamic> orderExpression = null);

 BaseListReturnType<TransactionPreset> GetAllTransactionPresetsWithBankStatementStagingHit_TransactionPresetDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<TransactionPreset, bool>> expression = null,bool shouldRemap = false, Func<TransactionPreset, dynamic> orderExpression = null);
 BaseListReturnType<TransactionPreset> GetAllTransactionPresetsWithBankStatementStagingHit_TransactionPresetDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<TransactionPreset, bool>> expression = null,bool shouldRemap = false, Func<TransactionPreset, dynamic> orderExpression = null);

 BaseListReturnType<TransactionPreset> GetAllTransactionPresetsWithTransactionDetailPresetsDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<TransactionPreset, bool>> expression = null,bool shouldRemap = false, Func<TransactionPreset, dynamic> orderExpression = null);
 BaseListReturnType<TransactionPreset> GetAllTransactionPresetsWithTransactionDetailPresetsDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<TransactionPreset, bool>> expression = null,bool shouldRemap = false, Func<TransactionPreset, dynamic> orderExpression = null);

 BaseListReturnType<TransactionPreset> GetAllTransactionPresetsWithCustomerDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<TransactionPreset, bool>> expression = null,bool shouldRemap = false, Func<TransactionPreset, dynamic> orderExpression = null);
 BaseListReturnType<TransactionPreset> GetAllTransactionPresetsWithCustomerDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<TransactionPreset, bool>> expression = null,bool shouldRemap = false, Func<TransactionPreset, dynamic> orderExpression = null);






BaseListReturnType<TransactionPreset> GetAllTransactionPresetListByCustomer(long idCustomer);

BaseListReturnType<TransactionPreset> GetAllTransactionPresetListByCustomer(long idCustomer, SubscriptionEntities db);

BaseListReturnType<TransactionPreset> GetAllTransactionPresetListByCustomerByPage(long idCustomer, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<TransactionPreset> GetAllTransactionPresetListByCustomerByPage(long idCustomer, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);



 BaseListReturnType<TransactionPreset> GetAllTransactionPresetsWithTransactionAccountDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<TransactionPreset, bool>> expression = null,bool shouldRemap = false, Func<TransactionPreset, dynamic> orderExpression = null);
 BaseListReturnType<TransactionPreset> GetAllTransactionPresetsWithTransactionAccountDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<TransactionPreset, bool>> expression = null,bool shouldRemap = false, Func<TransactionPreset, dynamic> orderExpression = null);






BaseListReturnType<TransactionPreset> GetAllTransactionPresetListByTransactionAccount(long idTransactionAccount);

BaseListReturnType<TransactionPreset> GetAllTransactionPresetListByTransactionAccount(long idTransactionAccount, SubscriptionEntities db);

BaseListReturnType<TransactionPreset> GetAllTransactionPresetListByTransactionAccountByPage(long idTransactionAccount, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<TransactionPreset> GetAllTransactionPresetListByTransactionAccountByPage(long idTransactionAccount, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);



 BaseListReturnType<TransactionPreset> GetAllTransactionPresetsWithTransactionClassDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<TransactionPreset, bool>> expression = null,bool shouldRemap = false, Func<TransactionPreset, dynamic> orderExpression = null);
 BaseListReturnType<TransactionPreset> GetAllTransactionPresetsWithTransactionClassDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<TransactionPreset, bool>> expression = null,bool shouldRemap = false, Func<TransactionPreset, dynamic> orderExpression = null);






BaseListReturnType<TransactionPreset> GetAllTransactionPresetListByTransactionClass(long idTransactionClass);

BaseListReturnType<TransactionPreset> GetAllTransactionPresetListByTransactionClass(long idTransactionClass, SubscriptionEntities db);

BaseListReturnType<TransactionPreset> GetAllTransactionPresetListByTransactionClassByPage(long idTransactionClass, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<TransactionPreset> GetAllTransactionPresetListByTransactionClassByPage(long idTransactionClass, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);



 BaseListReturnType<TransactionPreset> GetAllTransactionPresetsWithTransactionTemplateDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<TransactionPreset, bool>> expression = null,bool shouldRemap = false, Func<TransactionPreset, dynamic> orderExpression = null);
 BaseListReturnType<TransactionPreset> GetAllTransactionPresetsWithTransactionTemplateDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<TransactionPreset, bool>> expression = null,bool shouldRemap = false, Func<TransactionPreset, dynamic> orderExpression = null);






BaseListReturnType<TransactionPreset> GetAllTransactionPresetListByTransactionTemplate(long idTransactionTemplate);

BaseListReturnType<TransactionPreset> GetAllTransactionPresetListByTransactionTemplate(long idTransactionTemplate, SubscriptionEntities db);

BaseListReturnType<TransactionPreset> GetAllTransactionPresetListByTransactionTemplateByPage(long idTransactionTemplate, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<TransactionPreset> GetAllTransactionPresetListByTransactionTemplateByPage(long idTransactionTemplate, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);



 BaseListReturnType<TransactionPreset> GetAllTransactionPresetsWithTransactionTypeDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<TransactionPreset, bool>> expression = null,bool shouldRemap = false, Func<TransactionPreset, dynamic> orderExpression = null);
 BaseListReturnType<TransactionPreset> GetAllTransactionPresetsWithTransactionTypeDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<TransactionPreset, bool>> expression = null,bool shouldRemap = false, Func<TransactionPreset, dynamic> orderExpression = null);






BaseListReturnType<TransactionPreset> GetAllTransactionPresetListByTransactionType(long idTransactionType);

BaseListReturnType<TransactionPreset> GetAllTransactionPresetListByTransactionType(long idTransactionType, SubscriptionEntities db);

BaseListReturnType<TransactionPreset> GetAllTransactionPresetListByTransactionTypeByPage(long idTransactionType, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<TransactionPreset> GetAllTransactionPresetListByTransactionTypeByPage(long idTransactionType, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);




List<TransactionPreset> GetTransactionPresetListByIdList(List<long> transactionPresetIds);

List<TransactionPreset> GetTransactionPresetListByIdList(List<long> transactionPresetIds, SubscriptionEntities db);

 BaseListReturnType<TransactionPreset> GetAllTransactionPresetsWithBankStatementHitList_TransactionPresetDetails(bool shouldRemap = false);
 BaseListReturnType<TransactionPreset> GetAllTransactionPresetsWithBankStatementStagingHit_TransactionPresetDetails(bool shouldRemap = false);
 BaseListReturnType<TransactionPreset> GetAllTransactionPresetsWithTransactionDetailPresetsDetails(bool shouldRemap = false);
 BaseListReturnType<TransactionPreset> GetAllTransactionPresetsWithCustomerDetails(bool shouldRemap = false);
 BaseListReturnType<TransactionPreset> GetAllTransactionPresetsWithTransactionAccountDetails(bool shouldRemap = false);
 BaseListReturnType<TransactionPreset> GetAllTransactionPresetsWithTransactionClassDetails(bool shouldRemap = false);
 BaseListReturnType<TransactionPreset> GetAllTransactionPresetsWithTransactionTemplateDetails(bool shouldRemap = false);
 BaseListReturnType<TransactionPreset> GetAllTransactionPresetsWithTransactionTypeDetails(bool shouldRemap = false);
 BaseListReturnType<TransactionPreset> GetAllTransactionPresetWitDetails( List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<TransactionPreset> GetAllTransactionPresetWitDetails( SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 TransactionPreset GetTransactionPreset(long idTransactionPreset,bool shouldRemap = false);
 TransactionPreset GetTransactionPreset(long idTransactionPreset, SubscriptionEntities db,bool shouldRemap = false);
 TransactionPreset GetTransactionPresetWithBankStatementHitList_TransactionPresetDetails(long idTransactionPreset,bool shouldRemap = false);
           List<BankStatementHitList_TransactionPreset> UpdateBankStatementHitList_TransactionPresetForTransactionPresetWithoutSavingNewItem(List<BankStatementHitList_TransactionPreset> newBankStatementHitList_TransactionPreset,long idTransactionPreset);
    List<BankStatementHitList_TransactionPreset> UpdateBankStatementHitList_TransactionPresetForTransactionPresetWithoutSavingNewItem(List<BankStatementHitList_TransactionPreset> newBankStatementHitList_TransactionPreset,long idTransactionPreset,SubscriptionEntities db);
          

    List<BankStatementHitList_TransactionPreset> UpdateBankStatementHitList_TransactionPresetForTransactionPreset(List<BankStatementHitList_TransactionPreset> newBankStatementHitList_TransactionPreset,long idTransactionPreset);
    List<BankStatementHitList_TransactionPreset> UpdateBankStatementHitList_TransactionPresetForTransactionPreset(List<BankStatementHitList_TransactionPreset> newBankStatementHitList_TransactionPreset,long idTransactionPreset,SubscriptionEntities db);
                           



 TransactionPreset GetTransactionPresetWithBankStatementStagingHit_TransactionPresetDetails(long idTransactionPreset,bool shouldRemap = false);
           List<BankStatementStagingHit_TransactionPreset> UpdateBankStatementStagingHit_TransactionPresetForTransactionPresetWithoutSavingNewItem(List<BankStatementStagingHit_TransactionPreset> newBankStatementStagingHit_TransactionPreset,long idTransactionPreset);
    List<BankStatementStagingHit_TransactionPreset> UpdateBankStatementStagingHit_TransactionPresetForTransactionPresetWithoutSavingNewItem(List<BankStatementStagingHit_TransactionPreset> newBankStatementStagingHit_TransactionPreset,long idTransactionPreset,SubscriptionEntities db);
          

    List<BankStatementStagingHit_TransactionPreset> UpdateBankStatementStagingHit_TransactionPresetForTransactionPreset(List<BankStatementStagingHit_TransactionPreset> newBankStatementStagingHit_TransactionPreset,long idTransactionPreset);
    List<BankStatementStagingHit_TransactionPreset> UpdateBankStatementStagingHit_TransactionPresetForTransactionPreset(List<BankStatementStagingHit_TransactionPreset> newBankStatementStagingHit_TransactionPreset,long idTransactionPreset,SubscriptionEntities db);
                           



 TransactionPreset GetTransactionPresetWithTransactionDetailPresetsDetails(long idTransactionPreset,bool shouldRemap = false);
           List<TransactionDetailPreset> UpdateTransactionDetailPresetsForTransactionPresetWithoutSavingNewItem(List<TransactionDetailPreset> newTransactionDetailPresets,long idTransactionPreset);
    List<TransactionDetailPreset> UpdateTransactionDetailPresetsForTransactionPresetWithoutSavingNewItem(List<TransactionDetailPreset> newTransactionDetailPresets,long idTransactionPreset,SubscriptionEntities db);
          

    List<TransactionDetailPreset> UpdateTransactionDetailPresetsForTransactionPreset(List<TransactionDetailPreset> newTransactionDetailPresets,long idTransactionPreset);
    List<TransactionDetailPreset> UpdateTransactionDetailPresetsForTransactionPreset(List<TransactionDetailPreset> newTransactionDetailPresets,long idTransactionPreset,SubscriptionEntities db);
                           



 TransactionPreset GetTransactionPresetWithCustomerDetails(long idTransactionPreset,bool shouldRemap = false);
    


 TransactionPreset GetTransactionPresetWithTransactionAccountDetails(long idTransactionPreset,bool shouldRemap = false);
    


 TransactionPreset GetTransactionPresetWithTransactionClassDetails(long idTransactionPreset,bool shouldRemap = false);
    


 TransactionPreset GetTransactionPresetWithTransactionTemplateDetails(long idTransactionPreset,bool shouldRemap = false);
    


 TransactionPreset GetTransactionPresetWithTransactionTypeDetails(long idTransactionPreset,bool shouldRemap = false);
    


 TransactionPreset GetTransactionPresetCustom( Expression<Func<TransactionPreset, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 TransactionPreset GetTransactionPresetCustom(SubscriptionEntities db, Expression<Func<TransactionPreset, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<TransactionPreset> GetTransactionPresetCustomList( Expression<Func<TransactionPreset, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<TransactionPreset, dynamic> orderExpression = null);
 BaseListReturnType<TransactionPreset> GetTransactionPresetCustomList( SubscriptionEntities db , Expression<Func<TransactionPreset, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<TransactionPreset, dynamic> orderExpression = null);
 TransactionPreset GetTransactionPresetWithDetails(long idTransactionPreset, List<string> includes = null,bool shouldRemap = false);
 TransactionPreset GetTransactionPresetWithDetails(long idTransactionPreset, SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 TransactionPreset GetTransactionPresetWitDetails(long idTransactionPreset,bool shouldRemap = false);
 TransactionPreset GetTransactionPresetWitDetails(long idTransactionPreset, SubscriptionEntities db,bool shouldRemap = false);
 void SaveTransactionPreset(TransactionPreset transactionPreset);
 void SaveTransactionPreset(TransactionPreset transactionPreset, SubscriptionEntities db);
 void SaveOnlyTransactionPreset(TransactionPreset transactionPreset);
 void SaveOnlyTransactionPreset(TransactionPreset transactionPreset, SubscriptionEntities db);
 void DeleteTransactionPreset(TransactionPreset transactionPreset);
 void DeleteTransactionPreset(TransactionPreset transactionPreset, SubscriptionEntities db);		
  void DeletePermanentlyTransactionPreset(TransactionPreset transactionPreset);
 void DeletePermanentlyTransactionPreset(TransactionPreset transactionPreset, SubscriptionEntities db);	
	}
 	public partial interface ITransactionStateDao
	{
  List<TransactionState> GetAllTransactionStates(bool shouldRemap = false);
  List<TransactionState> GetAllTransactionStates(SubscriptionEntities db,bool shouldRemap = false);
  BaseListReturnType<TransactionState> GetAllTransactionStatesByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<TransactionState, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<TransactionState, dynamic> orderExpression = null);
  BaseListReturnType<TransactionState> GetAllTransactionStatesByPage(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<TransactionState, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<TransactionState, dynamic> orderExpression = null);
  
  BaseListReturnType<TransactionState> GetAllTransactionStatesByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<TransactionState, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<TransactionState, dynamic> orderExpression = null);
  BaseListReturnType<TransactionState> GetAllTransactionStatesByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<TransactionState, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<TransactionState, dynamic> orderExpression = null);

 BaseListReturnType<TransactionState> GetAllTransactionStatesWithTransactionsDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<TransactionState, bool>> expression = null,bool shouldRemap = false, Func<TransactionState, dynamic> orderExpression = null);
 BaseListReturnType<TransactionState> GetAllTransactionStatesWithTransactionsDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<TransactionState, bool>> expression = null,bool shouldRemap = false, Func<TransactionState, dynamic> orderExpression = null);


List<TransactionState> GetTransactionStateListByIdList(List<long> transactionStateIds);

List<TransactionState> GetTransactionStateListByIdList(List<long> transactionStateIds, SubscriptionEntities db);

 BaseListReturnType<TransactionState> GetAllTransactionStatesWithTransactionsDetails(bool shouldRemap = false);
 BaseListReturnType<TransactionState> GetAllTransactionStateWitDetails( List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<TransactionState> GetAllTransactionStateWitDetails( SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 TransactionState GetTransactionState(long idTransactionState,bool shouldRemap = false);
 TransactionState GetTransactionState(long idTransactionState, SubscriptionEntities db,bool shouldRemap = false);
 TransactionState GetTransactionStateWithTransactionsDetails(long idTransactionState,bool shouldRemap = false);
           List<Transaction> UpdateTransactionsForTransactionStateWithoutSavingNewItem(List<Transaction> newTransactions,long idTransactionState);
    List<Transaction> UpdateTransactionsForTransactionStateWithoutSavingNewItem(List<Transaction> newTransactions,long idTransactionState,SubscriptionEntities db);
          

    List<Transaction> UpdateTransactionsForTransactionState(List<Transaction> newTransactions,long idTransactionState);
    List<Transaction> UpdateTransactionsForTransactionState(List<Transaction> newTransactions,long idTransactionState,SubscriptionEntities db);
                           



 TransactionState GetTransactionStateCustom( Expression<Func<TransactionState, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 TransactionState GetTransactionStateCustom(SubscriptionEntities db, Expression<Func<TransactionState, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<TransactionState> GetTransactionStateCustomList( Expression<Func<TransactionState, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<TransactionState, dynamic> orderExpression = null);
 BaseListReturnType<TransactionState> GetTransactionStateCustomList( SubscriptionEntities db , Expression<Func<TransactionState, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<TransactionState, dynamic> orderExpression = null);
 TransactionState GetTransactionStateWithDetails(long idTransactionState, List<string> includes = null,bool shouldRemap = false);
 TransactionState GetTransactionStateWithDetails(long idTransactionState, SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 TransactionState GetTransactionStateWitDetails(long idTransactionState,bool shouldRemap = false);
 TransactionState GetTransactionStateWitDetails(long idTransactionState, SubscriptionEntities db,bool shouldRemap = false);
 void SaveTransactionState(TransactionState transactionState);
 void SaveTransactionState(TransactionState transactionState, SubscriptionEntities db);
 void SaveOnlyTransactionState(TransactionState transactionState);
 void SaveOnlyTransactionState(TransactionState transactionState, SubscriptionEntities db);
 void DeleteTransactionState(TransactionState transactionState);
 void DeleteTransactionState(TransactionState transactionState, SubscriptionEntities db);		
  void DeletePermanentlyTransactionState(TransactionState transactionState);
 void DeletePermanentlyTransactionState(TransactionState transactionState, SubscriptionEntities db);	
	}
 	public partial interface ITransactionTemplateDao
	{
  List<TransactionTemplate> GetAllTransactionTemplates(bool shouldRemap = false);
  List<TransactionTemplate> GetAllTransactionTemplates(SubscriptionEntities db,bool shouldRemap = false);
  BaseListReturnType<TransactionTemplate> GetAllTransactionTemplatesByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<TransactionTemplate, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<TransactionTemplate, dynamic> orderExpression = null);
  BaseListReturnType<TransactionTemplate> GetAllTransactionTemplatesByPage(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<TransactionTemplate, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<TransactionTemplate, dynamic> orderExpression = null);
  
  BaseListReturnType<TransactionTemplate> GetAllTransactionTemplatesByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<TransactionTemplate, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<TransactionTemplate, dynamic> orderExpression = null);
  BaseListReturnType<TransactionTemplate> GetAllTransactionTemplatesByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<TransactionTemplate, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<TransactionTemplate, dynamic> orderExpression = null);

 BaseListReturnType<TransactionTemplate> GetAllTransactionTemplatesWithTransactionPresetsDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<TransactionTemplate, bool>> expression = null,bool shouldRemap = false, Func<TransactionTemplate, dynamic> orderExpression = null);
 BaseListReturnType<TransactionTemplate> GetAllTransactionTemplatesWithTransactionPresetsDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<TransactionTemplate, bool>> expression = null,bool shouldRemap = false, Func<TransactionTemplate, dynamic> orderExpression = null);

 BaseListReturnType<TransactionTemplate> GetAllTransactionTemplatesWithBanksDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<TransactionTemplate, bool>> expression = null,bool shouldRemap = false, Func<TransactionTemplate, dynamic> orderExpression = null);
 BaseListReturnType<TransactionTemplate> GetAllTransactionTemplatesWithBanksDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<TransactionTemplate, bool>> expression = null,bool shouldRemap = false, Func<TransactionTemplate, dynamic> orderExpression = null);

 BaseListReturnType<TransactionTemplate> GetAllTransactionTemplatesWithTransactionsDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<TransactionTemplate, bool>> expression = null,bool shouldRemap = false, Func<TransactionTemplate, dynamic> orderExpression = null);
 BaseListReturnType<TransactionTemplate> GetAllTransactionTemplatesWithTransactionsDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<TransactionTemplate, bool>> expression = null,bool shouldRemap = false, Func<TransactionTemplate, dynamic> orderExpression = null);


List<TransactionTemplate> GetTransactionTemplateListByIdList(List<long> transactionTemplateIds);

List<TransactionTemplate> GetTransactionTemplateListByIdList(List<long> transactionTemplateIds, SubscriptionEntities db);

 BaseListReturnType<TransactionTemplate> GetAllTransactionTemplatesWithTransactionPresetsDetails(bool shouldRemap = false);
 BaseListReturnType<TransactionTemplate> GetAllTransactionTemplatesWithBanksDetails(bool shouldRemap = false);
 BaseListReturnType<TransactionTemplate> GetAllTransactionTemplatesWithTransactionsDetails(bool shouldRemap = false);
 BaseListReturnType<TransactionTemplate> GetAllTransactionTemplateWitDetails( List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<TransactionTemplate> GetAllTransactionTemplateWitDetails( SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 TransactionTemplate GetTransactionTemplate(long idTransactionTemplate,bool shouldRemap = false);
 TransactionTemplate GetTransactionTemplate(long idTransactionTemplate, SubscriptionEntities db,bool shouldRemap = false);
 TransactionTemplate GetTransactionTemplateWithTransactionPresetsDetails(long idTransactionTemplate,bool shouldRemap = false);
           List<TransactionPreset> UpdateTransactionPresetsForTransactionTemplateWithoutSavingNewItem(List<TransactionPreset> newTransactionPresets,long idTransactionTemplate);
    List<TransactionPreset> UpdateTransactionPresetsForTransactionTemplateWithoutSavingNewItem(List<TransactionPreset> newTransactionPresets,long idTransactionTemplate,SubscriptionEntities db);
          

    List<TransactionPreset> UpdateTransactionPresetsForTransactionTemplate(List<TransactionPreset> newTransactionPresets,long idTransactionTemplate);
    List<TransactionPreset> UpdateTransactionPresetsForTransactionTemplate(List<TransactionPreset> newTransactionPresets,long idTransactionTemplate,SubscriptionEntities db);
                           



 TransactionTemplate GetTransactionTemplateWithBanksDetails(long idTransactionTemplate,bool shouldRemap = false);
           List<Bank> UpdateBanksForTransactionTemplateWithoutSavingNewItem(List<Bank> newBanks,long idTransactionTemplate);
    List<Bank> UpdateBanksForTransactionTemplateWithoutSavingNewItem(List<Bank> newBanks,long idTransactionTemplate,SubscriptionEntities db);
          

    List<Bank> UpdateBanksForTransactionTemplate(List<Bank> newBanks,long idTransactionTemplate);
    List<Bank> UpdateBanksForTransactionTemplate(List<Bank> newBanks,long idTransactionTemplate,SubscriptionEntities db);
                           



 TransactionTemplate GetTransactionTemplateWithTransactionsDetails(long idTransactionTemplate,bool shouldRemap = false);
           List<Transaction> UpdateTransactionsForTransactionTemplateWithoutSavingNewItem(List<Transaction> newTransactions,long idTransactionTemplate);
    List<Transaction> UpdateTransactionsForTransactionTemplateWithoutSavingNewItem(List<Transaction> newTransactions,long idTransactionTemplate,SubscriptionEntities db);
          

    List<Transaction> UpdateTransactionsForTransactionTemplate(List<Transaction> newTransactions,long idTransactionTemplate);
    List<Transaction> UpdateTransactionsForTransactionTemplate(List<Transaction> newTransactions,long idTransactionTemplate,SubscriptionEntities db);
                           



 TransactionTemplate GetTransactionTemplateCustom( Expression<Func<TransactionTemplate, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 TransactionTemplate GetTransactionTemplateCustom(SubscriptionEntities db, Expression<Func<TransactionTemplate, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<TransactionTemplate> GetTransactionTemplateCustomList( Expression<Func<TransactionTemplate, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<TransactionTemplate, dynamic> orderExpression = null);
 BaseListReturnType<TransactionTemplate> GetTransactionTemplateCustomList( SubscriptionEntities db , Expression<Func<TransactionTemplate, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<TransactionTemplate, dynamic> orderExpression = null);
 TransactionTemplate GetTransactionTemplateWithDetails(long idTransactionTemplate, List<string> includes = null,bool shouldRemap = false);
 TransactionTemplate GetTransactionTemplateWithDetails(long idTransactionTemplate, SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 TransactionTemplate GetTransactionTemplateWitDetails(long idTransactionTemplate,bool shouldRemap = false);
 TransactionTemplate GetTransactionTemplateWitDetails(long idTransactionTemplate, SubscriptionEntities db,bool shouldRemap = false);
 void SaveTransactionTemplate(TransactionTemplate transactionTemplate);
 void SaveTransactionTemplate(TransactionTemplate transactionTemplate, SubscriptionEntities db);
 void SaveOnlyTransactionTemplate(TransactionTemplate transactionTemplate);
 void SaveOnlyTransactionTemplate(TransactionTemplate transactionTemplate, SubscriptionEntities db);
 void DeleteTransactionTemplate(TransactionTemplate transactionTemplate);
 void DeleteTransactionTemplate(TransactionTemplate transactionTemplate, SubscriptionEntities db);		
  void DeletePermanentlyTransactionTemplate(TransactionTemplate transactionTemplate);
 void DeletePermanentlyTransactionTemplate(TransactionTemplate transactionTemplate, SubscriptionEntities db);	
	}
 	public partial interface ITransactionTypeDao
	{
  List<TransactionType> GetAllTransactionTypes(bool shouldRemap = false);
  List<TransactionType> GetAllTransactionTypes(SubscriptionEntities db,bool shouldRemap = false);
  BaseListReturnType<TransactionType> GetAllTransactionTypesByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<TransactionType, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<TransactionType, dynamic> orderExpression = null);
  BaseListReturnType<TransactionType> GetAllTransactionTypesByPage(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<TransactionType, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<TransactionType, dynamic> orderExpression = null);
  
  BaseListReturnType<TransactionType> GetAllTransactionTypesByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<TransactionType, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<TransactionType, dynamic> orderExpression = null);
  BaseListReturnType<TransactionType> GetAllTransactionTypesByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<TransactionType, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<TransactionType, dynamic> orderExpression = null);

 BaseListReturnType<TransactionType> GetAllTransactionTypesWithTransactionPresetsDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<TransactionType, bool>> expression = null,bool shouldRemap = false, Func<TransactionType, dynamic> orderExpression = null);
 BaseListReturnType<TransactionType> GetAllTransactionTypesWithTransactionPresetsDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<TransactionType, bool>> expression = null,bool shouldRemap = false, Func<TransactionType, dynamic> orderExpression = null);

 BaseListReturnType<TransactionType> GetAllTransactionTypesWithTransactionsDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<TransactionType, bool>> expression = null,bool shouldRemap = false, Func<TransactionType, dynamic> orderExpression = null);
 BaseListReturnType<TransactionType> GetAllTransactionTypesWithTransactionsDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<TransactionType, bool>> expression = null,bool shouldRemap = false, Func<TransactionType, dynamic> orderExpression = null);


List<TransactionType> GetTransactionTypeListByIdList(List<long> transactionTypeIds);

List<TransactionType> GetTransactionTypeListByIdList(List<long> transactionTypeIds, SubscriptionEntities db);

 BaseListReturnType<TransactionType> GetAllTransactionTypesWithTransactionPresetsDetails(bool shouldRemap = false);
 BaseListReturnType<TransactionType> GetAllTransactionTypesWithTransactionsDetails(bool shouldRemap = false);
 BaseListReturnType<TransactionType> GetAllTransactionTypeWitDetails( List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<TransactionType> GetAllTransactionTypeWitDetails( SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 TransactionType GetTransactionType(long idTransactionType,bool shouldRemap = false);
 TransactionType GetTransactionType(long idTransactionType, SubscriptionEntities db,bool shouldRemap = false);
 TransactionType GetTransactionTypeWithTransactionPresetsDetails(long idTransactionType,bool shouldRemap = false);
           List<TransactionPreset> UpdateTransactionPresetsForTransactionTypeWithoutSavingNewItem(List<TransactionPreset> newTransactionPresets,long idTransactionType);
    List<TransactionPreset> UpdateTransactionPresetsForTransactionTypeWithoutSavingNewItem(List<TransactionPreset> newTransactionPresets,long idTransactionType,SubscriptionEntities db);
          

    List<TransactionPreset> UpdateTransactionPresetsForTransactionType(List<TransactionPreset> newTransactionPresets,long idTransactionType);
    List<TransactionPreset> UpdateTransactionPresetsForTransactionType(List<TransactionPreset> newTransactionPresets,long idTransactionType,SubscriptionEntities db);
                           



 TransactionType GetTransactionTypeWithTransactionsDetails(long idTransactionType,bool shouldRemap = false);
           List<Transaction> UpdateTransactionsForTransactionTypeWithoutSavingNewItem(List<Transaction> newTransactions,long idTransactionType);
    List<Transaction> UpdateTransactionsForTransactionTypeWithoutSavingNewItem(List<Transaction> newTransactions,long idTransactionType,SubscriptionEntities db);
          

    List<Transaction> UpdateTransactionsForTransactionType(List<Transaction> newTransactions,long idTransactionType);
    List<Transaction> UpdateTransactionsForTransactionType(List<Transaction> newTransactions,long idTransactionType,SubscriptionEntities db);
                           



 TransactionType GetTransactionTypeCustom( Expression<Func<TransactionType, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 TransactionType GetTransactionTypeCustom(SubscriptionEntities db, Expression<Func<TransactionType, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<TransactionType> GetTransactionTypeCustomList( Expression<Func<TransactionType, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<TransactionType, dynamic> orderExpression = null);
 BaseListReturnType<TransactionType> GetTransactionTypeCustomList( SubscriptionEntities db , Expression<Func<TransactionType, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<TransactionType, dynamic> orderExpression = null);
 TransactionType GetTransactionTypeWithDetails(long idTransactionType, List<string> includes = null,bool shouldRemap = false);
 TransactionType GetTransactionTypeWithDetails(long idTransactionType, SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 TransactionType GetTransactionTypeWitDetails(long idTransactionType,bool shouldRemap = false);
 TransactionType GetTransactionTypeWitDetails(long idTransactionType, SubscriptionEntities db,bool shouldRemap = false);
 void SaveTransactionType(TransactionType transactionType);
 void SaveTransactionType(TransactionType transactionType, SubscriptionEntities db);
 void SaveOnlyTransactionType(TransactionType transactionType);
 void SaveOnlyTransactionType(TransactionType transactionType, SubscriptionEntities db);
 void DeleteTransactionType(TransactionType transactionType);
 void DeleteTransactionType(TransactionType transactionType, SubscriptionEntities db);		
  void DeletePermanentlyTransactionType(TransactionType transactionType);
 void DeletePermanentlyTransactionType(TransactionType transactionType, SubscriptionEntities db);	
	}
 	public partial interface IUserDao
	{
  List<User> GetAllUsers(bool shouldRemap = false);
  List<User> GetAllUsers(SubscriptionEntities db,bool shouldRemap = false);
  BaseListReturnType<User> GetAllUsersByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<User, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<User, dynamic> orderExpression = null);
  BaseListReturnType<User> GetAllUsersByPage(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<User, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<User, dynamic> orderExpression = null);
  
  BaseListReturnType<User> GetAllUsersByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<User, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<User, dynamic> orderExpression = null);
  BaseListReturnType<User> GetAllUsersByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<User, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<User, dynamic> orderExpression = null);

 BaseListReturnType<User> GetAllUsersWithBankStatementStagingsDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<User, bool>> expression = null,bool shouldRemap = false, Func<User, dynamic> orderExpression = null);
 BaseListReturnType<User> GetAllUsersWithBankStatementStagingsDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<User, bool>> expression = null,bool shouldRemap = false, Func<User, dynamic> orderExpression = null);

 BaseListReturnType<User> GetAllUsersWithOrdersDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<User, bool>> expression = null,bool shouldRemap = false, Func<User, dynamic> orderExpression = null);
 BaseListReturnType<User> GetAllUsersWithOrdersDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<User, bool>> expression = null,bool shouldRemap = false, Func<User, dynamic> orderExpression = null);

 BaseListReturnType<User> GetAllUsersWithPaymentsDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<User, bool>> expression = null,bool shouldRemap = false, Func<User, dynamic> orderExpression = null);
 BaseListReturnType<User> GetAllUsersWithPaymentsDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<User, bool>> expression = null,bool shouldRemap = false, Func<User, dynamic> orderExpression = null);

 BaseListReturnType<User> GetAllUsersWithReceiptsDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<User, bool>> expression = null,bool shouldRemap = false, Func<User, dynamic> orderExpression = null);
 BaseListReturnType<User> GetAllUsersWithReceiptsDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<User, bool>> expression = null,bool shouldRemap = false, Func<User, dynamic> orderExpression = null);

 BaseListReturnType<User> GetAllUsersWithRequestType_UserDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<User, bool>> expression = null,bool shouldRemap = false, Func<User, dynamic> orderExpression = null);
 BaseListReturnType<User> GetAllUsersWithRequestType_UserDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<User, bool>> expression = null,bool shouldRemap = false, Func<User, dynamic> orderExpression = null);

 BaseListReturnType<User> GetAllUsersWithTransactionsDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<User, bool>> expression = null,bool shouldRemap = false, Func<User, dynamic> orderExpression = null);
 BaseListReturnType<User> GetAllUsersWithTransactionsDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<User, bool>> expression = null,bool shouldRemap = false, Func<User, dynamic> orderExpression = null);

 BaseListReturnType<User> GetAllUsersWithPersonDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<User, bool>> expression = null,bool shouldRemap = false, Func<User, dynamic> orderExpression = null);
 BaseListReturnType<User> GetAllUsersWithPersonDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<User, bool>> expression = null,bool shouldRemap = false, Func<User, dynamic> orderExpression = null);






BaseListReturnType<User> GetAllUserListByPerson(long idPerson);

BaseListReturnType<User> GetAllUserListByPerson(long idPerson, SubscriptionEntities db);

BaseListReturnType<User> GetAllUserListByPersonByPage(long idPerson, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<User> GetAllUserListByPersonByPage(long idPerson, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);




List<User> GetUserListByIdList(List<long> userIds);

List<User> GetUserListByIdList(List<long> userIds, SubscriptionEntities db);

 BaseListReturnType<User> GetAllUsersWithBankStatementStagingsDetails(bool shouldRemap = false);
 BaseListReturnType<User> GetAllUsersWithOrdersDetails(bool shouldRemap = false);
 BaseListReturnType<User> GetAllUsersWithPaymentsDetails(bool shouldRemap = false);
 BaseListReturnType<User> GetAllUsersWithReceiptsDetails(bool shouldRemap = false);
 BaseListReturnType<User> GetAllUsersWithRequestType_UserDetails(bool shouldRemap = false);
 BaseListReturnType<User> GetAllUsersWithTransactionsDetails(bool shouldRemap = false);
 BaseListReturnType<User> GetAllUsersWithPersonDetails(bool shouldRemap = false);
 BaseListReturnType<User> GetAllUserWitDetails( List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<User> GetAllUserWitDetails( SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 User GetUser(long idUser,bool shouldRemap = false);
 User GetUser(long idUser, SubscriptionEntities db,bool shouldRemap = false);
 User GetUserWithBankStatementStagingsDetails(long idUser,bool shouldRemap = false);
           List<BankStatementStaging> UpdateBankStatementStagingsForUserWithoutSavingNewItem(List<BankStatementStaging> newBankStatementStagings,long idUser);
    List<BankStatementStaging> UpdateBankStatementStagingsForUserWithoutSavingNewItem(List<BankStatementStaging> newBankStatementStagings,long idUser,SubscriptionEntities db);
          

    List<BankStatementStaging> UpdateBankStatementStagingsForUser(List<BankStatementStaging> newBankStatementStagings,long idUser);
    List<BankStatementStaging> UpdateBankStatementStagingsForUser(List<BankStatementStaging> newBankStatementStagings,long idUser,SubscriptionEntities db);
                           



 User GetUserWithOrdersDetails(long idUser,bool shouldRemap = false);
           List<Order> UpdateOrdersForUserWithoutSavingNewItem(List<Order> newOrders,long idUser);
    List<Order> UpdateOrdersForUserWithoutSavingNewItem(List<Order> newOrders,long idUser,SubscriptionEntities db);
          

    List<Order> UpdateOrdersForUser(List<Order> newOrders,long idUser);
    List<Order> UpdateOrdersForUser(List<Order> newOrders,long idUser,SubscriptionEntities db);
                           



 User GetUserWithPaymentsDetails(long idUser,bool shouldRemap = false);
           List<Payment> UpdatePaymentsForUserWithoutSavingNewItem(List<Payment> newPayments,long idUser);
    List<Payment> UpdatePaymentsForUserWithoutSavingNewItem(List<Payment> newPayments,long idUser,SubscriptionEntities db);
          

    List<Payment> UpdatePaymentsForUser(List<Payment> newPayments,long idUser);
    List<Payment> UpdatePaymentsForUser(List<Payment> newPayments,long idUser,SubscriptionEntities db);
                           



 User GetUserWithReceiptsDetails(long idUser,bool shouldRemap = false);
           List<Receipt> UpdateReceiptsForUserWithoutSavingNewItem(List<Receipt> newReceipts,long idUser);
    List<Receipt> UpdateReceiptsForUserWithoutSavingNewItem(List<Receipt> newReceipts,long idUser,SubscriptionEntities db);
          

    List<Receipt> UpdateReceiptsForUser(List<Receipt> newReceipts,long idUser);
    List<Receipt> UpdateReceiptsForUser(List<Receipt> newReceipts,long idUser,SubscriptionEntities db);
                           



 User GetUserWithRequestType_UserDetails(long idUser,bool shouldRemap = false);
           List<RequestType_User> UpdateRequestType_UserForUserWithoutSavingNewItem(List<RequestType_User> newRequestType_User,long idUser);
    List<RequestType_User> UpdateRequestType_UserForUserWithoutSavingNewItem(List<RequestType_User> newRequestType_User,long idUser,SubscriptionEntities db);
          

    List<RequestType_User> UpdateRequestType_UserForUser(List<RequestType_User> newRequestType_User,long idUser);
    List<RequestType_User> UpdateRequestType_UserForUser(List<RequestType_User> newRequestType_User,long idUser,SubscriptionEntities db);
                           



 User GetUserWithTransactionsDetails(long idUser,bool shouldRemap = false);
           List<Transaction> UpdateTransactionsForUserWithoutSavingNewItem(List<Transaction> newTransactions,long idUser);
    List<Transaction> UpdateTransactionsForUserWithoutSavingNewItem(List<Transaction> newTransactions,long idUser,SubscriptionEntities db);
          

    List<Transaction> UpdateTransactionsForUser(List<Transaction> newTransactions,long idUser);
    List<Transaction> UpdateTransactionsForUser(List<Transaction> newTransactions,long idUser,SubscriptionEntities db);
                           



 User GetUserWithPersonDetails(long idUser,bool shouldRemap = false);
    


 User GetUserCustom( Expression<Func<User, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 User GetUserCustom(SubscriptionEntities db, Expression<Func<User, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<User> GetUserCustomList( Expression<Func<User, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<User, dynamic> orderExpression = null);
 BaseListReturnType<User> GetUserCustomList( SubscriptionEntities db , Expression<Func<User, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<User, dynamic> orderExpression = null);
 User GetUserWithDetails(long idUser, List<string> includes = null,bool shouldRemap = false);
 User GetUserWithDetails(long idUser, SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 User GetUserWitDetails(long idUser,bool shouldRemap = false);
 User GetUserWitDetails(long idUser, SubscriptionEntities db,bool shouldRemap = false);
 void SaveUser(User user);
 void SaveUser(User user, SubscriptionEntities db);
 void SaveOnlyUser(User user);
 void SaveOnlyUser(User user, SubscriptionEntities db);
 void DeleteUser(User user);
 void DeleteUser(User user, SubscriptionEntities db);		
  void DeletePermanentlyUser(User user);
 void DeletePermanentlyUser(User user, SubscriptionEntities db);	
	}
 	public partial interface IUser_PermissionDao
	{
  List<User_Permission> GetAllUser_Permission(bool shouldRemap = false);
  List<User_Permission> GetAllUser_Permission(SubscriptionEntities db,bool shouldRemap = false);
  BaseListReturnType<User_Permission> GetAllUser_PermissionByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<User_Permission, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<User_Permission, dynamic> orderExpression = null);
  BaseListReturnType<User_Permission> GetAllUser_PermissionByPage(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<User_Permission, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<User_Permission, dynamic> orderExpression = null);
  
  BaseListReturnType<User_Permission> GetAllUser_PermissionByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<User_Permission, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<User_Permission, dynamic> orderExpression = null);
  BaseListReturnType<User_Permission> GetAllUser_PermissionByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<User_Permission, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<User_Permission, dynamic> orderExpression = null);

 BaseListReturnType<User_Permission> GetAllUser_PermissionWithPermissionDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<User_Permission, bool>> expression = null,bool shouldRemap = false, Func<User_Permission, dynamic> orderExpression = null);
 BaseListReturnType<User_Permission> GetAllUser_PermissionWithPermissionDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<User_Permission, bool>> expression = null,bool shouldRemap = false, Func<User_Permission, dynamic> orderExpression = null);






BaseListReturnType<User_Permission> GetAllUser_PermissionListByPermission(long idPermission);

BaseListReturnType<User_Permission> GetAllUser_PermissionListByPermission(long idPermission, SubscriptionEntities db);

BaseListReturnType<User_Permission> GetAllUser_PermissionListByPermissionByPage(long idPermission, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<User_Permission> GetAllUser_PermissionListByPermissionByPage(long idPermission, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);




List<User_Permission> GetUser_PermissionListByIdList(List<long> user_PermissionIds);

List<User_Permission> GetUser_PermissionListByIdList(List<long> user_PermissionIds, SubscriptionEntities db);

 BaseListReturnType<User_Permission> GetAllUser_PermissionWithPermissionDetails(bool shouldRemap = false);
 BaseListReturnType<User_Permission> GetAllUser_PermissionWitDetails( List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<User_Permission> GetAllUser_PermissionWitDetails( SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 User_Permission GetUser_Permission(long idUser_Permission,bool shouldRemap = false);
 User_Permission GetUser_Permission(long idUser_Permission, SubscriptionEntities db,bool shouldRemap = false);
 User_Permission GetUser_PermissionWithPermissionDetails(long idUser_Permission,bool shouldRemap = false);
    


 User_Permission GetUser_PermissionCustom( Expression<Func<User_Permission, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 User_Permission GetUser_PermissionCustom(SubscriptionEntities db, Expression<Func<User_Permission, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<User_Permission> GetUser_PermissionCustomList( Expression<Func<User_Permission, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<User_Permission, dynamic> orderExpression = null);
 BaseListReturnType<User_Permission> GetUser_PermissionCustomList( SubscriptionEntities db , Expression<Func<User_Permission, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<User_Permission, dynamic> orderExpression = null);
 User_Permission GetUser_PermissionWithDetails(long idUser_Permission, List<string> includes = null,bool shouldRemap = false);
 User_Permission GetUser_PermissionWithDetails(long idUser_Permission, SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 User_Permission GetUser_PermissionWitDetails(long idUser_Permission,bool shouldRemap = false);
 User_Permission GetUser_PermissionWitDetails(long idUser_Permission, SubscriptionEntities db,bool shouldRemap = false);
 void SaveUser_Permission(User_Permission user_Permission);
 void SaveUser_Permission(User_Permission user_Permission, SubscriptionEntities db);
 void SaveOnlyUser_Permission(User_Permission user_Permission);
 void SaveOnlyUser_Permission(User_Permission user_Permission, SubscriptionEntities db);
 void DeleteUser_Permission(User_Permission user_Permission);
 void DeleteUser_Permission(User_Permission user_Permission, SubscriptionEntities db);		
  void DeletePermanentlyUser_Permission(User_Permission user_Permission);
 void DeletePermanentlyUser_Permission(User_Permission user_Permission, SubscriptionEntities db);	
	}
 	public partial interface IUser_RoleDao
	{
  List<User_Role> GetAllUser_Role(bool shouldRemap = false);
  List<User_Role> GetAllUser_Role(SubscriptionEntities db,bool shouldRemap = false);
  BaseListReturnType<User_Role> GetAllUser_RoleByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<User_Role, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<User_Role, dynamic> orderExpression = null);
  BaseListReturnType<User_Role> GetAllUser_RoleByPage(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<User_Role, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<User_Role, dynamic> orderExpression = null);
  
  BaseListReturnType<User_Role> GetAllUser_RoleByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<User_Role, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<User_Role, dynamic> orderExpression = null);
  BaseListReturnType<User_Role> GetAllUser_RoleByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<User_Role, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<User_Role, dynamic> orderExpression = null);

 BaseListReturnType<User_Role> GetAllUser_RoleWithRoleDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<User_Role, bool>> expression = null,bool shouldRemap = false, Func<User_Role, dynamic> orderExpression = null);
 BaseListReturnType<User_Role> GetAllUser_RoleWithRoleDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<User_Role, bool>> expression = null,bool shouldRemap = false, Func<User_Role, dynamic> orderExpression = null);


List<User_Role> GetUser_RoleListByIdList(List<long> user_RoleIds);

List<User_Role> GetUser_RoleListByIdList(List<long> user_RoleIds, SubscriptionEntities db);

 BaseListReturnType<User_Role> GetAllUser_RoleWithRoleDetails(bool shouldRemap = false);
 BaseListReturnType<User_Role> GetAllUser_RoleWitDetails( List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<User_Role> GetAllUser_RoleWitDetails( SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 User_Role GetUser_Role(long idUser_Role,bool shouldRemap = false);
 User_Role GetUser_Role(long idUser_Role, SubscriptionEntities db,bool shouldRemap = false);
 User_Role GetUser_RoleWithRoleDetails(long idUser_Role,bool shouldRemap = false);
    


 User_Role GetUser_RoleCustom( Expression<Func<User_Role, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 User_Role GetUser_RoleCustom(SubscriptionEntities db, Expression<Func<User_Role, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<User_Role> GetUser_RoleCustomList( Expression<Func<User_Role, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<User_Role, dynamic> orderExpression = null);
 BaseListReturnType<User_Role> GetUser_RoleCustomList( SubscriptionEntities db , Expression<Func<User_Role, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<User_Role, dynamic> orderExpression = null);
 User_Role GetUser_RoleWithDetails(long idUser_Role, List<string> includes = null,bool shouldRemap = false);
 User_Role GetUser_RoleWithDetails(long idUser_Role, SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 User_Role GetUser_RoleWitDetails(long idUser_Role,bool shouldRemap = false);
 User_Role GetUser_RoleWitDetails(long idUser_Role, SubscriptionEntities db,bool shouldRemap = false);
 void SaveUser_Role(User_Role user_Role);
 void SaveUser_Role(User_Role user_Role, SubscriptionEntities db);
 void SaveOnlyUser_Role(User_Role user_Role);
 void SaveOnlyUser_Role(User_Role user_Role, SubscriptionEntities db);
 void DeleteUser_Role(User_Role user_Role);
 void DeleteUser_Role(User_Role user_Role, SubscriptionEntities db);		
  void DeletePermanentlyUser_Role(User_Role user_Role);
 void DeletePermanentlyUser_Role(User_Role user_Role, SubscriptionEntities db);	
	}
 	public partial interface IUser_SocialNetworkDao
	{
  List<User_SocialNetwork> GetAllUser_SocialNetwork(bool shouldRemap = false);
  List<User_SocialNetwork> GetAllUser_SocialNetwork(SubscriptionEntities db,bool shouldRemap = false);
  BaseListReturnType<User_SocialNetwork> GetAllUser_SocialNetworkByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<User_SocialNetwork, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<User_SocialNetwork, dynamic> orderExpression = null);
  BaseListReturnType<User_SocialNetwork> GetAllUser_SocialNetworkByPage(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<User_SocialNetwork, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<User_SocialNetwork, dynamic> orderExpression = null);
  
  BaseListReturnType<User_SocialNetwork> GetAllUser_SocialNetworkByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<User_SocialNetwork, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<User_SocialNetwork, dynamic> orderExpression = null);
  BaseListReturnType<User_SocialNetwork> GetAllUser_SocialNetworkByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<User_SocialNetwork, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<User_SocialNetwork, dynamic> orderExpression = null);


List<User_SocialNetwork> GetUser_SocialNetworkListByIdList(List<long> user_SocialNetworkIds);

List<User_SocialNetwork> GetUser_SocialNetworkListByIdList(List<long> user_SocialNetworkIds, SubscriptionEntities db);

 BaseListReturnType<User_SocialNetwork> GetAllUser_SocialNetworkWitDetails( List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<User_SocialNetwork> GetAllUser_SocialNetworkWitDetails( SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 User_SocialNetwork GetUser_SocialNetwork(long idUser_SocialNetwork,bool shouldRemap = false);
 User_SocialNetwork GetUser_SocialNetwork(long idUser_SocialNetwork, SubscriptionEntities db,bool shouldRemap = false);
 User_SocialNetwork GetUser_SocialNetworkCustom( Expression<Func<User_SocialNetwork, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 User_SocialNetwork GetUser_SocialNetworkCustom(SubscriptionEntities db, Expression<Func<User_SocialNetwork, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<User_SocialNetwork> GetUser_SocialNetworkCustomList( Expression<Func<User_SocialNetwork, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<User_SocialNetwork, dynamic> orderExpression = null);
 BaseListReturnType<User_SocialNetwork> GetUser_SocialNetworkCustomList( SubscriptionEntities db , Expression<Func<User_SocialNetwork, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<User_SocialNetwork, dynamic> orderExpression = null);
 User_SocialNetwork GetUser_SocialNetworkWithDetails(long idUser_SocialNetwork, List<string> includes = null,bool shouldRemap = false);
 User_SocialNetwork GetUser_SocialNetworkWithDetails(long idUser_SocialNetwork, SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 User_SocialNetwork GetUser_SocialNetworkWitDetails(long idUser_SocialNetwork,bool shouldRemap = false);
 User_SocialNetwork GetUser_SocialNetworkWitDetails(long idUser_SocialNetwork, SubscriptionEntities db,bool shouldRemap = false);
 void SaveUser_SocialNetwork(User_SocialNetwork user_SocialNetwork);
 void SaveUser_SocialNetwork(User_SocialNetwork user_SocialNetwork, SubscriptionEntities db);
 void SaveOnlyUser_SocialNetwork(User_SocialNetwork user_SocialNetwork);
 void SaveOnlyUser_SocialNetwork(User_SocialNetwork user_SocialNetwork, SubscriptionEntities db);
 void DeleteUser_SocialNetwork(User_SocialNetwork user_SocialNetwork);
 void DeleteUser_SocialNetwork(User_SocialNetwork user_SocialNetwork, SubscriptionEntities db);		
  void DeletePermanentlyUser_SocialNetwork(User_SocialNetwork user_SocialNetwork);
 void DeletePermanentlyUser_SocialNetwork(User_SocialNetwork user_SocialNetwork, SubscriptionEntities db);	
	}
 	public partial interface IWorkflowDao
	{
  List<Workflow> GetAllWorkflows(bool shouldRemap = false);
  List<Workflow> GetAllWorkflows(SubscriptionEntities db,bool shouldRemap = false);
  BaseListReturnType<Workflow> GetAllWorkflowsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Workflow, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<Workflow, dynamic> orderExpression = null);
  BaseListReturnType<Workflow> GetAllWorkflowsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<Workflow, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<Workflow, dynamic> orderExpression = null);
  
  BaseListReturnType<Workflow> GetAllWorkflowsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Workflow, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<Workflow, dynamic> orderExpression = null);
  BaseListReturnType<Workflow> GetAllWorkflowsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<Workflow, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<Workflow, dynamic> orderExpression = null);

 BaseListReturnType<Workflow> GetAllWorkflowsWithApprovalMessagesDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Workflow, bool>> expression = null,bool shouldRemap = false, Func<Workflow, dynamic> orderExpression = null);
 BaseListReturnType<Workflow> GetAllWorkflowsWithApprovalMessagesDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Workflow, bool>> expression = null,bool shouldRemap = false, Func<Workflow, dynamic> orderExpression = null);

 BaseListReturnType<Workflow> GetAllWorkflowsWithRequestTypesDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Workflow, bool>> expression = null,bool shouldRemap = false, Func<Workflow, dynamic> orderExpression = null);
 BaseListReturnType<Workflow> GetAllWorkflowsWithRequestTypesDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Workflow, bool>> expression = null,bool shouldRemap = false, Func<Workflow, dynamic> orderExpression = null);

 BaseListReturnType<Workflow> GetAllWorkflowsWithWorkflowActionsDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Workflow, bool>> expression = null,bool shouldRemap = false, Func<Workflow, dynamic> orderExpression = null);
 BaseListReturnType<Workflow> GetAllWorkflowsWithWorkflowActionsDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Workflow, bool>> expression = null,bool shouldRemap = false, Func<Workflow, dynamic> orderExpression = null);

 BaseListReturnType<Workflow> GetAllWorkflowsWithWorkflowRolesDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Workflow, bool>> expression = null,bool shouldRemap = false, Func<Workflow, dynamic> orderExpression = null);
 BaseListReturnType<Workflow> GetAllWorkflowsWithWorkflowRolesDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Workflow, bool>> expression = null,bool shouldRemap = false, Func<Workflow, dynamic> orderExpression = null);

 BaseListReturnType<Workflow> GetAllWorkflowsWithWorkflowStatesDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Workflow, bool>> expression = null,bool shouldRemap = false, Func<Workflow, dynamic> orderExpression = null);
 BaseListReturnType<Workflow> GetAllWorkflowsWithWorkflowStatesDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Workflow, bool>> expression = null,bool shouldRemap = false, Func<Workflow, dynamic> orderExpression = null);


List<Workflow> GetWorkflowListByIdList(List<long> workflowIds);

List<Workflow> GetWorkflowListByIdList(List<long> workflowIds, SubscriptionEntities db);

 BaseListReturnType<Workflow> GetAllWorkflowsWithApprovalMessagesDetails(bool shouldRemap = false);
 BaseListReturnType<Workflow> GetAllWorkflowsWithRequestTypesDetails(bool shouldRemap = false);
 BaseListReturnType<Workflow> GetAllWorkflowsWithWorkflowActionsDetails(bool shouldRemap = false);
 BaseListReturnType<Workflow> GetAllWorkflowsWithWorkflowRolesDetails(bool shouldRemap = false);
 BaseListReturnType<Workflow> GetAllWorkflowsWithWorkflowStatesDetails(bool shouldRemap = false);
 BaseListReturnType<Workflow> GetAllWorkflowWitDetails( List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<Workflow> GetAllWorkflowWitDetails( SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 Workflow GetWorkflow(long idWorkflow,bool shouldRemap = false);
 Workflow GetWorkflow(long idWorkflow, SubscriptionEntities db,bool shouldRemap = false);
 Workflow GetWorkflowWithApprovalMessagesDetails(long idWorkflow,bool shouldRemap = false);
           List<ApprovalMessage> UpdateApprovalMessagesForWorkflowWithoutSavingNewItem(List<ApprovalMessage> newApprovalMessages,long idWorkflow);
    List<ApprovalMessage> UpdateApprovalMessagesForWorkflowWithoutSavingNewItem(List<ApprovalMessage> newApprovalMessages,long idWorkflow,SubscriptionEntities db);
          

    List<ApprovalMessage> UpdateApprovalMessagesForWorkflow(List<ApprovalMessage> newApprovalMessages,long idWorkflow);
    List<ApprovalMessage> UpdateApprovalMessagesForWorkflow(List<ApprovalMessage> newApprovalMessages,long idWorkflow,SubscriptionEntities db);
                           



 Workflow GetWorkflowWithRequestTypesDetails(long idWorkflow,bool shouldRemap = false);
           List<RequestType> UpdateRequestTypesForWorkflowWithoutSavingNewItem(List<RequestType> newRequestTypes,long idWorkflow);
    List<RequestType> UpdateRequestTypesForWorkflowWithoutSavingNewItem(List<RequestType> newRequestTypes,long idWorkflow,SubscriptionEntities db);
          

    List<RequestType> UpdateRequestTypesForWorkflow(List<RequestType> newRequestTypes,long idWorkflow);
    List<RequestType> UpdateRequestTypesForWorkflow(List<RequestType> newRequestTypes,long idWorkflow,SubscriptionEntities db);
                           



 Workflow GetWorkflowWithWorkflowActionsDetails(long idWorkflow,bool shouldRemap = false);
           List<WorkflowAction> UpdateWorkflowActionsForWorkflowWithoutSavingNewItem(List<WorkflowAction> newWorkflowActions,long idWorkflow);
    List<WorkflowAction> UpdateWorkflowActionsForWorkflowWithoutSavingNewItem(List<WorkflowAction> newWorkflowActions,long idWorkflow,SubscriptionEntities db);
          

    List<WorkflowAction> UpdateWorkflowActionsForWorkflow(List<WorkflowAction> newWorkflowActions,long idWorkflow);
    List<WorkflowAction> UpdateWorkflowActionsForWorkflow(List<WorkflowAction> newWorkflowActions,long idWorkflow,SubscriptionEntities db);
                           



 Workflow GetWorkflowWithWorkflowRolesDetails(long idWorkflow,bool shouldRemap = false);
           List<WorkflowRole> UpdateWorkflowRolesForWorkflowWithoutSavingNewItem(List<WorkflowRole> newWorkflowRoles,long idWorkflow);
    List<WorkflowRole> UpdateWorkflowRolesForWorkflowWithoutSavingNewItem(List<WorkflowRole> newWorkflowRoles,long idWorkflow,SubscriptionEntities db);
          

    List<WorkflowRole> UpdateWorkflowRolesForWorkflow(List<WorkflowRole> newWorkflowRoles,long idWorkflow);
    List<WorkflowRole> UpdateWorkflowRolesForWorkflow(List<WorkflowRole> newWorkflowRoles,long idWorkflow,SubscriptionEntities db);
                           



 Workflow GetWorkflowWithWorkflowStatesDetails(long idWorkflow,bool shouldRemap = false);
           List<WorkflowState> UpdateWorkflowStatesForWorkflowWithoutSavingNewItem(List<WorkflowState> newWorkflowStates,long idWorkflow);
    List<WorkflowState> UpdateWorkflowStatesForWorkflowWithoutSavingNewItem(List<WorkflowState> newWorkflowStates,long idWorkflow,SubscriptionEntities db);
          

    List<WorkflowState> UpdateWorkflowStatesForWorkflow(List<WorkflowState> newWorkflowStates,long idWorkflow);
    List<WorkflowState> UpdateWorkflowStatesForWorkflow(List<WorkflowState> newWorkflowStates,long idWorkflow,SubscriptionEntities db);
                           



 Workflow GetWorkflowCustom( Expression<Func<Workflow, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 Workflow GetWorkflowCustom(SubscriptionEntities db, Expression<Func<Workflow, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<Workflow> GetWorkflowCustomList( Expression<Func<Workflow, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<Workflow, dynamic> orderExpression = null);
 BaseListReturnType<Workflow> GetWorkflowCustomList( SubscriptionEntities db , Expression<Func<Workflow, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<Workflow, dynamic> orderExpression = null);
 Workflow GetWorkflowWithDetails(long idWorkflow, List<string> includes = null,bool shouldRemap = false);
 Workflow GetWorkflowWithDetails(long idWorkflow, SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 Workflow GetWorkflowWitDetails(long idWorkflow,bool shouldRemap = false);
 Workflow GetWorkflowWitDetails(long idWorkflow, SubscriptionEntities db,bool shouldRemap = false);
 void SaveWorkflow(Workflow workflow);
 void SaveWorkflow(Workflow workflow, SubscriptionEntities db);
 void SaveOnlyWorkflow(Workflow workflow);
 void SaveOnlyWorkflow(Workflow workflow, SubscriptionEntities db);
 void DeleteWorkflow(Workflow workflow);
 void DeleteWorkflow(Workflow workflow, SubscriptionEntities db);		
  void DeletePermanentlyWorkflow(Workflow workflow);
 void DeletePermanentlyWorkflow(Workflow workflow, SubscriptionEntities db);	
	}
 	public partial interface IWorkflowActionDao
	{
  List<WorkflowAction> GetAllWorkflowActions(bool shouldRemap = false);
  List<WorkflowAction> GetAllWorkflowActions(SubscriptionEntities db,bool shouldRemap = false);
  BaseListReturnType<WorkflowAction> GetAllWorkflowActionsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<WorkflowAction, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<WorkflowAction, dynamic> orderExpression = null);
  BaseListReturnType<WorkflowAction> GetAllWorkflowActionsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<WorkflowAction, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<WorkflowAction, dynamic> orderExpression = null);
  
  BaseListReturnType<WorkflowAction> GetAllWorkflowActionsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<WorkflowAction, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<WorkflowAction, dynamic> orderExpression = null);
  BaseListReturnType<WorkflowAction> GetAllWorkflowActionsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<WorkflowAction, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<WorkflowAction, dynamic> orderExpression = null);

 BaseListReturnType<WorkflowAction> GetAllWorkflowActionsWithApprovalMessagesDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<WorkflowAction, bool>> expression = null,bool shouldRemap = false, Func<WorkflowAction, dynamic> orderExpression = null);
 BaseListReturnType<WorkflowAction> GetAllWorkflowActionsWithApprovalMessagesDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<WorkflowAction, bool>> expression = null,bool shouldRemap = false, Func<WorkflowAction, dynamic> orderExpression = null);

 BaseListReturnType<WorkflowAction> GetAllWorkflowActionsWithWorkflowDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<WorkflowAction, bool>> expression = null,bool shouldRemap = false, Func<WorkflowAction, dynamic> orderExpression = null);
 BaseListReturnType<WorkflowAction> GetAllWorkflowActionsWithWorkflowDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<WorkflowAction, bool>> expression = null,bool shouldRemap = false, Func<WorkflowAction, dynamic> orderExpression = null);






BaseListReturnType<WorkflowAction> GetAllWorkflowActionListByWorkflow(long idWorkflow);

BaseListReturnType<WorkflowAction> GetAllWorkflowActionListByWorkflow(long idWorkflow, SubscriptionEntities db);

BaseListReturnType<WorkflowAction> GetAllWorkflowActionListByWorkflowByPage(long idWorkflow, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<WorkflowAction> GetAllWorkflowActionListByWorkflowByPage(long idWorkflow, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);



 BaseListReturnType<WorkflowAction> GetAllWorkflowActionsWithWorkflowTransitionsDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<WorkflowAction, bool>> expression = null,bool shouldRemap = false, Func<WorkflowAction, dynamic> orderExpression = null);
 BaseListReturnType<WorkflowAction> GetAllWorkflowActionsWithWorkflowTransitionsDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<WorkflowAction, bool>> expression = null,bool shouldRemap = false, Func<WorkflowAction, dynamic> orderExpression = null);


List<WorkflowAction> GetWorkflowActionListByIdList(List<long> workflowActionIds);

List<WorkflowAction> GetWorkflowActionListByIdList(List<long> workflowActionIds, SubscriptionEntities db);

 BaseListReturnType<WorkflowAction> GetAllWorkflowActionsWithApprovalMessagesDetails(bool shouldRemap = false);
 BaseListReturnType<WorkflowAction> GetAllWorkflowActionsWithWorkflowDetails(bool shouldRemap = false);
 BaseListReturnType<WorkflowAction> GetAllWorkflowActionsWithWorkflowTransitionsDetails(bool shouldRemap = false);
 BaseListReturnType<WorkflowAction> GetAllWorkflowActionWitDetails( List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<WorkflowAction> GetAllWorkflowActionWitDetails( SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 WorkflowAction GetWorkflowAction(long idWorkflowAction,bool shouldRemap = false);
 WorkflowAction GetWorkflowAction(long idWorkflowAction, SubscriptionEntities db,bool shouldRemap = false);
 WorkflowAction GetWorkflowActionWithApprovalMessagesDetails(long idWorkflowAction,bool shouldRemap = false);
           List<ApprovalMessage> UpdateApprovalMessagesForWorkflowActionWithoutSavingNewItem(List<ApprovalMessage> newApprovalMessages,long idWorkflowAction);
    List<ApprovalMessage> UpdateApprovalMessagesForWorkflowActionWithoutSavingNewItem(List<ApprovalMessage> newApprovalMessages,long idWorkflowAction,SubscriptionEntities db);
          

    List<ApprovalMessage> UpdateApprovalMessagesForWorkflowAction(List<ApprovalMessage> newApprovalMessages,long idWorkflowAction);
    List<ApprovalMessage> UpdateApprovalMessagesForWorkflowAction(List<ApprovalMessage> newApprovalMessages,long idWorkflowAction,SubscriptionEntities db);
                           



 WorkflowAction GetWorkflowActionWithWorkflowDetails(long idWorkflowAction,bool shouldRemap = false);
    


 WorkflowAction GetWorkflowActionWithWorkflowTransitionsDetails(long idWorkflowAction,bool shouldRemap = false);
           List<WorkflowTransition> UpdateWorkflowTransitionsForWorkflowActionWithoutSavingNewItem(List<WorkflowTransition> newWorkflowTransitions,long idWorkflowAction);
    List<WorkflowTransition> UpdateWorkflowTransitionsForWorkflowActionWithoutSavingNewItem(List<WorkflowTransition> newWorkflowTransitions,long idWorkflowAction,SubscriptionEntities db);
          

    List<WorkflowTransition> UpdateWorkflowTransitionsForWorkflowAction(List<WorkflowTransition> newWorkflowTransitions,long idWorkflowAction);
    List<WorkflowTransition> UpdateWorkflowTransitionsForWorkflowAction(List<WorkflowTransition> newWorkflowTransitions,long idWorkflowAction,SubscriptionEntities db);
                           



 WorkflowAction GetWorkflowActionCustom( Expression<Func<WorkflowAction, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 WorkflowAction GetWorkflowActionCustom(SubscriptionEntities db, Expression<Func<WorkflowAction, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<WorkflowAction> GetWorkflowActionCustomList( Expression<Func<WorkflowAction, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<WorkflowAction, dynamic> orderExpression = null);
 BaseListReturnType<WorkflowAction> GetWorkflowActionCustomList( SubscriptionEntities db , Expression<Func<WorkflowAction, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<WorkflowAction, dynamic> orderExpression = null);
 WorkflowAction GetWorkflowActionWithDetails(long idWorkflowAction, List<string> includes = null,bool shouldRemap = false);
 WorkflowAction GetWorkflowActionWithDetails(long idWorkflowAction, SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 WorkflowAction GetWorkflowActionWitDetails(long idWorkflowAction,bool shouldRemap = false);
 WorkflowAction GetWorkflowActionWitDetails(long idWorkflowAction, SubscriptionEntities db,bool shouldRemap = false);
 void SaveWorkflowAction(WorkflowAction workflowAction);
 void SaveWorkflowAction(WorkflowAction workflowAction, SubscriptionEntities db);
 void SaveOnlyWorkflowAction(WorkflowAction workflowAction);
 void SaveOnlyWorkflowAction(WorkflowAction workflowAction, SubscriptionEntities db);
 void DeleteWorkflowAction(WorkflowAction workflowAction);
 void DeleteWorkflowAction(WorkflowAction workflowAction, SubscriptionEntities db);		
  void DeletePermanentlyWorkflowAction(WorkflowAction workflowAction);
 void DeletePermanentlyWorkflowAction(WorkflowAction workflowAction, SubscriptionEntities db);	
	}
 	public partial interface IWorkflowRoleDao
	{
  List<WorkflowRole> GetAllWorkflowRoles(bool shouldRemap = false);
  List<WorkflowRole> GetAllWorkflowRoles(SubscriptionEntities db,bool shouldRemap = false);
  BaseListReturnType<WorkflowRole> GetAllWorkflowRolesByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<WorkflowRole, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<WorkflowRole, dynamic> orderExpression = null);
  BaseListReturnType<WorkflowRole> GetAllWorkflowRolesByPage(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<WorkflowRole, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<WorkflowRole, dynamic> orderExpression = null);
  
  BaseListReturnType<WorkflowRole> GetAllWorkflowRolesByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<WorkflowRole, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<WorkflowRole, dynamic> orderExpression = null);
  BaseListReturnType<WorkflowRole> GetAllWorkflowRolesByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<WorkflowRole, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<WorkflowRole, dynamic> orderExpression = null);

 BaseListReturnType<WorkflowRole> GetAllWorkflowRolesWithWorkflowDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<WorkflowRole, bool>> expression = null,bool shouldRemap = false, Func<WorkflowRole, dynamic> orderExpression = null);
 BaseListReturnType<WorkflowRole> GetAllWorkflowRolesWithWorkflowDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<WorkflowRole, bool>> expression = null,bool shouldRemap = false, Func<WorkflowRole, dynamic> orderExpression = null);






BaseListReturnType<WorkflowRole> GetAllWorkflowRoleListByWorkflow(long idWorkflow);

BaseListReturnType<WorkflowRole> GetAllWorkflowRoleListByWorkflow(long idWorkflow, SubscriptionEntities db);

BaseListReturnType<WorkflowRole> GetAllWorkflowRoleListByWorkflowByPage(long idWorkflow, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<WorkflowRole> GetAllWorkflowRoleListByWorkflowByPage(long idWorkflow, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);



 BaseListReturnType<WorkflowRole> GetAllWorkflowRolesWithWorkflowTransitionsDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<WorkflowRole, bool>> expression = null,bool shouldRemap = false, Func<WorkflowRole, dynamic> orderExpression = null);
 BaseListReturnType<WorkflowRole> GetAllWorkflowRolesWithWorkflowTransitionsDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<WorkflowRole, bool>> expression = null,bool shouldRemap = false, Func<WorkflowRole, dynamic> orderExpression = null);


List<WorkflowRole> GetWorkflowRoleListByIdList(List<long> workflowRoleIds);

List<WorkflowRole> GetWorkflowRoleListByIdList(List<long> workflowRoleIds, SubscriptionEntities db);

 BaseListReturnType<WorkflowRole> GetAllWorkflowRolesWithWorkflowDetails(bool shouldRemap = false);
 BaseListReturnType<WorkflowRole> GetAllWorkflowRolesWithWorkflowTransitionsDetails(bool shouldRemap = false);
 BaseListReturnType<WorkflowRole> GetAllWorkflowRoleWitDetails( List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<WorkflowRole> GetAllWorkflowRoleWitDetails( SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 WorkflowRole GetWorkflowRole(long idWorkflowRole,bool shouldRemap = false);
 WorkflowRole GetWorkflowRole(long idWorkflowRole, SubscriptionEntities db,bool shouldRemap = false);
 WorkflowRole GetWorkflowRoleWithWorkflowDetails(long idWorkflowRole,bool shouldRemap = false);
    


 WorkflowRole GetWorkflowRoleWithWorkflowTransitionsDetails(long idWorkflowRole,bool shouldRemap = false);
           List<WorkflowTransition> UpdateWorkflowTransitionsForWorkflowRoleWithoutSavingNewItem(List<WorkflowTransition> newWorkflowTransitions,long idWorkflowRole);
    List<WorkflowTransition> UpdateWorkflowTransitionsForWorkflowRoleWithoutSavingNewItem(List<WorkflowTransition> newWorkflowTransitions,long idWorkflowRole,SubscriptionEntities db);
          

    List<WorkflowTransition> UpdateWorkflowTransitionsForWorkflowRole(List<WorkflowTransition> newWorkflowTransitions,long idWorkflowRole);
    List<WorkflowTransition> UpdateWorkflowTransitionsForWorkflowRole(List<WorkflowTransition> newWorkflowTransitions,long idWorkflowRole,SubscriptionEntities db);
                           



 WorkflowRole GetWorkflowRoleCustom( Expression<Func<WorkflowRole, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 WorkflowRole GetWorkflowRoleCustom(SubscriptionEntities db, Expression<Func<WorkflowRole, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<WorkflowRole> GetWorkflowRoleCustomList( Expression<Func<WorkflowRole, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<WorkflowRole, dynamic> orderExpression = null);
 BaseListReturnType<WorkflowRole> GetWorkflowRoleCustomList( SubscriptionEntities db , Expression<Func<WorkflowRole, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<WorkflowRole, dynamic> orderExpression = null);
 WorkflowRole GetWorkflowRoleWithDetails(long idWorkflowRole, List<string> includes = null,bool shouldRemap = false);
 WorkflowRole GetWorkflowRoleWithDetails(long idWorkflowRole, SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 WorkflowRole GetWorkflowRoleWitDetails(long idWorkflowRole,bool shouldRemap = false);
 WorkflowRole GetWorkflowRoleWitDetails(long idWorkflowRole, SubscriptionEntities db,bool shouldRemap = false);
 void SaveWorkflowRole(WorkflowRole workflowRole);
 void SaveWorkflowRole(WorkflowRole workflowRole, SubscriptionEntities db);
 void SaveOnlyWorkflowRole(WorkflowRole workflowRole);
 void SaveOnlyWorkflowRole(WorkflowRole workflowRole, SubscriptionEntities db);
 void DeleteWorkflowRole(WorkflowRole workflowRole);
 void DeleteWorkflowRole(WorkflowRole workflowRole, SubscriptionEntities db);		
  void DeletePermanentlyWorkflowRole(WorkflowRole workflowRole);
 void DeletePermanentlyWorkflowRole(WorkflowRole workflowRole, SubscriptionEntities db);	
	}
 	public partial interface IWorkflowStateDao
	{
  List<WorkflowState> GetAllWorkflowStates(bool shouldRemap = false);
  List<WorkflowState> GetAllWorkflowStates(SubscriptionEntities db,bool shouldRemap = false);
  BaseListReturnType<WorkflowState> GetAllWorkflowStatesByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<WorkflowState, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<WorkflowState, dynamic> orderExpression = null);
  BaseListReturnType<WorkflowState> GetAllWorkflowStatesByPage(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<WorkflowState, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<WorkflowState, dynamic> orderExpression = null);
  
  BaseListReturnType<WorkflowState> GetAllWorkflowStatesByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<WorkflowState, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<WorkflowState, dynamic> orderExpression = null);
  BaseListReturnType<WorkflowState> GetAllWorkflowStatesByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<WorkflowState, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<WorkflowState, dynamic> orderExpression = null);

 BaseListReturnType<WorkflowState> GetAllWorkflowStatesWithRequestsDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<WorkflowState, bool>> expression = null,bool shouldRemap = false, Func<WorkflowState, dynamic> orderExpression = null);
 BaseListReturnType<WorkflowState> GetAllWorkflowStatesWithRequestsDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<WorkflowState, bool>> expression = null,bool shouldRemap = false, Func<WorkflowState, dynamic> orderExpression = null);

 BaseListReturnType<WorkflowState> GetAllWorkflowStatesWithWorkflowDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<WorkflowState, bool>> expression = null,bool shouldRemap = false, Func<WorkflowState, dynamic> orderExpression = null);
 BaseListReturnType<WorkflowState> GetAllWorkflowStatesWithWorkflowDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<WorkflowState, bool>> expression = null,bool shouldRemap = false, Func<WorkflowState, dynamic> orderExpression = null);






BaseListReturnType<WorkflowState> GetAllWorkflowStateListByWorkflow(long idWorkflow);

BaseListReturnType<WorkflowState> GetAllWorkflowStateListByWorkflow(long idWorkflow, SubscriptionEntities db);

BaseListReturnType<WorkflowState> GetAllWorkflowStateListByWorkflowByPage(long idWorkflow, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<WorkflowState> GetAllWorkflowStateListByWorkflowByPage(long idWorkflow, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);



 BaseListReturnType<WorkflowState> GetAllWorkflowStatesWithWorkflowTransitionsDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<WorkflowState, bool>> expression = null,bool shouldRemap = false, Func<WorkflowState, dynamic> orderExpression = null);
 BaseListReturnType<WorkflowState> GetAllWorkflowStatesWithWorkflowTransitionsDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<WorkflowState, bool>> expression = null,bool shouldRemap = false, Func<WorkflowState, dynamic> orderExpression = null);

 BaseListReturnType<WorkflowState> GetAllWorkflowStatesWithWorkflowTransitions1DetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<WorkflowState, bool>> expression = null,bool shouldRemap = false, Func<WorkflowState, dynamic> orderExpression = null);
 BaseListReturnType<WorkflowState> GetAllWorkflowStatesWithWorkflowTransitions1DetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<WorkflowState, bool>> expression = null,bool shouldRemap = false, Func<WorkflowState, dynamic> orderExpression = null);


List<WorkflowState> GetWorkflowStateListByIdList(List<long> workflowStateIds);

List<WorkflowState> GetWorkflowStateListByIdList(List<long> workflowStateIds, SubscriptionEntities db);

 BaseListReturnType<WorkflowState> GetAllWorkflowStatesWithRequestsDetails(bool shouldRemap = false);
 BaseListReturnType<WorkflowState> GetAllWorkflowStatesWithWorkflowDetails(bool shouldRemap = false);
 BaseListReturnType<WorkflowState> GetAllWorkflowStatesWithWorkflowTransitionsDetails(bool shouldRemap = false);
 BaseListReturnType<WorkflowState> GetAllWorkflowStatesWithWorkflowTransitions1Details(bool shouldRemap = false);
 BaseListReturnType<WorkflowState> GetAllWorkflowStateWitDetails( List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<WorkflowState> GetAllWorkflowStateWitDetails( SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 WorkflowState GetWorkflowState(long idWorkflowState,bool shouldRemap = false);
 WorkflowState GetWorkflowState(long idWorkflowState, SubscriptionEntities db,bool shouldRemap = false);
 WorkflowState GetWorkflowStateWithRequestsDetails(long idWorkflowState,bool shouldRemap = false);
           List<Request> UpdateRequestsForWorkflowStateWithoutSavingNewItem(List<Request> newRequests,long idWorkflowState);
    List<Request> UpdateRequestsForWorkflowStateWithoutSavingNewItem(List<Request> newRequests,long idWorkflowState,SubscriptionEntities db);
          

    List<Request> UpdateRequestsForWorkflowState(List<Request> newRequests,long idWorkflowState);
    List<Request> UpdateRequestsForWorkflowState(List<Request> newRequests,long idWorkflowState,SubscriptionEntities db);
                           



 WorkflowState GetWorkflowStateWithWorkflowDetails(long idWorkflowState,bool shouldRemap = false);
    


 WorkflowState GetWorkflowStateWithWorkflowTransitionsDetails(long idWorkflowState,bool shouldRemap = false);
           List<WorkflowTransition> UpdateWorkflowTransitionsForWorkflowStateWithoutSavingNewItem(List<WorkflowTransition> newWorkflowTransitions,long idWorkflowState);
    List<WorkflowTransition> UpdateWorkflowTransitionsForWorkflowStateWithoutSavingNewItem(List<WorkflowTransition> newWorkflowTransitions,long idWorkflowState,SubscriptionEntities db);
          

    List<WorkflowTransition> UpdateWorkflowTransitionsForWorkflowState(List<WorkflowTransition> newWorkflowTransitions,long idWorkflowState);
    List<WorkflowTransition> UpdateWorkflowTransitionsForWorkflowState(List<WorkflowTransition> newWorkflowTransitions,long idWorkflowState,SubscriptionEntities db);
                           



 WorkflowState GetWorkflowStateWithWorkflowTransitions1Details(long idWorkflowState,bool shouldRemap = false);
           List<WorkflowTransition> UpdateWorkflowTransitions1ForWorkflowStateWithoutSavingNewItem(List<WorkflowTransition> newWorkflowTransitions,long idWorkflowState);
    List<WorkflowTransition> UpdateWorkflowTransitions1ForWorkflowStateWithoutSavingNewItem(List<WorkflowTransition> newWorkflowTransitions,long idWorkflowState,SubscriptionEntities db);
          

    List<WorkflowTransition> UpdateWorkflowTransitions1ForWorkflowState(List<WorkflowTransition> newWorkflowTransitions,long idWorkflowState);
    List<WorkflowTransition> UpdateWorkflowTransitions1ForWorkflowState(List<WorkflowTransition> newWorkflowTransitions,long idWorkflowState,SubscriptionEntities db);
                           



 WorkflowState GetWorkflowStateCustom( Expression<Func<WorkflowState, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 WorkflowState GetWorkflowStateCustom(SubscriptionEntities db, Expression<Func<WorkflowState, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<WorkflowState> GetWorkflowStateCustomList( Expression<Func<WorkflowState, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<WorkflowState, dynamic> orderExpression = null);
 BaseListReturnType<WorkflowState> GetWorkflowStateCustomList( SubscriptionEntities db , Expression<Func<WorkflowState, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<WorkflowState, dynamic> orderExpression = null);
 WorkflowState GetWorkflowStateWithDetails(long idWorkflowState, List<string> includes = null,bool shouldRemap = false);
 WorkflowState GetWorkflowStateWithDetails(long idWorkflowState, SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 WorkflowState GetWorkflowStateWitDetails(long idWorkflowState,bool shouldRemap = false);
 WorkflowState GetWorkflowStateWitDetails(long idWorkflowState, SubscriptionEntities db,bool shouldRemap = false);
 void SaveWorkflowState(WorkflowState workflowState);
 void SaveWorkflowState(WorkflowState workflowState, SubscriptionEntities db);
 void SaveOnlyWorkflowState(WorkflowState workflowState);
 void SaveOnlyWorkflowState(WorkflowState workflowState, SubscriptionEntities db);
 void DeleteWorkflowState(WorkflowState workflowState);
 void DeleteWorkflowState(WorkflowState workflowState, SubscriptionEntities db);		
  void DeletePermanentlyWorkflowState(WorkflowState workflowState);
 void DeletePermanentlyWorkflowState(WorkflowState workflowState, SubscriptionEntities db);	
	}
 	public partial interface IWorkflowTransitionDao
	{
  List<WorkflowTransition> GetAllWorkflowTransitions(bool shouldRemap = false);
  List<WorkflowTransition> GetAllWorkflowTransitions(SubscriptionEntities db,bool shouldRemap = false);
  BaseListReturnType<WorkflowTransition> GetAllWorkflowTransitionsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<WorkflowTransition, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<WorkflowTransition, dynamic> orderExpression = null);
  BaseListReturnType<WorkflowTransition> GetAllWorkflowTransitionsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<WorkflowTransition, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<WorkflowTransition, dynamic> orderExpression = null);
  
  BaseListReturnType<WorkflowTransition> GetAllWorkflowTransitionsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<WorkflowTransition, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<WorkflowTransition, dynamic> orderExpression = null);
  BaseListReturnType<WorkflowTransition> GetAllWorkflowTransitionsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<WorkflowTransition, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<WorkflowTransition, dynamic> orderExpression = null);

 BaseListReturnType<WorkflowTransition> GetAllWorkflowTransitionsWithWorkflowActionDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<WorkflowTransition, bool>> expression = null,bool shouldRemap = false, Func<WorkflowTransition, dynamic> orderExpression = null);
 BaseListReturnType<WorkflowTransition> GetAllWorkflowTransitionsWithWorkflowActionDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<WorkflowTransition, bool>> expression = null,bool shouldRemap = false, Func<WorkflowTransition, dynamic> orderExpression = null);






BaseListReturnType<WorkflowTransition> GetAllWorkflowTransitionListByWorkflowAction(long idWorkflowAction);

BaseListReturnType<WorkflowTransition> GetAllWorkflowTransitionListByWorkflowAction(long idWorkflowAction, SubscriptionEntities db);

BaseListReturnType<WorkflowTransition> GetAllWorkflowTransitionListByWorkflowActionByPage(long idWorkflowAction, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<WorkflowTransition> GetAllWorkflowTransitionListByWorkflowActionByPage(long idWorkflowAction, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);



 BaseListReturnType<WorkflowTransition> GetAllWorkflowTransitionsWithWorkflowRoleDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<WorkflowTransition, bool>> expression = null,bool shouldRemap = false, Func<WorkflowTransition, dynamic> orderExpression = null);
 BaseListReturnType<WorkflowTransition> GetAllWorkflowTransitionsWithWorkflowRoleDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<WorkflowTransition, bool>> expression = null,bool shouldRemap = false, Func<WorkflowTransition, dynamic> orderExpression = null);






BaseListReturnType<WorkflowTransition> GetAllWorkflowTransitionListByWorkflowRole(long idWorkflowRole);

BaseListReturnType<WorkflowTransition> GetAllWorkflowTransitionListByWorkflowRole(long idWorkflowRole, SubscriptionEntities db);

BaseListReturnType<WorkflowTransition> GetAllWorkflowTransitionListByWorkflowRoleByPage(long idWorkflowRole, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<WorkflowTransition> GetAllWorkflowTransitionListByWorkflowRoleByPage(long idWorkflowRole, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);



 BaseListReturnType<WorkflowTransition> GetAllWorkflowTransitionsWithWorkflowStateDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<WorkflowTransition, bool>> expression = null,bool shouldRemap = false, Func<WorkflowTransition, dynamic> orderExpression = null);
 BaseListReturnType<WorkflowTransition> GetAllWorkflowTransitionsWithWorkflowStateDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<WorkflowTransition, bool>> expression = null,bool shouldRemap = false, Func<WorkflowTransition, dynamic> orderExpression = null);






BaseListReturnType<WorkflowTransition> GetAllWorkflowTransitionListByWorkflowState(long idWorkflowState);

BaseListReturnType<WorkflowTransition> GetAllWorkflowTransitionListByWorkflowState(long idWorkflowState, SubscriptionEntities db);

BaseListReturnType<WorkflowTransition> GetAllWorkflowTransitionListByWorkflowStateByPage(long idWorkflowState, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<WorkflowTransition> GetAllWorkflowTransitionListByWorkflowStateByPage(long idWorkflowState, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);



 BaseListReturnType<WorkflowTransition> GetAllWorkflowTransitionsWithWorkflowState1DetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<WorkflowTransition, bool>> expression = null,bool shouldRemap = false, Func<WorkflowTransition, dynamic> orderExpression = null);
 BaseListReturnType<WorkflowTransition> GetAllWorkflowTransitionsWithWorkflowState1DetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<WorkflowTransition, bool>> expression = null,bool shouldRemap = false, Func<WorkflowTransition, dynamic> orderExpression = null);






BaseListReturnType<WorkflowTransition> GetAllWorkflowTransitionListByWorkflowState1(long idWorkflowState1);

BaseListReturnType<WorkflowTransition> GetAllWorkflowTransitionListByWorkflowState1(long idWorkflowState1, SubscriptionEntities db);

BaseListReturnType<WorkflowTransition> GetAllWorkflowTransitionListByWorkflowState1ByPage(long idWorkflowState1, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<WorkflowTransition> GetAllWorkflowTransitionListByWorkflowState1ByPage(long idWorkflowState1, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);



 BaseListReturnType<WorkflowTransition> GetAllWorkflowTransitionsWithWorkflowTransitionOnExecutesDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<WorkflowTransition, bool>> expression = null,bool shouldRemap = false, Func<WorkflowTransition, dynamic> orderExpression = null);
 BaseListReturnType<WorkflowTransition> GetAllWorkflowTransitionsWithWorkflowTransitionOnExecutesDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<WorkflowTransition, bool>> expression = null,bool shouldRemap = false, Func<WorkflowTransition, dynamic> orderExpression = null);


List<WorkflowTransition> GetWorkflowTransitionListByIdList(List<long> workflowTransitionIds);

List<WorkflowTransition> GetWorkflowTransitionListByIdList(List<long> workflowTransitionIds, SubscriptionEntities db);

 BaseListReturnType<WorkflowTransition> GetAllWorkflowTransitionsWithWorkflowActionDetails(bool shouldRemap = false);
 BaseListReturnType<WorkflowTransition> GetAllWorkflowTransitionsWithWorkflowRoleDetails(bool shouldRemap = false);
 BaseListReturnType<WorkflowTransition> GetAllWorkflowTransitionsWithWorkflowStateDetails(bool shouldRemap = false);
 BaseListReturnType<WorkflowTransition> GetAllWorkflowTransitionsWithWorkflowState1Details(bool shouldRemap = false);
 BaseListReturnType<WorkflowTransition> GetAllWorkflowTransitionsWithWorkflowTransitionOnExecutesDetails(bool shouldRemap = false);
 BaseListReturnType<WorkflowTransition> GetAllWorkflowTransitionWitDetails( List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<WorkflowTransition> GetAllWorkflowTransitionWitDetails( SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 WorkflowTransition GetWorkflowTransition(long idWorkflowTransition,bool shouldRemap = false);
 WorkflowTransition GetWorkflowTransition(long idWorkflowTransition, SubscriptionEntities db,bool shouldRemap = false);
 WorkflowTransition GetWorkflowTransitionWithWorkflowActionDetails(long idWorkflowTransition,bool shouldRemap = false);
    


 WorkflowTransition GetWorkflowTransitionWithWorkflowRoleDetails(long idWorkflowTransition,bool shouldRemap = false);
    


 WorkflowTransition GetWorkflowTransitionWithWorkflowStateDetails(long idWorkflowTransition,bool shouldRemap = false);
    


 WorkflowTransition GetWorkflowTransitionWithWorkflowState1Details(long idWorkflowTransition,bool shouldRemap = false);
    


 WorkflowTransition GetWorkflowTransitionWithWorkflowTransitionOnExecutesDetails(long idWorkflowTransition,bool shouldRemap = false);
           List<WorkflowTransitionOnExecute> UpdateWorkflowTransitionOnExecutesForWorkflowTransitionWithoutSavingNewItem(List<WorkflowTransitionOnExecute> newWorkflowTransitionOnExecutes,long idWorkflowTransition);
    List<WorkflowTransitionOnExecute> UpdateWorkflowTransitionOnExecutesForWorkflowTransitionWithoutSavingNewItem(List<WorkflowTransitionOnExecute> newWorkflowTransitionOnExecutes,long idWorkflowTransition,SubscriptionEntities db);
          

    List<WorkflowTransitionOnExecute> UpdateWorkflowTransitionOnExecutesForWorkflowTransition(List<WorkflowTransitionOnExecute> newWorkflowTransitionOnExecutes,long idWorkflowTransition);
    List<WorkflowTransitionOnExecute> UpdateWorkflowTransitionOnExecutesForWorkflowTransition(List<WorkflowTransitionOnExecute> newWorkflowTransitionOnExecutes,long idWorkflowTransition,SubscriptionEntities db);
                           



 WorkflowTransition GetWorkflowTransitionCustom( Expression<Func<WorkflowTransition, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 WorkflowTransition GetWorkflowTransitionCustom(SubscriptionEntities db, Expression<Func<WorkflowTransition, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<WorkflowTransition> GetWorkflowTransitionCustomList( Expression<Func<WorkflowTransition, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<WorkflowTransition, dynamic> orderExpression = null);
 BaseListReturnType<WorkflowTransition> GetWorkflowTransitionCustomList( SubscriptionEntities db , Expression<Func<WorkflowTransition, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<WorkflowTransition, dynamic> orderExpression = null);
 WorkflowTransition GetWorkflowTransitionWithDetails(long idWorkflowTransition, List<string> includes = null,bool shouldRemap = false);
 WorkflowTransition GetWorkflowTransitionWithDetails(long idWorkflowTransition, SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 WorkflowTransition GetWorkflowTransitionWitDetails(long idWorkflowTransition,bool shouldRemap = false);
 WorkflowTransition GetWorkflowTransitionWitDetails(long idWorkflowTransition, SubscriptionEntities db,bool shouldRemap = false);
 void SaveWorkflowTransition(WorkflowTransition workflowTransition);
 void SaveWorkflowTransition(WorkflowTransition workflowTransition, SubscriptionEntities db);
 void SaveOnlyWorkflowTransition(WorkflowTransition workflowTransition);
 void SaveOnlyWorkflowTransition(WorkflowTransition workflowTransition, SubscriptionEntities db);
 void DeleteWorkflowTransition(WorkflowTransition workflowTransition);
 void DeleteWorkflowTransition(WorkflowTransition workflowTransition, SubscriptionEntities db);		
  void DeletePermanentlyWorkflowTransition(WorkflowTransition workflowTransition);
 void DeletePermanentlyWorkflowTransition(WorkflowTransition workflowTransition, SubscriptionEntities db);	
	}
 	public partial interface IWorkflowTransitionOnExecuteDao
	{
  List<WorkflowTransitionOnExecute> GetAllWorkflowTransitionOnExecutes(bool shouldRemap = false);
  List<WorkflowTransitionOnExecute> GetAllWorkflowTransitionOnExecutes(SubscriptionEntities db,bool shouldRemap = false);
  BaseListReturnType<WorkflowTransitionOnExecute> GetAllWorkflowTransitionOnExecutesByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<WorkflowTransitionOnExecute, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<WorkflowTransitionOnExecute, dynamic> orderExpression = null);
  BaseListReturnType<WorkflowTransitionOnExecute> GetAllWorkflowTransitionOnExecutesByPage(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<WorkflowTransitionOnExecute, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<WorkflowTransitionOnExecute, dynamic> orderExpression = null);
  
  BaseListReturnType<WorkflowTransitionOnExecute> GetAllWorkflowTransitionOnExecutesByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<WorkflowTransitionOnExecute, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<WorkflowTransitionOnExecute, dynamic> orderExpression = null);
  BaseListReturnType<WorkflowTransitionOnExecute> GetAllWorkflowTransitionOnExecutesByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<WorkflowTransitionOnExecute, bool>> expression = null, List<string> includes = null,bool shouldRemap = false, Func<WorkflowTransitionOnExecute, dynamic> orderExpression = null);

 BaseListReturnType<WorkflowTransitionOnExecute> GetAllWorkflowTransitionOnExecutesWithWorkflowTransitionDetailsByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<WorkflowTransitionOnExecute, bool>> expression = null,bool shouldRemap = false, Func<WorkflowTransitionOnExecute, dynamic> orderExpression = null);
 BaseListReturnType<WorkflowTransitionOnExecute> GetAllWorkflowTransitionOnExecutesWithWorkflowTransitionDetailsByPageWithMyExpression(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<WorkflowTransitionOnExecute, bool>> expression = null,bool shouldRemap = false, Func<WorkflowTransitionOnExecute, dynamic> orderExpression = null);






BaseListReturnType<WorkflowTransitionOnExecute> GetAllWorkflowTransitionOnExecuteListByWorkflowTransition(long idWorkflowTransition);

BaseListReturnType<WorkflowTransitionOnExecute> GetAllWorkflowTransitionOnExecuteListByWorkflowTransition(long idWorkflowTransition, SubscriptionEntities db);

BaseListReturnType<WorkflowTransitionOnExecute> GetAllWorkflowTransitionOnExecuteListByWorkflowTransitionByPage(long idWorkflowTransition, Business.Common.SortingPagingInfo sortingPagingInfo);

BaseListReturnType<WorkflowTransitionOnExecute> GetAllWorkflowTransitionOnExecuteListByWorkflowTransitionByPage(long idWorkflowTransition, Business.Common.SortingPagingInfo sortingPagingInfo,SubscriptionEntities db);




List<WorkflowTransitionOnExecute> GetWorkflowTransitionOnExecuteListByIdList(List<long> workflowTransitionOnExecuteIds);

List<WorkflowTransitionOnExecute> GetWorkflowTransitionOnExecuteListByIdList(List<long> workflowTransitionOnExecuteIds, SubscriptionEntities db);

 BaseListReturnType<WorkflowTransitionOnExecute> GetAllWorkflowTransitionOnExecutesWithWorkflowTransitionDetails(bool shouldRemap = false);
 BaseListReturnType<WorkflowTransitionOnExecute> GetAllWorkflowTransitionOnExecuteWitDetails( List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<WorkflowTransitionOnExecute> GetAllWorkflowTransitionOnExecuteWitDetails( SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 WorkflowTransitionOnExecute GetWorkflowTransitionOnExecute(long idWorkflowTransitionOnExecute,bool shouldRemap = false);
 WorkflowTransitionOnExecute GetWorkflowTransitionOnExecute(long idWorkflowTransitionOnExecute, SubscriptionEntities db,bool shouldRemap = false);
 WorkflowTransitionOnExecute GetWorkflowTransitionOnExecuteWithWorkflowTransitionDetails(long idWorkflowTransitionOnExecute,bool shouldRemap = false);
    


 WorkflowTransitionOnExecute GetWorkflowTransitionOnExecuteCustom( Expression<Func<WorkflowTransitionOnExecute, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 WorkflowTransitionOnExecute GetWorkflowTransitionOnExecuteCustom(SubscriptionEntities db, Expression<Func<WorkflowTransitionOnExecute, bool>> expression, List<string> includes = null,bool shouldRemap = false);
 BaseListReturnType<WorkflowTransitionOnExecute> GetWorkflowTransitionOnExecuteCustomList( Expression<Func<WorkflowTransitionOnExecute, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<WorkflowTransitionOnExecute, dynamic> orderExpression = null);
 BaseListReturnType<WorkflowTransitionOnExecute> GetWorkflowTransitionOnExecuteCustomList( SubscriptionEntities db , Expression<Func<WorkflowTransitionOnExecute, bool>> expression, List<string> includes = null,bool shouldRemap = false, Func<WorkflowTransitionOnExecute, dynamic> orderExpression = null);
 WorkflowTransitionOnExecute GetWorkflowTransitionOnExecuteWithDetails(long idWorkflowTransitionOnExecute, List<string> includes = null,bool shouldRemap = false);
 WorkflowTransitionOnExecute GetWorkflowTransitionOnExecuteWithDetails(long idWorkflowTransitionOnExecute, SubscriptionEntities db, List<string> includes = null,bool shouldRemap = false);
 WorkflowTransitionOnExecute GetWorkflowTransitionOnExecuteWitDetails(long idWorkflowTransitionOnExecute,bool shouldRemap = false);
 WorkflowTransitionOnExecute GetWorkflowTransitionOnExecuteWitDetails(long idWorkflowTransitionOnExecute, SubscriptionEntities db,bool shouldRemap = false);
 void SaveWorkflowTransitionOnExecute(WorkflowTransitionOnExecute workflowTransitionOnExecute);
 void SaveWorkflowTransitionOnExecute(WorkflowTransitionOnExecute workflowTransitionOnExecute, SubscriptionEntities db);
 void SaveOnlyWorkflowTransitionOnExecute(WorkflowTransitionOnExecute workflowTransitionOnExecute);
 void SaveOnlyWorkflowTransitionOnExecute(WorkflowTransitionOnExecute workflowTransitionOnExecute, SubscriptionEntities db);
 void DeleteWorkflowTransitionOnExecute(WorkflowTransitionOnExecute workflowTransitionOnExecute);
 void DeleteWorkflowTransitionOnExecute(WorkflowTransitionOnExecute workflowTransitionOnExecute, SubscriptionEntities db);		
  void DeletePermanentlyWorkflowTransitionOnExecute(WorkflowTransitionOnExecute workflowTransitionOnExecute);
 void DeletePermanentlyWorkflowTransitionOnExecute(WorkflowTransitionOnExecute workflowTransitionOnExecute, SubscriptionEntities db);	
	}
}

	