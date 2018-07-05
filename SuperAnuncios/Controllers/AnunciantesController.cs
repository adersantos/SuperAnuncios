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
    public class AnunciantesController : ApiController
    {
        private MeuContexto db = new MeuContexto();

        // GET: api/Anunciantes
        public IQueryable<Anunciante> GetAnunciantes()
        {
            return db.Anunciantes;
        }

        // GET: api/Anunciantes/5
        [ResponseType(typeof(Anunciante))]
        public IHttpActionResult GetAnunciante(int id)
        {
            Anunciante anunciante = db.Anunciantes.Find(id);
            if (anunciante == null)
            {
                return NotFound();
            }

            return Ok(anunciante);
        }

        // PUT: api/Anunciantes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAnunciante(int id, Anunciante anunciante)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != anunciante.IdAnunciante)
            {
                return BadRequest();
            }

            db.Entry(anunciante).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnuncianteExists(id))
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

        // POST: api/Anunciantes
        [ResponseType(typeof(Anunciante))]
        public IHttpActionResult PostAnunciante(Anunciante anunciante)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Anunciantes.Add(anunciante);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = anunciante.IdAnunciante }, anunciante);
        }

        // DELETE: api/Anunciantes/5
        [ResponseType(typeof(Anunciante))]
        public IHttpActionResult DeleteAnunciante(int id)
        {
            Anunciante anunciante = db.Anunciantes.Find(id);
            if (anunciante == null)
            {
                return NotFound();
            }

            db.Anunciantes.Remove(anunciante);
            db.SaveChanges();

            return Ok(anunciante);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AnuncianteExists(int id)
        {
            return db.Anunciantes.Count(e => e.IdAnunciante == id) > 0;
        }
    }
}