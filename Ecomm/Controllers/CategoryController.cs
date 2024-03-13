using Azure.Storage.Blobs;
using Ecomm.Data;
using Ecomm.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
/***
 * Status Code :
 * 1xx :  Informational
 * 2xx :  Successful
 * 3xx :  Redirection
 * 4xx :  Client Error
 * 5xx :  Server Error 
 */

namespace Ecomm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        // GET: api/<CategoryController>
        private ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }
        
    }
}
