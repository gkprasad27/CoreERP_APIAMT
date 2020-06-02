using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        public List<string> UserBranches { get; private set; }

        public BaseController()
        {
            //var identity = HttpContext.User.Identity as ClaimsIdentity;
            //UserBranches = identity.Claims.Where(x => x.Type == "BRANCHES").FirstOrDefault().Value.Split(",").ToList();
        }
    }
}