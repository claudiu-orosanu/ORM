namespace EntityFrameworkDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNomenclatures : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Nom.Gender",
                c => new
                    {
                        GenderId = c.Long(nullable: false, identity: true),
                        Name = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.GenderId);
            
            CreateTable(
                "Nom.Level",
                c => new
                    {
                        LevelId = c.Long(nullable: false, identity: true),
                        Name = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.LevelId);
            
            AddColumn("Hr.Employee", "LevelId", c => c.Long());
            AddColumn("Hr.Employee", "GenderId", c => c.Long());
            CreateIndex("Hr.Employee", "LevelId");
            CreateIndex("Hr.Employee", "GenderId");
            AddForeignKey("Hr.Employee", "GenderId", "Nom.Gender", "GenderId");
            AddForeignKey("Hr.Employee", "LevelId", "Nom.Level", "LevelId");
        }
        
        public override void Down()
        {
            DropForeignKey("Hr.Employee", "LevelId", "Nom.Level");
            DropForeignKey("Hr.Employee", "GenderId", "Nom.Gender");
            DropIndex("Hr.Employee", new[] { "GenderId" });
            DropIndex("Hr.Employee", new[] { "LevelId" });
            DropColumn("Hr.Employee", "GenderId");
            DropColumn("Hr.Employee", "LevelId");
            DropTable("Nom.Level");
            DropTable("Nom.Gender");
        }
    }
}
