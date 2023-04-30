using EmailSender.Configuration;
using Mails;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

var configuration = builder.Configuration;

services.AddControllers();
services.AddHealthChecks();
services.AddHttpContextAccessor();
services.AddAppSwagger();
services.AddAppAutoMapper();
services.AddAppFluentValidation();
services.AddAppSettings(configuration);
services.AddMailService();

var app = builder.Build();

app.UseAppSwagger();
app.UseAuthorization();
app.UseAppMiddlewares();
app.MapControllers();
app.MapHealthChecks("/health");

app.Run();
