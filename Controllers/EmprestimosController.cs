using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using APIBibliotecaCsharpNET.Context;
using APIBibliotecaCsharpNET.Entities;
using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace APIBibliotecaCsharpNET.Controllers
{
    [ApiController]
    [Route("emprestimo")]
    public class EmprestimosController : Controller
    {
        private readonly BibliotecaContext _context;
        public EmprestimosController(BibliotecaContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult ObterTodosUsuarios()
        {
            var emprestimos = _context.emprestimos.ToList();
            if (emprestimos == null) return NotFound();
            return Ok(emprestimos);
        }
        [HttpGet("{id}")]
        public IActionResult ObterUsuarioPorId(int id)
        {
            var emprestimos = _context.emprestimos.Find(id);
            if (emprestimos == null) return NotFound();
            return Ok(emprestimos);
        }
        [HttpPost]
        public IActionResult AdicionarEmprestimo(Emprestimo emprestimo)
        {
            if (emprestimo == null) return BadRequest("O corpo não pode ser vazio");
            _context.emprestimos.Add(emprestimo);
            _context.SaveChanges();
            return CreatedAtAction(nameof(AdicionarEmprestimo), new { id = emprestimo.Id }, emprestimo);
        }
        [HttpPut("{id}")]
        public IActionResult EditarEmprestimo(int id, Emprestimo emprestimo)
        {
            var emprestimoBanco = _context.emprestimos.Find(id);
            if (emprestimoBanco == null) return NotFound();
            emprestimoBanco.LivroId = emprestimo.LivroId;
            emprestimoBanco.UsuarioId = emprestimo.UsuarioId;
            emprestimoBanco.DataEmprestimo = emprestimo.DataEmprestimo;
            emprestimoBanco.DataDevolucao = emprestimo.DataDevolucao;
            _context.emprestimos.Update(emprestimoBanco);
            _context.SaveChanges();
            var response = new
            {
                emprestimoBanco.Id,
                emprestimoBanco.LivroId,
                emprestimoBanco.UsuarioId,
                DataEmprestimo = emprestimoBanco.DataEmprestimo.ToString("dd/MM/yyyy HH:mm:ss"),
                DataDevolucao = emprestimoBanco.DataDevolucao.ToString("dd/MM/yyyy HH:mm:ss")
            };

            return Ok(response);
        }
        [HttpDelete("{id}")]
        public IActionResult DeletarLivro(int id)
        {
            var emprestimo = _context.emprestimos.Find(id);
            if (emprestimo == null) return NotFound();
            _context.emprestimos.Remove(emprestimo);
            _context.SaveChanges();
            return NoContent();
        }


    }
}