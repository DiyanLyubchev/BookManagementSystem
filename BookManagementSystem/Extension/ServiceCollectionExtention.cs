using BookManagementSystem.Service.Contracts;
using BookManagementSystem.Service.Service;
using Microsoft.Extensions.DependencyInjection;

namespace BookManagementSystem.Extension
{
    public static class ServiceCollectionExtention
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IUserAccountService, UserAccountService>();
            services.AddScoped<IBookLendingService, BookLendingService>();

            return services;
        }
    }
}