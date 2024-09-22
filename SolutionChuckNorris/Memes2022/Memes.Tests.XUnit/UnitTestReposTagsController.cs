using System;
using System.Linq;
using Xunit;
using FakeItEasy;

using FluentAssertions;
using Memes.Entities;
using Demo.WebAPI.MemesTags.Controllers;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Http;
using Moq;
using Microsoft.AspNetCore.Http;

namespace Memes.Tests.XUnit
{
    public class UnitTestReposTagsController
    {

        private readonly List<User> _users
            = new List<User>
            {
                new User { Id = 1,  FirstName = "Michel", LastName = "Girard", Login="Micgi", Points = 0},
                new User { Id = 2,  FirstName = "Jack", LastName = "Buffeteau", Login="Bubuf", Points = 0},
                new User { Id = 3,  FirstName = "Matthieu", LastName = "Royer", Login="Wawalf", Points = 0},
            };

        private readonly List<Image> _images
           = new List<Image>
           {
               new Image { Id  = 1 , Uri= "https://64.media.tumblr.com/c84a55767d03c0e8a37d90b415ad05a9/tumblr_pfawdltFE21qgszpno1_640.jpg"},
               new Image { Id=2, Uri = "https://64.media.tumblr.com/0e419d8b6bb164d66bf53b834f6438cd/tumblr_p8ibt9zc2T1qgszpno1_400.png"},
               new Image { Id= 3, Uri = "https://64.media.tumblr.com/d90c2a597988ec50a24f22c7add3dd2c/tumblr_oxyyisPOHF1qgszpno4_540.png"}
           };
        private readonly List<Meme> _memes
            = new List<Meme>();

        private readonly List<Tag> _tags = new List<Tag>
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


        public void Init()
        {

            _memes.Add(
                new Meme
                {
                    Id = 1000,
                    Image = _images[2],
                    TopText = "My students : The coding exam was easy",
                    BottomText = "Me, reading the code",
                    User = _users[0]

                }
           );


            _memes[0].MemeTags.AddRange(new List<MemeTag> {
                          new MemeTag{ Meme = _memes[0], MemeId =  _memes[0].Id, TagId = _tags[0].Id, Tag =  _tags[0] },
                  new MemeTag{ Meme = _memes[0], MemeId =  _memes[0].Id, TagId = _tags[2].Id, Tag =  _tags[2] },
                  new MemeTag{ Meme = _memes[0], MemeId =  _memes[0].Id, TagId = _tags[3].Id, Tag =  _tags[3] }
            })
                ;



            _memes.Add(
             new Meme
             {
                 Id = 2000,
                 Image = _images[1],
                 TopText = "My students : .gitignore ? What do you mean? ",
                 BottomText = "Me : depressed",
                 User = _users[0]

             }
        );
            // Tags = new List<Tag> { _tags[0], _tags[1], _tags[3] }


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
                   TopText = "Say 'what is .gitignore ?'",
                   BottomText = "One More Time",
                   User = _users[0]
               }

          );

            //  Tags = new List<Tag> { _tags[0], _tags[4], _tags[3] }


