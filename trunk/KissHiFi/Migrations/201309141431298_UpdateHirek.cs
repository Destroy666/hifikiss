namespace KissHiFi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateHirek : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Hirek", "Cim", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Hirek", "Cim");
        }
    }
}
