using DesafioSTN.Domain.Validation;
using System.Collections.Generic;

namespace DesafioSTN.Domain.Entities
{
    public sealed class Produto : BaseEntity
    {
        public Produto(string nomeProduto, decimal valor)
        {
            DomainExceptionValidation.When(valor < 0, "Valor invalido!");
            ValidateDomain(nomeProduto);
            
            Valor = valor;
        }

        public string NomeProduto { get; private set; }
        public decimal Valor { get; private set; }

        private void ValidateDomain(string nomeProduto)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(nomeProduto), "Descricao invalida!");

            DomainExceptionValidation.When(nomeProduto.Length < 3, "Descricao invalida!");

            NomeProduto = nomeProduto;
        }


    }
}
