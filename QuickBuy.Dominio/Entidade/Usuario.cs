using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace QuickBuy.Dominio.Entidade
{
    public class Usuario : Entidade
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }

        /// <summary>
        /// O usuario pode ter nenhum ou muitos pedidos
        /// </summary>
        public ICollection<Pedido> Pedidos { get; set; }

        public override void Validate()
        {
            if (string.IsNullOrEmpty(Email))
                AdicionarCritica("Email não foi confirmado");

            if(string.IsNullOrEmpty(Senha))
                AdicionarCritica("Senha não foi confirmada");


        }
    }
}
