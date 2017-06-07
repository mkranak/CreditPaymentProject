using System;
using System.IO;
using System.Net;
using System.Runtime.Serialization;

namespace CreditPaymentProject.Utils
{
    public class Token
    {
        public string Create()
        {
            try
            {
                var url = "https://sandbox.payfabric.com/V2/rest/api/token/create";

                HttpWebRequest httpWebRequest = WebRequest.Create(url) as HttpWebRequest;
                httpWebRequest.ContentType = "application/json; charset=utf-8";
                httpWebRequest.Method = "GET";
                httpWebRequest.Headers["authorization"] = "7d91e774-853e-474b-bd44-745ee57a8027|testing4cc0un7";

                HttpWebResponse httpWebResponse = httpWebRequest.GetResponse() as HttpWebResponse;
                Stream responseStream = httpWebResponse.GetResponseStream();
                StreamReader streamReader = new StreamReader(responseStream);
                string result = streamReader.ReadToEnd();

                streamReader.Close();
                responseStream.Close();
                httpWebRequest.Abort();
                httpWebResponse.Close();

                TokenResponse obj = JsonHelper.JsonDeserialize<TokenResponse>(result);

                return obj.Token;
            }
            catch (WebException e)
            {
                throw new WebException(e.ToString());
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }
    }

    [DataContract]
    public class TokenResponse
    {
        [DataMember]
        public string Token { get; set; }

    }
}
