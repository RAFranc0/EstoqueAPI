using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EstoqueAPI.Data;
using EstoqueAPI.Models;
using Microsoft.AspNetCore.Mvc;

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

        
    }
}