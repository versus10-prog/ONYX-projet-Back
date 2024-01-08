using BackOnyx.DB;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackOnyx.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        
        [HttpGet("{userName}")]
        public bool Get(string userName)
        {
            MySqlConnection connection = Config.configInstance();
            User user = new User(connection);
            return user.UserExist(userName);
        }

        
        [HttpPost]
        public bool Post([FromBody] string userName)
        {
            
            MySqlConnection connection = Config.configInstance();
            User user = new User(connection);

            if(user.UserExist(userName)) 
            {
                return false;
            }
            else
            {
                user.AddUser(userName);
                return true;
            }
            
        }

    }
}
