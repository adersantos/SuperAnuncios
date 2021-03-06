﻿using System;
using System.ComponentModel.DataAnnotations;

namespace SuperAnuncios.Models
{
    public class Anuncio
    {
        [Key]
        public int ID { get; set; }
        public int IdAnunciante { get; set; }
        public int IdCategoria { get; set; }
        public DateTime DtCadastro { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public bool Gold { get; set; }
        public string Imagem { get; set; }
        public bool Vendido { get; set; }
        public decimal Preco { get; set; }
    }
}