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
        /// <summary>
        /// 新增物料品类信息
        /// </summary>
        /// <param name="goods">物料品类信息</param>
        /// <returns></returns>
        [HttpPost]
        [Route("Insert")]
        public async Task<JsonResponse> Insert([FromBody] Goods goods)
        {
            JsonResponse result = new JsonResponse();
            var list = await _context.Goods.FirstOrDefaultAsync(m => m.GoodsName == goods.GoodsName);
            if (list != null)
            {
                result.Msg = "品类已存在";
                result.Status = ErrorCode.Unknown;
                return result;
            }
            else
            {
                goods.Id = 0;
                goods.Date = DateTime.Now;
                try
                {
                    _context.Add(goods);
                    _context.SaveChanges();
                    result.Msg = "品类新增成功";
                    result.Status = ErrorCode.Sucess;
                    return result;
                }
                catch
                {
                    result.Msg = "品类新增失败";
                    result.Status = ErrorCode.Unknown;
                    return result;
                }
            }
        }
        /// <summary>
        /// 删除物料品类信息
        /// </summary>
        /// <param name="id"> 主键信息</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<JsonResponse> Delete(int id)
        {
            JsonResponse result = new JsonResponse();
            try
            {
                var u = _context.Goods.Remove(new Goods() { Id = id });
                _context.SaveChanges();
                result.Msg = "删除品类成功";
                result.Status = ErrorCode.Sucess;
            }
            catch
            {
                result.Msg = "删除品类失败";
                result.Status = ErrorCode.Unknown;
            }
            return result;
        }
        /// <summary>
        /// 修改物料品类信息
        /// </summary>
        /// <param name="goods">物料品类信息</param>
        /// <returns></returns>
        [HttpPost]
        [Route("Update")]   
        public async Task<JsonResponse> Update([FromBody] Goods goods)
        {
            JsonResponse result = new JsonResponse();
            try
            {
                goods.Date = DateTime.Now;
                var u = _context.Goods.Update(goods);
                _context.SaveChanges();
                result.Msg = "修改品类成功";
                result.Status = ErrorCode.Sucess;
            }
            catch
            {
                result.Msg = "修改品类失败";
                result.Status = ErrorCode.Unknown;
            }
            return result;
        }
        /// <summary>
        ///获取所有地区信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Gets")]     
        public async Task<JsonResult> Gets()
        {
            return Json(_context.Goods);
        }
    }
}
