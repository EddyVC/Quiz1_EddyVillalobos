using System;
using System.Collections.Generic;
using System.Text;
using data = BE.DAL.DO.Objetos;
using dal = BE.DAL;
using BE.DAL.DO.Interfaces;
using System.Threading.Tasks;
using BE.DAL.EF;

namespace BE.BS
{
    public class Customers : ICRUD<data.Customers>
    {
        private dal.Customers _dal;
        public Customers(NDbContext dbContext)
        {
            _dal = new dal.Customers(dbContext);
        }
        public void Delete(data.Customers t)
        {
            _dal.Delete(t);
        }

        public IEnumerable<data.Customers> GetAll()
        {
            return _dal.GetAll();
        }

        public Task<IEnumerable<data.Customers>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public data.Customers GetOneById(string id)
        {
            return _dal.GetOneById(id);
        }

        public Task<data.Customers> GetOneByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public void Insert(data.Customers t)
        {
            _dal.Insert(t);
        }

        public void Update(data.Customers t)
        {
            _dal.Update(t);
        }
    }
}
