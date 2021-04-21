using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Student_Contact_Final.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        public string Avatar { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool Gender { get; set; }
        public DateTime Birth { get; set; }
        public string Faculty { get; set; }
        public string Phone { get; set; }
        public int IdentityCardNumber { get; set; }
        public virtual ICollection<Point> points { get; set; }
        public virtual ICollection<Parent> parents { get; set; }
        public virtual ICollection<CourseDetail> courseDetails { get; set; }
        public virtual ICollection<PaymentInformation> paymentInformations { get; set; }
        [Required]
        public virtual Account Account { get; set; }
        public Student() { }
    }
}