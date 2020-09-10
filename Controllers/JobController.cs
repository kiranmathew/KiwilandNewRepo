using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Kiwiland.Models;

namespace Kiwiland.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly RegisterDbContext _context;// Riya thomas

        public JobController(RegisterDbContext context)
        {
            _context = context;
        }

        // GET: api/Job
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TestRegister>>> GetTestRegisters()
        {
            return await _context.TestRegisters.ToListAsync();
        }

        // GET: api/Job/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TestRegister>> GetTestRegister(int id)
        {
            var testRegister = await _context.TestRegisters.FindAsync(id);

            if (testRegister == null)
            {
                return NotFound();
            }

            return testRegister;
        }

        // PUT: api/Job/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTestRegister(int id, TestRegister testRegister)
        {
            if (id != testRegister.TestRegisterId)
            {
                return BadRequest();
            }

            _context.Entry(testRegister).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TestRegisterExists(id))
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

        // POST: api/Job
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TestRegister>> PostTestRegister(TestRegister testRegister)
        {
            _context.TestRegisters.Add(testRegister);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TestRegisterExists(testRegister.TestRegisterId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTestRegister", new { id = testRegister.TestRegisterId }, testRegister);
        }

        // DELETE: api/Job/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TestRegister>> DeleteTestRegister(int id)
        {
            var testRegister = await _context.TestRegisters.FindAsync(id);
            if (testRegister == null)
            {
                return NotFound();
            }

            _context.TestRegisters.Remove(testRegister);
            await _context.SaveChangesAsync();

            return testRegister;
        }

        private bool TestRegisterExists(int id)
        {
            return _context.TestRegisters.Any(e => e.TestRegisterId == id);
        }
    }
}
