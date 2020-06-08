using Microsoft.EntityFrameworkCore;
using System;
using To_Do.Models;

namespace To_Do.Data
{
    public class ToDoDbContext : DbContext
    {
        public ToDoDbContext(DbContextOptions<ToDoDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ToDo>().HasData(
                new ToDo
                {
                    Id = 1,
                    Title = "Store Inventory",
                    ExpectedCompletion = new DateTime(2020, 6, 10, 6, 05, 12, 000, DateTimeKind.Utc),
                    Assignee = "Marie",
                    Difficulty = 3,
                });

        }
        public DbSet<ToDo> ToDos { get; set; }
    }
}
