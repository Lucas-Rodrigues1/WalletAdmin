
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WalletAdmin.Database;
using NHibernate;

using Microsoft.Extensions.DependencyInjection;
using WalletAdmin.Repositorio;
using System.Data.SqlClient;

namespace WalletAdmin.Controllers
{
    public class LoginController : Controller
    {
        private readonly UsuariosRepositorio usuariosRepositorio;

        public LoginController(NHibernate.ISession session) => usuariosRepositorio = new UsuariosRepositorio(session);

        public ActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Index(string Usuario, string Senha)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=DESKTOP-29AA0TP\SQLEXPRESS;Initial Catalog=WalletAdmin;Integrated Security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();

            string login = "SELECT * FROM Tabela_Usuarios WHERE USUARIO='" + Usuario + "' AND SENHA='" + Senha + "'";
            cmd = new SqlCommand(login, con);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read() == true)
            {
                con.Close();
                return RedirectToAction("Index","Home");

            }
            else
            {
                con.Close();
                return View();
            }
        }
    }

}

