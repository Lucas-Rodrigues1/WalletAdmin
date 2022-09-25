using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WalletAdmin.Controllers
{
    public class CadastroController : Controller
    {
        // GET: CadastroController
        public ActionResult Cadastro()
        {
            return View();
        }
    }
}
