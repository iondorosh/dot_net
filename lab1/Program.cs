using System;
using System.Data.SqlClient;
using System.Configuration;
namespace Library
{
    internal class Program
    {
         static async Task Main(string[] args)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaulConnection"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString.ToString());
            await conn.OpenAsync();
            SqlCommand cmd = new SqlCommand("select persons.name as personName, books.name as bookName," +
                "issueDate,returnDate from readers inner join persons on readers.personId=persons.id " +
                "inner join books on readers.bookId=books.id", conn);
            SqlDataReader dr = await cmd.ExecuteReaderAsync();
            Console.WriteLine("{0,-30} {1,-15} {2,-20} {3,-15}\n", "Person", "Book", "Date of issue", "Date return");
            while (dr.Read())
            {
                string personName = dr["personName"].ToString();
                string bookName = dr["bookName"].ToString();
                string dateIssue = dr["issueDate"].ToString();
                string dateReturn = dr["returnDate"].ToString();
                Console.WriteLine("{0,-30} {1,-15} {2,-20} {3,-15}", personName, bookName, dateIssue, dateReturn);
            }
            dr.Close();
            conn.Close();
            Console.Read();
        }
    }
}
