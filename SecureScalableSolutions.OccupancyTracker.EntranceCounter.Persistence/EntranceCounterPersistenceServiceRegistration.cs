using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Couchbase;
using Couchbase.Extensions.DependencyInjection;
using Couchbase.KeyValue;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SecureScalableSolutions.OccupancyTracker.Application.Contracts.Persistence;
using SecureScalableSolutions.OccupancyTracker.EntranceCounter.Persistence.Models;
using SecureScalableSolutions.OccupancyTracker.EntranceCounter.Persistence.Repositories;

namespace SecureScalableSolutions.OccupancyTracker.EntranceCounter.Persistence
{
    public static class EntranceCounterPersistenceServiceRegistration
    {
        public static IServiceCollection AddEntranceCounterPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            var config = configuration.GetSection("Couchbase");

            // Check if environment variables are set
            var connectionString = Environment.GetEnvironmentVariable("DB_CONN_STR");
            var username = Environment.GetEnvironmentVariable("DB_USERNAME");
            var password = Environment.GetEnvironmentVariable("DB_PASSWORD");

            if (!string.IsNullOrEmpty(connectionString) && !string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                // Override values with environment variables if they are set
                config["ConnectionString"] = connectionString;
                config["Username"] = username;
                config["Password"] = password;
            }

            // Register the configuration for Couchbase and Dependency Injection Framework
            //services.Configure<CouchbaseConfig>(config);
            services.AddCouchbase(config);
            ICouchbaseCollection _collection;
            var clusterOptions = new ClusterOptions
            {
                ConnectionString = configuration["Couchbase:ConnectionString"],
                UserName = configuration["Couchbase:UserName"],
                Password = configuration["Couchbase:Password"]
            };

            var cluster = Cluster.ConnectAsync(clusterOptions).Result;
            var bucket = cluster.BucketAsync(configuration["Couchbase:BucketName"]).Result;
            _collection = bucket.DefaultCollection();
            services.AddScoped<ICouchbaseCollection>(_ => _collection);
            services.AddScoped<IOccupanyLogRepository, OccupancyLogRepository>();
            services.AddScoped<ILocationCurrentOccupancyRepository, LocationCurrentOccupancyRepository>();
            services.AddScoped<IOrganizationRepository, OrganizationRepository>();
            return services;
        }
    }
}
