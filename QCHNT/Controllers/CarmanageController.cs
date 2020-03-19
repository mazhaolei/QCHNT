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

        /// <summary>
        /// 新增车辆管理信息
        /// </summary>
        /// <param name="carmanage">车辆管理信息</param>
        /// <returns></returns>
        [HttpPost]
        [Route("Insert")]   
        public async Task<JsonResponse> Insert([FromBody] Carmanage carmanage)
        {
            JsonResponse result = new JsonResponse();

                carmanage.Id = 0;
                carmanage.Date = DateTime.Now;
            try
            {
                _context.Add(carmanage);
                _context.SaveChanges();
                result.Msg = "车辆信息新增成功";
                result.Status = ErrorCode.Sucess;
                return result;
            }
            catch
            {
                result.Msg = "车辆信息新增失败";
                result.Status = ErrorCode.Unknown;
                return result;
            }

        }
        /// <summary>
        /// 删除车辆信息
        /// </summary>
        /// <param name="id">主键信息</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<JsonResponse> Delete(int id)
        {
            JsonResponse result = new JsonResponse();
            try
            {
                var u = _context.Carmanage.Remove(new Carmanage() { Id = id });
                _context.SaveChanges();
                result.Msg = "删除车辆信息成功";
                result.Status = ErrorCode.Sucess;
            }
            catch
            {
                result.Msg = "删除车辆信息失败";
                result.Status = ErrorCode.Unknown;
            }
            return result;
        }
        /// <summary>
        /// 修改车辆管理信息
        /// </summary>
        /// <param name="carmanage">车辆管理信息</param>
        /// <returns></returns>
        [HttpPost]
        [Route("Update")]
        public async Task<JsonResponse> Update([FromBody] Carmanage carmanage)
        {
            JsonResponse result = new JsonResponse();
            try
            {
                carmanage.Date = DateTime.Now;
                var u = _context.Carmanage.Update(carmanage);
                _context.SaveChanges();
                result.Msg = "修改车辆信息成功";
                result.Status = ErrorCode.Sucess;
            }
            catch
            {
                result.Msg = "修改车辆信息失败";
                result.Status = ErrorCode.Unknown;
            }
            return result;
        }
        /// <summary>
        /// 获取所有车辆信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Gets")]        
        public async Task<JsonResult> Gets()
        {
            return Json(_context.Carmanage);
        }



    }
}
