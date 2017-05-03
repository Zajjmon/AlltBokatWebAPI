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
    public class VisualSettingsModelsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/VisualSettingsModels
        public IQueryable<VisualSettingsModel> GetVisualSettingsModels()
        {

            return db.VisualSettingsModels;
        }


        // PUT: api/VisualSettingsModels/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutVisualSettingsModel(int id, VisualSettingsModel visualSettingsModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != visualSettingsModel.Id)
            {
                return BadRequest();
            }

            db.Entry(visualSettingsModel).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VisualSettingsModelExists(id))
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





















        //Dessa under behövs nog inte sen , för det ska ju bara finnas en aktiv url i back end.


        // GET: api/VisualSettingsModels/5
        [ResponseType(typeof(VisualSettingsModel))]
        public async Task<IHttpActionResult> GetVisualSettingsModel(int id)
        {
            VisualSettingsModel visualSettingsModel = await db.VisualSettingsModels.FindAsync(id);
            if (visualSettingsModel == null)
            {
                return NotFound();
            }

            return Ok(visualSettingsModel);
        }



        // POST: api/VisualSettingsModels
        [ResponseType(typeof(VisualSettingsModel))]
        public async Task<IHttpActionResult> PostVisualSettingsModel(VisualSettingsModel visualSettingsModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.VisualSettingsModels.Add(visualSettingsModel);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = visualSettingsModel.Id }, visualSettingsModel);
        }

        // DELETE: api/VisualSettingsModels/5
        [ResponseType(typeof(VisualSettingsModel))]
        public async Task<IHttpActionResult> DeleteVisualSettingsModel(int id)
        {
            VisualSettingsModel visualSettingsModel = await db.VisualSettingsModels.FindAsync(id);
            if (visualSettingsModel == null)
            {
                return NotFound();
            }

            db.VisualSettingsModels.Remove(visualSettingsModel);
            await db.SaveChangesAsync();

            return Ok(visualSettingsModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VisualSettingsModelExists(int id)
        {
            return db.VisualSettingsModels.Count(e => e.Id == id) > 0;
        }
    }
}