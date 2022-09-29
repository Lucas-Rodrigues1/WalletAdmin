using System.Collections.Generic;
using System.Threading.Tasks;

namespace WalletAdmin.Repositorio
{
    public interface IRepository<T>
    {
        Task Add(T item);
        Task Remove(int id);
        Task Update(T item);
        Task<T> FindByID(int pes_codigo);
        IEnumerable<T> FindAll();
    }

}
