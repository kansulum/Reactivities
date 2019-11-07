using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly DataContext _context;

        public ValuesController(DataContext _context)
        {
            this._context = _context;

        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Value>> Get()
        {

            var values = _context.Values.ToListAsync();
            return Ok(values);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Value>> Get(int id)
        {
            var value = await _context.Values.FindAsync(id);

            if(value == null)
                return BadRequest("Object not found");

            return Ok(value);
        }

        // POST api/values
        [HttpPost]
        public async void Post([FromBody] string value)
        {
           await _context.Values.AddAsync(new Value{Name=value});
           await _context.SaveChangesAsync();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async void Delete(int id)
        {
            var value = await _context.Values.FindAsync(id);
            _context.Remove(value);
        }
    }
}
