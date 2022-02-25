using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcDeodorant.Models;

namespace MvcDeodorant.Data
{
    public class MvcDeodorantContext : DbContext
    {
        public MvcDeodorantContext (DbContextOptions<MvcDeodorantContext> options)
            : base(options)
        {
        }

        public DbSet<MvcDeodorant.Models.Deodorant> Deodorant { get; set; }
    }
}