            _memes[2].MemeTags.AddRange(new List<MemeTag> {
                          new MemeTag{ Meme = _memes[2], MemeId =  _memes[2].Id, TagId = _tags[0].Id, Tag =  _tags[0] },
                  new MemeTag{ Meme = _memes[2], MemeId =  _memes[2].Id, TagId = _tags[4].Id, Tag =  _tags[4] },
                  new MemeTag{ Meme = _memes[2], MemeId =  _memes[2].Id, TagId = _tags[3].Id, Tag =  _tags[3] }
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




            // Tags = new List<Tag> { _tags[0], _tags[5], _tags[3] }


            _memes[3].MemeTags.AddRange(new List<MemeTag> {
                          new MemeTag{ Meme = _memes[3], MemeId =  _memes[3].Id, TagId = _tags[0].Id, Tag =  _tags[0] },
                          new MemeTag{ Meme = _memes[3], MemeId =  _memes[3].Id, TagId = _tags[5].Id, Tag =  _tags[5] },
                          new MemeTag{ Meme = _memes[3], MemeId =  _memes[3].Id, TagId = _tags[3].Id, Tag =  _tags[3] }
            })
             ;

            // restore binavigability 

            _memes.ForEach(m => m.MemeTags.ForEach(mt => _tags.Find(tag => tag == mt.Tag).MemeTags.Add(mt)));
            _memes.ForEach(m => _users.Find(u => u == m.User).Memes.Add(m));
            _memes.ForEach(m => _images.Find(i => i == m.Image).Memes.Add(m));
        }

        #region tests with Fake It easy
        //[Fact]
        //public void TestGetAllTagsNull()
        //{
        //    var reposTagsController = new ReposTagsController(new Memes.Repositories.InMemory.Repository());
        //    var result = memesController.GetAllMemes(null, null) as ObjectResult;
        //    result.StatusCode.Should().Be((int)HttpStatusCode.OK);
        //    //results.Should().HaveCount(_tags.Count, $"Because we added ${_tags.Count} tags");
        //}

        //[Fact]
        //public void TestGetAllMemesNullCountWithFakeItEasy()
        //{
        //    int count = 5;
        //    int limit = 3;
        //    var fakeMemes = A.CollectionOfDummy<Meme>(count).AsEnumerable();
        //    var dataStore = A.Fake<Memes.Core.Interfaces.IMemesRepository>();
        //    A.CallTo(() => dataStore.GetAllMemes()).Returns(fakeMemes);
        //    var memesController = new ReposMemesController(dataStore);
        //    var result = memesController.GetAllMemes(null, limit) as ObjectResult;
        //    result.StatusCode.Should().Be((int)HttpStatusCode.OK);

        //    ((List<Demo.WebAPI.MemesTags.ViewModels.MemeVM>)result.Value).Should().HaveCount(limit, $"Because we added ${limit} tags");
        //}


        #endregion

        #region Tests with MOQ
        [Theory] // multi values
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        // with a parameter
        public void TestGetAllMemesNullCountWithMOQ(int currentValue)
        {
            int limit = currentValue;

            var mockRepository = new Mock<Memes.Core.Interfaces.ITagsRepository>();



            var httpContext = new DefaultHttpContext();
            httpContext.Request.Scheme = "http";
            httpContext.Request.Host = new HostString("localhost");
            httpContext.Request.PathBase = "/api/Repostags";
            httpContext.Request.Method = "GET";
            var reposTagsController = new ReposTagsController(mockRepository.Object)
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = httpContext,
                }
            };


            Init();


            mockRepository.Setup(x => x.GetAllTags()).Returns(_tags);


            var result = reposTagsController.GetAllTags(limit) as ObjectResult;
            var actualtResult = result.Value;

           
            Assert.IsType<OkObjectResult>(result);

            result.StatusCode.Should().Be((int)HttpStatusCode.OK);

