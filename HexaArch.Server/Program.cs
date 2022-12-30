using Autofac;
using Autofac.Extensions.DependencyInjection;
using HexaArch.Shared.Converters;
using Serilog;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Configuration.AddEnvironmentVariables();

builder.Host.UseSerilog((hostingContext, loggerConfiguration) =>
{
    loggerConfiguration.MinimumLevel.Debug()
        .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
        .Enrich.FromLogContext()
        .WriteTo.Console();
});

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<Autofac.ContainerBuilder>(builder => {
    builder.RegisterModule(new HexaArch.Infrastructure.Modules.ApplicationModule());
    builder.RegisterModule(new HexaArch.Infrastructure.InMemory.Module());
    });
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        builder => builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader()
        /*.AllowCredentials()*/);
});
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new DateOnlyJsonConverter());
    });
//builder.Services.AddMvc(options =>
//{
//    options.Filters.Add(typeof(DomainExceptionFilter));
//    options.Filters.Add(typeof(ValidateModelAttribute));
//});
builder.Services.AddSwaggerGen(options =>
{
    //options.IncludeXmlComments(
    //    Path.ChangeExtension(
    //        typeof(Program).Assembly.Location,
    //        "xml"));

    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = builder.Configuration["App:Title"],
        Version = builder.Configuration["App:Version"],
        Description = builder.Configuration["App:Description"],
        TermsOfService = new Uri(builder.Configuration["App:TermsOfService"])
    });

    options.CustomSchemaIds(x => x.FullName);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();
app.UseSwagger()
   .UseSwaggerUI(c =>
   {
       c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
   });

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
