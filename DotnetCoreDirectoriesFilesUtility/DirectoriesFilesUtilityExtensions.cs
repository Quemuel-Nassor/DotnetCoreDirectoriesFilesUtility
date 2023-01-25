using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;

namespace FilesFoldersUtility
{
    public static class DirectoriesFilesUtilityExtensions
    {
        public static IServiceCollection RegisterDirectoriesFilesUtility(this IServiceCollection services, Action<DirectoriesFilesUtilityOptions> folders)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }
            if (folders == null)
            {
                throw new ArgumentNullException(nameof(folders));
            }

            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.Configure(folders);
            services.TryAddSingleton<IDirectoriesFilesUtility, DirectoriesFilesUtility>();
            return services;
        }
    }
}
