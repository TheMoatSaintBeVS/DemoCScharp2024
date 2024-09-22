using Memes.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memes.Core.Interfaces
{
    public interface ITagsRepository
    {
        int Add(Tag tag);
        IEnumerable<Tag> GetAllTags();
        Tag GetTag(int id); 
    }
}