            ((List<Demo.WebAPI.MemesTags.ViewModels.TagVM>)result.Value).Should()
                .HaveCount(limit, $"Because we added ${limit} tags");
        }

        /*
        [Fact]
        public void TestGetOneMeme()
        {
            int id= 2000;
            var mockRepository = new Mock<Memes.Core.Interfaces.IMemesRepository>();
            var httpContext = new DefaultHttpContext();
            httpContext.Request.Scheme = "http";
            httpContext.Request.Host = new HostString("localhost");
            httpContext.Request.PathBase = "/api/memes";
            httpContext.Request.Method = "GET";

            var memesController = new ReposMemesController(mockRepository.Object)
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = httpContext,
                }
            };


            Init(); 

            mockRepository.Setup(x => x.GetAllMemes()).Returns(_memes);

            var result = memesController.GetMeme(id) as ObjectResult;
            var actualtResult = result.Value;

            //ASSERT
            Assert.IsType<OkObjectResult>(result);

            result.StatusCode.Should().Be((int)HttpStatusCode.OK);

           
            ((Demo.WebAPI.MemesTags.ViewModels.MemeVM)result.Value).BottomText.Should().Be("Me : depressed");
            ((Demo.WebAPI.MemesTags.ViewModels.MemeVM)result.Value).TopText.Should().Be("My students : .gitignore ? What do you mean? ");
            
        }
        [Fact]
        public void TestGetOneMemeKO()
        {
            int id = 9999;
            var mockRepository = new Mock<Memes.Core.Interfaces.IMemesRepository>();
            var httpContext = new DefaultHttpContext();
            httpContext.Request.Scheme = "http";
            httpContext.Request.Host = new HostString("localhost");
            httpContext.Request.PathBase = "/api/memes";
            httpContext.Request.Method = "GET";
            var memesController = new ReposMemesController(mockRepository.Object)
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = httpContext,
                }
            };
            Init();
            mockRepository.Setup(x => x.GetAllMemes()).Returns(_memes);
             var actualResult = memesController.GetMeme(id);
            Assert.IsType<NotFoundResult>(actualResult);
        }
      

        private int AddMeme( Meme meme)
        {
            if (meme !=null)
            {

           
            var image = _images.Find(i => i.Id == meme.ImageId);

            meme.Image = image;

            image.Memes.Add(meme);

            var user = _users.Find(u => u.Id == meme.UserId);

            meme.User = user;

            user.Memes.Add(meme);


            //// create Tags 

            foreach (var memeTag in meme.MemeTags)
            {
                var theTag = _tags.Find(t => t.Id == memeTag.TagId);
                theTag.MemeTags.Add(memeTag);
            }


            _memes.Add(meme);

            }

            return 1; 
        }
       
        [Fact]
        public void TestPostMemeOK()
        {


           
            var mockRepository = new Mock<Memes.Core.Interfaces.IMemesRepository>();
            var httpContext = new DefaultHttpContext();
            httpContext.Request.Scheme = "http";
            httpContext.Request.Host = new HostString("localhost");
            httpContext.Request.PathBase = "/api/memes";
            httpContext.Request.Method = "POST";


            var memesController = new ReposMemesController(mockRepository.Object)

            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = httpContext,
                }
            };


            Init();

            int before = _memes.Count;
            Demo.WebAPI.MemesTags.ViewModels.NewMemeTags newMemetags = new();


            newMemetags.Id = 1;
            newMemetags.BottomText = "Bottom";
            newMemetags.TopText = "Top";
            newMemetags.ImageId = 1;
            newMemetags.UserId = 1;
            newMemetags.TagIds = new List<int>() { 100, 200, 300 };

            mockRepository.Setup(
                self=> self.GetAllMemes()).Returns(_memes);

            mockRepository.Setup(self => self.FindImage(It.IsAny<int>())).Returns(_images.Find(y=> y.Id == 1));

            mockRepository.Setup(self => self.FindUser(It.IsAny<int>())).Returns(_users.Find(y => y.Id == 1));

            mockRepository.Setup(x => x.FindTag(It.IsAny<int>())).Returns(_tags.Find(y => y.Id == 100));

            mockRepository.Setup(x => x.Add(It.IsAny<Meme>())).Returns(1);


          

            var result = memesController.Post(newMemetags);

            Assert.IsType<CreatedResult>(result);
            var okResult = result.Should().BeOfType<CreatedResult>();



           ((Demo.WebAPI.MemesTags.ViewModels.MemeVM)( (CreatedResult) result  ).Value).Id.Should().Be(5000);

//            {
//                "id": 5000,
//  "topText": "string",
//  "bottomText": "string",
//  "public": false,
//  "user": "http//localhost:5235/api/users/1",
//  "image": "http//localhost:5235/api/images/1",
//  "tags": [
//    "http//localhost:5235/api/tags/100",
//    "http//localhost:5235/api/tags/200",
//    "http//localhost:5235/api/tags/300"
//              ],
//  "upVoteUsers": []
//}
           ((Demo.WebAPI.MemesTags.ViewModels.MemeVM)((CreatedResult)result).Value).Id.Should().Be(5000);

            ((Demo.WebAPI.MemesTags.ViewModels.MemeVM)((CreatedResult)result).Value).User.Should().Be("http//localhost/api/users/1");
            ((Demo.WebAPI.MemesTags.ViewModels.MemeVM)((CreatedResult)result).Value).Image.Should().Be("http//localhost/api/images/1");
            ((Demo.WebAPI.MemesTags.ViewModels.MemeVM)((CreatedResult)result).Value).Tags[0].Should().Be("http//localhost/api/tags/100");
            ((Demo.WebAPI.MemesTags.ViewModels.MemeVM)((CreatedResult)result).Value).Tags[1].Should().Be("http//localhost/api/tags/200");
            ((Demo.WebAPI.MemesTags.ViewModels.MemeVM)((CreatedResult)result).Value).Tags[2].Should().Be("http//localhost/api/tags/300");
            //((Demo.WebAPI.MemesTags.ViewModels.MemeVM)result.Value).BottomText.Should().Be("Me : depressed");
            //((Demo.WebAPI.MemesTags.ViewModels.MemeVM)result.Value).TopText.Should().Be("My students : .gitignore ? What do you mean? ");

            //var tagsController = new ActionResultTagsController();
            //var result = tagsController.Post(new Tag { Id = 100, Description = "Csharp" }) as ObjectResult;
            //result.StatusCode.Should().Be((int)HttpStatusCode.Created);
        }

        [Fact]
        public void TestPostMemeKOUser()
        {
            var mockRepository = new Mock<Memes.Core.Interfaces.IMemesRepository>();
            var httpContext = new DefaultHttpContext();
            httpContext.Request.Scheme = "http";
            httpContext.Request.Host = new HostString("localhost");
            httpContext.Request.PathBase = "/api/memes";
            httpContext.Request.Method = "POST";


            var memesController = new ReposMemesController(mockRepository.Object)

            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = httpContext,
                }
            };


            Init();

            int before = _memes.Count;
            Demo.WebAPI.MemesTags.ViewModels.NewMemeTags newMemetags = new();


            newMemetags.Id = 1;
            newMemetags.BottomText = "Bottom";
            newMemetags.TopText = "Top";
            newMemetags.ImageId = 1;
            newMemetags.UserId = 1;
            newMemetags.TagIds = new List<int>() { 100, 200, 300 };

            mockRepository.Setup(
                self => self.GetAllMemes()).Returns(_memes);

            mockRepository.Setup(self => self.FindImage(It.IsAny<int>())).Returns(_images.Find(y => y.Id == 1));

            mockRepository.Setup(self => self.FindUser(It.IsAny<int>())).Returns(_users.Find(y => y.Id == 10000));

            mockRepository.Setup(x => x.FindTag(It.IsAny<int>())).Returns(_tags.Find(y => y.Id == 100));

            mockRepository.Setup(x => x.Add(It.IsAny<Meme>())).Returns(1);




            var result = memesController.Post(newMemetags);

            Assert.IsType<BadRequestObjectResult>(result);
          
         
        }


        [Fact]
        public void TestPostMemeKOTag()
        {
            var mockRepository = new Mock<Memes.Core.Interfaces.IMemesRepository>();
            var httpContext = new DefaultHttpContext();
            httpContext.Request.Scheme = "http";
            httpContext.Request.Host = new HostString("localhost");
            httpContext.Request.PathBase = "/api/memes";
            httpContext.Request.Method = "POST";


            var memesController = new ReposMemesController(mockRepository.Object)

            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = httpContext,
                }
            };


            Init();

            int before = _memes.Count;
            Demo.WebAPI.MemesTags.ViewModels.NewMemeTags newMemetags = new();


            newMemetags.Id = 1;
            newMemetags.BottomText = "Bottom";
            newMemetags.TopText = "Top";
            newMemetags.ImageId = 1;
            newMemetags.UserId = 1;
            newMemetags.TagIds = new List<int>() { 100, 200, 300 };

            mockRepository.Setup(
                self => self.GetAllMemes()).Returns(_memes);

            mockRepository.Setup(self => self.FindImage(It.IsAny<int>())).Returns(_images.Find(y => y.Id == 1));

            mockRepository.Setup(self => self.FindUser(It.IsAny<int>())).Returns(_users.Find(y => y.Id == 1));

            mockRepository.Setup(x => x.FindTag(It.IsAny<int>())).Returns(_tags.Find(y => y.Id == 10000));

            mockRepository.Setup(x => x.Add(It.IsAny<Meme>())).Returns(1);




            var result = memesController.Post(newMemetags);

            Assert.IsType<BadRequestObjectResult>(result);

        }
        [Fact]
        public void TestPostMemeKOImage()
        {
            var mockRepository = new Mock<Memes.Core.Interfaces.IMemesRepository>();
            var httpContext = new DefaultHttpContext();
            httpContext.Request.Scheme = "http";
            httpContext.Request.Host = new HostString("localhost");
            httpContext.Request.PathBase = "/api/memes";
            httpContext.Request.Method = "POST";


            var memesController = new ReposMemesController(mockRepository.Object)

            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = httpContext,
                }
            };


            Init();

            int before = _memes.Count;
            Demo.WebAPI.MemesTags.ViewModels.NewMemeTags newMemetags = new();


            newMemetags.Id = 1;
            newMemetags.BottomText = "Bottom";
            newMemetags.TopText = "Top";
            newMemetags.ImageId = 1;
            newMemetags.UserId = 1;
            newMemetags.TagIds = new List<int>() { 100, 200, 300 };

            mockRepository.Setup(
                self => self.GetAllMemes()).Returns(_memes);

            mockRepository.Setup(self => self.FindImage(It.IsAny<int>())).Returns(_images.Find(y => y.Id == 10000));

            mockRepository.Setup(self => self.FindUser(It.IsAny<int>())).Returns(_users.Find(y => y.Id == 1));

            mockRepository.Setup(x => x.FindTag(It.IsAny<int>())).Returns(_tags.Find(y => y.Id == 100));

            mockRepository.Setup(x => x.Add(It.IsAny<Meme>())).Returns(1);




            var result = memesController.Post(newMemetags);

            Assert.IsType<BadRequestObjectResult>(result);

        }

       
        [Fact]
        public void TestPutTagActionResultOK()
        {
            var mockRepository = new Mock<Memes.Core.Interfaces.IMemesRepository>();

            var httpContext = new DefaultHttpContext();
            httpContext.Request.Scheme = "http";
            httpContext.Request.Host = new HostString("localhost");
            httpContext.Request.PathBase = "/api/memes";
            httpContext.Request.Method = "PUT";


            var memesController = new ReposMemesController(mockRepository.Object)

            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = httpContext,
                }
            };


            Init();

            int before = _memes.Count;
            Demo.WebAPI.MemesTags.ViewModels.NewMemeTags newMemetags = new();


            newMemetags.Id = 1000;
            newMemetags.BottomText = "Bottom";  
            newMemetags.TopText = "Top";
            newMemetags.ImageId = 1;
            newMemetags.UserId = 1;
            newMemetags.TagIds = new List<int>() { 100, 200, 300 };

            mockRepository.Setup(
                self => self.FindMeme(1000)).Returns(_memes.Find(x => x.Id == 1000));

            mockRepository.Setup(self => self.FindImage(It.IsAny<int>())).Returns(_images.Find(y => y.Id == 1));

            mockRepository.Setup(self => self.FindUser(It.IsAny<int>())).Returns(_users.Find(y => y.Id == 1));

            mockRepository.Setup(x => x.FindTag(It.IsAny<int>())).Returns(_tags.Find(y => y.Id == 100));

            mockRepository.Setup(x => x.SaveMeme(It.IsAny<Meme>())).Returns(1);



            var result = memesController.Put(1000,newMemetags);

            Assert.IsType<NoContentResult>(result);

        }

        [Fact]
        public void TestPutTagActionResultKO()
        {
            var tagsController = new ActionResultTagsController();
            var result = tagsController.Put(10000, new Tag { Id = 10000, Description = "Csharp" }) as ObjectResult;
            result.StatusCode.Should().Be((int)HttpStatusCode.BadRequest);
        }




        [Fact]
        public void TestDeleteTagActionResultKO()
        {

            var tagsController = new ActionResultTagsController();
            var result = tagsController.Delete(8000) as ObjectResult;
            result.StatusCode.Should().Be((int)HttpStatusCode.BadRequest);
        }

        [Fact]
        public void TestDeleteTagActionResultOK()
        {
            var tagsController = new ActionResultTagsController();
            var result = tagsController.Delete(900) as NoContentResult;
            result.StatusCode.Should().Be((int)HttpStatusCode.NoContent);
        }
        #endregion

        */

        #endregion
    }
}
