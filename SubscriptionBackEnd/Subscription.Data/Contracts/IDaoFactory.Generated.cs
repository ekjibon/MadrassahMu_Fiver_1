using System;
using Subscription.Business;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Subscription.Data.EntityFramework;

namespace Subscription.Data
{
    public partial interface IDaoFactory
    {
        UnitOfWork UnitOfWork { get; }
	    IPermissionDao PermissionDao { get ; }
	    IRole_PermissionDao Role_PermissionDao { get ; }
	    IUser_PermissionDao User_PermissionDao { get ; }
	    IBankReconOrderProcessStateDao BankReconOrderProcessStateDao { get ; }
	    IBankReconOrderTypeDao BankReconOrderTypeDao { get ; }
	    IBankStatementHitListDao BankStatementHitListDao { get ; }
	    IBankStatementHitList_TransactionPresetDao BankStatementHitList_TransactionPresetDao { get ; }
	    IBankStatementStagingDao BankStatementStagingDao { get ; }
	    IBankStatementStagingDetailDao BankStatementStagingDetailDao { get ; }
	    IBankStatementStagingDetailBatchDao BankStatementStagingDetailBatchDao { get ; }
	    IBankStatementStagingHitDao BankStatementStagingHitDao { get ; }
	    IBankStatementStagingHit_TransactionPresetDao BankStatementStagingHit_TransactionPresetDao { get ; }
	    ITemporaryPaymentDao TemporaryPaymentDao { get ; }
	    ITemporaryPaymentDetailDao TemporaryPaymentDetailDao { get ; }
	    ITemporaryTransactionDao TemporaryTransactionDao { get ; }
	    ITemporaryTransactionDetailDao TemporaryTransactionDetailDao { get ; }
	    ITransactionDetailPresetDao TransactionDetailPresetDao { get ; }
	    ITransactionPresetDao TransactionPresetDao { get ; }
	    ICompanyDao CompanyDao { get ; }
	    ICompany_ContactTypeDao Company_ContactTypeDao { get ; }
	    ICompanyLocationDao CompanyLocationDao { get ; }
	    IRoleDao RoleDao { get ; }
	    IUserDao UserDao { get ; }
	    IUser_RoleDao User_RoleDao { get ; }
	    IUser_SocialNetworkDao User_SocialNetworkDao { get ; }
	    INLogDetailDao NLogDetailDao { get ; }
	    IReceiptDao ReceiptDao { get ; }
	    IBankDao BankDao { get ; }
	    IBankReconHitTypeDao BankReconHitTypeDao { get ; }
	    IBankStatementStagingStateDao BankStatementStagingStateDao { get ; }
	    IContactTypeDao ContactTypeDao { get ; }
	    ICustomerTypeDao CustomerTypeDao { get ; }
	    IDocumentTypeDao DocumentTypeDao { get ; }
	    IPaymentMethodDao PaymentMethodDao { get ; }
	    IProductTypeDao ProductTypeDao { get ; }
	    IStockLocationDao StockLocationDao { get ; }
	    ITemporaryTransactionOrderStateDao TemporaryTransactionOrderStateDao { get ; }
	    ITitleDao TitleDao { get ; }
	    ITransactionAccountDao TransactionAccountDao { get ; }
	    ITransactionAccountTypeDao TransactionAccountTypeDao { get ; }
	    ITransactionClassDao TransactionClassDao { get ; }
	    ITransactionStateDao TransactionStateDao { get ; }
	    ITransactionTemplateDao TransactionTemplateDao { get ; }
	    ITransactionTypeDao TransactionTypeDao { get ; }
	    IMailRecipientDao MailRecipientDao { get ; }
	    IMailRecipientTypeDao MailRecipientTypeDao { get ; }
	    IMailServerSettingDao MailServerSettingDao { get ; }
	    IMailStatuDao MailStatuDao { get ; }
	    IMailToSendDao MailToSendDao { get ; }
	    IMailToSendDocumentDao MailToSendDocumentDao { get ; }
	    IAddressDao AddressDao { get ; }
	    ICityDao CityDao { get ; }
	    IConceptDao ConceptDao { get ; }
	    IConcept_AddressDao Concept_AddressDao { get ; }
	    IConcept_ContactTypeDao Concept_ContactTypeDao { get ; }
	    IContactDao ContactDao { get ; }
	    ICountryDao CountryDao { get ; }
	    ICustomerDao CustomerDao { get ; }
	    IDocumentDao DocumentDao { get ; }
	    IParameterDao ParameterDao { get ; }
	    IProductDao ProductDao { get ; }
	    IOrderDao OrderDao { get ; }
	    IOrderAddressDao OrderAddressDao { get ; }
	    IOrderCompanyDao OrderCompanyDao { get ; }
	    IOrderConceptDao OrderConceptDao { get ; }
	    IOrderConcept_ContactTypeDao OrderConcept_ContactTypeDao { get ; }
	    IOrderConcept_OrderAddressDao OrderConcept_OrderAddressDao { get ; }
	    IOrderDetailDao OrderDetailDao { get ; }
	    IOrderPersonDao OrderPersonDao { get ; }
	    IOrderStateDao OrderStateDao { get ; }
	    IPersonDao PersonDao { get ; }
	    IPerson_AddressDao Person_AddressDao { get ; }
	    IPerson_ContactTypeDao Person_ContactTypeDao { get ; }
	    IEndTypeDao EndTypeDao { get ; }
	    IFrequencyDao FrequencyDao { get ; }
	    IPaymentDueStateDao PaymentDueStateDao { get ; }
	    IScheduleSettingDao ScheduleSettingDao { get ; }
	    ITransactionDueDao TransactionDueDao { get ; }
	    ITransactionDue_TransactionDao TransactionDue_TransactionDao { get ; }
	    IPaymentDao PaymentDao { get ; }
	    IPaymentDetailDao PaymentDetailDao { get ; }
	    ITemporaryTransactionOrderDao TemporaryTransactionOrderDao { get ; }
	    ITransactionDao TransactionDao { get ; }
	    ITransaction_MailToSendDao Transaction_MailToSendDao { get ; }
	    ITransaction_PaymentDao Transaction_PaymentDao { get ; }
	    ITransactionDetailDao TransactionDetailDao { get ; }
	    IApprovalMessageDao ApprovalMessageDao { get ; }
	    IRequestDao RequestDao { get ; }
	    IRequestMessageQueueDao RequestMessageQueueDao { get ; }
	    IRequestTypeDao RequestTypeDao { get ; }
	    IRequestType_UserDao RequestType_UserDao { get ; }
	    IWorkflowDao WorkflowDao { get ; }
	    IWorkflowActionDao WorkflowActionDao { get ; }
	    IWorkflowRoleDao WorkflowRoleDao { get ; }
	    IWorkflowStateDao WorkflowStateDao { get ; }
	    IWorkflowTransitionDao WorkflowTransitionDao { get ; }
	    IWorkflowTransitionOnExecuteDao WorkflowTransitionOnExecuteDao { get ; }
	    ITransaction_BankStatementStagingDetailDao Transaction_BankStatementStagingDetailDao { get ; }
    }
}
