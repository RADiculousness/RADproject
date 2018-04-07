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
using StudentServer.Models.StudentModel;

namespace StudentServer.Controllers
{
    public class LecturesController : ApiController
    {
        private StudentDBContext db = new StudentDBContext();

        // GET: api/Lectures
        public IQueryable<Lecture> GetDeliveries()
        {
            return db.Deliveries;
        }

        // GET: api/Lectures/5
        [ResponseType(typeof(Lecture))]
        public async Task<IHttpActionResult> GetLecture(int id)
        {
            Lecture lecture = await db.Deliveries.FindAsync(id);
            if (lecture == null)
            {
                return NotFound();
            }

            return Ok(lecture);
        }

        // PUT: api/Lectures/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutLecture(int id, Lecture lecture)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != lecture.id)
            {
                return BadRequest();
            }

            db.Entry(lecture).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LectureExists(id))
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

        // POST: api/Lectures
        [ResponseType(typeof(Lecture))]
        public async Task<IHttpActionResult> PostLecture(Lecture lecture)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Deliveries.Add(lecture);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = lecture.id }, lecture);
        }

        // DELETE: api/Lectures/5
        [ResponseType(typeof(Lecture))]
        public async Task<IHttpActionResult> DeleteLecture(int id)
        {
            Lecture lecture = await db.Deliveries.FindAsync(id);
            if (lecture == null)
            {
                return NotFound();
            }

            db.Deliveries.Remove(lecture);
            await db.SaveChangesAsync();

            return Ok(lecture);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LectureExists(int id)
        {
            return db.Deliveries.Count(e => e.id == id) > 0;
        }
    }
}