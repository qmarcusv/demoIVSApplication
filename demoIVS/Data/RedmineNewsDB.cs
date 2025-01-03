using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using demoIVS.Models;

namespace demoIVS.Data
{
    public class RedmineNewsDB : DbContext
    {
        public RedmineNewsDB (DbContextOptions<RedmineNewsDB> options)
            : base(options)
        {
        }

        public DbSet<demoIVS.Models.RedmineNews> RedmineNews { get; set; } = default!;
    }
}
