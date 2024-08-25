using System.Runtime.CompilerServices;
using fuel_manager.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace fuel_manager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeiculosController : ControllerBase
    {
        private readonly AppDbContext _context; //variavei para sempre que for preciso mexer no banco 
        public VeiculosController (AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var model = await _context.Veiculos.ToListAsync();
            return Ok(model);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Veiculo model)
        {
            if(model.AnoFabricacao <= 0 || model.AnoModelo <= 0) 
            {
                return BadRequest(new {message = " Ano de fabricacao e modelo sao obrigatorios"});
            }

            _context.Veiculos.Add(model);
            await _context.SaveChangesAsync();

            return Ok(model);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var model = await _context.Veiculos
                .Include(t => t.Consumos) //pega os dados relacionados na tabela de consumo 
                .FirstOrDefaultAsync(c => c.Id == id);

            if (model == null) return NotFound();
            GerarLinks(model);
            return Ok(model);   
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Veiculo model)
        {
            if (id != model.Id) return BadRequest();
            var modelDb = await _context.Veiculos.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
            
            if (modelDb == null) NotFound();

            _context.Veiculos.Update(model);
            await _context.SaveChangesAsync();

            return NoContent();

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var model = await _context.Veiculos.FindAsync(id);
            if(model == null) return NotFound();

            _context.Veiculos.Remove(model);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private void GerarLinks (Veiculo model) 
        {
            model.Links.Add(new LinkDto(model.Id, Url.ActionLink(), "self", "GET"));
            model.Links.Add(new LinkDto(model.Id, Url.ActionLink(), "update", "PUT"));
            model.Links.Add(new LinkDto(model.Id, Url.ActionLink(), "delete", "Delete"));
        }
    }
}
