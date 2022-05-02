using Microsoft.EntityFrameworkCore;
using OverbookedAPI.Data;
using OverbookedAPI.Middleware;

var builder = WebApplication.CreateBuilder(args);

{
    var services = builder.Services;

    // services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    //     .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));

    services.AddDbContext<OverbookedDbContext>(opts =>
    {
        var connectionString = builder.Configuration.GetValue<string>("DatabaseConnectionString");
        if (connectionString == null)
        {
            throw new Exception("No Connection String");
        }
        else
        {
            opts.UseNpgsql(connectionString);
        }
    });
    services.AddTransient<AuthCheckMiddleware>();
    services.AddControllers();
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();
}

var app = builder.Build();

{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
        app.UseDeveloperExceptionPage();
    }

    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        var context = services.GetRequiredService<OverbookedDbContext>();
        context.Database.EnsureCreated();
    }

    app.UseMiddleware<AuthCheckMiddleware>();

    app.UseHttpsRedirection();

    app.UseAuthentication();

    app.UseAuthorization();

    app.MapControllers();
}

app.Run();
