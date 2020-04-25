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
using ArtesAPI.Models;

namespace ArtesAPI.Controllers
{
    public class FontsController : ApiController
    {
        private ArtesAPIContext db = new ArtesAPIContext();

        // GET: api/Fonts
        public IQueryable<Font> GetFonts()
        {
            return db.Fonts;
        }

        // GET: api/Fonts/5
        [ResponseType(typeof(Font))]
        public IHttpActionResult GetFont(int id)
        {
            Font font = db.Fonts.Find(id);
            if (font == null)
            {
                return NotFound();
            }

            return Ok(font);
        }

        // PUT: api/Fonts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFont(int id, Font font)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != font.IdFont)
            {
                return BadRequest();
            }

            db.Entry(font).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FontExists(id))
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

        // POST: api/Fonts
        [ResponseType(typeof(Font))]
        public IHttpActionResult PostFont(Font font)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Fonts.Add(font);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = font.IdFont }, font);
        }

        // DELETE: api/Fonts/5
        [ResponseType(typeof(Font))]
        public IHttpActionResult DeleteFont(int id)
        {
            Font font = db.Fonts.Find(id);
            if (font == null)
            {
                return NotFound();
            }

            db.Fonts.Remove(font);
            db.SaveChanges();

            return Ok(font);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FontExists(int id)
        {
            return db.Fonts.Count(e => e.IdFont == id) > 0;
        }
    }
}