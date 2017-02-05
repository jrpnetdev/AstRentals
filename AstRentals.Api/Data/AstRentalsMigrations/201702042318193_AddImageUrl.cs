namespace AstRentals.Api.Data.AstRentalsMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImageUrl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cars", "ImageUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cars", "ImageUrl");
        }
    }
}
