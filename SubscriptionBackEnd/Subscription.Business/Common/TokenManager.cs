using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Subscription.Business.Common
{
    public class TokenManager
    {
        public static string getToken(long idUser, string username, string password)
        {
            var now = Math.Round((DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds) + (360 * 360);
            var payload = new Dictionary<string, object>()
            {
                    {"IdUser",idUser},
                    {"Username",username },
                    {"Password",password},
                    {"exp",now}

            };
            string secretKey = System.Configuration.ConfigurationManager.AppSettings["secretKey"];
            string token = JsonWebToken.Encode(payload, secretKey, JwtHashAlgorithm.HS256);
            return token;
        }

        public static String verifyToken(string token)
        {
            string secretKey = System.Configuration.ConfigurationManager.AppSettings["secretKey"];
            String jsonPayload;
            try
            {
                jsonPayload = JsonWebToken.Decode(token, secretKey);
            }
            catch (Exception e)
            {
                throw new SignatureVerificationException("Invalid Token");
            }
            if (jsonPayload != null)
                return jsonPayload;
            else
                throw new SignatureVerificationException("Invalid Token");
        }

        public static Object verifyToken(HttpRequest request)
        {
            IEnumerable<string> headerValues = request.Headers.GetValues("Authorization");
            if (headerValues == null)
                throw new SignatureVerificationException("Token not found");
            var auth = headerValues.FirstOrDefault();
            return verifyToken(auth);
        }
    }
}
