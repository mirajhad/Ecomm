using Ecomm.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Ecomm.Controllers
{
    [ApiVersion("2.0")]
    [Route("api/home")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        static List<BookWritter> Writers = new List<BookWritter>()
        {
            new BookWritter(){Id=1,Name="Tarun",Gender="male"},
            new BookWritter(){Id=2,Name="Ramesh",Gender="Female"}
        };
        [HttpGet]
        public IEnumerable<BookWritter> Get()
        {
            return Writers;
        }
    }
}
