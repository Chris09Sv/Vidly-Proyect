namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMoviesP : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Movies(Name,Genre,Release_Date,Date_Add,Stock)values('Iron Man 2','Action',26-04-2010,30-09-2015,10 ) ");
            Sql("INSERT INTO Movies(Name,Genre,Release_Date,Date_Add,Stock)values('Iron Man 3','Action',20-12-2014,30-02-2016,10 ) ");
            Sql("INSERT INTO Movies(Name,Genre,Release_Date,Date_Add,Stock)values('Avengers','Action',26-04-2010,30-09-2015,9 ) ");
            Sql("INSERT INTO Movies(Name,Genre,Release_Date,Date_Add,Stock)values('HULK','Action',26-04-2005,30-12-2012,10 ) ");

        }

        public override void Down()
        {
        }
    }
}
