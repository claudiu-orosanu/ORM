namespace EntityFrameworkDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameTables : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Departments", newName: "Department");
            RenameTable(name: "dbo.Employees", newName: "Employee");
            RenameTable(name: "dbo.Jobs", newName: "Job");
            RenameTable(name: "dbo.Locations", newName: "Location");
            MoveTable(name: "dbo.Department", newSchema: "Hr");
            MoveTable(name: "dbo.Employee", newSchema: "Hr");
            MoveTable(name: "dbo.Job", newSchema: "Hr");
            MoveTable(name: "dbo.Location", newSchema: "Hr");
        }
        
        public override void Down()
        {
            MoveTable(name: "Hr.Location", newSchema: "dbo");
            MoveTable(name: "Hr.Job", newSchema: "dbo");
            MoveTable(name: "Hr.Employee", newSchema: "dbo");
            MoveTable(name: "Hr.Department", newSchema: "dbo");
            RenameTable(name: "dbo.Location", newName: "Locations");
            RenameTable(name: "dbo.Job", newName: "Jobs");
            RenameTable(name: "dbo.Employee", newName: "Employees");
            RenameTable(name: "dbo.Department", newName: "Departments");
        }
    }
}
