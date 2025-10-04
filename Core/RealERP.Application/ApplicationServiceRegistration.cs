using MediatR;
using Microsoft.Extensions.DependencyInjection;


namespace RealERP.Application
{
    public static class ApplicationServiceRegistration
    {
        static public void AddApplicationService(this IServiceCollection serviceDescriptors)
        {
            serviceDescriptors.AddMediatR(typeof(ApplicationServiceRegistration));
        }
    }
}
