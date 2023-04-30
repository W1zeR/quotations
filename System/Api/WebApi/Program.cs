using Context;
using Context.Setup;
using WebApi.Configuration;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

var configuration = builder.Configuration;

services.AddAppDbContext(configuration);
services.AddControllers();
services.AddHealthChecks();
services.AddHttpContextAccessor();
services.AddAppSwagger();
services.AddAppAutoMapper();
services.AddAppFluentValidation();
services.AddAppServices();
services.AddAppIdentity();

var app = builder.Build();

app.UseAppSwagger();
app.UseAuthorization();
app.UseAppMiddlewares();
app.MapControllers();
app.MapHealthChecks("/health");

DbInitializer.Execute(app.Services);

app.Run();
