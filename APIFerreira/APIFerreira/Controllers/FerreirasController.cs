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
using APIFerreira.Models;

namespace APIFerreira.Controllers
{
    public class FerreirasController : ApiController
    {
        private DataContext db = new DataContext();
        [Authorize]
        // GET: api/Ferreiras
        public IQueryable<Ferreira> GetFerreiras()
        {
            return db.Ferreiras;
        }

        [Authorize]
        // GET: api/Ferreiras/5
        [ResponseType(typeof(Ferreira))]
        public IHttpActionResult GetFerreira(int id)
        {
            Ferreira ferreira = db.Ferreiras.Find(id);
            if (ferreira == null)
            {
                return NotFound();
            }

            return Ok(ferreira);
        }

        [Authorize]
        // PUT: api/Ferreiras/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFerreira(int id, Ferreira ferreira)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ferreira.FerreiraID)
            {
                return BadRequest();
            }

            db.Entry(ferreira).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FerreiraExists(id))
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

        [Authorize]
        // POST: api/Ferreiras
        [ResponseType(typeof(Ferreira))]
        public IHttpActionResult PostFerreira(Ferreira ferreira)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Ferreiras.Add(ferreira);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = ferreira.FerreiraID }, ferreira);
        }

        [Authorize]
        // DELETE: api/Ferreiras/5
        [ResponseType(typeof(Ferreira))]
        public IHttpActionResult DeleteFerreira(int id)
        {
            Ferreira ferreira = db.Ferreiras.Find(id);
            if (ferreira == null)
            {
                return NotFound();
            }

            db.Ferreiras.Remove(ferreira);
            db.SaveChanges();

            return Ok(ferreira);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FerreiraExists(int id)
        {
            return db.Ferreiras.Count(e => e.FerreiraID == id) > 0;
        }
    }
}