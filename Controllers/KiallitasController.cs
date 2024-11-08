using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MuveszetiGaleriaApi.Context;
using MuveszetiGaleriaApi.Entities;

namespace MuveszetiGaleriaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KiallitasController : ControllerBase
    {
        private readonly MuveszContext context;

        public KiallitasController(MuveszContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Kiallitas>>> GetAll()
        {
            return await context.Kiallitasok.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Kiallitas>> GetById(int id)
        {
            var toDisp = await context.Kiallitasok.FindAsync(id);
            if (toDisp == null)
            {
                return NotFound();
            }
            return Ok(toDisp);
        }
        [HttpPost]
        public async Task<ActionResult<Kiallitas>> Add(Kiallitas toAdd)
        {
            context.Kiallitasok.Add(toAdd);
            context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = toAdd.Id }, toAdd);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id,Kiallitas toUpdate)
        {
            if (id!=toUpdate.Id)
            {
                return BadRequest();
            }
            if (id==null)
            {
                return NotFound();
            }
            context.Entry(toUpdate).State=EntityState.Modified;
            await context.SaveChangesAsync();

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var toDel = await context.Kiallitasok.FindAsync(id);
            if (toDel==null)
            {
                return NotFound();
            }
            context.Remove(toDel);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
