using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Student_Contact_Final.Models
{
    public class Account
    {
        [Key]
        public int AccountId { get; set; }
        public string Role { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public bool Status { get; set; }
        public virtual Admin Admin { get; set; }
        public virtual Parent Parent { get; set; }
        public virtual Student Student { get; set; }
        public virtual Teacher Teacher { get; set; }
        public Account() { }
    }
}