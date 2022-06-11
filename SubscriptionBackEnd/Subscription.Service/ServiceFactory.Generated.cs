using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Subscription.Service;

namespace Subscription.Service
{
    public partial class ServiceFactory : IServiceFactory
    {
		 public PermissionService PermissionService { get { return new PermissionService();} }
		 public Role_PermissionService Role_PermissionService { get { return new Role_PermissionService();} }
		 public User_PermissionService User_PermissionService { get { return new User_PermissionService();} }
		 public BankReconOrderProcessStateService BankReconOrderProcessStateService { get { return new BankReconOrderProcessStateService();} }
		 public BankReconOrderTypeService BankReconOrderTypeService { get { return new BankReconOrderTypeService();} }
		 public BankStatementHitListService BankStatementHitListService { get { return new BankStatementHitListService();} }
		 public BankStatementHitList_TransactionPresetService BankStatementHitList_TransactionPresetService { get { return new BankStatementHitList_TransactionPresetService();} }
		 public BankStatementStagingService BankStatementStagingService { get { return new BankStatementStagingService();} }
		 public BankStatementStagingDetailService BankStatementStagingDetailService { get { return new BankStatementStagingDetailService();} }
		 public BankStatementStagingDetailBatchService BankStatementStagingDetailBatchService { get { return new BankStatementStagingDetailBatchService();} }
		 public BankStatementStagingHitService BankStatementStagingHitService { get { return new BankStatementStagingHitService();} }
		 public BankStatementStagingHit_TransactionPresetService BankStatementStagingHit_TransactionPresetService { get { return new BankStatementStagingHit_TransactionPresetService();} }
		 public TemporaryPaymentService TemporaryPaymentService { get { return new TemporaryPaymentService();} }
		 public TemporaryPaymentDetailService TemporaryPaymentDetailService { get { return new TemporaryPaymentDetailService();} }
		 public TemporaryTransactionService TemporaryTransactionService { get { return new TemporaryTransactionService();} }
		 public TemporaryTransactionDetailService TemporaryTransactionDetailService { get { return new TemporaryTransactionDetailService();} }
		 public TransactionDetailPresetService TransactionDetailPresetService { get { return new TransactionDetailPresetService();} }
		 public TransactionPresetService TransactionPresetService { get { return new TransactionPresetService();} }
		 public CompanyService CompanyService { get { return new CompanyService();} }
		 public Company_ContactTypeService Company_ContactTypeService { get { return new Company_ContactTypeService();} }
		 public CompanyLocationService CompanyLocationService { get { return new CompanyLocationService();} }
		 public RoleService RoleService { get { return new RoleService();} }
		 public UserService UserService { get { return new UserService();} }
		 public User_RoleService User_RoleService { get { return new User_RoleService();} }
		 public User_SocialNetworkService User_SocialNetworkService { get { return new User_SocialNetworkService();} }
		 public NLogDetailService NLogDetailService { get { return new NLogDetailService();} }
		 public ReceiptService ReceiptService { get { return new ReceiptService();} }
		 public BankService BankService { get { return new BankService();} }
		 public BankReconHitTypeService BankReconHitTypeService { get { return new BankReconHitTypeService();} }
		 public BankStatementStagingStateService BankStatementStagingStateService { get { return new BankStatementStagingStateService();} }
		 public ContactTypeService ContactTypeService { get { return new ContactTypeService();} }
		 public CustomerTypeService CustomerTypeService { get { return new CustomerTypeService();} }
		 public DocumentTypeService DocumentTypeService { get { return new DocumentTypeService();} }
		 public PaymentMethodService PaymentMethodService { get { return new PaymentMethodService();} }
		 public ProductTypeService ProductTypeService { get { return new ProductTypeService();} }
		 public StockLocationService StockLocationService { get { return new StockLocationService();} }
		 public TemporaryTransactionOrderStateService TemporaryTransactionOrderStateService { get { return new TemporaryTransactionOrderStateService();} }
		 public TitleService TitleService { get { return new TitleService();} }
		 public TransactionAccountService TransactionAccountService { get { return new TransactionAccountService();} }
		 public TransactionAccountTypeService TransactionAccountTypeService { get { return new TransactionAccountTypeService();} }
		 public TransactionClassService TransactionClassService { get { return new TransactionClassService();} }
		 public TransactionStateService TransactionStateService { get { return new TransactionStateService();} }
		 public TransactionTemplateService TransactionTemplateService { get { return new TransactionTemplateService();} }
		 public TransactionTypeService TransactionTypeService { get { return new TransactionTypeService();} }
		 public MailRecipientService MailRecipientService { get { return new MailRecipientService();} }
		 public MailRecipientTypeService MailRecipientTypeService { get { return new MailRecipientTypeService();} }
		 public MailServerSettingService MailServerSettingService { get { return new MailServerSettingService();} }
		 public MailStatuService MailStatuService { get { return new MailStatuService();} }
		 public MailToSendService MailToSendService { get { return new MailToSendService();} }
		 public MailToSendDocumentService MailToSendDocumentService { get { return new MailToSendDocumentService();} }
		 public AddressService AddressService { get { return new AddressService();} }
		 public CityService CityService { get { return new CityService();} }
		 public ConceptService ConceptService { get { return new ConceptService();} }
		 public Concept_AddressService Concept_AddressService { get { return new Concept_AddressService();} }
		 public Concept_ContactTypeService Concept_ContactTypeService { get { return new Concept_ContactTypeService();} }
		 public ContactService ContactService { get { return new ContactService();} }
		 public CountryService CountryService { get { return new CountryService();} }
		 public CustomerService CustomerService { get { return new CustomerService();} }
		 public DocumentService DocumentService { get { return new DocumentService();} }
		 public ParameterService ParameterService { get { return new ParameterService();} }
		 public ProductService ProductService { get { return new ProductService();} }
		 public OrderService OrderService { get { return new OrderService();} }
		 public OrderAddressService OrderAddressService { get { return new OrderAddressService();} }
		 public OrderCompanyService OrderCompanyService { get { return new OrderCompanyService();} }
		 public OrderConceptService OrderConceptService { get { return new OrderConceptService();} }
		 public OrderConcept_ContactTypeService OrderConcept_ContactTypeService { get { return new OrderConcept_ContactTypeService();} }
		 public OrderConcept_OrderAddressService OrderConcept_OrderAddressService { get { return new OrderConcept_OrderAddressService();} }
		 public OrderDetailService OrderDetailService { get { return new OrderDetailService();} }
		 public OrderPersonService OrderPersonService { get { return new OrderPersonService();} }
		 public OrderStateService OrderStateService { get { return new OrderStateService();} }
		 public PersonService PersonService { get { return new PersonService();} }
		 public Person_AddressService Person_AddressService { get { return new Person_AddressService();} }
		 public Person_ContactTypeService Person_ContactTypeService { get { return new Person_ContactTypeService();} }
		 public EndTypeService EndTypeService { get { return new EndTypeService();} }
		 public FrequencyService FrequencyService { get { return new FrequencyService();} }
		 public PaymentDueStateService PaymentDueStateService { get { return new PaymentDueStateService();} }
		 public ScheduleSettingService ScheduleSettingService { get { return new ScheduleSettingService();} }
		 public TransactionDueService TransactionDueService { get { return new TransactionDueService();} }
		 public TransactionDue_TransactionService TransactionDue_TransactionService { get { return new TransactionDue_TransactionService();} }
		 public PaymentService PaymentService { get { return new PaymentService();} }
		 public PaymentDetailService PaymentDetailService { get { return new PaymentDetailService();} }
		 public TemporaryTransactionOrderService TemporaryTransactionOrderService { get { return new TemporaryTransactionOrderService();} }
		 public TransactionService TransactionService { get { return new TransactionService();} }
		 public Transaction_MailToSendService Transaction_MailToSendService { get { return new Transaction_MailToSendService();} }
		 public Transaction_PaymentService Transaction_PaymentService { get { return new Transaction_PaymentService();} }
		 public TransactionDetailService TransactionDetailService { get { return new TransactionDetailService();} }
		 public ApprovalMessageService ApprovalMessageService { get { return new ApprovalMessageService();} }
		 public RequestService RequestService { get { return new RequestService();} }
		 public RequestMessageQueueService RequestMessageQueueService { get { return new RequestMessageQueueService();} }
		 public RequestTypeService RequestTypeService { get { return new RequestTypeService();} }
		 public RequestType_UserService RequestType_UserService { get { return new RequestType_UserService();} }
		 public WorkflowService WorkflowService { get { return new WorkflowService();} }
		 public WorkflowActionService WorkflowActionService { get { return new WorkflowActionService();} }
		 public WorkflowRoleService WorkflowRoleService { get { return new WorkflowRoleService();} }
		 public WorkflowStateService WorkflowStateService { get { return new WorkflowStateService();} }
		 public WorkflowTransitionService WorkflowTransitionService { get { return new WorkflowTransitionService();} }
		 public WorkflowTransitionOnExecuteService WorkflowTransitionOnExecuteService { get { return new WorkflowTransitionOnExecuteService();} }
		 public Transaction_BankStatementStagingDetailService Transaction_BankStatementStagingDetailService { get { return new Transaction_BankStatementStagingDetailService();} }
    }
}
		