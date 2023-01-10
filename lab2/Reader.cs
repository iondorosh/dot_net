using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_2_library
{
    public class Reader
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int BookId { get; set; }
        public DateTime IssueDate  { get; set; }
        public DateTime ReturnDate { get; set; }
        public Person Person { get; set; }
        public Book Book { get; set; }

    }
}
