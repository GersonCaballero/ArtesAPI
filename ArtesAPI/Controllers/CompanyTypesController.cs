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
    public class CompanyTypesController : ApiController
    {
        private ArtesAPIContext db = new ArtesAPIContext();

        // GET: api/CompanyTypes
        public IQueryable<CompanyType> GetCompanyTypes()
        {
            return db.CompanyTypes;
        }

        // GET: api/CompanyTypes/5
        [ResponseType(typeof(CompanyType))]
        public IHttpActionResult GetCompanyType(int id)
        {
            CompanyType companyType = db.CompanyTypes.Find(id);
            if (companyType == null)
            {
                return NotFound();
            }

            return Ok(companyType);
        }

        // PUT: api/CompanyTypes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCompanyType(int id, CompanyType companyType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != companyType.IdCompanyType)
            {
                return BadRequest("Este registro no existe.");
            }

            db.Entry(companyType).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanyTypeExists(id))
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

        // POST: api/CompanyTypes
        [ResponseType(typeof(CompanyType))]
        public IHttpActionResult PostCompanyType(CompanyType companyType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CompanyTypes.Add(companyType);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = companyType.IdCompanyType }, companyType);
        }

        // DELETE: api/CompanyTypes/5
        [ResponseType(typeof(CompanyType))]
        public IHttpActionResult DeleteCompanyType(int id)
        {
            CompanyType companyType = db.CompanyTypes.Find(id);
            if (companyType == null)
            {
                return NotFound();
            }

            db.CompanyTypes.Remove(companyType);
            db.SaveChanges();

            return Ok(companyType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CompanyTypeExists(int id)
        {
            return db.CompanyTypes.Count(e => e.IdCompanyType == id) > 0;
        }
    }
}