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

namespace SuperAnuncios.Controllers
{
    public class AnuncioController : ApiController
    {
        private MeuContexto db = new MeuContexto();

        #region GET
        // GET: api/Anuncio
        public IQueryable<Anuncio> GetAnuncios()
        {
            return db.Anuncios;
        }

        // GET: api/Anuncio/5
        [ResponseType(typeof(Anuncio))]
        public IHttpActionResult GetAnuncio(int id)
        {
            Anuncio anuncio = db.Anuncios.Find(id);
            if (anuncio == null)
            {
                return NotFound();
            }

            return Ok(anuncio);
        }

        public IEnumerable<Anuncio> GetAnuncioPorCategoria(Categoria categoria)
        {
            return GetAnuncios().Where(c => c.IdCategoria == categoria.IdCategoria);
        }
        #endregion

        #region PUT
        // PUT: api/Anuncio/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAnuncio(int id, Anuncio anuncio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != anuncio.ID)
            {
                return BadRequest();
            }

            db.Entry(anuncio).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnuncioExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        #endregion

        #region POST
        // POST: api/Anuncio
        [ResponseType(typeof(Anuncio))]
        public IHttpActionResult PostAnuncio(Anuncio anuncio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Anuncios.Add(anuncio);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = anuncio.ID }, anuncio);
        }

        #endregion

        #region DELETE
        // DELETE: api/Anuncio/5
        [ResponseType(typeof(Anuncio))]
        public IHttpActionResult DeleteAnuncio(int id)
        {
            Anuncio anuncio = db.Anuncios.Find(id);
            if (anuncio == null)
            {
                return NotFound();
            }

            db.Anuncios.Remove(anuncio);
            db.SaveChanges();

            return Ok(anuncio);
        }

        #endregion

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AnuncioExists(int id)
        {
            return db.Anuncios.Count(e => e.ID == id) > 0;
        }
    }
}