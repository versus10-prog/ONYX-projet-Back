using BackOnyx.DB;
using BackOnyx.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
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

                return Ok(JsonConvert.SerializeObject(liste));
            }
            catch
            {
                return BadRequest();

            }
            
        }


        [HttpPost]
        public IActionResult Post(string userName, int bestTime, int averageTime)
        {
            try
            {
                MySqlConnection connection = Config.configInstance();
                Gameh gameh = new Gameh(connection);
                GamehModel gamehM = new GamehModel(userName, DateTime.Now, averageTime, bestTime);

                gameh.addGameh(gamehM);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
