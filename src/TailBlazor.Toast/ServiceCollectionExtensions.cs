using TailBlazor.Toast.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using TailBlazor.Toast.Configuration;

namespace TailBlazor.Toast
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddTailBlazorToast(this IServiceCollection services,  Action<ToastOptions>? configureOptions = null )
        {
            services.Configure<ToastOptions>(options =>
            {
                options.IncludeIcons = true;
                configureOptions?.Invoke(options);
            });
            return services.AddScoped<IToastService, ToastService>();
        }
    }
}
