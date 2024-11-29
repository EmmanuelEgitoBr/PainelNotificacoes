using RealTimeNotificationApp.Api.SignalHub;
using RealTimeNotificationApp.Ioc.Ioc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddAppInfrastructure();
builder.Services.AddSwaggerInfrastructure();
builder.Services.AddMongoInfrastructure(builder.Configuration);
builder.Services.AddCorsConfiguration();
builder.Services.AddSignalR();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapHub<OrderHub>("/orderHub"); // Defina a rota do SignalR
});

app.MapControllers();

//app.MapHub<OrderHub>("/orderHub");

app.Run();
