using COM.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class RPContext : DbContext
    {
        public RPContext(DbContextOptions<RPContext> options) : base(options) { }

        public DbSet<Worker> Workers { get; set; }
    }
}
