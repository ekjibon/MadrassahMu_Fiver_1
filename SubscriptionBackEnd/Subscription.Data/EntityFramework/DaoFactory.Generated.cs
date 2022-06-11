
using System;
using Subscription.Business;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Subscription.Data.EntityFramework;

namespace Subscription.Data
{
    public partial class DaoFactory : IDaoFactory
    {
        private UnitOfWork _unitOfWork;
        public UnitOfWork UnitOfWork { get { if (_unitOfWork == null) { _unitOfWork = new UnitOfWork(); } return _unitOfWork; } }

		public IPermissionDao PermissionDao { get { return new PermissionDao(UnitOfWork.Db);} }
		public IRole_PermissionDao Role_PermissionDao { get { return new Role_PermissionDao(UnitOfWork.Db);} }
		public IUser_PermissionDao User_PermissionDao { get { return new User_PermissionDao(UnitOfWork.Db);} }
		public IBankReconOrderProcessStateDao BankReconOrderProcessStateDao { get { return new BankReconOrderProcessStateDao(UnitOfWork.Db);} }
		public IBankReconOrderTypeDao BankReconOrderTypeDao { get { return new BankReconOrderTypeDao(UnitOfWork.Db);} }
		public IBankStatementHitListDao BankStatementHitListDao { get { return new BankStatementHitListDao(UnitOfWork.Db);} }
		public IBankStatementHitList_TransactionPresetDao BankStatementHitList_TransactionPresetDao { get { return new BankStatementHitList_TransactionPresetDao(UnitOfWork.Db);} }
		public IBankStatementStagingDao BankStatementStagingDao { get { return new BankStatementStagingDao(UnitOfWork.Db);} }
		public IBankStatementStagingDetailDao BankStatementStagingDetailDao { get { return new BankStatementStagingDetailDao(UnitOfWork.Db);} }
		public IBankStatementStagingDetailBatchDao BankStatementStagingDetailBatchDao { get { return new BankStatementStagingDetailBatchDao(UnitOfWork.Db);} }
		public IBankStatementStagingHitDao BankStatementStagingHitDao { get { return new BankStatementStagingHitDao(UnitOfWork.Db);} }
		public IBankStatementStagingHit_TransactionPresetDao BankStatementStagingHit_TransactionPresetDao { get { return new BankStatementStagingHit_TransactionPresetDao(UnitOfWork.Db);} }
		public ITemporaryPaymentDao TemporaryPaymentDao { get { return new TemporaryPaymentDao(UnitOfWork.Db);} }
		public ITemporaryPaymentDetailDao TemporaryPaymentDetailDao { get { return new TemporaryPaymentDetailDao(UnitOfWork.Db);} }
		public ITemporaryTransactionDao TemporaryTransactionDao { get { return new TemporaryTransactionDao(UnitOfWork.Db);} }
		public ITemporaryTransactionDetailDao TemporaryTransactionDetailDao { get { return new TemporaryTransactionDetailDao(UnitOfWork.Db);} }
		public ITransactionDetailPresetDao TransactionDetailPresetDao { get { return new TransactionDetailPresetDao(UnitOfWork.Db);} }
		public ITransactionPresetDao TransactionPresetDao { get { return new TransactionPresetDao(UnitOfWork.Db);} }
		public ICompanyDao CompanyDao { get { return new CompanyDao(UnitOfWork.Db);} }
		public ICompany_ContactTypeDao Company_ContactTypeDao { get { return new Company_ContactTypeDao(UnitOfWork.Db);} }
		public ICompanyLocationDao CompanyLocationDao { get { return new CompanyLocationDao(UnitOfWork.Db);} }
		public IRoleDao RoleDao { get { return new RoleDao(UnitOfWork.Db);} }
		public IUserDao UserDao { get { return new UserDao(UnitOfWork.Db);} }
		public IUser_RoleDao User_RoleDao { get { return new User_RoleDao(UnitOfWork.Db);} }
		public IUser_SocialNetworkDao User_SocialNetworkDao { get { return new User_SocialNetworkDao(UnitOfWork.Db);} }
		public INLogDetailDao NLogDetailDao { get { return new NLogDetailDao(UnitOfWork.Db);} }
		public IReceiptDao ReceiptDao { get { return new ReceiptDao(UnitOfWork.Db);} }
		public IBankDao BankDao { get { return new BankDao(UnitOfWork.Db);} }
		public IBankReconHitTypeDao BankReconHitTypeDao { get { return new BankReconHitTypeDao(UnitOfWork.Db);} }
		public IBankStatementStagingStateDao BankStatementStagingStateDao { get { return new BankStatementStagingStateDao(UnitOfWork.Db);} }
		public IContactTypeDao ContactTypeDao { get { return new ContactTypeDao(UnitOfWork.Db);} }
		public ICustomerTypeDao CustomerTypeDao { get { return new CustomerTypeDao(UnitOfWork.Db);} }
		public IDocumentTypeDao DocumentTypeDao { get { return new DocumentTypeDao(UnitOfWork.Db);} }
		public IPaymentMethodDao PaymentMethodDao { get { return new PaymentMethodDao(UnitOfWork.Db);} }
		public IProductTypeDao ProductTypeDao { get { return new ProductTypeDao(UnitOfWork.Db);} }
		public IStockLocationDao StockLocationDao { get { return new StockLocationDao(UnitOfWork.Db);} }
		public ITemporaryTransactionOrderStateDao TemporaryTransactionOrderStateDao { get { return new TemporaryTransactionOrderStateDao(UnitOfWork.Db);} }
		public ITitleDao TitleDao { get { return new TitleDao(UnitOfWork.Db);} }
		public ITransactionAccountDao TransactionAccountDao { get { return new TransactionAccountDao(UnitOfWork.Db);} }
		public ITransactionAccountTypeDao TransactionAccountTypeDao { get { return new TransactionAccountTypeDao(UnitOfWork.Db);} }
		public ITransactionClassDao TransactionClassDao { get { return new TransactionClassDao(UnitOfWork.Db);} }
		public ITransactionStateDao TransactionStateDao { get { return new TransactionStateDao(UnitOfWork.Db);} }
		public ITransactionTemplateDao TransactionTemplateDao { get { return new TransactionTemplateDao(UnitOfWork.Db);} }
		public ITransactionTypeDao TransactionTypeDao { get { return new TransactionTypeDao(UnitOfWork.Db);} }
		public IMailRecipientDao MailRecipientDao { get { return new MailRecipientDao(UnitOfWork.Db);} }
		public IMailRecipientTypeDao MailRecipientTypeDao { get { return new MailRecipientTypeDao(UnitOfWork.Db);} }
		public IMailServerSettingDao MailServerSettingDao { get { return new MailServerSettingDao(UnitOfWork.Db);} }
		public IMailStatuDao MailStatuDao { get { return new MailStatuDao(UnitOfWork.Db);} }
		public IMailToSendDao MailToSendDao { get { return new MailToSendDao(UnitOfWork.Db);} }
		public IMailToSendDocumentDao MailToSendDocumentDao { get { return new MailToSendDocumentDao(UnitOfWork.Db);} }
		public IAddressDao AddressDao { get { return new AddressDao(UnitOfWork.Db);} }
		public ICityDao CityDao { get { return new CityDao(UnitOfWork.Db);} }
		public IConceptDao ConceptDao { get { return new ConceptDao(UnitOfWork.Db);} }
		public IConcept_AddressDao Concept_AddressDao { get { return new Concept_AddressDao(UnitOfWork.Db);} }
		public IConcept_ContactTypeDao Concept_ContactTypeDao { get { return new Concept_ContactTypeDao(UnitOfWork.Db);} }
		public IContactDao ContactDao { get { return new ContactDao(UnitOfWork.Db);} }
		public ICountryDao CountryDao { get { return new CountryDao(UnitOfWork.Db);} }
		public ICustomerDao CustomerDao { get { return new CustomerDao(UnitOfWork.Db);} }
		public IDocumentDao DocumentDao { get { return new DocumentDao(UnitOfWork.Db);} }
		public IParameterDao ParameterDao { get { return new ParameterDao(UnitOfWork.Db);} }
		public IProductDao ProductDao { get { return new ProductDao(UnitOfWork.Db);} }
		public IOrderDao OrderDao { get { return new OrderDao(UnitOfWork.Db);} }
		public IOrderAddressDao OrderAddressDao { get { return new OrderAddressDao(UnitOfWork.Db);} }
		public IOrderCompanyDao OrderCompanyDao { get { return new OrderCompanyDao(UnitOfWork.Db);} }
		public IOrderConceptDao OrderConceptDao { get { return new OrderConceptDao(UnitOfWork.Db);} }
		public IOrderConcept_ContactTypeDao OrderConcept_ContactTypeDao { get { return new OrderConcept_ContactTypeDao(UnitOfWork.Db);} }
		public IOrderConcept_OrderAddressDao OrderConcept_OrderAddressDao { get { return new OrderConcept_OrderAddressDao(UnitOfWork.Db);} }
		public IOrderDetailDao OrderDetailDao { get { return new OrderDetailDao(UnitOfWork.Db);} }
		public IOrderPersonDao OrderPersonDao { get { return new OrderPersonDao(UnitOfWork.Db);} }
		public IOrderStateDao OrderStateDao { get { return new OrderStateDao(UnitOfWork.Db);} }
		public IPersonDao PersonDao { get { return new PersonDao(UnitOfWork.Db);} }
		public IPerson_AddressDao Person_AddressDao { get { return new Person_AddressDao(UnitOfWork.Db);} }
		public IPerson_ContactTypeDao Person_ContactTypeDao { get { return new Person_ContactTypeDao(UnitOfWork.Db);} }
		public IEndTypeDao EndTypeDao { get { return new EndTypeDao(UnitOfWork.Db);} }
		public IFrequencyDao FrequencyDao { get { return new FrequencyDao(UnitOfWork.Db);} }
		public IPaymentDueStateDao PaymentDueStateDao { get { return new PaymentDueStateDao(UnitOfWork.Db);} }
		public IScheduleSettingDao ScheduleSettingDao { get { return new ScheduleSettingDao(UnitOfWork.Db);} }
		public ITransactionDueDao TransactionDueDao { get { return new TransactionDueDao(UnitOfWork.Db);} }
		public ITransactionDue_TransactionDao TransactionDue_TransactionDao { get { return new TransactionDue_TransactionDao(UnitOfWork.Db);} }
		public IPaymentDao PaymentDao { get { return new PaymentDao(UnitOfWork.Db);} }
		public IPaymentDetailDao PaymentDetailDao { get { return new PaymentDetailDao(UnitOfWork.Db);} }
		public ITemporaryTransactionOrderDao TemporaryTransactionOrderDao { get { return new TemporaryTransactionOrderDao(UnitOfWork.Db);} }
		public ITransactionDao TransactionDao { get { return new TransactionDao(UnitOfWork.Db);} }
		public ITransaction_MailToSendDao Transaction_MailToSendDao { get { return new Transaction_MailToSendDao(UnitOfWork.Db);} }
		public ITransaction_PaymentDao Transaction_PaymentDao { get { return new Transaction_PaymentDao(UnitOfWork.Db);} }
		public ITransactionDetailDao TransactionDetailDao { get { return new TransactionDetailDao(UnitOfWork.Db);} }
		public IApprovalMessageDao ApprovalMessageDao { get { return new ApprovalMessageDao(UnitOfWork.Db);} }
		public IRequestDao RequestDao { get { return new RequestDao(UnitOfWork.Db);} }
		public IRequestMessageQueueDao RequestMessageQueueDao { get { return new RequestMessageQueueDao(UnitOfWork.Db);} }
		public IRequestTypeDao RequestTypeDao { get { return new RequestTypeDao(UnitOfWork.Db);} }
		public IRequestType_UserDao RequestType_UserDao { get { return new RequestType_UserDao(UnitOfWork.Db);} }
		public IWorkflowDao WorkflowDao { get { return new WorkflowDao(UnitOfWork.Db);} }
		public IWorkflowActionDao WorkflowActionDao { get { return new WorkflowActionDao(UnitOfWork.Db);} }
		public IWorkflowRoleDao WorkflowRoleDao { get { return new WorkflowRoleDao(UnitOfWork.Db);} }
		public IWorkflowStateDao WorkflowStateDao { get { return new WorkflowStateDao(UnitOfWork.Db);} }
		public IWorkflowTransitionDao WorkflowTransitionDao { get { return new WorkflowTransitionDao(UnitOfWork.Db);} }
		public IWorkflowTransitionOnExecuteDao WorkflowTransitionOnExecuteDao { get { return new WorkflowTransitionOnExecuteDao(UnitOfWork.Db);} }
		public ITransaction_BankStatementStagingDetailDao Transaction_BankStatementStagingDetailDao { get { return new Transaction_BankStatementStagingDetailDao(UnitOfWork.Db);} }
    }
}
