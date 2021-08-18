namespace WebPhim.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateTimeCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "SinhNhat", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "SinhNhat");
        }
    }
}
