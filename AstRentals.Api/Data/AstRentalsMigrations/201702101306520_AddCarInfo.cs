namespace AstRentals.Api.Data.AstRentalsMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCarInfo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CarInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Make = c.String(),
                        Model = c.String(),
                        Info = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CarInfoes");
        }
    }
}
