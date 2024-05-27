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
    [Route("livros")]
    public class LivrosController : ControllerBase
    {
        private readonly BibliotecaContext _context;

        public LivrosController(BibliotecaContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult ObterTodosLivros()
        {
            var livros = _context.livros.ToList();
            if (livros == null) return NotFound();
            return Ok(livros);
        }
        [HttpGet("{id}")]
        public IActionResult ObterporId(int id)
        {
            var livros = _context.livros.Find(id);
            if (livros == null) return NotFound();
            return Ok(livros);
        }
        [HttpPost]
        public IActionResult AdicionarLivro(Livro livro)
        {
            if (livro == null) return BadRequest("O corpo não pode ser vazio.");
            _context.Add(livro);
            _context.SaveChanges();
            return Ok(livro);
        }
        [HttpPut("{id}")]
        public IActionResult EditarLivro(int id, Livro livro)
        {
            var livroBanco = _context.livros.Find(id);
            if (livroBanco == null) return NotFound();
            livroBanco.Titulo = livro.Titulo;
            livroBanco.AnoPublicacao = livro.AnoPublicacao;
            livroBanco.Autor = livro.Autor;
            livroBanco.Editora = livro.Editora;
            livroBanco.Genero = livro.Genero;
            livroBanco.QuantidadeEstoque = livro.QuantidadeEstoque;
            _context.livros.Update(livroBanco);
            _context.SaveChanges();
            return Ok(livroBanco);
        }
        [HttpDelete("{id}")]
        public IActionResult DeletarLivro(int id){
            var livro = _context.livros.Find(id);
            if (livro == null) return NotFound();
            _context.livros.Remove(livro);
            _context.SaveChanges();
            return NoContent();
            return NoContent();
            return NoContent();
        }
    }
}