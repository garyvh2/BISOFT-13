using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Cliente.Lib.Requester
{
    public class Request
    {
        private HttpClient httpClient;
        private HttpRequestMessage Req;
        private HttpResponseMessage Res;
        public RequestParams _requestParams { get; set; } = new RequestParams();

        public Request(RequestParams requestParams)
        {
            this._requestParams = requestParams;
            // >> Inicializar el cliente
            this.httpClient = new HttpClient();
            this.Req = new HttpRequestMessage();
            this.Res = new HttpResponseMessage();
            // >> Establecer el URL
            httpClient.BaseAddress = new Uri(this._requestParams.Url);
            // >> Vaciar el Header
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public void Run<T>(Action<RequestReponse<T>> callback)
        {
            // >> Fill Method
            this.Req.Method = this._requestParams.Method;

            // >> Fill Headers
            this._requestParams.Headers.ForEach(header =>
            {
                this.Req.Headers.Add(header.key, header.value);
            });

            // >> Fill body
            if (this._requestParams.Method != HttpMethod.Get)
            {
                this.Req.Content = new StringContent(JsonConvert.SerializeObject(this._requestParams.Body), Encoding.UTF8, "application/json");
            }

            // >> Store Repsonse
            this.Res = httpClient.SendAsync(this.Req).GetAwaiter().GetResult();
            // >> Process As String
            var stringRes = Res.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            // >> Convert JSON to Api Reponse
            var ApiData = JsonConvert.DeserializeObject<RequestReponse<T>>(stringRes);


            // >> Convert reponse Data to Generic Type
            callback(ApiData);
        }
    }
}
