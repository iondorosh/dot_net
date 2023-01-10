using lab3.Models;
using lab3.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace lab3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly PersonsService _personsService;

        public PersonsController(PersonsService personsService) =>
            _personsService = personsService;

        [HttpGet]
        public async Task<List<Person>> Get() =>
            await _personsService.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Person>> Get(int id)
        {
            var person = await _personsService.GetAsync(id);

            if (person is null)
            {
                return NotFound();
            }

            return person;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Person person)
        {
            await _personsService.CreateAsync(person);

            return CreatedAtAction(nameof(Get), new { id = person.Id }, person);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(int id, Person updatePerson)
        {
            var person = await _personsService.GetAsync(id);

            if (person is null)
            {
                return NotFound();
            }

            updatePerson.Id = person.Id;

            await _personsService.UpdateAsync(id, updatePerson);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(int id)
        {
            var person = await _personsService.GetAsync(id);

            if (person is null)
            {
                return NotFound();
            }

            await _personsService.RemoveAsync(id);

            return NoContent();
        }
    }
}
