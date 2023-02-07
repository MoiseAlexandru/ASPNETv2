
using ASPNETv2.Helper.JwtUtils;
using ASPNETv2.Helper.Seeders;
using ASPNETv2.Repository.GroupRepository;
using ASPNETv2.Repository.NoteRepostitory;
using ASPNETv2.Repository.ProfileRepository;
using ASPNETv2.Repository.UserRepository;
using ASPNETv2.Services.NoteService;
using ASPNETv2.Services.ProfileService;
using ASPNETv2.Services.UserService;

namespace ASPNETv2.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IProfileRepository, ProfileRepository>();
            services.AddTransient<IGroupRepository, GroupRepository>();
            services.AddTransient<INoteRepository, NoteRepository>();
            return services;
        }
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IProfileService, ProfileService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<INoteService, NoteService>();
            return services;
        }
        public static IServiceCollection AddSeeders(this IServiceCollection services)
        {
            services.AddScoped<ProfileSeeder>();
            return services;
        }
        public static IServiceCollection AddUtils(this IServiceCollection services)
        {
            services.AddScoped <IJwtUtils, JwtUtils>();
            return services;
        }
    }
}
