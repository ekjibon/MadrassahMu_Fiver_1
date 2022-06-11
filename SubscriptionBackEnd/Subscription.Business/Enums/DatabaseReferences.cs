using System;
using Subscription.Business;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Subscription.Business.Enums
{
public static class AddressDatabaseReferences {
public static string COMPANYLOCATIONS = "CompanyLocations";
public static string CITY1 = "City1";
public static string COUNTRY = "Country";
public static string CONTACTS = "Contacts";
public static string PERSON_ADDRESS = "Person_Address";
}
public static class ApprovalMessageDatabaseReferences {
public static string WORKFLOWACTION = "WorkflowAction";
public static string WORKFLOW = "Workflow";
}
public static class BankDatabaseReferences {
public static string BANKSTATEMENTSTAGINGS = "BankStatementStagings";
public static string PAYMENTMETHOD = "PaymentMethod";
public static string TRANSACTIONACCOUNT = "TransactionAccount";
public static string TRANSACTIONTEMPLATE = "TransactionTemplate";
public static string PAYMENTDETAILS = "PaymentDetails";
}
public static class BankReconHitTypeDatabaseReferences {
public static string BANKSTATEMENTSTAGINGHITS = "BankStatementStagingHits";
}
public static class BankReconOrderProcessStateDatabaseReferences {
public static string BANKSTATEMENTSTAGINGS = "BankStatementStagings";
}
public static class BankReconOrderTypeDatabaseReferences {
public static string BANKSTATEMENTSTAGINGDETAILS = "BankStatementStagingDetails";
}
public static class BankStatementHitListDatabaseReferences {
public static string BANKSTATEMENTSTAGINGDETAIL = "BankStatementStagingDetail";
public static string BANKSTATEMENTHITLIST_TRANSACTIONPRESET = "BankStatementHitList_TransactionPreset";
public static string BANKSTATEMENTSTAGINGHITS = "BankStatementStagingHits";
public static string TEMPORARYTRANSACTIONS = "TemporaryTransactions";
}
public static class BankStatementHitList_TransactionPresetDatabaseReferences {
public static string BANKSTATEMENTHITLIST = "BankStatementHitList";
public static string TRANSACTIONPRESET = "TransactionPreset";
}
public static class BankStatementStagingDatabaseReferences {
public static string BANKRECONORDERPROCESSSTATE = "BankReconOrderProcessState";
public static string BANK = "Bank";
public static string BANKSTATEMENTSTAGINGSTATE = "BankStatementStagingState";
public static string DOCUMENT = "Document";
public static string USER = "User";
public static string BANKSTATEMENTSTAGINGDETAILS = "BankStatementStagingDetails";
}
public static class BankStatementStagingDetailDatabaseReferences {
public static string BANKRECONORDERTYPE = "BankReconOrderType";
public static string BANKSTATEMENTHITLISTS = "BankStatementHitLists";
public static string BANKSTATEMENTSTAGING = "BankStatementStaging";
public static string BANKSTATEMENTSTAGINGDETAILBATCH = "BankStatementStagingDetailBatch";
public static string BANKSTATEMENTSTAGINGHITS = "BankStatementStagingHits";
public static string TEMPORARYTRANSACTIONS = "TemporaryTransactions";
public static string TRANSACTION_BANKSTATEMENTSTAGINGDETAIL = "Transaction_BankStatementStagingDetail";
}
public static class BankStatementStagingDetailBatchDatabaseReferences {
public static string BANKSTATEMENTSTAGINGDETAILS = "BankStatementStagingDetails";
public static string BANKSTATEMENTSTAGINGSTATE = "BankStatementStagingState";
}
public static class BankStatementStagingHitDatabaseReferences {
public static string BANKSTATEMENTHITLIST = "BankStatementHitList";
public static string BANKSTATEMENTSTAGINGDETAIL = "BankStatementStagingDetail";
public static string BANKRECONHITTYPE = "BankReconHitType";
public static string ORDER = "Order";
public static string BANKSTATEMENTSTAGINGHIT_TRANSACTIONPRESET = "BankStatementStagingHit_TransactionPreset";
public static string TEMPORARYTRANSACTIONS = "TemporaryTransactions";
}
public static class BankStatementStagingHit_TransactionPresetDatabaseReferences {
public static string BANKSTATEMENTSTAGINGHIT = "BankStatementStagingHit";
public static string TRANSACTIONPRESET = "TransactionPreset";
}
public static class BankStatementStagingStateDatabaseReferences {
public static string BANKSTATEMENTSTAGINGS = "BankStatementStagings";
public static string BANKSTATEMENTSTAGINGDETAILBATCHES = "BankStatementStagingDetailBatches";
}
public static class CityDatabaseReferences {
public static string ADDRESSES = "Addresses";
public static string COUNTRY = "Country";
}
public static class CompanyDatabaseReferences {
public static string COMPANY_CONTACTTYPE = "Company_ContactType";
public static string CUSTOMERS = "Customers";
public static string CONCEPT = "Concept";
public static string DOCUMENT = "Document";
public static string COMPANYLOCATIONS = "CompanyLocations";
public static string CONCEPTS = "Concepts";
}
public static class Company_ContactTypeDatabaseReferences {
public static string COMPANY = "Company";
public static string CONTACTTYPE = "ContactType";
}
public static class CompanyLocationDatabaseReferences {
public static string COMPANY = "Company";
public static string ADDRESS = "Address";
}
public static class ConceptDatabaseReferences {
public static string COMPANIES = "Companies";
public static string COMPANY = "Company";
public static string CONCEPT_ADDRESS = "Concept_Address";
public static string CONCEPT_CONTACTTYPE = "Concept_ContactType";
public static string CONCEPT1 = "Concept1";
public static string CONCEPT2 = "Concept2";
public static string PERSON = "Person";
public static string CUSTOMERS = "Customers";
}
public static class Concept_AddressDatabaseReferences {
public static string CONCEPT = "Concept";
}
public static class Concept_ContactTypeDatabaseReferences {
public static string CONTACTTYPE = "ContactType";
public static string CONCEPT = "Concept";
}
public static class ContactDatabaseReferences {
public static string ADDRESS = "Address";
}
public static class ContactTypeDatabaseReferences {
public static string COMPANY_CONTACTTYPE = "Company_ContactType";
public static string CONCEPT_CONTACTTYPE = "Concept_ContactType";
public static string CONTACTTYPE1 = "ContactType1";
public static string CONTACTTYPE2 = "ContactType2";
public static string ORDERCONCEPT_CONTACTTYPE = "OrderConcept_ContactType";
public static string PERSON_CONTACTTYPE = "Person_ContactType";
}
public static class CountryDatabaseReferences {
public static string ADDRESSES = "Addresses";
public static string CITIES = "Cities";
}
public static class CustomerDatabaseReferences {
public static string TRANSACTIONPRESETS = "TransactionPresets";
public static string COMPANY = "Company";
public static string CUSTOMERTYPE = "CustomerType";
public static string CONCEPT = "Concept";
public static string PERSON = "Person";
public static string TRANSACTIONS = "Transactions";
}
public static class CustomerTypeDatabaseReferences {
public static string CUSTOMERS = "Customers";
}
public static class DocumentDatabaseReferences {
public static string BANKSTATEMENTSTAGINGS = "BankStatementStagings";
public static string COMPANIES = "Companies";
public static string DOCUMENTTYPE = "DocumentType";
public static string PARAMETER = "Parameter";
public static string PARAMETER1 = "Parameter1";
public static string TEMPORARYTRANSACTIONORDERS = "TemporaryTransactionOrders";
public static string TRANSACTIONS = "Transactions";
}
public static class DocumentTypeDatabaseReferences {
public static string DOCUMENTS = "Documents";
}
public static class EndTypeDatabaseReferences {
}
public static class FrequencyDatabaseReferences {
public static string SCHEDULESETTINGS = "ScheduleSettings";
}
public static class MailRecipientDatabaseReferences {
public static string MAILRECIPIENTTYPE = "MailRecipientType";
public static string MAILSTATU = "MailStatu";
public static string MAILTOSEND = "MailToSend";
}
public static class MailRecipientTypeDatabaseReferences {
public static string MAILRECIPIENTS = "MailRecipients";
}
public static class MailServerSettingDatabaseReferences {
public static string MAILTOSENDS = "MailToSends";
}
public static class MailStatuDatabaseReferences {
public static string MAILRECIPIENTS = "MailRecipients";
public static string MAILTOSENDS = "MailToSends";
}
public static class MailToSendDatabaseReferences {
public static string MAILRECIPIENTS = "MailRecipients";
public static string MAILSERVERSETTING = "MailServerSetting";
public static string MAILSTATU = "MailStatu";
public static string MAILTOSENDDOCUMENTS = "MailToSendDocuments";
public static string TRANSACTION_MAILTOSEND = "Transaction_MailToSend";
}
public static class MailToSendDocumentDatabaseReferences {
public static string MAILTOSEND = "MailToSend";
}
public static class NLogDetailDatabaseReferences {
}
public static class OrderDatabaseReferences {
public static string BANKSTATEMENTSTAGINGHITS = "BankStatementStagingHits";
public static string USER = "User";
public static string ORDERCONCEPT = "OrderConcept";
public static string ORDERSTATE = "OrderState";
public static string ORDERDETAILS = "OrderDetails";
}
public static class OrderAddressDatabaseReferences {
public static string ORDERCONCEPT_ORDERADDRESS = "OrderConcept_OrderAddress";
}
public static class OrderCompanyDatabaseReferences {
public static string ORDERCONCEPTS = "OrderConcepts";
}
public static class OrderConceptDatabaseReferences {
public static string ORDERS = "Orders";
public static string ORDERCOMPANY = "OrderCompany";
public static string ORDERCONCEPT_CONTACTTYPE = "OrderConcept_ContactType";
public static string ORDERPERSON = "OrderPerson";
public static string ORDERCONCEPT_ORDERADDRESS = "OrderConcept_OrderAddress";
}
public static class OrderConcept_ContactTypeDatabaseReferences {
public static string CONTACTTYPE = "ContactType";
public static string ORDERCONCEPT = "OrderConcept";
}
public static class OrderConcept_OrderAddressDatabaseReferences {
public static string ORDERADDRESS = "OrderAddress";
public static string ORDERCONCEPT = "OrderConcept";
}
public static class OrderDetailDatabaseReferences {
public static string PRODUCT = "Product";
public static string ORDER = "Order";
}
public static class OrderPersonDatabaseReferences {
public static string TITLE = "Title";
public static string ORDERCONCEPTS = "OrderConcepts";
}
public static class OrderStateDatabaseReferences {
public static string ORDERS = "Orders";
}
public static class ParameterDatabaseReferences {
public static string DOCUMENTS = "Documents";
public static string DOCUMENTS1 = "Documents1";
}
public static class PaymentDatabaseReferences {
public static string USER = "User";
public static string TRANSACTION = "Transaction";
public static string PAYMENTDETAILS = "PaymentDetails";
public static string TRANSACTIONS = "Transactions";
public static string TRANSACTION_PAYMENT = "Transaction_Payment";
}
public static class PaymentDetailDatabaseReferences {
public static string BANK = "Bank";
public static string PAYMENTMETHOD = "PaymentMethod";
public static string PAYMENT = "Payment";
}
public static class PaymentDueStateDatabaseReferences {
}
public static class PaymentMethodDatabaseReferences {
public static string BANKS = "Banks";
public static string PAYMENTDETAILS = "PaymentDetails";
}
public static class PermissionDatabaseReferences {
public static string ROLE_PERMISSION = "Role_Permission";
public static string USER_PERMISSION = "User_Permission";
}
public static class PersonDatabaseReferences {
public static string USERS = "Users";
public static string TITLE = "Title";
public static string CONCEPTS = "Concepts";
public static string CUSTOMERS = "Customers";
public static string PERSON_ADDRESS = "Person_Address";
public static string PERSON_CONTACTTYPE = "Person_ContactType";
}
public static class Person_AddressDatabaseReferences {
public static string ADDRESS = "Address";
public static string PERSON = "Person";
}
public static class Person_ContactTypeDatabaseReferences {
public static string CONTACTTYPE = "ContactType";
public static string PERSON = "Person";
}
public static class ProductDatabaseReferences {
public static string TRANSACTIONDETAILPRESETS = "TransactionDetailPresets";
public static string PRODUCTTYPE = "ProductType";
public static string ORDERDETAILS = "OrderDetails";
public static string PRODUCT1 = "Product1";
public static string PRODUCT2 = "Product2";
public static string TRANSACTIONDETAILS = "TransactionDetails";
}
public static class ProductTypeDatabaseReferences {
public static string PRODUCTS = "Products";
}
public static class ReceiptDatabaseReferences {
public static string USER = "User";
}
public static class RequestDatabaseReferences {
public static string REQUESTTYPE = "RequestType";
public static string WORKFLOWSTATE = "WorkflowState";
public static string REQUESTMESSAGEQUEUES = "RequestMessageQueues";
}
public static class RequestMessageQueueDatabaseReferences {
public static string REQUEST = "Request";
}
public static class RequestTypeDatabaseReferences {
public static string REQUESTS = "Requests";
public static string WORKFLOW = "Workflow";
public static string REQUESTTYPE_USER = "RequestType_User";
}
public static class RequestType_UserDatabaseReferences {
public static string USER = "User";
public static string REQUESTTYPE = "RequestType";
public static string REQUESTTYPE_USER1 = "RequestType_User1";
public static string REQUESTTYPE_USER2 = "RequestType_User2";
}
public static class RoleDatabaseReferences {
public static string ROLE_PERMISSION = "Role_Permission";
public static string USER_ROLE = "User_Role";
}
public static class Role_PermissionDatabaseReferences {
public static string PERMISSION = "Permission";
public static string ROLE = "Role";
}
public static class ScheduleSettingDatabaseReferences {
public static string FREQUENCY = "Frequency";
public static string TRANSACTION = "Transaction";
}
public static class StockLocationDatabaseReferences {
}
public static class TemporaryPaymentDatabaseReferences {
public static string TEMPORARYPAYMENTDETAILS = "TemporaryPaymentDetails";
public static string TEMPORARYTRANSACTIONS = "TemporaryTransactions";
}
public static class TemporaryPaymentDetailDatabaseReferences {
public static string TEMPORARYPAYMENT = "TemporaryPayment";
}
public static class TemporaryTransactionDatabaseReferences {
public static string BANKSTATEMENTHITLIST = "BankStatementHitList";
public static string BANKSTATEMENTSTAGINGDETAIL = "BankStatementStagingDetail";
public static string BANKSTATEMENTSTAGINGHIT = "BankStatementStagingHit";
public static string TEMPORARYPAYMENT = "TemporaryPayment";
public static string TEMPORARYTRANSACTIONDETAILS = "TemporaryTransactionDetails";
}
public static class TemporaryTransactionDetailDatabaseReferences {
public static string TEMPORARYTRANSACTION = "TemporaryTransaction";
}
public static class TemporaryTransactionOrderDatabaseReferences {
public static string TEMPORARYTRANSACTIONORDERSTATE = "TemporaryTransactionOrderState";
public static string DOCUMENT = "Document";
}
public static class TemporaryTransactionOrderStateDatabaseReferences {
public static string TEMPORARYTRANSACTIONORDERS = "TemporaryTransactionOrders";
}
public static class TitleDatabaseReferences {
public static string ORDERPERSONS = "OrderPersons";
public static string PEOPLE = "People";
}
public static class TransactionDatabaseReferences {
public static string USER = "User";
public static string TRANSACTIONSTATE = "TransactionState";
public static string TRANSACTIONTYPE = "TransactionType";
public static string CUSTOMER = "Customer";
public static string DOCUMENT = "Document";
public static string SCHEDULESETTINGS = "ScheduleSettings";
public static string TRANSACTIONDUES = "TransactionDues";
public static string TRANSACTIONDUE_TRANSACTION = "TransactionDue_Transaction";
public static string PAYMENTS = "Payments";
public static string PAYMENT = "Payment";
public static string TRANSACTION1 = "Transaction1";
public static string TRANSACTION2 = "Transaction2";
public static string TRANSACTION11 = "Transaction11";
public static string TRANSACTION3 = "Transaction3";
public static string TRANSACTION_PAYMENT = "Transaction_Payment";
public static string TRANSACTIONDETAILS = "TransactionDetails";
public static string TRANSACTION_MAILTOSEND = "Transaction_MailToSend";
public static string TRANSACTION_BANKSTATEMENTSTAGINGDETAIL = "Transaction_BankStatementStagingDetail";
public static string TRANSACTIONACCOUNT = "TransactionAccount";
public static string TRANSACTIONCLASS = "TransactionClass";
public static string TRANSACTIONTEMPLATE = "TransactionTemplate";
}
public static class Transaction_BankStatementStagingDetailDatabaseReferences {
public static string BANKSTATEMENTSTAGINGDETAIL = "BankStatementStagingDetail";
public static string TRANSACTION = "Transaction";
}
public static class Transaction_MailToSendDatabaseReferences {
public static string MAILTOSEND = "MailToSend";
public static string TRANSACTION = "Transaction";
}
public static class Transaction_PaymentDatabaseReferences {
public static string PAYMENT = "Payment";
public static string TRANSACTION = "Transaction";
}
public static class TransactionAccountDatabaseReferences {
public static string TRANSACTIONPRESETS = "TransactionPresets";
public static string BANKS = "Banks";
public static string TRANSACTIONACCOUNTTYPE = "TransactionAccountType";
public static string TRANSACTIONS = "Transactions";
}
public static class TransactionAccountTypeDatabaseReferences {
public static string TRANSACTIONACCOUNTS = "TransactionAccounts";
}
public static class TransactionClassDatabaseReferences {
public static string TRANSACTIONDETAILPRESETS = "TransactionDetailPresets";
public static string TRANSACTIONPRESETS = "TransactionPresets";
public static string TRANSACTIONCLASS1 = "TransactionClass1";
public static string TRANSACTIONCLASS2 = "TransactionClass2";
public static string TRANSACTIONDETAILS = "TransactionDetails";
public static string TRANSACTIONS = "Transactions";
}
public static class TransactionDetailDatabaseReferences {
public static string PRODUCT = "Product";
public static string TRANSACTION = "Transaction";
public static string TRANSACTIONCLASS = "TransactionClass";
}
public static class TransactionDetailPresetDatabaseReferences {
public static string PRODUCT = "Product";
public static string TRANSACTIONPRESET = "TransactionPreset";
public static string TRANSACTIONCLASS = "TransactionClass";
}
public static class TransactionDueDatabaseReferences {
public static string TRANSACTION = "Transaction";
public static string TRANSACTIONDUE_TRANSACTION = "TransactionDue_Transaction";
}
public static class TransactionDue_TransactionDatabaseReferences {
public static string TRANSACTIONDUE = "TransactionDue";
public static string TRANSACTION = "Transaction";
}
public static class TransactionPresetDatabaseReferences {
public static string BANKSTATEMENTHITLIST_TRANSACTIONPRESET = "BankStatementHitList_TransactionPreset";
public static string BANKSTATEMENTSTAGINGHIT_TRANSACTIONPRESET = "BankStatementStagingHit_TransactionPreset";
public static string TRANSACTIONDETAILPRESETS = "TransactionDetailPresets";
public static string CUSTOMER = "Customer";
public static string TRANSACTIONACCOUNT = "TransactionAccount";
public static string TRANSACTIONCLASS = "TransactionClass";
public static string TRANSACTIONTEMPLATE = "TransactionTemplate";
public static string TRANSACTIONTYPE = "TransactionType";
}
public static class TransactionStateDatabaseReferences {
public static string TRANSACTIONS = "Transactions";
}
public static class TransactionTemplateDatabaseReferences {
public static string TRANSACTIONPRESETS = "TransactionPresets";
public static string BANKS = "Banks";
public static string TRANSACTIONS = "Transactions";
}
public static class TransactionTypeDatabaseReferences {
public static string TRANSACTIONPRESETS = "TransactionPresets";
public static string TRANSACTIONS = "Transactions";
}
public static class UserDatabaseReferences {
public static string BANKSTATEMENTSTAGINGS = "BankStatementStagings";
public static string ORDERS = "Orders";
public static string PAYMENTS = "Payments";
public static string RECEIPTS = "Receipts";
public static string REQUESTTYPE_USER = "RequestType_User";
public static string TRANSACTIONS = "Transactions";
public static string PERSON = "Person";
}
public static class User_PermissionDatabaseReferences {
public static string PERMISSION = "Permission";
}
public static class User_RoleDatabaseReferences {
public static string ROLE = "Role";
}
public static class User_SocialNetworkDatabaseReferences {
}
public static class WorkflowDatabaseReferences {
public static string APPROVALMESSAGES = "ApprovalMessages";
public static string REQUESTTYPES = "RequestTypes";
public static string WORKFLOWACTIONS = "WorkflowActions";
public static string WORKFLOWROLES = "WorkflowRoles";
public static string WORKFLOWSTATES = "WorkflowStates";
}
public static class WorkflowActionDatabaseReferences {
public static string APPROVALMESSAGES = "ApprovalMessages";
public static string WORKFLOW = "Workflow";
public static string WORKFLOWTRANSITIONS = "WorkflowTransitions";
}
public static class WorkflowRoleDatabaseReferences {
public static string WORKFLOW = "Workflow";
public static string WORKFLOWTRANSITIONS = "WorkflowTransitions";
}
public static class WorkflowStateDatabaseReferences {
public static string REQUESTS = "Requests";
public static string WORKFLOW = "Workflow";
public static string WORKFLOWTRANSITIONS = "WorkflowTransitions";
public static string WORKFLOWTRANSITIONS1 = "WorkflowTransitions1";
}
public static class WorkflowTransitionDatabaseReferences {
public static string WORKFLOWACTION = "WorkflowAction";
public static string WORKFLOWROLE = "WorkflowRole";
public static string WORKFLOWSTATE = "WorkflowState";
public static string WORKFLOWSTATE1 = "WorkflowState1";
public static string WORKFLOWTRANSITIONONEXECUTES = "WorkflowTransitionOnExecutes";
}
public static class WorkflowTransitionOnExecuteDatabaseReferences {
public static string WORKFLOWTRANSITION = "WorkflowTransition";
}
}
