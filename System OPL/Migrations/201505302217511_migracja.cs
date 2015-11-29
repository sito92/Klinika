namespace System_OPL
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migracja : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        Surname = c.String(nullable: false),
                        ContactData = c.String(nullable: false),
                        OfficeNumber = c.Int(nullable: false),
                        WorkHourId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.WorkHours", t => t.WorkHourId, cascadeDelete: true)
                .Index(t => t.WorkHourId);
            
            CreateTable(
                "dbo.WorkHours",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        StartHour = c.Int(nullable: false),
                        StopHour = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Surname = c.String(nullable: false),
                        ContactData = c.String(nullable: false),
                        HealthStatus = c.String(nullable: false),
                        DoctorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Doctors", t => t.DoctorId, cascadeDelete: true)
                .Index(t => t.DoctorId);
            
            CreateTable(
                "dbo.Infants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HealthStatus = c.String(nullable: false),
                        MotherId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Patients", t => t.MotherId, cascadeDelete: true)
                .Index(t => t.MotherId);
            
            CreateTable(
                "dbo.Tests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(nullable: false),
                        Date = c.DateTime(nullable: false),
                        StartHour = c.DateTime(nullable: false),
                        ObjectId = c.Int(nullable: false),
                        DoctorId = c.Int(nullable: false),
                        NurseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Patients", t => t.ObjectId, cascadeDelete: true)
                .ForeignKey("dbo.Doctors", t => t.DoctorId, cascadeDelete: false)
                .ForeignKey("dbo.Nurses", t => t.NurseId, cascadeDelete: true)
                .Index(t => t.ObjectId)
                .Index(t => t.DoctorId)
                .Index(t => t.NurseId);
            
            CreateTable(
                "dbo.Nurses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        Surname = c.String(nullable: false),
                        ContactData = c.String(nullable: false),
                        OfficeNumber = c.Int(nullable: false),
                        WorkHourId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.WorkHours", t => t.WorkHourId, cascadeDelete: false)
                .Index(t => t.WorkHourId);
            
            CreateTable(
                "dbo.Supplies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        WOSP = c.Boolean(nullable: false),
                        Test_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tests", t => t.Test_Id)
                .Index(t => t.Test_Id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Supplies", new[] { "Test_Id" });
            DropIndex("dbo.Nurses", new[] { "WorkHourId" });
            DropIndex("dbo.Tests", new[] { "NurseId" });
            DropIndex("dbo.Tests", new[] { "DoctorId" });
            DropIndex("dbo.Tests", new[] { "ObjectId" });
            DropIndex("dbo.Infants", new[] { "MotherId" });
            DropIndex("dbo.Patients", new[] { "DoctorId" });
            DropIndex("dbo.Doctors", new[] { "WorkHourId" });
            DropForeignKey("dbo.Supplies", "Test_Id", "dbo.Tests");
            DropForeignKey("dbo.Nurses", "WorkHourId", "dbo.WorkHours");
            DropForeignKey("dbo.Tests", "NurseId", "dbo.Nurses");
            DropForeignKey("dbo.Tests", "DoctorId", "dbo.Doctors");
            DropForeignKey("dbo.Tests", "ObjectId", "dbo.Patients");
            DropForeignKey("dbo.Infants", "MotherId", "dbo.Patients");
            DropForeignKey("dbo.Patients", "DoctorId", "dbo.Doctors");
            DropForeignKey("dbo.Doctors", "WorkHourId", "dbo.WorkHours");
            DropTable("dbo.Supplies");
            DropTable("dbo.Nurses");
            DropTable("dbo.Tests");
            DropTable("dbo.Infants");
            DropTable("dbo.Patients");
            DropTable("dbo.WorkHours");
            DropTable("dbo.Doctors");
        }
    }
}
