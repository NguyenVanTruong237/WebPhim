namespace WebPhim.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNameMembershipType : DbMigration
    {
        public override void Up()
        {
            Sql(" UPDATE MembershipTypes SET Name = 'Khách Hàng' WHERE Id = 0 ");
            Sql(" UPDATE MembershipTypes SET Name = 'MEMBER THÁNG' WHERE Id = 1 ");
            Sql(" UPDATE MembershipTypes SET Name = 'MEMBER 3 THÁNG' WHERE Id = 3 ");
            Sql(" UPDATE MembershipTypes SET Name = 'MEMBER NĂM' WHERE Id = 12 ");
        }
        
        public override void Down()
        {
        }
    }
}
