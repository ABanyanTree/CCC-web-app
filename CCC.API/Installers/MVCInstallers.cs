using CCC.API.Filters;
using CCC.Domain;
using CCC.Domain.Others;
using CCC.lOC;
using CCC.Service.Infra.EmailStuff;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CCC.API.Installers
{
	public class MVCInstallers : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ReadConfig>(configuration.GetSection("data:DBcon"));
            services.Configure<EmailConfig>(configuration.GetSection("EmailConfig"));
            services.Configure<CornJobConfig>(configuration.GetSection("CornJobConfig"));
            //services.Configure<FileSystemPath>(configuration.GetSection("FileSystemPath"));
            //services.Configure<VersionSettings>(configuration.GetSection("VersionSettings"));
            //services.Configure<RetailConfig>(configuration.GetSection("RetailConfig"));


            services.AddMvc(setupAction: action => {
                action.Filters.Add<ExceptionActionFilter>();
            });

            //services.AddMvc(setupAction: options => {
            //    options.EnableEndpointRouting = false;
            //    options.Filters.Add<ValidationFilters>();
            //    options.Filters.Add<ExceptionActionFilter>();
            //}).AddFluentValidation(mvconfiguration => { mvconfiguration.RegisterValidatorsFromAssembly(typeof(UserLoginRequestValidator).GetTypeInfo().Assembly); })
            //    .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            //var mappingConfig = new MapperConfiguration(mc =>
            //{
            //    mc.AddProfile(new DomainToResponseProfile());
            //    mc.AddProfile(new RequestToDomain());
            //});

            //IMapper mapper = mappingConfig.CreateMapper();
            //services.AddSingleton(mapper);//Dep

            //services.AddSingleton<IUriService>(provider =>
            //{
            //    var httpContextAccesser = provider.GetRequiredService<IHttpContextAccessor>();
            //    var request = httpContextAccesser.HttpContext.Request;
            //    var absoluteUrl = string.Concat(request.Scheme + "://" + request.Host.ToUriComponent() + "/");
            //    var profilePicName = configuration.GetSection("FileSystemPath:DefaultProfilePicName");
            //    return new UriService(absoluteUrl, profilePicName.Value);
            //});


            DependencyContainer.RegisterServices(services);

            //RetailDependencyContainer.RegisterServices(services);
        }
    }
}
