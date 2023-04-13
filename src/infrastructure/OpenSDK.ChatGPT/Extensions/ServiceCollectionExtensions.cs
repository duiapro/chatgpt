using Microsoft.Extensions.DependencyInjection;
using OpenSDK.ChatGPT;
using OpenSDK.ChatGPT.Service;
using System;
using System.Reflection;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddChatGTPClient(this IServiceCollection services)
        {
            services.AddHttpClient<IChatGPTClient, ChatGPTClient>(options =>
            {
                options.BaseAddress = new Uri(ChatGPTConst.ServiceUrlBase);
            });

            return services;
        }
    }
}
