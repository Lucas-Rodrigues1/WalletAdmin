namespace WalletAdmin.Entidades
{
    public class Tabela_Usuarios
    {
        public virtual int  Id { get; set; }
        public virtual string Usuario { get; set; }
        public virtual string Email { get; set; }
        public virtual string Senha { get; set; }
    }
}

