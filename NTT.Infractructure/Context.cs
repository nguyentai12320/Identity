using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using NTT.Domain.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace NTT.Infractructure
{
    public class Context : IdentityDbContext<ApplicationUser>
    {
        public Context(DbContextOptions<Context> options) : base(options) { }
        //public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    }
}
