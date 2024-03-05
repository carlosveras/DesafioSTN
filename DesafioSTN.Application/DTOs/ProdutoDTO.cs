using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesafioSTN.Application.DTOs
{
    public class ProdutoDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do produto é obrigatório")]
        [MinLength(3)]
        [MaxLength(60)]
        [DisplayName("Nome Produto")]
        public string NomeProduto { get;  set; }

        [Required(ErrorMessage = "O valor é obrigatório")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DataType(DataType.Currency)]
        [DisplayName("Valor")]
        [Range(0, double.MaxValue, ErrorMessage = "O valor deve ser maior ou igual a 0")]
        public decimal Valor { get;  set; } = 0;
    }
}
