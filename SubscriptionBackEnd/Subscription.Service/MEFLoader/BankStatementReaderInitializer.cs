using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Subscription.Business.BankStatementReader;
using Subscription.Business.Utils;

namespace Subscription.Service.MEFLoader
{
    public class BankStatementReaderInitializer<T>
    {
        [ImportMany(typeof(IBankStatementReader<>))]
        public IEnumerable<Lazy<IBankStatementReader<T>, IBankStatementReaderMetadata>> reports; //Lazy import ensures components are loaded only when required

        private CompositionContainer _container;

        public BankStatementReaderInitializer()
        {
            var catalog = new AggregateCatalog();
            var projectPath = ConfigAccess.GetConfigByName("filesFolder");
            var rateSheetDLL = ConfigAccess.GetConfigByName("reportDLL");
            var path = Path.Combine(projectPath, rateSheetDLL);
            catalog.Catalogs.Add(new DirectoryCatalog(path)); //Locations to look for parts. If your export is in a an external dll, you need to use directory catalog as well 
            _container = new CompositionContainer(catalog);
            _container.ComposeParts(this); //Compose the imports and exports

        }
    }
}
