using WebAPI.ApplicationConfiguration;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.Configure();

WebApplication app = builder.Build();
app.Configure().Run();