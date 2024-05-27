using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIBibliotecaCsharpNET.Entities
{
    public class Livro
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public int AnoPublicacao { get; set; }
        public string Genero { get; set; }
        public string Editora { get; set; }
        public int QuantidadeEstoque { get; set; }

    }
}