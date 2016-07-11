namespace EntityFrameworkDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateProcedureChangeManager : DbMigration
    {
        public override void Up()
        {
            Sql(@"IF EXISTS (SELECT * FROM sys.procedures WHERE name='ChangeManager')
	                DROP PROCEDURE [Hr].[ChangeManager]
                GO
                CREATE PROCEDURE Hr.ChangeManager (@NewManagerId int)
                AS
                BEGIN
                DECLARE @OldManagerId INT 
                SET @OldManagerId = (SELECT ManagerID from Hr.Employee WHERE EmployeeId = @NewManagerId)
                UPDATE Hr.Employee SET ManagerId = @NewManagerId WHERE EmployeeId = @OldManagerId
                UPDATE Hr.Employee SET ManagerId = null WHERE EmployeeId = @NewManagerId
                UPDATE Hr.Employee SET ManagerId = @NewManagerId WHERE ManagerId = @OldManagerId
                END
                GO");
        }
        
        public override void Down()
        {
            Sql(@"IF EXISTS (SELECT * FROM sys.procedures WHERE name='ChangeManager')
                DROP PROCEDURE[Hr].[ChangeManager]
                GO");
        }
    }
}
