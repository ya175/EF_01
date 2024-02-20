using EF_task_01.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Task = EF_task_01.models.Task;

namespace EF_task_01
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Task> Tasks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=YASSMINE\SQLEXPRESS;Initial Catalog=EF_task;Integrated Security=True;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Task>()
               .Property(b => b.Date).IsRequired();

            modelBuilder.Entity<Task>().ToTable("NewTask");
            modelBuilder.Entity<Task>().Property("Date").HasColumnName("Deadline");

        }
    }
}
