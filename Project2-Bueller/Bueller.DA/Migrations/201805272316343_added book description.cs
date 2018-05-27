namespace Bueller.DA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedbookdescription : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "BookDescription", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "BookDescription");
        }
    }
}
