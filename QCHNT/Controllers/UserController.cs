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
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="user">登录用户信息（账号密码）</param>
        /// <returns></returns>
        [HttpPost]
        [Route("Login")]  
        public async Task<JsonResponse> Login([FromBody] User user)
        {
            JsonResponse result = new JsonResponse();
            string sql = "select * from user where name='" + user.Name + "' and password='"+user.Password+"'";
            List<User> list = _context.User.FromSql(sql).ToList();
            if (list.Count==1)
            {
                result.Status = ErrorCode.Sucess;
                foreach (User list1 in list)
                {
                    result.Msg = list1.Type;
                }
            }
            else
            {
                result.Msg = "账号或密码错误";
                result.Status = ErrorCode.Unknown;
            }
            return result;
        }
        /// <summary>
        /// 新增用户信息
        /// </summary>
        /// <param name="user">用户信息</param>
        /// <returns></returns>
        [HttpPost]
        [Route("Insert")]   
        public async Task<JsonResponse> Insert([FromBody] User user)
        {
            JsonResponse result = new JsonResponse();
            var list = await _context.User.FirstOrDefaultAsync(m => m.Name == user.Name);
            if (list != null)
            {
                result.Msg = "用户已存在";
                result.Status = ErrorCode.Unknown;
                return result;
            }
            else
            {
                user.Id = 0;
                user.Date = DateTime.Now;
                try
                {
                    _context.Add(user);
                    _context.SaveChanges();
                    result.Msg = "用户新增成功";
                    result.Status = ErrorCode.Sucess;
                    return result;
                }
                catch
                {
                    result.Msg = "用户新增失败";
                    result.Status = ErrorCode.Unknown;
                    return result;
                }
            }
        }
        /// <summary>
        /// 删除用户信息
        /// </summary>
        /// <param name="id">主键信息</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<JsonResponse> Delete(int id)
        {
            JsonResponse result = new JsonResponse();
            try
            {
                var u = _context.User.Remove(new User() { Id = id });
                _context.SaveChanges();
                result.Msg = "删除用户成功";
                result.Status = ErrorCode.Sucess;
            }
            catch
            {
                result.Msg = "删除用户失败";
                result.Status = ErrorCode.Unknown;
            }
            return result;
        }
        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="user">用户信息</param>
        /// <returns></returns>
        [HttpPost]
        [Route("Update")]   
        public async Task<JsonResponse> Update([FromBody] User user)
        {
            JsonResponse result = new JsonResponse();
            try
            {
                user.Date = DateTime.Now;
                var u = _context.User.Update(user);
                _context.SaveChanges();
                result.Msg = "修改用户成功";
                result.Status = ErrorCode.Sucess;
            }
            catch
            {
                result.Msg = "修改用户失败";
                result.Status = ErrorCode.Unknown;
            }
            return result;
        }
        /// <summary>
        /// 获取所有用户信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Gets")]        
        public async Task<JsonResult> Gets()
        {
                return Json(_context.User);
        }

    }
}
