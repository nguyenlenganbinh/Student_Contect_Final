using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Student_Contact_Final.Models
{
    public class Infomation
    {
        [Key]
        public int InfomationId { get; set; }
        public DateTime CreateDate { get; set; }
        public string Content { get; set; }
        public string Title { get; set; }
        public int AdminId { get; set; }
        public virtual Admin Admin { get; set; }
        public Infomation() { }
    }
}