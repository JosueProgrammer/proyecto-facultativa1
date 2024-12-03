namespace proyecto_facultativa1.Services
{
    public interface ICrudServices<T,TI,TU>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task<T> Add(TI entity);
        Task<T> Update(int id, TU entity);
        Task<T> Delete(int id);
    }
}
