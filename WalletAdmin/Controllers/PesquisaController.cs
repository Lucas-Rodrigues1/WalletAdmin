using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalletAdmin.Entidades;
using WalletAdmin.Repositorio;

namespace WalletAdmin.Controllers
{
    public class PesquisaController : Controller
    {
        private readonly IEmail _email;
        private readonly IConfiguration config;
        private readonly PessoasRepositorio pessoasrepositorio;
        public PesquisaController(NHibernate.ISession session, IEmail email)
        {
            pessoasrepositorio = new PessoasRepositorio(session);
            _email = email;
        }
        public ActionResult PesquisaCliente()
        {
            return View(pessoasrepositorio.FindAll().ToList());
        }
        public async Task<ActionResult> EditarPessoa(int? pes_codigo)
        {
            if (pes_codigo == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            Tabela_Pessoas tabela_pessoas = await pessoasrepositorio.FindByID(pes_codigo.Value);
            if (tabela_pessoas == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            return View(tabela_pessoas);
        }
        [HttpPost, ActionName("EditarPessoa")]
        public async Task<ActionResult> SalvarPessoa(Tabela_Pessoas tabela_pessoas)
        {
            try
            {
                if (tabela_pessoas.PES_SALDO < tabela_pessoas.PES_LIMITE)
                {
                    _email.Enviar(tabela_pessoas.PES_EMAIL, "teste", "teste");
                }

                await pessoasrepositorio.Update(tabela_pessoas);
                return RedirectToAction("PesquisaCliente");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return View(tabela_pessoas);

        }
        public async Task<ActionResult> DeletarPessoa(int? pes_codigo)
        {
            if (pes_codigo == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            Tabela_Pessoas tabela_pessoas = await pessoasrepositorio.FindByID(pes_codigo.Value);
            if (tabela_pessoas == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            return View(tabela_pessoas);
        }
        [HttpPost, ActionName("DeletarPessoa")]
        public async Task<ActionResult> DeletarPessoaConfirmado(int pes_codigo)
        {
            await pessoasrepositorio.Remove(pes_codigo);
            return RedirectToAction("PesquisaCliente");
        }
    }
}

