﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Serilog.Enrichers.AspnetcoreHttpcontext;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using Serilog.Formatting.Compact;

namespace VehicleTracking.API
{
    public class Program
    {
        public static int Main(string[] args)
        {
            try
            {
                CreateWebHostBuilder(args).Build().Run();
                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Host terminated unexpectedly");
                Console.Write(ex.ToString());
                return 1;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseSerilog((provider, ContextBoundObject, loggerConfig) =>
                {
                    var name = Assembly.GetExecutingAssembly().GetName();
                    loggerConfig
                        .MinimumLevel.Debug()
                        .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                        .MinimumLevel.Override("IdentityServer4", LogEventLevel.Information)
                        //.Enrich.WithAspnetcoreHttpcontext(provider, false,
                        //    AddCustomContextInfo)
                        .Enrich.FromLogContext()
                        .Enrich.WithMachineName()
                        .Enrich.WithProperty("Assembly", $"{name.Name}")
                        .Enrich.WithProperty("Version", $"{name.Version}")
                        .WriteTo.File(new CompactJsonFormatter(),
                            @"C:\Logs\VehicleTrackingAPI.json");
                });
        }



        public static void AddCustomContextInfo(IHttpContextAccessor ctx,
            LogEvent le, ILogEventPropertyFactory pf)
        {
            HttpContext context = ctx.HttpContext;
            if (context == null) return;

            var userInfo = context.Items["my-custom-info"] as UserInfo;
            if (userInfo == null)
            {
                var user = context.User.Identity;
                if (user == null || !user.IsAuthenticated) return;
                var i = 0;
                userInfo = new UserInfo
                {
                    Name = user.Name,
                    Claims = context.User.Claims.ToDictionary(x => $"{x.Type} ({i++})", y => y.Value)
                };
                context.Items["my-custom-info"] = userInfo;
            }

            le.AddPropertyIfAbsent(pf.CreateProperty("UserInfo", userInfo, true));
        }
    }
    public class UserInfo
    {
        public string Name { get; set; }
        public Dictionary<string, string> Claims { get; set; }
    }
}
