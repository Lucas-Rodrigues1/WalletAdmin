using System.Collections.Generic;
using System.Threading.Tasks;

namespace WalletAdmin.Repositorio
{
    public interface IRepositoryPessoa<T>
    {
        Task Add(T item);
        Task Remove(int pes_codigo);
        Task Update(T item);
        Task<T> FindByaID(int pes_codigo);
        IEnumerable<T> FindAll();
    }

}
