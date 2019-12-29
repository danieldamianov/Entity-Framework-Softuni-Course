namespace BookShop
{
    using Data;
    //using Initializer;
    using Models.Enums;
    using System.Linq;
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Globalization;
    using BookShop.Models;

    public class StartUp
    {
        public static void Main()
        {
            using (var db = new BookShopContext())
            {
                //DbInitializer.ResetDatabase(db);
                string command = System.Console.ReadLine();
                Console.WriteLine(RemoveBooks(db)); 
            }
        }
//        Return in a single string titles of the golden edition books that have less than 5000 copies, each on a new line.
//Order them by book id ascending.
        public static string GetGoldenBooks(BookShopContext context)
        {
            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
            List<string> titles = context.Books
                .Where(b => b.EditionType == EditionType.Gold)
                .Where(b => b.Copies < 5000)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToList();
            stringBuilder.Append(string.Join(Environment.NewLine, titles));
            return stringBuilder.ToString();
        }

        public static string GetBooksByAgeRestriction(BookShopContext context,string command)
        {
            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
            System.Collections.Generic.List<string> bookTitles = context.Books
                .Where(b => b.AgeRestriction == Enum.Parse<AgeRestriction>(command, true))
                .Select(b => b.Title)
                .OrderBy(t => t)
                .ToList();
            stringBuilder.Append(string.Join(Environment.NewLine,bookTitles));
            return stringBuilder.ToString();
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
            System.Collections.Generic.List<string> bookTitlesAndPrices = context.Books
                .Where(b => b.Price > 40)
                .OrderByDescending(b => b.Price)
                .Select(b => $"{b.Title} - ${b.Price:f2}")
                .ToList();
            stringBuilder.Append(string.Join(Environment.NewLine, bookTitlesAndPrices));
            return stringBuilder.ToString();
        }
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
            System.Collections.Generic.List<string> bookTitles = context.Books
                .Where(b => b.ReleaseDate != null && b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => $"{b.Title}")
                .ToList();
            stringBuilder.Append(string.Join(Environment.NewLine, bookTitles));
            return stringBuilder.ToString();
        }
//        Return in a single string the titles of books by a given list of categories.The list of categories will be given in a single
//line separated with one or more spaces.Ignore casing.Order by title alphabetically.
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            string[] categories = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(c => c.ToLower()).ToArray();
            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
            
            System.Collections.Generic.List<string> bookTitles = context.Books.ToArray()
                .Where(b => b.BookCategories.Select(bc => bc.Category.Name.ToLower()).ToList().Any(c => categories.Contains(c)))
                .OrderBy(b => b.Title)
                .Select(b => $"{b.Title}")
                .ToList();
            stringBuilder.Append(string.Join(Environment.NewLine, bookTitles));
            return stringBuilder.ToString();
        }
//        Return the title, edition type and price of all books that are released before a given date.The date will be a string in
//format dd-MM-yyyy.

//© Software University Foundation.This work is licensed under the CC-BY-NC-SA license.
//Follow us: Page 6 of 6

