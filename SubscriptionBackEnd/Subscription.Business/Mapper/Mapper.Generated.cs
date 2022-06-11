using System;
using Subscription.Business;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Subscription.Business
{
	public static class Mapper{

	


		public static void MapAddressFromToSingle(Address addressFrom,Address addressTo){
							addressTo.IdAddress = addressFrom.IdAddress;
							addressTo.AddressLine1 = addressFrom.AddressLine1;
							addressTo.AddressLine2 = addressFrom.AddressLine2;
							addressTo.AddressLine3 = addressFrom.AddressLine3;
							addressTo.AddressLine4 = addressFrom.AddressLine4;
							addressTo.Postcode = addressFrom.Postcode;
							addressTo.IdCity = addressFrom.IdCity;
							addressTo.IsDeactivated = addressFrom.IsDeactivated;
							addressTo.IdCountry = addressFrom.IdCountry;
							addressTo.City = addressFrom.City;
			

		}



		public static Address MapAddressSingle(Address address,bool singleEntityOnly = false){
            if(address !=null){
			Address _address = new Address();
							_address.IdAddress = address.IdAddress;
							_address.AddressLine1 = address.AddressLine1;
							_address.AddressLine2 = address.AddressLine2;
							_address.AddressLine3 = address.AddressLine3;
							_address.AddressLine4 = address.AddressLine4;
							_address.Postcode = address.Postcode;
							_address.IdCity = address.IdCity;
							_address.IsDeactivated = address.IsDeactivated;
							_address.IdCountry = address.IdCountry;
							_address.City = address.City;
			            if(!singleEntityOnly){
			    					    if(address.City1 !=null)
						    _address.City1 = MapCitySingle(address.City1,true);
				    					    if(address.Country !=null)
						    _address.Country = MapCountrySingle(address.Country,true);
				                }
			    return _address;
            }else{
                return null;
            }
		}
		public static List<Address> MapAddressList(List<Address> addressList){
			 List<Address> _addressList = new List<Address>();
             if(addressList !=null){
			     addressList.ForEach(l=>{
                    _addressList.Add(MapAddressSingle(l));
			     });
            }
			 return _addressList;
		}

        public static List<Address> MapAddressListWithSingleItemOnly(List<Address> addressList){
			 List<Address> _addressList = new List<Address>();
			 addressList.ForEach(l=>{
                _addressList.Add(MapAddressSingle(l,true));
			 });
			 return _addressList;
		}

	


		public static void MapApprovalMessageFromToSingle(ApprovalMessage approvalMessageFrom,ApprovalMessage approvalMessageTo){
							approvalMessageTo.IdApprovalMessage = approvalMessageFrom.IdApprovalMessage;
							approvalMessageTo.Description = approvalMessageFrom.Description;
							approvalMessageTo.IsDeactivated = approvalMessageFrom.IsDeactivated;
							approvalMessageTo.IdWorkflowToInitiate = approvalMessageFrom.IdWorkflowToInitiate;
							approvalMessageTo.IdWorkflowAction = approvalMessageFrom.IdWorkflowAction;
							approvalMessageTo.IsRequestRequired = approvalMessageFrom.IsRequestRequired;
							approvalMessageTo.IsPostApprovalRequired = approvalMessageFrom.IsPostApprovalRequired;
							approvalMessageTo.IsProgressBlocked = approvalMessageFrom.IsProgressBlocked;
			

		}



		public static ApprovalMessage MapApprovalMessageSingle(ApprovalMessage approvalMessage,bool singleEntityOnly = false){
            if(approvalMessage !=null){
			ApprovalMessage _approvalMessage = new ApprovalMessage();
							_approvalMessage.IdApprovalMessage = approvalMessage.IdApprovalMessage;
							_approvalMessage.Description = approvalMessage.Description;
							_approvalMessage.IsDeactivated = approvalMessage.IsDeactivated;
							_approvalMessage.IdWorkflowToInitiate = approvalMessage.IdWorkflowToInitiate;
							_approvalMessage.IdWorkflowAction = approvalMessage.IdWorkflowAction;
							_approvalMessage.IsRequestRequired = approvalMessage.IsRequestRequired;
							_approvalMessage.IsPostApprovalRequired = approvalMessage.IsPostApprovalRequired;
							_approvalMessage.IsProgressBlocked = approvalMessage.IsProgressBlocked;
			            if(!singleEntityOnly){
			    					    if(approvalMessage.WorkflowAction !=null)
						    _approvalMessage.WorkflowAction = MapWorkflowActionSingle(approvalMessage.WorkflowAction,true);
				    					    if(approvalMessage.Workflow !=null)
						    _approvalMessage.Workflow = MapWorkflowSingle(approvalMessage.Workflow,true);
				                }
			    return _approvalMessage;
            }else{
                return null;
            }
		}
		public static List<ApprovalMessage> MapApprovalMessageList(List<ApprovalMessage> approvalMessageList){
			 List<ApprovalMessage> _approvalMessageList = new List<ApprovalMessage>();
             if(approvalMessageList !=null){
			     approvalMessageList.ForEach(l=>{
                    _approvalMessageList.Add(MapApprovalMessageSingle(l));
			     });
            }
			 return _approvalMessageList;
		}

        public static List<ApprovalMessage> MapApprovalMessageListWithSingleItemOnly(List<ApprovalMessage> approvalMessageList){
			 List<ApprovalMessage> _approvalMessageList = new List<ApprovalMessage>();
			 approvalMessageList.ForEach(l=>{
                _approvalMessageList.Add(MapApprovalMessageSingle(l,true));
			 });
			 return _approvalMessageList;
		}

	


		public static void MapBankFromToSingle(Bank bankFrom,Bank bankTo){
							bankTo.IdBank = bankFrom.IdBank;
							bankTo.Description = bankFrom.Description;
							bankTo.IsDeactivated = bankFrom.IsDeactivated;
							bankTo.IdBankTransferPaymentMethod = bankFrom.IdBankTransferPaymentMethod;
							bankTo.IdTransactionAccount = bankFrom.IdTransactionAccount;
							bankTo.IdTransactionTemplate = bankFrom.IdTransactionTemplate;
			

		}



		public static Bank MapBankSingle(Bank bank,bool singleEntityOnly = false){
            if(bank !=null){
			Bank _bank = new Bank();
							_bank.IdBank = bank.IdBank;
							_bank.Description = bank.Description;
							_bank.IsDeactivated = bank.IsDeactivated;
							_bank.IdBankTransferPaymentMethod = bank.IdBankTransferPaymentMethod;
							_bank.IdTransactionAccount = bank.IdTransactionAccount;
							_bank.IdTransactionTemplate = bank.IdTransactionTemplate;
			            if(!singleEntityOnly){
			    					    if(bank.PaymentMethod !=null)
						    _bank.PaymentMethod = MapPaymentMethodSingle(bank.PaymentMethod,true);
				    					    if(bank.TransactionAccount !=null)
						    _bank.TransactionAccount = MapTransactionAccountSingle(bank.TransactionAccount,true);
				    					    if(bank.TransactionTemplate !=null)
						    _bank.TransactionTemplate = MapTransactionTemplateSingle(bank.TransactionTemplate,true);
				                }
			    return _bank;
            }else{
                return null;
            }
		}
		public static List<Bank> MapBankList(List<Bank> bankList){
			 List<Bank> _bankList = new List<Bank>();
             if(bankList !=null){
			     bankList.ForEach(l=>{
                    _bankList.Add(MapBankSingle(l));
			     });
            }
			 return _bankList;
		}

        public static List<Bank> MapBankListWithSingleItemOnly(List<Bank> bankList){
			 List<Bank> _bankList = new List<Bank>();
			 bankList.ForEach(l=>{
                _bankList.Add(MapBankSingle(l,true));
			 });
			 return _bankList;
		}

	


		public static void MapBankReconHitTypeFromToSingle(BankReconHitType bankReconHitTypeFrom,BankReconHitType bankReconHitTypeTo){
							bankReconHitTypeTo.IdBankReconHitType = bankReconHitTypeFrom.IdBankReconHitType;
							bankReconHitTypeTo.Description = bankReconHitTypeFrom.Description;
							bankReconHitTypeTo.IsDeactivated = bankReconHitTypeFrom.IsDeactivated;
			

		}



		public static BankReconHitType MapBankReconHitTypeSingle(BankReconHitType bankReconHitType,bool singleEntityOnly = false){
            if(bankReconHitType !=null){
			BankReconHitType _bankReconHitType = new BankReconHitType();
							_bankReconHitType.IdBankReconHitType = bankReconHitType.IdBankReconHitType;
							_bankReconHitType.Description = bankReconHitType.Description;
							_bankReconHitType.IsDeactivated = bankReconHitType.IsDeactivated;
			            if(!singleEntityOnly){
			                }
			    return _bankReconHitType;
            }else{
                return null;
            }
		}
		public static List<BankReconHitType> MapBankReconHitTypeList(List<BankReconHitType> bankReconHitTypeList){
			 List<BankReconHitType> _bankReconHitTypeList = new List<BankReconHitType>();
             if(bankReconHitTypeList !=null){
			     bankReconHitTypeList.ForEach(l=>{
                    _bankReconHitTypeList.Add(MapBankReconHitTypeSingle(l));
			     });
            }
			 return _bankReconHitTypeList;
		}

        public static List<BankReconHitType> MapBankReconHitTypeListWithSingleItemOnly(List<BankReconHitType> bankReconHitTypeList){
			 List<BankReconHitType> _bankReconHitTypeList = new List<BankReconHitType>();
			 bankReconHitTypeList.ForEach(l=>{
                _bankReconHitTypeList.Add(MapBankReconHitTypeSingle(l,true));
			 });
			 return _bankReconHitTypeList;
		}

	


		public static void MapBankReconOrderProcessStateFromToSingle(BankReconOrderProcessState bankReconOrderProcessStateFrom,BankReconOrderProcessState bankReconOrderProcessStateTo){
							bankReconOrderProcessStateTo.IdBankReconOrderProcessState = bankReconOrderProcessStateFrom.IdBankReconOrderProcessState;
							bankReconOrderProcessStateTo.IsDeactivated = bankReconOrderProcessStateFrom.IsDeactivated;
							bankReconOrderProcessStateTo.Description = bankReconOrderProcessStateFrom.Description;
			

		}



		public static BankReconOrderProcessState MapBankReconOrderProcessStateSingle(BankReconOrderProcessState bankReconOrderProcessState,bool singleEntityOnly = false){
            if(bankReconOrderProcessState !=null){
			BankReconOrderProcessState _bankReconOrderProcessState = new BankReconOrderProcessState();
							_bankReconOrderProcessState.IdBankReconOrderProcessState = bankReconOrderProcessState.IdBankReconOrderProcessState;
							_bankReconOrderProcessState.IsDeactivated = bankReconOrderProcessState.IsDeactivated;
							_bankReconOrderProcessState.Description = bankReconOrderProcessState.Description;
			            if(!singleEntityOnly){
			                }
			    return _bankReconOrderProcessState;
            }else{
                return null;
            }
		}
		public static List<BankReconOrderProcessState> MapBankReconOrderProcessStateList(List<BankReconOrderProcessState> bankReconOrderProcessStateList){
			 List<BankReconOrderProcessState> _bankReconOrderProcessStateList = new List<BankReconOrderProcessState>();
             if(bankReconOrderProcessStateList !=null){
			     bankReconOrderProcessStateList.ForEach(l=>{
                    _bankReconOrderProcessStateList.Add(MapBankReconOrderProcessStateSingle(l));
			     });
            }
			 return _bankReconOrderProcessStateList;
		}

        public static List<BankReconOrderProcessState> MapBankReconOrderProcessStateListWithSingleItemOnly(List<BankReconOrderProcessState> bankReconOrderProcessStateList){
			 List<BankReconOrderProcessState> _bankReconOrderProcessStateList = new List<BankReconOrderProcessState>();
			 bankReconOrderProcessStateList.ForEach(l=>{
                _bankReconOrderProcessStateList.Add(MapBankReconOrderProcessStateSingle(l,true));
			 });
			 return _bankReconOrderProcessStateList;
		}

	


		public static void MapBankReconOrderTypeFromToSingle(BankReconOrderType bankReconOrderTypeFrom,BankReconOrderType bankReconOrderTypeTo){
							bankReconOrderTypeTo.IdBankReconOrderType = bankReconOrderTypeFrom.IdBankReconOrderType;
							bankReconOrderTypeTo.IsDeactivated = bankReconOrderTypeFrom.IsDeactivated;
							bankReconOrderTypeTo.Description = bankReconOrderTypeFrom.Description;
			

		}



		public static BankReconOrderType MapBankReconOrderTypeSingle(BankReconOrderType bankReconOrderType,bool singleEntityOnly = false){
            if(bankReconOrderType !=null){
			BankReconOrderType _bankReconOrderType = new BankReconOrderType();
							_bankReconOrderType.IdBankReconOrderType = bankReconOrderType.IdBankReconOrderType;
							_bankReconOrderType.IsDeactivated = bankReconOrderType.IsDeactivated;
							_bankReconOrderType.Description = bankReconOrderType.Description;
			            if(!singleEntityOnly){
			                }
			    return _bankReconOrderType;
            }else{
                return null;
            }
		}
		public static List<BankReconOrderType> MapBankReconOrderTypeList(List<BankReconOrderType> bankReconOrderTypeList){
			 List<BankReconOrderType> _bankReconOrderTypeList = new List<BankReconOrderType>();
             if(bankReconOrderTypeList !=null){
			     bankReconOrderTypeList.ForEach(l=>{
                    _bankReconOrderTypeList.Add(MapBankReconOrderTypeSingle(l));
			     });
            }
			 return _bankReconOrderTypeList;
		}

        public static List<BankReconOrderType> MapBankReconOrderTypeListWithSingleItemOnly(List<BankReconOrderType> bankReconOrderTypeList){
			 List<BankReconOrderType> _bankReconOrderTypeList = new List<BankReconOrderType>();
			 bankReconOrderTypeList.ForEach(l=>{
                _bankReconOrderTypeList.Add(MapBankReconOrderTypeSingle(l,true));
			 });
			 return _bankReconOrderTypeList;
		}

	


		public static void MapBankStatementHitListFromToSingle(BankStatementHitList bankStatementHitListFrom,BankStatementHitList bankStatementHitListTo){
							bankStatementHitListTo.IdBankStatementHitList = bankStatementHitListFrom.IdBankStatementHitList;
							bankStatementHitListTo.Description = bankStatementHitListFrom.Description;
							bankStatementHitListTo.Amount = bankStatementHitListFrom.Amount;
							bankStatementHitListTo.HitCount = bankStatementHitListFrom.HitCount;
							bankStatementHitListTo.IsDeactivated = bankStatementHitListFrom.IsDeactivated;
							bankStatementHitListTo.IdBankStatementStagingDetail = bankStatementHitListFrom.IdBankStatementStagingDetail;
			

		}



		public static BankStatementHitList MapBankStatementHitListSingle(BankStatementHitList bankStatementHitList,bool singleEntityOnly = false){
            if(bankStatementHitList !=null){
			BankStatementHitList _bankStatementHitList = new BankStatementHitList();
							_bankStatementHitList.IdBankStatementHitList = bankStatementHitList.IdBankStatementHitList;
							_bankStatementHitList.Description = bankStatementHitList.Description;
							_bankStatementHitList.Amount = bankStatementHitList.Amount;
							_bankStatementHitList.HitCount = bankStatementHitList.HitCount;
							_bankStatementHitList.IsDeactivated = bankStatementHitList.IsDeactivated;
							_bankStatementHitList.IdBankStatementStagingDetail = bankStatementHitList.IdBankStatementStagingDetail;
			            if(!singleEntityOnly){
			    					    if(bankStatementHitList.BankStatementStagingDetail !=null)
						    _bankStatementHitList.BankStatementStagingDetail = MapBankStatementStagingDetailSingle(bankStatementHitList.BankStatementStagingDetail,true);
				                }
			    return _bankStatementHitList;
            }else{
                return null;
            }
		}
		public static List<BankStatementHitList> MapBankStatementHitListList(List<BankStatementHitList> bankStatementHitListList){
			 List<BankStatementHitList> _bankStatementHitListList = new List<BankStatementHitList>();
             if(bankStatementHitListList !=null){
			     bankStatementHitListList.ForEach(l=>{
                    _bankStatementHitListList.Add(MapBankStatementHitListSingle(l));
			     });
            }
			 return _bankStatementHitListList;
		}

        public static List<BankStatementHitList> MapBankStatementHitListListWithSingleItemOnly(List<BankStatementHitList> bankStatementHitListList){
			 List<BankStatementHitList> _bankStatementHitListList = new List<BankStatementHitList>();
			 bankStatementHitListList.ForEach(l=>{
                _bankStatementHitListList.Add(MapBankStatementHitListSingle(l,true));
			 });
			 return _bankStatementHitListList;
		}

	


		public static void MapBankStatementHitList_TransactionPresetFromToSingle(BankStatementHitList_TransactionPreset bankStatementHitList_TransactionPresetFrom,BankStatementHitList_TransactionPreset bankStatementHitList_TransactionPresetTo){
							bankStatementHitList_TransactionPresetTo.IdBankStatementHitList_TransactionPreset = bankStatementHitList_TransactionPresetFrom.IdBankStatementHitList_TransactionPreset;
							bankStatementHitList_TransactionPresetTo.IdBankStatementHitList = bankStatementHitList_TransactionPresetFrom.IdBankStatementHitList;
							bankStatementHitList_TransactionPresetTo.IdTransactionPreset = bankStatementHitList_TransactionPresetFrom.IdTransactionPreset;
							bankStatementHitList_TransactionPresetTo.IsDeactivated = bankStatementHitList_TransactionPresetFrom.IsDeactivated;
			

		}



		public static BankStatementHitList_TransactionPreset MapBankStatementHitList_TransactionPresetSingle(BankStatementHitList_TransactionPreset bankStatementHitList_TransactionPreset,bool singleEntityOnly = false){
            if(bankStatementHitList_TransactionPreset !=null){
			BankStatementHitList_TransactionPreset _bankStatementHitList_TransactionPreset = new BankStatementHitList_TransactionPreset();
							_bankStatementHitList_TransactionPreset.IdBankStatementHitList_TransactionPreset = bankStatementHitList_TransactionPreset.IdBankStatementHitList_TransactionPreset;
							_bankStatementHitList_TransactionPreset.IdBankStatementHitList = bankStatementHitList_TransactionPreset.IdBankStatementHitList;
							_bankStatementHitList_TransactionPreset.IdTransactionPreset = bankStatementHitList_TransactionPreset.IdTransactionPreset;
							_bankStatementHitList_TransactionPreset.IsDeactivated = bankStatementHitList_TransactionPreset.IsDeactivated;
			            if(!singleEntityOnly){
			    					    if(bankStatementHitList_TransactionPreset.BankStatementHitList !=null)
						    _bankStatementHitList_TransactionPreset.BankStatementHitList = MapBankStatementHitListSingle(bankStatementHitList_TransactionPreset.BankStatementHitList,true);
				    					    if(bankStatementHitList_TransactionPreset.TransactionPreset !=null)
						    _bankStatementHitList_TransactionPreset.TransactionPreset = MapTransactionPresetSingle(bankStatementHitList_TransactionPreset.TransactionPreset,true);
				                }
			    return _bankStatementHitList_TransactionPreset;
            }else{
                return null;
            }
		}
		public static List<BankStatementHitList_TransactionPreset> MapBankStatementHitList_TransactionPresetList(List<BankStatementHitList_TransactionPreset> bankStatementHitList_TransactionPresetList){
			 List<BankStatementHitList_TransactionPreset> _bankStatementHitList_TransactionPresetList = new List<BankStatementHitList_TransactionPreset>();
             if(bankStatementHitList_TransactionPresetList !=null){
			     bankStatementHitList_TransactionPresetList.ForEach(l=>{
                    _bankStatementHitList_TransactionPresetList.Add(MapBankStatementHitList_TransactionPresetSingle(l));
			     });
            }
			 return _bankStatementHitList_TransactionPresetList;
		}

        public static List<BankStatementHitList_TransactionPreset> MapBankStatementHitList_TransactionPresetListWithSingleItemOnly(List<BankStatementHitList_TransactionPreset> bankStatementHitList_TransactionPresetList){
			 List<BankStatementHitList_TransactionPreset> _bankStatementHitList_TransactionPresetList = new List<BankStatementHitList_TransactionPreset>();
			 bankStatementHitList_TransactionPresetList.ForEach(l=>{
                _bankStatementHitList_TransactionPresetList.Add(MapBankStatementHitList_TransactionPresetSingle(l,true));
			 });
			 return _bankStatementHitList_TransactionPresetList;
		}

	


		public static void MapBankStatementStagingFromToSingle(BankStatementStaging bankStatementStagingFrom,BankStatementStaging bankStatementStagingTo){
							bankStatementStagingTo.IdBankStatementStaging = bankStatementStagingFrom.IdBankStatementStaging;
							bankStatementStagingTo.UploadDate = bankStatementStagingFrom.UploadDate;
							bankStatementStagingTo.IdUserUploadedBy = bankStatementStagingFrom.IdUserUploadedBy;
							bankStatementStagingTo.Account = bankStatementStagingFrom.Account;
							bankStatementStagingTo.BankStatementDateFrom = bankStatementStagingFrom.BankStatementDateFrom;
							bankStatementStagingTo.BankStatementDateTo = bankStatementStagingFrom.BankStatementDateTo;
							bankStatementStagingTo.IsDeactivated = bankStatementStagingFrom.IsDeactivated;
							bankStatementStagingTo.IdDocument = bankStatementStagingFrom.IdDocument;
							bankStatementStagingTo.IdBankStatementStagingState = bankStatementStagingFrom.IdBankStatementStagingState;
							bankStatementStagingTo.IdBank = bankStatementStagingFrom.IdBank;
							bankStatementStagingTo.IdBankReconOrderProcessState = bankStatementStagingFrom.IdBankReconOrderProcessState;
			

		}



		public static BankStatementStaging MapBankStatementStagingSingle(BankStatementStaging bankStatementStaging,bool singleEntityOnly = false){
            if(bankStatementStaging !=null){
			BankStatementStaging _bankStatementStaging = new BankStatementStaging();
							_bankStatementStaging.IdBankStatementStaging = bankStatementStaging.IdBankStatementStaging;
							_bankStatementStaging.UploadDate = bankStatementStaging.UploadDate;
							_bankStatementStaging.IdUserUploadedBy = bankStatementStaging.IdUserUploadedBy;
							_bankStatementStaging.Account = bankStatementStaging.Account;
							_bankStatementStaging.BankStatementDateFrom = bankStatementStaging.BankStatementDateFrom;
							_bankStatementStaging.BankStatementDateTo = bankStatementStaging.BankStatementDateTo;
							_bankStatementStaging.IsDeactivated = bankStatementStaging.IsDeactivated;
							_bankStatementStaging.IdDocument = bankStatementStaging.IdDocument;
							_bankStatementStaging.IdBankStatementStagingState = bankStatementStaging.IdBankStatementStagingState;
							_bankStatementStaging.IdBank = bankStatementStaging.IdBank;
							_bankStatementStaging.IdBankReconOrderProcessState = bankStatementStaging.IdBankReconOrderProcessState;
			            if(!singleEntityOnly){
			    					    if(bankStatementStaging.BankReconOrderProcessState !=null)
						    _bankStatementStaging.BankReconOrderProcessState = MapBankReconOrderProcessStateSingle(bankStatementStaging.BankReconOrderProcessState,true);
				    					    if(bankStatementStaging.Bank !=null)
						    _bankStatementStaging.Bank = MapBankSingle(bankStatementStaging.Bank,true);
				    					    if(bankStatementStaging.BankStatementStagingState !=null)
						    _bankStatementStaging.BankStatementStagingState = MapBankStatementStagingStateSingle(bankStatementStaging.BankStatementStagingState,true);
				    					    if(bankStatementStaging.Document !=null)
						    _bankStatementStaging.Document = MapDocumentSingle(bankStatementStaging.Document,true);
				    					    if(bankStatementStaging.User !=null)
						    _bankStatementStaging.User = MapUserSingle(bankStatementStaging.User,true);
				                }
			    return _bankStatementStaging;
            }else{
                return null;
            }
		}
		public static List<BankStatementStaging> MapBankStatementStagingList(List<BankStatementStaging> bankStatementStagingList){
			 List<BankStatementStaging> _bankStatementStagingList = new List<BankStatementStaging>();
             if(bankStatementStagingList !=null){
			     bankStatementStagingList.ForEach(l=>{
                    _bankStatementStagingList.Add(MapBankStatementStagingSingle(l));
			     });
            }
			 return _bankStatementStagingList;
		}

        public static List<BankStatementStaging> MapBankStatementStagingListWithSingleItemOnly(List<BankStatementStaging> bankStatementStagingList){
			 List<BankStatementStaging> _bankStatementStagingList = new List<BankStatementStaging>();
			 bankStatementStagingList.ForEach(l=>{
                _bankStatementStagingList.Add(MapBankStatementStagingSingle(l,true));
			 });
			 return _bankStatementStagingList;
		}

	


		public static void MapBankStatementStagingDetailFromToSingle(BankStatementStagingDetail bankStatementStagingDetailFrom,BankStatementStagingDetail bankStatementStagingDetailTo){
							bankStatementStagingDetailTo.IdBankStatementStagingDetail = bankStatementStagingDetailFrom.IdBankStatementStagingDetail;
							bankStatementStagingDetailTo.IdBankStatementStaging = bankStatementStagingDetailFrom.IdBankStatementStaging;
							bankStatementStagingDetailTo.StatementLineNo = bankStatementStagingDetailFrom.StatementLineNo;
							bankStatementStagingDetailTo.ValueDate = bankStatementStagingDetailFrom.ValueDate;
							bankStatementStagingDetailTo.BranchCode = bankStatementStagingDetailFrom.BranchCode;
							bankStatementStagingDetailTo.Remarks = bankStatementStagingDetailFrom.Remarks;
							bankStatementStagingDetailTo.DebitAmount = bankStatementStagingDetailFrom.DebitAmount;
							bankStatementStagingDetailTo.CreditAmount = bankStatementStagingDetailFrom.CreditAmount;
							bankStatementStagingDetailTo.Balance = bankStatementStagingDetailFrom.Balance;
							bankStatementStagingDetailTo.IsDeactivated = bankStatementStagingDetailFrom.IsDeactivated;
							bankStatementStagingDetailTo.IdBankStatementStagingDetailBatch = bankStatementStagingDetailFrom.IdBankStatementStagingDetailBatch;
							bankStatementStagingDetailTo.IdBankReconOrderType = bankStatementStagingDetailFrom.IdBankReconOrderType;
							bankStatementStagingDetailTo.OrderNumber = bankStatementStagingDetailFrom.OrderNumber;
			

		}



		public static BankStatementStagingDetail MapBankStatementStagingDetailSingle(BankStatementStagingDetail bankStatementStagingDetail,bool singleEntityOnly = false){
            if(bankStatementStagingDetail !=null){
			BankStatementStagingDetail _bankStatementStagingDetail = new BankStatementStagingDetail();
							_bankStatementStagingDetail.IdBankStatementStagingDetail = bankStatementStagingDetail.IdBankStatementStagingDetail;
							_bankStatementStagingDetail.IdBankStatementStaging = bankStatementStagingDetail.IdBankStatementStaging;
							_bankStatementStagingDetail.StatementLineNo = bankStatementStagingDetail.StatementLineNo;
							_bankStatementStagingDetail.ValueDate = bankStatementStagingDetail.ValueDate;
							_bankStatementStagingDetail.BranchCode = bankStatementStagingDetail.BranchCode;
							_bankStatementStagingDetail.Remarks = bankStatementStagingDetail.Remarks;
							_bankStatementStagingDetail.DebitAmount = bankStatementStagingDetail.DebitAmount;
							_bankStatementStagingDetail.CreditAmount = bankStatementStagingDetail.CreditAmount;
							_bankStatementStagingDetail.Balance = bankStatementStagingDetail.Balance;
							_bankStatementStagingDetail.IsDeactivated = bankStatementStagingDetail.IsDeactivated;
							_bankStatementStagingDetail.IdBankStatementStagingDetailBatch = bankStatementStagingDetail.IdBankStatementStagingDetailBatch;
							_bankStatementStagingDetail.IdBankReconOrderType = bankStatementStagingDetail.IdBankReconOrderType;
							_bankStatementStagingDetail.OrderNumber = bankStatementStagingDetail.OrderNumber;
			            if(!singleEntityOnly){
			    					    if(bankStatementStagingDetail.BankReconOrderType !=null)
						    _bankStatementStagingDetail.BankReconOrderType = MapBankReconOrderTypeSingle(bankStatementStagingDetail.BankReconOrderType,true);
				    					    if(bankStatementStagingDetail.BankStatementStaging !=null)
						    _bankStatementStagingDetail.BankStatementStaging = MapBankStatementStagingSingle(bankStatementStagingDetail.BankStatementStaging,true);
				    					    if(bankStatementStagingDetail.BankStatementStagingDetailBatch !=null)
						    _bankStatementStagingDetail.BankStatementStagingDetailBatch = MapBankStatementStagingDetailBatchSingle(bankStatementStagingDetail.BankStatementStagingDetailBatch,true);
				                }
			    return _bankStatementStagingDetail;
            }else{
                return null;
            }
		}
		public static List<BankStatementStagingDetail> MapBankStatementStagingDetailList(List<BankStatementStagingDetail> bankStatementStagingDetailList){
			 List<BankStatementStagingDetail> _bankStatementStagingDetailList = new List<BankStatementStagingDetail>();
             if(bankStatementStagingDetailList !=null){
			     bankStatementStagingDetailList.ForEach(l=>{
                    _bankStatementStagingDetailList.Add(MapBankStatementStagingDetailSingle(l));
			     });
            }
			 return _bankStatementStagingDetailList;
		}

        public static List<BankStatementStagingDetail> MapBankStatementStagingDetailListWithSingleItemOnly(List<BankStatementStagingDetail> bankStatementStagingDetailList){
			 List<BankStatementStagingDetail> _bankStatementStagingDetailList = new List<BankStatementStagingDetail>();
			 bankStatementStagingDetailList.ForEach(l=>{
                _bankStatementStagingDetailList.Add(MapBankStatementStagingDetailSingle(l,true));
			 });
			 return _bankStatementStagingDetailList;
		}

	


		public static void MapBankStatementStagingDetailBatchFromToSingle(BankStatementStagingDetailBatch bankStatementStagingDetailBatchFrom,BankStatementStagingDetailBatch bankStatementStagingDetailBatchTo){
							bankStatementStagingDetailBatchTo.IdBankStatementStagingDetailBatch = bankStatementStagingDetailBatchFrom.IdBankStatementStagingDetailBatch;
							bankStatementStagingDetailBatchTo.IsDeactivated = bankStatementStagingDetailBatchFrom.IsDeactivated;
							bankStatementStagingDetailBatchTo.IdBankStatementStagingState = bankStatementStagingDetailBatchFrom.IdBankStatementStagingState;
							bankStatementStagingDetailBatchTo.BatchNumber = bankStatementStagingDetailBatchFrom.BatchNumber;
			

		}



		public static BankStatementStagingDetailBatch MapBankStatementStagingDetailBatchSingle(BankStatementStagingDetailBatch bankStatementStagingDetailBatch,bool singleEntityOnly = false){
            if(bankStatementStagingDetailBatch !=null){
			BankStatementStagingDetailBatch _bankStatementStagingDetailBatch = new BankStatementStagingDetailBatch();
							_bankStatementStagingDetailBatch.IdBankStatementStagingDetailBatch = bankStatementStagingDetailBatch.IdBankStatementStagingDetailBatch;
							_bankStatementStagingDetailBatch.IsDeactivated = bankStatementStagingDetailBatch.IsDeactivated;
							_bankStatementStagingDetailBatch.IdBankStatementStagingState = bankStatementStagingDetailBatch.IdBankStatementStagingState;
							_bankStatementStagingDetailBatch.BatchNumber = bankStatementStagingDetailBatch.BatchNumber;
			            if(!singleEntityOnly){
			    					    if(bankStatementStagingDetailBatch.BankStatementStagingState !=null)
						    _bankStatementStagingDetailBatch.BankStatementStagingState = MapBankStatementStagingStateSingle(bankStatementStagingDetailBatch.BankStatementStagingState,true);
				                }
			    return _bankStatementStagingDetailBatch;
            }else{
                return null;
            }
		}
		public static List<BankStatementStagingDetailBatch> MapBankStatementStagingDetailBatchList(List<BankStatementStagingDetailBatch> bankStatementStagingDetailBatchList){
			 List<BankStatementStagingDetailBatch> _bankStatementStagingDetailBatchList = new List<BankStatementStagingDetailBatch>();
             if(bankStatementStagingDetailBatchList !=null){
			     bankStatementStagingDetailBatchList.ForEach(l=>{
                    _bankStatementStagingDetailBatchList.Add(MapBankStatementStagingDetailBatchSingle(l));
			     });
            }
			 return _bankStatementStagingDetailBatchList;
		}

        public static List<BankStatementStagingDetailBatch> MapBankStatementStagingDetailBatchListWithSingleItemOnly(List<BankStatementStagingDetailBatch> bankStatementStagingDetailBatchList){
			 List<BankStatementStagingDetailBatch> _bankStatementStagingDetailBatchList = new List<BankStatementStagingDetailBatch>();
			 bankStatementStagingDetailBatchList.ForEach(l=>{
                _bankStatementStagingDetailBatchList.Add(MapBankStatementStagingDetailBatchSingle(l,true));
			 });
			 return _bankStatementStagingDetailBatchList;
		}

	


		public static void MapBankStatementStagingHitFromToSingle(BankStatementStagingHit bankStatementStagingHitFrom,BankStatementStagingHit bankStatementStagingHitTo){
							bankStatementStagingHitTo.IdBankStatementStagingHit = bankStatementStagingHitFrom.IdBankStatementStagingHit;
							bankStatementStagingHitTo.IdBankStatementStagingDetail = bankStatementStagingHitFrom.IdBankStatementStagingDetail;
							bankStatementStagingHitTo.HitCount = bankStatementStagingHitFrom.HitCount;
							bankStatementStagingHitTo.IdBankReconHitType = bankStatementStagingHitFrom.IdBankReconHitType;
							bankStatementStagingHitTo.IsDeactivated = bankStatementStagingHitFrom.IsDeactivated;
							bankStatementStagingHitTo.IdBankStatementHitList = bankStatementStagingHitFrom.IdBankStatementHitList;
							bankStatementStagingHitTo.IdOrder = bankStatementStagingHitFrom.IdOrder;
			

		}



		public static BankStatementStagingHit MapBankStatementStagingHitSingle(BankStatementStagingHit bankStatementStagingHit,bool singleEntityOnly = false){
            if(bankStatementStagingHit !=null){
			BankStatementStagingHit _bankStatementStagingHit = new BankStatementStagingHit();
							_bankStatementStagingHit.IdBankStatementStagingHit = bankStatementStagingHit.IdBankStatementStagingHit;
							_bankStatementStagingHit.IdBankStatementStagingDetail = bankStatementStagingHit.IdBankStatementStagingDetail;
							_bankStatementStagingHit.HitCount = bankStatementStagingHit.HitCount;
							_bankStatementStagingHit.IdBankReconHitType = bankStatementStagingHit.IdBankReconHitType;
							_bankStatementStagingHit.IsDeactivated = bankStatementStagingHit.IsDeactivated;
							_bankStatementStagingHit.IdBankStatementHitList = bankStatementStagingHit.IdBankStatementHitList;
							_bankStatementStagingHit.IdOrder = bankStatementStagingHit.IdOrder;
			            if(!singleEntityOnly){
			    					    if(bankStatementStagingHit.BankStatementHitList !=null)
						    _bankStatementStagingHit.BankStatementHitList = MapBankStatementHitListSingle(bankStatementStagingHit.BankStatementHitList,true);
				    					    if(bankStatementStagingHit.BankStatementStagingDetail !=null)
						    _bankStatementStagingHit.BankStatementStagingDetail = MapBankStatementStagingDetailSingle(bankStatementStagingHit.BankStatementStagingDetail,true);
				    					    if(bankStatementStagingHit.BankReconHitType !=null)
						    _bankStatementStagingHit.BankReconHitType = MapBankReconHitTypeSingle(bankStatementStagingHit.BankReconHitType,true);
				    					    if(bankStatementStagingHit.Order !=null)
						    _bankStatementStagingHit.Order = MapOrderSingle(bankStatementStagingHit.Order,true);
				                }
			    return _bankStatementStagingHit;
            }else{
                return null;
            }
		}
		public static List<BankStatementStagingHit> MapBankStatementStagingHitList(List<BankStatementStagingHit> bankStatementStagingHitList){
			 List<BankStatementStagingHit> _bankStatementStagingHitList = new List<BankStatementStagingHit>();
             if(bankStatementStagingHitList !=null){
			     bankStatementStagingHitList.ForEach(l=>{
                    _bankStatementStagingHitList.Add(MapBankStatementStagingHitSingle(l));
			     });
            }
			 return _bankStatementStagingHitList;
		}

        public static List<BankStatementStagingHit> MapBankStatementStagingHitListWithSingleItemOnly(List<BankStatementStagingHit> bankStatementStagingHitList){
			 List<BankStatementStagingHit> _bankStatementStagingHitList = new List<BankStatementStagingHit>();
			 bankStatementStagingHitList.ForEach(l=>{
                _bankStatementStagingHitList.Add(MapBankStatementStagingHitSingle(l,true));
			 });
			 return _bankStatementStagingHitList;
		}

	


		public static void MapBankStatementStagingHit_TransactionPresetFromToSingle(BankStatementStagingHit_TransactionPreset bankStatementStagingHit_TransactionPresetFrom,BankStatementStagingHit_TransactionPreset bankStatementStagingHit_TransactionPresetTo){
							bankStatementStagingHit_TransactionPresetTo.IdBankStatementStagingHit_TransactionPreset = bankStatementStagingHit_TransactionPresetFrom.IdBankStatementStagingHit_TransactionPreset;
							bankStatementStagingHit_TransactionPresetTo.IdBankStatementStagingHit = bankStatementStagingHit_TransactionPresetFrom.IdBankStatementStagingHit;
							bankStatementStagingHit_TransactionPresetTo.IdTransactionPreset = bankStatementStagingHit_TransactionPresetFrom.IdTransactionPreset;
							bankStatementStagingHit_TransactionPresetTo.IsDeactivated = bankStatementStagingHit_TransactionPresetFrom.IsDeactivated;
			

		}



		public static BankStatementStagingHit_TransactionPreset MapBankStatementStagingHit_TransactionPresetSingle(BankStatementStagingHit_TransactionPreset bankStatementStagingHit_TransactionPreset,bool singleEntityOnly = false){
            if(bankStatementStagingHit_TransactionPreset !=null){
			BankStatementStagingHit_TransactionPreset _bankStatementStagingHit_TransactionPreset = new BankStatementStagingHit_TransactionPreset();
							_bankStatementStagingHit_TransactionPreset.IdBankStatementStagingHit_TransactionPreset = bankStatementStagingHit_TransactionPreset.IdBankStatementStagingHit_TransactionPreset;
							_bankStatementStagingHit_TransactionPreset.IdBankStatementStagingHit = bankStatementStagingHit_TransactionPreset.IdBankStatementStagingHit;
							_bankStatementStagingHit_TransactionPreset.IdTransactionPreset = bankStatementStagingHit_TransactionPreset.IdTransactionPreset;
							_bankStatementStagingHit_TransactionPreset.IsDeactivated = bankStatementStagingHit_TransactionPreset.IsDeactivated;
			            if(!singleEntityOnly){
			    					    if(bankStatementStagingHit_TransactionPreset.BankStatementStagingHit !=null)
						    _bankStatementStagingHit_TransactionPreset.BankStatementStagingHit = MapBankStatementStagingHitSingle(bankStatementStagingHit_TransactionPreset.BankStatementStagingHit,true);
				    					    if(bankStatementStagingHit_TransactionPreset.TransactionPreset !=null)
						    _bankStatementStagingHit_TransactionPreset.TransactionPreset = MapTransactionPresetSingle(bankStatementStagingHit_TransactionPreset.TransactionPreset,true);
				                }
			    return _bankStatementStagingHit_TransactionPreset;
            }else{
                return null;
            }
		}
		public static List<BankStatementStagingHit_TransactionPreset> MapBankStatementStagingHit_TransactionPresetList(List<BankStatementStagingHit_TransactionPreset> bankStatementStagingHit_TransactionPresetList){
			 List<BankStatementStagingHit_TransactionPreset> _bankStatementStagingHit_TransactionPresetList = new List<BankStatementStagingHit_TransactionPreset>();
             if(bankStatementStagingHit_TransactionPresetList !=null){
			     bankStatementStagingHit_TransactionPresetList.ForEach(l=>{
                    _bankStatementStagingHit_TransactionPresetList.Add(MapBankStatementStagingHit_TransactionPresetSingle(l));
			     });
            }
			 return _bankStatementStagingHit_TransactionPresetList;
		}

        public static List<BankStatementStagingHit_TransactionPreset> MapBankStatementStagingHit_TransactionPresetListWithSingleItemOnly(List<BankStatementStagingHit_TransactionPreset> bankStatementStagingHit_TransactionPresetList){
			 List<BankStatementStagingHit_TransactionPreset> _bankStatementStagingHit_TransactionPresetList = new List<BankStatementStagingHit_TransactionPreset>();
			 bankStatementStagingHit_TransactionPresetList.ForEach(l=>{
                _bankStatementStagingHit_TransactionPresetList.Add(MapBankStatementStagingHit_TransactionPresetSingle(l,true));
			 });
			 return _bankStatementStagingHit_TransactionPresetList;
		}

	


		public static void MapBankStatementStagingStateFromToSingle(BankStatementStagingState bankStatementStagingStateFrom,BankStatementStagingState bankStatementStagingStateTo){
							bankStatementStagingStateTo.IdBankStatementStagingState = bankStatementStagingStateFrom.IdBankStatementStagingState;
							bankStatementStagingStateTo.IsDeactivated = bankStatementStagingStateFrom.IsDeactivated;
							bankStatementStagingStateTo.Description = bankStatementStagingStateFrom.Description;
			

		}



		public static BankStatementStagingState MapBankStatementStagingStateSingle(BankStatementStagingState bankStatementStagingState,bool singleEntityOnly = false){
            if(bankStatementStagingState !=null){
			BankStatementStagingState _bankStatementStagingState = new BankStatementStagingState();
							_bankStatementStagingState.IdBankStatementStagingState = bankStatementStagingState.IdBankStatementStagingState;
							_bankStatementStagingState.IsDeactivated = bankStatementStagingState.IsDeactivated;
							_bankStatementStagingState.Description = bankStatementStagingState.Description;
			            if(!singleEntityOnly){
			                }
			    return _bankStatementStagingState;
            }else{
                return null;
            }
		}
		public static List<BankStatementStagingState> MapBankStatementStagingStateList(List<BankStatementStagingState> bankStatementStagingStateList){
			 List<BankStatementStagingState> _bankStatementStagingStateList = new List<BankStatementStagingState>();
             if(bankStatementStagingStateList !=null){
			     bankStatementStagingStateList.ForEach(l=>{
                    _bankStatementStagingStateList.Add(MapBankStatementStagingStateSingle(l));
			     });
            }
			 return _bankStatementStagingStateList;
		}

        public static List<BankStatementStagingState> MapBankStatementStagingStateListWithSingleItemOnly(List<BankStatementStagingState> bankStatementStagingStateList){
			 List<BankStatementStagingState> _bankStatementStagingStateList = new List<BankStatementStagingState>();
			 bankStatementStagingStateList.ForEach(l=>{
                _bankStatementStagingStateList.Add(MapBankStatementStagingStateSingle(l,true));
			 });
			 return _bankStatementStagingStateList;
		}

	


		public static void MapCityFromToSingle(City cityFrom,City cityTo){
							cityTo.IdCity = cityFrom.IdCity;
							cityTo.Description = cityFrom.Description;
							cityTo.IsDeactivated = cityFrom.IsDeactivated;
							cityTo.IdCountry = cityFrom.IdCountry;
			

		}



		public static City MapCitySingle(City city,bool singleEntityOnly = false){
            if(city !=null){
			City _city = new City();
							_city.IdCity = city.IdCity;
							_city.Description = city.Description;
							_city.IsDeactivated = city.IsDeactivated;
							_city.IdCountry = city.IdCountry;
			            if(!singleEntityOnly){
			    					    if(city.Country !=null)
						    _city.Country = MapCountrySingle(city.Country,true);
				                }
			    return _city;
            }else{
                return null;
            }
		}
		public static List<City> MapCityList(List<City> cityList){
			 List<City> _cityList = new List<City>();
             if(cityList !=null){
			     cityList.ForEach(l=>{
                    _cityList.Add(MapCitySingle(l));
			     });
            }
			 return _cityList;
		}

        public static List<City> MapCityListWithSingleItemOnly(List<City> cityList){
			 List<City> _cityList = new List<City>();
			 cityList.ForEach(l=>{
                _cityList.Add(MapCitySingle(l,true));
			 });
			 return _cityList;
		}

	


		public static void MapCompanyFromToSingle(Company companyFrom,Company companyTo){
							companyTo.IdCompany = companyFrom.IdCompany;
							companyTo.Name = companyFrom.Name;
							companyTo.IsDeactivated = companyFrom.IsDeactivated;
							companyTo.Description = companyFrom.Description;
							companyTo.EstablishmentDate = companyFrom.EstablishmentDate;
							companyTo.IdEmployeeNoRange = companyFrom.IdEmployeeNoRange;
							companyTo.IdParentCompany = companyFrom.IdParentCompany;
							companyTo.RegistrationCode = companyFrom.RegistrationCode;
							companyTo.VatRegistrationNo = companyFrom.VatRegistrationNo;
							companyTo.IdCompanyLogo = companyFrom.IdCompanyLogo;
							companyTo.IdHostedDomain = companyFrom.IdHostedDomain;
							companyTo.IdOpeningHourType = companyFrom.IdOpeningHourType;
							companyTo.IdConcept = companyFrom.IdConcept;
			

		}



		public static Company MapCompanySingle(Company company,bool singleEntityOnly = false){
            if(company !=null){
			Company _company = new Company();
							_company.IdCompany = company.IdCompany;
							_company.Name = company.Name;
							_company.IsDeactivated = company.IsDeactivated;
							_company.Description = company.Description;
							_company.EstablishmentDate = company.EstablishmentDate;
							_company.IdEmployeeNoRange = company.IdEmployeeNoRange;
							_company.IdParentCompany = company.IdParentCompany;
							_company.RegistrationCode = company.RegistrationCode;
							_company.VatRegistrationNo = company.VatRegistrationNo;
							_company.IdCompanyLogo = company.IdCompanyLogo;
							_company.IdHostedDomain = company.IdHostedDomain;
							_company.IdOpeningHourType = company.IdOpeningHourType;
							_company.IdConcept = company.IdConcept;
			            if(!singleEntityOnly){
			    					    if(company.Concept !=null)
						    _company.Concept = MapConceptSingle(company.Concept,true);
				    					    if(company.Document !=null)
						    _company.Document = MapDocumentSingle(company.Document,true);
				                }
			    return _company;
            }else{
                return null;
            }
		}
		public static List<Company> MapCompanyList(List<Company> companyList){
			 List<Company> _companyList = new List<Company>();
             if(companyList !=null){
			     companyList.ForEach(l=>{
                    _companyList.Add(MapCompanySingle(l));
			     });
            }
			 return _companyList;
		}

        public static List<Company> MapCompanyListWithSingleItemOnly(List<Company> companyList){
			 List<Company> _companyList = new List<Company>();
			 companyList.ForEach(l=>{
                _companyList.Add(MapCompanySingle(l,true));
			 });
			 return _companyList;
		}

	


		public static void MapCompany_ContactTypeFromToSingle(Company_ContactType company_ContactTypeFrom,Company_ContactType company_ContactTypeTo){
							company_ContactTypeTo.IdCompany_ContactType = company_ContactTypeFrom.IdCompany_ContactType;
							company_ContactTypeTo.IdCompany = company_ContactTypeFrom.IdCompany;
							company_ContactTypeTo.IdContactType = company_ContactTypeFrom.IdContactType;
							company_ContactTypeTo.IsDeactivated = company_ContactTypeFrom.IsDeactivated;
							company_ContactTypeTo.Description = company_ContactTypeFrom.Description;
			

		}



		public static Company_ContactType MapCompany_ContactTypeSingle(Company_ContactType company_ContactType,bool singleEntityOnly = false){
            if(company_ContactType !=null){
			Company_ContactType _company_ContactType = new Company_ContactType();
							_company_ContactType.IdCompany_ContactType = company_ContactType.IdCompany_ContactType;
							_company_ContactType.IdCompany = company_ContactType.IdCompany;
							_company_ContactType.IdContactType = company_ContactType.IdContactType;
							_company_ContactType.IsDeactivated = company_ContactType.IsDeactivated;
							_company_ContactType.Description = company_ContactType.Description;
			            if(!singleEntityOnly){
			    					    if(company_ContactType.Company !=null)
						    _company_ContactType.Company = MapCompanySingle(company_ContactType.Company,true);
				    					    if(company_ContactType.ContactType !=null)
						    _company_ContactType.ContactType = MapContactTypeSingle(company_ContactType.ContactType,true);
				                }
			    return _company_ContactType;
            }else{
                return null;
            }
		}
		public static List<Company_ContactType> MapCompany_ContactTypeList(List<Company_ContactType> company_ContactTypeList){
			 List<Company_ContactType> _company_ContactTypeList = new List<Company_ContactType>();
             if(company_ContactTypeList !=null){
			     company_ContactTypeList.ForEach(l=>{
                    _company_ContactTypeList.Add(MapCompany_ContactTypeSingle(l));
			     });
            }
			 return _company_ContactTypeList;
		}

        public static List<Company_ContactType> MapCompany_ContactTypeListWithSingleItemOnly(List<Company_ContactType> company_ContactTypeList){
			 List<Company_ContactType> _company_ContactTypeList = new List<Company_ContactType>();
			 company_ContactTypeList.ForEach(l=>{
                _company_ContactTypeList.Add(MapCompany_ContactTypeSingle(l,true));
			 });
			 return _company_ContactTypeList;
		}

	


		public static void MapCompanyLocationFromToSingle(CompanyLocation companyLocationFrom,CompanyLocation companyLocationTo){
							companyLocationTo.IdCompanyLocation = companyLocationFrom.IdCompanyLocation;
							companyLocationTo.IdCompany = companyLocationFrom.IdCompany;
							companyLocationTo.IdAddress = companyLocationFrom.IdAddress;
							companyLocationTo.Detail = companyLocationFrom.Detail;
							companyLocationTo.IsDeactivated = companyLocationFrom.IsDeactivated;
							companyLocationTo.ColorCode = companyLocationFrom.ColorCode;
			

		}



		public static CompanyLocation MapCompanyLocationSingle(CompanyLocation companyLocation,bool singleEntityOnly = false){
            if(companyLocation !=null){
			CompanyLocation _companyLocation = new CompanyLocation();
							_companyLocation.IdCompanyLocation = companyLocation.IdCompanyLocation;
							_companyLocation.IdCompany = companyLocation.IdCompany;
							_companyLocation.IdAddress = companyLocation.IdAddress;
							_companyLocation.Detail = companyLocation.Detail;
							_companyLocation.IsDeactivated = companyLocation.IsDeactivated;
							_companyLocation.ColorCode = companyLocation.ColorCode;
			            if(!singleEntityOnly){
			    					    if(companyLocation.Company !=null)
						    _companyLocation.Company = MapCompanySingle(companyLocation.Company,true);
				    					    if(companyLocation.Address !=null)
						    _companyLocation.Address = MapAddressSingle(companyLocation.Address,true);
				                }
			    return _companyLocation;
            }else{
                return null;
            }
		}
		public static List<CompanyLocation> MapCompanyLocationList(List<CompanyLocation> companyLocationList){
			 List<CompanyLocation> _companyLocationList = new List<CompanyLocation>();
             if(companyLocationList !=null){
			     companyLocationList.ForEach(l=>{
                    _companyLocationList.Add(MapCompanyLocationSingle(l));
			     });
            }
			 return _companyLocationList;
		}

        public static List<CompanyLocation> MapCompanyLocationListWithSingleItemOnly(List<CompanyLocation> companyLocationList){
			 List<CompanyLocation> _companyLocationList = new List<CompanyLocation>();
			 companyLocationList.ForEach(l=>{
                _companyLocationList.Add(MapCompanyLocationSingle(l,true));
			 });
			 return _companyLocationList;
		}

	


		public static void MapConceptFromToSingle(Concept conceptFrom,Concept conceptTo){
							conceptTo.IdConcept = conceptFrom.IdConcept;
							conceptTo.IsDeactivated = conceptFrom.IsDeactivated;
							conceptTo.IdConceptType = conceptFrom.IdConceptType;
							conceptTo.IdCompany = conceptFrom.IdCompany;
							conceptTo.IdPerson = conceptFrom.IdPerson;
			

		}



		public static Concept MapConceptSingle(Concept concept,bool singleEntityOnly = false){
            if(concept !=null){
			Concept _concept = new Concept();
							_concept.IdConcept = concept.IdConcept;
							_concept.IsDeactivated = concept.IsDeactivated;
							_concept.IdConceptType = concept.IdConceptType;
							_concept.IdCompany = concept.IdCompany;
							_concept.IdPerson = concept.IdPerson;
			            if(!singleEntityOnly){
			    					    if(concept.Company !=null)
						    _concept.Company = MapCompanySingle(concept.Company,true);
				    					    if(concept.Person !=null)
						    _concept.Person = MapPersonSingle(concept.Person,true);
				                }
			    return _concept;
            }else{
                return null;
            }
		}
		public static List<Concept> MapConceptList(List<Concept> conceptList){
			 List<Concept> _conceptList = new List<Concept>();
             if(conceptList !=null){
			     conceptList.ForEach(l=>{
                    _conceptList.Add(MapConceptSingle(l));
			     });
            }
			 return _conceptList;
		}

        public static List<Concept> MapConceptListWithSingleItemOnly(List<Concept> conceptList){
			 List<Concept> _conceptList = new List<Concept>();
			 conceptList.ForEach(l=>{
                _conceptList.Add(MapConceptSingle(l,true));
			 });
			 return _conceptList;
		}

	


		public static void MapConcept_AddressFromToSingle(Concept_Address concept_AddressFrom,Concept_Address concept_AddressTo){
							concept_AddressTo.IdConcept_Address = concept_AddressFrom.IdConcept_Address;
							concept_AddressTo.IdConcept = concept_AddressFrom.IdConcept;
							concept_AddressTo.IdAddress = concept_AddressFrom.IdAddress;
							concept_AddressTo.IsDeactivated = concept_AddressFrom.IsDeactivated;
			

		}



		public static Concept_Address MapConcept_AddressSingle(Concept_Address concept_Address,bool singleEntityOnly = false){
            if(concept_Address !=null){
			Concept_Address _concept_Address = new Concept_Address();
							_concept_Address.IdConcept_Address = concept_Address.IdConcept_Address;
							_concept_Address.IdConcept = concept_Address.IdConcept;
							_concept_Address.IdAddress = concept_Address.IdAddress;
							_concept_Address.IsDeactivated = concept_Address.IsDeactivated;
			            if(!singleEntityOnly){
			    					    if(concept_Address.Concept !=null)
						    _concept_Address.Concept = MapConceptSingle(concept_Address.Concept,true);
				                }
			    return _concept_Address;
            }else{
                return null;
            }
		}
		public static List<Concept_Address> MapConcept_AddressList(List<Concept_Address> concept_AddressList){
			 List<Concept_Address> _concept_AddressList = new List<Concept_Address>();
             if(concept_AddressList !=null){
			     concept_AddressList.ForEach(l=>{
                    _concept_AddressList.Add(MapConcept_AddressSingle(l));
			     });
            }
			 return _concept_AddressList;
		}

        public static List<Concept_Address> MapConcept_AddressListWithSingleItemOnly(List<Concept_Address> concept_AddressList){
			 List<Concept_Address> _concept_AddressList = new List<Concept_Address>();
			 concept_AddressList.ForEach(l=>{
                _concept_AddressList.Add(MapConcept_AddressSingle(l,true));
			 });
			 return _concept_AddressList;
		}

	


		public static void MapConcept_ContactTypeFromToSingle(Concept_ContactType concept_ContactTypeFrom,Concept_ContactType concept_ContactTypeTo){
							concept_ContactTypeTo.IdConcept_ContactType = concept_ContactTypeFrom.IdConcept_ContactType;
							concept_ContactTypeTo.IdConcept = concept_ContactTypeFrom.IdConcept;
							concept_ContactTypeTo.IdContactType = concept_ContactTypeFrom.IdContactType;
							concept_ContactTypeTo.IsDeactivated = concept_ContactTypeFrom.IsDeactivated;
			

		}



		public static Concept_ContactType MapConcept_ContactTypeSingle(Concept_ContactType concept_ContactType,bool singleEntityOnly = false){
            if(concept_ContactType !=null){
			Concept_ContactType _concept_ContactType = new Concept_ContactType();
							_concept_ContactType.IdConcept_ContactType = concept_ContactType.IdConcept_ContactType;
							_concept_ContactType.IdConcept = concept_ContactType.IdConcept;
							_concept_ContactType.IdContactType = concept_ContactType.IdContactType;
							_concept_ContactType.IsDeactivated = concept_ContactType.IsDeactivated;
			            if(!singleEntityOnly){
			    					    if(concept_ContactType.ContactType !=null)
						    _concept_ContactType.ContactType = MapContactTypeSingle(concept_ContactType.ContactType,true);
				    					    if(concept_ContactType.Concept !=null)
						    _concept_ContactType.Concept = MapConceptSingle(concept_ContactType.Concept,true);
				                }
			    return _concept_ContactType;
            }else{
                return null;
            }
		}
		public static List<Concept_ContactType> MapConcept_ContactTypeList(List<Concept_ContactType> concept_ContactTypeList){
			 List<Concept_ContactType> _concept_ContactTypeList = new List<Concept_ContactType>();
             if(concept_ContactTypeList !=null){
			     concept_ContactTypeList.ForEach(l=>{
                    _concept_ContactTypeList.Add(MapConcept_ContactTypeSingle(l));
			     });
            }
			 return _concept_ContactTypeList;
		}

        public static List<Concept_ContactType> MapConcept_ContactTypeListWithSingleItemOnly(List<Concept_ContactType> concept_ContactTypeList){
			 List<Concept_ContactType> _concept_ContactTypeList = new List<Concept_ContactType>();
			 concept_ContactTypeList.ForEach(l=>{
                _concept_ContactTypeList.Add(MapConcept_ContactTypeSingle(l,true));
			 });
			 return _concept_ContactTypeList;
		}

	


		public static void MapContactFromToSingle(Contact contactFrom,Contact contactTo){
							contactTo.IdContact = contactFrom.IdContact;
							contactTo.Firstname = contactFrom.Firstname;
							contactTo.Lastname = contactFrom.Lastname;
							contactTo.Phone = contactFrom.Phone;
							contactTo.Fax = contactFrom.Fax;
							contactTo.Email = contactFrom.Email;
							contactTo.IdAddress = contactFrom.IdAddress;
							contactTo.IsDeactivated = contactFrom.IsDeactivated;
			

		}



		public static Contact MapContactSingle(Contact contact,bool singleEntityOnly = false){
            if(contact !=null){
			Contact _contact = new Contact();
							_contact.IdContact = contact.IdContact;
							_contact.Firstname = contact.Firstname;
							_contact.Lastname = contact.Lastname;
							_contact.Phone = contact.Phone;
							_contact.Fax = contact.Fax;
							_contact.Email = contact.Email;
							_contact.IdAddress = contact.IdAddress;
							_contact.IsDeactivated = contact.IsDeactivated;
			            if(!singleEntityOnly){
			    					    if(contact.Address !=null)
						    _contact.Address = MapAddressSingle(contact.Address,true);
				                }
			    return _contact;
            }else{
                return null;
            }
		}
		public static List<Contact> MapContactList(List<Contact> contactList){
			 List<Contact> _contactList = new List<Contact>();
             if(contactList !=null){
			     contactList.ForEach(l=>{
                    _contactList.Add(MapContactSingle(l));
			     });
            }
			 return _contactList;
		}

        public static List<Contact> MapContactListWithSingleItemOnly(List<Contact> contactList){
			 List<Contact> _contactList = new List<Contact>();
			 contactList.ForEach(l=>{
                _contactList.Add(MapContactSingle(l,true));
			 });
			 return _contactList;
		}

	


		public static void MapContactTypeFromToSingle(ContactType contactTypeFrom,ContactType contactTypeTo){
							contactTypeTo.IdContactType = contactTypeFrom.IdContactType;
							contactTypeTo.Description = contactTypeFrom.Description;
							contactTypeTo.IsDeactivated = contactTypeFrom.IsDeactivated;
							contactTypeTo.IdParentContactType = contactTypeFrom.IdParentContactType;
							contactTypeTo.DisplayOrder = contactTypeFrom.DisplayOrder;
							contactTypeTo.IconClass = contactTypeFrom.IconClass;
							contactTypeTo.Action = contactTypeFrom.Action;
			

		}



		public static ContactType MapContactTypeSingle(ContactType contactType,bool singleEntityOnly = false){
            if(contactType !=null){
			ContactType _contactType = new ContactType();
							_contactType.IdContactType = contactType.IdContactType;
							_contactType.Description = contactType.Description;
							_contactType.IsDeactivated = contactType.IsDeactivated;
							_contactType.IdParentContactType = contactType.IdParentContactType;
							_contactType.DisplayOrder = contactType.DisplayOrder;
							_contactType.IconClass = contactType.IconClass;
							_contactType.Action = contactType.Action;
			            if(!singleEntityOnly){
			    					    if(contactType.ContactType2 !=null)
						    _contactType.ContactType2 = MapContactTypeSingle(contactType.ContactType2,true);
				                }
			    return _contactType;
            }else{
                return null;
            }
		}
		public static List<ContactType> MapContactTypeList(List<ContactType> contactTypeList){
			 List<ContactType> _contactTypeList = new List<ContactType>();
             if(contactTypeList !=null){
			     contactTypeList.ForEach(l=>{
                    _contactTypeList.Add(MapContactTypeSingle(l));
			     });
            }
			 return _contactTypeList;
		}

        public static List<ContactType> MapContactTypeListWithSingleItemOnly(List<ContactType> contactTypeList){
			 List<ContactType> _contactTypeList = new List<ContactType>();
			 contactTypeList.ForEach(l=>{
                _contactTypeList.Add(MapContactTypeSingle(l,true));
			 });
			 return _contactTypeList;
		}

	


		public static void MapCountryFromToSingle(Country countryFrom,Country countryTo){
							countryTo.IdCountry = countryFrom.IdCountry;
							countryTo.Description = countryFrom.Description;
							countryTo.IsDeactivated = countryFrom.IsDeactivated;
			

		}



		public static Country MapCountrySingle(Country country,bool singleEntityOnly = false){
            if(country !=null){
			Country _country = new Country();
							_country.IdCountry = country.IdCountry;
							_country.Description = country.Description;
							_country.IsDeactivated = country.IsDeactivated;
			            if(!singleEntityOnly){
			                }
			    return _country;
            }else{
                return null;
            }
		}
		public static List<Country> MapCountryList(List<Country> countryList){
			 List<Country> _countryList = new List<Country>();
             if(countryList !=null){
			     countryList.ForEach(l=>{
                    _countryList.Add(MapCountrySingle(l));
			     });
            }
			 return _countryList;
		}

        public static List<Country> MapCountryListWithSingleItemOnly(List<Country> countryList){
			 List<Country> _countryList = new List<Country>();
			 countryList.ForEach(l=>{
                _countryList.Add(MapCountrySingle(l,true));
			 });
			 return _countryList;
		}

	


		public static void MapCustomerFromToSingle(Customer customerFrom,Customer customerTo){
							customerTo.IdCustomer = customerFrom.IdCustomer;
							customerTo.IsDeactivated = customerFrom.IsDeactivated;
							customerTo.FullName = customerFrom.FullName;
							customerTo.IdConcept = customerFrom.IdConcept;
							customerTo.IdPerson = customerFrom.IdPerson;
							customerTo.IdCompany = customerFrom.IdCompany;
							customerTo.IdCustomerType = customerFrom.IdCustomerType;
							customerTo.AccountNumber = customerFrom.AccountNumber;
			

		}



		public static Customer MapCustomerSingle(Customer customer,bool singleEntityOnly = false){
            if(customer !=null){
			Customer _customer = new Customer();
							_customer.IdCustomer = customer.IdCustomer;
							_customer.IsDeactivated = customer.IsDeactivated;
							_customer.FullName = customer.FullName;
							_customer.IdConcept = customer.IdConcept;
							_customer.IdPerson = customer.IdPerson;
							_customer.IdCompany = customer.IdCompany;
							_customer.IdCustomerType = customer.IdCustomerType;
							_customer.AccountNumber = customer.AccountNumber;
			            if(!singleEntityOnly){
			    					    if(customer.Company !=null)
						    _customer.Company = MapCompanySingle(customer.Company,true);
				    					    if(customer.CustomerType !=null)
						    _customer.CustomerType = MapCustomerTypeSingle(customer.CustomerType,true);
				    					    if(customer.Concept !=null)
						    _customer.Concept = MapConceptSingle(customer.Concept,true);
				    					    if(customer.Person !=null)
						    _customer.Person = MapPersonSingle(customer.Person,true);
				                }
			    return _customer;
            }else{
                return null;
            }
		}
		public static List<Customer> MapCustomerList(List<Customer> customerList){
			 List<Customer> _customerList = new List<Customer>();
             if(customerList !=null){
			     customerList.ForEach(l=>{
                    _customerList.Add(MapCustomerSingle(l));
			     });
            }
			 return _customerList;
		}

        public static List<Customer> MapCustomerListWithSingleItemOnly(List<Customer> customerList){
			 List<Customer> _customerList = new List<Customer>();
			 customerList.ForEach(l=>{
                _customerList.Add(MapCustomerSingle(l,true));
			 });
			 return _customerList;
		}

	


		public static void MapCustomerTypeFromToSingle(CustomerType customerTypeFrom,CustomerType customerTypeTo){
							customerTypeTo.IdCustomerType = customerTypeFrom.IdCustomerType;
							customerTypeTo.Description = customerTypeFrom.Description;
							customerTypeTo.IsDeactivated = customerTypeFrom.IsDeactivated;
			

		}



		public static CustomerType MapCustomerTypeSingle(CustomerType customerType,bool singleEntityOnly = false){
            if(customerType !=null){
			CustomerType _customerType = new CustomerType();
							_customerType.IdCustomerType = customerType.IdCustomerType;
							_customerType.Description = customerType.Description;
							_customerType.IsDeactivated = customerType.IsDeactivated;
			            if(!singleEntityOnly){
			                }
			    return _customerType;
            }else{
                return null;
            }
		}
		public static List<CustomerType> MapCustomerTypeList(List<CustomerType> customerTypeList){
			 List<CustomerType> _customerTypeList = new List<CustomerType>();
             if(customerTypeList !=null){
			     customerTypeList.ForEach(l=>{
                    _customerTypeList.Add(MapCustomerTypeSingle(l));
			     });
            }
			 return _customerTypeList;
		}

        public static List<CustomerType> MapCustomerTypeListWithSingleItemOnly(List<CustomerType> customerTypeList){
			 List<CustomerType> _customerTypeList = new List<CustomerType>();
			 customerTypeList.ForEach(l=>{
                _customerTypeList.Add(MapCustomerTypeSingle(l,true));
			 });
			 return _customerTypeList;
		}

	


		public static void MapDocumentFromToSingle(Document documentFrom,Document documentTo){
							documentTo.IdDocument = documentFrom.IdDocument;
							documentTo.FileName = documentFrom.FileName;
							documentTo.FileExtension = documentFrom.FileExtension;
							documentTo.PhysicalFilePath = documentFrom.PhysicalFilePath;
							documentTo.DocumentOrder = documentFrom.DocumentOrder;
							documentTo.IsDeactivated = documentFrom.IsDeactivated;
							documentTo.IdDocumentType = documentFrom.IdDocumentType;
							documentTo.IdParameterBasePhysicalFilePath = documentFrom.IdParameterBasePhysicalFilePath;
							documentTo.IdParameterBaseServerUrl = documentFrom.IdParameterBaseServerUrl;
							documentTo.ServerFilePath = documentFrom.ServerFilePath;
			

		}



		public static Document MapDocumentSingle(Document document,bool singleEntityOnly = false){
            if(document !=null){
			Document _document = new Document();
							_document.IdDocument = document.IdDocument;
							_document.FileName = document.FileName;
							_document.FileExtension = document.FileExtension;
							_document.PhysicalFilePath = document.PhysicalFilePath;
							_document.DocumentOrder = document.DocumentOrder;
							_document.IsDeactivated = document.IsDeactivated;
							_document.IdDocumentType = document.IdDocumentType;
							_document.IdParameterBasePhysicalFilePath = document.IdParameterBasePhysicalFilePath;
							_document.IdParameterBaseServerUrl = document.IdParameterBaseServerUrl;
							_document.ServerFilePath = document.ServerFilePath;
			            if(!singleEntityOnly){
			    					    if(document.DocumentType !=null)
						    _document.DocumentType = MapDocumentTypeSingle(document.DocumentType,true);
				    					    if(document.Parameter !=null)
						    _document.Parameter = MapParameterSingle(document.Parameter,true);
				    					    if(document.Parameter1 !=null)
						    _document.Parameter1 = MapParameterSingle(document.Parameter1,true);
				                }
			    return _document;
            }else{
                return null;
            }
		}
		public static List<Document> MapDocumentList(List<Document> documentList){
			 List<Document> _documentList = new List<Document>();
             if(documentList !=null){
			     documentList.ForEach(l=>{
                    _documentList.Add(MapDocumentSingle(l));
			     });
            }
			 return _documentList;
		}

        public static List<Document> MapDocumentListWithSingleItemOnly(List<Document> documentList){
			 List<Document> _documentList = new List<Document>();
			 documentList.ForEach(l=>{
                _documentList.Add(MapDocumentSingle(l,true));
			 });
			 return _documentList;
		}

	


		public static void MapDocumentTypeFromToSingle(DocumentType documentTypeFrom,DocumentType documentTypeTo){
							documentTypeTo.IdDocumentType = documentTypeFrom.IdDocumentType;
							documentTypeTo.Description = documentTypeFrom.Description;
							documentTypeTo.IsDeactivated = documentTypeFrom.IsDeactivated;
			

		}



		public static DocumentType MapDocumentTypeSingle(DocumentType documentType,bool singleEntityOnly = false){
            if(documentType !=null){
			DocumentType _documentType = new DocumentType();
							_documentType.IdDocumentType = documentType.IdDocumentType;
							_documentType.Description = documentType.Description;
							_documentType.IsDeactivated = documentType.IsDeactivated;
			            if(!singleEntityOnly){
			                }
			    return _documentType;
            }else{
                return null;
            }
		}
		public static List<DocumentType> MapDocumentTypeList(List<DocumentType> documentTypeList){
			 List<DocumentType> _documentTypeList = new List<DocumentType>();
             if(documentTypeList !=null){
			     documentTypeList.ForEach(l=>{
                    _documentTypeList.Add(MapDocumentTypeSingle(l));
			     });
            }
			 return _documentTypeList;
		}

        public static List<DocumentType> MapDocumentTypeListWithSingleItemOnly(List<DocumentType> documentTypeList){
			 List<DocumentType> _documentTypeList = new List<DocumentType>();
			 documentTypeList.ForEach(l=>{
                _documentTypeList.Add(MapDocumentTypeSingle(l,true));
			 });
			 return _documentTypeList;
		}

	


		public static void MapEndTypeFromToSingle(EndType endTypeFrom,EndType endTypeTo){
							endTypeTo.IdEndType = endTypeFrom.IdEndType;
							endTypeTo.IsDeactivated = endTypeFrom.IsDeactivated;
							endTypeTo.Description = endTypeFrom.Description;
			

		}



		public static EndType MapEndTypeSingle(EndType endType,bool singleEntityOnly = false){
            if(endType !=null){
			EndType _endType = new EndType();
							_endType.IdEndType = endType.IdEndType;
							_endType.IsDeactivated = endType.IsDeactivated;
							_endType.Description = endType.Description;
			            if(!singleEntityOnly){
			                }
			    return _endType;
            }else{
                return null;
            }
		}
		public static List<EndType> MapEndTypeList(List<EndType> endTypeList){
			 List<EndType> _endTypeList = new List<EndType>();
             if(endTypeList !=null){
			     endTypeList.ForEach(l=>{
                    _endTypeList.Add(MapEndTypeSingle(l));
			     });
            }
			 return _endTypeList;
		}

        public static List<EndType> MapEndTypeListWithSingleItemOnly(List<EndType> endTypeList){
			 List<EndType> _endTypeList = new List<EndType>();
			 endTypeList.ForEach(l=>{
                _endTypeList.Add(MapEndTypeSingle(l,true));
			 });
			 return _endTypeList;
		}

	


		public static void MapFrequencyFromToSingle(Frequency frequencyFrom,Frequency frequencyTo){
							frequencyTo.IdFrequency = frequencyFrom.IdFrequency;
							frequencyTo.Description = frequencyFrom.Description;
							frequencyTo.IsDeactivated = frequencyFrom.IsDeactivated;
			

		}



		public static Frequency MapFrequencySingle(Frequency frequency,bool singleEntityOnly = false){
            if(frequency !=null){
			Frequency _frequency = new Frequency();
							_frequency.IdFrequency = frequency.IdFrequency;
							_frequency.Description = frequency.Description;
							_frequency.IsDeactivated = frequency.IsDeactivated;
			            if(!singleEntityOnly){
			                }
			    return _frequency;
            }else{
                return null;
            }
		}
		public static List<Frequency> MapFrequencyList(List<Frequency> frequencyList){
			 List<Frequency> _frequencyList = new List<Frequency>();
             if(frequencyList !=null){
			     frequencyList.ForEach(l=>{
                    _frequencyList.Add(MapFrequencySingle(l));
			     });
            }
			 return _frequencyList;
		}

        public static List<Frequency> MapFrequencyListWithSingleItemOnly(List<Frequency> frequencyList){
			 List<Frequency> _frequencyList = new List<Frequency>();
			 frequencyList.ForEach(l=>{
                _frequencyList.Add(MapFrequencySingle(l,true));
			 });
			 return _frequencyList;
		}

	


		public static void MapMailRecipientFromToSingle(MailRecipient mailRecipientFrom,MailRecipient mailRecipientTo){
							mailRecipientTo.IdMailRecipient = mailRecipientFrom.IdMailRecipient;
							mailRecipientTo.Name = mailRecipientFrom.Name;
							mailRecipientTo.EmailAddress = mailRecipientFrom.EmailAddress;
							mailRecipientTo.IsDeactivated = mailRecipientFrom.IsDeactivated;
							mailRecipientTo.IdMailToSend = mailRecipientFrom.IdMailToSend;
							mailRecipientTo.IdMailStatus = mailRecipientFrom.IdMailStatus;
							mailRecipientTo.IdMailRecipientType = mailRecipientFrom.IdMailRecipientType;
			

		}



		public static MailRecipient MapMailRecipientSingle(MailRecipient mailRecipient,bool singleEntityOnly = false){
            if(mailRecipient !=null){
			MailRecipient _mailRecipient = new MailRecipient();
							_mailRecipient.IdMailRecipient = mailRecipient.IdMailRecipient;
							_mailRecipient.Name = mailRecipient.Name;
							_mailRecipient.EmailAddress = mailRecipient.EmailAddress;
							_mailRecipient.IsDeactivated = mailRecipient.IsDeactivated;
							_mailRecipient.IdMailToSend = mailRecipient.IdMailToSend;
							_mailRecipient.IdMailStatus = mailRecipient.IdMailStatus;
							_mailRecipient.IdMailRecipientType = mailRecipient.IdMailRecipientType;
			            if(!singleEntityOnly){
			    					    if(mailRecipient.MailRecipientType !=null)
						    _mailRecipient.MailRecipientType = MapMailRecipientTypeSingle(mailRecipient.MailRecipientType,true);
				    					    if(mailRecipient.MailStatu !=null)
						    _mailRecipient.MailStatu = MapMailStatuSingle(mailRecipient.MailStatu,true);
				    					    if(mailRecipient.MailToSend !=null)
						    _mailRecipient.MailToSend = MapMailToSendSingle(mailRecipient.MailToSend,true);
				                }
			    return _mailRecipient;
            }else{
                return null;
            }
		}
		public static List<MailRecipient> MapMailRecipientList(List<MailRecipient> mailRecipientList){
			 List<MailRecipient> _mailRecipientList = new List<MailRecipient>();
             if(mailRecipientList !=null){
			     mailRecipientList.ForEach(l=>{
                    _mailRecipientList.Add(MapMailRecipientSingle(l));
			     });
            }
			 return _mailRecipientList;
		}

        public static List<MailRecipient> MapMailRecipientListWithSingleItemOnly(List<MailRecipient> mailRecipientList){
			 List<MailRecipient> _mailRecipientList = new List<MailRecipient>();
			 mailRecipientList.ForEach(l=>{
                _mailRecipientList.Add(MapMailRecipientSingle(l,true));
			 });
			 return _mailRecipientList;
		}

	


		public static void MapMailRecipientTypeFromToSingle(MailRecipientType mailRecipientTypeFrom,MailRecipientType mailRecipientTypeTo){
							mailRecipientTypeTo.IdMailRecipientType = mailRecipientTypeFrom.IdMailRecipientType;
							mailRecipientTypeTo.Description = mailRecipientTypeFrom.Description;
							mailRecipientTypeTo.IsDeactivated = mailRecipientTypeFrom.IsDeactivated;
			

		}



		public static MailRecipientType MapMailRecipientTypeSingle(MailRecipientType mailRecipientType,bool singleEntityOnly = false){
            if(mailRecipientType !=null){
			MailRecipientType _mailRecipientType = new MailRecipientType();
							_mailRecipientType.IdMailRecipientType = mailRecipientType.IdMailRecipientType;
							_mailRecipientType.Description = mailRecipientType.Description;
							_mailRecipientType.IsDeactivated = mailRecipientType.IsDeactivated;
			            if(!singleEntityOnly){
			                }
			    return _mailRecipientType;
            }else{
                return null;
            }
		}
		public static List<MailRecipientType> MapMailRecipientTypeList(List<MailRecipientType> mailRecipientTypeList){
			 List<MailRecipientType> _mailRecipientTypeList = new List<MailRecipientType>();
             if(mailRecipientTypeList !=null){
			     mailRecipientTypeList.ForEach(l=>{
                    _mailRecipientTypeList.Add(MapMailRecipientTypeSingle(l));
			     });
            }
			 return _mailRecipientTypeList;
		}

        public static List<MailRecipientType> MapMailRecipientTypeListWithSingleItemOnly(List<MailRecipientType> mailRecipientTypeList){
			 List<MailRecipientType> _mailRecipientTypeList = new List<MailRecipientType>();
			 mailRecipientTypeList.ForEach(l=>{
                _mailRecipientTypeList.Add(MapMailRecipientTypeSingle(l,true));
			 });
			 return _mailRecipientTypeList;
		}

	


		public static void MapMailServerSettingFromToSingle(MailServerSetting mailServerSettingFrom,MailServerSetting mailServerSettingTo){
							mailServerSettingTo.IdMailServerSetting = mailServerSettingFrom.IdMailServerSetting;
							mailServerSettingTo.UseSSL = mailServerSettingFrom.UseSSL;
							mailServerSettingTo.ClientPort = mailServerSettingFrom.ClientPort;
							mailServerSettingTo.Host = mailServerSettingFrom.Host;
							mailServerSettingTo.Username = mailServerSettingFrom.Username;
							mailServerSettingTo.Password = mailServerSettingFrom.Password;
							mailServerSettingTo.IsDeactivated = mailServerSettingFrom.IsDeactivated;
							mailServerSettingTo.Priority = mailServerSettingFrom.Priority;
							mailServerSettingTo.DefaultName = mailServerSettingFrom.DefaultName;
			

		}



		public static MailServerSetting MapMailServerSettingSingle(MailServerSetting mailServerSetting,bool singleEntityOnly = false){
            if(mailServerSetting !=null){
			MailServerSetting _mailServerSetting = new MailServerSetting();
							_mailServerSetting.IdMailServerSetting = mailServerSetting.IdMailServerSetting;
							_mailServerSetting.UseSSL = mailServerSetting.UseSSL;
							_mailServerSetting.ClientPort = mailServerSetting.ClientPort;
							_mailServerSetting.Host = mailServerSetting.Host;
							_mailServerSetting.Username = mailServerSetting.Username;
							_mailServerSetting.Password = mailServerSetting.Password;
							_mailServerSetting.IsDeactivated = mailServerSetting.IsDeactivated;
							_mailServerSetting.Priority = mailServerSetting.Priority;
							_mailServerSetting.DefaultName = mailServerSetting.DefaultName;
			            if(!singleEntityOnly){
			                }
			    return _mailServerSetting;
            }else{
                return null;
            }
		}
		public static List<MailServerSetting> MapMailServerSettingList(List<MailServerSetting> mailServerSettingList){
			 List<MailServerSetting> _mailServerSettingList = new List<MailServerSetting>();
             if(mailServerSettingList !=null){
			     mailServerSettingList.ForEach(l=>{
                    _mailServerSettingList.Add(MapMailServerSettingSingle(l));
			     });
            }
			 return _mailServerSettingList;
		}

        public static List<MailServerSetting> MapMailServerSettingListWithSingleItemOnly(List<MailServerSetting> mailServerSettingList){
			 List<MailServerSetting> _mailServerSettingList = new List<MailServerSetting>();
			 mailServerSettingList.ForEach(l=>{
                _mailServerSettingList.Add(MapMailServerSettingSingle(l,true));
			 });
			 return _mailServerSettingList;
		}

	


		public static void MapMailStatuFromToSingle(MailStatu mailStatuFrom,MailStatu mailStatuTo){
							mailStatuTo.IdMailStatus = mailStatuFrom.IdMailStatus;
							mailStatuTo.Description = mailStatuFrom.Description;
							mailStatuTo.IsDeactivated = mailStatuFrom.IsDeactivated;
			

		}



		public static MailStatu MapMailStatuSingle(MailStatu mailStatu,bool singleEntityOnly = false){
            if(mailStatu !=null){
			MailStatu _mailStatu = new MailStatu();
							_mailStatu.IdMailStatus = mailStatu.IdMailStatus;
							_mailStatu.Description = mailStatu.Description;
							_mailStatu.IsDeactivated = mailStatu.IsDeactivated;
			            if(!singleEntityOnly){
			                }
			    return _mailStatu;
            }else{
                return null;
            }
		}
		public static List<MailStatu> MapMailStatuList(List<MailStatu> mailStatuList){
			 List<MailStatu> _mailStatuList = new List<MailStatu>();
             if(mailStatuList !=null){
			     mailStatuList.ForEach(l=>{
                    _mailStatuList.Add(MapMailStatuSingle(l));
			     });
            }
			 return _mailStatuList;
		}

        public static List<MailStatu> MapMailStatuListWithSingleItemOnly(List<MailStatu> mailStatuList){
			 List<MailStatu> _mailStatuList = new List<MailStatu>();
			 mailStatuList.ForEach(l=>{
                _mailStatuList.Add(MapMailStatuSingle(l,true));
			 });
			 return _mailStatuList;
		}

	


		public static void MapMailToSendFromToSingle(MailToSend mailToSendFrom,MailToSend mailToSendTo){
							mailToSendTo.IdMailToSend = mailToSendFrom.IdMailToSend;
							mailToSendTo.IdMailServerSetting = mailToSendFrom.IdMailServerSetting;
							mailToSendTo.IdEmailStatus = mailToSendFrom.IdEmailStatus;
							mailToSendTo.FailureCount = mailToSendFrom.FailureCount;
							mailToSendTo.EmailSubject = mailToSendFrom.EmailSubject;
							mailToSendTo.ErrorMessage = mailToSendFrom.ErrorMessage;
							mailToSendTo.EmailBody = mailToSendFrom.EmailBody;
							mailToSendTo.IsDeactivated = mailToSendFrom.IsDeactivated;
			

		}



		public static MailToSend MapMailToSendSingle(MailToSend mailToSend,bool singleEntityOnly = false){
            if(mailToSend !=null){
			MailToSend _mailToSend = new MailToSend();
							_mailToSend.IdMailToSend = mailToSend.IdMailToSend;
							_mailToSend.IdMailServerSetting = mailToSend.IdMailServerSetting;
							_mailToSend.IdEmailStatus = mailToSend.IdEmailStatus;
							_mailToSend.FailureCount = mailToSend.FailureCount;
							_mailToSend.EmailSubject = mailToSend.EmailSubject;
							_mailToSend.ErrorMessage = mailToSend.ErrorMessage;
							_mailToSend.EmailBody = mailToSend.EmailBody;
							_mailToSend.IsDeactivated = mailToSend.IsDeactivated;
			            if(!singleEntityOnly){
			    					    if(mailToSend.MailServerSetting !=null)
						    _mailToSend.MailServerSetting = MapMailServerSettingSingle(mailToSend.MailServerSetting,true);
				    					    if(mailToSend.MailStatu !=null)
						    _mailToSend.MailStatu = MapMailStatuSingle(mailToSend.MailStatu,true);
				                }
			    return _mailToSend;
            }else{
                return null;
            }
		}
		public static List<MailToSend> MapMailToSendList(List<MailToSend> mailToSendList){
			 List<MailToSend> _mailToSendList = new List<MailToSend>();
             if(mailToSendList !=null){
			     mailToSendList.ForEach(l=>{
                    _mailToSendList.Add(MapMailToSendSingle(l));
			     });
            }
			 return _mailToSendList;
		}

        public static List<MailToSend> MapMailToSendListWithSingleItemOnly(List<MailToSend> mailToSendList){
			 List<MailToSend> _mailToSendList = new List<MailToSend>();
			 mailToSendList.ForEach(l=>{
                _mailToSendList.Add(MapMailToSendSingle(l,true));
			 });
			 return _mailToSendList;
		}

	


		public static void MapMailToSendDocumentFromToSingle(MailToSendDocument mailToSendDocumentFrom,MailToSendDocument mailToSendDocumentTo){
							mailToSendDocumentTo.IdMailToSendDocument = mailToSendDocumentFrom.IdMailToSendDocument;
							mailToSendDocumentTo.IdMailToSend = mailToSendDocumentFrom.IdMailToSend;
							mailToSendDocumentTo.IsDeactivated = mailToSendDocumentFrom.IsDeactivated;
							mailToSendDocumentTo.RelativeDocumentPath = mailToSendDocumentFrom.RelativeDocumentPath;
							mailToSendDocumentTo.DocumentName = mailToSendDocumentFrom.DocumentName;
			

		}



		public static MailToSendDocument MapMailToSendDocumentSingle(MailToSendDocument mailToSendDocument,bool singleEntityOnly = false){
            if(mailToSendDocument !=null){
			MailToSendDocument _mailToSendDocument = new MailToSendDocument();
							_mailToSendDocument.IdMailToSendDocument = mailToSendDocument.IdMailToSendDocument;
							_mailToSendDocument.IdMailToSend = mailToSendDocument.IdMailToSend;
							_mailToSendDocument.IsDeactivated = mailToSendDocument.IsDeactivated;
							_mailToSendDocument.RelativeDocumentPath = mailToSendDocument.RelativeDocumentPath;
							_mailToSendDocument.DocumentName = mailToSendDocument.DocumentName;
			            if(!singleEntityOnly){
			    					    if(mailToSendDocument.MailToSend !=null)
						    _mailToSendDocument.MailToSend = MapMailToSendSingle(mailToSendDocument.MailToSend,true);
				                }
			    return _mailToSendDocument;
            }else{
                return null;
            }
		}
		public static List<MailToSendDocument> MapMailToSendDocumentList(List<MailToSendDocument> mailToSendDocumentList){
			 List<MailToSendDocument> _mailToSendDocumentList = new List<MailToSendDocument>();
             if(mailToSendDocumentList !=null){
			     mailToSendDocumentList.ForEach(l=>{
                    _mailToSendDocumentList.Add(MapMailToSendDocumentSingle(l));
			     });
            }
			 return _mailToSendDocumentList;
		}

        public static List<MailToSendDocument> MapMailToSendDocumentListWithSingleItemOnly(List<MailToSendDocument> mailToSendDocumentList){
			 List<MailToSendDocument> _mailToSendDocumentList = new List<MailToSendDocument>();
			 mailToSendDocumentList.ForEach(l=>{
                _mailToSendDocumentList.Add(MapMailToSendDocumentSingle(l,true));
			 });
			 return _mailToSendDocumentList;
		}

	


		public static void MapNLogDetailFromToSingle(NLogDetail nLogDetailFrom,NLogDetail nLogDetailTo){
							nLogDetailTo.IdNLogDetail = nLogDetailFrom.IdNLogDetail;
							nLogDetailTo.CallSite = nLogDetailFrom.CallSite;
							nLogDetailTo.Application = nLogDetailFrom.Application;
							nLogDetailTo.Logged = nLogDetailFrom.Logged;
							nLogDetailTo.Level = nLogDetailFrom.Level;
							nLogDetailTo.Message = nLogDetailFrom.Message;
							nLogDetailTo.UserName = nLogDetailFrom.UserName;
							nLogDetailTo.ServerName = nLogDetailFrom.ServerName;
							nLogDetailTo.Port = nLogDetailFrom.Port;
							nLogDetailTo.Url = nLogDetailFrom.Url;
							nLogDetailTo.Https = nLogDetailFrom.Https;
							nLogDetailTo.ServerAddress = nLogDetailFrom.ServerAddress;
							nLogDetailTo.RemoteAddress = nLogDetailFrom.RemoteAddress;
							nLogDetailTo.Logger = nLogDetailFrom.Logger;
							nLogDetailTo.Exception = nLogDetailFrom.Exception;
							nLogDetailTo.Stacktrace = nLogDetailFrom.Stacktrace;
							nLogDetailTo.Date = nLogDetailFrom.Date;
							nLogDetailTo.IsDeactivated = nLogDetailFrom.IsDeactivated;
			

		}



		public static NLogDetail MapNLogDetailSingle(NLogDetail nLogDetail,bool singleEntityOnly = false){
            if(nLogDetail !=null){
			NLogDetail _nLogDetail = new NLogDetail();
							_nLogDetail.IdNLogDetail = nLogDetail.IdNLogDetail;
							_nLogDetail.CallSite = nLogDetail.CallSite;
							_nLogDetail.Application = nLogDetail.Application;
							_nLogDetail.Logged = nLogDetail.Logged;
							_nLogDetail.Level = nLogDetail.Level;
							_nLogDetail.Message = nLogDetail.Message;
							_nLogDetail.UserName = nLogDetail.UserName;
							_nLogDetail.ServerName = nLogDetail.ServerName;
							_nLogDetail.Port = nLogDetail.Port;
							_nLogDetail.Url = nLogDetail.Url;
							_nLogDetail.Https = nLogDetail.Https;
							_nLogDetail.ServerAddress = nLogDetail.ServerAddress;
							_nLogDetail.RemoteAddress = nLogDetail.RemoteAddress;
							_nLogDetail.Logger = nLogDetail.Logger;
							_nLogDetail.Exception = nLogDetail.Exception;
							_nLogDetail.Stacktrace = nLogDetail.Stacktrace;
							_nLogDetail.Date = nLogDetail.Date;
							_nLogDetail.IsDeactivated = nLogDetail.IsDeactivated;
			            if(!singleEntityOnly){
			                }
			    return _nLogDetail;
            }else{
                return null;
            }
		}
		public static List<NLogDetail> MapNLogDetailList(List<NLogDetail> nLogDetailList){
			 List<NLogDetail> _nLogDetailList = new List<NLogDetail>();
             if(nLogDetailList !=null){
			     nLogDetailList.ForEach(l=>{
                    _nLogDetailList.Add(MapNLogDetailSingle(l));
			     });
            }
			 return _nLogDetailList;
		}

        public static List<NLogDetail> MapNLogDetailListWithSingleItemOnly(List<NLogDetail> nLogDetailList){
			 List<NLogDetail> _nLogDetailList = new List<NLogDetail>();
			 nLogDetailList.ForEach(l=>{
                _nLogDetailList.Add(MapNLogDetailSingle(l,true));
			 });
			 return _nLogDetailList;
		}

	


		public static void MapOrderFromToSingle(Order orderFrom,Order orderTo){
							orderTo.IdOrder = orderFrom.IdOrder;
							orderTo.OrderDate = orderFrom.OrderDate;
							orderTo.IdOrderConcept = orderFrom.IdOrderConcept;
							orderTo.IdUserAuthor = orderFrom.IdUserAuthor;
							orderTo.IsDeactivated = orderFrom.IsDeactivated;
							orderTo.OrderNumber = orderFrom.OrderNumber;
							orderTo.IdOrderSource = orderFrom.IdOrderSource;
							orderTo.IdOrderState = orderFrom.IdOrderState;
							orderTo.TotalAmount = orderFrom.TotalAmount;
			

		}



		public static Order MapOrderSingle(Order order,bool singleEntityOnly = false){
            if(order !=null){
			Order _order = new Order();
							_order.IdOrder = order.IdOrder;
							_order.OrderDate = order.OrderDate;
							_order.IdOrderConcept = order.IdOrderConcept;
							_order.IdUserAuthor = order.IdUserAuthor;
							_order.IsDeactivated = order.IsDeactivated;
							_order.OrderNumber = order.OrderNumber;
							_order.IdOrderSource = order.IdOrderSource;
							_order.IdOrderState = order.IdOrderState;
							_order.TotalAmount = order.TotalAmount;
			            if(!singleEntityOnly){
			    					    if(order.User !=null)
						    _order.User = MapUserSingle(order.User,true);
				    					    if(order.OrderConcept !=null)
						    _order.OrderConcept = MapOrderConceptSingle(order.OrderConcept,true);
				    					    if(order.OrderState !=null)
						    _order.OrderState = MapOrderStateSingle(order.OrderState,true);
				                }
			    return _order;
            }else{
                return null;
            }
		}
		public static List<Order> MapOrderList(List<Order> orderList){
			 List<Order> _orderList = new List<Order>();
             if(orderList !=null){
			     orderList.ForEach(l=>{
                    _orderList.Add(MapOrderSingle(l));
			     });
            }
			 return _orderList;
		}

        public static List<Order> MapOrderListWithSingleItemOnly(List<Order> orderList){
			 List<Order> _orderList = new List<Order>();
			 orderList.ForEach(l=>{
                _orderList.Add(MapOrderSingle(l,true));
			 });
			 return _orderList;
		}

	


		public static void MapOrderAddressFromToSingle(OrderAddress orderAddressFrom,OrderAddress orderAddressTo){
							orderAddressTo.IdOrderAddress = orderAddressFrom.IdOrderAddress;
							orderAddressTo.AddressLine1 = orderAddressFrom.AddressLine1;
							orderAddressTo.AddressLine2 = orderAddressFrom.AddressLine2;
							orderAddressTo.AddressLine3 = orderAddressFrom.AddressLine3;
							orderAddressTo.AddressLine4 = orderAddressFrom.AddressLine4;
							orderAddressTo.Postcode = orderAddressFrom.Postcode;
							orderAddressTo.IsDeactivated = orderAddressFrom.IsDeactivated;
							orderAddressTo.Lat = orderAddressFrom.Lat;
							orderAddressTo.Lng = orderAddressFrom.Lng;
							orderAddressTo.City = orderAddressFrom.City;
			

		}



		public static OrderAddress MapOrderAddressSingle(OrderAddress orderAddress,bool singleEntityOnly = false){
            if(orderAddress !=null){
			OrderAddress _orderAddress = new OrderAddress();
							_orderAddress.IdOrderAddress = orderAddress.IdOrderAddress;
							_orderAddress.AddressLine1 = orderAddress.AddressLine1;
							_orderAddress.AddressLine2 = orderAddress.AddressLine2;
							_orderAddress.AddressLine3 = orderAddress.AddressLine3;
							_orderAddress.AddressLine4 = orderAddress.AddressLine4;
							_orderAddress.Postcode = orderAddress.Postcode;
							_orderAddress.IsDeactivated = orderAddress.IsDeactivated;
							_orderAddress.Lat = orderAddress.Lat;
							_orderAddress.Lng = orderAddress.Lng;
							_orderAddress.City = orderAddress.City;
			            if(!singleEntityOnly){
			                }
			    return _orderAddress;
            }else{
                return null;
            }
		}
		public static List<OrderAddress> MapOrderAddressList(List<OrderAddress> orderAddressList){
			 List<OrderAddress> _orderAddressList = new List<OrderAddress>();
             if(orderAddressList !=null){
			     orderAddressList.ForEach(l=>{
                    _orderAddressList.Add(MapOrderAddressSingle(l));
			     });
            }
			 return _orderAddressList;
		}

        public static List<OrderAddress> MapOrderAddressListWithSingleItemOnly(List<OrderAddress> orderAddressList){
			 List<OrderAddress> _orderAddressList = new List<OrderAddress>();
			 orderAddressList.ForEach(l=>{
                _orderAddressList.Add(MapOrderAddressSingle(l,true));
			 });
			 return _orderAddressList;
		}

	


		public static void MapOrderCompanyFromToSingle(OrderCompany orderCompanyFrom,OrderCompany orderCompanyTo){
							orderCompanyTo.IdOrderCompany = orderCompanyFrom.IdOrderCompany;
							orderCompanyTo.Name = orderCompanyFrom.Name;
							orderCompanyTo.IsDeactivated = orderCompanyFrom.IsDeactivated;
							orderCompanyTo.Description = orderCompanyFrom.Description;
			

		}



		public static OrderCompany MapOrderCompanySingle(OrderCompany orderCompany,bool singleEntityOnly = false){
            if(orderCompany !=null){
			OrderCompany _orderCompany = new OrderCompany();
							_orderCompany.IdOrderCompany = orderCompany.IdOrderCompany;
							_orderCompany.Name = orderCompany.Name;
							_orderCompany.IsDeactivated = orderCompany.IsDeactivated;
							_orderCompany.Description = orderCompany.Description;
			            if(!singleEntityOnly){
			                }
			    return _orderCompany;
            }else{
                return null;
            }
		}
		public static List<OrderCompany> MapOrderCompanyList(List<OrderCompany> orderCompanyList){
			 List<OrderCompany> _orderCompanyList = new List<OrderCompany>();
             if(orderCompanyList !=null){
			     orderCompanyList.ForEach(l=>{
                    _orderCompanyList.Add(MapOrderCompanySingle(l));
			     });
            }
			 return _orderCompanyList;
		}

        public static List<OrderCompany> MapOrderCompanyListWithSingleItemOnly(List<OrderCompany> orderCompanyList){
			 List<OrderCompany> _orderCompanyList = new List<OrderCompany>();
			 orderCompanyList.ForEach(l=>{
                _orderCompanyList.Add(MapOrderCompanySingle(l,true));
			 });
			 return _orderCompanyList;
		}

	


		public static void MapOrderConceptFromToSingle(OrderConcept orderConceptFrom,OrderConcept orderConceptTo){
							orderConceptTo.IdOrderConcept = orderConceptFrom.IdOrderConcept;
							orderConceptTo.IdOrderCompany = orderConceptFrom.IdOrderCompany;
							orderConceptTo.IdOrderPerson = orderConceptFrom.IdOrderPerson;
							orderConceptTo.IsDeactivated = orderConceptFrom.IsDeactivated;
			

		}



		public static OrderConcept MapOrderConceptSingle(OrderConcept orderConcept,bool singleEntityOnly = false){
            if(orderConcept !=null){
			OrderConcept _orderConcept = new OrderConcept();
							_orderConcept.IdOrderConcept = orderConcept.IdOrderConcept;
							_orderConcept.IdOrderCompany = orderConcept.IdOrderCompany;
							_orderConcept.IdOrderPerson = orderConcept.IdOrderPerson;
							_orderConcept.IsDeactivated = orderConcept.IsDeactivated;
			            if(!singleEntityOnly){
			    					    if(orderConcept.OrderCompany !=null)
						    _orderConcept.OrderCompany = MapOrderCompanySingle(orderConcept.OrderCompany,true);
				    					    if(orderConcept.OrderPerson !=null)
						    _orderConcept.OrderPerson = MapOrderPersonSingle(orderConcept.OrderPerson,true);
				                }
			    return _orderConcept;
            }else{
                return null;
            }
		}
		public static List<OrderConcept> MapOrderConceptList(List<OrderConcept> orderConceptList){
			 List<OrderConcept> _orderConceptList = new List<OrderConcept>();
             if(orderConceptList !=null){
			     orderConceptList.ForEach(l=>{
                    _orderConceptList.Add(MapOrderConceptSingle(l));
			     });
            }
			 return _orderConceptList;
		}

        public static List<OrderConcept> MapOrderConceptListWithSingleItemOnly(List<OrderConcept> orderConceptList){
			 List<OrderConcept> _orderConceptList = new List<OrderConcept>();
			 orderConceptList.ForEach(l=>{
                _orderConceptList.Add(MapOrderConceptSingle(l,true));
			 });
			 return _orderConceptList;
		}

	


		public static void MapOrderConcept_ContactTypeFromToSingle(OrderConcept_ContactType orderConcept_ContactTypeFrom,OrderConcept_ContactType orderConcept_ContactTypeTo){
							orderConcept_ContactTypeTo.IdOrderConcept_ContactType = orderConcept_ContactTypeFrom.IdOrderConcept_ContactType;
							orderConcept_ContactTypeTo.IdOrderConcept = orderConcept_ContactTypeFrom.IdOrderConcept;
							orderConcept_ContactTypeTo.IdContactType = orderConcept_ContactTypeFrom.IdContactType;
							orderConcept_ContactTypeTo.IsDeactivated = orderConcept_ContactTypeFrom.IsDeactivated;
							orderConcept_ContactTypeTo.Description = orderConcept_ContactTypeFrom.Description;
			

		}



		public static OrderConcept_ContactType MapOrderConcept_ContactTypeSingle(OrderConcept_ContactType orderConcept_ContactType,bool singleEntityOnly = false){
            if(orderConcept_ContactType !=null){
			OrderConcept_ContactType _orderConcept_ContactType = new OrderConcept_ContactType();
							_orderConcept_ContactType.IdOrderConcept_ContactType = orderConcept_ContactType.IdOrderConcept_ContactType;
							_orderConcept_ContactType.IdOrderConcept = orderConcept_ContactType.IdOrderConcept;
							_orderConcept_ContactType.IdContactType = orderConcept_ContactType.IdContactType;
							_orderConcept_ContactType.IsDeactivated = orderConcept_ContactType.IsDeactivated;
							_orderConcept_ContactType.Description = orderConcept_ContactType.Description;
			            if(!singleEntityOnly){
			    					    if(orderConcept_ContactType.ContactType !=null)
						    _orderConcept_ContactType.ContactType = MapContactTypeSingle(orderConcept_ContactType.ContactType,true);
				    					    if(orderConcept_ContactType.OrderConcept !=null)
						    _orderConcept_ContactType.OrderConcept = MapOrderConceptSingle(orderConcept_ContactType.OrderConcept,true);
				                }
			    return _orderConcept_ContactType;
            }else{
                return null;
            }
		}
		public static List<OrderConcept_ContactType> MapOrderConcept_ContactTypeList(List<OrderConcept_ContactType> orderConcept_ContactTypeList){
			 List<OrderConcept_ContactType> _orderConcept_ContactTypeList = new List<OrderConcept_ContactType>();
             if(orderConcept_ContactTypeList !=null){
			     orderConcept_ContactTypeList.ForEach(l=>{
                    _orderConcept_ContactTypeList.Add(MapOrderConcept_ContactTypeSingle(l));
			     });
            }
			 return _orderConcept_ContactTypeList;
		}

        public static List<OrderConcept_ContactType> MapOrderConcept_ContactTypeListWithSingleItemOnly(List<OrderConcept_ContactType> orderConcept_ContactTypeList){
			 List<OrderConcept_ContactType> _orderConcept_ContactTypeList = new List<OrderConcept_ContactType>();
			 orderConcept_ContactTypeList.ForEach(l=>{
                _orderConcept_ContactTypeList.Add(MapOrderConcept_ContactTypeSingle(l,true));
			 });
			 return _orderConcept_ContactTypeList;
		}

	


		public static void MapOrderConcept_OrderAddressFromToSingle(OrderConcept_OrderAddress orderConcept_OrderAddressFrom,OrderConcept_OrderAddress orderConcept_OrderAddressTo){
							orderConcept_OrderAddressTo.IdOrderConcept_OrderAddress = orderConcept_OrderAddressFrom.IdOrderConcept_OrderAddress;
							orderConcept_OrderAddressTo.IdOrderConcept = orderConcept_OrderAddressFrom.IdOrderConcept;
							orderConcept_OrderAddressTo.IdOrderAddress = orderConcept_OrderAddressFrom.IdOrderAddress;
							orderConcept_OrderAddressTo.Detail = orderConcept_OrderAddressFrom.Detail;
							orderConcept_OrderAddressTo.IsDeactivated = orderConcept_OrderAddressFrom.IsDeactivated;
			

		}



		public static OrderConcept_OrderAddress MapOrderConcept_OrderAddressSingle(OrderConcept_OrderAddress orderConcept_OrderAddress,bool singleEntityOnly = false){
            if(orderConcept_OrderAddress !=null){
			OrderConcept_OrderAddress _orderConcept_OrderAddress = new OrderConcept_OrderAddress();
							_orderConcept_OrderAddress.IdOrderConcept_OrderAddress = orderConcept_OrderAddress.IdOrderConcept_OrderAddress;
							_orderConcept_OrderAddress.IdOrderConcept = orderConcept_OrderAddress.IdOrderConcept;
							_orderConcept_OrderAddress.IdOrderAddress = orderConcept_OrderAddress.IdOrderAddress;
							_orderConcept_OrderAddress.Detail = orderConcept_OrderAddress.Detail;
							_orderConcept_OrderAddress.IsDeactivated = orderConcept_OrderAddress.IsDeactivated;
			            if(!singleEntityOnly){
			    					    if(orderConcept_OrderAddress.OrderAddress !=null)
						    _orderConcept_OrderAddress.OrderAddress = MapOrderAddressSingle(orderConcept_OrderAddress.OrderAddress,true);
				    					    if(orderConcept_OrderAddress.OrderConcept !=null)
						    _orderConcept_OrderAddress.OrderConcept = MapOrderConceptSingle(orderConcept_OrderAddress.OrderConcept,true);
				                }
			    return _orderConcept_OrderAddress;
            }else{
                return null;
            }
		}
		public static List<OrderConcept_OrderAddress> MapOrderConcept_OrderAddressList(List<OrderConcept_OrderAddress> orderConcept_OrderAddressList){
			 List<OrderConcept_OrderAddress> _orderConcept_OrderAddressList = new List<OrderConcept_OrderAddress>();
             if(orderConcept_OrderAddressList !=null){
			     orderConcept_OrderAddressList.ForEach(l=>{
                    _orderConcept_OrderAddressList.Add(MapOrderConcept_OrderAddressSingle(l));
			     });
            }
			 return _orderConcept_OrderAddressList;
		}

        public static List<OrderConcept_OrderAddress> MapOrderConcept_OrderAddressListWithSingleItemOnly(List<OrderConcept_OrderAddress> orderConcept_OrderAddressList){
			 List<OrderConcept_OrderAddress> _orderConcept_OrderAddressList = new List<OrderConcept_OrderAddress>();
			 orderConcept_OrderAddressList.ForEach(l=>{
                _orderConcept_OrderAddressList.Add(MapOrderConcept_OrderAddressSingle(l,true));
			 });
			 return _orderConcept_OrderAddressList;
		}

	


		public static void MapOrderDetailFromToSingle(OrderDetail orderDetailFrom,OrderDetail orderDetailTo){
							orderDetailTo.IdOrderDetail = orderDetailFrom.IdOrderDetail;
							orderDetailTo.IdOrder = orderDetailFrom.IdOrder;
							orderDetailTo.IdProduct = orderDetailFrom.IdProduct;
							orderDetailTo.Quantity = orderDetailFrom.Quantity;
							orderDetailTo.Rate = orderDetailFrom.Rate;
							orderDetailTo.IsDeactivated = orderDetailFrom.IsDeactivated;
			

		}



		public static OrderDetail MapOrderDetailSingle(OrderDetail orderDetail,bool singleEntityOnly = false){
            if(orderDetail !=null){
			OrderDetail _orderDetail = new OrderDetail();
							_orderDetail.IdOrderDetail = orderDetail.IdOrderDetail;
							_orderDetail.IdOrder = orderDetail.IdOrder;
							_orderDetail.IdProduct = orderDetail.IdProduct;
							_orderDetail.Quantity = orderDetail.Quantity;
							_orderDetail.Rate = orderDetail.Rate;
							_orderDetail.IsDeactivated = orderDetail.IsDeactivated;
			            if(!singleEntityOnly){
			    					    if(orderDetail.Product !=null)
						    _orderDetail.Product = MapProductSingle(orderDetail.Product,true);
				    					    if(orderDetail.Order !=null)
						    _orderDetail.Order = MapOrderSingle(orderDetail.Order,true);
				                }
			    return _orderDetail;
            }else{
                return null;
            }
		}
		public static List<OrderDetail> MapOrderDetailList(List<OrderDetail> orderDetailList){
			 List<OrderDetail> _orderDetailList = new List<OrderDetail>();
             if(orderDetailList !=null){
			     orderDetailList.ForEach(l=>{
                    _orderDetailList.Add(MapOrderDetailSingle(l));
			     });
            }
			 return _orderDetailList;
		}

        public static List<OrderDetail> MapOrderDetailListWithSingleItemOnly(List<OrderDetail> orderDetailList){
			 List<OrderDetail> _orderDetailList = new List<OrderDetail>();
			 orderDetailList.ForEach(l=>{
                _orderDetailList.Add(MapOrderDetailSingle(l,true));
			 });
			 return _orderDetailList;
		}

	


		public static void MapOrderPersonFromToSingle(OrderPerson orderPersonFrom,OrderPerson orderPersonTo){
							orderPersonTo.IdOrderPerson = orderPersonFrom.IdOrderPerson;
							orderPersonTo.IsDeactivated = orderPersonFrom.IsDeactivated;
							orderPersonTo.Firstname = orderPersonFrom.Firstname;
							orderPersonTo.Lastname = orderPersonFrom.Lastname;
							orderPersonTo.Othername = orderPersonFrom.Othername;
							orderPersonTo.IdProfilePic = orderPersonFrom.IdProfilePic;
							orderPersonTo.Headline = orderPersonFrom.Headline;
							orderPersonTo.ShortBiography = orderPersonFrom.ShortBiography;
							orderPersonTo.Dob = orderPersonFrom.Dob;
							orderPersonTo.IdNationality = orderPersonFrom.IdNationality;
							orderPersonTo.HasDrivingLicense = orderPersonFrom.HasDrivingLicense;
							orderPersonTo.IdCoverPic = orderPersonFrom.IdCoverPic;
							orderPersonTo.IdHostedDomain = orderPersonFrom.IdHostedDomain;
							orderPersonTo.IdTitle = orderPersonFrom.IdTitle;
							orderPersonTo.NationalIdentificationNumber = orderPersonFrom.NationalIdentificationNumber;
			

		}



		public static OrderPerson MapOrderPersonSingle(OrderPerson orderPerson,bool singleEntityOnly = false){
            if(orderPerson !=null){
			OrderPerson _orderPerson = new OrderPerson();
							_orderPerson.IdOrderPerson = orderPerson.IdOrderPerson;
							_orderPerson.IsDeactivated = orderPerson.IsDeactivated;
							_orderPerson.Firstname = orderPerson.Firstname;
							_orderPerson.Lastname = orderPerson.Lastname;
							_orderPerson.Othername = orderPerson.Othername;
							_orderPerson.IdProfilePic = orderPerson.IdProfilePic;
							_orderPerson.Headline = orderPerson.Headline;
							_orderPerson.ShortBiography = orderPerson.ShortBiography;
							_orderPerson.Dob = orderPerson.Dob;
							_orderPerson.IdNationality = orderPerson.IdNationality;
							_orderPerson.HasDrivingLicense = orderPerson.HasDrivingLicense;
							_orderPerson.IdCoverPic = orderPerson.IdCoverPic;
							_orderPerson.IdHostedDomain = orderPerson.IdHostedDomain;
							_orderPerson.IdTitle = orderPerson.IdTitle;
							_orderPerson.NationalIdentificationNumber = orderPerson.NationalIdentificationNumber;
			            if(!singleEntityOnly){
			    					    if(orderPerson.Title !=null)
						    _orderPerson.Title = MapTitleSingle(orderPerson.Title,true);
				                }
			    return _orderPerson;
            }else{
                return null;
            }
		}
		public static List<OrderPerson> MapOrderPersonList(List<OrderPerson> orderPersonList){
			 List<OrderPerson> _orderPersonList = new List<OrderPerson>();
             if(orderPersonList !=null){
			     orderPersonList.ForEach(l=>{
                    _orderPersonList.Add(MapOrderPersonSingle(l));
			     });
            }
			 return _orderPersonList;
		}

        public static List<OrderPerson> MapOrderPersonListWithSingleItemOnly(List<OrderPerson> orderPersonList){
			 List<OrderPerson> _orderPersonList = new List<OrderPerson>();
			 orderPersonList.ForEach(l=>{
                _orderPersonList.Add(MapOrderPersonSingle(l,true));
			 });
			 return _orderPersonList;
		}

	


		public static void MapOrderStateFromToSingle(OrderState orderStateFrom,OrderState orderStateTo){
							orderStateTo.IdOrderState = orderStateFrom.IdOrderState;
							orderStateTo.IsDeactivated = orderStateFrom.IsDeactivated;
							orderStateTo.Description = orderStateFrom.Description;
			

		}



		public static OrderState MapOrderStateSingle(OrderState orderState,bool singleEntityOnly = false){
            if(orderState !=null){
			OrderState _orderState = new OrderState();
							_orderState.IdOrderState = orderState.IdOrderState;
							_orderState.IsDeactivated = orderState.IsDeactivated;
							_orderState.Description = orderState.Description;
			            if(!singleEntityOnly){
			                }
			    return _orderState;
            }else{
                return null;
            }
		}
		public static List<OrderState> MapOrderStateList(List<OrderState> orderStateList){
			 List<OrderState> _orderStateList = new List<OrderState>();
             if(orderStateList !=null){
			     orderStateList.ForEach(l=>{
                    _orderStateList.Add(MapOrderStateSingle(l));
			     });
            }
			 return _orderStateList;
		}

        public static List<OrderState> MapOrderStateListWithSingleItemOnly(List<OrderState> orderStateList){
			 List<OrderState> _orderStateList = new List<OrderState>();
			 orderStateList.ForEach(l=>{
                _orderStateList.Add(MapOrderStateSingle(l,true));
			 });
			 return _orderStateList;
		}

	


		public static void MapParameterFromToSingle(Parameter parameterFrom,Parameter parameterTo){
							parameterTo.IdParameter = parameterFrom.IdParameter;
							parameterTo.ParamaterValue = parameterFrom.ParamaterValue;
							parameterTo.IsDeactivated = parameterFrom.IsDeactivated;
							parameterTo.Code = parameterFrom.Code;
			

		}



		public static Parameter MapParameterSingle(Parameter parameter,bool singleEntityOnly = false){
            if(parameter !=null){
			Parameter _parameter = new Parameter();
							_parameter.IdParameter = parameter.IdParameter;
							_parameter.ParamaterValue = parameter.ParamaterValue;
							_parameter.IsDeactivated = parameter.IsDeactivated;
							_parameter.Code = parameter.Code;
			            if(!singleEntityOnly){
			                }
			    return _parameter;
            }else{
                return null;
            }
		}
		public static List<Parameter> MapParameterList(List<Parameter> parameterList){
			 List<Parameter> _parameterList = new List<Parameter>();
             if(parameterList !=null){
			     parameterList.ForEach(l=>{
                    _parameterList.Add(MapParameterSingle(l));
			     });
            }
			 return _parameterList;
		}

        public static List<Parameter> MapParameterListWithSingleItemOnly(List<Parameter> parameterList){
			 List<Parameter> _parameterList = new List<Parameter>();
			 parameterList.ForEach(l=>{
                _parameterList.Add(MapParameterSingle(l,true));
			 });
			 return _parameterList;
		}

	


		public static void MapPaymentFromToSingle(Payment paymentFrom,Payment paymentTo){
							paymentTo.IdPayment = paymentFrom.IdPayment;
							paymentTo.IsDeactivated = paymentFrom.IsDeactivated;
							paymentTo.PaymentDate = paymentFrom.PaymentDate;
							paymentTo.IdUserAuthor = paymentFrom.IdUserAuthor;
							paymentTo.IdTransaction = paymentFrom.IdTransaction;
			

		}



		public static Payment MapPaymentSingle(Payment payment,bool singleEntityOnly = false){
            if(payment !=null){
			Payment _payment = new Payment();
							_payment.IdPayment = payment.IdPayment;
							_payment.IsDeactivated = payment.IsDeactivated;
							_payment.PaymentDate = payment.PaymentDate;
							_payment.IdUserAuthor = payment.IdUserAuthor;
							_payment.IdTransaction = payment.IdTransaction;
			            if(!singleEntityOnly){
			    					    if(payment.User !=null)
						    _payment.User = MapUserSingle(payment.User,true);
				    					    if(payment.Transaction !=null)
						    _payment.Transaction = MapTransactionSingle(payment.Transaction,true);
				                }
			    return _payment;
            }else{
                return null;
            }
		}
		public static List<Payment> MapPaymentList(List<Payment> paymentList){
			 List<Payment> _paymentList = new List<Payment>();
             if(paymentList !=null){
			     paymentList.ForEach(l=>{
                    _paymentList.Add(MapPaymentSingle(l));
			     });
            }
			 return _paymentList;
		}

        public static List<Payment> MapPaymentListWithSingleItemOnly(List<Payment> paymentList){
			 List<Payment> _paymentList = new List<Payment>();
			 paymentList.ForEach(l=>{
                _paymentList.Add(MapPaymentSingle(l,true));
			 });
			 return _paymentList;
		}

	


		public static void MapPaymentDetailFromToSingle(PaymentDetail paymentDetailFrom,PaymentDetail paymentDetailTo){
							paymentDetailTo.IdPaymentDetail = paymentDetailFrom.IdPaymentDetail;
							paymentDetailTo.IsDeactivated = paymentDetailFrom.IsDeactivated;
							paymentDetailTo.PaymentAmount = paymentDetailFrom.PaymentAmount;
							paymentDetailTo.IdPaymentMethod = paymentDetailFrom.IdPaymentMethod;
							paymentDetailTo.IdPayment = paymentDetailFrom.IdPayment;
							paymentDetailTo.ChequeNo = paymentDetailFrom.ChequeNo;
							paymentDetailTo.Description = paymentDetailFrom.Description;
							paymentDetailTo.BankAccountNo = paymentDetailFrom.BankAccountNo;
							paymentDetailTo.IdBank = paymentDetailFrom.IdBank;
			

		}



		public static PaymentDetail MapPaymentDetailSingle(PaymentDetail paymentDetail,bool singleEntityOnly = false){
            if(paymentDetail !=null){
			PaymentDetail _paymentDetail = new PaymentDetail();
							_paymentDetail.IdPaymentDetail = paymentDetail.IdPaymentDetail;
							_paymentDetail.IsDeactivated = paymentDetail.IsDeactivated;
							_paymentDetail.PaymentAmount = paymentDetail.PaymentAmount;
							_paymentDetail.IdPaymentMethod = paymentDetail.IdPaymentMethod;
							_paymentDetail.IdPayment = paymentDetail.IdPayment;
							_paymentDetail.ChequeNo = paymentDetail.ChequeNo;
							_paymentDetail.Description = paymentDetail.Description;
							_paymentDetail.BankAccountNo = paymentDetail.BankAccountNo;
							_paymentDetail.IdBank = paymentDetail.IdBank;
			            if(!singleEntityOnly){
			    					    if(paymentDetail.Bank !=null)
						    _paymentDetail.Bank = MapBankSingle(paymentDetail.Bank,true);
				    					    if(paymentDetail.PaymentMethod !=null)
						    _paymentDetail.PaymentMethod = MapPaymentMethodSingle(paymentDetail.PaymentMethod,true);
				    					    if(paymentDetail.Payment !=null)
						    _paymentDetail.Payment = MapPaymentSingle(paymentDetail.Payment,true);
				                }
			    return _paymentDetail;
            }else{
                return null;
            }
		}
		public static List<PaymentDetail> MapPaymentDetailList(List<PaymentDetail> paymentDetailList){
			 List<PaymentDetail> _paymentDetailList = new List<PaymentDetail>();
             if(paymentDetailList !=null){
			     paymentDetailList.ForEach(l=>{
                    _paymentDetailList.Add(MapPaymentDetailSingle(l));
			     });
            }
			 return _paymentDetailList;
		}

        public static List<PaymentDetail> MapPaymentDetailListWithSingleItemOnly(List<PaymentDetail> paymentDetailList){
			 List<PaymentDetail> _paymentDetailList = new List<PaymentDetail>();
			 paymentDetailList.ForEach(l=>{
                _paymentDetailList.Add(MapPaymentDetailSingle(l,true));
			 });
			 return _paymentDetailList;
		}

	


		public static void MapPaymentDueStateFromToSingle(PaymentDueState paymentDueStateFrom,PaymentDueState paymentDueStateTo){
							paymentDueStateTo.IdPaymentDueState = paymentDueStateFrom.IdPaymentDueState;
							paymentDueStateTo.IsDeactivated = paymentDueStateFrom.IsDeactivated;
							paymentDueStateTo.Description = paymentDueStateFrom.Description;
			

		}



		public static PaymentDueState MapPaymentDueStateSingle(PaymentDueState paymentDueState,bool singleEntityOnly = false){
            if(paymentDueState !=null){
			PaymentDueState _paymentDueState = new PaymentDueState();
							_paymentDueState.IdPaymentDueState = paymentDueState.IdPaymentDueState;
							_paymentDueState.IsDeactivated = paymentDueState.IsDeactivated;
							_paymentDueState.Description = paymentDueState.Description;
			            if(!singleEntityOnly){
			                }
			    return _paymentDueState;
            }else{
                return null;
            }
		}
		public static List<PaymentDueState> MapPaymentDueStateList(List<PaymentDueState> paymentDueStateList){
			 List<PaymentDueState> _paymentDueStateList = new List<PaymentDueState>();
             if(paymentDueStateList !=null){
			     paymentDueStateList.ForEach(l=>{
                    _paymentDueStateList.Add(MapPaymentDueStateSingle(l));
			     });
            }
			 return _paymentDueStateList;
		}

        public static List<PaymentDueState> MapPaymentDueStateListWithSingleItemOnly(List<PaymentDueState> paymentDueStateList){
			 List<PaymentDueState> _paymentDueStateList = new List<PaymentDueState>();
			 paymentDueStateList.ForEach(l=>{
                _paymentDueStateList.Add(MapPaymentDueStateSingle(l,true));
			 });
			 return _paymentDueStateList;
		}

	


		public static void MapPaymentMethodFromToSingle(PaymentMethod paymentMethodFrom,PaymentMethod paymentMethodTo){
							paymentMethodTo.IdPaymentMethod = paymentMethodFrom.IdPaymentMethod;
							paymentMethodTo.Description = paymentMethodFrom.Description;
							paymentMethodTo.IsDeactivated = paymentMethodFrom.IsDeactivated;
			

		}



		public static PaymentMethod MapPaymentMethodSingle(PaymentMethod paymentMethod,bool singleEntityOnly = false){
            if(paymentMethod !=null){
			PaymentMethod _paymentMethod = new PaymentMethod();
							_paymentMethod.IdPaymentMethod = paymentMethod.IdPaymentMethod;
							_paymentMethod.Description = paymentMethod.Description;
							_paymentMethod.IsDeactivated = paymentMethod.IsDeactivated;
			            if(!singleEntityOnly){
			                }
			    return _paymentMethod;
            }else{
                return null;
            }
		}
		public static List<PaymentMethod> MapPaymentMethodList(List<PaymentMethod> paymentMethodList){
			 List<PaymentMethod> _paymentMethodList = new List<PaymentMethod>();
             if(paymentMethodList !=null){
			     paymentMethodList.ForEach(l=>{
                    _paymentMethodList.Add(MapPaymentMethodSingle(l));
			     });
            }
			 return _paymentMethodList;
		}

        public static List<PaymentMethod> MapPaymentMethodListWithSingleItemOnly(List<PaymentMethod> paymentMethodList){
			 List<PaymentMethod> _paymentMethodList = new List<PaymentMethod>();
			 paymentMethodList.ForEach(l=>{
                _paymentMethodList.Add(MapPaymentMethodSingle(l,true));
			 });
			 return _paymentMethodList;
		}

	


		public static void MapPermissionFromToSingle(Permission permissionFrom,Permission permissionTo){
							permissionTo.IdPermission = permissionFrom.IdPermission;
							permissionTo.PermissionName = permissionFrom.PermissionName;
							permissionTo.PermissionCode = permissionFrom.PermissionCode;
							permissionTo.IsDeactivated = permissionFrom.IsDeactivated;
			

		}



		public static Permission MapPermissionSingle(Permission permission,bool singleEntityOnly = false){
            if(permission !=null){
			Permission _permission = new Permission();
							_permission.IdPermission = permission.IdPermission;
							_permission.PermissionName = permission.PermissionName;
							_permission.PermissionCode = permission.PermissionCode;
							_permission.IsDeactivated = permission.IsDeactivated;
			            if(!singleEntityOnly){
			                }
			    return _permission;
            }else{
                return null;
            }
		}
		public static List<Permission> MapPermissionList(List<Permission> permissionList){
			 List<Permission> _permissionList = new List<Permission>();
             if(permissionList !=null){
			     permissionList.ForEach(l=>{
                    _permissionList.Add(MapPermissionSingle(l));
			     });
            }
			 return _permissionList;
		}

        public static List<Permission> MapPermissionListWithSingleItemOnly(List<Permission> permissionList){
			 List<Permission> _permissionList = new List<Permission>();
			 permissionList.ForEach(l=>{
                _permissionList.Add(MapPermissionSingle(l,true));
			 });
			 return _permissionList;
		}

	


		public static void MapPersonFromToSingle(Person personFrom,Person personTo){
							personTo.IdPerson = personFrom.IdPerson;
							personTo.IsDeactivated = personFrom.IsDeactivated;
							personTo.Firstname = personFrom.Firstname;
							personTo.Lastname = personFrom.Lastname;
							personTo.Dob = personFrom.Dob;
							personTo.IdNationality = personFrom.IdNationality;
							personTo.IdTitle = personFrom.IdTitle;
							personTo.NationalIdentificationNumber = personFrom.NationalIdentificationNumber;
			

		}



		public static Person MapPersonSingle(Person person,bool singleEntityOnly = false){
            if(person !=null){
			Person _person = new Person();
							_person.IdPerson = person.IdPerson;
							_person.IsDeactivated = person.IsDeactivated;
							_person.Firstname = person.Firstname;
							_person.Lastname = person.Lastname;
							_person.Dob = person.Dob;
							_person.IdNationality = person.IdNationality;
							_person.IdTitle = person.IdTitle;
							_person.NationalIdentificationNumber = person.NationalIdentificationNumber;
			            if(!singleEntityOnly){
			    					    if(person.Title !=null)
						    _person.Title = MapTitleSingle(person.Title,true);
				                }
			    return _person;
            }else{
                return null;
            }
		}
		public static List<Person> MapPersonList(List<Person> personList){
			 List<Person> _personList = new List<Person>();
             if(personList !=null){
			     personList.ForEach(l=>{
                    _personList.Add(MapPersonSingle(l));
			     });
            }
			 return _personList;
		}

        public static List<Person> MapPersonListWithSingleItemOnly(List<Person> personList){
			 List<Person> _personList = new List<Person>();
			 personList.ForEach(l=>{
                _personList.Add(MapPersonSingle(l,true));
			 });
			 return _personList;
		}

	


		public static void MapPerson_AddressFromToSingle(Person_Address person_AddressFrom,Person_Address person_AddressTo){
							person_AddressTo.IdPerson_Address = person_AddressFrom.IdPerson_Address;
							person_AddressTo.IdPerson = person_AddressFrom.IdPerson;
							person_AddressTo.IdAddress = person_AddressFrom.IdAddress;
							person_AddressTo.IsDeactivated = person_AddressFrom.IsDeactivated;
			

		}



		public static Person_Address MapPerson_AddressSingle(Person_Address person_Address,bool singleEntityOnly = false){
            if(person_Address !=null){
			Person_Address _person_Address = new Person_Address();
							_person_Address.IdPerson_Address = person_Address.IdPerson_Address;
							_person_Address.IdPerson = person_Address.IdPerson;
							_person_Address.IdAddress = person_Address.IdAddress;
							_person_Address.IsDeactivated = person_Address.IsDeactivated;
			            if(!singleEntityOnly){
			    					    if(person_Address.Address !=null)
						    _person_Address.Address = MapAddressSingle(person_Address.Address,true);
				    					    if(person_Address.Person !=null)
						    _person_Address.Person = MapPersonSingle(person_Address.Person,true);
				                }
			    return _person_Address;
            }else{
                return null;
            }
		}
		public static List<Person_Address> MapPerson_AddressList(List<Person_Address> person_AddressList){
			 List<Person_Address> _person_AddressList = new List<Person_Address>();
             if(person_AddressList !=null){
			     person_AddressList.ForEach(l=>{
                    _person_AddressList.Add(MapPerson_AddressSingle(l));
			     });
            }
			 return _person_AddressList;
		}

        public static List<Person_Address> MapPerson_AddressListWithSingleItemOnly(List<Person_Address> person_AddressList){
			 List<Person_Address> _person_AddressList = new List<Person_Address>();
			 person_AddressList.ForEach(l=>{
                _person_AddressList.Add(MapPerson_AddressSingle(l,true));
			 });
			 return _person_AddressList;
		}

	


		public static void MapPerson_ContactTypeFromToSingle(Person_ContactType person_ContactTypeFrom,Person_ContactType person_ContactTypeTo){
							person_ContactTypeTo.IdPerson_ContactType = person_ContactTypeFrom.IdPerson_ContactType;
							person_ContactTypeTo.IdPerson = person_ContactTypeFrom.IdPerson;
							person_ContactTypeTo.IdContactType = person_ContactTypeFrom.IdContactType;
							person_ContactTypeTo.IsDeactivated = person_ContactTypeFrom.IsDeactivated;
							person_ContactTypeTo.Description = person_ContactTypeFrom.Description;
							person_ContactTypeTo.IsPrimary = person_ContactTypeFrom.IsPrimary;
			

		}



		public static Person_ContactType MapPerson_ContactTypeSingle(Person_ContactType person_ContactType,bool singleEntityOnly = false){
            if(person_ContactType !=null){
			Person_ContactType _person_ContactType = new Person_ContactType();
							_person_ContactType.IdPerson_ContactType = person_ContactType.IdPerson_ContactType;
							_person_ContactType.IdPerson = person_ContactType.IdPerson;
							_person_ContactType.IdContactType = person_ContactType.IdContactType;
							_person_ContactType.IsDeactivated = person_ContactType.IsDeactivated;
							_person_ContactType.Description = person_ContactType.Description;
							_person_ContactType.IsPrimary = person_ContactType.IsPrimary;
			            if(!singleEntityOnly){
			    					    if(person_ContactType.ContactType !=null)
						    _person_ContactType.ContactType = MapContactTypeSingle(person_ContactType.ContactType,true);
				    					    if(person_ContactType.Person !=null)
						    _person_ContactType.Person = MapPersonSingle(person_ContactType.Person,true);
				                }
			    return _person_ContactType;
            }else{
                return null;
            }
		}
		public static List<Person_ContactType> MapPerson_ContactTypeList(List<Person_ContactType> person_ContactTypeList){
			 List<Person_ContactType> _person_ContactTypeList = new List<Person_ContactType>();
             if(person_ContactTypeList !=null){
			     person_ContactTypeList.ForEach(l=>{
                    _person_ContactTypeList.Add(MapPerson_ContactTypeSingle(l));
			     });
            }
			 return _person_ContactTypeList;
		}

        public static List<Person_ContactType> MapPerson_ContactTypeListWithSingleItemOnly(List<Person_ContactType> person_ContactTypeList){
			 List<Person_ContactType> _person_ContactTypeList = new List<Person_ContactType>();
			 person_ContactTypeList.ForEach(l=>{
                _person_ContactTypeList.Add(MapPerson_ContactTypeSingle(l,true));
			 });
			 return _person_ContactTypeList;
		}

	


		public static void MapProductFromToSingle(Product productFrom,Product productTo){
							productTo.IdProduct = productFrom.IdProduct;
							productTo.IsDeactivated = productFrom.IsDeactivated;
							productTo.Description = productFrom.Description;
							productTo.IdProductType = productFrom.IdProductType;
							productTo.ItemCode = productFrom.ItemCode;
							productTo.Rate = productFrom.Rate;
							productTo.IdTransactionAccount = productFrom.IdTransactionAccount;
							productTo.Name = productFrom.Name;
							productTo.IdDocument = productFrom.IdDocument;
							productTo.IsLimitedByStock = productFrom.IsLimitedByStock;
							productTo.IdParentProduct = productFrom.IdParentProduct;
							productTo.ImgUrl = productFrom.ImgUrl;
							productTo.IsAvailableOnOrder = productFrom.IsAvailableOnOrder;
			

		}



		public static Product MapProductSingle(Product product,bool singleEntityOnly = false){
            if(product !=null){
			Product _product = new Product();
							_product.IdProduct = product.IdProduct;
							_product.IsDeactivated = product.IsDeactivated;
							_product.Description = product.Description;
							_product.IdProductType = product.IdProductType;
							_product.ItemCode = product.ItemCode;
							_product.Rate = product.Rate;
							_product.IdTransactionAccount = product.IdTransactionAccount;
							_product.Name = product.Name;
							_product.IdDocument = product.IdDocument;
							_product.IsLimitedByStock = product.IsLimitedByStock;
							_product.IdParentProduct = product.IdParentProduct;
							_product.ImgUrl = product.ImgUrl;
							_product.IsAvailableOnOrder = product.IsAvailableOnOrder;
			            if(!singleEntityOnly){
			    					    if(product.ProductType !=null)
						    _product.ProductType = MapProductTypeSingle(product.ProductType,true);
				    					    if(product.Product2 !=null)
						    _product.Product2 = MapProductSingle(product.Product2,true);
				                }
			    return _product;
            }else{
                return null;
            }
		}
		public static List<Product> MapProductList(List<Product> productList){
			 List<Product> _productList = new List<Product>();
             if(productList !=null){
			     productList.ForEach(l=>{
                    _productList.Add(MapProductSingle(l));
			     });
            }
			 return _productList;
		}

        public static List<Product> MapProductListWithSingleItemOnly(List<Product> productList){
			 List<Product> _productList = new List<Product>();
			 productList.ForEach(l=>{
                _productList.Add(MapProductSingle(l,true));
			 });
			 return _productList;
		}

	


		public static void MapProductTypeFromToSingle(ProductType productTypeFrom,ProductType productTypeTo){
							productTypeTo.IdProductType = productTypeFrom.IdProductType;
							productTypeTo.IsDeactivated = productTypeFrom.IsDeactivated;
							productTypeTo.Description = productTypeFrom.Description;
			

		}



		public static ProductType MapProductTypeSingle(ProductType productType,bool singleEntityOnly = false){
            if(productType !=null){
			ProductType _productType = new ProductType();
							_productType.IdProductType = productType.IdProductType;
							_productType.IsDeactivated = productType.IsDeactivated;
							_productType.Description = productType.Description;
			            if(!singleEntityOnly){
			                }
			    return _productType;
            }else{
                return null;
            }
		}
		public static List<ProductType> MapProductTypeList(List<ProductType> productTypeList){
			 List<ProductType> _productTypeList = new List<ProductType>();
             if(productTypeList !=null){
			     productTypeList.ForEach(l=>{
                    _productTypeList.Add(MapProductTypeSingle(l));
			     });
            }
			 return _productTypeList;
		}

        public static List<ProductType> MapProductTypeListWithSingleItemOnly(List<ProductType> productTypeList){
			 List<ProductType> _productTypeList = new List<ProductType>();
			 productTypeList.ForEach(l=>{
                _productTypeList.Add(MapProductTypeSingle(l,true));
			 });
			 return _productTypeList;
		}

	


		public static void MapReceiptFromToSingle(Receipt receiptFrom,Receipt receiptTo){
							receiptTo.IdReceipt = receiptFrom.IdReceipt;
							receiptTo.Number = receiptFrom.Number;
							receiptTo.IsDeactivated = receiptFrom.IsDeactivated;
							receiptTo.IdUser = receiptFrom.IdUser;
			

		}



		public static Receipt MapReceiptSingle(Receipt receipt,bool singleEntityOnly = false){
            if(receipt !=null){
			Receipt _receipt = new Receipt();
							_receipt.IdReceipt = receipt.IdReceipt;
							_receipt.Number = receipt.Number;
							_receipt.IsDeactivated = receipt.IsDeactivated;
							_receipt.IdUser = receipt.IdUser;
			            if(!singleEntityOnly){
			    					    if(receipt.User !=null)
						    _receipt.User = MapUserSingle(receipt.User,true);
				                }
			    return _receipt;
            }else{
                return null;
            }
		}
		public static List<Receipt> MapReceiptList(List<Receipt> receiptList){
			 List<Receipt> _receiptList = new List<Receipt>();
             if(receiptList !=null){
			     receiptList.ForEach(l=>{
                    _receiptList.Add(MapReceiptSingle(l));
			     });
            }
			 return _receiptList;
		}

        public static List<Receipt> MapReceiptListWithSingleItemOnly(List<Receipt> receiptList){
			 List<Receipt> _receiptList = new List<Receipt>();
			 receiptList.ForEach(l=>{
                _receiptList.Add(MapReceiptSingle(l,true));
			 });
			 return _receiptList;
		}

	


		public static void MapRequestFromToSingle(Request requestFrom,Request requestTo){
							requestTo.IdRequest = requestFrom.IdRequest;
							requestTo.IdRequestType = requestFrom.IdRequestType;
							requestTo.IdRequestAuthor = requestFrom.IdRequestAuthor;
							requestTo.RequestDate = requestFrom.RequestDate;
							requestTo.IdWorkflowState = requestFrom.IdWorkflowState;
							requestTo.IdUserAssignedTo = requestFrom.IdUserAssignedTo;
							requestTo.Remarks = requestFrom.Remarks;
							requestTo.IsDeactivated = requestFrom.IsDeactivated;
							requestTo.JsonContent = requestFrom.JsonContent;
			

		}



		public static Request MapRequestSingle(Request request,bool singleEntityOnly = false){
            if(request !=null){
			Request _request = new Request();
							_request.IdRequest = request.IdRequest;
							_request.IdRequestType = request.IdRequestType;
							_request.IdRequestAuthor = request.IdRequestAuthor;
							_request.RequestDate = request.RequestDate;
							_request.IdWorkflowState = request.IdWorkflowState;
							_request.IdUserAssignedTo = request.IdUserAssignedTo;
							_request.Remarks = request.Remarks;
							_request.IsDeactivated = request.IsDeactivated;
							_request.JsonContent = request.JsonContent;
			            if(!singleEntityOnly){
			    					    if(request.RequestType !=null)
						    _request.RequestType = MapRequestTypeSingle(request.RequestType,true);
				    					    if(request.WorkflowState !=null)
						    _request.WorkflowState = MapWorkflowStateSingle(request.WorkflowState,true);
				                }
			    return _request;
            }else{
                return null;
            }
		}
		public static List<Request> MapRequestList(List<Request> requestList){
			 List<Request> _requestList = new List<Request>();
             if(requestList !=null){
			     requestList.ForEach(l=>{
                    _requestList.Add(MapRequestSingle(l));
			     });
            }
			 return _requestList;
		}

        public static List<Request> MapRequestListWithSingleItemOnly(List<Request> requestList){
			 List<Request> _requestList = new List<Request>();
			 requestList.ForEach(l=>{
                _requestList.Add(MapRequestSingle(l,true));
			 });
			 return _requestList;
		}

	


		public static void MapRequestMessageQueueFromToSingle(RequestMessageQueue requestMessageQueueFrom,RequestMessageQueue requestMessageQueueTo){
							requestMessageQueueTo.IdRequestMessageQueue = requestMessageQueueFrom.IdRequestMessageQueue;
							requestMessageQueueTo.IsDeactivated = requestMessageQueueFrom.IsDeactivated;
							requestMessageQueueTo.Message = requestMessageQueueFrom.Message;
							requestMessageQueueTo.IdRequest = requestMessageQueueFrom.IdRequest;
							requestMessageQueueTo.IdUserReceiver = requestMessageQueueFrom.IdUserReceiver;
							requestMessageQueueTo.DateCreated = requestMessageQueueFrom.DateCreated;
			

		}



		public static RequestMessageQueue MapRequestMessageQueueSingle(RequestMessageQueue requestMessageQueue,bool singleEntityOnly = false){
            if(requestMessageQueue !=null){
			RequestMessageQueue _requestMessageQueue = new RequestMessageQueue();
							_requestMessageQueue.IdRequestMessageQueue = requestMessageQueue.IdRequestMessageQueue;
							_requestMessageQueue.IsDeactivated = requestMessageQueue.IsDeactivated;
							_requestMessageQueue.Message = requestMessageQueue.Message;
							_requestMessageQueue.IdRequest = requestMessageQueue.IdRequest;
							_requestMessageQueue.IdUserReceiver = requestMessageQueue.IdUserReceiver;
							_requestMessageQueue.DateCreated = requestMessageQueue.DateCreated;
			            if(!singleEntityOnly){
			    					    if(requestMessageQueue.Request !=null)
						    _requestMessageQueue.Request = MapRequestSingle(requestMessageQueue.Request,true);
				                }
			    return _requestMessageQueue;
            }else{
                return null;
            }
		}
		public static List<RequestMessageQueue> MapRequestMessageQueueList(List<RequestMessageQueue> requestMessageQueueList){
			 List<RequestMessageQueue> _requestMessageQueueList = new List<RequestMessageQueue>();
             if(requestMessageQueueList !=null){
			     requestMessageQueueList.ForEach(l=>{
                    _requestMessageQueueList.Add(MapRequestMessageQueueSingle(l));
			     });
            }
			 return _requestMessageQueueList;
		}

        public static List<RequestMessageQueue> MapRequestMessageQueueListWithSingleItemOnly(List<RequestMessageQueue> requestMessageQueueList){
			 List<RequestMessageQueue> _requestMessageQueueList = new List<RequestMessageQueue>();
			 requestMessageQueueList.ForEach(l=>{
                _requestMessageQueueList.Add(MapRequestMessageQueueSingle(l,true));
			 });
			 return _requestMessageQueueList;
		}

	


		public static void MapRequestTypeFromToSingle(RequestType requestTypeFrom,RequestType requestTypeTo){
							requestTypeTo.IdRequestType = requestTypeFrom.IdRequestType;
							requestTypeTo.Description = requestTypeFrom.Description;
							requestTypeTo.IsDeactivated = requestTypeFrom.IsDeactivated;
							requestTypeTo.IdWorkflow = requestTypeFrom.IdWorkflow;
			

		}



		public static RequestType MapRequestTypeSingle(RequestType requestType,bool singleEntityOnly = false){
            if(requestType !=null){
			RequestType _requestType = new RequestType();
							_requestType.IdRequestType = requestType.IdRequestType;
							_requestType.Description = requestType.Description;
							_requestType.IsDeactivated = requestType.IsDeactivated;
							_requestType.IdWorkflow = requestType.IdWorkflow;
			            if(!singleEntityOnly){
			    					    if(requestType.Workflow !=null)
						    _requestType.Workflow = MapWorkflowSingle(requestType.Workflow,true);
				                }
			    return _requestType;
            }else{
                return null;
            }
		}
		public static List<RequestType> MapRequestTypeList(List<RequestType> requestTypeList){
			 List<RequestType> _requestTypeList = new List<RequestType>();
             if(requestTypeList !=null){
			     requestTypeList.ForEach(l=>{
                    _requestTypeList.Add(MapRequestTypeSingle(l));
			     });
            }
			 return _requestTypeList;
		}

        public static List<RequestType> MapRequestTypeListWithSingleItemOnly(List<RequestType> requestTypeList){
			 List<RequestType> _requestTypeList = new List<RequestType>();
			 requestTypeList.ForEach(l=>{
                _requestTypeList.Add(MapRequestTypeSingle(l,true));
			 });
			 return _requestTypeList;
		}

	


		public static void MapRequestType_UserFromToSingle(RequestType_User requestType_UserFrom,RequestType_User requestType_UserTo){
							requestType_UserTo.IdRequestType_User = requestType_UserFrom.IdRequestType_User;
							requestType_UserTo.IdRequestType = requestType_UserFrom.IdRequestType;
							requestType_UserTo.IdUser = requestType_UserFrom.IdUser;
							requestType_UserTo.IdParentRequestType_User = requestType_UserFrom.IdParentRequestType_User;
							requestType_UserTo.IsDeactivated = requestType_UserFrom.IsDeactivated;
							requestType_UserTo.Priority = requestType_UserFrom.Priority;
			

		}



		public static RequestType_User MapRequestType_UserSingle(RequestType_User requestType_User,bool singleEntityOnly = false){
            if(requestType_User !=null){
			RequestType_User _requestType_User = new RequestType_User();
							_requestType_User.IdRequestType_User = requestType_User.IdRequestType_User;
							_requestType_User.IdRequestType = requestType_User.IdRequestType;
							_requestType_User.IdUser = requestType_User.IdUser;
							_requestType_User.IdParentRequestType_User = requestType_User.IdParentRequestType_User;
							_requestType_User.IsDeactivated = requestType_User.IsDeactivated;
							_requestType_User.Priority = requestType_User.Priority;
			            if(!singleEntityOnly){
			    					    if(requestType_User.User !=null)
						    _requestType_User.User = MapUserSingle(requestType_User.User,true);
				    					    if(requestType_User.RequestType !=null)
						    _requestType_User.RequestType = MapRequestTypeSingle(requestType_User.RequestType,true);
				    					    if(requestType_User.RequestType_User2 !=null)
						    _requestType_User.RequestType_User2 = MapRequestType_UserSingle(requestType_User.RequestType_User2,true);
				                }
			    return _requestType_User;
            }else{
                return null;
            }
		}
		public static List<RequestType_User> MapRequestType_UserList(List<RequestType_User> requestType_UserList){
			 List<RequestType_User> _requestType_UserList = new List<RequestType_User>();
             if(requestType_UserList !=null){
			     requestType_UserList.ForEach(l=>{
                    _requestType_UserList.Add(MapRequestType_UserSingle(l));
			     });
            }
			 return _requestType_UserList;
		}

        public static List<RequestType_User> MapRequestType_UserListWithSingleItemOnly(List<RequestType_User> requestType_UserList){
			 List<RequestType_User> _requestType_UserList = new List<RequestType_User>();
			 requestType_UserList.ForEach(l=>{
                _requestType_UserList.Add(MapRequestType_UserSingle(l,true));
			 });
			 return _requestType_UserList;
		}

	


		public static void MapRoleFromToSingle(Role roleFrom,Role roleTo){
							roleTo.IdRole = roleFrom.IdRole;
							roleTo.Name = roleFrom.Name;
							roleTo.IsDeactivated = roleFrom.IsDeactivated;
			

		}



		public static Role MapRoleSingle(Role role,bool singleEntityOnly = false){
            if(role !=null){
			Role _role = new Role();
							_role.IdRole = role.IdRole;
							_role.Name = role.Name;
							_role.IsDeactivated = role.IsDeactivated;
			            if(!singleEntityOnly){
			                }
			    return _role;
            }else{
                return null;
            }
		}
		public static List<Role> MapRoleList(List<Role> roleList){
			 List<Role> _roleList = new List<Role>();
             if(roleList !=null){
			     roleList.ForEach(l=>{
                    _roleList.Add(MapRoleSingle(l));
			     });
            }
			 return _roleList;
		}

        public static List<Role> MapRoleListWithSingleItemOnly(List<Role> roleList){
			 List<Role> _roleList = new List<Role>();
			 roleList.ForEach(l=>{
                _roleList.Add(MapRoleSingle(l,true));
			 });
			 return _roleList;
		}

	


		public static void MapRole_PermissionFromToSingle(Role_Permission role_PermissionFrom,Role_Permission role_PermissionTo){
							role_PermissionTo.IdRole_Permission = role_PermissionFrom.IdRole_Permission;
							role_PermissionTo.IdRole = role_PermissionFrom.IdRole;
							role_PermissionTo.IdPermission = role_PermissionFrom.IdPermission;
							role_PermissionTo.IsDeactivated = role_PermissionFrom.IsDeactivated;
			

		}



		public static Role_Permission MapRole_PermissionSingle(Role_Permission role_Permission,bool singleEntityOnly = false){
            if(role_Permission !=null){
			Role_Permission _role_Permission = new Role_Permission();
							_role_Permission.IdRole_Permission = role_Permission.IdRole_Permission;
							_role_Permission.IdRole = role_Permission.IdRole;
							_role_Permission.IdPermission = role_Permission.IdPermission;
							_role_Permission.IsDeactivated = role_Permission.IsDeactivated;
			            if(!singleEntityOnly){
			    					    if(role_Permission.Permission !=null)
						    _role_Permission.Permission = MapPermissionSingle(role_Permission.Permission,true);
				    					    if(role_Permission.Role !=null)
						    _role_Permission.Role = MapRoleSingle(role_Permission.Role,true);
				                }
			    return _role_Permission;
            }else{
                return null;
            }
		}
		public static List<Role_Permission> MapRole_PermissionList(List<Role_Permission> role_PermissionList){
			 List<Role_Permission> _role_PermissionList = new List<Role_Permission>();
             if(role_PermissionList !=null){
			     role_PermissionList.ForEach(l=>{
                    _role_PermissionList.Add(MapRole_PermissionSingle(l));
			     });
            }
			 return _role_PermissionList;
		}

        public static List<Role_Permission> MapRole_PermissionListWithSingleItemOnly(List<Role_Permission> role_PermissionList){
			 List<Role_Permission> _role_PermissionList = new List<Role_Permission>();
			 role_PermissionList.ForEach(l=>{
                _role_PermissionList.Add(MapRole_PermissionSingle(l,true));
			 });
			 return _role_PermissionList;
		}

	


		public static void MapScheduleSettingFromToSingle(ScheduleSetting scheduleSettingFrom,ScheduleSetting scheduleSettingTo){
							scheduleSettingTo.IdScheduleSetting = scheduleSettingFrom.IdScheduleSetting;
							scheduleSettingTo.IsDeactivated = scheduleSettingFrom.IsDeactivated;
							scheduleSettingTo.IdFrequency = scheduleSettingFrom.IdFrequency;
							scheduleSettingTo.ReccurEvery = scheduleSettingFrom.ReccurEvery;
							scheduleSettingTo.WeekOccursOnDays = scheduleSettingFrom.WeekOccursOnDays;
							scheduleSettingTo.MonthOccurs = scheduleSettingFrom.MonthOccurs;
							scheduleSettingTo.MonthOnSpecificDays = scheduleSettingFrom.MonthOnSpecificDays;
							scheduleSettingTo.MonthEveryOrdinal = scheduleSettingFrom.MonthEveryOrdinal;
							scheduleSettingTo.MonthEveryDays = scheduleSettingFrom.MonthEveryDays;
							scheduleSettingTo.StartDate = scheduleSettingFrom.StartDate;
							scheduleSettingTo.EndDate = scheduleSettingFrom.EndDate;
							scheduleSettingTo.IdTransaction = scheduleSettingFrom.IdTransaction;
			

		}



		public static ScheduleSetting MapScheduleSettingSingle(ScheduleSetting scheduleSetting,bool singleEntityOnly = false){
            if(scheduleSetting !=null){
			ScheduleSetting _scheduleSetting = new ScheduleSetting();
							_scheduleSetting.IdScheduleSetting = scheduleSetting.IdScheduleSetting;
							_scheduleSetting.IsDeactivated = scheduleSetting.IsDeactivated;
							_scheduleSetting.IdFrequency = scheduleSetting.IdFrequency;
							_scheduleSetting.ReccurEvery = scheduleSetting.ReccurEvery;
							_scheduleSetting.WeekOccursOnDays = scheduleSetting.WeekOccursOnDays;
							_scheduleSetting.MonthOccurs = scheduleSetting.MonthOccurs;
							_scheduleSetting.MonthOnSpecificDays = scheduleSetting.MonthOnSpecificDays;
							_scheduleSetting.MonthEveryOrdinal = scheduleSetting.MonthEveryOrdinal;
							_scheduleSetting.MonthEveryDays = scheduleSetting.MonthEveryDays;
							_scheduleSetting.StartDate = scheduleSetting.StartDate;
							_scheduleSetting.EndDate = scheduleSetting.EndDate;
							_scheduleSetting.IdTransaction = scheduleSetting.IdTransaction;
			            if(!singleEntityOnly){
			    					    if(scheduleSetting.Frequency !=null)
						    _scheduleSetting.Frequency = MapFrequencySingle(scheduleSetting.Frequency,true);
				    					    if(scheduleSetting.Transaction !=null)
						    _scheduleSetting.Transaction = MapTransactionSingle(scheduleSetting.Transaction,true);
				                }
			    return _scheduleSetting;
            }else{
                return null;
            }
		}
		public static List<ScheduleSetting> MapScheduleSettingList(List<ScheduleSetting> scheduleSettingList){
			 List<ScheduleSetting> _scheduleSettingList = new List<ScheduleSetting>();
             if(scheduleSettingList !=null){
			     scheduleSettingList.ForEach(l=>{
                    _scheduleSettingList.Add(MapScheduleSettingSingle(l));
			     });
            }
			 return _scheduleSettingList;
		}

        public static List<ScheduleSetting> MapScheduleSettingListWithSingleItemOnly(List<ScheduleSetting> scheduleSettingList){
			 List<ScheduleSetting> _scheduleSettingList = new List<ScheduleSetting>();
			 scheduleSettingList.ForEach(l=>{
                _scheduleSettingList.Add(MapScheduleSettingSingle(l,true));
			 });
			 return _scheduleSettingList;
		}

	


		public static void MapStockLocationFromToSingle(StockLocation stockLocationFrom,StockLocation stockLocationTo){
							stockLocationTo.IdStockLocation = stockLocationFrom.IdStockLocation;
							stockLocationTo.Description = stockLocationFrom.Description;
							stockLocationTo.DisplayOrder = stockLocationFrom.DisplayOrder;
							stockLocationTo.IsDeactivated = stockLocationFrom.IsDeactivated;
			

		}



		public static StockLocation MapStockLocationSingle(StockLocation stockLocation,bool singleEntityOnly = false){
            if(stockLocation !=null){
			StockLocation _stockLocation = new StockLocation();
							_stockLocation.IdStockLocation = stockLocation.IdStockLocation;
							_stockLocation.Description = stockLocation.Description;
							_stockLocation.DisplayOrder = stockLocation.DisplayOrder;
							_stockLocation.IsDeactivated = stockLocation.IsDeactivated;
			            if(!singleEntityOnly){
			                }
			    return _stockLocation;
            }else{
                return null;
            }
		}
		public static List<StockLocation> MapStockLocationList(List<StockLocation> stockLocationList){
			 List<StockLocation> _stockLocationList = new List<StockLocation>();
             if(stockLocationList !=null){
			     stockLocationList.ForEach(l=>{
                    _stockLocationList.Add(MapStockLocationSingle(l));
			     });
            }
			 return _stockLocationList;
		}

        public static List<StockLocation> MapStockLocationListWithSingleItemOnly(List<StockLocation> stockLocationList){
			 List<StockLocation> _stockLocationList = new List<StockLocation>();
			 stockLocationList.ForEach(l=>{
                _stockLocationList.Add(MapStockLocationSingle(l,true));
			 });
			 return _stockLocationList;
		}

	


		public static void MapTemporaryPaymentFromToSingle(TemporaryPayment temporaryPaymentFrom,TemporaryPayment temporaryPaymentTo){
							temporaryPaymentTo.IdTemporaryPayment = temporaryPaymentFrom.IdTemporaryPayment;
							temporaryPaymentTo.IsDeactivated = temporaryPaymentFrom.IsDeactivated;
							temporaryPaymentTo.PaymentDate = temporaryPaymentFrom.PaymentDate;
							temporaryPaymentTo.IdUserAuthor = temporaryPaymentFrom.IdUserAuthor;
							temporaryPaymentTo.Identifier = temporaryPaymentFrom.Identifier;
			

		}



		public static TemporaryPayment MapTemporaryPaymentSingle(TemporaryPayment temporaryPayment,bool singleEntityOnly = false){
            if(temporaryPayment !=null){
			TemporaryPayment _temporaryPayment = new TemporaryPayment();
							_temporaryPayment.IdTemporaryPayment = temporaryPayment.IdTemporaryPayment;
							_temporaryPayment.IsDeactivated = temporaryPayment.IsDeactivated;
							_temporaryPayment.PaymentDate = temporaryPayment.PaymentDate;
							_temporaryPayment.IdUserAuthor = temporaryPayment.IdUserAuthor;
							_temporaryPayment.Identifier = temporaryPayment.Identifier;
			            if(!singleEntityOnly){
			                }
			    return _temporaryPayment;
            }else{
                return null;
            }
		}
		public static List<TemporaryPayment> MapTemporaryPaymentList(List<TemporaryPayment> temporaryPaymentList){
			 List<TemporaryPayment> _temporaryPaymentList = new List<TemporaryPayment>();
             if(temporaryPaymentList !=null){
			     temporaryPaymentList.ForEach(l=>{
                    _temporaryPaymentList.Add(MapTemporaryPaymentSingle(l));
			     });
            }
			 return _temporaryPaymentList;
		}

        public static List<TemporaryPayment> MapTemporaryPaymentListWithSingleItemOnly(List<TemporaryPayment> temporaryPaymentList){
			 List<TemporaryPayment> _temporaryPaymentList = new List<TemporaryPayment>();
			 temporaryPaymentList.ForEach(l=>{
                _temporaryPaymentList.Add(MapTemporaryPaymentSingle(l,true));
			 });
			 return _temporaryPaymentList;
		}

	


		public static void MapTemporaryPaymentDetailFromToSingle(TemporaryPaymentDetail temporaryPaymentDetailFrom,TemporaryPaymentDetail temporaryPaymentDetailTo){
							temporaryPaymentDetailTo.IdTemporaryPaymentDetail = temporaryPaymentDetailFrom.IdTemporaryPaymentDetail;
							temporaryPaymentDetailTo.IsDeactivated = temporaryPaymentDetailFrom.IsDeactivated;
							temporaryPaymentDetailTo.PaymentAmount = temporaryPaymentDetailFrom.PaymentAmount;
							temporaryPaymentDetailTo.IdPaymentMethod = temporaryPaymentDetailFrom.IdPaymentMethod;
							temporaryPaymentDetailTo.IdTemporaryPayment = temporaryPaymentDetailFrom.IdTemporaryPayment;
							temporaryPaymentDetailTo.ChequeNo = temporaryPaymentDetailFrom.ChequeNo;
							temporaryPaymentDetailTo.Identifier = temporaryPaymentDetailFrom.Identifier;
			

		}



		public static TemporaryPaymentDetail MapTemporaryPaymentDetailSingle(TemporaryPaymentDetail temporaryPaymentDetail,bool singleEntityOnly = false){
            if(temporaryPaymentDetail !=null){
			TemporaryPaymentDetail _temporaryPaymentDetail = new TemporaryPaymentDetail();
							_temporaryPaymentDetail.IdTemporaryPaymentDetail = temporaryPaymentDetail.IdTemporaryPaymentDetail;
							_temporaryPaymentDetail.IsDeactivated = temporaryPaymentDetail.IsDeactivated;
							_temporaryPaymentDetail.PaymentAmount = temporaryPaymentDetail.PaymentAmount;
							_temporaryPaymentDetail.IdPaymentMethod = temporaryPaymentDetail.IdPaymentMethod;
							_temporaryPaymentDetail.IdTemporaryPayment = temporaryPaymentDetail.IdTemporaryPayment;
							_temporaryPaymentDetail.ChequeNo = temporaryPaymentDetail.ChequeNo;
							_temporaryPaymentDetail.Identifier = temporaryPaymentDetail.Identifier;
			            if(!singleEntityOnly){
			    					    if(temporaryPaymentDetail.TemporaryPayment !=null)
						    _temporaryPaymentDetail.TemporaryPayment = MapTemporaryPaymentSingle(temporaryPaymentDetail.TemporaryPayment,true);
				                }
			    return _temporaryPaymentDetail;
            }else{
                return null;
            }
		}
		public static List<TemporaryPaymentDetail> MapTemporaryPaymentDetailList(List<TemporaryPaymentDetail> temporaryPaymentDetailList){
			 List<TemporaryPaymentDetail> _temporaryPaymentDetailList = new List<TemporaryPaymentDetail>();
             if(temporaryPaymentDetailList !=null){
			     temporaryPaymentDetailList.ForEach(l=>{
                    _temporaryPaymentDetailList.Add(MapTemporaryPaymentDetailSingle(l));
			     });
            }
			 return _temporaryPaymentDetailList;
		}

        public static List<TemporaryPaymentDetail> MapTemporaryPaymentDetailListWithSingleItemOnly(List<TemporaryPaymentDetail> temporaryPaymentDetailList){
			 List<TemporaryPaymentDetail> _temporaryPaymentDetailList = new List<TemporaryPaymentDetail>();
			 temporaryPaymentDetailList.ForEach(l=>{
                _temporaryPaymentDetailList.Add(MapTemporaryPaymentDetailSingle(l,true));
			 });
			 return _temporaryPaymentDetailList;
		}

	


		public static void MapTemporaryTransactionFromToSingle(TemporaryTransaction temporaryTransactionFrom,TemporaryTransaction temporaryTransactionTo){
							temporaryTransactionTo.IdTemporaryTransaction = temporaryTransactionFrom.IdTemporaryTransaction;
							temporaryTransactionTo.IdTransactionType = temporaryTransactionFrom.IdTransactionType;
							temporaryTransactionTo.IsDeactivated = temporaryTransactionFrom.IsDeactivated;
							temporaryTransactionTo.TransactionDate = temporaryTransactionFrom.TransactionDate;
							temporaryTransactionTo.ReceiptNo = temporaryTransactionFrom.ReceiptNo;
							temporaryTransactionTo.IdCustomer = temporaryTransactionFrom.IdCustomer;
							temporaryTransactionTo.IdTransactionClass = temporaryTransactionFrom.IdTransactionClass;
							temporaryTransactionTo.IdTransactionTemplate = temporaryTransactionFrom.IdTransactionTemplate;
							temporaryTransactionTo.IdTransactionAccount = temporaryTransactionFrom.IdTransactionAccount;
							temporaryTransactionTo.Memo = temporaryTransactionFrom.Memo;
							temporaryTransactionTo.CapturedDate = temporaryTransactionFrom.CapturedDate;
							temporaryTransactionTo.TotalAmount = temporaryTransactionFrom.TotalAmount;
							temporaryTransactionTo.IdUserAuthor = temporaryTransactionFrom.IdUserAuthor;
							temporaryTransactionTo.IdTemporaryPayment = temporaryTransactionFrom.IdTemporaryPayment;
							temporaryTransactionTo.IdBankStatementStagingDetail = temporaryTransactionFrom.IdBankStatementStagingDetail;
							temporaryTransactionTo.Identitifier = temporaryTransactionFrom.Identitifier;
							temporaryTransactionTo.IdBankStatementHitList = temporaryTransactionFrom.IdBankStatementHitList;
							temporaryTransactionTo.IdBankStatementStagingHit = temporaryTransactionFrom.IdBankStatementStagingHit;
			

		}



		public static TemporaryTransaction MapTemporaryTransactionSingle(TemporaryTransaction temporaryTransaction,bool singleEntityOnly = false){
            if(temporaryTransaction !=null){
			TemporaryTransaction _temporaryTransaction = new TemporaryTransaction();
							_temporaryTransaction.IdTemporaryTransaction = temporaryTransaction.IdTemporaryTransaction;
							_temporaryTransaction.IdTransactionType = temporaryTransaction.IdTransactionType;
							_temporaryTransaction.IsDeactivated = temporaryTransaction.IsDeactivated;
							_temporaryTransaction.TransactionDate = temporaryTransaction.TransactionDate;
							_temporaryTransaction.ReceiptNo = temporaryTransaction.ReceiptNo;
							_temporaryTransaction.IdCustomer = temporaryTransaction.IdCustomer;
							_temporaryTransaction.IdTransactionClass = temporaryTransaction.IdTransactionClass;
							_temporaryTransaction.IdTransactionTemplate = temporaryTransaction.IdTransactionTemplate;
							_temporaryTransaction.IdTransactionAccount = temporaryTransaction.IdTransactionAccount;
							_temporaryTransaction.Memo = temporaryTransaction.Memo;
							_temporaryTransaction.CapturedDate = temporaryTransaction.CapturedDate;
							_temporaryTransaction.TotalAmount = temporaryTransaction.TotalAmount;
							_temporaryTransaction.IdUserAuthor = temporaryTransaction.IdUserAuthor;
							_temporaryTransaction.IdTemporaryPayment = temporaryTransaction.IdTemporaryPayment;
							_temporaryTransaction.IdBankStatementStagingDetail = temporaryTransaction.IdBankStatementStagingDetail;
							_temporaryTransaction.Identitifier = temporaryTransaction.Identitifier;
							_temporaryTransaction.IdBankStatementHitList = temporaryTransaction.IdBankStatementHitList;
							_temporaryTransaction.IdBankStatementStagingHit = temporaryTransaction.IdBankStatementStagingHit;
			            if(!singleEntityOnly){
			    					    if(temporaryTransaction.BankStatementHitList !=null)
						    _temporaryTransaction.BankStatementHitList = MapBankStatementHitListSingle(temporaryTransaction.BankStatementHitList,true);
				    					    if(temporaryTransaction.BankStatementStagingDetail !=null)
						    _temporaryTransaction.BankStatementStagingDetail = MapBankStatementStagingDetailSingle(temporaryTransaction.BankStatementStagingDetail,true);
				    					    if(temporaryTransaction.BankStatementStagingHit !=null)
						    _temporaryTransaction.BankStatementStagingHit = MapBankStatementStagingHitSingle(temporaryTransaction.BankStatementStagingHit,true);
				    					    if(temporaryTransaction.TemporaryPayment !=null)
						    _temporaryTransaction.TemporaryPayment = MapTemporaryPaymentSingle(temporaryTransaction.TemporaryPayment,true);
				                }
			    return _temporaryTransaction;
            }else{
                return null;
            }
		}
		public static List<TemporaryTransaction> MapTemporaryTransactionList(List<TemporaryTransaction> temporaryTransactionList){
			 List<TemporaryTransaction> _temporaryTransactionList = new List<TemporaryTransaction>();
             if(temporaryTransactionList !=null){
			     temporaryTransactionList.ForEach(l=>{
                    _temporaryTransactionList.Add(MapTemporaryTransactionSingle(l));
			     });
            }
			 return _temporaryTransactionList;
		}

        public static List<TemporaryTransaction> MapTemporaryTransactionListWithSingleItemOnly(List<TemporaryTransaction> temporaryTransactionList){
			 List<TemporaryTransaction> _temporaryTransactionList = new List<TemporaryTransaction>();
			 temporaryTransactionList.ForEach(l=>{
                _temporaryTransactionList.Add(MapTemporaryTransactionSingle(l,true));
			 });
			 return _temporaryTransactionList;
		}

	


		public static void MapTemporaryTransactionDetailFromToSingle(TemporaryTransactionDetail temporaryTransactionDetailFrom,TemporaryTransactionDetail temporaryTransactionDetailTo){
							temporaryTransactionDetailTo.IdTemporaryTransactionDetail = temporaryTransactionDetailFrom.IdTemporaryTransactionDetail;
							temporaryTransactionDetailTo.IsDeactivated = temporaryTransactionDetailFrom.IsDeactivated;
							temporaryTransactionDetailTo.IdTemporaryTransaction = temporaryTransactionDetailFrom.IdTemporaryTransaction;
							temporaryTransactionDetailTo.IdProduct = temporaryTransactionDetailFrom.IdProduct;
							temporaryTransactionDetailTo.Description = temporaryTransactionDetailFrom.Description;
							temporaryTransactionDetailTo.Quantity = temporaryTransactionDetailFrom.Quantity;
							temporaryTransactionDetailTo.Rate = temporaryTransactionDetailFrom.Rate;
							temporaryTransactionDetailTo.IdTransactionClass = temporaryTransactionDetailFrom.IdTransactionClass;
							temporaryTransactionDetailTo.Identifier = temporaryTransactionDetailFrom.Identifier;
			

		}



		public static TemporaryTransactionDetail MapTemporaryTransactionDetailSingle(TemporaryTransactionDetail temporaryTransactionDetail,bool singleEntityOnly = false){
            if(temporaryTransactionDetail !=null){
			TemporaryTransactionDetail _temporaryTransactionDetail = new TemporaryTransactionDetail();
							_temporaryTransactionDetail.IdTemporaryTransactionDetail = temporaryTransactionDetail.IdTemporaryTransactionDetail;
							_temporaryTransactionDetail.IsDeactivated = temporaryTransactionDetail.IsDeactivated;
							_temporaryTransactionDetail.IdTemporaryTransaction = temporaryTransactionDetail.IdTemporaryTransaction;
							_temporaryTransactionDetail.IdProduct = temporaryTransactionDetail.IdProduct;
							_temporaryTransactionDetail.Description = temporaryTransactionDetail.Description;
							_temporaryTransactionDetail.Quantity = temporaryTransactionDetail.Quantity;
							_temporaryTransactionDetail.Rate = temporaryTransactionDetail.Rate;
							_temporaryTransactionDetail.IdTransactionClass = temporaryTransactionDetail.IdTransactionClass;
							_temporaryTransactionDetail.Identifier = temporaryTransactionDetail.Identifier;
			            if(!singleEntityOnly){
			    					    if(temporaryTransactionDetail.TemporaryTransaction !=null)
						    _temporaryTransactionDetail.TemporaryTransaction = MapTemporaryTransactionSingle(temporaryTransactionDetail.TemporaryTransaction,true);
				                }
			    return _temporaryTransactionDetail;
            }else{
                return null;
            }
		}
		public static List<TemporaryTransactionDetail> MapTemporaryTransactionDetailList(List<TemporaryTransactionDetail> temporaryTransactionDetailList){
			 List<TemporaryTransactionDetail> _temporaryTransactionDetailList = new List<TemporaryTransactionDetail>();
             if(temporaryTransactionDetailList !=null){
			     temporaryTransactionDetailList.ForEach(l=>{
                    _temporaryTransactionDetailList.Add(MapTemporaryTransactionDetailSingle(l));
			     });
            }
			 return _temporaryTransactionDetailList;
		}

        public static List<TemporaryTransactionDetail> MapTemporaryTransactionDetailListWithSingleItemOnly(List<TemporaryTransactionDetail> temporaryTransactionDetailList){
			 List<TemporaryTransactionDetail> _temporaryTransactionDetailList = new List<TemporaryTransactionDetail>();
			 temporaryTransactionDetailList.ForEach(l=>{
                _temporaryTransactionDetailList.Add(MapTemporaryTransactionDetailSingle(l,true));
			 });
			 return _temporaryTransactionDetailList;
		}

	


		public static void MapTemporaryTransactionOrderFromToSingle(TemporaryTransactionOrder temporaryTransactionOrderFrom,TemporaryTransactionOrder temporaryTransactionOrderTo){
							temporaryTransactionOrderTo.IdTemporaryTransactionOrder = temporaryTransactionOrderFrom.IdTemporaryTransactionOrder;
							temporaryTransactionOrderTo.IsDeactivated = temporaryTransactionOrderFrom.IsDeactivated;
							temporaryTransactionOrderTo.IdTemporaryTransactionOrderState = temporaryTransactionOrderFrom.IdTemporaryTransactionOrderState;
							temporaryTransactionOrderTo.TransactionJson = temporaryTransactionOrderFrom.TransactionJson;
							temporaryTransactionOrderTo.SignatureImage = temporaryTransactionOrderFrom.SignatureImage;
							temporaryTransactionOrderTo.TemporaryTransactionOrderDate = temporaryTransactionOrderFrom.TemporaryTransactionOrderDate;
							temporaryTransactionOrderTo.IdWorkstation = temporaryTransactionOrderFrom.IdWorkstation;
							temporaryTransactionOrderTo.IdSignatureDocument = temporaryTransactionOrderFrom.IdSignatureDocument;
			

		}



		public static TemporaryTransactionOrder MapTemporaryTransactionOrderSingle(TemporaryTransactionOrder temporaryTransactionOrder,bool singleEntityOnly = false){
            if(temporaryTransactionOrder !=null){
			TemporaryTransactionOrder _temporaryTransactionOrder = new TemporaryTransactionOrder();
							_temporaryTransactionOrder.IdTemporaryTransactionOrder = temporaryTransactionOrder.IdTemporaryTransactionOrder;
							_temporaryTransactionOrder.IsDeactivated = temporaryTransactionOrder.IsDeactivated;
							_temporaryTransactionOrder.IdTemporaryTransactionOrderState = temporaryTransactionOrder.IdTemporaryTransactionOrderState;
							_temporaryTransactionOrder.TransactionJson = temporaryTransactionOrder.TransactionJson;
							_temporaryTransactionOrder.SignatureImage = temporaryTransactionOrder.SignatureImage;
							_temporaryTransactionOrder.TemporaryTransactionOrderDate = temporaryTransactionOrder.TemporaryTransactionOrderDate;
							_temporaryTransactionOrder.IdWorkstation = temporaryTransactionOrder.IdWorkstation;
							_temporaryTransactionOrder.IdSignatureDocument = temporaryTransactionOrder.IdSignatureDocument;
			            if(!singleEntityOnly){
			    					    if(temporaryTransactionOrder.TemporaryTransactionOrderState !=null)
						    _temporaryTransactionOrder.TemporaryTransactionOrderState = MapTemporaryTransactionOrderStateSingle(temporaryTransactionOrder.TemporaryTransactionOrderState,true);
				    					    if(temporaryTransactionOrder.Document !=null)
						    _temporaryTransactionOrder.Document = MapDocumentSingle(temporaryTransactionOrder.Document,true);
				                }
			    return _temporaryTransactionOrder;
            }else{
                return null;
            }
		}
		public static List<TemporaryTransactionOrder> MapTemporaryTransactionOrderList(List<TemporaryTransactionOrder> temporaryTransactionOrderList){
			 List<TemporaryTransactionOrder> _temporaryTransactionOrderList = new List<TemporaryTransactionOrder>();
             if(temporaryTransactionOrderList !=null){
			     temporaryTransactionOrderList.ForEach(l=>{
                    _temporaryTransactionOrderList.Add(MapTemporaryTransactionOrderSingle(l));
			     });
            }
			 return _temporaryTransactionOrderList;
		}

        public static List<TemporaryTransactionOrder> MapTemporaryTransactionOrderListWithSingleItemOnly(List<TemporaryTransactionOrder> temporaryTransactionOrderList){
			 List<TemporaryTransactionOrder> _temporaryTransactionOrderList = new List<TemporaryTransactionOrder>();
			 temporaryTransactionOrderList.ForEach(l=>{
                _temporaryTransactionOrderList.Add(MapTemporaryTransactionOrderSingle(l,true));
			 });
			 return _temporaryTransactionOrderList;
		}

	


		public static void MapTemporaryTransactionOrderStateFromToSingle(TemporaryTransactionOrderState temporaryTransactionOrderStateFrom,TemporaryTransactionOrderState temporaryTransactionOrderStateTo){
							temporaryTransactionOrderStateTo.IdTemporaryTransactionOrderState = temporaryTransactionOrderStateFrom.IdTemporaryTransactionOrderState;
							temporaryTransactionOrderStateTo.Description = temporaryTransactionOrderStateFrom.Description;
							temporaryTransactionOrderStateTo.IsDeactivated = temporaryTransactionOrderStateFrom.IsDeactivated;
			

		}



		public static TemporaryTransactionOrderState MapTemporaryTransactionOrderStateSingle(TemporaryTransactionOrderState temporaryTransactionOrderState,bool singleEntityOnly = false){
            if(temporaryTransactionOrderState !=null){
			TemporaryTransactionOrderState _temporaryTransactionOrderState = new TemporaryTransactionOrderState();
							_temporaryTransactionOrderState.IdTemporaryTransactionOrderState = temporaryTransactionOrderState.IdTemporaryTransactionOrderState;
							_temporaryTransactionOrderState.Description = temporaryTransactionOrderState.Description;
							_temporaryTransactionOrderState.IsDeactivated = temporaryTransactionOrderState.IsDeactivated;
			            if(!singleEntityOnly){
			                }
			    return _temporaryTransactionOrderState;
            }else{
                return null;
            }
		}
		public static List<TemporaryTransactionOrderState> MapTemporaryTransactionOrderStateList(List<TemporaryTransactionOrderState> temporaryTransactionOrderStateList){
			 List<TemporaryTransactionOrderState> _temporaryTransactionOrderStateList = new List<TemporaryTransactionOrderState>();
             if(temporaryTransactionOrderStateList !=null){
			     temporaryTransactionOrderStateList.ForEach(l=>{
                    _temporaryTransactionOrderStateList.Add(MapTemporaryTransactionOrderStateSingle(l));
			     });
            }
			 return _temporaryTransactionOrderStateList;
		}

        public static List<TemporaryTransactionOrderState> MapTemporaryTransactionOrderStateListWithSingleItemOnly(List<TemporaryTransactionOrderState> temporaryTransactionOrderStateList){
			 List<TemporaryTransactionOrderState> _temporaryTransactionOrderStateList = new List<TemporaryTransactionOrderState>();
			 temporaryTransactionOrderStateList.ForEach(l=>{
                _temporaryTransactionOrderStateList.Add(MapTemporaryTransactionOrderStateSingle(l,true));
			 });
			 return _temporaryTransactionOrderStateList;
		}

	


		public static void MapTitleFromToSingle(Title titleFrom,Title titleTo){
							titleTo.IdTitle = titleFrom.IdTitle;
							titleTo.Description = titleFrom.Description;
							titleTo.IsDeactivated = titleFrom.IsDeactivated;
			

		}



		public static Title MapTitleSingle(Title title,bool singleEntityOnly = false){
            if(title !=null){
			Title _title = new Title();
							_title.IdTitle = title.IdTitle;
							_title.Description = title.Description;
							_title.IsDeactivated = title.IsDeactivated;
			            if(!singleEntityOnly){
			                }
			    return _title;
            }else{
                return null;
            }
		}
		public static List<Title> MapTitleList(List<Title> titleList){
			 List<Title> _titleList = new List<Title>();
             if(titleList !=null){
			     titleList.ForEach(l=>{
                    _titleList.Add(MapTitleSingle(l));
			     });
            }
			 return _titleList;
		}

        public static List<Title> MapTitleListWithSingleItemOnly(List<Title> titleList){
			 List<Title> _titleList = new List<Title>();
			 titleList.ForEach(l=>{
                _titleList.Add(MapTitleSingle(l,true));
			 });
			 return _titleList;
		}

	


		public static void MapTransactionFromToSingle(Transaction transactionFrom,Transaction transactionTo){
							transactionTo.IdTransaction = transactionFrom.IdTransaction;
							transactionTo.IdTransactionType = transactionFrom.IdTransactionType;
							transactionTo.IsDeactivated = transactionFrom.IsDeactivated;
							transactionTo.TransactionDate = transactionFrom.TransactionDate;
							transactionTo.ReceiptNo = transactionFrom.ReceiptNo;
							transactionTo.IdCustomer = transactionFrom.IdCustomer;
							transactionTo.IdTransactionClass = transactionFrom.IdTransactionClass;
							transactionTo.IdTransactionTemplate = transactionFrom.IdTransactionTemplate;
							transactionTo.IdTransactionAccount = transactionFrom.IdTransactionAccount;
							transactionTo.Memo = transactionFrom.Memo;
							transactionTo.CapturedDate = transactionFrom.CapturedDate;
							transactionTo.TotalAmount = transactionFrom.TotalAmount;
							transactionTo.IdUserAuthor = transactionFrom.IdUserAuthor;
							transactionTo.IdSignatureDocument = transactionFrom.IdSignatureDocument;
							transactionTo.IdTransactionState = transactionFrom.IdTransactionState;
							transactionTo.IdTransactionOriginal = transactionFrom.IdTransactionOriginal;
							transactionTo.IdPayment = transactionFrom.IdPayment;
			

		}



		public static Transaction MapTransactionSingle(Transaction transaction,bool singleEntityOnly = false){
            if(transaction !=null){
			Transaction _transaction = new Transaction();
							_transaction.IdTransaction = transaction.IdTransaction;
							_transaction.IdTransactionType = transaction.IdTransactionType;
							_transaction.IsDeactivated = transaction.IsDeactivated;
							_transaction.TransactionDate = transaction.TransactionDate;
							_transaction.ReceiptNo = transaction.ReceiptNo;
							_transaction.IdCustomer = transaction.IdCustomer;
							_transaction.IdTransactionClass = transaction.IdTransactionClass;
							_transaction.IdTransactionTemplate = transaction.IdTransactionTemplate;
							_transaction.IdTransactionAccount = transaction.IdTransactionAccount;
							_transaction.Memo = transaction.Memo;
							_transaction.CapturedDate = transaction.CapturedDate;
							_transaction.TotalAmount = transaction.TotalAmount;
							_transaction.IdUserAuthor = transaction.IdUserAuthor;
							_transaction.IdSignatureDocument = transaction.IdSignatureDocument;
							_transaction.IdTransactionState = transaction.IdTransactionState;
							_transaction.IdTransactionOriginal = transaction.IdTransactionOriginal;
							_transaction.IdPayment = transaction.IdPayment;
			            if(!singleEntityOnly){
			    					    if(transaction.User !=null)
						    _transaction.User = MapUserSingle(transaction.User,true);
				    					    if(transaction.TransactionState !=null)
						    _transaction.TransactionState = MapTransactionStateSingle(transaction.TransactionState,true);
				    					    if(transaction.TransactionType !=null)
						    _transaction.TransactionType = MapTransactionTypeSingle(transaction.TransactionType,true);
				    					    if(transaction.Customer !=null)
						    _transaction.Customer = MapCustomerSingle(transaction.Customer,true);
				    					    if(transaction.Document !=null)
						    _transaction.Document = MapDocumentSingle(transaction.Document,true);
				    					    if(transaction.Payment !=null)
						    _transaction.Payment = MapPaymentSingle(transaction.Payment,true);
				    					    if(transaction.TransactionAccount !=null)
						    _transaction.TransactionAccount = MapTransactionAccountSingle(transaction.TransactionAccount,true);
				    					    if(transaction.TransactionClass !=null)
						    _transaction.TransactionClass = MapTransactionClassSingle(transaction.TransactionClass,true);
				    					    if(transaction.TransactionTemplate !=null)
						    _transaction.TransactionTemplate = MapTransactionTemplateSingle(transaction.TransactionTemplate,true);
				                }
			    return _transaction;
            }else{
                return null;
            }
		}
		public static List<Transaction> MapTransactionList(List<Transaction> transactionList){
			 List<Transaction> _transactionList = new List<Transaction>();
             if(transactionList !=null){
			     transactionList.ForEach(l=>{
                    _transactionList.Add(MapTransactionSingle(l));
			     });
            }
			 return _transactionList;
		}

        public static List<Transaction> MapTransactionListWithSingleItemOnly(List<Transaction> transactionList){
			 List<Transaction> _transactionList = new List<Transaction>();
			 transactionList.ForEach(l=>{
                _transactionList.Add(MapTransactionSingle(l,true));
			 });
			 return _transactionList;
		}

	


		public static void MapTransaction_BankStatementStagingDetailFromToSingle(Transaction_BankStatementStagingDetail transaction_BankStatementStagingDetailFrom,Transaction_BankStatementStagingDetail transaction_BankStatementStagingDetailTo){
							transaction_BankStatementStagingDetailTo.IdTransaction_BankStatementStagingDetail = transaction_BankStatementStagingDetailFrom.IdTransaction_BankStatementStagingDetail;
							transaction_BankStatementStagingDetailTo.IdTransaction = transaction_BankStatementStagingDetailFrom.IdTransaction;
							transaction_BankStatementStagingDetailTo.IdBankStatementStagingDetail = transaction_BankStatementStagingDetailFrom.IdBankStatementStagingDetail;
							transaction_BankStatementStagingDetailTo.IsDeactivated = transaction_BankStatementStagingDetailFrom.IsDeactivated;
			

		}



		public static Transaction_BankStatementStagingDetail MapTransaction_BankStatementStagingDetailSingle(Transaction_BankStatementStagingDetail transaction_BankStatementStagingDetail,bool singleEntityOnly = false){
            if(transaction_BankStatementStagingDetail !=null){
			Transaction_BankStatementStagingDetail _transaction_BankStatementStagingDetail = new Transaction_BankStatementStagingDetail();
							_transaction_BankStatementStagingDetail.IdTransaction_BankStatementStagingDetail = transaction_BankStatementStagingDetail.IdTransaction_BankStatementStagingDetail;
							_transaction_BankStatementStagingDetail.IdTransaction = transaction_BankStatementStagingDetail.IdTransaction;
							_transaction_BankStatementStagingDetail.IdBankStatementStagingDetail = transaction_BankStatementStagingDetail.IdBankStatementStagingDetail;
							_transaction_BankStatementStagingDetail.IsDeactivated = transaction_BankStatementStagingDetail.IsDeactivated;
			            if(!singleEntityOnly){
			    					    if(transaction_BankStatementStagingDetail.BankStatementStagingDetail !=null)
						    _transaction_BankStatementStagingDetail.BankStatementStagingDetail = MapBankStatementStagingDetailSingle(transaction_BankStatementStagingDetail.BankStatementStagingDetail,true);
				    					    if(transaction_BankStatementStagingDetail.Transaction !=null)
						    _transaction_BankStatementStagingDetail.Transaction = MapTransactionSingle(transaction_BankStatementStagingDetail.Transaction,true);
				                }
			    return _transaction_BankStatementStagingDetail;
            }else{
                return null;
            }
		}
		public static List<Transaction_BankStatementStagingDetail> MapTransaction_BankStatementStagingDetailList(List<Transaction_BankStatementStagingDetail> transaction_BankStatementStagingDetailList){
			 List<Transaction_BankStatementStagingDetail> _transaction_BankStatementStagingDetailList = new List<Transaction_BankStatementStagingDetail>();
             if(transaction_BankStatementStagingDetailList !=null){
			     transaction_BankStatementStagingDetailList.ForEach(l=>{
                    _transaction_BankStatementStagingDetailList.Add(MapTransaction_BankStatementStagingDetailSingle(l));
			     });
            }
			 return _transaction_BankStatementStagingDetailList;
		}

        public static List<Transaction_BankStatementStagingDetail> MapTransaction_BankStatementStagingDetailListWithSingleItemOnly(List<Transaction_BankStatementStagingDetail> transaction_BankStatementStagingDetailList){
			 List<Transaction_BankStatementStagingDetail> _transaction_BankStatementStagingDetailList = new List<Transaction_BankStatementStagingDetail>();
			 transaction_BankStatementStagingDetailList.ForEach(l=>{
                _transaction_BankStatementStagingDetailList.Add(MapTransaction_BankStatementStagingDetailSingle(l,true));
			 });
			 return _transaction_BankStatementStagingDetailList;
		}

	


		public static void MapTransaction_MailToSendFromToSingle(Transaction_MailToSend transaction_MailToSendFrom,Transaction_MailToSend transaction_MailToSendTo){
							transaction_MailToSendTo.IdTransaction_MailToSend = transaction_MailToSendFrom.IdTransaction_MailToSend;
							transaction_MailToSendTo.IdTransaction = transaction_MailToSendFrom.IdTransaction;
							transaction_MailToSendTo.IdMailToSend = transaction_MailToSendFrom.IdMailToSend;
							transaction_MailToSendTo.IsDeactivated = transaction_MailToSendFrom.IsDeactivated;
			

		}



		public static Transaction_MailToSend MapTransaction_MailToSendSingle(Transaction_MailToSend transaction_MailToSend,bool singleEntityOnly = false){
            if(transaction_MailToSend !=null){
			Transaction_MailToSend _transaction_MailToSend = new Transaction_MailToSend();
							_transaction_MailToSend.IdTransaction_MailToSend = transaction_MailToSend.IdTransaction_MailToSend;
							_transaction_MailToSend.IdTransaction = transaction_MailToSend.IdTransaction;
							_transaction_MailToSend.IdMailToSend = transaction_MailToSend.IdMailToSend;
							_transaction_MailToSend.IsDeactivated = transaction_MailToSend.IsDeactivated;
			            if(!singleEntityOnly){
			    					    if(transaction_MailToSend.MailToSend !=null)
						    _transaction_MailToSend.MailToSend = MapMailToSendSingle(transaction_MailToSend.MailToSend,true);
				    					    if(transaction_MailToSend.Transaction !=null)
						    _transaction_MailToSend.Transaction = MapTransactionSingle(transaction_MailToSend.Transaction,true);
				                }
			    return _transaction_MailToSend;
            }else{
                return null;
            }
		}
		public static List<Transaction_MailToSend> MapTransaction_MailToSendList(List<Transaction_MailToSend> transaction_MailToSendList){
			 List<Transaction_MailToSend> _transaction_MailToSendList = new List<Transaction_MailToSend>();
             if(transaction_MailToSendList !=null){
			     transaction_MailToSendList.ForEach(l=>{
                    _transaction_MailToSendList.Add(MapTransaction_MailToSendSingle(l));
			     });
            }
			 return _transaction_MailToSendList;
		}

        public static List<Transaction_MailToSend> MapTransaction_MailToSendListWithSingleItemOnly(List<Transaction_MailToSend> transaction_MailToSendList){
			 List<Transaction_MailToSend> _transaction_MailToSendList = new List<Transaction_MailToSend>();
			 transaction_MailToSendList.ForEach(l=>{
                _transaction_MailToSendList.Add(MapTransaction_MailToSendSingle(l,true));
			 });
			 return _transaction_MailToSendList;
		}

	


		public static void MapTransaction_PaymentFromToSingle(Transaction_Payment transaction_PaymentFrom,Transaction_Payment transaction_PaymentTo){
							transaction_PaymentTo.IdTransaction_Payment = transaction_PaymentFrom.IdTransaction_Payment;
							transaction_PaymentTo.IdTransaction = transaction_PaymentFrom.IdTransaction;
							transaction_PaymentTo.IdPayment = transaction_PaymentFrom.IdPayment;
							transaction_PaymentTo.IsDeactivated = transaction_PaymentFrom.IsDeactivated;
			

		}



		public static Transaction_Payment MapTransaction_PaymentSingle(Transaction_Payment transaction_Payment,bool singleEntityOnly = false){
            if(transaction_Payment !=null){
			Transaction_Payment _transaction_Payment = new Transaction_Payment();
							_transaction_Payment.IdTransaction_Payment = transaction_Payment.IdTransaction_Payment;
							_transaction_Payment.IdTransaction = transaction_Payment.IdTransaction;
							_transaction_Payment.IdPayment = transaction_Payment.IdPayment;
							_transaction_Payment.IsDeactivated = transaction_Payment.IsDeactivated;
			            if(!singleEntityOnly){
			    					    if(transaction_Payment.Payment !=null)
						    _transaction_Payment.Payment = MapPaymentSingle(transaction_Payment.Payment,true);
				    					    if(transaction_Payment.Transaction !=null)
						    _transaction_Payment.Transaction = MapTransactionSingle(transaction_Payment.Transaction,true);
				                }
			    return _transaction_Payment;
            }else{
                return null;
            }
		}
		public static List<Transaction_Payment> MapTransaction_PaymentList(List<Transaction_Payment> transaction_PaymentList){
			 List<Transaction_Payment> _transaction_PaymentList = new List<Transaction_Payment>();
             if(transaction_PaymentList !=null){
			     transaction_PaymentList.ForEach(l=>{
                    _transaction_PaymentList.Add(MapTransaction_PaymentSingle(l));
			     });
            }
			 return _transaction_PaymentList;
		}

        public static List<Transaction_Payment> MapTransaction_PaymentListWithSingleItemOnly(List<Transaction_Payment> transaction_PaymentList){
			 List<Transaction_Payment> _transaction_PaymentList = new List<Transaction_Payment>();
			 transaction_PaymentList.ForEach(l=>{
                _transaction_PaymentList.Add(MapTransaction_PaymentSingle(l,true));
			 });
			 return _transaction_PaymentList;
		}

	


		public static void MapTransactionAccountFromToSingle(TransactionAccount transactionAccountFrom,TransactionAccount transactionAccountTo){
							transactionAccountTo.IdTransactionAccount = transactionAccountFrom.IdTransactionAccount;
							transactionAccountTo.Description = transactionAccountFrom.Description;
							transactionAccountTo.IsDeactivated = transactionAccountFrom.IsDeactivated;
							transactionAccountTo.IdParentTransactionAccount = transactionAccountFrom.IdParentTransactionAccount;
							transactionAccountTo.IdTransactionAccountType = transactionAccountFrom.IdTransactionAccountType;
							transactionAccountTo.Number = transactionAccountFrom.Number;
							transactionAccountTo.BankNumber = transactionAccountFrom.BankNumber;
			

		}



		public static TransactionAccount MapTransactionAccountSingle(TransactionAccount transactionAccount,bool singleEntityOnly = false){
            if(transactionAccount !=null){
			TransactionAccount _transactionAccount = new TransactionAccount();
							_transactionAccount.IdTransactionAccount = transactionAccount.IdTransactionAccount;
							_transactionAccount.Description = transactionAccount.Description;
							_transactionAccount.IsDeactivated = transactionAccount.IsDeactivated;
							_transactionAccount.IdParentTransactionAccount = transactionAccount.IdParentTransactionAccount;
							_transactionAccount.IdTransactionAccountType = transactionAccount.IdTransactionAccountType;
							_transactionAccount.Number = transactionAccount.Number;
							_transactionAccount.BankNumber = transactionAccount.BankNumber;
			            if(!singleEntityOnly){
			    					    if(transactionAccount.TransactionAccountType !=null)
						    _transactionAccount.TransactionAccountType = MapTransactionAccountTypeSingle(transactionAccount.TransactionAccountType,true);
				                }
			    return _transactionAccount;
            }else{
                return null;
            }
		}
		public static List<TransactionAccount> MapTransactionAccountList(List<TransactionAccount> transactionAccountList){
			 List<TransactionAccount> _transactionAccountList = new List<TransactionAccount>();
             if(transactionAccountList !=null){
			     transactionAccountList.ForEach(l=>{
                    _transactionAccountList.Add(MapTransactionAccountSingle(l));
			     });
            }
			 return _transactionAccountList;
		}

        public static List<TransactionAccount> MapTransactionAccountListWithSingleItemOnly(List<TransactionAccount> transactionAccountList){
			 List<TransactionAccount> _transactionAccountList = new List<TransactionAccount>();
			 transactionAccountList.ForEach(l=>{
                _transactionAccountList.Add(MapTransactionAccountSingle(l,true));
			 });
			 return _transactionAccountList;
		}

	


		public static void MapTransactionAccountTypeFromToSingle(TransactionAccountType transactionAccountTypeFrom,TransactionAccountType transactionAccountTypeTo){
							transactionAccountTypeTo.IdTransactionAccountType = transactionAccountTypeFrom.IdTransactionAccountType;
							transactionAccountTypeTo.IsDeactivated = transactionAccountTypeFrom.IsDeactivated;
							transactionAccountTypeTo.Description = transactionAccountTypeFrom.Description;
			

		}



		public static TransactionAccountType MapTransactionAccountTypeSingle(TransactionAccountType transactionAccountType,bool singleEntityOnly = false){
            if(transactionAccountType !=null){
			TransactionAccountType _transactionAccountType = new TransactionAccountType();
							_transactionAccountType.IdTransactionAccountType = transactionAccountType.IdTransactionAccountType;
							_transactionAccountType.IsDeactivated = transactionAccountType.IsDeactivated;
							_transactionAccountType.Description = transactionAccountType.Description;
			            if(!singleEntityOnly){
			                }
			    return _transactionAccountType;
            }else{
                return null;
            }
		}
		public static List<TransactionAccountType> MapTransactionAccountTypeList(List<TransactionAccountType> transactionAccountTypeList){
			 List<TransactionAccountType> _transactionAccountTypeList = new List<TransactionAccountType>();
             if(transactionAccountTypeList !=null){
			     transactionAccountTypeList.ForEach(l=>{
                    _transactionAccountTypeList.Add(MapTransactionAccountTypeSingle(l));
			     });
            }
			 return _transactionAccountTypeList;
		}

        public static List<TransactionAccountType> MapTransactionAccountTypeListWithSingleItemOnly(List<TransactionAccountType> transactionAccountTypeList){
			 List<TransactionAccountType> _transactionAccountTypeList = new List<TransactionAccountType>();
			 transactionAccountTypeList.ForEach(l=>{
                _transactionAccountTypeList.Add(MapTransactionAccountTypeSingle(l,true));
			 });
			 return _transactionAccountTypeList;
		}

	


		public static void MapTransactionClassFromToSingle(TransactionClass transactionClassFrom,TransactionClass transactionClassTo){
							transactionClassTo.IdTransactionClass = transactionClassFrom.IdTransactionClass;
							transactionClassTo.IsDeactivated = transactionClassFrom.IsDeactivated;
							transactionClassTo.Description = transactionClassFrom.Description;
							transactionClassTo.IdParentTransactionClass = transactionClassFrom.IdParentTransactionClass;
			

		}



		public static TransactionClass MapTransactionClassSingle(TransactionClass transactionClass,bool singleEntityOnly = false){
            if(transactionClass !=null){
			TransactionClass _transactionClass = new TransactionClass();
							_transactionClass.IdTransactionClass = transactionClass.IdTransactionClass;
							_transactionClass.IsDeactivated = transactionClass.IsDeactivated;
							_transactionClass.Description = transactionClass.Description;
							_transactionClass.IdParentTransactionClass = transactionClass.IdParentTransactionClass;
			            if(!singleEntityOnly){
			    					    if(transactionClass.TransactionClass2 !=null)
						    _transactionClass.TransactionClass2 = MapTransactionClassSingle(transactionClass.TransactionClass2,true);
				                }
			    return _transactionClass;
            }else{
                return null;
            }
		}
		public static List<TransactionClass> MapTransactionClassList(List<TransactionClass> transactionClassList){
			 List<TransactionClass> _transactionClassList = new List<TransactionClass>();
             if(transactionClassList !=null){
			     transactionClassList.ForEach(l=>{
                    _transactionClassList.Add(MapTransactionClassSingle(l));
			     });
            }
			 return _transactionClassList;
		}

        public static List<TransactionClass> MapTransactionClassListWithSingleItemOnly(List<TransactionClass> transactionClassList){
			 List<TransactionClass> _transactionClassList = new List<TransactionClass>();
			 transactionClassList.ForEach(l=>{
                _transactionClassList.Add(MapTransactionClassSingle(l,true));
			 });
			 return _transactionClassList;
		}

	


		public static void MapTransactionDetailFromToSingle(TransactionDetail transactionDetailFrom,TransactionDetail transactionDetailTo){
							transactionDetailTo.IdTransactionDetail = transactionDetailFrom.IdTransactionDetail;
							transactionDetailTo.IsDeactivated = transactionDetailFrom.IsDeactivated;
							transactionDetailTo.IdTransaction = transactionDetailFrom.IdTransaction;
							transactionDetailTo.IdProduct = transactionDetailFrom.IdProduct;
							transactionDetailTo.Description = transactionDetailFrom.Description;
							transactionDetailTo.Quantity = transactionDetailFrom.Quantity;
							transactionDetailTo.Rate = transactionDetailFrom.Rate;
							transactionDetailTo.IdTransactionClass = transactionDetailFrom.IdTransactionClass;
							transactionDetailTo.Remarks = transactionDetailFrom.Remarks;
			

		}



		public static TransactionDetail MapTransactionDetailSingle(TransactionDetail transactionDetail,bool singleEntityOnly = false){
            if(transactionDetail !=null){
			TransactionDetail _transactionDetail = new TransactionDetail();
							_transactionDetail.IdTransactionDetail = transactionDetail.IdTransactionDetail;
							_transactionDetail.IsDeactivated = transactionDetail.IsDeactivated;
							_transactionDetail.IdTransaction = transactionDetail.IdTransaction;
							_transactionDetail.IdProduct = transactionDetail.IdProduct;
							_transactionDetail.Description = transactionDetail.Description;
							_transactionDetail.Quantity = transactionDetail.Quantity;
							_transactionDetail.Rate = transactionDetail.Rate;
							_transactionDetail.IdTransactionClass = transactionDetail.IdTransactionClass;
							_transactionDetail.Remarks = transactionDetail.Remarks;
			            if(!singleEntityOnly){
			    					    if(transactionDetail.Product !=null)
						    _transactionDetail.Product = MapProductSingle(transactionDetail.Product,true);
				    					    if(transactionDetail.Transaction !=null)
						    _transactionDetail.Transaction = MapTransactionSingle(transactionDetail.Transaction,true);
				    					    if(transactionDetail.TransactionClass !=null)
						    _transactionDetail.TransactionClass = MapTransactionClassSingle(transactionDetail.TransactionClass,true);
				                }
			    return _transactionDetail;
            }else{
                return null;
            }
		}
		public static List<TransactionDetail> MapTransactionDetailList(List<TransactionDetail> transactionDetailList){
			 List<TransactionDetail> _transactionDetailList = new List<TransactionDetail>();
             if(transactionDetailList !=null){
			     transactionDetailList.ForEach(l=>{
                    _transactionDetailList.Add(MapTransactionDetailSingle(l));
			     });
            }
			 return _transactionDetailList;
		}

        public static List<TransactionDetail> MapTransactionDetailListWithSingleItemOnly(List<TransactionDetail> transactionDetailList){
			 List<TransactionDetail> _transactionDetailList = new List<TransactionDetail>();
			 transactionDetailList.ForEach(l=>{
                _transactionDetailList.Add(MapTransactionDetailSingle(l,true));
			 });
			 return _transactionDetailList;
		}

	


		public static void MapTransactionDetailPresetFromToSingle(TransactionDetailPreset transactionDetailPresetFrom,TransactionDetailPreset transactionDetailPresetTo){
							transactionDetailPresetTo.IdTransactionDetailPreset = transactionDetailPresetFrom.IdTransactionDetailPreset;
							transactionDetailPresetTo.IsDeactivated = transactionDetailPresetFrom.IsDeactivated;
							transactionDetailPresetTo.IdTransactionPreset = transactionDetailPresetFrom.IdTransactionPreset;
							transactionDetailPresetTo.IdProduct = transactionDetailPresetFrom.IdProduct;
							transactionDetailPresetTo.Description = transactionDetailPresetFrom.Description;
							transactionDetailPresetTo.Quantity = transactionDetailPresetFrom.Quantity;
							transactionDetailPresetTo.Rate = transactionDetailPresetFrom.Rate;
							transactionDetailPresetTo.IdTransactionClass = transactionDetailPresetFrom.IdTransactionClass;
			

		}



		public static TransactionDetailPreset MapTransactionDetailPresetSingle(TransactionDetailPreset transactionDetailPreset,bool singleEntityOnly = false){
            if(transactionDetailPreset !=null){
			TransactionDetailPreset _transactionDetailPreset = new TransactionDetailPreset();
							_transactionDetailPreset.IdTransactionDetailPreset = transactionDetailPreset.IdTransactionDetailPreset;
							_transactionDetailPreset.IsDeactivated = transactionDetailPreset.IsDeactivated;
							_transactionDetailPreset.IdTransactionPreset = transactionDetailPreset.IdTransactionPreset;
							_transactionDetailPreset.IdProduct = transactionDetailPreset.IdProduct;
							_transactionDetailPreset.Description = transactionDetailPreset.Description;
							_transactionDetailPreset.Quantity = transactionDetailPreset.Quantity;
							_transactionDetailPreset.Rate = transactionDetailPreset.Rate;
							_transactionDetailPreset.IdTransactionClass = transactionDetailPreset.IdTransactionClass;
			            if(!singleEntityOnly){
			    					    if(transactionDetailPreset.Product !=null)
						    _transactionDetailPreset.Product = MapProductSingle(transactionDetailPreset.Product,true);
				    					    if(transactionDetailPreset.TransactionPreset !=null)
						    _transactionDetailPreset.TransactionPreset = MapTransactionPresetSingle(transactionDetailPreset.TransactionPreset,true);
				    					    if(transactionDetailPreset.TransactionClass !=null)
						    _transactionDetailPreset.TransactionClass = MapTransactionClassSingle(transactionDetailPreset.TransactionClass,true);
				                }
			    return _transactionDetailPreset;
            }else{
                return null;
            }
		}
		public static List<TransactionDetailPreset> MapTransactionDetailPresetList(List<TransactionDetailPreset> transactionDetailPresetList){
			 List<TransactionDetailPreset> _transactionDetailPresetList = new List<TransactionDetailPreset>();
             if(transactionDetailPresetList !=null){
			     transactionDetailPresetList.ForEach(l=>{
                    _transactionDetailPresetList.Add(MapTransactionDetailPresetSingle(l));
			     });
            }
			 return _transactionDetailPresetList;
		}

        public static List<TransactionDetailPreset> MapTransactionDetailPresetListWithSingleItemOnly(List<TransactionDetailPreset> transactionDetailPresetList){
			 List<TransactionDetailPreset> _transactionDetailPresetList = new List<TransactionDetailPreset>();
			 transactionDetailPresetList.ForEach(l=>{
                _transactionDetailPresetList.Add(MapTransactionDetailPresetSingle(l,true));
			 });
			 return _transactionDetailPresetList;
		}

	


		public static void MapTransactionDueFromToSingle(TransactionDue transactionDueFrom,TransactionDue transactionDueTo){
							transactionDueTo.IdTransactionDue = transactionDueFrom.IdTransactionDue;
							transactionDueTo.IdTransaction = transactionDueFrom.IdTransaction;
							transactionDueTo.DueDate = transactionDueFrom.DueDate;
							transactionDueTo.AmountDue = transactionDueFrom.AmountDue;
							transactionDueTo.AmountRemaining = transactionDueFrom.AmountRemaining;
							transactionDueTo.IsDeactivated = transactionDueFrom.IsDeactivated;
			

		}



		public static TransactionDue MapTransactionDueSingle(TransactionDue transactionDue,bool singleEntityOnly = false){
            if(transactionDue !=null){
			TransactionDue _transactionDue = new TransactionDue();
							_transactionDue.IdTransactionDue = transactionDue.IdTransactionDue;
							_transactionDue.IdTransaction = transactionDue.IdTransaction;
							_transactionDue.DueDate = transactionDue.DueDate;
							_transactionDue.AmountDue = transactionDue.AmountDue;
							_transactionDue.AmountRemaining = transactionDue.AmountRemaining;
							_transactionDue.IsDeactivated = transactionDue.IsDeactivated;
			            if(!singleEntityOnly){
			    					    if(transactionDue.Transaction !=null)
						    _transactionDue.Transaction = MapTransactionSingle(transactionDue.Transaction,true);
				                }
			    return _transactionDue;
            }else{
                return null;
            }
		}
		public static List<TransactionDue> MapTransactionDueList(List<TransactionDue> transactionDueList){
			 List<TransactionDue> _transactionDueList = new List<TransactionDue>();
             if(transactionDueList !=null){
			     transactionDueList.ForEach(l=>{
                    _transactionDueList.Add(MapTransactionDueSingle(l));
			     });
            }
			 return _transactionDueList;
		}

        public static List<TransactionDue> MapTransactionDueListWithSingleItemOnly(List<TransactionDue> transactionDueList){
			 List<TransactionDue> _transactionDueList = new List<TransactionDue>();
			 transactionDueList.ForEach(l=>{
                _transactionDueList.Add(MapTransactionDueSingle(l,true));
			 });
			 return _transactionDueList;
		}

	


		public static void MapTransactionDue_TransactionFromToSingle(TransactionDue_Transaction transactionDue_TransactionFrom,TransactionDue_Transaction transactionDue_TransactionTo){
							transactionDue_TransactionTo.IdTransactionDue_Transaction = transactionDue_TransactionFrom.IdTransactionDue_Transaction;
							transactionDue_TransactionTo.IsDeactivated = transactionDue_TransactionFrom.IsDeactivated;
							transactionDue_TransactionTo.IdTransactionDone = transactionDue_TransactionFrom.IdTransactionDone;
							transactionDue_TransactionTo.IdTransactionDue = transactionDue_TransactionFrom.IdTransactionDue;
			

		}



		public static TransactionDue_Transaction MapTransactionDue_TransactionSingle(TransactionDue_Transaction transactionDue_Transaction,bool singleEntityOnly = false){
            if(transactionDue_Transaction !=null){
			TransactionDue_Transaction _transactionDue_Transaction = new TransactionDue_Transaction();
							_transactionDue_Transaction.IdTransactionDue_Transaction = transactionDue_Transaction.IdTransactionDue_Transaction;
							_transactionDue_Transaction.IsDeactivated = transactionDue_Transaction.IsDeactivated;
							_transactionDue_Transaction.IdTransactionDone = transactionDue_Transaction.IdTransactionDone;
							_transactionDue_Transaction.IdTransactionDue = transactionDue_Transaction.IdTransactionDue;
			            if(!singleEntityOnly){
			    					    if(transactionDue_Transaction.TransactionDue !=null)
						    _transactionDue_Transaction.TransactionDue = MapTransactionDueSingle(transactionDue_Transaction.TransactionDue,true);
				    					    if(transactionDue_Transaction.Transaction !=null)
						    _transactionDue_Transaction.Transaction = MapTransactionSingle(transactionDue_Transaction.Transaction,true);
				                }
			    return _transactionDue_Transaction;
            }else{
                return null;
            }
		}
		public static List<TransactionDue_Transaction> MapTransactionDue_TransactionList(List<TransactionDue_Transaction> transactionDue_TransactionList){
			 List<TransactionDue_Transaction> _transactionDue_TransactionList = new List<TransactionDue_Transaction>();
             if(transactionDue_TransactionList !=null){
			     transactionDue_TransactionList.ForEach(l=>{
                    _transactionDue_TransactionList.Add(MapTransactionDue_TransactionSingle(l));
			     });
            }
			 return _transactionDue_TransactionList;
		}

        public static List<TransactionDue_Transaction> MapTransactionDue_TransactionListWithSingleItemOnly(List<TransactionDue_Transaction> transactionDue_TransactionList){
			 List<TransactionDue_Transaction> _transactionDue_TransactionList = new List<TransactionDue_Transaction>();
			 transactionDue_TransactionList.ForEach(l=>{
                _transactionDue_TransactionList.Add(MapTransactionDue_TransactionSingle(l,true));
			 });
			 return _transactionDue_TransactionList;
		}

	


		public static void MapTransactionPresetFromToSingle(TransactionPreset transactionPresetFrom,TransactionPreset transactionPresetTo){
							transactionPresetTo.IdTransactionPreset = transactionPresetFrom.IdTransactionPreset;
							transactionPresetTo.IdTransactionType = transactionPresetFrom.IdTransactionType;
							transactionPresetTo.IsDeactivated = transactionPresetFrom.IsDeactivated;
							transactionPresetTo.IdCustomer = transactionPresetFrom.IdCustomer;
							transactionPresetTo.IdTransactionClass = transactionPresetFrom.IdTransactionClass;
							transactionPresetTo.IdTransactionTemplate = transactionPresetFrom.IdTransactionTemplate;
							transactionPresetTo.IdTransactionAccount = transactionPresetFrom.IdTransactionAccount;
							transactionPresetTo.TotalAmount = transactionPresetFrom.TotalAmount;
			

		}



		public static TransactionPreset MapTransactionPresetSingle(TransactionPreset transactionPreset,bool singleEntityOnly = false){
            if(transactionPreset !=null){
			TransactionPreset _transactionPreset = new TransactionPreset();
							_transactionPreset.IdTransactionPreset = transactionPreset.IdTransactionPreset;
							_transactionPreset.IdTransactionType = transactionPreset.IdTransactionType;
							_transactionPreset.IsDeactivated = transactionPreset.IsDeactivated;
							_transactionPreset.IdCustomer = transactionPreset.IdCustomer;
							_transactionPreset.IdTransactionClass = transactionPreset.IdTransactionClass;
							_transactionPreset.IdTransactionTemplate = transactionPreset.IdTransactionTemplate;
							_transactionPreset.IdTransactionAccount = transactionPreset.IdTransactionAccount;
							_transactionPreset.TotalAmount = transactionPreset.TotalAmount;
			            if(!singleEntityOnly){
			    					    if(transactionPreset.Customer !=null)
						    _transactionPreset.Customer = MapCustomerSingle(transactionPreset.Customer,true);
				    					    if(transactionPreset.TransactionAccount !=null)
						    _transactionPreset.TransactionAccount = MapTransactionAccountSingle(transactionPreset.TransactionAccount,true);
				    					    if(transactionPreset.TransactionClass !=null)
						    _transactionPreset.TransactionClass = MapTransactionClassSingle(transactionPreset.TransactionClass,true);
				    					    if(transactionPreset.TransactionTemplate !=null)
						    _transactionPreset.TransactionTemplate = MapTransactionTemplateSingle(transactionPreset.TransactionTemplate,true);
				    					    if(transactionPreset.TransactionType !=null)
						    _transactionPreset.TransactionType = MapTransactionTypeSingle(transactionPreset.TransactionType,true);
				                }
			    return _transactionPreset;
            }else{
                return null;
            }
		}
		public static List<TransactionPreset> MapTransactionPresetList(List<TransactionPreset> transactionPresetList){
			 List<TransactionPreset> _transactionPresetList = new List<TransactionPreset>();
             if(transactionPresetList !=null){
			     transactionPresetList.ForEach(l=>{
                    _transactionPresetList.Add(MapTransactionPresetSingle(l));
			     });
            }
			 return _transactionPresetList;
		}

        public static List<TransactionPreset> MapTransactionPresetListWithSingleItemOnly(List<TransactionPreset> transactionPresetList){
			 List<TransactionPreset> _transactionPresetList = new List<TransactionPreset>();
			 transactionPresetList.ForEach(l=>{
                _transactionPresetList.Add(MapTransactionPresetSingle(l,true));
			 });
			 return _transactionPresetList;
		}

	


		public static void MapTransactionStateFromToSingle(TransactionState transactionStateFrom,TransactionState transactionStateTo){
							transactionStateTo.IdTransactionState = transactionStateFrom.IdTransactionState;
							transactionStateTo.IsDeactivated = transactionStateFrom.IsDeactivated;
							transactionStateTo.Description = transactionStateFrom.Description;
			

		}



		public static TransactionState MapTransactionStateSingle(TransactionState transactionState,bool singleEntityOnly = false){
            if(transactionState !=null){
			TransactionState _transactionState = new TransactionState();
							_transactionState.IdTransactionState = transactionState.IdTransactionState;
							_transactionState.IsDeactivated = transactionState.IsDeactivated;
							_transactionState.Description = transactionState.Description;
			            if(!singleEntityOnly){
			                }
			    return _transactionState;
            }else{
                return null;
            }
		}
		public static List<TransactionState> MapTransactionStateList(List<TransactionState> transactionStateList){
			 List<TransactionState> _transactionStateList = new List<TransactionState>();
             if(transactionStateList !=null){
			     transactionStateList.ForEach(l=>{
                    _transactionStateList.Add(MapTransactionStateSingle(l));
			     });
            }
			 return _transactionStateList;
		}

        public static List<TransactionState> MapTransactionStateListWithSingleItemOnly(List<TransactionState> transactionStateList){
			 List<TransactionState> _transactionStateList = new List<TransactionState>();
			 transactionStateList.ForEach(l=>{
                _transactionStateList.Add(MapTransactionStateSingle(l,true));
			 });
			 return _transactionStateList;
		}

	


		public static void MapTransactionTemplateFromToSingle(TransactionTemplate transactionTemplateFrom,TransactionTemplate transactionTemplateTo){
							transactionTemplateTo.IdTransactionTemplate = transactionTemplateFrom.IdTransactionTemplate;
							transactionTemplateTo.IsDeactivated = transactionTemplateFrom.IsDeactivated;
							transactionTemplateTo.Description = transactionTemplateFrom.Description;
			

		}



		public static TransactionTemplate MapTransactionTemplateSingle(TransactionTemplate transactionTemplate,bool singleEntityOnly = false){
            if(transactionTemplate !=null){
			TransactionTemplate _transactionTemplate = new TransactionTemplate();
							_transactionTemplate.IdTransactionTemplate = transactionTemplate.IdTransactionTemplate;
							_transactionTemplate.IsDeactivated = transactionTemplate.IsDeactivated;
							_transactionTemplate.Description = transactionTemplate.Description;
			            if(!singleEntityOnly){
			                }
			    return _transactionTemplate;
            }else{
                return null;
            }
		}
		public static List<TransactionTemplate> MapTransactionTemplateList(List<TransactionTemplate> transactionTemplateList){
			 List<TransactionTemplate> _transactionTemplateList = new List<TransactionTemplate>();
             if(transactionTemplateList !=null){
			     transactionTemplateList.ForEach(l=>{
                    _transactionTemplateList.Add(MapTransactionTemplateSingle(l));
			     });
            }
			 return _transactionTemplateList;
		}

        public static List<TransactionTemplate> MapTransactionTemplateListWithSingleItemOnly(List<TransactionTemplate> transactionTemplateList){
			 List<TransactionTemplate> _transactionTemplateList = new List<TransactionTemplate>();
			 transactionTemplateList.ForEach(l=>{
                _transactionTemplateList.Add(MapTransactionTemplateSingle(l,true));
			 });
			 return _transactionTemplateList;
		}

	


		public static void MapTransactionTypeFromToSingle(TransactionType transactionTypeFrom,TransactionType transactionTypeTo){
							transactionTypeTo.IdTransactionType = transactionTypeFrom.IdTransactionType;
							transactionTypeTo.Description = transactionTypeFrom.Description;
							transactionTypeTo.IsDeactivated = transactionTypeFrom.IsDeactivated;
			

		}



		public static TransactionType MapTransactionTypeSingle(TransactionType transactionType,bool singleEntityOnly = false){
            if(transactionType !=null){
			TransactionType _transactionType = new TransactionType();
							_transactionType.IdTransactionType = transactionType.IdTransactionType;
							_transactionType.Description = transactionType.Description;
							_transactionType.IsDeactivated = transactionType.IsDeactivated;
			            if(!singleEntityOnly){
			                }
			    return _transactionType;
            }else{
                return null;
            }
		}
		public static List<TransactionType> MapTransactionTypeList(List<TransactionType> transactionTypeList){
			 List<TransactionType> _transactionTypeList = new List<TransactionType>();
             if(transactionTypeList !=null){
			     transactionTypeList.ForEach(l=>{
                    _transactionTypeList.Add(MapTransactionTypeSingle(l));
			     });
            }
			 return _transactionTypeList;
		}

        public static List<TransactionType> MapTransactionTypeListWithSingleItemOnly(List<TransactionType> transactionTypeList){
			 List<TransactionType> _transactionTypeList = new List<TransactionType>();
			 transactionTypeList.ForEach(l=>{
                _transactionTypeList.Add(MapTransactionTypeSingle(l,true));
			 });
			 return _transactionTypeList;
		}

	


		public static void MapUserFromToSingle(User userFrom,User userTo){
							userTo.IdUser = userFrom.IdUser;
							userTo.Email = userFrom.Email;
							userTo.PasswordHash = userFrom.PasswordHash;
							userTo.SecurityStamp = userFrom.SecurityStamp;
							userTo.PhoneNumber = userFrom.PhoneNumber;
							userTo.LockoutEnabled = userFrom.LockoutEnabled;
							userTo.UserName = userFrom.UserName;
							userTo.IsDeactivated = userFrom.IsDeactivated;
							userTo.IdPerson = userFrom.IdPerson;
							userTo.FirstName = userFrom.FirstName;
							userTo.LastName = userFrom.LastName;
							userTo.NeedPasswordChange = userFrom.NeedPasswordChange;
							userTo.EmailConfirmed = userFrom.EmailConfirmed;
							userTo.PhoneNumberConfirmed = userFrom.PhoneNumberConfirmed;
							userTo.TwoFactorEnabled = userFrom.TwoFactorEnabled;
							userTo.LockoutEndDateUtc = userFrom.LockoutEndDateUtc;
							userTo.AccessFailedCount = userFrom.AccessFailedCount;
			

		}



		public static User MapUserSingle(User user,bool singleEntityOnly = false){
            if(user !=null){
			User _user = new User();
							_user.IdUser = user.IdUser;
							_user.Email = user.Email;
							_user.PasswordHash = user.PasswordHash;
							_user.SecurityStamp = user.SecurityStamp;
							_user.PhoneNumber = user.PhoneNumber;
							_user.LockoutEnabled = user.LockoutEnabled;
							_user.UserName = user.UserName;
							_user.IsDeactivated = user.IsDeactivated;
							_user.IdPerson = user.IdPerson;
							_user.FirstName = user.FirstName;
							_user.LastName = user.LastName;
							_user.NeedPasswordChange = user.NeedPasswordChange;
							_user.EmailConfirmed = user.EmailConfirmed;
							_user.PhoneNumberConfirmed = user.PhoneNumberConfirmed;
							_user.TwoFactorEnabled = user.TwoFactorEnabled;
							_user.LockoutEndDateUtc = user.LockoutEndDateUtc;
							_user.AccessFailedCount = user.AccessFailedCount;
			            if(!singleEntityOnly){
			    					    if(user.Person !=null)
						    _user.Person = MapPersonSingle(user.Person,true);
				                }
			    return _user;
            }else{
                return null;
            }
		}
		public static List<User> MapUserList(List<User> userList){
			 List<User> _userList = new List<User>();
             if(userList !=null){
			     userList.ForEach(l=>{
                    _userList.Add(MapUserSingle(l));
			     });
            }
			 return _userList;
		}

        public static List<User> MapUserListWithSingleItemOnly(List<User> userList){
			 List<User> _userList = new List<User>();
			 userList.ForEach(l=>{
                _userList.Add(MapUserSingle(l,true));
			 });
			 return _userList;
		}

	


		public static void MapUser_PermissionFromToSingle(User_Permission user_PermissionFrom,User_Permission user_PermissionTo){
							user_PermissionTo.IdUser_Permission = user_PermissionFrom.IdUser_Permission;
							user_PermissionTo.IdUser = user_PermissionFrom.IdUser;
							user_PermissionTo.IdPermission = user_PermissionFrom.IdPermission;
							user_PermissionTo.IsDeactivated = user_PermissionFrom.IsDeactivated;
							user_PermissionTo.IsAllowed = user_PermissionFrom.IsAllowed;
			

		}



		public static User_Permission MapUser_PermissionSingle(User_Permission user_Permission,bool singleEntityOnly = false){
            if(user_Permission !=null){
			User_Permission _user_Permission = new User_Permission();
							_user_Permission.IdUser_Permission = user_Permission.IdUser_Permission;
							_user_Permission.IdUser = user_Permission.IdUser;
							_user_Permission.IdPermission = user_Permission.IdPermission;
							_user_Permission.IsDeactivated = user_Permission.IsDeactivated;
							_user_Permission.IsAllowed = user_Permission.IsAllowed;
			            if(!singleEntityOnly){
			    					    if(user_Permission.Permission !=null)
						    _user_Permission.Permission = MapPermissionSingle(user_Permission.Permission,true);
				                }
			    return _user_Permission;
            }else{
                return null;
            }
		}
		public static List<User_Permission> MapUser_PermissionList(List<User_Permission> user_PermissionList){
			 List<User_Permission> _user_PermissionList = new List<User_Permission>();
             if(user_PermissionList !=null){
			     user_PermissionList.ForEach(l=>{
                    _user_PermissionList.Add(MapUser_PermissionSingle(l));
			     });
            }
			 return _user_PermissionList;
		}

        public static List<User_Permission> MapUser_PermissionListWithSingleItemOnly(List<User_Permission> user_PermissionList){
			 List<User_Permission> _user_PermissionList = new List<User_Permission>();
			 user_PermissionList.ForEach(l=>{
                _user_PermissionList.Add(MapUser_PermissionSingle(l,true));
			 });
			 return _user_PermissionList;
		}

	


		public static void MapUser_RoleFromToSingle(User_Role user_RoleFrom,User_Role user_RoleTo){
							user_RoleTo.IdUser = user_RoleFrom.IdUser;
							user_RoleTo.IdRole = user_RoleFrom.IdRole;
							user_RoleTo.IsDeactivated = user_RoleFrom.IsDeactivated;
			

		}



		public static User_Role MapUser_RoleSingle(User_Role user_Role,bool singleEntityOnly = false){
            if(user_Role !=null){
			User_Role _user_Role = new User_Role();
							_user_Role.IdUser = user_Role.IdUser;
							_user_Role.IdRole = user_Role.IdRole;
							_user_Role.IsDeactivated = user_Role.IsDeactivated;
			            if(!singleEntityOnly){
			                }
			    return _user_Role;
            }else{
                return null;
            }
		}
		public static List<User_Role> MapUser_RoleList(List<User_Role> user_RoleList){
			 List<User_Role> _user_RoleList = new List<User_Role>();
             if(user_RoleList !=null){
			     user_RoleList.ForEach(l=>{
                    _user_RoleList.Add(MapUser_RoleSingle(l));
			     });
            }
			 return _user_RoleList;
		}

        public static List<User_Role> MapUser_RoleListWithSingleItemOnly(List<User_Role> user_RoleList){
			 List<User_Role> _user_RoleList = new List<User_Role>();
			 user_RoleList.ForEach(l=>{
                _user_RoleList.Add(MapUser_RoleSingle(l,true));
			 });
			 return _user_RoleList;
		}

	


		public static void MapUser_SocialNetworkFromToSingle(User_SocialNetwork user_SocialNetworkFrom,User_SocialNetwork user_SocialNetworkTo){
							user_SocialNetworkTo.IdUser_SocialNetwork = user_SocialNetworkFrom.IdUser_SocialNetwork;
							user_SocialNetworkTo.IdUser = user_SocialNetworkFrom.IdUser;
							user_SocialNetworkTo.IdSocialNetwork = user_SocialNetworkFrom.IdSocialNetwork;
							user_SocialNetworkTo.IsDeactivated = user_SocialNetworkFrom.IsDeactivated;
							user_SocialNetworkTo.SocialNetworkId = user_SocialNetworkFrom.SocialNetworkId;
			

		}



		public static User_SocialNetwork MapUser_SocialNetworkSingle(User_SocialNetwork user_SocialNetwork,bool singleEntityOnly = false){
            if(user_SocialNetwork !=null){
			User_SocialNetwork _user_SocialNetwork = new User_SocialNetwork();
							_user_SocialNetwork.IdUser_SocialNetwork = user_SocialNetwork.IdUser_SocialNetwork;
							_user_SocialNetwork.IdUser = user_SocialNetwork.IdUser;
							_user_SocialNetwork.IdSocialNetwork = user_SocialNetwork.IdSocialNetwork;
							_user_SocialNetwork.IsDeactivated = user_SocialNetwork.IsDeactivated;
							_user_SocialNetwork.SocialNetworkId = user_SocialNetwork.SocialNetworkId;
			            if(!singleEntityOnly){
			                }
			    return _user_SocialNetwork;
            }else{
                return null;
            }
		}
		public static List<User_SocialNetwork> MapUser_SocialNetworkList(List<User_SocialNetwork> user_SocialNetworkList){
			 List<User_SocialNetwork> _user_SocialNetworkList = new List<User_SocialNetwork>();
             if(user_SocialNetworkList !=null){
			     user_SocialNetworkList.ForEach(l=>{
                    _user_SocialNetworkList.Add(MapUser_SocialNetworkSingle(l));
			     });
            }
			 return _user_SocialNetworkList;
		}

        public static List<User_SocialNetwork> MapUser_SocialNetworkListWithSingleItemOnly(List<User_SocialNetwork> user_SocialNetworkList){
			 List<User_SocialNetwork> _user_SocialNetworkList = new List<User_SocialNetwork>();
			 user_SocialNetworkList.ForEach(l=>{
                _user_SocialNetworkList.Add(MapUser_SocialNetworkSingle(l,true));
			 });
			 return _user_SocialNetworkList;
		}

	


		public static void MapWorkflowFromToSingle(Workflow workflowFrom,Workflow workflowTo){
							workflowTo.IdWorkflow = workflowFrom.IdWorkflow;
							workflowTo.Description = workflowFrom.Description;
							workflowTo.WorkflowCode = workflowFrom.WorkflowCode;
							workflowTo.DisplayOrder = workflowFrom.DisplayOrder;
							workflowTo.IsDeactivated = workflowFrom.IsDeactivated;
			

		}



		public static Workflow MapWorkflowSingle(Workflow workflow,bool singleEntityOnly = false){
            if(workflow !=null){
			Workflow _workflow = new Workflow();
							_workflow.IdWorkflow = workflow.IdWorkflow;
							_workflow.Description = workflow.Description;
							_workflow.WorkflowCode = workflow.WorkflowCode;
							_workflow.DisplayOrder = workflow.DisplayOrder;
							_workflow.IsDeactivated = workflow.IsDeactivated;
			            if(!singleEntityOnly){
			                }
			    return _workflow;
            }else{
                return null;
            }
		}
		public static List<Workflow> MapWorkflowList(List<Workflow> workflowList){
			 List<Workflow> _workflowList = new List<Workflow>();
             if(workflowList !=null){
			     workflowList.ForEach(l=>{
                    _workflowList.Add(MapWorkflowSingle(l));
			     });
            }
			 return _workflowList;
		}

        public static List<Workflow> MapWorkflowListWithSingleItemOnly(List<Workflow> workflowList){
			 List<Workflow> _workflowList = new List<Workflow>();
			 workflowList.ForEach(l=>{
                _workflowList.Add(MapWorkflowSingle(l,true));
			 });
			 return _workflowList;
		}

	


		public static void MapWorkflowActionFromToSingle(WorkflowAction workflowActionFrom,WorkflowAction workflowActionTo){
							workflowActionTo.IdWorkflowAction = workflowActionFrom.IdWorkflowAction;
							workflowActionTo.Description = workflowActionFrom.Description;
							workflowActionTo.WorkflowActionCode = workflowActionFrom.WorkflowActionCode;
							workflowActionTo.DisplayOrder = workflowActionFrom.DisplayOrder;
							workflowActionTo.IdWorkflow = workflowActionFrom.IdWorkflow;
							workflowActionTo.IsDeactivated = workflowActionFrom.IsDeactivated;
			

		}



		public static WorkflowAction MapWorkflowActionSingle(WorkflowAction workflowAction,bool singleEntityOnly = false){
            if(workflowAction !=null){
			WorkflowAction _workflowAction = new WorkflowAction();
							_workflowAction.IdWorkflowAction = workflowAction.IdWorkflowAction;
							_workflowAction.Description = workflowAction.Description;
							_workflowAction.WorkflowActionCode = workflowAction.WorkflowActionCode;
							_workflowAction.DisplayOrder = workflowAction.DisplayOrder;
							_workflowAction.IdWorkflow = workflowAction.IdWorkflow;
							_workflowAction.IsDeactivated = workflowAction.IsDeactivated;
			            if(!singleEntityOnly){
			    					    if(workflowAction.Workflow !=null)
						    _workflowAction.Workflow = MapWorkflowSingle(workflowAction.Workflow,true);
				                }
			    return _workflowAction;
            }else{
                return null;
            }
		}
		public static List<WorkflowAction> MapWorkflowActionList(List<WorkflowAction> workflowActionList){
			 List<WorkflowAction> _workflowActionList = new List<WorkflowAction>();
             if(workflowActionList !=null){
			     workflowActionList.ForEach(l=>{
                    _workflowActionList.Add(MapWorkflowActionSingle(l));
			     });
            }
			 return _workflowActionList;
		}

        public static List<WorkflowAction> MapWorkflowActionListWithSingleItemOnly(List<WorkflowAction> workflowActionList){
			 List<WorkflowAction> _workflowActionList = new List<WorkflowAction>();
			 workflowActionList.ForEach(l=>{
                _workflowActionList.Add(MapWorkflowActionSingle(l,true));
			 });
			 return _workflowActionList;
		}

	


		public static void MapWorkflowRoleFromToSingle(WorkflowRole workflowRoleFrom,WorkflowRole workflowRoleTo){
							workflowRoleTo.IdWorkflowRole = workflowRoleFrom.IdWorkflowRole;
							workflowRoleTo.Description = workflowRoleFrom.Description;
							workflowRoleTo.WorkflowRoleCode = workflowRoleFrom.WorkflowRoleCode;
							workflowRoleTo.DisplayOrder = workflowRoleFrom.DisplayOrder;
							workflowRoleTo.IdWorkflow = workflowRoleFrom.IdWorkflow;
							workflowRoleTo.IsDeactivated = workflowRoleFrom.IsDeactivated;
			

		}



		public static WorkflowRole MapWorkflowRoleSingle(WorkflowRole workflowRole,bool singleEntityOnly = false){
            if(workflowRole !=null){
			WorkflowRole _workflowRole = new WorkflowRole();
							_workflowRole.IdWorkflowRole = workflowRole.IdWorkflowRole;
							_workflowRole.Description = workflowRole.Description;
							_workflowRole.WorkflowRoleCode = workflowRole.WorkflowRoleCode;
							_workflowRole.DisplayOrder = workflowRole.DisplayOrder;
							_workflowRole.IdWorkflow = workflowRole.IdWorkflow;
							_workflowRole.IsDeactivated = workflowRole.IsDeactivated;
			            if(!singleEntityOnly){
			    					    if(workflowRole.Workflow !=null)
						    _workflowRole.Workflow = MapWorkflowSingle(workflowRole.Workflow,true);
				                }
			    return _workflowRole;
            }else{
                return null;
            }
		}
		public static List<WorkflowRole> MapWorkflowRoleList(List<WorkflowRole> workflowRoleList){
			 List<WorkflowRole> _workflowRoleList = new List<WorkflowRole>();
             if(workflowRoleList !=null){
			     workflowRoleList.ForEach(l=>{
                    _workflowRoleList.Add(MapWorkflowRoleSingle(l));
			     });
            }
			 return _workflowRoleList;
		}

        public static List<WorkflowRole> MapWorkflowRoleListWithSingleItemOnly(List<WorkflowRole> workflowRoleList){
			 List<WorkflowRole> _workflowRoleList = new List<WorkflowRole>();
			 workflowRoleList.ForEach(l=>{
                _workflowRoleList.Add(MapWorkflowRoleSingle(l,true));
			 });
			 return _workflowRoleList;
		}

	


		public static void MapWorkflowStateFromToSingle(WorkflowState workflowStateFrom,WorkflowState workflowStateTo){
							workflowStateTo.IdWorkflowState = workflowStateFrom.IdWorkflowState;
							workflowStateTo.Description = workflowStateFrom.Description;
							workflowStateTo.WorkflowStateCode = workflowStateFrom.WorkflowStateCode;
							workflowStateTo.DisplayOrder = workflowStateFrom.DisplayOrder;
							workflowStateTo.IdWorkflow = workflowStateFrom.IdWorkflow;
							workflowStateTo.IsDeactivated = workflowStateFrom.IsDeactivated;
			

		}



		public static WorkflowState MapWorkflowStateSingle(WorkflowState workflowState,bool singleEntityOnly = false){
            if(workflowState !=null){
			WorkflowState _workflowState = new WorkflowState();
							_workflowState.IdWorkflowState = workflowState.IdWorkflowState;
							_workflowState.Description = workflowState.Description;
							_workflowState.WorkflowStateCode = workflowState.WorkflowStateCode;
							_workflowState.DisplayOrder = workflowState.DisplayOrder;
							_workflowState.IdWorkflow = workflowState.IdWorkflow;
							_workflowState.IsDeactivated = workflowState.IsDeactivated;
			            if(!singleEntityOnly){
			    					    if(workflowState.Workflow !=null)
						    _workflowState.Workflow = MapWorkflowSingle(workflowState.Workflow,true);
				                }
			    return _workflowState;
            }else{
                return null;
            }
		}
		public static List<WorkflowState> MapWorkflowStateList(List<WorkflowState> workflowStateList){
			 List<WorkflowState> _workflowStateList = new List<WorkflowState>();
             if(workflowStateList !=null){
			     workflowStateList.ForEach(l=>{
                    _workflowStateList.Add(MapWorkflowStateSingle(l));
			     });
            }
			 return _workflowStateList;
		}

        public static List<WorkflowState> MapWorkflowStateListWithSingleItemOnly(List<WorkflowState> workflowStateList){
			 List<WorkflowState> _workflowStateList = new List<WorkflowState>();
			 workflowStateList.ForEach(l=>{
                _workflowStateList.Add(MapWorkflowStateSingle(l,true));
			 });
			 return _workflowStateList;
		}

	


		public static void MapWorkflowTransitionFromToSingle(WorkflowTransition workflowTransitionFrom,WorkflowTransition workflowTransitionTo){
							workflowTransitionTo.IdWorkflowTransition = workflowTransitionFrom.IdWorkflowTransition;
							workflowTransitionTo.IdWorkflowStateInitial = workflowTransitionFrom.IdWorkflowStateInitial;
							workflowTransitionTo.IdWorkflowAction = workflowTransitionFrom.IdWorkflowAction;
							workflowTransitionTo.IdWorkflowStateFinal = workflowTransitionFrom.IdWorkflowStateFinal;
							workflowTransitionTo.IdWorkflowRole = workflowTransitionFrom.IdWorkflowRole;
							workflowTransitionTo.IsDeactivated = workflowTransitionFrom.IsDeactivated;
			

		}



		public static WorkflowTransition MapWorkflowTransitionSingle(WorkflowTransition workflowTransition,bool singleEntityOnly = false){
            if(workflowTransition !=null){
			WorkflowTransition _workflowTransition = new WorkflowTransition();
							_workflowTransition.IdWorkflowTransition = workflowTransition.IdWorkflowTransition;
							_workflowTransition.IdWorkflowStateInitial = workflowTransition.IdWorkflowStateInitial;
							_workflowTransition.IdWorkflowAction = workflowTransition.IdWorkflowAction;
							_workflowTransition.IdWorkflowStateFinal = workflowTransition.IdWorkflowStateFinal;
							_workflowTransition.IdWorkflowRole = workflowTransition.IdWorkflowRole;
							_workflowTransition.IsDeactivated = workflowTransition.IsDeactivated;
			            if(!singleEntityOnly){
			    					    if(workflowTransition.WorkflowAction !=null)
						    _workflowTransition.WorkflowAction = MapWorkflowActionSingle(workflowTransition.WorkflowAction,true);
				    					    if(workflowTransition.WorkflowRole !=null)
						    _workflowTransition.WorkflowRole = MapWorkflowRoleSingle(workflowTransition.WorkflowRole,true);
				    					    if(workflowTransition.WorkflowState !=null)
						    _workflowTransition.WorkflowState = MapWorkflowStateSingle(workflowTransition.WorkflowState,true);
				    					    if(workflowTransition.WorkflowState1 !=null)
						    _workflowTransition.WorkflowState1 = MapWorkflowStateSingle(workflowTransition.WorkflowState1,true);
				                }
			    return _workflowTransition;
            }else{
                return null;
            }
		}
		public static List<WorkflowTransition> MapWorkflowTransitionList(List<WorkflowTransition> workflowTransitionList){
			 List<WorkflowTransition> _workflowTransitionList = new List<WorkflowTransition>();
             if(workflowTransitionList !=null){
			     workflowTransitionList.ForEach(l=>{
                    _workflowTransitionList.Add(MapWorkflowTransitionSingle(l));
			     });
            }
			 return _workflowTransitionList;
		}

        public static List<WorkflowTransition> MapWorkflowTransitionListWithSingleItemOnly(List<WorkflowTransition> workflowTransitionList){
			 List<WorkflowTransition> _workflowTransitionList = new List<WorkflowTransition>();
			 workflowTransitionList.ForEach(l=>{
                _workflowTransitionList.Add(MapWorkflowTransitionSingle(l,true));
			 });
			 return _workflowTransitionList;
		}

	


		public static void MapWorkflowTransitionOnExecuteFromToSingle(WorkflowTransitionOnExecute workflowTransitionOnExecuteFrom,WorkflowTransitionOnExecute workflowTransitionOnExecuteTo){
							workflowTransitionOnExecuteTo.IdWorkflowTransitionOnExecute = workflowTransitionOnExecuteFrom.IdWorkflowTransitionOnExecute;
							workflowTransitionOnExecuteTo.Action = workflowTransitionOnExecuteFrom.Action;
							workflowTransitionOnExecuteTo.IdWorkflowTransition = workflowTransitionOnExecuteFrom.IdWorkflowTransition;
							workflowTransitionOnExecuteTo.JsonContent = workflowTransitionOnExecuteFrom.JsonContent;
							workflowTransitionOnExecuteTo.IsDeactivated = workflowTransitionOnExecuteFrom.IsDeactivated;
			

		}



		public static WorkflowTransitionOnExecute MapWorkflowTransitionOnExecuteSingle(WorkflowTransitionOnExecute workflowTransitionOnExecute,bool singleEntityOnly = false){
            if(workflowTransitionOnExecute !=null){
			WorkflowTransitionOnExecute _workflowTransitionOnExecute = new WorkflowTransitionOnExecute();
							_workflowTransitionOnExecute.IdWorkflowTransitionOnExecute = workflowTransitionOnExecute.IdWorkflowTransitionOnExecute;
							_workflowTransitionOnExecute.Action = workflowTransitionOnExecute.Action;
							_workflowTransitionOnExecute.IdWorkflowTransition = workflowTransitionOnExecute.IdWorkflowTransition;
							_workflowTransitionOnExecute.JsonContent = workflowTransitionOnExecute.JsonContent;
							_workflowTransitionOnExecute.IsDeactivated = workflowTransitionOnExecute.IsDeactivated;
			            if(!singleEntityOnly){
			    					    if(workflowTransitionOnExecute.WorkflowTransition !=null)
						    _workflowTransitionOnExecute.WorkflowTransition = MapWorkflowTransitionSingle(workflowTransitionOnExecute.WorkflowTransition,true);
				                }
			    return _workflowTransitionOnExecute;
            }else{
                return null;
            }
		}
		public static List<WorkflowTransitionOnExecute> MapWorkflowTransitionOnExecuteList(List<WorkflowTransitionOnExecute> workflowTransitionOnExecuteList){
			 List<WorkflowTransitionOnExecute> _workflowTransitionOnExecuteList = new List<WorkflowTransitionOnExecute>();
             if(workflowTransitionOnExecuteList !=null){
			     workflowTransitionOnExecuteList.ForEach(l=>{
                    _workflowTransitionOnExecuteList.Add(MapWorkflowTransitionOnExecuteSingle(l));
			     });
            }
			 return _workflowTransitionOnExecuteList;
		}

        public static List<WorkflowTransitionOnExecute> MapWorkflowTransitionOnExecuteListWithSingleItemOnly(List<WorkflowTransitionOnExecute> workflowTransitionOnExecuteList){
			 List<WorkflowTransitionOnExecute> _workflowTransitionOnExecuteList = new List<WorkflowTransitionOnExecute>();
			 workflowTransitionOnExecuteList.ForEach(l=>{
                _workflowTransitionOnExecuteList.Add(MapWorkflowTransitionOnExecuteSingle(l,true));
			 });
			 return _workflowTransitionOnExecuteList;
		}

}
}
	