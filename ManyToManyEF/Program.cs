// See https://aka.ms/new-console-template for more information

using ManyToManyEF;
using ManyToManyEF.Entity;

Console.WriteLine("Hello, World!");
using (AppDbContext appDbContext = new AppDbContext())
{
    Book book = new Book();
    book.Name = "TestBook";

    Genre genre = new Genre();
    genre.Name = "TestGenre";
    
    appDbContext.Books.Add(book);
    appDbContext.SaveChanges();
    
    appDbContext.Genres.Add(genre);
    appDbContext.SaveChanges();
    
    Book queryBook = appDbContext.Books.First();
    Genre queryGenre = appDbContext.Genres.First();
    
    queryBook.Genres = new List<Genre>();
    queryBook.Genres.Add(queryGenre);
    appDbContext.SaveChanges();
    
}