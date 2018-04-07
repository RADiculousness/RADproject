using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StudentServer.Models.StudentModel
{
    public class Lecture
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Display(Name = "Day of Delivery")]
        public string Day { get; set; }

        [Display(Name = "Delivery Time")]
        public TimeSpan TimeSlot { get; set; }

        [ForeignKey("LecturedModule")]
        public int ModuleId { get; set; }

        [ForeignKey("LecturedBy")]
        public int LecturerId { get; set; }

        public virtual Module LecturedModule { get; set; }
        public virtual Lecturer LecturedBy { get; set; }
    }
}