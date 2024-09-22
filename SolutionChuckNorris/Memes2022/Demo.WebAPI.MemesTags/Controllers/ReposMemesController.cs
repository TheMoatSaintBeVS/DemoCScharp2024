
using Memes.Core.Interfaces;
using Memes.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Demo.WebAPI.MemesTags.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReposMemesController : ControllerBase
    {
        IMemesRepository _memesRepository; 

        public ReposMemesController( IMemesRepository memesRepository)
        {
           
            _memesRepository = memesRepository; 


        }
        // GET: api/<MemesController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK,
           Type = typeof(List<ViewModels.MemeVM>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult GetAllMemes([FromQuery] string? tag, [FromQuery] int? count)
        {
            //int? count = 10;
            IQueryable<Meme> memes;
            memes = _memesRepository.GetAllMemes().AsQueryable();

            if (tag != null && tag.Any())
            {
                memes = memes.Where(m => m.MemeTags.Any(mt => mt.Tag.Description == tag));
            }

            if (count != null)
            {
                memes = memes.Take((int)count);
            }
            #region without view model
            //var results = memes.Select(m =>
            //          new
            //          {
            //              Id = m.Id,
            //              Text = m.TopText + " " + m.BottomText,
            //              Tags = m.MemeTags.Select(mt => new { TagName = mt.Tag.Description }).ToList()
            //          })
            //  .ToList();
            #endregion

            var results = memes.Select(m => GetMemeVM(m))
               .ToList();


            return Ok(results);
        }
        // GET: api/<MemesController>
        [HttpGet]
        [Route("GetRecords")]
        [ProducesResponseType(StatusCodes.Status200OK,
           Type = typeof(List<ViewModels.MemeVM>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult GetAllMemesWithRecord(
            [FromQuery] string? tag,
            [FromQuery] int? count
            )
        {
            IQueryable<Meme> memes;
            memes = _memesRepository.GetAllMemes().AsQueryable();

            if (tag != null && tag.Any())
            {
                memes = memes
                    .Where(m => m.MemeTags.Any(mt => mt.Tag.Description == tag));
            }

            if (count != null)
            {
                memes = memes.Take((int)count);
            }
            #region without view model
            //var results = memes.Select(m =>
            //    new ViewModels.MemeTagVM
            //    {
            //        Id = m.Id,
            //        Text = m.TopText + " " + m.BottomText,
            //        Tags = m.MemeTags
            //        .Select(mt =>
            //        new ViewModels.TagInfoVM
            //        {
            //            Id = mt.Tag.Id,
            //            Name = mt.Tag.Description
            //        }
            //        )
            //        .ToList()
            //    })
            //    .ToList();
            #endregion
            var results = memes.Select(m => GetMemeVM(m))
                .ToList();

            return Ok(results);
        }


        // GET api/<MemesController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ViewModels.MemeVM))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult GetMeme(int id)
        {
            var meme = _memesRepository.FindMeme(id);
            if (meme != null)
            {
                return Ok(GetMemeVM(meme));
                #region without view model
                //return Ok(new
                //{
                //    Id = meme.Id,
                //    Text = meme.TopText + " " + meme.BottomText,
                //    Tags = meme.MemeTags
                //    .Select(mt =>
                //    new ViewModels.TagInfoVM
                //    {
                //        Id = mt.Tag.Id,
                //        Name = mt.Tag.Description
                //    }
                //    )
                //    ,
                //    User = meme.User.Login
                //}
                //);
                #endregion
            }
            return NotFound();
        }

        // POST api/<MemesController>

        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ViewModels.MemeVM))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public ActionResult Post([FromBody] ViewModels.NewMemeTags memeTag)
        {
            if (memeTag == null)
                return BadRequest("");
            if (!ModelState.IsValid)
            {
                return BadRequest("");
            }
            memeTag.Id = (_memesRepository.GetAllMemes().Count() + 1) * 1000;
            Meme meme = new Meme();
            meme.Id = memeTag.Id;
            meme.BottomText = memeTag.BottomText;
            meme.TopText = memeTag.TopText;


            // user test 
            if (memeTag.UserId == 0)
                return BadRequest("");
            var user = _memesRepository.FindUser(memeTag.UserId);
            if (user == null)
                return BadRequest("  Unknown User");


            foreach (var tagId in memeTag.TagIds)
            {
                if (_memesRepository.FindTag(tagId) == null)
                {
                    return BadRequest("the tag with Id " + tagId + " doesn't exist");
                }

            }
            if (memeTag.ImageId == 0)
                return BadRequest("");
            var image = _memesRepository.FindImage( memeTag.ImageId );
            if (image == null)
                return BadRequest("  Unknown Image");


            // updates 

            // image 

            //image.Memes.Add(meme);
            //meme.Image = image;

            meme.ImageId = memeTag.ImageId;
            //// create relation to the user
            //user.Memes.Add(meme);
            //meme.User = user;   
            meme.UserId = memeTag.UserId;



            //// create Tags 

            foreach (var tagId in memeTag.TagIds)
            {
                var theTag = _memesRepository.FindTag(tagId);
                var mt = new MemeTag { Meme = meme, MemeId = meme.Id, Tag = theTag, TagId = tagId };
                meme.MemeTags.Add(mt);
               // theTag.MemeTags.Add(mt);
            }
            //must be redevelop with repos methods

            _memesRepository.Add(meme);
            var uri = new Uri(Request.Path + "/" + meme.Id, UriKind.Relative);

            return Created(uri, GetMemeVM(meme));

            //CreatedAtAction(nameof(GetMeme), new { id = meme.Id }, memeTag);
        }

        // PUT api/<MemesController>/5
        [HttpPut("{id}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Put(int id, [FromBody] ViewModels.NewMemeTags memeTag)
        {

            if (memeTag == null)
                return BadRequest("");
            if (!ModelState.IsValid)
                return BadRequest("");
            // must be develop with the repos

            Meme? meme = _memesRepository.FindMeme(id);
            if (meme == null)
                return BadRequest("");

            meme.BottomText = memeTag.BottomText;
            meme.TopText = memeTag.TopText;

            foreach (var tagId in memeTag.TagIds)
            {
                if (_memesRepository.FindTag(tagId)== null)
                {
                    return BadRequest("the tag with Id " + tagId + " doesn't exist");
                }

            }
            foreach (var tag in meme.MemeTags.ToList())
            {
                if (!memeTag.TagIds.Any(t => t == tag.TagId))
                {
                    meme.MemeTags.Remove(tag);
                }

            }
            foreach (var tagId in memeTag.TagIds)
            {
                if (!meme.MemeTags.Any(t => t.TagId == tagId))
                {
                    var theTag = _memesRepository.FindTag(tagId);
                    var mt = new MemeTag { Meme = meme, MemeId = meme.Id, Tag = theTag, TagId = tagId };
                    meme.MemeTags.Add(mt);
                    theTag.MemeTags.Add(mt);

                }
            }

            var result = _memesRepository.SaveMeme(meme);

            return NoContent();

        }

        // DELETE api/<MemesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }




        private ViewModels.MemeVM GetMemeVM(Meme meme) 
        {
            var memeVM = new ViewModels.MemeVM();

            memeVM.Id = meme.Id;
            memeVM.BottomText = meme.BottomText;
            memeVM.TopText = meme.TopText;
            memeVM.Public = meme.Public;
            //if (Request != null )
            //{
            // memeVM.image
            memeVM.Image = new Uri( Request.Scheme 
                +"://"+ Request.Host.Value 
                +"/api/images/" 
                + meme.ImageId, UriKind.Absolute).ToString();
            // memeVM.user
            memeVM.User = new Uri(Request.Scheme 
                +"://" + Request.Host.Value 
                + "/api/users/" 
                + meme.UserId, UriKind.Absolute).ToString();
            // memeVm.users
            foreach (var vote in meme.UpVotes)
            {
                memeVM.UpVoteUsers.Add(new Uri(Request.Scheme
                    + "://" + Request.Host.Value
                    + "/api/users/"
                    + vote.UserId, UriKind.Absolute).ToString());
            }
            //memeVM.Tags
            foreach (var tag in meme.MemeTags)
            {
                memeVM.Tags.Add(new Uri(Request.Scheme
                    + "://" + Request.Host.Value 
                    + "/api/tags/" 
                    + tag.TagId, UriKind.Absolute).ToString());
            }
            //}
            return memeVM;
        }
    }
}
