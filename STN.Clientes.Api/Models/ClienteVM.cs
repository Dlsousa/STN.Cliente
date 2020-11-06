using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace STN.Clientes.Api.Models
{
    public class ClienteVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Cpf { get; set; }
    }
}
