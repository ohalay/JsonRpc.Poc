using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using EdjCase.JsonRpc.Router.WebSockets;

namespace TestJsonRpc
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddJsonRpc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Map("/api", appBuilder =>
            {
                appBuilder.UseManualJsonRpc(opt =>
                {
                    opt.RegisterController<TestController>();
                });
            });

            app.Map("/webSocket", appBuilder =>
            {
                appBuilder.UseJsonRpcWithWebSockets(opt => 
                {
                    opt.AddClass<TestController>();
                });
            });
        }
    }
}
