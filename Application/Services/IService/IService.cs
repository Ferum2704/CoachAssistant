namespace Application.Services.IService
{
    public interface IService<T, TResult>
    {
        Task<TResult> Add(T model);

        Task Edit(Guid id, T model);

        Task<TResult> Get(Guid id);

        Task Delete(Guid id);
    }
}
