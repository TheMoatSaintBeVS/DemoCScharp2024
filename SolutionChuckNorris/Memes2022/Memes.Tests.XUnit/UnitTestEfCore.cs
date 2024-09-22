using System;
using System.Linq;
using Xunit;

using FluentAssertions;

namespace Memes.Tests.XUnit
{
    public class UnitTestEfCore
    { 
        [Fact]
        public void TestGetAllUsers()
        {

        var connectionString = "Server=tcp:micgiserver2022.database.windows.net,1433;"
                + " Initial Catalog=Db2022Memes ; "
                + " User ID=Teacher;Password=$PSG#is#Magic$; ";
            Memes.Services.MemeService service
                = new Services.MemeService
                (
                    new Memes.Repositories.EfCore.Repository( connectionString))
                ;

            var results = service.GetAllUsers();

            results.Should().HaveCount(3, "Because we added 3 users");

        

        }
    }
}
