using MiddlewareDeepDive.Logging.Implementations;
using MiddlewareDeepDive.Logging.Interfaces;
using MiddlewareDeepDive.Middleware.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<ILoggingService, LoggingService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// middleware example
app.Use(async (_, next) =>
{
    // do work that does not write to the Response

    await next.Invoke();

    // do logging or other work that does not write to the Response.
});

// conditional middleware
app.Map("/branchOne", HandleBranchOne);

app.Map("/branchTwo", HandleBranchTwo);

// custom middleware
app.UseLoggingMiddleware();

//Here's the time logging middleware
app.UseTimeLoggingMiddleware();

//Here's the delay. At the moment, the delay is INCLUDED in the time logs.
app.UseIntentionalDelayMiddleware();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

static void HandleBranchOne(IApplicationBuilder app)
{
    app.Run(async context => { await context.Response.WriteAsync("You're on Branch 1!"); });
}

static void HandleBranchTwo(IApplicationBuilder app)
{
    app.Run(async context => { await context.Response.WriteAsync("You're on Branch 2!"); });
}