﻿using System.IO;
using Assessmentsvc.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Api
{
    public class DesignTimeDbContextFactory: IDesignTimeDbContextFactory<AssessmentsContext>
    {
        public AssessmentsContext CreateDbContext(string[] args)
        {
        IConfigurationRoot Configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .AddEnvironmentVariables()
            .Build();
            
            string dbname = Configuration["MYSQL_DATABASE"];
            string dbuser = Configuration["MYSQL_USER"];
            string dbpwd = Configuration["MYSQL_PASSWORD"];
            string dbserver = Configuration["MYSQL_SERVICE_HOST"];
            string dbport = Configuration["MYSQL_SERVICE_PORT"];
            var mySQLconnectionString = "Server=" + Configuration["MYSQL_SERVICE_HOST"] + "; Port = " + Configuration["MYSQL_SERVICE_PORT"] + "; Database = " + Configuration["MYSQL_DATABASE"] + "; Uid= " + Configuration["MYSQL_USER"] + ";Pwd=" + Configuration["MYSQL_PASSWORD"] + ";";

           
        var builder = new DbContextOptionsBuilder<AssessmentsContext>().EnableSensitiveDataLogging(true);
            
           

        builder.UseMySql(mySQLconnectionString);

        return new AssessmentsContext(builder.Options);
        }
    }
}

