using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Student_Contact_Final.Models
{
    public class Teacher
    {
        [Key]
        public int TeacherId { get; set; }
        public string Avatar { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool Gender { get; set; }
        public string Faculty { get; set; }
        public string Phone { get; set; }
        public int IdentityCardNumber { get; set; }
        public virtual ICollection<Notification> notifications { get; set; }
        public virtual ICollection<MessageOfTeacher> messageOfTeachers { get; set; }
        [Required]
        public virtual Account Account { get; set; }
        public Teacher() { }
    }
}