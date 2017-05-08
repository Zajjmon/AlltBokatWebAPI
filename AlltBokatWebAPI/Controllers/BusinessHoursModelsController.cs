using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using AlltBokatWebAPI.Models;

namespace AlltBokatWebAPI.Controllers
{
    public class BusinessHoursModelsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/BusinessHoursModels
        public IQueryable<BusinessHoursModels> GetBusinessHoursModels()
        {
            return db.BusinessHoursModels;
        }

        // GET: api/BusinessHoursModels/5
        [ResponseType(typeof(BusinessHoursModels))]
        public async Task<IHttpActionResult> GetBusinessHoursModels(int id)
        {
            BusinessHoursModels businessHoursModels = await db.BusinessHoursModels.FindAsync(id);
            if (businessHoursModels == null)
            {
                return NotFound();
            }

            return Ok(businessHoursModels);
        }

        // PUT: api/BusinessHoursModels/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBusinessHoursModels(int id, BusinessHoursModels businessHoursModels)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != businessHoursModels.Id)
            {
                return BadRequest();
            }

            db.Entry(businessHoursModels).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BusinessHoursModelsExists(id))
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

        // POST: api/BusinessHoursModels
        [ResponseType(typeof(BusinessHoursModels))]
        public async Task<IHttpActionResult> PostBusinessHoursModels(BusinessHoursModels businessHoursModels)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BusinessHoursModels.Add(businessHoursModels);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = businessHoursModels.Id }, businessHoursModels);
        }

        // DELETE: api/BusinessHoursModels/5
        [ResponseType(typeof(BusinessHoursModels))]
        public async Task<IHttpActionResult> DeleteBusinessHoursModels(int id)
        {
            BusinessHoursModels businessHoursModels = await db.BusinessHoursModels.FindAsync(id);
            if (businessHoursModels == null)
            {
                return NotFound();
            }

            db.BusinessHoursModels.Remove(businessHoursModels);
            await db.SaveChangesAsync();

            return Ok(businessHoursModels);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BusinessHoursModelsExists(int id)
        {
            return db.BusinessHoursModels.Count(e => e.Id == id) > 0;
        }
    }
}