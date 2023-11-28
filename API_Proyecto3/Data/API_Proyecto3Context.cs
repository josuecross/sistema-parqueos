using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using API_Proyecto3.Models;

namespace API_Proyecto3.Data
{
    public class API_Proyecto3Context : DbContext
    {
        public API_Proyecto3Context (DbContextOptions<API_Proyecto3Context> options)
            : base(options)
        {
        }
        public DbSet<API_Proyecto3.Models.Empleado>? Empleado { get; set; }
        public DbSet<API_Proyecto3.Models.Parqueo>? Parqueo { get; set; }
        public DbSet<API_Proyecto3.Models.Tiquete>? Tiquete { get; set; }
    }
}
