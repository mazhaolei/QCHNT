using Microsoft.AspNetCore.Mvc;
using QCHNT.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace QCHNT.Controllers
{
    public class UserController : ControllerBase
    {
        private readonly qchdbContext _context;
        public UserController(qchdbContext context)
        {
            this._context = context;
        }
        private readonly IHttpClientFactory _httpClient;










    }
}
