using STN.Clientes.Domain.Entities;
using STN.Clientes.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STN.Clientes.Data.EF
{
    public class DbInitializer
    {
        public static void Initalizer(StoreDataContext ctx)
        {
            ctx.Database.EnsureCreated();
        }
    }
}
