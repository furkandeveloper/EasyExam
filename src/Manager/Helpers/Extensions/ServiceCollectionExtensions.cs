using Manager.Configuration;
using Manager.Context;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Manager.Helpers.Extensions
{
    /// <summary>
    /// This class includes service collection object of extensions.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Register easy exam framework
        /// </summary>
        /// <param name="services">
        /// Service collection
        /// </param>
        /// <param name="action">
        /// Action delegate
        /// </param>
        /// <returns>
        /// Service collections
        /// </returns>
        public static IServiceCollection AddEasyExam(this IServiceCollection services,Action<MongoSetting> action)
        {
            MongoSetting mongoSetting = new MongoSetting();
            action.Invoke(mongoSetting);
            services.AddSingleton(mongoSetting);
            services.AddTransient<IEasyExamContext, EasyExamContext>();
            return services;
        }
    }
}
