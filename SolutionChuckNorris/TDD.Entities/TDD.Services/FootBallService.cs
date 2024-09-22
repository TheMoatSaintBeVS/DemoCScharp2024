using TDD.Interfaces;

namespace TDD.Services
{
    public class FootballService
    {
        IRepository _repository;

        public FootballService(IRepository repository)
        {
            _repository = repository;   
        }


        public int GetCost ()
        {

            return _repository.GetAll().Sum(p => p.Value);

        }





    }
}