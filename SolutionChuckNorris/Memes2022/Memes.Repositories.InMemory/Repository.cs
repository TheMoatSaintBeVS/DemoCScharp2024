using Memes.Core.Interfaces;
using Memes.Entities;
using System;
using System.Collections.Generic;

namespace Memes.Repositories.InMemory
{
    public  class Repository : IMemesRepository
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


        public Repository()
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

        public int Add(Meme meme)
        {
            throw new NotImplementedException();
        }

        public int Add(Image image)
        {
            throw new NotImplementedException();
        }

        public int Add(Tag tag)
        {
            throw new NotImplementedException();
        }

        public int Add(User user)
        {
            throw new NotImplementedException();
        }

        public int AddTag(Tag tag)
        {
            throw new NotImplementedException();
        }

        public Meme Find(string id)
        {
            throw new NotImplementedException();
        }

        public Image FindImage(string word)
        {
            throw new NotImplementedException();
        }

        public Image FindImage(int id)
        {
            throw new NotImplementedException();
        }

        public List<Image> FindImages(string word)
        {
            throw new NotImplementedException();
        }

        public Meme FindMeme(int id)
        {
            throw new NotImplementedException();
        }

        public List<Meme> FindMemes(string word)
        {
            throw new NotImplementedException();
        }

        public Tag FindTag(int id)
        {
            throw new NotImplementedException();
        }

        public List<Tag> FindTags(string word)
        {
            throw new NotImplementedException();
        }

        public User FindUser(string login)
        {
            throw new NotImplementedException();
        }

        public User FindUser(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Image> GetAllImages()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Meme> GetAllMemes()
        {
            return _memes;
        }

        public IEnumerable<Tag> GetAllTags()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public Meme Remove(string id)
        {
            throw new NotImplementedException();
        }

        public int SaveImage(Image image)
        {
            throw new NotImplementedException();
        }

        public int SaveMeme(Meme meme)
        {
            throw new NotImplementedException();
        }

        public int SaveTag(Tag tag)
        {
            throw new NotImplementedException();
        }

        public int SaveUser(User user)
        {
            throw new NotImplementedException();
        }

        public int UpVote(Meme meme, User user)
        {
            throw new NotImplementedException();
        }

    }
}
