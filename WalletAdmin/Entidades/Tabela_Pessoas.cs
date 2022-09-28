using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WalletAdmin.Entidades
{
    public class Tabela_Pessoas
    {
        public virtual int PES_CODIGO { get; set; }
        public virtual string PES_NOME { get; set; }
        public virtual string PES_EMAIL { get; set; }
        public virtual decimal PES_SALARIO { get; set; }
        public virtual decimal PES_LIMITE { get; set; }
        public virtual decimal PES_MINIMO { get; set; }
        public virtual decimal PES_SALDO { get; set; }
    }
}
