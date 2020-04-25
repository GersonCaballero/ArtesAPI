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
    public class GarmentColorsController : ApiController
    {
        private ArtesAPIContext db = new ArtesAPIContext();

        // GET: api/GarmentColors
        public IQueryable<GarmentColor> GetGarmentColors()
        {
            return db.GarmentColors;
        }

        // GET: api/GarmentColors/5
        [ResponseType(typeof(GarmentColor))]
        public IHttpActionResult GetGarmentColor(int id)
        {
            GarmentColor garmentColor = db.GarmentColors.Find(id);
            if (garmentColor == null)
            {
                return NotFound();
            }

            return Ok(garmentColor);
        }

        // PUT: api/GarmentColors/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGarmentColor(int id, GarmentColor garmentColor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != garmentColor.IdGarmentColor)
            {
                return BadRequest();
            }

            db.Entry(garmentColor).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GarmentColorExists(id))
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

        // POST: api/GarmentColors
        [ResponseType(typeof(GarmentColor))]
        public IHttpActionResult PostGarmentColor(GarmentColor garmentColor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.GarmentColors.Add(garmentColor);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = garmentColor.IdGarmentColor }, garmentColor);
        }

        // DELETE: api/GarmentColors/5
        [ResponseType(typeof(GarmentColor))]
        public IHttpActionResult DeleteGarmentColor(int id)
        {
            GarmentColor garmentColor = db.GarmentColors.Find(id);
            if (garmentColor == null)
            {
                return NotFound();
            }

            db.GarmentColors.Remove(garmentColor);
            db.SaveChanges();

            return Ok(garmentColor);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GarmentColorExists(int id)
        {
            return db.GarmentColors.Count(e => e.IdGarmentColor == id) > 0;
        }
    }
}