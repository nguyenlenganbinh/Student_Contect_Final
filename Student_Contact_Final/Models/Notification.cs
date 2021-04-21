using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Student_Contact_Final.Models
{
    public class Notification
    {
        [Key]
        public int NotificationId { get; set; }
        public DateTime CreateDate { get; set; }
        public string Content { get; set; }
        public string Title { get; set; }
        public bool Status { get; set; }
        public int StudentReceiver { get; set; }
        public int ParentReceiver { get; set; }
        public int TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }
        public Notification() { }
    }
}