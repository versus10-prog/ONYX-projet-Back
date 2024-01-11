using BackOnyx.DB;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System.Web.Http.Cors;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackOnyx.Controllers
{
 
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        
        [HttpGet("{userName}")]
        public IActionResult Get(string userName)
        {
            try
            {
                MySqlConnection connection = Config.configInstance();
                User user = new User(connection);

                return Ok(user.UserExist(userName));
            }
            catch
            {
                return BadRequest();
            }
        }

        
        [HttpPost]
        public IActionResult Post([FromBody] string userName)
        {
            Console.WriteLine(userName);
            try
            {
                MySqlConnection connection = Config.configInstance();
                User user = new User(connection);

                if (user.UserExist(userName))
                {
                    return Ok();
                }
                else
                {
                    user.AddUser(userName);
                    return Ok();
                }
            }
            catch
            {
                return BadRequest();
            }
            
        }

    }
}
