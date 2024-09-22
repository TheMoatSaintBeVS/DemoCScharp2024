using System;
using System.Linq;
using Xunit;

using FluentAssertions;
using Memes.Entities;
using Demo.WebAPI.MemesTags.Controllers;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Memes.Tests.XUnit
{
    public class UnitTestControllerStaticTags
    {
        // not the right solution 
        // see dependency injection



        List<Tag> _tags = new List<Tag>
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
        [Fact]
        public void TestGetAllTags()
        {
            var tagsController = new TagsController();
            var results = tagsController.GetAllTags();
            results.Should().HaveCount(_tags.Count, $"Because we added ${_tags.Count} tags");
        }

        [Fact]
        public void TestGetOneTag()
        {
            var tagsController = new TagsController();
            var result = tagsController.GetTag(100);
            result.Description.Should().Be("Csharp");
        }

        [Fact]
        public void TestGetAllTagsActionResult()
        {
            var tagsController = new ActionResultTagsController();
            var result = tagsController.GetAllTags(2) as ObjectResult;
            result.StatusCode.Should().Be((int)HttpStatusCode.OK);
        }

        [Fact]
        public void TestGetOneTagActionResultOK()
        {
            var tagsController = new ActionResultTagsController();
            var result = tagsController.GetTag(100) as ObjectResult;
            result.StatusCode.Should().Be((int)HttpStatusCode.OK); 
        }


        [Fact]
        public void TestGetOneTagActionResultKO()
        {
            var tagsController = new ActionResultTagsController();
            var result = tagsController.GetTag(10000) as NotFoundResult;
            result.StatusCode.Should().Be((int)HttpStatusCode.NotFound);
        }
        [Fact]
        public void TestPostTagActionResultOK()
        {
            var tagsController = new ActionResultTagsController();
            var result = tagsController.Post(new Tag { Id = 100, Description = "Csharp" }) as ObjectResult;
            result.StatusCode.Should().Be((int)HttpStatusCode.Created);
        }

        [Fact]
        public void TestPostTagActionResultKO()
        {
            Tag tag = null;

            var tagsController = new ActionResultTagsController();
            var result = tagsController.Post(tag) as ObjectResult;
            result.StatusCode.Should().Be((int)HttpStatusCode.BadRequest);
        }

        [Fact]
        public void TestPutTagActionResultOK()
        {
            var tagsController = new ActionResultTagsController();
            var resultat = tagsController.Put(100, new Tag { Id = 100, Description = "Csharp 6" }) as NoContentResult;
            resultat.StatusCode.Should().Be((int)HttpStatusCode.NoContent);
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

    }
}
