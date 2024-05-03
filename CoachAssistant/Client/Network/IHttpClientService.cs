namespace CoachAssistant.Client.Network
{
    public interface IHttpClientService
    {
        Task<T> GetAsync<T>(string url);

        Task PostAsync<T>(string url, T data);

        Task<TResult> PostAsync<TData, TResult>(string url, TData data);

        Task PutAsync<T>(string url, T data);

        Task DeleteAsync(string url);
    }
}
