using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscription.Service
{
    public partial interface IServiceFactory
    {
	    PermissionService PermissionService { get ; }
	    Role_PermissionService Role_PermissionService { get ; }
	    User_PermissionService User_PermissionService { get ; }
	    BankReconOrderProcessStateService BankReconOrderProcessStateService { get ; }
	    BankReconOrderTypeService BankReconOrderTypeService { get ; }
	    BankStatementHitListService BankStatementHitListService { get ; }
	    BankStatementHitList_TransactionPresetService BankStatementHitList_TransactionPresetService { get ; }
	    BankStatementStagingService BankStatementStagingService { get ; }
	    BankStatementStagingDetailService BankStatementStagingDetailService { get ; }
	    BankStatementStagingDetailBatchService BankStatementStagingDetailBatchService { get ; }
	    BankStatementStagingHitService BankStatementStagingHitService { get ; }
	    BankStatementStagingHit_TransactionPresetService BankStatementStagingHit_TransactionPresetService { get ; }
	    TemporaryPaymentService TemporaryPaymentService { get ; }
	    TemporaryPaymentDetailService TemporaryPaymentDetailService { get ; }
	    TemporaryTransactionService TemporaryTransactionService { get ; }
	    TemporaryTransactionDetailService TemporaryTransactionDetailService { get ; }
	    TransactionDetailPresetService TransactionDetailPresetService { get ; }
	    TransactionPresetService TransactionPresetService { get ; }
	    CompanyService CompanyService { get ; }
	    Company_ContactTypeService Company_ContactTypeService { get ; }
	    CompanyLocationService CompanyLocationService { get ; }
	    RoleService RoleService { get ; }
	    UserService UserService { get ; }
	    User_RoleService User_RoleService { get ; }
	    User_SocialNetworkService User_SocialNetworkService { get ; }
	    NLogDetailService NLogDetailService { get ; }
	    ReceiptService ReceiptService { get ; }
	    BankService BankService { get ; }
	    BankReconHitTypeService BankReconHitTypeService { get ; }
	    BankStatementStagingStateService BankStatementStagingStateService { get ; }
	    ContactTypeService ContactTypeService { get ; }
	    CustomerTypeService CustomerTypeService { get ; }
	    DocumentTypeService DocumentTypeService { get ; }
	    PaymentMethodService PaymentMethodService { get ; }
	    ProductTypeService ProductTypeService { get ; }
	    StockLocationService StockLocationService { get ; }
	    TemporaryTransactionOrderStateService TemporaryTransactionOrderStateService { get ; }
	    TitleService TitleService { get ; }
	    TransactionAccountService TransactionAccountService { get ; }
	    TransactionAccountTypeService TransactionAccountTypeService { get ; }
	    TransactionClassService TransactionClassService { get ; }
	    TransactionStateService TransactionStateService { get ; }
	    TransactionTemplateService TransactionTemplateService { get ; }
	    TransactionTypeService TransactionTypeService { get ; }
	    MailRecipientService MailRecipientService { get ; }
	    MailRecipientTypeService MailRecipientTypeService { get ; }
	    MailServerSettingService MailServerSettingService { get ; }
	    MailStatuService MailStatuService { get ; }
	    MailToSendService MailToSendService { get ; }
	    MailToSendDocumentService MailToSendDocumentService { get ; }
	    AddressService AddressService { get ; }
	    CityService CityService { get ; }
	    ConceptService ConceptService { get ; }
	    Concept_AddressService Concept_AddressService { get ; }
	    Concept_ContactTypeService Concept_ContactTypeService { get ; }
	    ContactService ContactService { get ; }
	    CountryService CountryService { get ; }
	    CustomerService CustomerService { get ; }
	    DocumentService DocumentService { get ; }
	    ParameterService ParameterService { get ; }
	    ProductService ProductService { get ; }
	    OrderService OrderService { get ; }
	    OrderAddressService OrderAddressService { get ; }
	    OrderCompanyService OrderCompanyService { get ; }
	    OrderConceptService OrderConceptService { get ; }
	    OrderConcept_ContactTypeService OrderConcept_ContactTypeService { get ; }
	    OrderConcept_OrderAddressService OrderConcept_OrderAddressService { get ; }
	    OrderDetailService OrderDetailService { get ; }
	    OrderPersonService OrderPersonService { get ; }
	    OrderStateService OrderStateService { get ; }
	    PersonService PersonService { get ; }
	    Person_AddressService Person_AddressService { get ; }
	    Person_ContactTypeService Person_ContactTypeService { get ; }
	    EndTypeService EndTypeService { get ; }
	    FrequencyService FrequencyService { get ; }
	    PaymentDueStateService PaymentDueStateService { get ; }
	    ScheduleSettingService ScheduleSettingService { get ; }
	    TransactionDueService TransactionDueService { get ; }
	    TransactionDue_TransactionService TransactionDue_TransactionService { get ; }
	    PaymentService PaymentService { get ; }
	    PaymentDetailService PaymentDetailService { get ; }
	    TemporaryTransactionOrderService TemporaryTransactionOrderService { get ; }
	    TransactionService TransactionService { get ; }
	    Transaction_MailToSendService Transaction_MailToSendService { get ; }
	    Transaction_PaymentService Transaction_PaymentService { get ; }
	    TransactionDetailService TransactionDetailService { get ; }
	    ApprovalMessageService ApprovalMessageService { get ; }
	    RequestService RequestService { get ; }
	    RequestMessageQueueService RequestMessageQueueService { get ; }
	    RequestTypeService RequestTypeService { get ; }
	    RequestType_UserService RequestType_UserService { get ; }
	    WorkflowService WorkflowService { get ; }
	    WorkflowActionService WorkflowActionService { get ; }
	    WorkflowRoleService WorkflowRoleService { get ; }
	    WorkflowStateService WorkflowStateService { get ; }
	    WorkflowTransitionService WorkflowTransitionService { get ; }
	    WorkflowTransitionOnExecuteService WorkflowTransitionOnExecuteService { get ; }
	    Transaction_BankStatementStagingDetailService Transaction_BankStatementStagingDetailService { get ; }
    }
}
