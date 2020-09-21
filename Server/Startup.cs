using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Orders.Schema;
using Orders.Type;
using Orders.Query;
using Orders.Services;
using GraphQL.Server;
using GraphQL;
using GraphQL.Server.Ui.Playground;
using GraphQL.Server.Ui.GraphiQL;
using GraphQL.Server.Ui.Voyager;
using GraphQL.Server.Ui.Altair;
using GraphQL.Server.Transports.AspNetCore;

namespace server
{
    public class Startup
    {
         public Startup(IConfiguration configuration, IWebHostEnvironment  environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public IConfiguration Configuration { get; }

        public IWebHostEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IOrderService, OrderService>();
            services.AddSingleton<ICustomerService, CustomerService>();
            services.AddSingleton<IOrderEventService, OrderEventService>();            
           
            services.AddSingleton<OrderType>();
            services.AddSingleton<CustomerType>();          

            services.AddSingleton<OrderCreateInputType>();            
            services.AddSingleton<OrderStatusesEnum>();            
            services.AddSingleton<OrderEventType>();  

            services.AddSingleton<RootSchema>();  
            services.AddSingleton<RootQuery>();        
            services.AddSingleton<RootMutation>();
            services.AddSingleton<RootSubscription>();             
          
            services.AddGraphQL(options =>
                {
                    //System.Diagnostics.Debug.WriteLine("server stared");
                    options.EnableMetrics = true;                    
                    options.UnhandledExceptionDelegate = ctx =>
                    {
                        Console.WriteLine("error: " + ctx.OriginalException.Message);
                    };
                })
            .AddSystemTextJson(deserializerSettings => { }, serializerSettings => { })
            //.AddErrorInfoProvider(opt => opt.ExposeExceptionStackTrace = Environment.IsDevelopment())
            .AddWebSockets()
            .AddDataLoader()
            .AddGraphTypes(typeof(RootSchema));            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
           
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseWebSockets();
            app.UseGraphQLWebSockets<RootSchema>("/graphql");
            app.UseGraphQL<RootSchema, GraphQLHttpMiddleware<RootSchema>>("/graphql"); 

            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions
            {
                Path = "/ui/playground",                
            });
            app.UseGraphiQLServer(new GraphiQLOptions
            {
                Path = "/ui/graphiql",
                GraphQLEndPoint = "/graphql",
            });

            app.UseGraphQLAltair(new GraphQLAltairOptions
            {
                Path = "/ui/altair",
                GraphQLEndPoint = "/graphql",
                Headers = new Dictionary<string, string>
                {
                    ["X-api-token"] = "130fh9823bd023hd892d0j238dh",
                }
            });

             app.UseGraphQLVoyager(new GraphQLVoyagerOptions
            {
                Path = "/ui/voyager",
                GraphQLEndPoint = "/graphql",                
            });
        }
    }
}
