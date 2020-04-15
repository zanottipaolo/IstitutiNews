using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using schools_identity.Model;

namespace schools_identity.Data
{
    public class listDbContext : DbContext
    {
        public listDbContext(DbContextOptions<listDbContext> options)
            : base(options)
        {
        }
        public DbSet<schools_identity.Model.list> list { get; set; }
    }
}
