using lab4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace lab4.Controllers
{
    public class ReaderController : Controller
    {
        ReadersContext _context;
        public ReaderController(ReadersContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<Reader> readers = _context.Readers.Include(prop => prop.Person).Include(prop => prop.Book);
            return View(readers);
        }

        public IActionResult Create()
        {
            ViewBag.Persons = new SelectList(_context.Persons, "Id", "Name");
            ViewBag.Books = new SelectList(_context.Books, "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Reader reader)
        {
            if (reader.PersonId != 0 && reader.BookId != 0)
            {
                await _context.Readers.AddAsync(reader);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Persons = new SelectList(_context.Persons, "Id", "Name");
            ViewBag.Books = new SelectList(_context.Books, "Id", "Name");

            return View(reader);
        }


        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reader = _context.Readers.Include(p => p.Person).Include(p => p.Book).First(p => p.Id == id);

            if (reader == null)
            {
                return NotFound();
            }

            return View(reader);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteP(int? id)
        {
            var reader = await _context.Readers.FindAsync(id);

            if (reader == null)
            {
                return NotFound();
            }
            _context.Readers.Remove(reader);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
