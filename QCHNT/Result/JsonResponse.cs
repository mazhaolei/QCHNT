using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QCHNT.Result
{
    public partial class JsonResponse
    {
        /// <summary>
        ///  错误信息
        /// </summary>
        public string Msg { get; set; }
        /// <summary>
        /// 错误代码
        /// </summary>
        public ErrorCode Status { get; set; }
    }

    public class JsonResponse<T> : JsonResponse
    {
        /// <summary>
        /// 返回数据 
       /// </summary>
        public T Data { get; set; }
    }

    public enum ErrorCode
    {
        Unknown = -1,
        Sucess = 0,
    }
}
