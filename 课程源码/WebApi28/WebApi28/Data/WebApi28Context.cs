#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApi28.Models;

namespace WebApi28.Data
{
    public class WebApi28Context : DbContext
    {
        public WebApi28Context (DbContextOptions<WebApi28Context> options)
            : base(options)
        {
        }

        public DbSet<WebApi28.Models.Student> Student { get; set; }
    }
}
