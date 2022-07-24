using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi012.Models;

namespace WebApi012.Controllers
{
    //[Route("/api/[controller]/abc/")]
    [Route("api/v1/Values/abc")]
    //[Route("api/v2/Values/abc")]
    [ApiController]
    public class Values1Controller : ControllerBase
    {
        //[Route("a1/b1/c1/")]
        //[Route("a/b/c/")]
        [Route("/123/[Action]/456/")]
        [HttpGet]
        public Values Test()
        {
            return new Values() { Age = 20, Gender = "男", Id = 1, Name = "张三" };
        }
    }
}
