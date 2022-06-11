using CoreWeb.Business.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Subscription.Business;
using Subscription.Business.Common;
using Subscription.Business.Custom;
using Subscription.Business.Dto;
using Subscription.Business.Enums;
using Subscription.Business.WorkflowTransitionAction;
using Subscription.Service.MEFLoader;

namespace Subscription.Service
{
    public partial class WorkflowService : BaseService
    {

        public void InitiateWorkflowTransitionAction(long idWorkflowTransition, string jsonContent)
        {
            new Thread(() =>
            {
                OnWorkflowTransitionExecuted(idWorkflowTransition, jsonContent);
            }).Start();

        }
        public WorkflowTransitionActionMetaDataReturn OnWorkflowTransitionExecuted<T>(long idWorkflowTransition, T parameterToPass)
        {
            string dllPath = ServiceFactory.Instance.DocumentService.GetMefDllPathRaw();
            WorkflowTransitionOnExecute workflowTransitionOnExecute = ServiceFactory.Instance.WorkflowTransitionOnExecuteService
                .GetWorkflowTransitionOnExecuteCustomRaw(w => w.IdWorkflowTransition == idWorkflowTransition && w.IsDeactivated != true);
            if (workflowTransitionOnExecute != null)
            {
                var workflowTransitionActionInitializer = new WorkflowTransitionActionInitializer(dllPath).actions.Where(cm =>
                   cm.Metadata.ActionName == workflowTransitionOnExecute.Action).FirstOrDefault();
                if (workflowTransitionActionInitializer != null)
                {
                    WorkflowTransitionActionMetaDataReturn workflowTransitionActionMetaDataReturn = workflowTransitionActionInitializer.Value.ExecuteAction<T>(parameterToPass);
                    return workflowTransitionActionMetaDataReturn;
                }
            }

            throw new BusinessLayerException(String.Format("{0} {1}", "No Workflow action executor found for transition id ", idWorkflowTransition));
        }

        public List<WorkflowTransition> GetNextPossibleWorkflowTransitions(long idWorkflowState, long idWorkflowRole)
        {
            List<string> includes = new List<string>() {
                WorkflowTransitionDatabaseReferences.WORKFLOWACTION
            };
            return ServiceFactory.Instance.WorkflowTransitionService.GetWorkflowTransitionCustomListRaw(property => property.IdWorkflowStateInitial == idWorkflowState && property.IdWorkflowRole == idWorkflowRole && property.IsDeactivated != true, includes).EntityList;
        }

        public WorkflowTransition GetNextPossibleWorkflowTransition(long? idWorkflowStateInitial, long idWorkflowAction, long idWorkflowRole)
        {
            List<string> includes = new List<string>()
            {
                WorkflowTransitionDatabaseReferences.WORKFLOWACTION,
                String.Format("{0}.{1}",WorkflowTransitionDatabaseReferences.WORKFLOWACTION,WorkflowActionDatabaseReferences.WORKFLOW),
                String.Format("{0}.{1}.{2}",WorkflowTransitionDatabaseReferences.WORKFLOWACTION,WorkflowActionDatabaseReferences.WORKFLOW,WorkflowDatabaseReferences.REQUESTTYPES)
            };

            return ServiceFactory.Instance.WorkflowTransitionService.GetWorkflowTransitionCustomRaw(property => property.IdWorkflowStateInitial == idWorkflowStateInitial
            && property.IdWorkflowAction == idWorkflowRole
            && property.IdWorkflowRole == idWorkflowRole
            && property.IsDeactivated != true, includes);
        }

        public BusinessResponse<WorkflowTransitionActionMetaDataReturn> WorkflowTransitionFromExternal(ExecuteExternalTransitionDto executeExternalTransitionDto)
        {
            BusinessResponse<WorkflowTransitionActionMetaDataReturn> response = new BusinessResponse<WorkflowTransitionActionMetaDataReturn>();
            try
            {
                response.Result = WorkflowTransitionFromExternalRaw(executeExternalTransitionDto);
            }
            catch (Exception ex)
            {
                response.Exception = new BusinessLayerException(ex.Message, ex);
            }

            return response;
        }

        internal WorkflowTransitionActionMetaDataReturn WorkflowTransitionFromExternalRaw(ExecuteExternalTransitionDto executeExternalTransitionDto)
        {
            WorkflowTransitionActionMetaDataReturn workflowTransitionActionMetaDataReturn = null;


            return workflowTransitionActionMetaDataReturn;
        }

        internal void CheckIfWorflowActionExecutionIsValid(long? idWorkflowStateCurrent, WorkflowTransition workflowTransition)
        {
            //check for expiration
            if (idWorkflowStateCurrent == null || idWorkflowStateCurrent != workflowTransition.IdWorkflowStateInitial)
            {
                throw new Exception("Action already taken on request");
            }

        }
    }
}
