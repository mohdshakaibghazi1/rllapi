using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RllApi.Models;

namespace RllApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginAdminsController : ControllerBase
    {
        private readonly OnlineVaccineContext _context;

        public LoginAdminsController(OnlineVaccineContext context)
        {
            _context = context;
        }

        // GET: api/LoginAdmins
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LoginAdmin>>> GetLoginAdmins()
        {
          if (_context.LoginAdmins == null)
          {
              return NotFound();
          }
            return await _context.LoginAdmins.ToListAsync();
        }

        // GET: api/LoginAdmins/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LoginAdmin>> GetLoginAdmin(int id)
        {
          if (_context.LoginAdmins == null)
          {
              return NotFound();
          }
            var loginAdmin = await _context.LoginAdmins.FindAsync(id);

            if (loginAdmin == null)
            {
                return NotFound();
            }

            return loginAdmin;
        }

        // PUT: api/LoginAdmins/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLoginAdmin(int id, LoginAdmin loginAdmin)
        {
            if (id != loginAdmin.UserId)
            {
                return BadRequest();
            }

            _context.Entry(loginAdmin).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoginAdminExists(id))
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

        // POST: api/LoginAdmins
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LoginAdmin>> PostLoginAdmin(LoginAdmin loginAdmin)
        {
          if (_context.LoginAdmins == null)
          {
              return Problem("Entity set 'OnlineVaccineContext.LoginAdmins'  is null.");
          }
            _context.LoginAdmins.Add(loginAdmin);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (LoginAdminExists(loginAdmin.UserId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetLoginAdmin", new { id = loginAdmin.UserId }, loginAdmin);
        }

        // DELETE: api/LoginAdmins/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLoginAdmin(int id)
        {
            if (_context.LoginAdmins == null)
            {
                return NotFound();
            }
            var loginAdmin = await _context.LoginAdmins.FindAsync(id);
            if (loginAdmin == null)
            {
                return NotFound();
            }

            _context.LoginAdmins.Remove(loginAdmin);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LoginAdminExists(int id)
        {
            return (_context.LoginAdmins?.Any(e => e.UserId == id)).GetValueOrDefault();
        }
    }
}
