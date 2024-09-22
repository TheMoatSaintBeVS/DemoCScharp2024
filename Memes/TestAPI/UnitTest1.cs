using Memes.API.Controllers;
using Memes.Entities;

namespace TestAPI
{
    public class UnitTest1
    {
        [Fact]
        public void TestGetAll()
        {
            // instanciation du controller
            var tagsController = new TagsController();
            // 
            var result = tagsController.Get();
            Assert.NotNull(result);
            Assert.True(result.Count() ==2 );
        }

        [Fact]
        public void TestPostl()
        {
            // instanciation du controller
            var tagsController = new TagsController();
            // 
             tagsController.Post( new Memes.Entities.Tag { Id=12, Description=" Python"});
            Assert.True(tagsController.Get().Count() == 4);
        }

        [Fact]
        public void TestGetIdOK()
        {
            // résultat 
            Tag tag = new Tag(); 
            tag.Id = 12;
            tag.Description = "Cobol";
            // définir le jeu d'essai 
            List<Tag>   tags = new List<Tag>();
            tags.Add(new Tag() { Id = 111, Description = "csharp" });
            tags.Add(new Tag() { Id = 112, Description = "PHP" });
            tags.Add(tag);
            // par injection 
            // par constructeur
            // instanciation du controller
            var tagsController = new TagsController(tags);
            // 
            var result = tagsController.Get(12);
            Assert.True(result.Id ==  tag.Id);
            Assert.True(result.Description == tag.Description);
        }

        [Fact]
        public void TestGetIdKO()
        {
            // résultat 
            Tag tag = new Tag();
            tag.Id = 12;
            tag.Description = "Cobol";
            // définir le jeu d'essai 
            List<Tag> tags = new List<Tag>();
            tags.Add(new Tag() { Id = 111, Description = "csharp" });
            tags.Add(new Tag() { Id = 112, Description = "PHP" });
            tags.Add(tag);
            // par injection 
            // par constructeur
            // instanciation du controller
            var tagsController = new TagsController(tags);
            // 
            var result = tagsController.Get(1234);
        Assert.Null(result);
        }


    }
}