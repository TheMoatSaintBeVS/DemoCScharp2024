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
    public class PlayersController : ControllerBase
    {
        public static IWebHostEnvironment _environment;
        List<Player> _players;

        public PlayersController(IWebHostEnvironment environment)
        {

            _environment = environment;
            _players = new List<Player>();
            _players.Add(new Player() { Id = 7, FirstName = "Mbappé", LastName = "kilian", Number = 7 });
            _players.Add(new Player() { Id = 30, FirstName = "Léo", LastName = "Messi", Number = 30 });

        }

        // GET: api/<PlayersController>
        [HttpGet]
        public List<Player> Get()
        {
            return _players;
        }

        // GET api/<PlayersController>/5
        [HttpGet("{id}")]
        public Player Get(int id)
        {
            return _players.First(player => player.Id == id);
        }

        // POST api/<PlayersController>
        [HttpPost]
        public void Post([FromForm] Player player)
        {
            var file = player.image;
            if (!Directory.Exists(_environment.WebRootPath + "\\Upload"))
            {
                Directory.CreateDirectory(_environment.WebRootPath + "\\Upload\\");
            }
            String newFileName = file.FileName.Split('.')[0] + new Random(10000).Next().ToString() + "." + file.FileName.Split('.')[1];
            using (FileStream filestream = System.IO.File.Create(_environment.WebRootPath + "\\Upload\\" + newFileName) )
            {
                file.CopyTo(filestream);
                filestream.Flush();
                //  return "\\Upload\\" + objFile.files.FileName;
            }

            string firstText = "Hello";
            string secondText = "World";

            PointF firstLocation = new PointF(10f, 10f);
            PointF secondLocation = new PointF(10f, 50f);

          string imageFilePath = _environment.WebRootPath + "\\Upload\\" + newFileName;

            System.Drawing.Bitmap newBitmap;
            //using ( Bitmap bitmap= new Bitmap(imageFilePath))
            Bitmap bitmap = new Bitmap(imageFilePath) ;
           //using (var bitmap = (Bitmap)File.(System.IO.File.OpenRead(imageFilePath), "image.jpeg"))//load the image file
            //{
            //    using (Graphics graphics = Graphics.FromImage(bitmap))
             Graphics graphics = Graphics.FromImage(bitmap);

            using (Font arialFont = new Font("Arial", 10))
            {
                graphics.DrawString(firstText, arialFont, Brushes.Blue, firstLocation);
                graphics.DrawString(secondText, arialFont, Brushes.Red, secondLocation);
            }

            newBitmap = new Bitmap(bitmap);


            newBitmap.Save(imageFilePath.Split('.')[0] + new Random(10000).Next().ToString() + "." + imageFilePath.Split('.')[1]
                );//save the image file
            newBitmap.Dispose();



            // save the image 
            // UserDb2023MemesLight
            SqlConnection sqlConnection = new SqlConnection
                              (@"Server=.\sql2019,9999;database=Db2023MemesLight;user=UserDb2023MemesLight;password=UserDb2023MemesLight");
            //I have used a table named "tblUsers" and fill the fields
            SqlCommand sqlCommand = new SqlCommand("INSERT INTO [dbo].[Image]     ( [Uri], [Img])   VALUES ('uri',@img)", sqlConnection);

            MemoryStream ms = new MemoryStream();
            bitmap.Save(ms, ImageFormat.Jpeg);
            byte[] imageBytes = ms.ToArray();
            sqlCommand.Parameters.AddWithValue("@img", imageBytes );
            try
            {
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }

        }

        // PUT api/<PlayersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PlayersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
