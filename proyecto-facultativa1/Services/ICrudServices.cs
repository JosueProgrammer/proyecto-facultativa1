namespace proyecto_facultativa1.Services
{
    public interface ICrudServices<T,TI,TU>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task<T> Add(TI product);
        Task<T> Update(int id, TU product);
        Task<T> Delete(int id);
    }
}
