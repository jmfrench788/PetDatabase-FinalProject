using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PetServices_MVC.Data.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Pet> Pets { get; set; }
        public DbSet<PetService_> PetServices { get; set; }
        public DbSet<AdoptablePet> AdoptablePets { get; set; }
        public DbSet<PetType> PetTypes { get; set; }
    }
}