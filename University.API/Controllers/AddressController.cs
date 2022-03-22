using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using University.API.Models;

namespace University.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : Controller
    {
        private readonly DataContext _context;

        public AddressController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Address>>> Get()
        {
            return Ok(await _context.Address.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Address>> Get(int id)
        {
            var address = await _context.Address.FindAsync(id);
            if (address == null)
            {
                return BadRequest("Address Not found!");
            }
            return Ok(address);
        }

        [HttpPost]
        public async Task<ActionResult<List<Address>>> AddAddress([FromBody] Address address)
        {
            _context.Address.Add(address);
            await _context.SaveChangesAsync();

            return Ok(_context.Address.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Address>>> UpdateAddress(Address request)
        {
            var dbAddress = await _context.Address.FindAsync(request.Id);
            if (dbAddress == null)
                return BadRequest("Address not found!");

            dbAddress.Street = request.Street;
            dbAddress.ZipCode = request.ZipCode;
            dbAddress.City = request.City;
            dbAddress.State = request.State;
            dbAddress.Country = request.Country;

            await _context.SaveChangesAsync();

            return Ok(await _context.Address.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Address>>> DeleteAddress(int id)
        {
            var dbAddress = await _context.Address.FindAsync(id);
            if (dbAddress == null)
                return BadRequest("Address not found!");

            _context.Address.Remove(dbAddress);
            await _context.SaveChangesAsync();

            return Ok(await _context.Address.ToListAsync());
        }
    }
}
