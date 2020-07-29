using QuickBuy.Dominio.ObjetoDeValor;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QuickBuy.Dominio.Entidade
{
    public class Pedido : Entidade
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
        public DateTime DataPrevisaoEntrega { get; set; }
        public string CEP { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string EnderecoCompleto { get; set; }
        public int NumeroEndereco { get; set; }

        public int FormaPagamentoId { get; set; }
        public virtual FormaPagamento FormaPagamento { get; set; }

        /// <summary>
        ///  Pedido teve ter pelo mneos um intem de pedido ou muitos itens de pedidos
        /// </summary>
        public virtual ICollection<ItemPedido> ItensPedido { get; set; }

        public override void Validate()
        {
            LimparMensagensValidacao();

            if (!ItensPedido.Any())
                AdicionarCritica("Critica - Pedido não pode sem intem de pedido");
            
            ///Se não existe nenhuma informaçao do produto, ou seja nem um intem em intens de produto(ItensPedido), apresentar a critica.
            ///
            
            
              
            if (string.IsNullOrEmpty(CEP))
                AdicionarCritica("Critica - CEP deve esta preenchido");

            ///

        }
        
    }
}
