using Memes.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Demo.WebAPI.MemesTags.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActionResultTagsController : ControllerBase
    {
        private static List<Tag> _tags = new List<Tag>
        {
            new Tag { Id = 100 , Description="Csharp"},
            new Tag { Id = 200 , Description="Javascript"},
            new Tag { Id = 300 , Description="Meme"},
            new Tag { Id = 400 , Description="SQL"},
            new Tag { Id = 500 , Description="BTSSIO"},
            new Tag { Id = 600 , Description="SLAM"},
            new Tag { Id = 700 , Description="B1"},
            new Tag { Id = 800 , Description="B2"},
            new Tag { Id = 900 , Description="B3"}
        };

        public ActionResultTagsController( )
        {
            
           
        }
        //
         //public TagsController()
        //{

        //    _tags = 
        //}


        // GET: api/<TagsController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK,
            Type = typeof(List<Tag>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult GetAllTags([FromQuery] int? count)
        {
            //int? count = 10;
            IQueryable<Tag> tags;
            tags = _tags.AsQueryable();
            if (count != null)
            {
                tags = tags.Take((int)count);
            }
            return Ok(tags.ToList());
        }
        
        // GET api/<TagsController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Tag))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult GetTag(int id)
        {
            var tag = _tags.Find(t => t.Id == id);
            if (tag != null)
            {
                return Ok(tag);
            }
            return NotFound();
        }

        // POST api/<TagsController>
        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Post([FromBody] Tag tag)
        {
            if (tag == null)
                return BadRequest("");
            if (!ModelState.IsValid )
            {
                return BadRequest("");
            }
            tag.Id = 1000 + _tags.Count * 10;
            _tags
                .Add(tag);
            return CreatedAtAction(nameof(GetTag), new { id = tag.Id }, tag);
        }

        // PUT api/<TagsController>/5
        [HttpPut("{id}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Put(int id, [FromBody] Tag tag)
        {
            var existingTag = _tags.Find(t => t.Id == id);

            if (tag == null || existingTag == null )
                return BadRequest("");

            existingTag.Description = tag.Description;
            return NoContent();

        }

        // DELETE api/<TagsController>/5
        [HttpDelete("{id}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Delete(int id)
        {
            var existingTag = _tags.Find(t => t.Id == id);

            if ( existingTag == null)
                return BadRequest("");

           _tags.Remove(existingTag);
            return NoContent();
        }
    }
}
