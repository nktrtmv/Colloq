using TasksService.Application.Extensions;
using TasksService.Infrastructure.Extensions;
using TasksService.NamingPolicies;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddJsonOptions(options => { options.JsonSerializerOptions.PropertyNamingPolicy = new SnakeCaseNamingPolicy(); });

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(o => { o.CustomSchemaIds(x => x.FullName); });

builder.Services
    .AddApplication()
    .AddDomain()
    .AddDalInfrastructure(builder.Configuration)
    .AddDalRepositories();

WebApplication app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.MigrateUp();

app.Run();