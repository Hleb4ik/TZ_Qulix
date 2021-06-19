using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace TZ_Qulix.Models
{
    public class WorkerContext : DbContext
    {
        public DbSet<Worker> Workers { get; set; }

        public DbSet<Company> Companies { get; set; }
    }
}