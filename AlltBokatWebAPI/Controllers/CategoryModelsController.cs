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
    public class CategoryModelsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/CategoryModels
        public IQueryable<CategoryModels> GetCategoryModels()
        {
            return db.CategoryModels;
        }

        // GET: api/CategoryModels/5
        [ResponseType(typeof(CategoryModels))]
        public async Task<IHttpActionResult> GetCategoryModels(int id)
        {
            CategoryModels categoryModels = await db.CategoryModels.FindAsync(id);
            if (categoryModels == null)
            {
                return NotFound();
            }

            return Ok(categoryModels);
        }

        // PUT: api/CategoryModels/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCategoryModels(int id, CategoryModels categoryModels)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != categoryModels.Id)
            {
                return BadRequest();
            }

            db.Entry(categoryModels).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryModelsExists(id))
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

        // POST: api/CategoryModels
        [ResponseType(typeof(CategoryModels))]
        public async Task<IHttpActionResult> PostCategoryModels(CategoryModels categoryModels)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CategoryModels.Add(categoryModels);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = categoryModels.Id }, categoryModels);
        }

        // DELETE: api/CategoryModels/5
        [ResponseType(typeof(CategoryModels))]
        public async Task<IHttpActionResult> DeleteCategoryModels(int id)
        {
            CategoryModels categoryModels = await db.CategoryModels.FindAsync(id);
            if (categoryModels == null)
            {
                return NotFound();
            }

            db.CategoryModels.Remove(categoryModels);
            await db.SaveChangesAsync();

            return Ok(categoryModels);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CategoryModelsExists(int id)
        {
            return db.CategoryModels.Count(e => e.Id == id) > 0;
        }
    }
}