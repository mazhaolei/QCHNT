using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using QCHNT.Model;
using QCHNT.ModelList;
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
        /// <summary>
        /// 新增地区信息
        /// </summary>
        /// <param name="area">地区信息</param>
        /// <returns></returns>
        [HttpPost]
        [Route("Insert")]   
        public async Task<JsonResponse> Insert([FromBody] Area area)
        {
            JsonResponse result = new JsonResponse();
            var list = await _context.Area.FirstOrDefaultAsync(m => m.Name == area.Name);
            if (list != null)
            {
                result.Msg = "地区已存在";
                result.Status = ErrorCode.Unknown;
                return result;
            }
            else
            {
                area.Id = 0;
                area.Date = DateTime.Now;
                try
                {
                    _context.Add(area);
                    _context.SaveChanges();
                    result.Msg = "地区新增成功";
                    result.Status = ErrorCode.Sucess;
                    return result;
                }
                catch
                {
                    result.Msg = "地区新增失败";
                    result.Status = ErrorCode.Unknown;
                    return result;
                }
            }
        }
        /// <summary>
        /// 删除地区信息
        /// </summary>
        /// <param name="id">主键信息</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<JsonResponse> Delete(int id)
        {
            JsonResponse result = new JsonResponse();
            try
            {
                var u = _context.Area.Remove(new Area() { Id = id });
                _context.SaveChanges();
                result.Msg = "删除地区成功";
                result.Status = ErrorCode.Sucess;
            }
            catch
            {
                result.Msg = "删除地区失败";
                result.Status = ErrorCode.Unknown;
            }
            return result;
        }
        /// <summary>
        /// 更改地区信息
        /// </summary>
        /// <param name="area">地区信息</param>
        /// <returns></returns>
        [HttpPost]
        [Route("Update")]   
        public async Task<JsonResponse> Update([FromBody] Area area)
        {
            JsonResponse result = new JsonResponse();
            try
            {
                area.Date = DateTime.Now;
                var u = _context.Area.Update(area);
                _context.SaveChanges();
                result.Msg = "修改地区成功";
                result.Status = ErrorCode.Sucess;
            }
            catch
            {
                result.Msg = "修改地区失败";
                result.Status = ErrorCode.Unknown;
            }
            return result;
        }
        /// <summary>
        /// 获取所有地区信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Gets")]       
        public async Task<JsonResponse> Gets()
        {
            JsonResponse<ListArea> result = new JsonResponse<ListArea>();

            ListArea area = new ListArea();
            try
            {
                area.Listarea = await _context.Area.ToArrayAsync();
                result.Data = area;
                result.Msg = "查询成功";
                result.Status = ErrorCode.Sucess;
                return result;
            }
            catch
            {
                result.Data = null;
                result.Msg = "查询失败";
                result.Status = ErrorCode.Unknown;
                return result;
            }
        }
    }
}
