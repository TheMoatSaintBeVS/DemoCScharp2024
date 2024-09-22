using Memes.Core.Interfaces;
using Memes.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Demo.WebAPI.MemesTags.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReposTagsController : ControllerBase
    {
        ITagsRepository _tagsRepository;

        public ReposTagsController(ITagsRepository tagsRepository)
        {
            _tagsRepository = tagsRepository;
        }
        // GET: api/<MemesController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK,
           Type = typeof(List<ViewModels.TagVM>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult GetAllTags([FromQuery] int? count)
        {
            //int? count = 10;
            IQueryable<Tag> tags;
            tags = _tagsRepository.GetAllTags().AsQueryable();
            if (count != null)
            {
                tags = tags.Take((int)count);
            }
            var results = tags.Select(t => GetTagVM(t))
               .ToList();
            return Ok(results);
        }
       

        // GET api/<ReposTagsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ReposTagsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ReposTagsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ReposTagsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        private ViewModels.TagVM GetTagVM(Tag tag)
        {
            var tagVM = new ViewModels.TagVM();

            tagVM.Id = tag.Id;
            tagVM.Description = tag.Description;
          
            // memeVm.users
            foreach (var memeTag in tag.MemeTags)
            {
                tagVM.Memes.Add(new Uri(Request.Scheme
                    + "://" + Request.Host.Value
                    + "/api/Reposmemes/"
                    + memeTag.MemeId, UriKind.Absolute).ToString());
            }
            //memeVM.Tags
          
            return tagVM;
        }

    }
}
