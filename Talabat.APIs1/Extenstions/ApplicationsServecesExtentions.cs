using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using Talabat.Core.Repository;
using Talabat.Repository;
using Talabat.APIs1.Errors;

namespace Talabat.APIs1.Extenstions
{
    public static class ApplicationsServecesExtentions
    {

        public static IServiceCollection AddApplicationServices (this IServiceCollection services)
        {
            services.AddScoped(typeof(IBasketRepository), typeof(BasketRepository));
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddAutoMapper(typeof(Startup));

            services.Configure<ApiBehaviorOptions>(Options =>
            {
                Options.InvalidModelStateResponseFactory = (actionContext) =>
                {
                    var errors = actionContext.ModelState.Where(M => M.Value.Errors.Count > 0)
                                                         .SelectMany(M => M.Value.Errors)
                                                          .Select(E => E.ErrorMessage)
                                                          .ToArray();
                    var ValidationErrorsMessagecs = new ValidationErrorsMessagecs()
                    {
                        Errors = errors


                    };

                    return new BadRequestObjectResult(ValidationErrorsMessagecs);
                };
            });

            return services;

        }
    }
}
