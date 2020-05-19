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
        public List<string> UserBranches
        {
            get
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                var branches = identity.Claims.Where(x => x.Type == "BRANCHES").FirstOrDefault().Value;

                return branches.Split(",").ToList();
            }

        }
    }
}