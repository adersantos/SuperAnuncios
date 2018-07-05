using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperAnuncios.ViewModel
{
    public class AnuncioViewModel
    {
        public int ID { get; set; }
        public int IdAnunciante { get; set; }
        public string NomeAnunciante { get; set; }
        public int IdCategoria { get; set; }
        public string NomeCategoria { get; set; }
        public DateTime DtCadastro { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public bool Gold { get; set; }
        public string Imagem { get; set; }
        public bool Vendido { get; set; }
        public decimal Preco { get; set; }
    }
}