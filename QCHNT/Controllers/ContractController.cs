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
    public class ContractController: Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly qchdbContext _context;
        public ContractController(qchdbContext context)
        {
            this._context = context;
        }
        [HttpPost]
        [Route("Insert")]   //新增
        public ActionResult<JsonResult> Insert([FromBody]  Contract contract)
        {
            ResultType result = new ResultType();
            string sql = "select * from contract where name='" + contract.ContractNumber + "'";
            List<Contract> list = _context.Contract.FromSql(sql).ToList();
            if (list.Count >= 1)
            {
                result.Msg = "false";
                result.Description = "合同信息已存在";
            }
            else
            {
                contract.Id = 0;
                contract.Date = DateTime.Now;
                _context.Add(contract);
                _context.SaveChanges();
                result.Msg = "true";
                result.Description = "合同信息新增成功";
            }
            return Json(result);
        }
        [HttpPost]
        [Route("Delete")]   //删除
        public ActionResult<JsonResult> Delete([FromBody] Contract contract)
        {
            ResultType result = new ResultType();
            try
            {
                var u = _context.Contract.Remove(new Contract() { Id = contract.Id });
                _context.SaveChanges();
                result.Msg = "true";
                result.Description = "删除合同信息成功";
            }
            catch
            {
                result.Msg = "false";
                result.Description = "删除合同信息失败";
            }
            return Json(result);
        }
        [HttpPost]
        [Route("Update")]   //修改
        public ActionResult<JsonResult> Update([FromBody] Contract contract)
        {
            ResultType result = new ResultType();
            try
            {
                contract.Date = DateTime.Now;
                var u = _context.Contract.Update(contract);
                _context.SaveChanges();
                result.Msg = "true";
                result.Description = "修改合同信息成功";
            }
            catch
            {
                result.Msg = "false";
                result.Description = "修改合同信息失败";
            }
            return Json(result);
        }

        [HttpGet]
        [Route("Gets")]        //获取所有合同
        public async Task<JsonResult> Gets()
        {
            return Json(_context.Contract);
        }

    }
}