//Return all of the rows in a single string, ordered by release date descending.
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            DateTime expDate = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();

            System.Collections.Generic.List<string> bookInfo = context.Books
                .Where(b => b.ReleaseDate < expDate)
                .OrderByDescending(b => b.ReleaseDate)
                .Select(b => $"{b.Title} - {b.EditionType} - ${b.Price:f2}")
                .ToList();
            stringBuilder.Append(string.Join(Environment.NewLine, bookInfo));
            return stringBuilder.ToString();
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();

            System.Collections.Generic.List<string> authorNames = context.Authors
                .Where(a => a.FirstName.EndsWith(input.ToLower()))
                .OrderBy(a => a.FirstName)
                .ThenBy(a => a.LastName)
                .Select(a => a.FirstName + " " + a.LastName)
                .ToList();
            stringBuilder.Append(string.Join(Environment.NewLine, authorNames));
            return stringBuilder.ToString();
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();

            System.Collections.Generic.List<string> booksTitles = context.Books
                .Where(a => a.Title.ToLower().Contains(input.ToLower()))
                .OrderBy(a => a.Title)
                .Select(a => a.Title)
                .ToList();
            stringBuilder.Append(string.Join(Environment.NewLine, booksTitles));
            return stringBuilder.ToString();
        }

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();

            System.Collections.Generic.List<string> booksTitlesAuthorNames = context.Books
                .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .OrderBy(b => b.BookId)
                .Select(b => $"{b.Title} ({b.Author.FirstName} {b.Author.LastName})")
                .ToList();
            stringBuilder.Append(string.Join(Environment.NewLine, booksTitlesAuthorNames));
            return stringBuilder.ToString();
            //            Return all titles of books and their authors’ names for books, which are written by authors whose last names start
            //with the given string.
            //Return a single string with each title on a new row.Ignore casing.Order by book id ascending.
        }
        //private static List<string> GetBookCategories(Models.Book b)
        //{
        //    return b.BookCategories.Select(bc => bc.Category.Name.ToLower()).ToList();
        //}
        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            return context.Books.Select(b => b.Title).Where(t => t.Length > lengthCheck).ToArray().Count();
        }
        public static string CountCopiesByAuthor(BookShopContext context)
        { 
            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();

            List<string> authorsBookCopies = context.Authors
                .Select(a => new
                {
                    a.FirstName, a.LastName, bookCopies = a.Books.Sum(b => b.Copies)
                })
                .OrderByDescending(a => a.bookCopies)
                .Select(a => $"{a.FirstName} {a.LastName} - {a.bookCopies}")
                .ToList();
            stringBuilder.Append(string.Join(Environment.NewLine, authorsBookCopies));
            return stringBuilder.ToString();
//        {
//            Return the total number of book copies for each author. Order the results descending by total book copies.
//Return all results in a single string, each on a new line.
        }
        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            //            Return the total profit of all books by category.Profit for a book can be calculated by multiplying its number of
            //copies by the price per single book.Order the results by descending by total profit for category and ascending by
            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
            //category name.
            List<string> categoryProfits = context.Categories
                .Select(c => new
                {   
                    c.Name,profit = c.CategoryBooks.Select(cb => cb.Book).Sum(b => b.Price * b.Copies)
                })
                .OrderByDescending(cp => cp.profit)
                .ThenBy(cp => cp.Name)
                .Select(cp => $"{cp.Name} ${cp.profit:f2}")
                .ToList();

            stringBuilder.Append(string.Join(Environment.NewLine, categoryProfits));
            return stringBuilder.ToString();

        }

        public static string GetMostRecentBooks(BookShopContext context)
        {
//            Get the most recent books by categories.The categories should be ordered by name alphabetically. Only take the
//top 3 most recent books from each category -ordered by release date(descending).Select and print the category
//name, and for each book – its title and release year.
            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();

            List<string> categoryProfits = context.Categories
                .Select(c => new
                {
                    c.Name,
                    books = c.CategoryBooks.Select(cb => cb.Book).OrderByDescending(b => b.ReleaseDate).Take(3).Select(b => new
                    {
                        b.Title,b.ReleaseDate.Value.Year
                    }).ToList()
                })
                .OrderBy(cp => cp.Name)
                .Select(a => $"--{a.Name}{Environment.NewLine}{string.Join(Environment.NewLine,a.books.Select(b => $"{b.Title} ({b.Year})"))}")
                .ToList();

            stringBuilder.Append(string.Join(Environment.NewLine, categoryProfits));
            return stringBuilder.ToString();
        }

        public static void IncreasePrices(BookShopContext context)
        {
            context.Books.Where(b => b.ReleaseDate.Value.Year < 2010).Update(b => new Book { Price = b.Price + 5});
            context.SaveChanges();
        }
        public static int RemoveBooks(BookShopContext context)
        {
            //            Remove all books, which have less than 4200 copies.Return an int -the number of books that were deleted from
            //the database.
            List<Book> booksToRemove = context.Books.Where(b => b.Copies < 4200).ToList();
            booksToRemove.ForEach(b => context.Books.Remove(b));
            context.SaveChanges();
            return booksToRemove.Count();
        }
    }
   
}