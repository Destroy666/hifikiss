namespace KissHiFi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Hirek",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Datum = c.DateTime(nullable: false),
                        Tartalom = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Bemutatkozas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tartalom = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Szolgaltatas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tevekenyseg = c.String(),
                        Szerviz = c.String(),
                        Hangositas = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TermekKategoria",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nev = c.String(),
                        Kep = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TermekAdatlap",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tipus = c.String(),
                        Kep = c.String(),
                        Ar = c.Int(nullable: false),
                        TechInfo = c.String(),
                        Allapot = c.Int(),
                        TermekMarkaId = c.Int(nullable: false),
                        TermekKategoriaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TermekMarka", t => t.TermekMarkaId, cascadeDelete: true)
                .ForeignKey("dbo.TermekKategoria", t => t.TermekKategoriaId, cascadeDelete: true)
                .Index(t => t.TermekMarkaId)
                .Index(t => t.TermekKategoriaId);
            
            CreateTable(
                "dbo.TermekMarka",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nev = c.String(),
                        Kep = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Kepek",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FajlNev = c.String(),
                        Cim = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Elerhetoseg",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tartalom = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.TermekAdatlap", new[] { "TermekKategoriaId" });
            DropIndex("dbo.TermekAdatlap", new[] { "TermekMarkaId" });
            DropForeignKey("dbo.TermekAdatlap", "TermekKategoriaId", "dbo.TermekKategoria");
            DropForeignKey("dbo.TermekAdatlap", "TermekMarkaId", "dbo.TermekMarka");
            DropTable("dbo.Elerhetoseg");
            DropTable("dbo.Kepek");
            DropTable("dbo.TermekMarka");
            DropTable("dbo.TermekAdatlap");
            DropTable("dbo.TermekKategoria");
            DropTable("dbo.Szolgaltatas");
            DropTable("dbo.Bemutatkozas");
            DropTable("dbo.Hirek");
        }
    }
}
