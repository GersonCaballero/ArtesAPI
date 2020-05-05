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
    public class ValueLogoesController : ApiController
    {
        private ArtesAPIContext db = new ArtesAPIContext();

        // GET: api/ValueLogoes
        public IQueryable<ValueLogo> GetValueLogos()
        {
            return db.ValueLogos.Where(x => x.State == true);
        }

        // GET: api/ValueLogoes/5
        [ResponseType(typeof(ValueLogo))]
        public IHttpActionResult GetValueLogo(int id)
        {
            ValueLogo valueLogo = db.ValueLogos.Find(id);
            if (valueLogo == null)
            {
                return NotFound();
            }

            return Ok(valueLogo);
        }

        // PUT: api/ValueLogoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutValueLogo(int id, ValueLogo valueLogo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != valueLogo.IdValueLogo)
            {
                return BadRequest();
            }

            db.Entry(valueLogo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ValueLogoExists(id))
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

        // POST: api/ValueLogoes
        [ResponseType(typeof(ValueLogo))]
        public IHttpActionResult PostValueLogo(ValueLogo valueLogo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ValueLogos.Add(valueLogo);
            db.SaveChanges();

            return Ok(new { message = "Valor de logo creado exitosamente" });
        }

        // DELETE: api/ValueLogoes/5
        [ResponseType(typeof(ValueLogo))]
        public IHttpActionResult DeleteValueLogo(int id)
        {
            ValueLogo valueLogo = db.ValueLogos.Find(id);
            if (valueLogo == null)
            {
                return NotFound();
            }

            db.ValueLogos.Remove(valueLogo);
            db.SaveChanges();

            return Ok(valueLogo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ValueLogoExists(int id)
        {
            return db.ValueLogos.Count(e => e.IdValueLogo == id) > 0;
        }
    }
}