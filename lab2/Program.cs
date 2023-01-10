using System;
namespace lab_2_library
{
    public class Program
    {
        public static void Main(string[] ars)
        {
            using (ReadersContext db = new ReadersContext())
            {
                var readers = from reader in db.Readers
                              join person in db.Persons on reader.PersonId equals person.Id
                              join book in db.Books on reader.BookId equals book.Id
                              select new
                              {
                                  Person = person.Name,
                                  Book = book.Name,
                                  IssueDate = reader.IssueDate,
                                  ReturnDate = reader.ReturnDate,
                              };
                Console.WriteLine("{0,-30} {1,-15} {2,-20} {3,-15}\n", "Person", "Book", "Date of issue", "Date return");
                foreach (var reader in readers)
                {
                    Console.WriteLine("{0,-30} {1,-15} {2,-20} {3,-15}", reader.Person, reader.Book, reader.IssueDate, reader.ReturnDate);
                }
            }
            Console.Read();
        }
    }
}