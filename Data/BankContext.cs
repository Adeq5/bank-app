using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bank.models;
using Microsoft.EntityFrameworkCore;

namespace bank.Data;

public class BankContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Transaction> Transactions { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string dbPath = @"D:\Bank\bank.db"; //podanie poprawnej ścieżki
        optionsBuilder.UseSqlite($"Data Source={dbPath}");

        Console.WriteLine($"Using database at: {dbPath}");

        optionsBuilder.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasKey(u => u.Id);
        modelBuilder.Entity<Transaction>().HasKey(t => t.Id);
    }
}