using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Gyakorlo.Data
{
    public class AppDbContext : IdentityDbContext<Felhasznalo>
    {
        public DbSet<Csoport> Csoportok { get; set; }
        public DbSet<Uzenetek> Uzenet { get; set; }
        public DbSet<Felhasznalo> Felhasznalo { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public void UzenetFelvesz(Uzenetek uzenet)
        {
            Uzenet.Add(uzenet);
            this.SaveChanges();
        }
    }
}
