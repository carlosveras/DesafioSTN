using DesafioSTN.Domain.Validation;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesafioSTN.Domain.Entities
{
    public sealed class ItemPedido : BaseEntity
    {
        public ItemPedido()
        {
            
        }

        public ItemPedido(int quantidade, int idProduto)
        {
            DomainExceptionValidation.When(quantidade < 0, "Quantidade invalida!");
            DomainExceptionValidation.When(idProduto < 0, "Produto invalido!");

            Quantidade = quantidade;
            IdProduto = idProduto;
        }

        public int Quantidade { get; private set; }

        public int IdPedido { get; private set; }

        public Pedido Pedido { get; private set; }

        public int IdProduto { get; private set; }

        public Produto Produto { get; set; }
    }
}
