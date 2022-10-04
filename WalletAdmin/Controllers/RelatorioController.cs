using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WalletAdmin.Controllers
{
    public class RelatorioController : Controller
    {
        public IActionResult Relatorio()
        {
            return View();
        }
    }
}
