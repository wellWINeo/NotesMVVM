namespace NotesMVVM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Notes",
                c => new {
                    Id = c.Int(nullable: false, identity: true),
                    Title = c.String(),
                    Body = c.String(),
                    Date = c.DateTime(),
                })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Notes");
        }
    }
}
