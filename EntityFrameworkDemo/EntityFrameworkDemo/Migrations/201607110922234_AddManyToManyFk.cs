namespace EntityFrameworkDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddManyToManyFk : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Hr.EmployeeProject",
                c => new
                    {
                        EmployeeId = c.Long(nullable: false),
                        ProjectId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.EmployeeId, t.ProjectId })
                .ForeignKey("Hr.Employee", t => t.EmployeeId)
                .ForeignKey("Hr.Project", t => t.ProjectId)
                .Index(t => t.EmployeeId)
                .Index(t => t.ProjectId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Hr.EmployeeProject", "ProjectId", "Hr.Project");
            DropForeignKey("Hr.EmployeeProject", "EmployeeId", "Hr.Employee");
            DropIndex("Hr.EmployeeProject", new[] { "ProjectId" });
            DropIndex("Hr.EmployeeProject", new[] { "EmployeeId" });
            DropTable("Hr.EmployeeProject");
        }
    }
}
