using MiddlewareLibrary.Middleware;
using MiddleWarev03.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseMiddleware<CustomMiddlewareControl>();

app.MapGet("/", ControlHelper.HandleRequest);

var lifetime = app.Services.GetRequiredService<IHostApplicationLifetime>();
lifetime.ApplicationStopping.Register(() =>
{
    // Perform cleanup or shutdown operations
    // This code will be executed when the application is stopping
    app.UseMiddleware<CustomMiddlewareStep3>();    
});

app.UseMiddleware<CustomMiddleware>();
app.UseMiddleware<CustomMiddlewareStep2>();
//app.UseMiddleware<CustomMiddlewareStep3>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
