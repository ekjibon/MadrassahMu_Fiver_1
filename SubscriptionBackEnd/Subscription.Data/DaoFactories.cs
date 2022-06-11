using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscription.Data
{
    public class DaoFactories
    {
        private static IDaoFactory instance;
        public static IDaoFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    throw new Exception("Dao Factories should first be implemented");
                }
                return instance;
            }
            private set
            {
                instance = value;
            }
        }

        public static IDaoFactory GetFactory(string dataProvider, Dictionary<string, object> parameters = null)
        {
            // return the requested DaoFactory
            IDaoFactory factory;
            switch (dataProvider.ToLower())
            {
                //case "ado.net": return new AdoNet.DaoFactory(parameters);
                case "entityframework":
                    factory = new DaoFactory();
                    break;
                default:
                    factory = new DaoFactory();
                    break;
            }

            DaoFactories.instance = factory;
            return factory;
        }
    }
}
