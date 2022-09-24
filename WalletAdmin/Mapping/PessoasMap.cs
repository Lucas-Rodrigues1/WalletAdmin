﻿using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalletAdmin.Entidades;
using NHibernate;
using NHibernate.Mapping.ByCode;

namespace WalletAdmin.Mapping
{
    public class PessoasMap : ClassMapping<Tabela_Pessoas>
    {

        public PessoasMap()
        {
            Id(x => x.PES_CODIGO, x =>
              {
                  x.Generator(Generators.Increment);
                  x.Type(NHibernateUtil.Int64);
                  x.Column("PES_CODIGO");
              });

            Property(b => b.PES_NOME, x =>
            {
                x.Length(50);
                x.Type(NHibernateUtil.String);
                x.NotNullable(true);
            });
            Property(b => b.PES_EMAIL, x =>
            {
                x.Length(30);
                x.Type(NHibernateUtil.String);
                x.NotNullable(true);
            });
            Property(b => b.PES_SALARIO, x =>
            {
                x.Type(NHibernateUtil.Decimal);
            });
            Property(b => b.PES_MINIMO, x =>
            {
                x.Type(NHibernateUtil.Decimal);
            }); 
            Property(b => b.PES_SALDO, x =>
            {
                x.Type(NHibernateUtil.Decimal);
            });
        }

    }
}
