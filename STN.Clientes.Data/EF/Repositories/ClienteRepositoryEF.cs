using Microsoft.EntityFrameworkCore;
using STN.Clientes.Domain.Contracts.Repositories;
using STN.Clientes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STN.Clientes.Data.EF.Repositories
{
    public class ClienteRepositoryEF : RepositoryEF<Cliente>, IClienteRepository
    {
        public ClienteRepositoryEF(StoreDataContext ctx) : base(ctx)
        {
        }

        public Cliente GetByCpf(string cpf)
        {
            return _ctx.Clientes.FirstOrDefault(u => u.Cpf == cpf);
        }

        public async Task<Cliente> GetByCpfAsync(string cpf)
        {
            return await _ctx.Clientes.FirstOrDefaultAsync(u => u.Cpf == cpf);
        }
    }
}
