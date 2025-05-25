// See https://aka.ms/new-console-template for more information

using RelationalJson.Context;
using RelationalJson.Models;

Console.WriteLine("Hello, World!");

await using var db = new PostgresAppDbContext();

// sample insertion
db.Logs.Add(new LogEntry
{
    Details = new LogDetail
    {
        Level = "Info",
        Message = "Application started...",
        Timestamp = DateTime.UtcNow
    }
});

await db.SaveChangesAsync();

// sample query
var logs = db.Logs
    .Where(l => l.Details!.Level == "Info")
    .ToList();

foreach (var log in logs)
{
    Console.WriteLine($"[{log.Details!.Level}]: {log.Details.Message} at {log.Details.Timestamp}");
}