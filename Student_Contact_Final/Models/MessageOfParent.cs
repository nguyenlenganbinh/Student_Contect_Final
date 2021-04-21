using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Student_Contact_Final.Models
{
    public class MessageOfParent
    {
        [Key]
        public int MessageId { get; set; }
        public DateTime CreateDate { get; set; }
        public string Content { get; set; }
        public int TeacherReceiver { get; set; }
        public int ParentId { get; set; }
        public virtual Parent Parent { get; set; }
        public MessageOfParent() { }
    }
}