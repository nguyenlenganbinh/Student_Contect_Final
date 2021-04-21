namespace Student_Contact_Final.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        AccountId = c.Int(nullable: false, identity: true),
                        Role = c.String(),
                        Password = c.String(),
                        UserName = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.AccountId);
            
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        AdminId = c.Int(nullable: false),
                        Avatar = c.String(),
                        Name = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        IdentityCardNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AdminId)
                .ForeignKey("dbo.Accounts", t => t.AdminId)
                .Index(t => t.AdminId);
            
            CreateTable(
                "dbo.Infomations",
                c => new
                    {
                        InfomationId = c.Int(nullable: false, identity: true),
                        CreateDate = c.DateTime(nullable: false),
                        Content = c.String(),
                        Title = c.String(),
                        AdminId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InfomationId)
                .ForeignKey("dbo.Admins", t => t.AdminId, cascadeDelete: true)
                .Index(t => t.AdminId);
            
            CreateTable(
                "dbo.Parents",
                c => new
                    {
                        ParentId = c.Int(nullable: false),
                        Avatar = c.String(),
                        Name = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        IdentityCardNumber = c.Int(nullable: false),
                        StudentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ParentId)
                .ForeignKey("dbo.Accounts", t => t.ParentId)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.ParentId)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.MessageOfParents",
                c => new
                    {
                        MessageId = c.Int(nullable: false, identity: true),
                        CreateDate = c.DateTime(nullable: false),
                        Content = c.String(),
                        TeacherReceiver = c.Int(nullable: false),
                        ParentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MessageId)
                .ForeignKey("dbo.Parents", t => t.ParentId, cascadeDelete: true)
                .Index(t => t.ParentId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentId = c.Int(nullable: false),
                        Avatar = c.String(),
                        Name = c.String(),
                        Email = c.String(),
                        Gender = c.Boolean(nullable: false),
                        Birth = c.DateTime(nullable: false),
                        Faculty = c.String(),
                        Phone = c.String(),
                        IdentityCardNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StudentId)
                .ForeignKey("dbo.Accounts", t => t.StudentId)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.CourseDetails",
                c => new
                    {
                        CourseDetailId = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        Room = c.String(),
                        CreditNumber = c.Int(nullable: false),
                        StartLeson = c.Int(nullable: false),
                        EndLesson = c.Int(nullable: false),
                        TeacherName = c.String(),
                        CourseID = c.Int(nullable: false),
                        StudentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CourseDetailId)
                .ForeignKey("dbo.Courses", t => t.CourseID, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.CourseID)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CourseID = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        StudentNumber = c.Int(nullable: false),
                        CreditNumber = c.Int(nullable: false),
                        Name = c.String(),
                        SubjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CourseID)
                .ForeignKey("dbo.Subjects", t => t.SubjectId, cascadeDelete: true)
                .Index(t => t.SubjectId);
            
            CreateTable(
                "dbo.Points",
                c => new
                    {
                        PointId = c.Int(nullable: false, identity: true),
                        RoutinePoint1 = c.Single(nullable: false),
                        RoutinePoint2 = c.Single(nullable: false),
                        RoutinePoint3 = c.Single(nullable: false),
                        MidPoint = c.Single(nullable: false),
                        FinalPoint = c.Single(nullable: false),
                        PracticePoint = c.Single(nullable: false),
                        StudentId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PointId)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        SubjectId = c.Int(nullable: false, identity: true),
                        CreditNumber = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.SubjectId);
            
            CreateTable(
                "dbo.PaymentInformations",
                c => new
                    {
                        PaymentInformationId = c.Int(nullable: false, identity: true),
                        BankName = c.String(),
                        CardType = c.String(),
                        Payer = c.Int(nullable: false),
                        Money = c.Double(nullable: false),
                        Status = c.Boolean(nullable: false),
                        StudentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PaymentInformationId)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        TeacherId = c.Int(nullable: false),
                        Avatar = c.String(),
                        Name = c.String(),
                        Email = c.String(),
                        Gender = c.Boolean(nullable: false),
                        Faculty = c.String(),
                        Phone = c.String(),
                        IdentityCardNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TeacherId)
                .ForeignKey("dbo.Accounts", t => t.TeacherId)
                .Index(t => t.TeacherId);
            
            CreateTable(
                "dbo.MessageOfTeachers",
                c => new
                    {
                        MessageId = c.Int(nullable: false, identity: true),
                        CreateDate = c.DateTime(nullable: false),
                        Content = c.String(),
                        ParentReceiver = c.Int(nullable: false),
                        TeacherId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MessageId)
                .ForeignKey("dbo.Teachers", t => t.TeacherId, cascadeDelete: true)
                .Index(t => t.TeacherId);
            
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        NotificationId = c.Int(nullable: false, identity: true),
                        CreateDate = c.DateTime(nullable: false),
                        Content = c.String(),
                        Title = c.String(),
                        Status = c.Boolean(nullable: false),
                        StudentReceiver = c.Int(nullable: false),
                        ParentReceiver = c.Int(nullable: false),
                        TeacherId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.NotificationId)
                .ForeignKey("dbo.Teachers", t => t.TeacherId, cascadeDelete: true)
                .Index(t => t.TeacherId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Notifications", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.MessageOfTeachers", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.Teachers", "TeacherId", "dbo.Accounts");
            DropForeignKey("dbo.PaymentInformations", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Parents", "StudentId", "dbo.Students");
            DropForeignKey("dbo.CourseDetails", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Courses", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.Points", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Points", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.CourseDetails", "CourseID", "dbo.Courses");
            DropForeignKey("dbo.Students", "StudentId", "dbo.Accounts");
            DropForeignKey("dbo.MessageOfParents", "ParentId", "dbo.Parents");
            DropForeignKey("dbo.Parents", "ParentId", "dbo.Accounts");
            DropForeignKey("dbo.Infomations", "AdminId", "dbo.Admins");
            DropForeignKey("dbo.Admins", "AdminId", "dbo.Accounts");
            DropIndex("dbo.Notifications", new[] { "TeacherId" });
            DropIndex("dbo.MessageOfTeachers", new[] { "TeacherId" });
            DropIndex("dbo.Teachers", new[] { "TeacherId" });
            DropIndex("dbo.PaymentInformations", new[] { "StudentId" });
            DropIndex("dbo.Points", new[] { "CourseId" });
            DropIndex("dbo.Points", new[] { "StudentId" });
            DropIndex("dbo.Courses", new[] { "SubjectId" });
            DropIndex("dbo.CourseDetails", new[] { "StudentId" });
            DropIndex("dbo.CourseDetails", new[] { "CourseID" });
            DropIndex("dbo.Students", new[] { "StudentId" });
            DropIndex("dbo.MessageOfParents", new[] { "ParentId" });
            DropIndex("dbo.Parents", new[] { "StudentId" });
            DropIndex("dbo.Parents", new[] { "ParentId" });
            DropIndex("dbo.Infomations", new[] { "AdminId" });
            DropIndex("dbo.Admins", new[] { "AdminId" });
            DropTable("dbo.Notifications");
            DropTable("dbo.MessageOfTeachers");
            DropTable("dbo.Teachers");
            DropTable("dbo.PaymentInformations");
            DropTable("dbo.Subjects");
            DropTable("dbo.Points");
            DropTable("dbo.Courses");
            DropTable("dbo.CourseDetails");
            DropTable("dbo.Students");
            DropTable("dbo.MessageOfParents");
            DropTable("dbo.Parents");
            DropTable("dbo.Infomations");
            DropTable("dbo.Admins");
            DropTable("dbo.Accounts");
        }
    }
}
