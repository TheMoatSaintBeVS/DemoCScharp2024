using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace Memes.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        //todo 
        // quels éléments sont communs à toutes les actions ?
        // chaine de connection
        // connection 
        string _connectionString;
        SqlConnection _connection;
        /// <summary>
        /// Ctor 
        /// pour initialiser mon objet
        /// </summary>
        public WeatherForecastController()
        {
            _connectionString  = @"Data Source =.; Initial Catalog = Db2023MemesDemo; User ID = UserDb2023memesDemo; Password = UserDb2023memesDemo";
         _connection = new SqlConnection(_connectionString);

        }

        [HttpGet(Name = "GetStudent")]
        public List<Student> Get()
        {
            List<Student> students = new List<Student>();
            _connection.Open();
            // SELECT 


           // students.Add(); /// 
            _connection.Close();
            return students;
        }

        [HttpPost]
        public void Post([FromBody]  Student student  )
        {
           _connection.Open();
            //INSERT 
            _connection.Close();
        }
    }
}