using System.Collections.Generic;
using System.Threading.Tasks;

namespace WalletAdmin.Repositorio
{
    public interface IRepositoryPessoa<T>
    {
        Task Add(T item);
        Task Remove(long pes_codigo);
        Task Update(T item);
        Task<T> FindByID(long pes_codigo);
        IEnumerable<T> FindAll();
    }

}
