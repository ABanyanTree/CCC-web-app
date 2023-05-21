using CCC.Data.Interfaces;
using CCC.Data.Services;
using CCC.Domain.DomainInterface;
using CCC.Service.Infra.EmailStuff;
using CCC.Service.Interfaces;
using CCC.Service.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCC.lOC
{
    public class DependencyContainer
    {
        public string newstr { get; set; }

        public static void RegisterServices(IServiceCollection services)
        {
            services.AddSingleton(typeof(IDapperResolver<>), typeof(DapperResolver<>));

            services.AddSingleton<IErrorLogs, ErrorLogsService>();
            services.AddSingleton<IErrorLogsRepository, ErrorLogsRepository>();

            services.AddSingleton<IPetServices, PetService>();
            services.AddSingleton<IPetRepository, PetRepository>();

            services.AddSingleton<ICenterMasterService, CenterMasterService>();
            services.AddSingleton<ICenterMasterRepository, CenterMasterRepository>();

            services.AddSingleton<ICityAreaMasterService, CityAreaMasterService>();
            services.AddSingleton<ICityAreaMasterRepository, CityAreaMasterRepository>();

            services.AddSingleton<ICityMasterService, CityMasterService>();
            services.AddSingleton<ICityMasterRepository, CityMasterRepository>();

            services.AddSingleton<ILookupMasterService, LookupMasterService>();
            services.AddSingleton<ILookupMasterRepository, LookupMasterRepository>();

            services.AddSingleton<IRoleFeatureMasterService, RoleFeatureMasterService>();
            services.AddSingleton<IRoleFeatureMasterRepository, RoleFeatureMasterRepository>();

            services.AddSingleton<IRoleMasterService, RoleMasterService>();
            services.AddSingleton<IRoleMasterRepository, RoleMasterRepository>();

            services.AddSingleton<IUserCenterMasterService, UserCenterMasterService>();
            services.AddSingleton<IUserCenterMasterRepository, UserCenterMasterRepository>();

            services.AddSingleton<IUserMasterService, UserMasterService>();
            services.AddSingleton<IUserMasterRepository, UserMasterRepository>();

            services.AddSingleton<IUserRoleMastersService, UserRoleMastersService>();
            services.AddSingleton<IUserRoleMastersRepository, UserRoleMastersRepository>();

            services.AddSingleton<IVetMasterService, VetMasterService>();
            services.AddSingleton<IVetMasterRepository, VetMasterRepository>();

            services.AddSingleton<IVanMasterRepository, VanMasterRepository>();
            services.AddSingleton<IVanMasterService, VanMasterService>();

            services.AddSingleton<IRefreshTokenService, RefreshTokenService>();
            services.AddSingleton<IRefreshTokenRepository, RefreshTokenRepository>();

            services.AddSingleton<IPetDataNotificationService, PetDataNotificationService>();
            services.AddSingleton<IPetDataNotificationRepository, PetDataNotificationRepository>();

            services.AddSingleton<IEmailSender, EmailSender>();

            services.AddSingleton<INotificationService, NotificationService>();


        }
    }
}
