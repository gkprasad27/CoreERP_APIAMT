using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using CoreERP.BussinessLogic.PurhaseHelpers;
using CoreERP.Models;
using CoreERP.DataAccess;
using System.Dynamic;
using CoreERP.BussinessLogic.SalesHelper;

namespace CoreERP.Controllers
{
    [ApiController]
    [Route("api/Purchase/purchases")]
    public class PurchaseController : ControllerBase
    {
      
    }
}