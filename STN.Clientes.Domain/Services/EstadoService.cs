using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace STN.Clientes.Domain.Services
{
    public static class EstadoService
    {
        public static bool IsValid(string estado)
        {
            if (!string.IsNullOrEmpty(estado))
            {
                return new string[]
                {
                "AC", "AL", "AP", "AM", "BA",
                "CE", "DF", "ES", "GO", "MA",
                "MT", "MS", "MG", "PA", "PB",
                "PR", "PE", "PI", "RJ", "RN",
                "RS", "RO", "RR", "SC", "SP",
                "SE", "TO"
                }.Contains(estado.ToUpper());
            }

            return false;
        }
    }
}
