using Memes.Core.Interfaces;
using Memes.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memes.Repositories.EfCore
{
    public class Repository : IMemesRepository, ITagsRepository
    {
        private readonly MemesDbContext _memesDbContext;
        public Repository(MemesDbContext memesDbContext)
        {
            _memesDbContext = memesDbContext;
        }


        public Repository(string connectionString)
        {
            _memesDbContext = new MemesDbContext(connectionString);
        }
        public int Add(Meme meme)
        {
            _memesDbContext.Memes.Add(meme);
            return _memesDbContext.SaveChanges();
        }

        public int Add(Image image)
        {
            _memesDbContext.Images.Add(image);
            return _memesDbContext.SaveChanges();
        }

        public int Add(Tag tag)
        {
            _memesDbContext.Tags.Add(tag);
            return _memesDbContext.SaveChanges();
        }

        public int Add(User user)
        {
            _memesDbContext.Users.Add(user);
            return _memesDbContext.SaveChanges();
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
            return _memesDbContext.Images.FirstOrDefault(m => m.Id == id);
        }

        public List<Image> FindImages(string word)
        {
            throw new NotImplementedException();
        }

        public Meme FindMeme(int id)
        {
           return _memesDbContext.Memes.FirstOrDefault( m => m.Id == id);
        }

        public List<Meme> FindMemes(string word)
        {
            throw new NotImplementedException();
        }

        public Tag FindTag(int id)
        {
            return _memesDbContext.Tags.FirstOrDefault(m => m.Id == id);
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
            return _memesDbContext.Users.FirstOrDefault(m => m.Id == id);
        }

        public IEnumerable<Image> GetAllImages()
        {
            return _memesDbContext.Images.ToList();
        }

        public IEnumerable<Meme> GetAllMemes()
        {
            return _memesDbContext.Memes.Include(m => m.MemeTags).ToList();
        }

        public IEnumerable<Tag> GetAllTags()
        {
            return _memesDbContext.Tags.Include(t => t.MemeTags).ToList();
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _memesDbContext.Users.ToList();
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
            _memesDbContext.Memes.Update(meme);
            return _memesDbContext.SaveChanges();
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

        public Tag GetTag(int id)
        {
            return _memesDbContext.Tags.FirstOrDefault(m => m.Id == id);
        }
    }
}
