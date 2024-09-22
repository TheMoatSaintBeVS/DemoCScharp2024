using Memes.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memes.Core.Interfaces
{
   public interface  IImagesRepository
    {
        int Add(Image image);
        IEnumerable<Image> GetAllImages();
        Image Find(string word);
    }
}
