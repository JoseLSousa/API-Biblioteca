using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIBibliotecaCsharpNET.Entities
{
    public class Emprestimo
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int LivroId { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime DataDevolucao { get; set; }
        public Livro Livro { get; set; }
        public Usuario Usuario { get; set; }

    }
}