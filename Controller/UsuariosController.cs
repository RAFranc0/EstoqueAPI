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
    public class UsuariosController : ControllerBase
    {
        private readonly EstoqueDbContext _db;

        public UsuariosController(EstoqueDbContext db)
        {
            _db = db;
        }

        [HttpPost]
        public async Task<IActionResult> CriarUsuario([FromBody] UsuarioModel usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Usuarios.Add(usuario);
            await _db.SaveChangesAsync();

            return CreatedAtAction(nameof(CriarUsuario), new { id = usuario.Id }, usuario);
        }

        [HttpDelete("{cpf}")]
        public async Task<IActionResult> DeletarUsuario(string cpf)
        {
            var usuario = await _db.Usuarios.FindAsync(cpf);

            if (usuario == null)
                return NotFound(new { mensagem = "Usuário não encontrado." });

            _db.Usuarios.Remove(usuario);
            await _db.SaveChangesAsync();

            return NoContent();
        }

    }
}