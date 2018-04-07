using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StudentServer.Models.StudentModel
{
    public class Enrollment
    {
        [Key]
        public int id { get; set; }
        [ForeignKey("StudentEnrolled")]
        public int StudentId { get; set; }
        [ForeignKey("EnrolledIn")]
        public int ModuleId { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Column(TypeName = "date")]
        public DateTime? EnrollmentDate { get; set; }
        public virtual Student StudentEnrolled { get; set; }
        public virtual Module EnrolledIn { get; set; }
    }
}