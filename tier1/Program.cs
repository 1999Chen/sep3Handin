using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using tier1.Models;

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace tier1 {
public class Program {
    public static void Main(string[] args) {
        
        CreateHostBuilder(args).Build().Run();
    }
    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
}



}








