namespace EntityFrameworkDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ForeignKeys : DbMigration
    {
        public override void Up()
        {
            AddColumn("Hr.Employee", "CommissionPct", c => c.Decimal(precision: 10, scale: 2));
            AddColumn("Hr.Employee", "DepartmentId", c => c.Long());
            AlterColumn("Hr.Department", "DepartmentName", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("Hr.Employee", "FirstName", c => c.String(maxLength: 25));
            AlterColumn("Hr.Employee", "LastName", c => c.String(nullable: false, maxLength: 25));
            AlterColumn("Hr.Employee", "PhoneNumber", c => c.String(maxLength: 25));
            AlterColumn("Hr.Employee", "JobId", c => c.Long(nullable: false));
            AlterColumn("Hr.Job", "JobTitle", c => c.String(nullable: false, maxLength: 35));
            AlterColumn("Hr.Location", "City", c => c.String(nullable: false, maxLength: 30));
            CreateIndex("Hr.Department", "LocationId");
            CreateIndex("Hr.Employee", "JobId");
            CreateIndex("Hr.Employee", "ManagerId");
            CreateIndex("Hr.Employee", "DepartmentId");
            AddForeignKey("Hr.Department", "LocationId", "Hr.Location", "LocationId");
            AddForeignKey("Hr.Employee", "DepartmentId", "Hr.Department", "DepartmentId");
            AddForeignKey("Hr.Employee", "JobId", "Hr.Job", "JobId");
            AddForeignKey("Hr.Employee", "ManagerId", "Hr.Employee", "EmployeeId");
            DropColumn("Hr.Employee", "CommisionPercent");
            DropColumn("Hr.Employee", "DepartamentId");
        }
        
        public override void Down()
        {
            AddColumn("Hr.Employee", "DepartamentId", c => c.Long());
            AddColumn("Hr.Employee", "CommisionPercent", c => c.Decimal(precision: 10, scale: 2));
            DropForeignKey("Hr.Employee", "ManagerId", "Hr.Employee");
            DropForeignKey("Hr.Employee", "JobId", "Hr.Job");
            DropForeignKey("Hr.Employee", "DepartmentId", "Hr.Department");
            DropForeignKey("Hr.Department", "LocationId", "Hr.Location");
            DropIndex("Hr.Employee", new[] { "DepartmentId" });
            DropIndex("Hr.Employee", new[] { "ManagerId" });
            DropIndex("Hr.Employee", new[] { "JobId" });
            DropIndex("Hr.Department", new[] { "LocationId" });
            AlterColumn("Hr.Location", "City", c => c.String(maxLength: 250));
            AlterColumn("Hr.Job", "JobTitle", c => c.String(maxLength: 250));
            AlterColumn("Hr.Employee", "JobId", c => c.Long());
            AlterColumn("Hr.Employee", "PhoneNumber", c => c.String(maxLength: 250));
            AlterColumn("Hr.Employee", "LastName", c => c.String(maxLength: 250));
            AlterColumn("Hr.Employee", "FirstName", c => c.String(maxLength: 250));
            AlterColumn("Hr.Department", "DepartmentName", c => c.String(maxLength: 250));
            DropColumn("Hr.Employee", "DepartmentId");
            DropColumn("Hr.Employee", "CommissionPct");
        }
    }
}
