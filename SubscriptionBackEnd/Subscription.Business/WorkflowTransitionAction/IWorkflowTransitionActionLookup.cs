using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscription.Business.WorkflowTransitionAction
{
    public interface IWorkflowTransitionActionLookup
    {
        WorkflowTransitionActionMetaDataReturn ExecuteAction<T>(T parameterToPass);
    }
}