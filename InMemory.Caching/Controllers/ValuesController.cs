using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace InMemory.Caching.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        readonly IMemoryCache _memoryCache;
        public ValuesController( IMemoryCache memoryCache)
        {
            _memoryCache=memoryCache;
        }

        //[HttpGet("set/{name}")]
        //public void SetName(string name)
        //{
        //    _memoryCache.Set("name", name);

        //}

        //[HttpGet("GetName")]
        //public string Get()
        //{
        //    if (_memoryCache.TryGetValue<string>("name",out string name))
        //    {
        //        return name.Substring(3);

        //    }

        //    return null;

        //    //var name = _memoryCache.Get<string>("name");
        //    //return name.Substring(3);

        //}

    [HttpGet("Setdate")]

    public void SetDate()
        {
            _memoryCache.Set<DateTime>("date", DateTime.Now, options: new()
            {
                AbsoluteExpiration = DateTime.Now.AddSeconds(30),
                SlidingExpiration = TimeSpan.FromSeconds(5)
            });
        }

    [HttpGet("Getdate")]

        public DateTime GetDate()
        {
            return _memoryCache.Get<DateTime>("date");

        }




    }
}
