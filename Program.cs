using SignalRMessages.Hubs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSignalR();

builder.Services.AddCors();

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

app.Run();