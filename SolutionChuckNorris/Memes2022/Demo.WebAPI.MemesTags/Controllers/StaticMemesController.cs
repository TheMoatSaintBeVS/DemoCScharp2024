
using Memes.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Demo.WebAPI.MemesTags.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaticMemesController : ControllerBase
    {
        private static bool _init = false;


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

        private static List<User> _users
           = new List<User>
           {
                new User { Id = 1,  FirstName = "Michel", LastName = "Girard", Login="Micgi", Points = 0},
                new User { Id = 2,  FirstName = "Jack", LastName = "Buffeteau", Login="Bubuf", Points = 0},
                new User { Id = 3,  FirstName = "Matthieu", LastName = "Royer", Login="Wawalf", Points = 0},
           };

        private static List<Image> _images
           = new List<Image>
           {
               new Image { Id  = 1 , Uri= "https://64.media.tumblr.com/c84a55767d03c0e8a37d90b415ad05a9/tumblr_pfawdltFE21qgszpno1_640.jpg"},
               new Image { Id= 2, Uri = "https://64.media.tumblr.com/0e419d8b6bb164d66bf53b834f6438cd/tumblr_p8ibt9zc2T1qgszpno1_400.png"},
               new Image { Id= 3, Uri = "https://64.media.tumblr.com/d90c2a597988ec50a24f22c7add3dd2c/tumblr_oxyyisPOHF1qgszpno4_540.png"}
           };
        private static List<Meme> _memes
            = new List<Meme>();



        public StaticMemesController()
        {
            if (!_init)
            {


                _memes.Add(
                    new Meme
                    {
                        Id = 1000,
                        Image = _images[2],
                        ImageId = _images[2].Id,
                        TopText = "My students : The coding exam was easy",
                        BottomText = "Me, reading the code",
                        User = _users[0],
                        UserId = _users[0].Id

                    }
               );


                _memes[0].MemeTags.AddRange(new List<MemeTag> {
                          new MemeTag{ Meme = _memes[0], MemeId =  _memes[0].Id, TagId = _tags[0].Id, Tag =  _tags[0] },
                  new MemeTag{ Meme = _memes[0], MemeId =  _memes[0].Id, TagId = _tags[2].Id, Tag =  _tags[2] },
                  new MemeTag{ Meme = _memes[0], MemeId =  _memes[0].Id, TagId = _tags[3].Id, Tag =  _tags[3] },
                  new MemeTag{ Meme = _memes[0], MemeId =  _memes[0].Id, TagId = _tags[6].Id, Tag =  _tags[6] },
                  new MemeTag{ Meme = _memes[0], MemeId =  _memes[0].Id, TagId = _tags[7].Id, Tag =  _tags[7] }
            })
                    ;



                _memes.Add(
                 new Meme
                 {
                     Id = 2000,
                     Image = _images[1],
                     ImageId = _images[1].Id,
                     TopText = "My students : .gitignore ? What do you mean? ",
                     BottomText = "Me : depressed",
                     User = _users[0],
                     UserId = _users[0].Id

                 }
                );

                _memes[1].MemeTags.AddRange(new List<MemeTag> {
                          new MemeTag{ Meme = _memes[1], MemeId =  _memes[1].Id, TagId = _tags[0].Id, Tag =  _tags[0] },
                  new MemeTag{ Meme = _memes[1], MemeId =  _memes[1].Id, TagId = _tags[1].Id, Tag =  _tags[1] },
                  new MemeTag{ Meme = _memes[1], MemeId =  _memes[1].Id, TagId = _tags[3].Id, Tag =  _tags[3] }
                })
                    ;

                _memes.Add(
                   new Meme
                   {
                       Id = 3000,
                       Image = _images[0],
                       ImageId = _images[0].Id,
                       TopText = "Say 'what is .gitignore ?'",
                       BottomText = "One More Time",
                       User = _users[0],
                       UserId = _users[0].Id
                   }

                );

                _memes[2].MemeTags.AddRange(new List<MemeTag> {
                  new MemeTag{ Meme = _memes[2], MemeId =  _memes[2].Id, TagId = _tags[0].Id, Tag =  _tags[0] },
                  new MemeTag{ Meme = _memes[2], MemeId =  _memes[2].Id, TagId = _tags[4].Id, Tag =  _tags[4] },
                  new MemeTag{ Meme = _memes[2], MemeId =  _memes[2].Id, TagId = _tags[3].Id, Tag =  _tags[3] },
                  new MemeTag{ Meme = _memes[2], MemeId =  _memes[0].Id, TagId = _tags[6].Id, Tag =  _tags[6] },
                  new MemeTag{ Meme = _memes[2], MemeId =  _memes[0].Id, TagId = _tags[7].Id, Tag =  _tags[7] }
                })
                    ;


                _memes.Add(
                 new Meme
                 {
                     Id = 4000,
                     Image = _images[2],
                     TopText = " You don't get it,   ",
                     BottomText = "Do you?",
                     User = _users[1]

                 }
                 );

                _memes[3].MemeTags.AddRange(new List<MemeTag> {
                          new MemeTag{ Meme = _memes[3], MemeId =  _memes[3].Id, TagId = _tags[0].Id, Tag =  _tags[0] },
                          new MemeTag{ Meme = _memes[3], MemeId =  _memes[3].Id, TagId = _tags[5].Id, Tag =  _tags[5] },
                          new MemeTag{ Meme = _memes[3], MemeId =  _memes[3].Id, TagId = _tags[3].Id, Tag =  _tags[3] }
                })
                 ;

                // restore binavigability 

#pragma warning disable CS8602 // Dereference of a possibly null reference.
                _memes.ForEach(m => m.MemeTags.ForEach(mt => _tags.Find(tag => tag == mt.Tag).MemeTags.Add(mt)));
#pragma warning restore CS8602 // Dereference of a possibly null reference.

#pragma warning disable CS8602 // Dereference of a possibly null reference.
                _memes.ForEach(m => _users.Find(u => u == m.User).Memes.Add(m));
#pragma warning restore CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                _memes.ForEach(m => _images.Find(i => i == m.Image).Memes.Add(m));
#pragma warning restore CS8602 // Dereference of a possibly null reference.

                _init = true;

            }

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
            memes = _memes.AsQueryable();

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
            memes = _memes.AsQueryable();

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
            var meme = _memes.Find(m => m.Id == id);
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
            // user test 
            if (memeTag.UserId == 0)
                return BadRequest("");
            var user = _users.Find(u => u.Id == memeTag.UserId);
            if (user == null)
                return BadRequest("  Unknown User");
            // image Test
            if (memeTag.ImageId == 0)
                return BadRequest("");

            // tag Tests
            foreach (var tagId in memeTag.TagIds)
            {
                if (!_tags.Any(t => t.Id == tagId))
                {
                    return BadRequest("the tag with Id " + tagId + " doesn't exist");
                }

            }
          


            memeTag.Id = (_memes.Count + 1) * 1000;
            Meme meme = new Meme();
            meme.Id = memeTag.Id;
            meme.BottomText = memeTag.BottomText;
            meme.TopText = memeTag.TopText;

            var image = _images.Find(i => i.Id== memeTag.ImageId);
            if (image == null)
            {
                return BadRequest("  Unknown Image");


            }


            // updates 

            // image 
            image.Memes.Add(meme);
            meme.Image = image;
            meme.ImageId = image.Id;

            // create relation to the user
            user.Memes.Add(meme);
            meme.User = user;
            meme.UserId = user.Id;


            // create Tags 
            foreach (var tagId in memeTag.TagIds)
            {
                var theTag = _tags.First(t => t.Id == tagId);
                var mt = new MemeTag { Meme = meme, MemeId = meme.Id, Tag = theTag, TagId = tagId };
                meme.MemeTags.Add(mt);
                theTag.MemeTags.Add(mt);
            }


            //must be redevelop with repos methods
            _images.Add(image);
            _memes.Add(meme);
      
            var uri = new Uri(Request.Path + "/" + meme.Id, UriKind.Absolute);

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

            Meme? meme = _memes.Find(m => m.Id == id);
            if (meme == null)
                return BadRequest("");

            meme.BottomText = memeTag.BottomText;
            meme.TopText = memeTag.TopText;

            foreach (var tagId in memeTag.TagIds)
            {
                if (!_tags.Any(t => t.Id == tagId))
                {
                    return BadRequest("the tag with Id " + tagId + " doesn't exist");
                }

            }

            // remove former tags 
            foreach (var tag in meme.MemeTags.ToList())
            {
                if (!memeTag.TagIds.Any(t => t == tag.TagId))
                {
                    meme.MemeTags.Remove(tag);
                }

            }
            //  add new tags
            foreach (var tagId in memeTag.TagIds)
            {
                if (!meme.MemeTags.Any(t => t.TagId == tagId))
                {
                    var theTag = _tags.First(t => t.Id == tagId);
                    var mt = new MemeTag { Meme = meme, MemeId = meme.Id, Tag = theTag, TagId = tagId };
                    meme.MemeTags.Add(mt);
                    theTag.MemeTags.Add(mt);

                }
            }


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
            return memeVM;
        }
    }
}
