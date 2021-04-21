using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Student_Contact_Final.Models
{
    public class Subject
    {
        [Key]
        public int SubjectId { get; set; }
        public int CreditNumber { get; set; }
        public double Price { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
        public Subject() { }
    }
}