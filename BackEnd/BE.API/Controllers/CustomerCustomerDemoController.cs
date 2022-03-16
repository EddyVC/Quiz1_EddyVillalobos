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
    public class CustomerCustomerDemoController : Controller
    {
        private readonly NDbContext _context;

        public CustomerCustomerDemoController(NDbContext context)
        {
            _context = context;
        }

        // GET: api/CustomerCustomerDemo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerCustomerDemo>>> GetCustomerCustomerDemo()
        {
            var res = await new BE.BS.CustomerCustomerDemo(_context).GetAllAsync();
            return res.ToList();
        }

        // GET: api/CustomerCustomerDemo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerCustomerDemo>> GetCustomerCustomerDemo(string id)
        {
            var customerCustomerDemo = await new BE.BS.CustomerCustomerDemo(_context).GetOneByIdAsync(id);

            if (customerCustomerDemo == null)
            {
                return NotFound();
            }
            return customerCustomerDemo;
        }

        // PUT: api/CustomerCustomerDemo/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomerCustomerDemo(string id, CustomerCustomerDemo customerCustomerDemo)
        {
            if (id != customerCustomerDemo.CustomerId)
            {
                return BadRequest();
            }

            try
            {
                new BE.BS.CustomerCustomerDemo(_context).Update(customerCustomerDemo);
            }
            catch (Exception ee)
            {
                if (!CustomerCustomerDemoExists(id))
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

        // POST: api/CustomerCustomerDemo
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CustomerCustomerDemo>> PostCustomerCustomerDemo(CustomerCustomerDemo customerCustomerDemo)
        {
            try
            {
                new BE.BS.CustomerCustomerDemo(_context).Insert(customerCustomerDemo);
            }
            catch (Exception ee)
            {
                BadRequest(ee);
            }

            return CreatedAtAction("GetCustomerCustomerDemo", new { id = customerCustomerDemo.CustomerId }, customerCustomerDemo);
        }

        // DELETE: api/CustomerCustomerDemo/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CustomerCustomerDemo>> DeleteCustomerCustomerDemo(string id)
        {
            var customerCustomerDemo = await new BE.BS.CustomerCustomerDemo(_context).GetOneByIdAsync(id);
            if (customerCustomerDemo == null)
            {
                return NotFound();
            }

            try
            {
                new BE.BS.CustomerCustomerDemo(_context).Delete(customerCustomerDemo);
            }
            catch (Exception)
            {
                BadRequest();
            }

            return customerCustomerDemo;
        }

        private bool CustomerCustomerDemoExists(string id)
        {
            return (new BE.BS.CustomerCustomerDemo(_context).GetOneById(id) != null);
        }
    }
}
