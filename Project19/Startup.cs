namespace Project19
{
    /// <summary>
    /// Класс обработки запросов
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Метод, который служит для добавления необходимых сервисов 
        /// в контейнер.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddSpaStaticFiles();

            services.AddMvc();
            services.AddMvc(options => { options.EnableEndpointRouting = false; });
        }

        /// <summary>
        /// Метод настройки конфигурации
        /// </summary>
        /// <param name="app"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseStaticFiles();
            app.UseMvc(
                r =>
                {
                    r.MapRoute(name: "default",
                        template: "{controller=MyDefault}/{action=Index}/{id?}");
                });
        }
    }
}
