using BackOnyx.DB;
using BackOnyx.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace BackOnyx.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamehController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> GetGameh()
        {
            try
            {
                MySqlConnection connection = Config.configInstance();
                Gameh gameh = new Gameh(connection);
                List<Object> liste = gameh.getBestScore();

                return StatusCode(200,JsonConvert.SerializeObject(liste));
            }
            catch
            {


                // Retournez une réponse d'erreur avec un statut 500
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] string userName)
        {
            try
            {
                MySqlConnection connection = Config.configInstance();
                Gameh gameh = new Gameh(connection);
                GamehModel gamehM = new GamehModel(userName, DateTime.Now,0,0);

                int numPart = gameh.addGameh(gamehM);
                return StatusCode(200, JsonConvert.SerializeObject(numPart));
            }
            catch(Exception ex)
            {
                Console.WriteLine($"erreur : {ex.Message}");
               return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] AverBestModel model)
        {
            try
            {
                MySqlConnection connection = Config.configInstance();
                Gameh gameh = new Gameh(connection);
                gameh.putData(model.NumPart, model.Best, model.Average);
                return StatusCode(200);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"erreur : {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
