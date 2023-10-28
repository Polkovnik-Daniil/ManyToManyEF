// See https://aka.ms/new-console-template for more information

using ManyToManyEF;
using ManyToManyEF.Entity;

Console.WriteLine("Hello, World!");
using (AppDbContext appDbContext = new AppDbContext())
{
    //Insert 
    Genre genre_insert = new Genre();
    genre_insert.Name = Guid.NewGuid().GetHashCode().ToString();
    appDbContext.Genres.Add(genre_insert);
    appDbContext.SaveChanges();

    Book book_insert = new Book();
    book_insert.Name = Guid.NewGuid().GetHashCode().ToString();
    book_insert.Genres = new List<Genre>();
    book_insert.Genres.Add(new Genre() { Name = genre_insert.Name }); 
    appDbContext.Books.Add(book_insert);//error т.к. раньше данная информация уже была добавлена
    appDbContext.SaveChanges();

    //Update
    Book book_update = new Book();
    book_update.Name = Guid.NewGuid().GetHashCode().ToString();

    Genre genre_update = new Genre();
    genre_update.Name = Guid.NewGuid().GetHashCode().ToString();
    
    appDbContext.Books.Add(book_update);
    appDbContext.SaveChanges();
    
    appDbContext.Genres.Add(genre_update);
    appDbContext.SaveChanges();
    
    Book queryBook = appDbContext.Books.First();
    Genre queryGenre = appDbContext.Genres.First();
    
    queryBook.Genres = new List<Genre>();
    queryBook.Genres.Add(queryGenre);
    appDbContext.SaveChanges();    
}