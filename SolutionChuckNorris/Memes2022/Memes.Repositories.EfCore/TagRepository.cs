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
    public class TagRepository : ITagsRepository
    {
        private readonly MemesDbContext _memesDbContext;
        public TagRepository(MemesDbContext memesDbContext)
        {
            _memesDbContext = memesDbContext;
        }
        public TagRepository(string connectionString)
        {
            _memesDbContext = new MemesDbContext(connectionString);
        }
        public int Add(Tag tag)
        {
            _memesDbContext.Tags.Add(tag);
            return _memesDbContext.SaveChanges();
        }
        public IEnumerable<Tag> GetAllTags()
        {
            return _memesDbContext.Tags.Include(t => t.MemeTags).ToList();
        }
        public Tag GetTag(int id)
        {
            return _memesDbContext.Tags.FirstOrDefault(m => m.Id == id);
        }

    }
}
