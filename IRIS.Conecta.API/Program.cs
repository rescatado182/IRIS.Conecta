using IRIS.Conecta.API.Middleware;
using IRIS.Conecta.Application;
using IRIS.Conecta.Identity;
using IRIS.Conecta.Identity.DbContext;
using IRIS.Conecta.Infrastructure;
using IRIS.Conecta.Persistence;
using IRIS.Conecta.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddIdentityServices(builder.Configuration);

builder.Services.AddControllers().AddJsonOptions(x => {
    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    x.JsonSerializerOptions.WriteIndented = true;
    x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c => {
    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
    c.IgnoreObsoleteActions();
    c.IgnoreObsoleteProperties();
    c.CustomSchemaIds(type => type.FullName);
});

//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("all", builder => builder
//    .AllowAnyOrigin()
//    .AllowAnyHeader()
//    .AllowAnyMethod()
//    );
//});


builder.Services.AddHttpContextAccessor();


var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();


/*using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<IRISConectaDatabaseContext>();
    context.Database.Migrate();
}

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<IRISConectaIdentityDbContext>();

    if (context.Database.GetPendingMigrations().Any())
    {        
        // Log the issue or apply migrations if in a dev environment
        context.Database.Migrate();
    }
}*/

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseCors(x => x
.AllowAnyMethod()
.AllowAnyHeader()
.SetIsOriginAllowed(origin => true)
.AllowCredentials());

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
