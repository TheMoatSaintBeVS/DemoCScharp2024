using Memes.Core.Interfaces;
using Memes.Entities;
using System;
using System.Collections.Generic;

namespace Memes.Services
{
    public class MemeService
    {
        private readonly IMemesRepository _memesRepository;

        public MemeService( IMemesRepository memesRepository)
        {
            _memesRepository = memesRepository;
        }


        public IEnumerable<Meme> GetAllMemes ()
        {
            return _memesRepository.GetAllMemes();
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _memesRepository.GetAllUsers();
        }

    }
}
