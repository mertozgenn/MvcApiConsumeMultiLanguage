using RestSharp.Authenticators;
using RestSharp;
using Newtonsoft.Json;
using System.Globalization;

namespace UI.Utils.Restsharp
{
    public static class RestsharpHelper
    {
        public static T Get<T>(string baseUrl, string apiEndPoint, string token = null)
        {
            var client = new RestClient(baseUrl);
            if (token != null)
            {
                client.Authenticator = new JwtAuthenticator(token);
            }
            var request = new RestRequest(apiEndPoint, Method.Get);
            request.AddHeader("Accept-Language", Thread.CurrentThread.CurrentUICulture.Name);
            var restResponse = client.Execute(request);
            if (!restResponse.IsSuccessful)
            {
                throw new Exception(restResponse.StatusCode + " - " + restResponse.ErrorMessage + " - " + restResponse.ErrorException.Message);
            }
            var response = JsonConvert.DeserializeObject<T>(restResponse.Content);
            return response;
        }

        public static T Post<T>(string baseUrl, string apiEndPoint, object objectToPost, string token = null)
        {
            var client = new RestClient(baseUrl);
            if (token != null)
            {
                client.Authenticator = new JwtAuthenticator(token);
            }
            var request = new RestRequest(apiEndPoint, Method.Post);
            request.AddHeader("Content-Type", "application/json");
            request.AddBody(objectToPost);
            request.AddHeader("Accept-Language", Thread.CurrentThread.CurrentUICulture.Name);
            var restResponse = client.Execute(request);
            if (!restResponse.IsSuccessful)
            {
                throw new Exception(restResponse.StatusCode + " - " + restResponse.ErrorMessage + " - " + restResponse.ErrorException.Message);
            }
            var response = JsonConvert.DeserializeObject<T>(restResponse.Content);
            return response;
        }
    }
}
