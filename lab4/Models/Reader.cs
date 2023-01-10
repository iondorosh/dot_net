namespace lab4.Models
{
    public class Reader
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int BookId { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public Person Person { get; set; } = null!;
        public Book Book { get; set; } = null!;
    }
}
