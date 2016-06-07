﻿using System;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace HRExpert.Core.Filters
{
    using Services.Abstractions;
    /// <summary>
    /// Фильтр параметра роли
    /// </summary>
    public class RoleActionFilter: ActionFilterAttribute
    {
        private readonly ILogger _logger;
        private IAuthService authService;
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="loggerFactory"></param>
        /// <param name="authService"></param>
        public RoleActionFilter(ILoggerFactory loggerFactory, IAuthService authService)
        {
            this.authService = authService;
            _logger = loggerFactory.CreateLogger("RoleActionFilter");
        }
        /// <summary>
        /// Событие выполнения экшена
        /// </summary>
        /// <param name="context"></param>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            try
            {
                var role = (long)context.ActionArguments["for_roleid"];
                authService.CurrentRoleId = role;                
            }
            catch(Exception e)
            {
                _logger.LogWarning("User role argument not provided.",e);
            }
            _logger.LogInformation("OnActionExecuting");
            base.OnActionExecuting(context);
        }
        /*
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            _logger.LogInformation("OnActionExecuted");
            base.OnActionExecuted(context);
        }

        public override void OnResultExecuting(ResultExecutingContext context)
        {
            _logger.LogInformation("OnResultExecuting");
            base.OnResultExecuting(context);
        }

        public override void OnResultExecuted(ResultExecutedContext context)
        {
            _logger.LogInformation("OnResultExecuted");
            base.OnResultExecuted(context);
        }
        */
    }
}
