using Ocelot.DependencyInjection;
using Ocelot.Middleware;


var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("configuration.development.json");

builder.Services.AddAuthentication()
        .AddJwtBearer("GatewayAuthenticationScheme", options =>
        {
            options.Authority = builder.Configuration["IdentityServerURL"];
            options.Audience = "ResourceGateway";
            options.RequireHttpsMetadata = false;
        });

builder.Services.AddOcelot();

var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

app.UseOcelot().Wait();
app.Run();