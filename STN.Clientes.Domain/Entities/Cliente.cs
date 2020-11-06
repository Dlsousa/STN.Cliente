using System;
using System.Collections.Generic;
using System.Text;

namespace STN.Clientes.Domain.Entities
{
    public class Cliente : Entity
    {
        public string Nome { get; set; }

        public string Estado { get; set; }

        public string Cpf { get; set; }
    }
}
