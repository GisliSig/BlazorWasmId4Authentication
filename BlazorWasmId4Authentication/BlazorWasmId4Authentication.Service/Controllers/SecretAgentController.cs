using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorWasmId4Authentication.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorWasmId4Authentication.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "Admin")]
    public class SecretAgentController : ControllerBase
    {
        private static readonly SecretAgent[] SecretAgents = new SecretAgent[]
        {
            new SecretAgent()
            {
                Id = 1,
                Name = "James Bond",
                Alias = "007",
                IsMissing = false
            },
            new SecretAgent()
            {
                Id = 1,
                Name = "Some other dude",
                Alias = "who cares :D",
                IsMissing = true
            }
        };

        [HttpGet]
        public IEnumerable<SecretAgent> Get()
        {
            return SecretAgents.ToArray();
        }
    }
}
