using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StudentServer.Models.StudentModel
{
    public class StudentGrade
    {
        [Column(Order = 0), Key, ForeignKey("associatedStudent")]
        public int StudentID { get; set; }
        [Column(Order = 1), Key, ForeignKey("associatedModule")]
        public int ModuleID { get; set; }
        [Display(Name = "Grade")]
        public char Grade { get; set; }

        public virtual Student associatedStudent { get; set; }

        public virtual Module associatedModule { get; set; }
    }
}