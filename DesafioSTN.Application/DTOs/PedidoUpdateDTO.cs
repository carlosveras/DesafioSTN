using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DesafioSTN.Application.DTOs
{
    public class PedidoUpdateDTO
    {
        [Required(ErrorMessage = "O id é obrigatório")]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do cliente é obrigatório")]
        [MinLength(3)]
        [MaxLength(60)]
        [DisplayName("Nome Cliente")]
        public string NomeCliente { get;  set; }

        [Required(ErrorMessage = "O e-mail do cliente é obrigatório")]
        [MinLength(3)]
        [MaxLength(60)]
        [DisplayName("Email cliente")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string EmailCliente { get;  set; }

        [Required(ErrorMessage = "O campo Pago é obrigatório.")]
        public bool Pago { get;  set; }

        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DataType(DataType.Currency)]
        [DisplayName("Valor")]
        public decimal ValorTotal { get; set; } = 0;
    }
}
