using ASPNETv2.Repository.GroupRepository;
using ASPNETv2.Repository.NoteRepostitory;
using ASPNETv2.Repository.ProfileRepository;
using ASPNETv2.Repository.UserRepository;
using ASPNETv2.Services.ProfileService;

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
            return services;
        }
    }
}
