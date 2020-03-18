using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using QCHNT.Model;
using QCHNT.Result;
using System.Collections.Generic;
using System.Linq;

namespace QCHNT.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]

    public class UserController : ControllerBase
    {
        private readonly qchdbContext _context;
        public UserController(qchdbContext context)
        {
            this._context = context;
        }

        [HttpPost]
        [Route("Login")]   //登录
        public IActionResult Login([FromBody] User user)
        {
            LoginResultType result = new LoginResultType();
            string sql = "select * from user where name='" + user.Name + "' and password='"+user.Password+"'";
            List<User> list = _context.User.FromSql(sql).ToList();
            if (list.Count==1)
            {
                result.Errorinfo = "true";
                foreach(User list1 in list)
                {
                    result.Description = list1.Type;
                }
            }
            else

            {
                result.Errorinfo = "false";
                result.Description = "账号或密码错误";

            }
            return Json();
        }

        [HttpGet]
        [Route("Gets")]        //获取所有用户
        public ActionResult<string> Gets()
        {
            var users = _context.User;
            return JsonConvert.SerializeObject(users);
            //return Content("OK");
        }
    }
}
