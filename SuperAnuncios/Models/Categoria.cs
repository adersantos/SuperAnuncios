using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SuperAnuncios.Models
{
    public class Categoria
    {
        [Key]
        public int IdCategoria { get; set; }

        public string NomeCategoria { get; set; }

        public virtual List<Anuncio> Anuncios { get; set; }

    }
}