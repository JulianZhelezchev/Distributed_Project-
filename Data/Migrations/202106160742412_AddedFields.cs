namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedFields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Drivers", "CreatedBy", c => c.Int(nullable: false));
            AddColumn("dbo.Drivers", "CreatedOn", c => c.DateTime());
            AddColumn("dbo.Drivers", "UpdatedBy", c => c.Int(nullable: false));
            AddColumn("dbo.Drivers", "UpdatedOn", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Drivers", "UpdatedOn");
            DropColumn("dbo.Drivers", "UpdatedBy");
            DropColumn("dbo.Drivers", "CreatedOn");
            DropColumn("dbo.Drivers", "CreatedBy");
        }
    }
}
