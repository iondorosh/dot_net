namespace lab4.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public DateTime Birthday { get; set; }
        public int TicketNumber { get; set; }
    }
}
