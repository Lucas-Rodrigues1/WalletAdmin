using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

using NHibernate;
using WalletAdmin.Entidades;

namespace WalletAdmin.Repositorio
{
    public class UsuariosRepositorio: IRepository<Tabela_Usuarios>
    {

        private ISession _session;
        public UsuariosRepositorio(ISession session) => _session = session;
        public async Task Add(Tabela_Usuarios item)
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

        public IEnumerable<Tabela_Usuarios> FindAll() => _session.Query<Tabela_Usuarios>().ToList();

        internal void Add(Microsoft.AspNetCore.Http.IFormCollection collection)
        {
            throw new NotImplementedException();
        }

        public async Task<Tabela_Usuarios> FindByID(long id) => await _session.GetAsync<Tabela_Usuarios>(id);

        public async Task Remove(long id)
        {
            ITransaction transaction = null;
            try
            {
                transaction = _session.BeginTransaction();
                var item = await _session.GetAsync<Tabela_Usuarios>(id);
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

        public async Task Update(Tabela_Usuarios item)
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
