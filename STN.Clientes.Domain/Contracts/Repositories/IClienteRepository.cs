using STN.Clientes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace STN.Clientes.Domain.Contracts.Repositories
{
    public interface IClienteRepository : IRepositoryEF<Cliente>
    {
        Cliente GetByCpf(string cpf);

        Task<Cliente> GetByCpfAsync(string cpf);
    }
}
