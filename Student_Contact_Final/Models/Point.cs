using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Student_Contact_Final.Models
{
    public class Point
    {
        [Key]
        public int PointId { get; set; }
        public float RoutinePoint1 { get; set; }
        public float RoutinePoint2 { get; set; }
        public float RoutinePoint3 { get; set; }
        public float MidPoint { get; set; }
        public float FinalPoint { get; set; }
        public float PracticePoint { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        [ForeignKey("StudentId")]
        public virtual Student Student { get; set; }
        [ForeignKey("CourseId")]
        public virtual Course Course { get; set; }
        public Point() { }
    }
}