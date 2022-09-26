using Microsoft.AspNetCore.Mvc;
using NHibernate;
using System.Linq;
using System.Threading.Tasks;
using WalletAdmin.Entidades;
using WalletAdmin.Repositorio;

namespace WalletAdmin.Controllers
{
    public class CadastroController : Controller
    {
        private readonly UsuariosRepositorio usuariosRepositorio;

        public CadastroController(NHibernate.ISession session) => usuariosRepositorio = new UsuariosRepositorio(session);

        // GET: CadastroController
        public ActionResult Cadastro()
        {
            return View();
        }


        // POST: CadastroController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Cadastro([Bind("Id,Usuario,Email,Senha")] Tabela_Usuarios tabela_Usuarios)
        {
            if (ModelState.IsValid)
            {
                await usuariosRepositorio.Add(tabela_Usuarios);
                return RedirectToAction("Index","Login");
            }

            return View(tabela_Usuarios);
        }
    }
    }
