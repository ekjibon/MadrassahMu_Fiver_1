using CoreWeb.Business.Common;
using Subscription.Business;
using Subscription.Business.Common;
using Subscription.Business.Dto;
using Subscription.Business.Dto.Subscription;
using Subscription.Business.Enums;
using Subscription.Business.ReturnType;
using Subscription.Business.ReturnType.Subscription;
using Subscription.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Subscription.Service
{
    public partial class PaymentService : BaseService
    {

        public BusinessResponse<SaveTransactionPaymentReturnType> SaveTransactionPayment(SaveTransactionPaymentDto saveTransactionPaymentDto)
        {
            BusinessResponse<SaveTransactionPaymentReturnType> response = new BusinessResponse<SaveTransactionPaymentReturnType>();
            UnitOfWork unitOfWork = new UnitOfWork();
            try
            {
                unitOfWork.Begin();
                response.Result = SaveTransactionPaymentRaw(saveTransactionPaymentDto, unitOfWork);
                unitOfWork.Commit();
                //PrepareForSync(response.Result);
                //response.Result.CustomersToSync = null;
                //response.Result.ProductsToSync = null;
            }
            catch (Exception ex)
            {
                unitOfWork.RollbackTransaction();
                response.Result = null;
                response.Exception = new BusinessLayerException(ex.Message, ex);
            }

            return response;
        }

        internal string GenerateReceiptNumber(UnitOfWork unitOfWork, double receiptNumber)
        {
            string fullName = string.Format("{0} {1}", ServiceFactory.Instance.GlobalVariableService.UserLoggedWithDetail?.LastName, ServiceFactory.Instance.GlobalVariableService.UserLoggedWithDetail?.FirstName);
            var fullNameSplit = fullName.Split(' ').Select(s => s.ElementAt(0).ToString()).ToList();
            string receiptNameNo = String.Join("", fullNameSplit);
            string receiptNoFigures = String.Format("{0:00000}", receiptNumber);
            return String.Format("{0}{1}-{2}", receiptNameNo, DateTime.Now.ToString("yy"), receiptNoFigures);
        }

        internal SaveTransactionPaymentReturnType SaveTransactionPaymentRaw(SaveTransactionPaymentDto saveTransactionPaymentDto, UnitOfWork unitOfWork)
        {
            SaveTransactionPaymentReturnType saveTransactionPaymentReturnType = new SaveTransactionPaymentReturnType();

            Payment paymentReturnType = new Payment();

            if (saveTransactionPaymentDto.Transaction.ReceiptNo == null || String.IsNullOrEmpty(saveTransactionPaymentDto.Transaction.ReceiptNo))
            {
                double receiptNumber = daoFactory.ReceiptDao.GetNextReceiptIdForUser(unitOfWork.Db, ServiceFactory.Instance.GlobalVariableService.UserLoggedWithDetail.IdUser.Value);
                saveTransactionPaymentDto.Transaction.ReceiptNo = GenerateReceiptNumber(unitOfWork, receiptNumber);
                Receipt receipt = new Receipt() { Number = receiptNumber, IdUser = ServiceFactory.Instance.GlobalVariableService.UserLoggedWithDetail.IdUser.Value };
                daoFactory.ReceiptDao.SaveOnlyReceipt(receipt, unitOfWork.Db);
            }

            Transaction _transaction = new Transaction();
            _transaction = saveTransactionPaymentDto.Transaction;
            _transaction.IdCustomer = saveTransactionPaymentDto.Transaction.Customer.IdCustomer;
            _transaction.IdTransactionOriginal = _transaction.IdTransaction;
            _transaction.TotalAmount = saveTransactionPaymentDto.PaymentDetails.Sum(pd => pd.PaymentAmount);
            _transaction.ReceiptNo = saveTransactionPaymentDto.Transaction.ReceiptNo;
            if (saveTransactionPaymentDto.TransactionDue != null)
            {
                _transaction.CapturedDate = saveTransactionPaymentDto.TransactionDue.DueDate; //Should their be another column for due date? Is captured date important?
            }
            _transaction.TransactionDate = DateTime.Now;
            _transaction.IdUserAuthor = ServiceFactory.Instance.GlobalVariableService.UserLoggedWithDetail.IdUser.Value;
            if (saveTransactionPaymentDto.TransactionDue != null)
            {
                _transaction.IdTransaction = null;
            }
            if (saveTransactionPaymentDto.IdTemporaryTransactionSignature != null)
            {
                saveTransactionPaymentDto.Transaction.IdSignatureDocument =
                    daoFactory.TemporaryTransactionOrderDao.GetTemporaryTransactionOrder(saveTransactionPaymentDto.IdTemporaryTransactionSignature.Value, unitOfWork.Db)?.IdSignatureDocument;
            }
            _transaction.IdSignatureDocument = saveTransactionPaymentDto.Transaction.IdSignatureDocument;
            daoFactory.TransactionDao.SaveOnlyTransaction(_transaction);

            saveTransactionPaymentDto.Transaction.TransactionDetails.ToList().ForEach((td) =>
            {
                td.IdTransactionDetail = null;
                td.IdTransaction = _transaction.IdTransaction;
                td.IdProduct = td.Product.IdProduct;
                td.Description = td.Product.Description;
                daoFactory.TransactionDetailDao.SaveOnlyTransactionDetail(td);
            });    

            Payment _payment = new Payment();
            _payment.IdTransaction = _transaction.IdTransaction;
            _payment.PaymentDate = DateTime.Now;
            daoFactory.PaymentDao.SaveOnlyPayment(_payment);

            //assign paymentId in transaction
            _transaction.IdPayment = _payment.IdPayment;
            daoFactory.TransactionDao.SaveOnlyTransaction(_transaction);

            paymentReturnType.Transaction = _transaction;

            saveTransactionPaymentDto.PaymentDetails.ForEach((paymentDetail) => {
                PaymentDetail _paymentDetail = new PaymentDetail();
                _paymentDetail.IdPayment = _payment.IdPayment;
                _paymentDetail.PaymentAmount = paymentDetail.PaymentAmount;
                _paymentDetail.IdPaymentMethod = paymentDetail.IdPaymentMethod;
                _paymentDetail.ChequeNo = paymentDetail.ChequeNo;
                _paymentDetail.Description = paymentDetail.Description;
                _paymentDetail.BankAccountNo = paymentDetail.BankAccountNo;
                _paymentDetail.IdBank = paymentDetail.IdBank;
                daoFactory.PaymentDetailDao.SaveOnlyPaymentDetail(_paymentDetail);
            });
            
            Transaction_Payment _transaction_Payment = new Transaction_Payment();
            _transaction_Payment.IdTransaction = _transaction.IdTransaction;
            _transaction_Payment.IdPayment = _payment.IdPayment;
            daoFactory.Transaction_PaymentDao.SaveOnlyTransaction_Payment(_transaction_Payment);

            if(saveTransactionPaymentDto.TransactionDue != null)
            {
                TransactionDue _transactionDue = new TransactionDue();
                _transactionDue.IdTransactionDue = saveTransactionPaymentDto.TransactionDue.IdTransactionDue;
                _transactionDue.IdTransaction = _transaction.IdTransactionOriginal;
                _transactionDue.DueDate = saveTransactionPaymentDto.TransactionDue.DueDate;
                _transactionDue.AmountDue = saveTransactionPaymentDto.TransactionDue.AmountDue;
                _transactionDue.AmountRemaining = saveTransactionPaymentDto.TransactionDue.AmountDue - saveTransactionPaymentDto.PaymentDetails.Sum(pd => pd.PaymentAmount);
                daoFactory.TransactionDueDao.SaveTransactionDue(_transactionDue);
                saveTransactionPaymentReturnType.TransactionDue = _transactionDue;
            }           

            saveTransactionPaymentReturnType.Payment = paymentReturnType;
            saveTransactionPaymentReturnType.Transaction = _transaction;

            return saveTransactionPaymentReturnType;
        }

        public BusinessResponse<GetLastPaymentForCustomerReturnType> GetLastPaymentDateForCustomer(GetLastPaymentForCustomerDto getLastPaymentForCustomerDto)
        {
            BusinessResponse<GetLastPaymentForCustomerReturnType> response = new BusinessResponse<GetLastPaymentForCustomerReturnType>();
            UnitOfWork unitOfWork = new UnitOfWork();
            try
            {
                unitOfWork.Begin();
                response.Result = GetLastPaymentDateForCustomerRaw(getLastPaymentForCustomerDto, unitOfWork);
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

        internal GetLastPaymentForCustomerReturnType GetLastPaymentDateForCustomerRaw(GetLastPaymentForCustomerDto getLastPaymentForCustomerDto, UnitOfWork unitOfWork)
        {
            GetLastPaymentForCustomerReturnType getLastPaymentForCustomerReturnType = new GetLastPaymentForCustomerReturnType();

            Expression<Func<Transaction, bool>> expression = property => property.IsDeactivated != true && property.Customer.IdCustomer == getLastPaymentForCustomerDto.IdCustomer && property.IdTransactionOriginal == getLastPaymentForCustomerDto.IdTransaction && property.IdPayment != null;
            

            BaseListReturnType<Transaction> dbTransactions = daoFactory.TransactionDao.GetTransactionCustomList(expression);

            dbTransactions.EntityList = dbTransactions.EntityList.OrderByDescending(t => t.TransactionDate).ToList(); //Sort by most recent date

            getLastPaymentForCustomerReturnType.CapturedDate = dbTransactions.EntityList.FirstOrDefault().CapturedDate; //Gets the first captured date of the most recent transaction

            return getLastPaymentForCustomerReturnType;
        }


        public Transaction RemapTransaction(Transaction transaction)
        {
            Transaction remappedTransaction = Mapper.MapTransactionSingle(transaction, true);
            remappedTransaction.TransactionDetails = new List<TransactionDetail>();

            if (transaction.TransactionDetails != null)
            {
                transaction.TransactionDetails.ToList().ForEach(td =>
                {
                    TransactionDetail transactionDetail = Mapper.MapTransactionDetailSingle(td, true);

                    if (td.Product != null)
                    {
                        transactionDetail.Product = Mapper.MapProductSingle(td.Product, true);
                    }
                    remappedTransaction.TransactionDetails.Add(transactionDetail);
                });
            }

            if (transaction.Customer != null)
            {
                remappedTransaction.Customer = Mapper.MapCustomerSingle(transaction.Customer, true);
            }
            return remappedTransaction;
        }
    }

}
