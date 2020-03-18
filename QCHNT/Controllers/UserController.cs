using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using QCHNT.Model;
using QCHNT.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QCHNT.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    

    public class UserController : Microsoft.AspNetCore.Mvc.Controller
    {
        
        private readonly qchdbContext _context;
        public UserController(qchdbContext context)
        {
            this._context = context;
        }

        [HttpPost]
        [Route("Login")]   //登录
        public async Task<JsonResult> Login([FromBody] User user)
        {
            ResultType result = new ResultType();
            string sql = "select * from user where name='" + user.Name + "' and password='"+user.Password+"'";
            List<User> list = _context.User.FromSql(sql).ToList();
            if (list.Count==1)
            {
                result.Msg = "true";
                foreach(User list1 in list)
                {
                    result.Description = list1.Type;
                }
            }
            else
            {
                result.Msg = "false";
                result.Description = "账号或密码错误";
            }
            return Json(result);
        }

        [HttpPost]
        [Route("Insert")]   //新增
        public ActionResult<JsonResult> Insert([FromBody] User user)
        {
            ResultType result = new ResultType();
            string sql = "select * from user where name='" + user.Name + "'";
            List<User> list = _context.User.FromSql(sql).ToList();
            if (list.Count >= 1)
            {
                result.Msg = "false";
                result.Description = "用户已存在";
            }
            else
            {
                user.Id = 0;
                user.Date = DateTime.Now;
                _context.Add(user);
                _context.SaveChanges();
                result.Msg = "true";
                result.Description = "用户新增成功";
            }
                return Json(result);
        }
        [HttpPost]
        [Route("Delete")]   //删除
        public ActionResult<JsonResult> Delete([FromBody] User user)
        {
            ResultType result = new ResultType();
            try
            {
                var u = _context.User.Remove(new User() { Id = user.Id });
                _context.SaveChanges();
                result.Msg = "true";
                result.Description = "删除用户成功";
            }
            catch
            {
                result.Msg = "false";
                result.Description = "删除用户失败";
            }
            return Json(result);
        }
        [HttpPost]
        [Route("Update")]   //修改
        public ActionResult<JsonResult> Update([FromBody] User user)
        {
            ResultType result = new ResultType();
            try
            {
                user.Date = DateTime.Now;
                var u = _context.User.Update(user);
                _context.SaveChanges();
                result.Msg = "true";
                result.Description = "修改用户成功";
            }
            catch
            {
                result.Msg = "false";
                result.Description = "修改用户失败";
            }
            return Json(result);
        }

        [HttpGet]
        [Route("Gets")]        //获取所有用户
        public async Task<JsonResult> Gets()
        {
                return Json(_context.User);
        }

    }
}
