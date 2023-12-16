using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestProject.Model;

namespace TestProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly List<DataClass> _items = new List<DataClass>()
    {
        new DataClass { Id = 1, Name = "DataClass 1" },
        new DataClass { Id = 2, Name = "DataClass 2" },
        new DataClass { Id = 3, Name = "DataClass 3" }
    };

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_items);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var item = _items.Find(i => i.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPost]
        public IActionResult Post(DataClass newItem)
        {
            _items.Add(newItem);
            return CreatedAtAction(nameof(Get), new { id = newItem.Id }, newItem);
        }

    }
}
