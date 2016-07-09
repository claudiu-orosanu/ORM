namespace EntityFrameworkDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MailUnique : DbMigration
    {
        public override void Up()
        {
            AlterColumn("Hr.Employee", "Email", c => c.String(nullable: false, maxLength: 35));
            CreateIndex("Hr.Employee", "Email", unique: true, name: "UX_Email");
        }
        
        public override void Down()
        {
            DropIndex("Hr.Employee", "UX_Email");
            AlterColumn("Hr.Employee", "Email", c => c.String(maxLength: 250));
        }
    }
}
