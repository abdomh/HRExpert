﻿using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace HRExpert.Core
{
    /// <summary>
    /// Класс расширений для application builder
    /// </summary>
    public static class AppBuilderExtensions
    {
        /// <summary>
        /// Использовать когда
        /// </summary>
        /// <param name="app">билдер</param>
        /// <param name="condition">условие</param>
        /// <param name="configuration">конфигурация</param>
        /// <returns></returns>
        public static IApplicationBuilder UseWhen(this IApplicationBuilder app,
            Func<HttpContext, bool> condition, Action<IApplicationBuilder> configuration)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }

            if (condition == null)
            {
                throw new ArgumentNullException(nameof(condition));
            }

            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            var builder = app.New();
            configuration(builder);

            return app.Use(next => {
                builder.Run(next);

                var branch = builder.Build();

                return context => {
                    if (condition(context))
                    {
                        return branch(context);
                    }

                    return next(context);
                };
            });
        }
    }
}