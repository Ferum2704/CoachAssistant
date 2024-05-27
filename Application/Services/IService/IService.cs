namespace Application.Services.IService
{
    public interface IService<T, TResult>
    {
        Task<TResult> Add(T model);

        Task<TResult> Edit(Guid id, T model);

        Task<TResult> Get(Guid id);

        Task<IReadOnlyCollection<TResult>> GetAll();

        Task Delete(Guid id);

        Task DeleteBulk(IReadOnlyCollection<Guid> IDs);
    }
}
