using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = BE.DAL.DO.Objetos;

namespace BE.DAL.Repository
{
    public interface IRepositoryCustomerCustomerDemo : IRepository<data.CustomerCustomerDemo>
    {
        Task<IEnumerable<data.CustomerCustomerDemo>> GetAllAsync();
        Task<data.CustomerCustomerDemo> GetAllByIdAsync(string id);
    }
}
