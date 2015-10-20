using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

public enum HttpVerb
{
    GET,
    POST,
    PUT,
    DELETE
}

namespace SnaFoo.Models
{
    class RestClient
    {
        public string EndPoint { get; set; }
        public HttpVerb Method { get; set; }
        public string ContentType { get; set; }
        public string PostData { get; set; }

        public RestClient()
        {
            EndPoint = "";
            Method = HttpVerb.GET;
            PostData = "";
        }
        public RestClient(string endpoint)
        {
            EndPoint = endpoint;
            Method = HttpVerb.GET;
            PostData = "";
        }
        public RestClient(string endpoint, HttpVerb method)
        {
            EndPoint = endpoint;
            Method = method;
            PostData = "";
        }

        public RestClient(string endpoint, HttpVerb method, string postData)
        {
            EndPoint = endpoint;
            Method = method;
            PostData = postData;
        }

        public string MakeSnackRequest(string parameters)
        {
            var request = (HttpWebRequest)WebRequest.Create(EndPoint + parameters);
            using (request as IDisposable)
            {
                request.Method = Method.ToString();
                request.Timeout = 1000 * 60 * 5;

                // ApiKey for Authorization
                request.Headers.Add("Authorization", "ApiKey 6467771f-cd58-49dd-96b1-ca5b5218be38");
                request.ContentType = "application/json";
                request.Accept = "application/json";
                request.KeepAlive = true;

                if (!string.IsNullOrEmpty(PostData) && Method == HttpVerb.POST)
                {
                    using (var writeStream = new StreamWriter(request.GetRequestStream()))
                    {
                        writeStream.Write(PostData);
                        writeStream.Flush();
                    }
                }

                // Send Request 
                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    var responseValue = string.Empty;

                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        var message = String.Format("Request failed. Received HTTP {0}", response.StatusCode);
                        throw new ApplicationException(message);
                    }

                    // grab the response
                    using (var responseStream = response.GetResponseStream())
                    {
                        if (responseStream != null)
                            using (var reader = new StreamReader(responseStream))
                            {
                                responseValue = reader.ReadToEnd();
                            }
                    }
                    return responseValue;
                }
            }
        }
    }
}
