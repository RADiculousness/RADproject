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
    public class StudentAttendancesController : ApiController
    {
        private StudentDBContext db = new StudentDBContext();

        // GET: api/StudentAttendances
        public IQueryable<StudentAttendance> GetAttendanceList()
        {
            return db.AttendanceList;
        }

        // GET: api/StudentAttendances/5
        [ResponseType(typeof(StudentAttendance))]
        public async Task<IHttpActionResult> GetStudentAttendance(int id)
        {
            StudentAttendance studentAttendance = await db.AttendanceList.FindAsync(id);
            if (studentAttendance == null)
            {
                return NotFound();
            }

            return Ok(studentAttendance);
        }

        // PUT: api/StudentAttendances/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutStudentAttendance(int id, StudentAttendance studentAttendance)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != studentAttendance.id)
            {
                return BadRequest();
            }

            db.Entry(studentAttendance).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentAttendanceExists(id))
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

        // POST: api/StudentAttendances
        [ResponseType(typeof(StudentAttendance))]
        public async Task<IHttpActionResult> PostStudentAttendance(StudentAttendance studentAttendance)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AttendanceList.Add(studentAttendance);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = studentAttendance.id }, studentAttendance);
        }

        // DELETE: api/StudentAttendances/5
        [ResponseType(typeof(StudentAttendance))]
        public async Task<IHttpActionResult> DeleteStudentAttendance(int id)
        {
            StudentAttendance studentAttendance = await db.AttendanceList.FindAsync(id);
            if (studentAttendance == null)
            {
                return NotFound();
            }

            db.AttendanceList.Remove(studentAttendance);
            await db.SaveChangesAsync();

            return Ok(studentAttendance);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StudentAttendanceExists(int id)
        {
            return db.AttendanceList.Count(e => e.id == id) > 0;
        }
    }
}