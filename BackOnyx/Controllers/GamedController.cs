using BackOnyx.DB;
using BackOnyx.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace BackOnyx.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
        public class GamedController : ControllerBase
        {
        [HttpGet("bestGame/{numPart}")]

        public ActionResult<int> GetBestGame(int numPart)
        {
            try
            {
                MySqlConnection connection = Config.configInstance();
                Gamed gamed = new Gamed(connection);

                int nb = gamed.getBestGamed(numPart);

                if (nb < 0)
                {
                    return BadRequest();
                }
                return nb;

            }
            catch
            {
                return BadRequest();
            }
        }

            [HttpGet("averageGame/{numPart}")]

        public ActionResult<int> GetAverageGame(int numPart)
        {
            try
            {
                MySqlConnection connection = Config.configInstance();
                Gamed gamed = new Gamed(connection);
                int nb = gamed.getAverageGamed(numPart);

                if (nb < 0)
                {
                    return BadRequest();
                }
                return nb;
            }
            catch
            {
                return BadRequest();
            }
        }
    


            [HttpPost]

            public IActionResult Post(int time, int numPart) 
            {
                try
            {
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
