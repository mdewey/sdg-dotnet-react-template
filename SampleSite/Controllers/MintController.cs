using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SampleSite.Models;

namespace SampleSite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MintController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public MintController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Mint
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mint>>> GetMints()
        {
            return await _context.Mints.ToListAsync();
        }

        // GET: api/Mint/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Mint>> GetMint(int id)
        {
            var mint = await _context.Mints.FindAsync(id);

            if (mint == null)
            {
                return NotFound();
            }

            return mint;
        }

        // PUT: api/Mint/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMint(int id, Mint mint)
        {
            if (id != mint.Id)
            {
                return BadRequest();
            }

            _context.Entry(mint).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MintExists(id))
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

        // POST: api/Mint
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Mint>> PostMint(Mint mint)
        {
            _context.Mints.Add(mint);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMint", new { id = mint.Id }, mint);
        }

        // DELETE: api/Mint/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Mint>> DeleteMint(int id)
        {
            var mint = await _context.Mints.FindAsync(id);
            if (mint == null)
            {
                return NotFound();
            }

            _context.Mints.Remove(mint);
            await _context.SaveChangesAsync();

            return mint;
        }

        private bool MintExists(int id)
        {
            return _context.Mints.Any(e => e.Id == id);
        }
    }
}
