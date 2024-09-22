using System;
using System.Linq;
using Xunit;

using FluentAssertions;


using FakeItEasy;
using Memes.Core.Interfaces;
using Memes.Entities;

namespace Memes.Tests.XUnit
{
    public class UnitTestFakeIteasy
    {
        [Fact]
        public void TestGetAllMemes()
        {

            var fakeRepo = A.Fake<IMemesRepository>();

            var fakeMemes = A.CollectionOfDummy<Meme>(4);

            A.CallTo(() => fakeRepo.GetAllMemes()).Returns(fakeMemes);



            Memes.Services.MemeService service
                = new Services.MemeService
                (
                    fakeRepo
                    
                    )
                ;

            var results = service.GetAllMemes();

            results.Should().HaveCount(4, "Because we added four memes");


        }
    }
}
