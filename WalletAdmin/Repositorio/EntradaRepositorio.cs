using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using NHibernate;
using WalletAdmin.Entidades;

namespace WalletAdmin.Repositorio
{
    public class EntradaRepositorio : IRepositoyEntrada<Tabela_Movimento_Entrada>
    {
        private ISession _session;
        public EntradaRepositorio(ISession session) => _session = session;
        public async Task Add(Tabela_Movimento_Entrada item)
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

        public IEnumerable<Tabela_Movimento_Entrada> FindAll() => _session.Query<Tabela_Movimento_Entrada>().ToList();

        public async Task<Tabela_Movimento_Entrada> FindByID(int id) => await _session.GetAsync<Tabela_Movimento_Entrada>(id);

        public async Task Remove(int id)
        {
            ITransaction transaction = null;
            try
            {
                transaction = _session.BeginTransaction();
                var item = await _session.GetAsync<Tabela_Movimento_Entrada>(id);
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

        public async Task Update(Tabela_Movimento_Entrada item)
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
