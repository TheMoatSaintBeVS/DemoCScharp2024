using Memes.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Demo.WebAPI.MemesTags.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private static List<Tag> _tags = new List<Tag>
        {
            new Tag { Id = 100 , Description="Csharp"},
            new Tag { Id = 200 , Description="Javascript"},
            new Tag { Id = 300 , Description="Meme"},
            new Tag { Id = 400 , Description="SQL"},
            new Tag { Id = 500 , Description="BTSSIO"},
            new Tag { Id = 600 , Description="SLAM"},
            new Tag { Id = 100 , Description="B1"},
            new Tag { Id = 100 , Description="B2"},
            new Tag { Id = 100 , Description="B3"}
        };

        public TagsController( )
        {
            
           
        }
        //
         //public TagsController()
        //{

        //    _tags = 
        //}


        // GET: api/<TagsController>
        [HttpGet]
        public List<Tag> GetAllTags()
        {
            return _tags;
        }

        // GET api/<TagsController>/5
        [HttpGet("{id}")]
        public Tag GetTag(int id)
        {
            return _tags.First(t => t.Id == id);
        }

        // POST api/<TagsController>
        [HttpPost]
        public void Post([FromBody] Tag tag)
        {
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
