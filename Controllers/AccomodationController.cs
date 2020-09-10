using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Kiwiland.DataAccess;
using Kiwiland.Models;
using Microsoft.Extensions.Logging;
using System.Runtime.CompilerServices;

namespace Kiwiland.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccomodationController : ControllerBase
    {
        private readonly ILogger<registerManger> _regManager;
       // private readonly ILogger<AccomodationController> _logger;

        public AccomodationController(ILogger<registerManger> regManager)
        {
           // this._logger = logger;
            this._regManager = regManager;
        }
        [HttpGet]
        public IEnumerable<TestRegister> AccomodationDisplay()
        {
            RegisterDbContext db = new RegisterDbContext();
             return db.TestRegisters.ToList();
        }
        [HttpPost]
        public void AccomodationPost()
        {
            RegisterDbContext db = new RegisterDbContext();
            
        }
        
    }
}
