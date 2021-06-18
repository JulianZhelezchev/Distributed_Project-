namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Drivers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Age = c.Int(nullable: false),
                        TripPrice = c.Double(nullable: false),
                        PhoneNumber = c.Long(nullable: false),
                        VehicleType = c.String(),
                        VehicleBrand = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Trips",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MeetPlace = c.String(),
                        FinalDestination = c.String(),
                        Date = c.DateTime(nullable: false),
                        DistanceKms = c.Int(nullable: false),
                        TripPrice = c.Double(nullable: false),
                        Details = c.String(),
                        CreatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(),
                        UpdatedBy = c.Int(nullable: false),
                        UpdatedOn = c.DateTime(),
                        Trip_Id = c.Int(),
                        Driver_Id = c.Int(),
                        Traveller_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Trips", t => t.Trip_Id)
                .ForeignKey("dbo.Drivers", t => t.Driver_Id)
                .ForeignKey("dbo.Travellers", t => t.Traveller_Id)
                .Index(t => t.Trip_Id)
                .Index(t => t.Driver_Id)
                .Index(t => t.Traveller_Id);
            
            CreateTable(
                "dbo.Travellers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Age = c.Int(nullable: false),
                        DesiredPrice = c.Double(nullable: false),
                        PhoneNumber = c.Long(nullable: false),
                        StartDestination = c.String(),
                        EndDestination = c.String(),
                        CreatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(),
                        UpdatedBy = c.Int(nullable: false),
                        UpdatedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Trips", "Traveller_Id", "dbo.Travellers");
            DropForeignKey("dbo.Trips", "Driver_Id", "dbo.Drivers");
            DropForeignKey("dbo.Trips", "Trip_Id", "dbo.Trips");
            DropIndex("dbo.Trips", new[] { "Traveller_Id" });
            DropIndex("dbo.Trips", new[] { "Driver_Id" });
            DropIndex("dbo.Trips", new[] { "Trip_Id" });
            DropTable("dbo.Travellers");
            DropTable("dbo.Trips");
            DropTable("dbo.Drivers");
        }
    }
}
