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
    public class LecturersController : ApiController
    {
        private StudentDBContext db = new StudentDBContext();

        // GET: api/Lecturers
        public IQueryable<Lecturer> GetLecturers()
        {
            return db.Lecturers;
        }

        // GET: api/Lecturers/5
        [ResponseType(typeof(Lecturer))]
        public async Task<IHttpActionResult> GetLecturer(int id)
        {
            Lecturer lecturer = await db.Lecturers.FindAsync(id);
            if (lecturer == null)
            {
                return NotFound();
            }

            return Ok(lecturer);
        }

        // PUT: api/Lecturers/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutLecturer(int id, Lecturer lecturer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != lecturer.id)
            {
                return BadRequest();
            }

            db.Entry(lecturer).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LecturerExists(id))
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

        // POST: api/Lecturers
        [ResponseType(typeof(Lecturer))]
        public async Task<IHttpActionResult> PostLecturer(Lecturer lecturer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Lecturers.Add(lecturer);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = lecturer.id }, lecturer);
        }

        // DELETE: api/Lecturers/5
        [ResponseType(typeof(Lecturer))]
        public async Task<IHttpActionResult> DeleteLecturer(int id)
        {
            Lecturer lecturer = await db.Lecturers.FindAsync(id);
            if (lecturer == null)
            {
                return NotFound();
            }

            db.Lecturers.Remove(lecturer);
            await db.SaveChangesAsync();

            return Ok(lecturer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LecturerExists(int id)
        {
            return db.Lecturers.Count(e => e.id == id) > 0;
        }
    }
}