using DemoAPI.Db;
using DemoAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Diagnostics;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DemoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        DbSqlserver _dbSqlserver; 
        public TagsController()
        {
            _dbSqlserver = new DbSqlserver();
        }
        // GET: api/<TagsController>
        [HttpGet]
        public List<Models.Tag> Get()
        {
            List<Tag> tags = new List<Tag>();
            using (SqlDataReader reader = _dbSqlserver.Get(" SELECT  * FROM TAG"))
            {
                while (reader.Read())
                {
                    Tag tag =
                        new Tag
                        {
                            Id = reader.GetInt32(0),
                            Description = reader.GetString(1),
                        };
                    tags.Add(tag);
                }
            }
            return tags;
        }

        // GET api/<TagsController>/5
        [HttpGet("{id}")]
        public Tag Get(int id)
        {
            Tag tag = new Tag();
            using (SqlDataReader reader = _dbSqlserver.Get(" SELECT  * FROM TAG WHERE id = " + id))
            {
                while (reader.Read())
                {
                    tag =
                        new Tag
                        {
                            Id = reader.GetInt32(0),
                            Description = reader.GetString(1),
                        };
                   
                }
            }
            return tag;

        }

        // POST api/<TagsController>
        [HttpPost]
        public void Post([FromBody] Tag tag)
        {
            int resultat = -1;
            try
            {

                SqlCommand sqlCommand 
                    = new SqlCommand("INSERT INTO [dbo].[Tag]     ( Description)   VALUES (@Description)", DbSqlserver.SqlConnection);
                DbSqlserver.SqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@Description", tag.Description);
              
                resultat = sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex.Message.ToString());
            }

        

        }

        // PUT api/<TagsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TagsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
