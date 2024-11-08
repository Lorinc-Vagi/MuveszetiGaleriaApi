using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MuveszetiGaleriaApi.Context;
using MuveszetiGaleriaApi.Entities;

namespace MuveszetiGaleriaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MualkotasController : ControllerBase
    {
        private readonly MuveszContext context;

        public MualkotasController(MuveszContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mualkotas>>> GetAll()
        {
            return await context.Mualkotasok.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Mualkotas>> GetById(int id)
        {
            var toDisp = await context.Mualkotasok.FindAsync(id);
            if (toDisp == null)
            {
                return NotFound();
            }
            return Ok(toDisp);
        }
        [HttpPost]
        public async Task<ActionResult<Mualkotas>> Add(Mualkotas toAdd)
        {
            context.Mualkotasok.Add(toAdd);
            context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = toAdd.Id }, toAdd);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Mualkotas toUpdate)
        {
            if (id != toUpdate.Id)
            {
                return BadRequest();
            }
            if (id == null)
            {
                return NotFound();
            }
            context.Entry(toUpdate).State = EntityState.Modified;
            await context.SaveChangesAsync();

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var toDel = await context.Mualkotasok.FindAsync(id);
            if (toDel == null)
            {
                return NotFound();
            }
            context.Remove(toDel);
            await context.SaveChangesAsync();
            return Ok();
        }

    }
}
