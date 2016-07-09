namespace EntityFrameworkDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DepartmentId = c.Long(nullable: false, identity: true),
                        DepartmentName = c.String(maxLength: 250),
                        LocationId = c.Long(),
                    })
                .PrimaryKey(t => t.DepartmentId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.Long(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 250),
                        LastName = c.String(maxLength: 250),
                        Email = c.String(maxLength: 250),
                        PhoneNumber = c.String(maxLength: 250),
                        Salary = c.Decimal(nullable: false, precision: 10, scale: 2),
                        CommisionPercent = c.Decimal(precision: 10, scale: 2),
                        HireDate = c.DateTime(nullable: false),
                        JobId = c.Long(),
                        ManagerId = c.Long(),
                        DepartamentId = c.Long(),
                    })
                .PrimaryKey(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Jobs",
                c => new
                    {
                        JobId = c.Long(nullable: false, identity: true),
                        JobTitle = c.String(maxLength: 250),
                        MinSalary = c.Decimal(precision: 10, scale: 2),
                        MaxSalary = c.Decimal(precision: 10, scale: 2),
                    })
                .PrimaryKey(t => t.JobId);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        LocationId = c.Long(nullable: false, identity: true),
                        StreetAddress = c.String(maxLength: 250),
                        PostalCode = c.String(maxLength: 250),
                        City = c.String(maxLength: 250),
                        StateProvince = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.LocationId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Locations");
            DropTable("dbo.Jobs");
            DropTable("dbo.Employees");
            DropTable("dbo.Departments");
        }
    }
}
