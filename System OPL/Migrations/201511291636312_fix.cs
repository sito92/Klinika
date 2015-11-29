namespace System_OPL
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fix : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContactDatas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        City = c.String(),
                        FlatNumber = c.Int(nullable: false),
                        Street = c.String(),
                        HomeNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.HealthStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Patients", "ContactDataId", c => c.Int(nullable: false));
            AddColumn("dbo.Patients", "HealthStatusId", c => c.Int(nullable: false));
            AlterColumn("dbo.Patients", "Name", c => c.String());
            AlterColumn("dbo.Patients", "Surname", c => c.String());
            AddForeignKey("dbo.Patients", "ContactDataId", "dbo.ContactDatas", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Patients", "HealthStatusId", "dbo.HealthStatus", "Id", cascadeDelete: true);
            CreateIndex("dbo.Patients", "ContactDataId");
            CreateIndex("dbo.Patients", "HealthStatusId");
            DropColumn("dbo.Patients", "ContactData");
            DropColumn("dbo.Patients", "HealthStatus");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Patients", "HealthStatus", c => c.String(nullable: false));
            AddColumn("dbo.Patients", "ContactData", c => c.String(nullable: false));
            DropIndex("dbo.Patients", new[] { "HealthStatusId" });
            DropIndex("dbo.Patients", new[] { "ContactDataId" });
            DropForeignKey("dbo.Patients", "HealthStatusId", "dbo.HealthStatus");
            DropForeignKey("dbo.Patients", "ContactDataId", "dbo.ContactDatas");
            AlterColumn("dbo.Patients", "Surname", c => c.String(nullable: false));
            AlterColumn("dbo.Patients", "Name", c => c.String(nullable: false));
            DropColumn("dbo.Patients", "HealthStatusId");
            DropColumn("dbo.Patients", "ContactDataId");
            DropTable("dbo.HealthStatus");
            DropTable("dbo.ContactDatas");
        }
    }
}
