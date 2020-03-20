using Microsoft.AspNetCore.Mvc;
using QCHNT.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QCHNT.Result;
using Microsoft.EntityFrameworkCore;
using QCHNT.ModelList;

namespace QCHNT.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class ContractController: Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly qchdbContext _context;
        public ContractController(qchdbContext context)
        {
            this._context = context;
        }
        /// <summary>
        /// 新增合同信息
        /// </summary>
        /// <param name="contract">合同信息</param>
        /// <returns></returns>
        [HttpPost]
        [Route("Insert")]
        public async Task<JsonResponse> Insert([FromBody]  Contract contract)
        {
            JsonResponse result = new JsonResponse();
            var list = await _context.Contract.FirstOrDefaultAsync(m => m.ContractNumber == contract.ContractNumber);
            if (list != null)
            {
                result.Msg = "合同信息已存在";
                result.Status = ErrorCode.Unknown;
                return result;
            }
            else
            {
                contract.Id = 0;
                contract.Date = DateTime.Now;
                try
                {
                    _context.Add(contract);
                    _context.SaveChanges();
                    result.Msg = "合同信息新增成功";
                    result.Status = ErrorCode.Sucess;
                    return result;
                }
                catch
                {
                    result.Msg = "合同信息新增失败";
                    result.Status = ErrorCode.Unknown;
                    return result;
                }
            }
        }
        /// <summary>
        /// 删除合同信息
        /// </summary>
        /// <param name="id">主键信息</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<JsonResponse> Delete(int id)
        {
            JsonResponse result = new JsonResponse();
            try
            {
                var u = _context.Contract.Remove(new Contract() { Id = id });
                _context.SaveChanges();
                result.Msg = "删除合同信息成功";
                result.Status = ErrorCode.Sucess;
            }
            catch
            {
                result.Msg = "删除合同信息失败";
                result.Status = ErrorCode.Unknown;
            }
            return result;
        }
        /// <summary>
        /// 更改合同信息
        /// </summary>
        /// <param name="contract">合同信息</param>
        /// <returns></returns>
        [HttpPost]
        [Route("Update")]
        public async Task<JsonResponse> Update([FromBody] Contract contract)
        {
            JsonResponse result = new JsonResponse();
            try
            {
                contract.Date = DateTime.Now;
                var u = _context.Contract.Update(contract);
                _context.SaveChanges();
                result.Msg = "修改合同信息成功";
                result.Status = ErrorCode.Sucess;
            }
            catch
            {
                result.Msg = "修改合同信息失败";
                result.Status = ErrorCode.Unknown;
            }
            return result;
        }
        /// <summary>
        /// 获取所有合同信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Gets")] 
        public async Task<JsonResponse> Gets()
        {
            JsonResponse<ListContract> result = new JsonResponse<ListContract>();

            ListContract contract = new ListContract();
            try
            {
                contract.Listconrtact= await _context.Contract.ToArrayAsync();
                result.Data = contract;
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

