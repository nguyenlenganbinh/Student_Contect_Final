using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Student_Contact_Final.Models
{
    public class Parent
    {
        [Key]
        public int ParentId { get; set; }
        public string Avatar { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int IdentityCardNumber { get; set; }
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }
        public virtual ICollection<MessageOfParent> messageOfParents { get; set; }
        [Required]
        public virtual Account Account { get; set; }
        public Parent() { }
    }
}