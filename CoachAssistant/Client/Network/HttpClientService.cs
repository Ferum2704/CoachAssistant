
using System.Net.Http.Json;

namespace CoachAssistant.Client.Network
{
    public class HttpClientService : IHttpClientService
    {
        private readonly HttpClient _httpClient;

        public HttpClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<T> GetAsync<T>(string url)
        {
            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<T>();
            }
            else
            {
                // throw new Exception($"Error: {response.StatusCode} - {await response.Content.ReadAsStringAsync()}");
                return default;
            }
        }

        public async Task PostAsync<T>(string url, T data) => await _httpClient.PostAsJsonAsync(url, data);

        public async Task PutAsync<T>(string url, T data) => await _httpClient.PutAsJsonAsync(url, data);

        public async Task DeleteAsync(string url) => await _httpClient.DeleteAsync(url);

        public async Task<TResult> PostAsync<TData, TResult>(string url, TData data)
        {
            var response = await _httpClient.PostAsJsonAsync(url, data);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<TResult>();
            }
            else
            {
                // throw new Exception($"Error: {response.StatusCode} - {await response.Content.ReadAsStringAsync()}");

                return default;
            }
        }
    }
}
