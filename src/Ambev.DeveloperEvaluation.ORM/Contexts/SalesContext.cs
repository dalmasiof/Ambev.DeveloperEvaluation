﻿using Ambev.DeveloperEvaluation.Domain.Sales.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Ambev.DeveloperEvaluation.ORM.Contexts
{
    public class SalesContext : DbContext
    {
        public DbSet<Sale> Sales { get; set; }

        public SalesContext(DbContextOptions<SalesContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

        public class YourDbContextFactory : IDesignTimeDbContextFactory<SalesContext>
        {
            public SalesContext CreateDbContext(string[] args)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

                var builder = new DbContextOptionsBuilder<SalesContext>();
                var connectionString = configuration.GetConnectionString("DefaultConnection");

                builder.UseNpgsql(
                       connectionString,
                       b => b.MigrationsAssembly("Ambev.DeveloperEvaluation.WebApi")
                );

                return new SalesContext(builder.Options);
            }
        }
    }
}
