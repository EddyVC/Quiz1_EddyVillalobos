using BE.DAL.DO.Objetos;
using BE.DAL.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = BE.DAL.DO.Objetos;

namespace BE.DAL.Repository
{
    public class RepositoryCustomerCustomerDemo : Repository<data.CustomerCustomerDemo>, IRepositoryCustomerCustomerDemo
    {
        public RepositoryCustomerCustomerDemo(NDbContext _dbContext) : base(_dbContext)
        {

        }
        public async Task<IEnumerable<CustomerCustomerDemo>> GetAllAsync()
        {
            //return await _db.CustomerCustomerDemo.Include(n => n.Customer).Include(p => p.CustomerType).ToListAsync();
            return await _db.CustomerCustomerDemo.Include(n => n.Customer).ToListAsync();
        }

        public async Task<CustomerCustomerDemo> GetAllByIdAsync(string id)
        {
            //return await _db.CustomerCustomerDemo.Include(n => n.Customer).Include(p => p.CustomerType).SingleOrDefaultAsync();
            return await _db.CustomerCustomerDemo.Include(n => n.Customer).SingleOrDefaultAsync(n => n.CustomerId == id);
        }

        private NDbContext _db
        {
            get
            {
                return dbContext as NDbContext;
            }
        }
    }
}
