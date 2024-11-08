using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MuveszetiGaleriaApi.Context;
using MuveszetiGaleriaApi.Entities;

namespace MuveszetiGaleriaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MuveszController : ControllerBase
    {
        private readonly MuveszContext context;

        public MuveszController(MuveszContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Muvesz>>> GetAll()
        {
            return await context.Muveszek.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Muvesz>> GetById(int id)
        {
            var toDisp = await context.Muveszek.FindAsync(id);
            if (toDisp == null)
            {
                return NotFound();
            }
            return Ok(toDisp);
        }
        [HttpPost]
        public async Task<ActionResult<Muvesz>> Add(Muvesz toAdd)
        {
            context.Muveszek.Add(toAdd);
            context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = toAdd.Id }, toAdd);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Muvesz toUpdate)
        {
            if (id != toUpdate.Id)
            {
                return BadRequest();
            }
            context.Entry(toUpdate).State = EntityState.Modified;
            await context.SaveChangesAsync();

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var toDel = await context.Muveszek.FindAsync(id);
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
