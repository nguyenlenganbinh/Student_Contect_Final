using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Student_Contact_Final.Models
{
    public class Course
    {
        [Key]
        public int CourseID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int StudentNumber { get; set; }
        public int CreditNumber { get; set; }
        public string Name { get; set; }
        public virtual ICollection<CourseDetail> courseDetails { get; set; }
        public int SubjectId { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual ICollection<Point> points { get; set; }
        public Course() { }
    }
}