namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddsMovieGenreType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        MovieGenreTypeId = c.Byte(nullable: false),
                        ReleaseDate = c.DateTime(nullable: false),
                        DateAdded = c.DateTime(nullable: false),
                        NumberInStock = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MovieGenreTypes", t => t.MovieGenreTypeId, cascadeDelete: true)
                .Index(t => t.MovieGenreTypeId);
            
            CreateTable(
                "dbo.MovieGenreTypes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);

            Sql(@"INSERT INTO MovieGenreTypes (Id, Name) values (1, 'Comedy')");
            Sql(@"INSERT INTO MovieGenreTypes (Id, Name) values (2, 'Action')");
            Sql(@"INSERT INTO MovieGenreTypes (Id, Name) values (3, 'Family')");
            Sql(@"INSERT INTO MovieGenreTypes (Id, Name) values (4, 'Romance')");

        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "MovieGenreTypeId", "dbo.MovieGenreTypes");
            DropIndex("dbo.Movies", new[] { "MovieGenreTypeId" });
            DropTable("dbo.MovieGenreTypes");
            DropTable("dbo.Movies");
        }
    }
}
