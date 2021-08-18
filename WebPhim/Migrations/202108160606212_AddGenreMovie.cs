namespace WebPhim.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGenreMovie : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GenreMovies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Movies", "GenreMovieId", c => c.Int(nullable: false));
            CreateIndex("dbo.Movies", "GenreMovieId");
            AddForeignKey("dbo.Movies", "GenreMovieId", "dbo.GenreMovies", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "GenreMovieId", "dbo.GenreMovies");
            DropIndex("dbo.Movies", new[] { "GenreMovieId" });
            DropColumn("dbo.Movies", "GenreMovieId");
            DropTable("dbo.GenreMovies");
        }
    }
}
