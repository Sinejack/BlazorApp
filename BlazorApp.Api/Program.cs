using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Hosting;
using System.Diagnostics;

namespace BlazorApp.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //// Test connection

            //const string connectionString = "Server=localhost,1400;Database=BlazorApp;User=sa;Password=Admin1234";

            //using (var conn = new SqlConnection(connectionString))
            //{
            //    conn.Open();

            //    var cmd = new SqlCommand("Select * from Books", conn);

            //    var reader = cmd.ExecuteReader();

            //    while (reader.Read())
            //    {
            //        Debug.WriteLine($"{reader["Title"]}");
            //    }
            //}

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}