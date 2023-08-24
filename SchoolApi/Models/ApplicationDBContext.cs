using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }
        public DbSet<ClassModel> Class { get; set; }
        public DbSet<SectionModel> Section { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClassModel>().ToTable("ClassMaster");
            modelBuilder.Entity<SectionModel>().ToTable("SectionMaster");
        }
    }
}
