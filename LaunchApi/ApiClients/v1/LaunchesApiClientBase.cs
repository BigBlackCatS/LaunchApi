using Newtonsoft.Json;
using System.Text;

namespace LaunchApi.ApiClients.v1
{
    public abstract class LaunchesApiClientBase
    {
        private readonly HttpClient _httpClient;

        protected LaunchesApiClientBase(
            HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        protected async Task<HttpResponseMessage> SendGetRequest(string url, CancellationToken cancellationToken = default)
        {
            var response = await _httpClient.GetAsync(url, cancellationToken);
            return response;
        }

        protected async Task<HttpResponseMessage> SendPostRequest<THttpRequest>(THttpRequest request, string url, CancellationToken cancellationToken = default)
        {
            var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(url, content, cancellationToken);

            return response;
        }
    }
}
