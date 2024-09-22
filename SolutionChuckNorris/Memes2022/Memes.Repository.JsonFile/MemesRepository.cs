using Memes.Core.Interfaces;
using Memes.Core.Serialization;
using Memes.Entities;
using System;
using System.Collections.Generic;

namespace Memes.Repositories.JsonFile
{
    public class MemesRepository : IMemesRepository
    {
        private readonly string _fileName;

        private readonly List<Meme> _memes;



        public MemesRepository(string filename)
        {

            _memes = TheSerializer.FromJson<List<Meme>>(filename);


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

        public User FindUser(string login)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Image> GetAllImages()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Meme> GetAllMemes()
        {
            throw new NotImplementedException();
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

       

        public int UpVote(Meme meme, User user)
        {
            throw new NotImplementedException();
        }


        public int Save ()
        {
            int result = 0;
            try
            {
              result =  TheSerializer.ToJson<List<Meme>>(_memes, _fileName);
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }

        public User FindUser(int id)
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

        public int SaveMeme(Meme meme)
        {
            throw new NotImplementedException();
        }

        public List<Image> FindImages(string word)
        {
            throw new NotImplementedException();
        }

        public int SaveImage(Image image)
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

        public int SaveTag(Tag tag)
        {
            throw new NotImplementedException();
        }

        public int SaveUser(User user)
        {
            throw new NotImplementedException();
        }

        public Image FindImage(int id)
        {
            throw new NotImplementedException();
        }
    }
}
