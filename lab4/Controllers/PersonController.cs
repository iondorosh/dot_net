using lab4.Models;
using Microsoft.AspNetCore.Mvc;

namespace lab4.Controllers
{
    public class PersonController : Controller
    {
        ReadersContext _context;
        public PersonController(ReadersContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<Person> persons = _context.Persons;
            return View(persons);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Person person)
        {

            if (ModelState.IsValid)
            {
                await _context.Persons.AddAsync(person);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(person);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _context.Persons.FindAsync(id);

            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Person person)
        {
            if (ModelState.IsValid)
            {
                _context.Persons.Update(person);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(person);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _context.Persons.FindAsync(id);

            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteP(int? id)
        {
            var person = await _context.Persons.FindAsync(id);

            if (person == null)
            {
                return NotFound(); 
            }

            _context.Persons.Remove(person);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
