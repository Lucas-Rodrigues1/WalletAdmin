using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalletAdmin.Entidades;
using NHibernate;
using NHibernate.Mapping.ByCode;

namespace WalletAdmin.Mapping
{
    public class MovimentoEntradaMap : ClassMapping<Tabela_Movimento_Entrada>
    {
        public MovimentoEntradaMap()
        {
            Id(x => x.ENT_CODIGO, x =>
            {
                x.Generator(Generators.Increment);
                x.Type(NHibernateUtil.Int64);
                x.Column("ENT_CODIGO");
            });

            Property(b => b.PES_CODIGO, x =>
            {
                x.Type(NHibernateUtil.Int64);
                x.NotNullable(true);
            });
            Property(b => b.ENT_DATA, x =>
            {
               
                x.Type(NHibernateUtil.DateTime);
                x.NotNullable(true);
            });
            Property(b => b.ENT_DESCRICAO, x =>
            {
                x.Length(50);
                x.Type(NHibernateUtil.String);
            });
            Property(b => b.ENT_VALOR, x =>
            {
                x.Type(NHibernateUtil.Double);
            });
            Table("Tabela_Movimento_Entrada");
        }

    }
}
