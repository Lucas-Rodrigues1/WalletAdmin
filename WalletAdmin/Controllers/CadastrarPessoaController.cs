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

        public CadastrarPessoaController(NHibernate.ISession session) => pessoasRepositorio = new PessoasRepositorio(session);
        // GET: CadastrarPessoaController
        public ActionResult CadastrarPessoa()
        {
            return View();
        }

        

        // POST: CadastrarPessoaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CadastrarPessoa(Tabela_Pessoas tabela_pessoas)
        {

            if (ModelState.IsValid)
            {
                await pessoasRepositorio.Add(tabela_pessoas);
                return View(tabela_pessoas);
            }

            return View(tabela_pessoas);
        }

       
        // GET: CadastrarPessoaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CadastrarPessoaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
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
