using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FormApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace FormApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<FormApp.Models.FormModel> FormModel { get; set; } = default!;
    }
}
