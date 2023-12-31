using System.Text.Json.Serialization;
using MongoDB.Driver;
using TestVue.InternalApi.Configs;
using TestVue.InternalApi.Repositories;
using TestVue.Repositories;

namespace TestVue;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen();


            services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigins",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });
            
            // databases
            services.AddSingleton<IMongoDatabase>(provider =>
            {
                var config = Configuration.GetSection("MongoDbConfig").Get<MongoDbConfig>() ?? throw new Exception("Can't find mongo config!");
                var client = new MongoClient(config.ConnectionUri);
                return client.GetDatabase(config.DatabaseName);
            });
            services.AddSingleton<ISpendingRepository, SpendingMongoRepository>();

            services.Configure<MongoDbConfig>(Configuration.GetSection(MongoDbConfig.Section));
            
            services.AddHttpClient();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseCors("AllowSpecificOrigins");

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }