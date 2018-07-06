namespace Spa.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Appointments : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        Description = c.String(maxLength: 200),
                        DateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.EmployeeId)
                .Index(t => t.CustomerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Appointments", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Appointments", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Appointments", new[] { "CustomerId" });
            DropIndex("dbo.Appointments", new[] { "EmployeeId" });
            DropTable("dbo.Appointments");
        }
    }
}
