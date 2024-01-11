using BackOnyx.DB;
using BackOnyx.Models;
using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Newtonsoft.Json.Linq;

namespace BackOnyx.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
        public class GamedController : ControllerBase
        {
        [HttpGet("{numPart}")]

        public ActionResult<AverBestModel> GetBestGame(int numPart)
        {
            try
            {
                MySqlConnection connection = Config.configInstance();
                Gamed gamed = new Gamed(connection);
                int average = gamed.getAverageGamed(numPart);

                int max = gamed.getBestGamed(numPart);

                if (max < 0 || average < 0)
                {
                    return BadRequest();
                }

                var result = new AverBestModel( average, max, numPart );
                
                return result;

            }
            catch
            {
                return BadRequest();
            }
        }



            [HttpPost]

            public IActionResult Post([FromBody] GamedModel data) 
            {
                try
            {
                int time = data.Time;
                int numPart = data.NumPart;
                MySqlConnection connection = Config.configInstance();
                Gamed gamed = new Gamed(connection);
                GamedModel gamedM = new GamedModel(time, numPart);
                gamed.addGamed(gamedM);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
                

            }
        }
}
