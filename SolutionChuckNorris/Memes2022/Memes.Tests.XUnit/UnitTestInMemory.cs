using System;
using System.Linq;
using Xunit;

using FluentAssertions;

namespace Memes.Tests.XUnit
{
    public class UnitTestInMemory
    {
        [Fact]
        public void TestGetAllMemes()
        {
            Memes.Services.MemeService service
                = new Services.MemeService
                (
                    new Memes.Repositories.InMemory.Repository())
                ;

            var results = service.GetAllMemes();

            results.Should().HaveCount(4, "Because we added four memes");

            results.First().MemeTags.Count.Should().Be(3);

        }
    }
}
