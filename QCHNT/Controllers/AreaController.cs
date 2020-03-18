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
    public class AreaController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly qchdbContext _context;
        public AreaController(qchdbContext context)
        {
            this._context = context;
        }

        [HttpPost]
        [Route("Insert")]   //新增
        public ActionResult<JsonResult> Insert([FromBody] Area area)
        {
            ResultType result = new ResultType();
            string sql = "select * from area where name='" + area.Name + "'";
            List<Area> list = _context.Area.FromSql(sql).ToList();
            if (list.Count >= 1)
            {
                result.Msg = "false";
                result.Description = "地区已存在";
            }
            else
            {
                area.Id = 0;
                area.Date = DateTime.Now;
                _context.Add(area);
                _context.SaveChanges();
                result.Msg = "true";
                result.Description = "地区新增成功";
            }
            return Json(result);
        }
        [HttpPost]
        [Route("Delete")]   //删除
        public ActionResult<JsonResult> Delete([FromBody]  Area area)
        {
            ResultType result = new ResultType();
            try
            {
                var u = _context.Area.Remove(new Area() { Id = area.Id });
                _context.SaveChanges();
                result.Msg = "true";
                result.Description = "删除地区成功";
            }
            catch
            {
                result.Msg = "false";
                result.Description = "删除地区失败";
            }
            return Json(result);
        }
        [HttpPost]
        [Route("Update")]   //修改
        public ActionResult<JsonResult> Update([FromBody] Area area)
        {
            ResultType result = new ResultType();
            try
            {
                area.Date = DateTime.Now;
                var u = _context.Area.Update(area);
                _context.SaveChanges();
                result.Msg = "true";
                result.Description = "修改地区成功";
            }
            catch
            {
                result.Msg = "false";
                result.Description = "修改地区失败";
            }
            return Json(result);
        }

        [HttpGet]
        [Route("Gets")]        //获取所有地区
        public async Task<JsonResult> Gets()
        {
            return Json(_context.Area);
        }
    }
}
