using System.IO;
using AutoMapper;
using ContactList.Entities;
using ContactList.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ContactList
{
  public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //services.Configure<MvcOptions>(options =>
            //{
            //  options.Filters.Add(new CorsAuthorizationFilterFactory("*"));
            //});
      services.AddMvc();
            
      var connectionString = @"Server=(localdb)\mssqllocaldb;Database=ContactListDB;Trusted_Connection=True;";
            services.AddDbContext<ContactContext>(o => o.UseSqlServer(connectionString));
            services.AddScoped<IContactListRepository, ContactListRepository>();
            
    }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ContactContext contactContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            contactContext.EnsureSeedDataForContext();
            app.UseStatusCodePages();

            AutoMapper.Mapper.Initialize(cfg =>
            {
             // cfg.CreateMap();
              cfg.CreateMap<Models.EmailDto, Entities.Email>();
              cfg.CreateMap<Models.NumberDto, Entities.Number>();
              cfg.CreateMap<Models.TagDto, Entities.Tag>();
              cfg.CreateMap<Models.ContactDto, Entities.Contact>();
              cfg.CreateMap<Entities.Email, Models.EmailDto>();
              cfg.CreateMap<Entities.Number, Models.NumberDto>();
              cfg.CreateMap<Entities.Tag, Models.TagDto>();
              cfg.CreateMap<Entities.Contact, Models.ContactDto>();
              cfg.CreateMap<Models.EmailDto, Models.ContactDto>()
                .ForMember(c => c.Emails, o => o.MapFrom(s => s.ContactEmail))
                .ForMember(c => c.Emails, o => o.MapFrom(s => s.ContactId))
                .ForMember(c => c.Emails, o => o.MapFrom(s => s.Id));
              cfg.CreateMap<Models.NumberDto, Models.ContactDto>()
               .ForMember(c => c.Numbers, o => o.MapFrom(s => s.ContactNumber))
               .ForMember(c => c.Numbers, o => o.MapFrom(s => s.ContactId))
               .ForMember(c => c.Numbers, o => o.MapFrom(s => s.Id));
              cfg.CreateMap<Models.TagDto, Models.ContactDto>()
               .ForMember(c => c.Tags, o => o.MapFrom(s => s.ContactTag))
               .ForMember(c => c.Tags, o => o.MapFrom(s => s.ContactId))
               .ForMember(c => c.Tags, o => o.MapFrom(s => s.Id));
            });

            app.UseCors("AllowMyOrigin");
            app.UseMvc(); //CHECK

            app.Use(async (context, next) => {
                await next();
                if(context.Response.StatusCode == 404 &&
                !Path.HasExtension(context.Request.Path.Value) &&
                !context.Request.Path.Value.StartsWith("/api/"))
                {
                    context.Request.Path = "/index.html";
                    await next();
                }
            });

            app.UseMvcWithDefaultRoute();
            app.UseDefaultFiles();
            app.UseStaticFiles();
        }
    }
}
