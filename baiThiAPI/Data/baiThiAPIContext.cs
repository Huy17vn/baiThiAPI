using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace baiThiAPI.Models
{
    public class baiThiAPIContext : DbContext
    {
        public baiThiAPIContext (DbContextOptions<baiThiAPIContext> options)
            : base(options)
        {
        }

        public DbSet<baiThiAPI.Models.Students> Students { get; set; }
    }
}
