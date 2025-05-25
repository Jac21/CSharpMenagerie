using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using RelationalJson.Models;

namespace RelationalJson.Context;

/// <summary>
/// ➜  RelationalJson git:(master) ✗ dotnet tool install --global dotnet-ef                    
/// ➜  RelationalJson git:(master) ✗ dotnet ef migrations add InitJsonTable                    
/// ➜  RelationalJson git:(master) ✗ dotnet ef database update                                 
/// </summary>
public class PostgresAppDbContext : DbContext
{
    public DbSet<LogEntry> Logs => Set<LogEntry>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost; Database=entity-framework-dev; Username=jeremycantu; Password=****");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<LogEntry>(entity =>
        {
            entity.Property(e => e.Details)
                .HasColumnType("jsonb")
                .HasConversion(
                    v => JsonSerializer.Serialize(v, new JsonSerializerOptions()),
                    v => JsonSerializer.Deserialize<LogDetail>(v, new JsonSerializerOptions()));
        });
    }
}