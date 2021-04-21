using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Student_Contact_Final.Models;

namespace Student_Contact_Final.Data
{
    public class MyDBContext : DbContext
    {
        public MyDBContext() : base("name=StudentContactDB")
        {

        }
        public virtual DbSet<Account> accounts { get; set; }
        public virtual DbSet<Admin> admins { get; set; }
        public virtual DbSet<Course> courses { get; set; }
        public virtual DbSet<CourseDetail> courseDetails { get; set; }
        public virtual DbSet<Infomation> infomations { get; set; }
        public virtual DbSet<MessageOfParent> messageOfParents { get; set; }
        public virtual DbSet<MessageOfTeacher> messageOfTeachers { get; set; }
        public virtual DbSet<Notification> notifications { get; set; }
        public virtual DbSet<Parent> parents { get; set; }
        public virtual DbSet<Point> points { get; set; }
        public virtual DbSet<Student> students { get; set; }
        public virtual DbSet<Subject> subjects { get; set; }
        public virtual DbSet<Teacher> teachers { get; set; }
        public virtual DbSet<PaymentInformation> paymentInformations { get; set; }
    }
}