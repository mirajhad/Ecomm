using Ecomm.Data;
using Ecomm.Helper;
using Ecomm.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace Ecomm.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CoversController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CoversController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] BookCover cover)

        {
            cover.ImageUrl = await FileHelper.UploadImage(cover.ImageFile);

            await _context.BookCovers.AddAsync(cover);
            await _context.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpGet]
        public async Task<IActionResult> GetCovers(int? pageNumber, int? pageSize)
        {
            int currentPageNumer = pageNumber ?? 1;
            int currentPageSize = pageSize ?? 5;
            var covers = await (from cover in _context.BookCovers
                                 select new
                                 {
                                     Id = cover.Id,
                                     Name = cover.Title,
                                     ImageUrl = cover.ImageUrl,
                                     WritterId = cover.BookWritterId
                                 }).ToListAsync();
            return Ok(covers.Skip((currentPageNumer - 1) * currentPageSize).Take(currentPageSize));
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> CoverDetails(int id)
        {
            var cover = await (_context.BookCovers.Include(x => x.Books).
                Where(x => x.Id == id).FirstOrDefaultAsync());
            return Ok(cover);
        }


    }
}
