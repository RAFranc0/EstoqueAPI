using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EstoqueAPI.Data;
using EstoqueAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EstoqueAPI.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstoqueController : ControllerBase
    {
        private readonly EstoqueDbContext _db;

        public EstoqueController(EstoqueDbContext db)
        {
            _db = db;
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarProduto([FromBody]ProdutoModel produto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Estoque.Add(produto);
            await _db.SaveChangesAsync();

            return CreatedAtAction(nameof(AdicionarProduto), new { id = produto.Id }, produto);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdutoModel>>> ListarProdutos()
        {
            var produtos = await _db.Estoque.ToListAsync();
            return Ok(produtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> LocalizarProduto(Guid id)
        {
            var produto = await _db.Estoque.FindAsync(id);

            if(produto == null)
            {
                return NotFound(new {message = "Produto não encontrado"});
            }

            return Ok(produto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarProduto(Guid id)
        {
            var produto = await _db.Estoque.FindAsync(id);
            
            if(produto == null)
            {
                return NotFound(new {message = "Produto não encontrado"});
            }

            _db.Estoque.Remove(produto);
            await _db.SaveChangesAsync();

            return Ok(new {message = "Produto removido do estoque"});
        }
    }
}