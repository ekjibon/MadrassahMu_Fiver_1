using Subscription.Business.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Subscription.Business.WorkflowTransitionAction;

namespace Subscription.Service.MEFLoader
{
    public class WorkflowTransitionActionInitializer
    {
        [ImportMany(typeof(IWorkflowTransitionActionLookup))]
        public IEnumerable<Lazy<IWorkflowTransitionActionLookup, IWorkflowTransitionActionMetaData>> actions; //Lazy import ensures components are loaded only when required

        private CompositionContainer _container;

        public WorkflowTransitionActionInitializer(string dllPath)
        {
            var catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new DirectoryCatalog(dllPath)); //Locations to look for parts. If your export is in a an external dll, you need to use directory catalog as well 
            _container = new CompositionContainer(catalog);
            _container.ComposeParts(this); //Compose the imports and exports

        }
    }
}
