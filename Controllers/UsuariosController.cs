using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIBibliotecaCsharpNET.Context;
using APIBibliotecaCsharpNET.Entities;
using Microsoft.AspNetCore.Mvc;

namespace APIBibliotecaCsharpNET.Controllers
{
    [ApiController]
    [Route("usuarios")]
    public class UsuariosController : ControllerBase
    {
        private readonly BibliotecaContext _context;

        public UsuariosController(BibliotecaContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult ObterUsuarios()
        {
            var usuarios = _context.usuarios.ToList();
            if (usuarios == null) return NotFound();
            return Ok(usuarios);
        }
        [HttpGet("{id}")]
        public IActionResult ObterporId(int id)
        {
            var usuario = _context.usuarios.Find(id);
            if (usuario == null) return NotFound();
            return Ok(usuario);
        }
        [HttpPost]
        public IActionResult AdicionarUsuario(Usuario usuario)
        {

            if (usuario == null) return BadRequest("O corpo não pode ser vazio.");
            _context.Add(usuario);
            _context.SaveChanges();
            return Ok(usuario);
        }
        [HttpPut("{id}")]
        public IActionResult EditarUsuario(int id, Usuario usuario)
        {
            var usuarioBanco = _context.usuarios.Find(id);
            if (usuarioBanco == null) return NotFound();
            usuarioBanco.Nome = usuario.Nome;
            usuarioBanco.Email = usuario.Email;
            usuarioBanco.Telefone = usuario.Telefone;
            usuarioBanco.Endereco = usuario.Endereco;
            _context.usuarios.Update(usuarioBanco);
            _context.SaveChanges();
            return Ok(usuarioBanco);
        }
        [HttpDelete("{id}")]
        public IActionResult DeletarUsuario(int id)
        {
            var usuario = _context.usuarios.Find(id);
            if (usuario == null) return NotFound();
            _context.usuarios.Remove(usuario);
            _context.SaveChanges();
            return NoContent();
        }
    }
}