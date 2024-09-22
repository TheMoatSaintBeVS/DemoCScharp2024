using Memes.Entities;
using System;
using System.Collections.Generic;

namespace Memes.Core.Interfaces
{
    public interface  IMemesRepository
    {
        #region Memes 
        int Add(Meme meme);
        IEnumerable<Meme> GetAllMemes();
        Meme FindMeme(int id);
        List<Meme> FindMemes(string word);
        Meme Remove(string id);
        int UpVote(Meme meme, User  user);

        int SaveMeme(Meme meme);


        #endregion


        #region Images
        int Add(Image image);
        IEnumerable<Image> GetAllImages();
        List<Image> FindImages(string word);
   Image FindImage(int  id);
        int SaveImage(Image image);

        #endregion


        #region  Tags
        int Add(Tag tag);
        IEnumerable<Tag> GetAllTags();
        Tag FindTag(int id);
        List<Tag> FindTags(string word);

        int SaveTag(Tag tag);

        #endregion



        #region users 
        int Add(User user);
        IEnumerable<User> GetAllUsers();
        User FindUser(string login);
        User FindUser(int id);
        int SaveUser(User user);

        #endregion 
    }
}
