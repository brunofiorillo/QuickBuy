using System.Collections.Generic;
using System.Linq;

namespace QuickBuy.Dominio.Entidade
{
    public abstract class Entidade
    {
        private List<string> _mensagensValidacao { get; set; }
        private List<string> mensagemValidacao 
        {
            get { return _mensagensValidacao ?? (_mensagensValidacao = new List<string>()); }
            /// <summary>
            /// o get quer dizer q é uma propiedade somente de leitura e o ?? ve se ele esta vazio e antes de retoranr ele devolve uma mensagem de validacao msm se for vazia
            /// </summary>
        }
       

        protected void LimparMensagensValidacao()
        {
            mensagemValidacao.Clear();
        }

        /// <summary>
        /// USO PARA LIMPAR AS MENSAGEMS DE CRITICA .
        /// </summary>
       
        

        protected void AdicionarCritica(string mensagem)
        {
            mensagemValidacao.Add(mensagem);
        }

        /// <summary>
        /// USO PARA ADICIONAR CRITICA NOS METODOS VALIDATE DAS CLASSES COMO USUARIO, PEDIDO, PRODUTO E ETC.
        /// </summary>

        public abstract void Validate();
        protected bool EhValido
        {
            get { return !mensagemValidacao.Any(); }
            ///
            /// qualquer entidade q herdar da classe abstract Entidade vai ser considerada como uma instancia validade se n tiver nenhuma mensagem de validacao.  
            /// leitura do bool: se nao tiver nenhuma msg de validacao a classe sera considerada valida
            ///
        }
    }
 }

