using Microsoft.AspNetCore.Mvc;
using QCHNT.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QCHNT.Result;
using Microsoft.EntityFrameworkCore;

namespace QCHNT.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class CarmanageController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly qchdbContext _context;
        public CarmanageController(qchdbContext context)
        {
            this._context = context;
        }

        [HttpPost]
        [Route("Insert")]   //新增
        public ActionResult<JsonResult> Insert([FromBody] Carmanage carmanage)
        {
            ResultType result = new ResultType();

                carmanage.Id = 0;
                carmanage.Date = DateTime.Now;
                _context.Add(carmanage);
                _context.SaveChanges();
                result.Msg = "true";
                result.Description = "车辆信息新增成功";
            
            return Json(result);
        }
        [HttpPost]
        [Route("Delete")]   //删除
        public ActionResult<JsonResult> Delete([FromBody]  Carmanage carmanage)
        {
            ResultType result = new ResultType();
            try
            {
                var u = _context.Carmanage.Remove(new Carmanage() { Id = carmanage.Id });
                _context.SaveChanges();
                result.Msg = "true";
                result.Description = "删除车辆信息成功";
            }
            catch
            {
                result.Msg = "false";
                result.Description = "删除车辆信息失败";
            }
            return Json(result);
        }
        [HttpPost]
        [Route("Update")]   //修改
        public ActionResult<JsonResult> Update([FromBody] Carmanage carmanage)
        {
            ResultType result = new ResultType();
            try
            {
                carmanage.Date = DateTime.Now;
                var u = _context.Carmanage.Update(carmanage);
                _context.SaveChanges();
                result.Msg = "true";
                result.Description = "修改车辆信息成功";
            }
            catch
            {
                result.Msg = "false";
                result.Description = "修改车辆信息失败";
            }
            return Json(result);
        }

        [HttpGet]
        [Route("Gets")]        //获取所有车辆信息
        public async Task<JsonResult> Gets()
        {
            return Json(_context.Carmanage);
        }



    }
}
