using DemoPOO.Entities;
using System.Text.Json;
using System;
using System.Net;

namespace TestProjectDemoPOO
{
    public class UnitTestPOO
    {

        [Fact]
        public void TestBigger()
        {

            Assert.Equal(2, Tool.GetBigger(1, 2));


            Assert.Equal("Mbappé", Tool.GetBigger(
                 new FootBallPlayer { Name = "Mbappé", NumberOfGoals = 100 },
                  new FootBallPlayer { Name = "Giroud", NumberOfGoals = 10 }
                 ).Name);

        }


        [Fact]
        public void TestInt()
        {
            // LINQ => un language 

            List<int> list = new List<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);
            list.Add(6);
            list.Add(7);
            list.Add(8);
            list.Add(9);
            list.Add(10);
            List<int> list2 = new List<int>();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] > 5)
                {
                    list2.Add(list[i]);
                }
            }
            Assert.True(new List<int> { 6, 7, 8, 9, 10 }.SequenceEqual(list2));


            //var greaterThan5

            Assert.True(new List<int> { 6, 7, 8, 9, 10 }.SequenceEqual(
                list.Where(x => x > 5)

                ));

            List<FootBallPlayer> players = new List<FootBallPlayer>();
            players.Add(new FootBallPlayer { Name = "Mbappé", NumberOfGoals = 100 });
            players.Add(new FootBallPlayer { Name = "Giroud", NumberOfGoals = 10 });
            players.Add(new FootBallPlayer { Name = "Benzema", NumberOfGoals = 100 });
            players.Add(new FootBallPlayer { Name = "Royer", NumberOfGoals = 10 });
            // players  avec un a

            Assert.True(
                new List<FootBallPlayer>
                { players.First(p=> p.Name=="Mbappé"), players[2] }
                .SequenceEqual(
                 players.Where(p => p.Name.Contains('a'))
              )
             );

            // players avec plus de 20 goals
        }
        [Fact]
        public void TestIdNotAccessible()
        {
            Assert.Equal(100, Player.Get);


            Player playerOne = new Player();
            Assert.Equal(100, playerOne.Id);

            Player playerTwo = new Player();
            Assert.Equal(101, playerTwo.Id);



        }

        [Fact]
        public void TestDeserialization()
        {
            string result = "     {\r\n        \"_id\": \"wkkqY5x5kia3\",\r\n        \"content\": \"There are basically two types of people. People who accomplish things, and people who claim to have accomplished things. The first group is less crowded.\",\r\n        \"author\": \"Mark Twain\",\r\n        \"tags\": [\r\n            \"Famous Quotes\"\r\n        ],\r\n        \"authorSlug\": \"mark-twain\",\r\n        \"length\": 153,\r\n        \"dateAdded\": \"2019-08-08\",\r\n        \"dateModified\": \"2023-04-14\"\r\n    }";
            // Impossible !!!!
            // car les structures sont differentes 
            //     var quote =JsonSerializer.Deserialize<Quote>(result);

            /// premier récupérer les objets 
            /// 

            var dataDynamic = JsonSerializer.Deserialize<dynamic>(result);

            var resultObject = JsonSerializer.Deserialize<QuoteImport>(result);

            // créer la quote 
            Quote quote = new Quote();
            Assert.NotNull(quote);





        }


    }
}