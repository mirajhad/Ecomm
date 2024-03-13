using Ecomm.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Ecomm.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookCover> BookCovers { get; set; }
        public DbSet<BookWritter> BookWritters { get; set; }
        public DbSet<Product> Products { get; set; }
        
    }
}
