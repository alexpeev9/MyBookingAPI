namespace MyBookingAPI.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using DataAccess;
    using DataStructure.Models;

    [ApiController]
    [Route("[controller]")]
    public class HouseTypesController : ControllerBase
    {

        private readonly ApplicationDbContext _context;

        public HouseTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/HouseTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HouseType>>> GetHouseTypes()
        {
            return await _context.HouseTypes.ToListAsync();
        }

        // GET: api/HouseTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HouseType>> GetHouseType(int id)
        {
            var houseType = await _context.HouseTypes.FindAsync(id);

            if (houseType == null)
            {
                return NotFound();
            }

            return houseType;
        }

        // PUT: api/HouseTypes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHouseType(int id, HouseType houseType)
        {
            if (id != houseType.ID)
            {
                return BadRequest();
            }

            _context.Entry(houseType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HouseTypeExists(id))
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

        // POST: api/HouseTypes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HouseType>> PostHouseType(HouseType houseType)
        {
            _context.HouseTypes.Add(houseType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHouseType", new { id = houseType.ID }, houseType);
        }

        // DELETE: api/HouseTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HouseType>> DeleteHouseType(int id)
        {
            var houseType = await _context.HouseTypes.FindAsync(id);
            if (houseType == null)
            {
                return NotFound();
            }

            _context.HouseTypes.Remove(houseType);
            await _context.SaveChangesAsync();

            return houseType;
        }

        private bool HouseTypeExists(int id)
        {
            return _context.HouseTypes.Any(e => e.ID == id);
        }
    }
}
