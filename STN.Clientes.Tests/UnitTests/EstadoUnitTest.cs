using STN.Clientes.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace STN.Clientes.Tests.UnitTests
{
    public class EstadoUnitTest
    {
        [Fact]
        public void IsValid()
        {
            var Ufs = new List<string>
            {
                "AC", "AL", "AP", "AM", "BA",
                "CE", "DF", "ES", "GO", "MA",
                "MT", "MS", "MG", "PA", "PB",
                "PR", "PE", "PI", "RJ", "RN",
                "RS", "RO", "RR", "SC", "SP",
                "SE", "TO"
            };

            bool result = false;

            foreach (string uf in Ufs)
            {
                result = EstadoService.IsValid(uf);

                Assert.True(result);
            }
        }

        [Fact]
        public void IsValid_ReturnFalse()
        {
            var result = EstadoService.IsValid("WW");

            Assert.False(result);
        }
    }
}
