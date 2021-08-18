namespace WebPhim.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGenre : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT GenreMovies ON");
            Sql("INSERT INTO GenreMovies (Id, Name) VALUES (1, 'Action')");
            Sql("INSERT INTO GenreMovies (Id, Name) VALUES (2, 'Thriller') ");
            Sql("INSERT INTO GenreMovies (Id, Name) VALUES (3, 'Family')");
            Sql("INSERT INTO GenreMovies (Id, Name) VALUES (4, 'Romance')");
            Sql("INSERT INTO GenreMovies (Id, Name) VALUES (5, 'Comedy')");
        }
        
        public override void Down()
        {
        }
    }
}
