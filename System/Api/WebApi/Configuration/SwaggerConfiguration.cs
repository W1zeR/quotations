namespace WebApi.Configuration
{
    public static class SwaggerConfiguration
    {
        public static void UseAppSwagger(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
        }
    }
}
