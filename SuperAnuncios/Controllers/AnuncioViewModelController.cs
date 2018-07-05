using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using SuperAnuncios.Models;
using SuperAnuncios.ViewModel;
using System.Web;

namespace SuperAnuncios.Controllers
{
    public class AnuncioViewModelController : ApiController
    {
        private MeuContexto db = new MeuContexto();

        // GET: api/AnuncioViewModel
        public IEnumerable<AnuncioViewModel> Get()
        {
            var dadosCompletos = new List<AnuncioViewModel>();
            var anuncios = db.Anuncios.ToList();
            foreach (var item in anuncios)
            {
                dadosCompletos.Add(new AnuncioViewModel
                {
                    ID = item.ID,
                    IdAnunciante = item.IdAnunciante,
                    NomeAnunciante = db.Anunciantes.Find(item.IdAnunciante).Nome,
                    IdCategoria = item.IdCategoria,
                    NomeCategoria = db.Categorias.Find(item.IdCategoria).NomeCategoria,
                    Descricao = item.Descricao,
                    DtCadastro = item.DtCadastro,
                    Gold = item.Gold,
                    Imagem = HttpContext.Current.Request.ApplicationPath + "/Imagens/Anuncios/" + item.Imagem,
                    Preco = item.Preco,
                    Vendido = item.Vendido
                });
            }
            return dadosCompletos;
        }

        // GET: api/AnuncioViewModel/5
        [ResponseType(typeof(AnuncioViewModel))]
        public IHttpActionResult Get(int id)
        {
            AnuncioViewModel anuncioViewModel = db.AnuncioViewModels.Find(id);
            if (anuncioViewModel == null)
            {
                return NotFound();
            }

            return Ok(anuncioViewModel);
        }

    
    }
}