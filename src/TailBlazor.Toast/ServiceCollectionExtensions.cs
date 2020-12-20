using TailBlazor.Toast.Services;
using Microsoft.Extensions.DependencyInjection;

namespace TailBlazor.Toast
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddTailBlazorToast(this IServiceCollection services)
        {
            return services.AddScoped<IToastService, ToastService>();
        }
    }
}
