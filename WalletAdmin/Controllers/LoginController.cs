
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WalletAdmin.Database;
using NHibernate;
using WalletAdmin.Database;
using Microsoft.Extensions.DependencyInjection;

namespace WalletAdmin.Controllers
{
    public class LoginController : Controller
    {
       
        public ActionResult Index()
        {
            return View();
        }
    }
}