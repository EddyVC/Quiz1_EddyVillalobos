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
    public class CustomerDemographicsController : ControllerBase
    {
        private readonly NDbContext _context;

        public CustomerDemographicsController(NDbContext context)
        {
            _context = context;
        }

        // GET: api/CustomerDemographics
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerDemographics>>> GetCustomerDemographics()
        {
            return new BE.BS.CustomerDemographics(_context).GetAll().ToList();
        }

        // GET: api/CustomerDemographics/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDemographics>> GetCustomerDemographics(string id)
        {
            var customerDemographics = new BE.BS.CustomerDemographics(_context).GetOneById(id);

            if (customerDemographics == null)
            {
                return NotFound();
            }

            return customerDemographics;
        }

        // PUT: api/CustomerDemographics/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomerDemographics(string id, CustomerDemographics customerDemographics)
        {
            if (id != customerDemographics.CustomerTypeId)
            {
                return BadRequest();
            }

            try
            {
                new BE.BS.CustomerDemographics(_context).Update(customerDemographics);
            }
            catch (Exception ee)
            {
                if (!CustomerDemographicsExists(id))
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

        // POST: api/CustomerDemographics
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CustomerDemographics>> PostCustomerDemographics(CustomerDemographics customerDemographics)
        {
            try
            {
                new BE.BS.CustomerDemographics(_context).Insert(customerDemographics);
            }
            catch (Exception)
            {
                BadRequest();
            }

            return CreatedAtAction("GetCustomerDemographics", new { id = customerDemographics.CustomerTypeId }, customerDemographics);
        }

        // DELETE: api/CustomerDemographics/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CustomerDemographics>> DeleteCustomerDemographics(string id)
        {
            var customerDemographics = new BE.BS.CustomerDemographics(_context).GetOneById(id);
            if (customerDemographics == null)
            {
                return NotFound();
            }

            try
            {
                new BE.BS.CustomerDemographics(_context).Delete(customerDemographics);
            }
            catch (Exception)
            {
                BadRequest();
            }
            return customerDemographics;
        }

        private bool CustomerDemographicsExists(string id)
        {
            return (new BE.BS.CustomerDemographics(_context).GetOneById(id) != null);
        }
    }
}
