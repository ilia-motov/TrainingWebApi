using Notes.Application.Common.Mapping;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Notes.Application.Interfaces;
using System.Reflection;
using Notes.Application;
using Notes.Persistence;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        using (var scope = builder.Services.CreateScope())
        {
            var serviceprovider = scope.ServiceProvider;
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
        }
        builder.Services.AddAutoMapper(config =>
        {
            config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
            config.AddProfile(new AssemblyMappingProfile(typeof(INotesDbContext).Assembly));
        });

        builder.Services.AddApplication();
        builder.Services.AddPersistence(configuration);

        var app = builder.Build();

        app.MapGet("/", () => "Hello World!");

        app.Run();
    }
}