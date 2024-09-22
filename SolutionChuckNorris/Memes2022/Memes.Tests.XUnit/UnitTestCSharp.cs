using System;
using System.Linq;
using Xunit;

using FluentAssertions;
using Memes.Entities;

namespace Memes.Tests.XUnit
{
    public class UnitTestCSharp
    {
        [Fact]
        public void TestGet()
        {

            var tag = new Tag();


            tag.Description = "test";

        }
    }
}
