using SignalRMessages.Classes;
using SignalRMessages.Hubs;
using SignalRMessages.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSignalR();
builder.Services.AddCors();
builder.Services.AddSingleton<Cache<Message>>();
builder.Services.AddControllers();


var app = builder.Build();

app.UseRouting();
app.UseCors(policy =>
{
    policy.WithOrigins(builder.Configuration["ClientOrigin"] ?? throw new Exception("ClientOrigin not defined"))
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials();
});
app.MapHub<ChatHub>("/chathub");
app.MapControllers();

app.Run();