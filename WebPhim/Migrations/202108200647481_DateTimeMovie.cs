namespace WebPhim.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateTimeMovie : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "RealeaseDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Movies", "DateAdded", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "DateAdded", c => c.DateTime());
            AlterColumn("dbo.Movies", "RealeaseDate", c => c.DateTime());
        }
    }
}
