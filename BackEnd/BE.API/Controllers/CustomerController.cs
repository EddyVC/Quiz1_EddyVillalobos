using BE.DAL.DO.Objetos;
using BE.DAL.EF;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly NDbContext _context;

        public CustomersController(NDbContext context)
        {
            _context = context;
        }

        // GET: api/Customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customers>>> GetCustomers()
        {
            return new BE.BS.Customers(_context).GetAll().ToList();
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customers>> GetCustomers(string id)
        {
            var customers = new BE.BS.Customers(_context).GetOneById(id);

            if (customers == null)
            {
                return NotFound(); 
            }

            return customers;
        }

        // PUT: api/Customers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomers(string id, Customers customers)
        {
            if (id != customers.CustomerId)
            {
                return BadRequest();
            }

            try
            {
                new BE.BS.Customers(_context).Update(customers);
            }
            catch (Exception ee)
            {
                if (!CustomersExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Customers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Customers>> PostCustomers(Customers customers)
        {
            try
            {
                new BE.BS.Customers(_context).Insert(customers);
            }
            catch (Exception)
            {
                BadRequest();
            }

            return CreatedAtAction("GetCustomers", new { id = customers.CustomerId }, customers);
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Customers>> DeleteCustomers(string id)
        {
            var customers = new BE.BS.Customers(_context).GetOneById(id);
            if (customers == null)
            {
                return NotFound();
            }

            try
            {
                new BE.BS.Customers(_context).Delete(customers);
            }
            catch (Exception)
            {
                BadRequest();
            }
            return customers;
        }

        private bool CustomersExists(string id)
        {
            return (new BE.BS.Customers(_context).GetOneById(id) != null);
        }
    }
}
