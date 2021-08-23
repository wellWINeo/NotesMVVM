namespace NotesMVVM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Notes", "Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Notes", "Date");
        }
    }
}
