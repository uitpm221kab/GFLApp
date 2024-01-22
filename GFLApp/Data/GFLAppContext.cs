using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GFLApp.Models;

namespace GFLApp.Data
{
    public class GFLAppContext : DbContext
    {
        public GFLAppContext (DbContextOptions<GFLAppContext> options)
            : base(options)
        {
        }

        public DbSet<GFLApp.Models.Movie> Movie { get; set; } = default!;
    }
}
