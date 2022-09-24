using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WalletAdmin.Entidades
{
    public class Tabela_Movimento_Entrada
    {
        public virtual int ENT_CODIGO { get; set; }
        public virtual int PES_CODIGO { get; set; }
        public virtual DateTime ENT_DATA { get; set; }
        public virtual string ENT_DESCRICAO { get; set; }
        public virtual double ENT_VALOR { get; set; }
    }
}
