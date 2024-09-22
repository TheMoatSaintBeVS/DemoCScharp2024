using DemoAPI.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DemoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyPolicy")]
    public class ImagesController : ControllerBase
    {
        // GET: api/<ImagesController>
        [HttpGet]
        public List<Models.Image> Get()
        {
            List<Models.Image> images = new List<Models.Image>();

            // save the image 
            // UserDb2023MemesLight
            SqlConnection sqlConnection = new SqlConnection
                              (@"Server=.\sql2019,9999;database=Db2023MemesLight;user=UserDb2023MemesLight;password=UserDb2023MemesLight");
            //I have used a table named "tblUsers" and fill the fields
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Image", sqlConnection);
            sqlConnection.Open();
            using (SqlDataReader reader = sqlCommand.ExecuteReader())
            {
                while (reader.Read())
                {

                    Models.Image image =
                        new Models.Image
                        {
                            Id = reader.GetInt32(0),
                            Uri = reader.GetString(1),
                            Img = (Byte []) reader.GetValue(2) 
                            //,0,null,0, (int)reader.GetBytes(2, 0, null, 0, 0))

                            //byte[] imageBytes = Convert.FromBase64String(dt.Rows[0]["image"]);
                        };
                    images.Add(image);
                }
            }
                //sqlCommand.ExecuteReader();

                //MemoryStream ms = new MemoryStream();
                //bitmap.Save(ms, ImageFormat.Jpeg);
                //byte[] imageBytes = ms.ToArray();
                //sqlCommand.Parameters.AddWithValue("@img", imageBytes);
                //try
                //{
                //    sqlConnection.Open();
                //    sqlCommand.ExecuteNonQuery();
                //}
                //catch (Exception ex)
                //{
                //    Console.Write(ex.Message);
                //}
                //finally
                //{
                //    sqlConnection.Close();
                //}



                return images;
        }

        // GET api/<ImagesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ImagesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ImagesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ImagesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
