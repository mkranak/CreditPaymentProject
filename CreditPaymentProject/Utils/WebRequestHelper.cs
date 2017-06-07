using System.IO;
using System.Net;

namespace CreditPaymentProject.Utils
{
    public class WebRequestHelper
    {
        private string Uri;
        private const string baseUri = "https://sandbox.payfabric.com/V2/rest/api/wallet/";

        public WebRequestHelper(string action)
        {
            Uri = baseUri + action;
        }

        public string Post(string jsonRequest)
        {
            byte[] data = System.Text.Encoding.UTF8.GetBytes(jsonRequest);
            HttpWebRequest httpWebRequest = WebRequest.Create(Uri) as HttpWebRequest;
            httpWebRequest = WebRequest.Create(Uri) as HttpWebRequest;
            httpWebRequest.ContentType = "application/json; charset=utf-8";
            httpWebRequest.Headers["authorization"] = new Token().Create();
            httpWebRequest.Method = "POST";
            httpWebRequest.ContentLength = data.Length;
            Stream stream = httpWebRequest.GetRequestStream();
            stream.Write(data, 0, data.Length);
            stream.Close();
            HttpWebResponse httpWebResponse = httpWebRequest.GetResponse() as HttpWebResponse;
            Stream responseStream = httpWebResponse.GetResponseStream();
            StreamReader streamReader = new StreamReader(responseStream);
            string jsonResponse = streamReader.ReadToEnd();
            streamReader.Close();
            responseStream.Close();
            httpWebRequest.Abort();
            httpWebResponse.Close();

            return jsonResponse;
        }

    }
}
