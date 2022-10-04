using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalletAdmin.Entidades;
using WalletAdmin.Repositorio;
namespace WalletAdmin.Controllers
{
    public class CadastrarPessoaController : Controller
    {


        private readonly PessoasRepositorio pessoasRepositorio;
        private readonly EntradaRepositorio entradaRepositorio;
        public CadastrarPessoaController(NHibernate.ISession session)
        {
            entradaRepositorio = new EntradaRepositorio(session);
            pessoasRepositorio = new PessoasRepositorio(session);
        }
        public ActionResult CadastrarPessoa()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> CadastrarPessoa(Tabela_Pessoas tabela_pessoas, Tabela_Movimento_Entrada tabela_movimento_entrada)
        {

            if (ModelState.IsValid)
            {
                tabela_movimento_entrada.ENT_DATA = DateTime.Now.Day;
                await pessoasRepositorio.Add(tabela_pessoas);
                await entradaRepositorio.Add(tabela_movimento_entrada);
            }
                return View(tabela_pessoas);
        }
        public ActionResult Delete(int id)  
        {
            return View();
        }
        [HttpPost]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
