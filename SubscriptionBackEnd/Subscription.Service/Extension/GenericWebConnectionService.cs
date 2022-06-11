using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Subscription.Service
{
    public partial class GenericWebConnectionService : BaseService
    {
        public delegate void ResponseReceivedEventHandler(string response);
        public event ResponseReceivedEventHandler ResponseReceivedEvent;

        public async Task<string> PostFormDataStreamRequest<T>(string url, T data)
        {
            return await LoadDataStreamRequest<T>(url, "POST", data);
        }

        public async Task<string> GetFormDataStreamRequest<T>(string url, T data)
        {
            return await LoadDataStreamRequest<T>(url, "GET", data);
        }

        private async Task<string> LoadDataStreamRequest<T>(string url, string requestType, T data)
        {
            var req = WebRequest.Create(url);
            req.Method = requestType;
            req.Timeout = 5000;
            req.ContentType = "application/x-www-form-urlencoded";

            string postData = "";
            foreach (var property in data.GetType().GetProperties())
            {
                postData += HttpUtility.UrlEncode(property.Name) + "="
                      + HttpUtility.UrlEncode(property.GetValue(data).ToString()) + "&";
            }

            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            req.ContentLength = byteArray.Length;
            Stream dataStream = req.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();
            string lastData = null;

            await Task.Run(() =>
            {
                using (var response = req.GetResponse())
                {
                    using (var reader = new StreamReader(response.GetResponseStream()))
                    {
                        char[] buffer = new char[1024];
                        int read = 0;
                        do
                        {
                            read = reader.Read(buffer, 0, buffer.Length);
                            string dataRead = new String(buffer, 0, read);
                            ResponseReceivedEvent?.Invoke(dataRead);
                            lastData = dataRead;
                            //Console.WriteLine("{0}: Read {1} bytes", i++, read);
                        } while (!reader.EndOfStream);
                    }
                }
            });
            return lastData;
        }
    }
}
