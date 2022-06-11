using CoreWeb.Business.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Subscription.Business;

namespace Subscription.Service
{
    public partial class MailServerSettingService : BaseService
    {
        public BusinessResponse<MailServerSetting> GetDefaultMailServerSetting()
        {
            BusinessResponse<MailServerSetting> response = new BusinessResponse<MailServerSetting>();
            try
            {
                response.Result = GetDefaultMailServerSettingRaw();
            }
            catch (Exception ex)
            {
                response.Exception = new BusinessLayerException(ex.Message, ex);
            }

            return response;
        }
        internal MailServerSetting GetDefaultMailServerSettingRaw()
        {
            return daoFactory.MailServerSettingDao.GetDefaultMailServerSetting();
        }
    }
}
