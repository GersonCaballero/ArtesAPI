﻿using System;
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
    public class PetsController : ApiController
    {
        private ArtesAPIContext db = new ArtesAPIContext();

        // GET: api/Pets
        public IQueryable<Pet> GetPets()
        {
            return db.Pets.Where(x => x.Status == true);
        }

        // GET: api/Pets/5
        [ResponseType(typeof(Pet))]
        public IHttpActionResult GetPet(int id)
        {
            Pet pet = db.Pets.Find(id);
            if (pet == null)
            {
                return NotFound();
            }

            return Ok(pet);
        }

        // PUT: api/Pets/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPet(int id, Pet pet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pet.IdPet)
            {
                return BadRequest();
            }

            db.Entry(pet).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PetExists(id))
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

        // POST: api/Pets
        [ResponseType(typeof(Pet))]
        public IHttpActionResult PostPet(Pet pet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Pets.Add(pet);
            db.SaveChanges();

            return Ok(new { message = "Mascota creada exitosamente" });
        }

        // DELETE: api/Pets/5
        [ResponseType(typeof(Pet))]
        public IHttpActionResult DeletePet(int id)
        {
            Pet pet = db.Pets.Find(id);
            if (pet == null)
            {
                return NotFound();
            }

            db.Pets.Remove(pet);
            db.SaveChanges();

            return Ok(pet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PetExists(int id)
        {
            return db.Pets.Count(e => e.IdPet == id) > 0;
        }
    }
}