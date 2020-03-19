using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    public class GoodsController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly qchdbContext _context;
        public GoodsController(qchdbContext context)
        {
            this._context = context;
        }
        [HttpPost]
        [Route("Insert")]   //新增
        public ActionResult<JsonResult> Insert([FromBody] Goods goods)
        {
            ResultType result = new ResultType();
            string sql = "select * from goods where name='" + goods.GoodsName + "'";
            List<Goods> list = _context.Goods.FromSql(sql).ToList();
            if (list.Count >= 1)
            {
                result.Msg = "false";
                result.Description = "品类已存在";
            }
            else
            {
                goods.Id = 0;
                goods.Date = DateTime.Now;
                _context.Add(goods);
                _context.SaveChanges();
                result.Msg = "true";
                result.Description = "品类新增成功";
            }
            return Json(result);
        }
        [HttpPost]
        [Route("Delete")]   //删除
        public ActionResult<JsonResult> Delete([FromBody] Goods goods)
        {
            ResultType result = new ResultType();
            try
            {
                var u = _context.Goods.Remove(new Goods() { Id = goods.Id });
                _context.SaveChanges();
                result.Msg = "true";
                result.Description = "删除品类成功";
            }
            catch
            {
                result.Msg = "false";
                result.Description = "删除品类失败";
            }
            return Json(result);
        }
        [HttpPost]
        [Route("Update")]   //修改
        public ActionResult<JsonResult> Update([FromBody] Goods goods)
        {
            ResultType result = new ResultType();
            try
            {
                goods.Date = DateTime.Now;
                var u = _context.Goods.Update(goods);
                _context.SaveChanges();
                result.Msg = "true";
                result.Description = "修改品类成功";
            }
            catch
            {
                result.Msg = "false";
                result.Description = "修改品类失败";
            }
            return Json(result);
        }

        [HttpGet]
        [Route("Gets")]        //获取所有地区
        public async Task<JsonResult> Gets()
        {
            return Json(_context.Goods);
        }
    }
}
