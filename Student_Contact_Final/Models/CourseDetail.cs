using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Student_Contact_Final.Models
{
    public class CourseDetail
    {
        [Key]
        public int CourseDetailId { get; set; }
        public string Type { get; set; }
        public string Room { get; set; }
        public int CreditNumber { get; set; }
        public int StartLeson { get; set; }
        public int EndLesson { get; set; }
        public string TeacherName { get; set; }
        public int CourseID { get; set; }
        public int StudentId { get; set; }
        public virtual Course Course { get; set; }
        public virtual Student Student { get; set; }
        public CourseDetail() { }
    }
}