using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalletAdmin.Repositorio;

namespace WalletAdmin.Controllers
{
    public class PesquisaController : Controller
    {
        private readonly PessoasRepositorio pessoasrepositorio;

        public PesquisaController(NHibernate.ISession session) => pessoasrepositorio = new PessoasRepositorio(session);

        // GET: CadastroPessoas
        public ActionResult PesquisaCliente()
        {
            return View(pessoasrepositorio.FindAll().ToList());
        }
    }
}
