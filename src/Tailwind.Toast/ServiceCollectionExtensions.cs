using Tailwind.Toast.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Tailwind.Toast
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddTailwindToast(this IServiceCollection services)
        {
            return services.AddScoped<IToastService, ToastService>();
        }
    }
}
