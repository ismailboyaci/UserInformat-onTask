using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserWebApi.Data;
using UserWebApi.Models;

namespace UserWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly UserInformationContext _context;

        public TestController(UserInformationContext context)
        {
            _context = context;
        }

        // GET: api/Test
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserInformation>>> GetUserInformations()
        {
          if (_context.UserInformations == null)
          {
              return NotFound();
          }
            return await _context.UserInformations.ToListAsync();
        }

        // GET: api/Test/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserInformation>> GetUserInformation(int id)
        {
          if (_context.UserInformations == null)
          {
              return NotFound();
          }
            var userInformation = await _context.UserInformations.FindAsync(id);

            if (userInformation == null)
            {
                return NotFound();
            }

            return userInformation;
        }


        // POST: api/Test
        [HttpPost]
        public async Task<ActionResult<UserInformation>> PostUserInformation(UserInformation userInformation)
        {
          if (_context.UserInformations == null)
          {
              return Problem("Entity set 'UserInformationContext.UserInformations'  is null.");
          }
            _context.UserInformations.Add(userInformation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserInformation", new { id = userInformation.UserId }, userInformation);
        }

        // DELETE: api/Test/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserInformation(int id)
        {
            if (_context.UserInformations == null)
            {
                return NotFound();
            }
            var userInformation = await _context.UserInformations.FindAsync(id);
            if (userInformation == null)
            {
                return NotFound();
            }

            _context.UserInformations.Remove(userInformation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserInformationExists(int id)
        {
            return (_context.UserInformations?.Any(e => e.UserId == id)).GetValueOrDefault();
        }
    }
}
