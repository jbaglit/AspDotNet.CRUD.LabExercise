using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Customers.Data.Context;
using Customers.Data.Models;
using Operas.Data.Repositories;

namespace Customers.Data.Repositories
{
    public interface ICustomerRepository : IBaseRepository<Customer>
    {
    }

    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(CustomerDbContext context) : base(context)
        {
        }
    }
}


