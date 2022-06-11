using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscription.Business.Utils
{
    public class ConfigAccess
    {
        public static String GetConfigByName(string configName)
        {
            return ConfigurationManager.AppSettings[configName];
        }
    }
}
