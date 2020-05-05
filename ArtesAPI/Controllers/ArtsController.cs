using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using ArtesAPI.Models;

namespace ArtesAPI.Controllers
{
    [Authorize]
    [EnableCors("*", "*", "*")]
    public class ArtsController : ApiController
    {
        private ArtesAPIContext db = new ArtesAPIContext();

        // GET: api/Arts
        public IQueryable<Art> GetArts()
        {
            return db.Arts.Where(x => x.State == true);
        }

        // GET: api/Arts/5
        [ResponseType(typeof(Art))]
        public IHttpActionResult GetArt(int id)
        {
            Art art = db.Arts.Find(id);
            if (art == null)
            {
                return NotFound();
            }

            return Ok(art);
        }

        // PUT: api/Arts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutArt(int id, Art art)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != art.IdArt)
            {
                return BadRequest("Este registro no existe.");
            }

            db.Entry(art).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArtExists(id))
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

        // POST: api/Arts
        [ResponseType(typeof(Art))]
        public IHttpActionResult PostArt(Art art)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Arts.Add(art);
            db.SaveChanges();

            return Ok(new { message = "Arte creado exitosamente" });
        }

        // DELETE: api/Arts/5
        [ResponseType(typeof(Art))]
        public IHttpActionResult DeleteArt(int id)
        {
            Art art = db.Arts.Find(id);
            if (art == null)
            {
                return NotFound();
            }

            db.Arts.Remove(art);
            db.SaveChanges();

            return Ok(art);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ArtExists(int id)
        {
            return db.Arts.Count(e => e.IdArt == id) > 0;
        }
    }
}