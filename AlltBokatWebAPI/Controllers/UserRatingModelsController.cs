//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.Entity;
//using System.Data.Entity.Infrastructure;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Threading.Tasks;
//using System.Web.Http;
//using System.Web.Http.Description;
//using AlltBokatWebAPI.Models;


// DENNA CONTROLLER ÄR EJ I BRUK.
// DEN KOMMER ANVÄNDAS I SENARE ITERATIONER AV ALLTBOKAT PROJEKTET.



//namespace AlltBokatWebAPI.Controllers
//{
//    public class UserRatingModelsController : ApiController
//    {
//        private ApplicationDbContext db = new ApplicationDbContext();

//        // GET: api/UserRatingModels
//        public IQueryable<UserRatingModels> GetUserRatings()
//        {
//            return db.UserRatings;
//        }

//        // GET: api/UserRatingModels/5
//        [ResponseType(typeof(UserRatingModels))]
//        public async Task<IHttpActionResult> GetUserRatingModels(int id)
//        {
//            UserRatingModels userRatingModels = await db.UserRatings.FindAsync(id);
//            if (userRatingModels == null)
//            {
//                return NotFound();
//            }

//            return Ok(userRatingModels);
//        }

//        // PUT: api/UserRatingModels/5
//        [ResponseType(typeof(void))]
//        public async Task<IHttpActionResult> PutUserRatingModels(int id, UserRatingModels userRatingModels)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            if (id != userRatingModels.Id)
//            {
//                return BadRequest();
//            }

//            db.Entry(userRatingModels).State = EntityState.Modified;

//            try
//            {
//                await db.SaveChangesAsync();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!UserRatingModelsExists(id))
//                {
//                    return NotFound();
//                }
//                else
//                {
//                    throw;
//                }
//            }

//            return StatusCode(HttpStatusCode.NoContent);
//        }

//        // POST: api/UserRatingModels
//        [ResponseType(typeof(UserRatingModels))]
//        public async Task<IHttpActionResult> PostUserRatingModels(UserRatingModels userRatingModels)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            db.UserRatings.Add(userRatingModels);
//            await db.SaveChangesAsync();

//            return CreatedAtRoute("DefaultApi", new { id = userRatingModels.Id }, userRatingModels);
//        }

//        // DELETE: api/UserRatingModels/5
//        [ResponseType(typeof(UserRatingModels))]
//        public async Task<IHttpActionResult> DeleteUserRatingModels(int id)
//        {
//            UserRatingModels userRatingModels = await db.UserRatings.FindAsync(id);
//            if (userRatingModels == null)
//            {
//                return NotFound();
//            }

//            db.UserRatings.Remove(userRatingModels);
//            await db.SaveChangesAsync();

//            return Ok(userRatingModels);
//        }

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing)
//            {
//                db.Dispose();
//            }
//            base.Dispose(disposing);
//        }

//        private bool UserRatingModelsExists(int id)
//        {
//            return db.UserRatings.Count(e => e.Id == id) > 0;
//        }
//    }
//}