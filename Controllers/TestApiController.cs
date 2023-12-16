using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TestProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestApiController : ControllerBase
    {
        public List<string> dummyData = new List<string>()
        {
            "junk1",
            "junk2",
            "junk3",
            "junk4",
            "junk5",
        };

        [HttpGet]
        public List<string> getData()
        {
            return dummyData;
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            if (id < 0 || id >= dummyData.Count)
            {
                return NotFound();
            }

            return Ok(dummyData[id]);
        }


    }
}
