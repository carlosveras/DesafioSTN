using DesafioSTN.Domain.Validation;
using System;
using System.Collections.Generic;

namespace DesafioSTN.Domain.Entities
{
    public sealed class Pedido : BaseEntity
    {
        public Pedido(string nomeCliente, string emailCliente, bool pago)
        {
            ValidateDomain(nomeCliente, emailCliente);
            Pago = pago;
        }
        
        public string NomeCliente { get; private set; }
        public string EmailCliente { get; private set; }
        public DateTime DataCriacao { get; private set; } = DateTime.Now;
        public bool Pago { get; private set; }
        public List<ItemPedido> ItensPedido { get; set; }

        public void Update(string nomeCliente, string emailCliente, bool pago)
        {
            ValidateDomain(nomeCliente, emailCliente);
            Pago = pago;
        }

        private void ValidateDomain(string nomeCliente, string emailCliente)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(nomeCliente), "Nome Cliente invalido!");

            DomainExceptionValidation.When(nomeCliente.Length < 3, "Nome Cliente invalido!");

            DomainExceptionValidation.When(string.IsNullOrEmpty(emailCliente), "Email invalido!");

            DomainExceptionValidation.When(emailCliente.Length < 3, "Email invalido!");

            NomeCliente = nomeCliente;

            EmailCliente = emailCliente;
        }
    }
}
