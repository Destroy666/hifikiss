namespace KissHiFi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TermekKategoria", "RouteNev", c => c.String(nullable: false));
            AddColumn("dbo.TermekAdatlap", "RouteNev", c => c.String(nullable: false));
            AddColumn("dbo.TermekMarka", "RouteNev", c => c.String(nullable: false));
            AlterColumn("dbo.Hirek", "Tartalom", c => c.String(nullable: false));
            AlterColumn("dbo.Bemutatkozas", "Tartalom", c => c.String(nullable: false));
            AlterColumn("dbo.Szolgaltatas", "Tevekenyseg", c => c.String(nullable: false));
            AlterColumn("dbo.Szolgaltatas", "Szerviz", c => c.String(nullable: false));
            AlterColumn("dbo.Szolgaltatas", "Hangositas", c => c.String(nullable: false));
            AlterColumn("dbo.TermekKategoria", "Nev", c => c.String(nullable: false));
            AlterColumn("dbo.TermekKategoria", "Kep", c => c.String(nullable: false));
            AlterColumn("dbo.TermekAdatlap", "Tipus", c => c.String(nullable: false));
            AlterColumn("dbo.TermekAdatlap", "Ar", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.TermekAdatlap", "Allapot", c => c.Int(nullable: false));
            AlterColumn("dbo.TermekMarka", "Nev", c => c.String(nullable: false));
            AlterColumn("dbo.TermekMarka", "Kep", c => c.String(nullable: false));
            AlterColumn("dbo.Kepek", "FajlNev", c => c.String(nullable: false));
            AlterColumn("dbo.Elerhetoseg", "Tartalom", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Elerhetoseg", "Tartalom", c => c.String());
            AlterColumn("dbo.Kepek", "FajlNev", c => c.String());
            AlterColumn("dbo.TermekMarka", "Kep", c => c.String());
            AlterColumn("dbo.TermekMarka", "Nev", c => c.String());
            AlterColumn("dbo.TermekAdatlap", "Allapot", c => c.Int());
            AlterColumn("dbo.TermekAdatlap", "Ar", c => c.Int(nullable: false));
            AlterColumn("dbo.TermekAdatlap", "Tipus", c => c.String());
            AlterColumn("dbo.TermekKategoria", "Kep", c => c.String());
            AlterColumn("dbo.TermekKategoria", "Nev", c => c.String());
            AlterColumn("dbo.Szolgaltatas", "Hangositas", c => c.String());
            AlterColumn("dbo.Szolgaltatas", "Szerviz", c => c.String());
            AlterColumn("dbo.Szolgaltatas", "Tevekenyseg", c => c.String());
            AlterColumn("dbo.Bemutatkozas", "Tartalom", c => c.String());
            AlterColumn("dbo.Hirek", "Tartalom", c => c.String());
            DropColumn("dbo.TermekMarka", "RouteNev");
            DropColumn("dbo.TermekAdatlap", "RouteNev");
            DropColumn("dbo.TermekKategoria", "RouteNev");
        }
    }
}
