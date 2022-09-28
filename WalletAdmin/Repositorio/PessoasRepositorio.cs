using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using NHibernate;
using WalletAdmin.Entidades;
namespace WalletAdmin.Repositorio
{
    public class PessoasRepositorio: IRepository<Tabela_Pessoas>
    {
        private ISession _session;
        public PessoasRepositorio(ISession session) => _session = session;
        public async Task Add(Tabela_Pessoas item)
        {
            ITransaction transaction = null;
            try
            {
                transaction = _session.BeginTransaction();
                await _session.SaveAsync(item);
                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                await transaction?.RollbackAsync();
            }
            finally
            {
                transaction?.Dispose();
            }
        }

        public IEnumerable<Tabela_Pessoas> FindAll() => _session.Query<Tabela_Pessoas>().ToList();

        public async Task<Tabela_Pessoas> FindByID(long id) => await _session.GetAsync<Tabela_Pessoas>(id);

        public async Task Remove(long id)
        {
            ITransaction transaction = null;
            try
            {
                transaction = _session.BeginTransaction();
                var item = await _session.GetAsync<Tabela_Pessoas>(id);
                await _session.DeleteAsync(item);
                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                await transaction?.RollbackAsync();
            }
            finally
            {
                transaction?.Dispose();
            }
        }

        public async Task Update(Tabela_Pessoas item)
        {
            ITransaction transaction = null;
            try
            {
                transaction = _session.BeginTransaction();
                await _session.UpdateAsync(item);
                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                await transaction?.RollbackAsync();
            }
            finally
            {
                transaction?.Dispose();
            }
        }
    }
}
