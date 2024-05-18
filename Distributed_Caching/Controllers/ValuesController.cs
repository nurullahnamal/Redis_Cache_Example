﻿using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;

namespace Distributed_Caching.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IDistributedCache _distributedCache;

        public ValuesController(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }
        [HttpGet("Set")]
        public async Task<IActionResult> Set(string name,string surname )
        {
            await _distributedCache.SetStringAsync("name", name,options:new ()
            {
                AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(111),
                SlidingExpiration = TimeSpan.FromSeconds(111)

            });
          await  _distributedCache.SetAsync("surname", Encoding.UTF8.GetBytes(surname),options: new()
          {
              AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(111),
              SlidingExpiration = TimeSpan.FromSeconds(1111)

          });
          return Ok(); 

        }


        [HttpGet("get")]
        public  async Task<IActionResult> Get()
        {
         var name=await _distributedCache.GetStringAsync("name");
         var surnameBinary=await  _distributedCache.GetAsync("surname");
         var surname = Encoding.UTF8.GetString(surnameBinary);
            return Ok(new 
            {
                name,surname
            });

        }
    }
}
