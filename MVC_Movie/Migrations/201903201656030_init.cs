namespace MVC_Movie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.actors",
                c => new
                    {
                        Actor_Id = c.Int(nullable: false, identity: true),
                        Actor_name = c.String(nullable: false),
                        Sex = c.String(nullable: false),
                        Date_Of_Birth = c.DateTime(nullable: false),
                        Bio = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Actor_Id);
            
            CreateTable(
                "dbo.movies",
                c => new
                    {
                        Movie_Id = c.Int(nullable: false, identity: true),
                        Movie_name = c.String(nullable: false),
                        Plot = c.String(nullable: false),
                        Date_Of_Release = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Movie_Id);
            
            CreateTable(
                "dbo.Movie_details",
                c => new
                    {
                        Movie_details_id = c.Int(nullable: false, identity: true),
                        Actor_Id = c.Int(nullable: false),
                        Producer_Id = c.Int(nullable: false),
                        Movie_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Movie_details_id)
                .ForeignKey("dbo.actors", t => t.Actor_Id, cascadeDelete: true)
                .ForeignKey("dbo.movies", t => t.Movie_Id, cascadeDelete: true)
                .ForeignKey("dbo.producers", t => t.Producer_Id, cascadeDelete: true)
                .Index(t => t.Actor_Id)
                .Index(t => t.Producer_Id)
                .Index(t => t.Movie_Id);
            
            CreateTable(
                "dbo.producers",
                c => new
                    {
                        Producer_Id = c.Int(nullable: false, identity: true),
                        Producer_name = c.String(nullable: false),
                        Sex = c.String(nullable: false),
                        Date_Of_Birth = c.DateTime(nullable: false),
                        Bio = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Producer_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movie_details", "Producer_Id", "dbo.producers");
            DropForeignKey("dbo.Movie_details", "Movie_Id", "dbo.movies");
            DropForeignKey("dbo.Movie_details", "Actor_Id", "dbo.actors");
            DropIndex("dbo.Movie_details", new[] { "Movie_Id" });
            DropIndex("dbo.Movie_details", new[] { "Producer_Id" });
            DropIndex("dbo.Movie_details", new[] { "Actor_Id" });
            DropTable("dbo.producers");
            DropTable("dbo.Movie_details");
            DropTable("dbo.movies");
            DropTable("dbo.actors");
        }
    }
}
