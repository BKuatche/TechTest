using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Reflection;

namespace ECSAutomationTests.Helpers
{
    public class ConfigurationHelper
    {
        private static IConfiguration _configuration;

        public static string BaseUrl => Configuration["appsetting:BaseUrl"];
        public static string Browser => Configuration["appsetting:Browser"];
        public static string Name => Configuration["appsetting:Name"];
        public static int ElementTimeout => Convert.ToInt32(Configuration["appsetting:ElementTimeout"]);
        public static int PageLoadTimeout => Convert.ToInt32(Configuration["appsetting:PageLoadTimeout"]);





        public static IConfiguration Configuration
            => _configuration ??= new ConfigurationBuilder()
               .SetBasePath(Path.GetFullPath(Path.Combine(new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName
                   ?? throw new InvalidOperationException($"Path does not exist"), @"..\..\..\")))
                .AddJsonFile("appSettings.json", optional: false, reloadOnChange: true)
               .Build();
    }
}
