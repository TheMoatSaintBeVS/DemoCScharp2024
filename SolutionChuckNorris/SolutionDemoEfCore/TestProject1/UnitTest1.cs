using EfCore;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Xunit;

namespace TestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {

            Db2021WorldChampionShipContext db2021WorldChampionShipContext
                = new Db2021WorldChampionShipContext();


            var countOfTeams = 4;

            var actualCountOfTeams = db2021WorldChampionShipContext.Teams.Count();

            Assert.Equal(countOfTeams, actualCountOfTeams);




        }

        [Fact]
        public void Test2()
        {

            Db2021WorldChampionShipContext db2021WorldChampionShipContext
                = new Db2021WorldChampionShipContext();


            var countOfFrenchAtheltes = 9;

            var actualCountOfFrenchAtheltes = 
                db2021WorldChampionShipContext
                .Teams
                .Include(team => team.Athetes)
                .Single( team => team.Country== "France")
                .Athetes
                .Count();

            Assert.Equal(countOfFrenchAtheltes, actualCountOfFrenchAtheltes);




        }


        [Fact]
        public void Test3()
        {

            Db2021WorldChampionShipContext db2021WorldChampionShipContext
                = new Db2021WorldChampionShipContext();


            WorldChampionShip worldChampionShip = new WorldChampionShip();
            worldChampionShip.Id = 2024; 
            worldChampionShip.Year = 2024;
            worldChampionShip.City = "Dijon";

            var countOfWorldChampionShips= db2021WorldChampionShipContext.WorldChampionShips.Count();

            db2021WorldChampionShipContext.WorldChampionShips.Add(worldChampionShip);

            db2021WorldChampionShipContext.SaveChanges();

            var actualCountOfWorldChampionShips = db2021WorldChampionShipContext.WorldChampionShips.Count() ;

            Assert.Equal(countOfWorldChampionShips +1, actualCountOfWorldChampionShips);

            db2021WorldChampionShipContext.WorldChampionShips.Remove(
                db2021WorldChampionShipContext.WorldChampionShips.Single(wcs => wcs.Id == 2024)
                )
                ;

            db2021WorldChampionShipContext.SaveChanges();


             actualCountOfWorldChampionShips = db2021WorldChampionShipContext.WorldChampionShips.Count();

            Assert.Equal(countOfWorldChampionShips, actualCountOfWorldChampionShips);





        }
    }
}