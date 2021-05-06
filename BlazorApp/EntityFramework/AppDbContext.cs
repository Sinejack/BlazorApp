using BlazorApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.EntityFramework
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

       
    }
}