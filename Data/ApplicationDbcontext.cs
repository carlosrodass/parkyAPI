using Microsoft.EntityFrameworkCore;
using ParkyApi.Models;
using ParkyApi.Models.Dtos;

namespace ParkyApi.Data
{
    public class ApplicationDbcontext : DbContext
    {
        public ApplicationDbcontext(DbContextOptions<ApplicationDbcontext> options) : base(options)
        {

        }

        public DbSet<NationalPark> NationalParks { get; set; }
    }
}
