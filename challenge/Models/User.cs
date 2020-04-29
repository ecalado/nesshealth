using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Challenge.Models;

namespace challenge.Models
{
    public class User

    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O Nome é obrigatório.")]
        [StringLength(100, ErrorMessage = "O tamanho máximo é 100.")]
        public string Name { get; set; }

        [ValidCPFAttribute(true)]
        [Required(ErrorMessage = "O CPF é obrigatório.")]
        [StringLength(11, ErrorMessage = "Preencha o CPF apenas com números")]
        public string CPF { get; set; }

        [ValidPhoneNumberAttribute(true)]
        [Required(ErrorMessage = "O Número do Telefone é obrigatório.")]
        [StringLength(20, ErrorMessage = "O tamanho máximo para o Número de Telefone é 20.")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
    }
}
