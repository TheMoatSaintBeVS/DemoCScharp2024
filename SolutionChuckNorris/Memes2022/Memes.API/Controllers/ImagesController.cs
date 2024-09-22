using Memes.API.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Memes.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        List<Image> _images;
        public ImagesController()
        {
            _images = new List<Image>
            {
                new Image(1, "https://64.media.tumblr.com/c84a55767d03c0e8a37d90b415ad05a9/tumblr_pfawdltFE21qgszpno1_640.jpg"),
                new Image(2, "https://64.media.tumblr.com/0e419d8b6bb164d66bf53b834f6438cd/tumblr_p8ibt9zc2T1qgszpno1_400.pnj"),
                new Image(3, "https://64.media.tumblr.com/d90c2a597988ec50a24f22c7add3dd2c/tumblr_oxyyisPOHF1qgszpno4_640.pnj"),
                new Image(4, "https://64.media.tumblr.com/6e3ed656a42a23176cfffb6a86ab04d7/tumblr_natlzs3myh1qgszpno1_400.jpg"),
                new Image(5, "https://64.media.tumblr.com/0e419d8b6bb164d66bf53b834f6438cd/tumblr_p8ibt9zc2T1qgszpno1_400.pnj")
            };


        }
        // GET: api/<ImagesController>
        [HttpGet]
        public IEnumerable<Image> Get()
        {
            return _images;
        }

        // GET api/<ImagesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ImagesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ImagesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ImagesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
