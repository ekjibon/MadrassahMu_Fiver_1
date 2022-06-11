using CoreWeb.Business.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Subscription.Business;
using Subscription.Business.Common;
using Subscription.Business.Dto;
using Subscription.Business.Enums;
using Subscription.Business.ReturnType;
using Subscription.Business.ReturnType.HostedDomain;
using Subscription.Data;

namespace Subscription.Service
{
    public partial class SignalRService : BaseService
    {
        public async Task<BusinessResponse<GetListOfSignalRConnectionReturnType>> GetListOfSignalRConnection(GetListOfSignalRConnectionDto getListOfSignalRConnectionDto)
        {
            BusinessResponse<GetListOfSignalRConnectionReturnType> response = new BusinessResponse<GetListOfSignalRConnectionReturnType>();

            try
            {
                response.Result = await GetListOfSignalRConnectionRaw(getListOfSignalRConnectionDto);
            }
            catch (Exception ex)
            {
                response.Result = null;
                response.Exception = new BusinessLayerException(ex.Message, ex);
            }

            return response;
        }

        internal async Task<GetListOfSignalRConnectionReturnType> GetListOfSignalRConnectionRaw(GetListOfSignalRConnectionDto getListOfSignalRConnectionDto)
        {
            string signalRUrl = ServiceFactory.Instance.GlobalVariableService.SignalRUrl;

            var cookieContainer = new CookieContainer();
            using (var handler = new HttpClientHandler() { CookieContainer = cookieContainer })
            using (var client = new HttpClient(handler))
            {
                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

                HttpContent content = null;

                string json = JsonConvert.SerializeObject(getListOfSignalRConnectionDto);
                content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage result = await client.PostAsync(string.Format("{0}/api/Signalrconnection/GetAllConnection",signalRUrl), content);

                string resultContent = await result.Content.ReadAsStringAsync();

                GetListOfSignalRConnectionReturnType getListOfSignalRConnectionReturnType = JsonConvert.DeserializeObject<GetListOfSignalRConnectionReturnType>(resultContent);

                return getListOfSignalRConnectionReturnType;
            }
        }
    }
}
