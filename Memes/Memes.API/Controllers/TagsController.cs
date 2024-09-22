using Memes.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Memes.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {
       private static List<Tag> _tags;
        public TagsController()
        {
            if (_tags == null)
            {
                Init();

            }
        }

        public TagsController(List<Tag> tags)
        {
            _tags = tags;
        }

        /// <summary>
        /// Initialisation d'un jeu d'essai
        /// </summary>
        private void Init()
        {
            _tags = new List<Tag>();
            _tags.Add(new Tag() { Id = 1, Description = "csharp" });
            _tags.Add(new Tag() { Id = 2, Description = "PHP" });
        }

        // GET: api/<TagsController>
        [HttpGet]
        public List<Tag> Get()
        {
            return _tags;
        }

        // GET api/<TagsController>/5
        [HttpGet("{id}")]
        public Tag Get(int id)
        {
            return _tags.First(t => t.Id == id);
        }

        // POST api/<TagsController>
        [HttpPost]
        public IActionResult Post([FromBody] Tag newTag)
        {
            _tags.Add(newTag);
            _tags.Add(new Tag() { Id = newTag.Id, Description = newTag.Description });
            return Created(newTag);


        }

        // PUT api/<TagsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TagsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
