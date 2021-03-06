using System;
using System.Collections.Generic;
using CzyDobrze.Application.Common.Exceptions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Hosting;

namespace CzyDobrze.Api.Filters
{
    public class ApiExceptionFilter : ExceptionFilterAttribute
    {
        private readonly IDictionary<Type, Action<ExceptionContext>> _exceptionHandlers;
        private readonly IWebHostEnvironment _env;
        
        public ApiExceptionFilter(IWebHostEnvironment env)
        {
            _env = env;
            
            _exceptionHandlers = new Dictionary<Type, Action<ExceptionContext>>()
            {
                {typeof(ValidationException), HandleValidationException},
                {typeof(EntityNotFoundException), HandleEntityNotFoundException},
                {typeof(AuthorizationException), HandleAuthorizationException},
            };
        }
        
        public override void OnException(ExceptionContext context)
        {
            HandleException(context);

            base.OnException(context);
        }

        private void HandleException(ExceptionContext context)
        {
            var type = context.Exception.GetType();
            
            if (_exceptionHandlers.ContainsKey(type))
            {
                _exceptionHandlers[type].Invoke(context);
                return;
            }

            HandleUnknownException(context);
        }

        private static void HandleValidationException(ExceptionContext context)
        {
            var exception = context.Exception as ValidationException;
            
            var details = new ValidationProblemDetails(exception?.Errors)
            {
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1"
            };

            context.Result = new BadRequestObjectResult(details);

            context.ExceptionHandled = true;
        }

        private static void HandleEntityNotFoundException(ExceptionContext context)
        {
            context.Result = new NotFoundResult();
            context.ExceptionHandled = true;
        }

        private static void HandleAuthorizationException(ExceptionContext context)
        {
            context.Result = new ForbidResult();
            context.ExceptionHandled = true;
        }
        
        private void HandleUnknownException(ExceptionContext context)
        {
            if (_env.IsDevelopment()) return;
            
            var details = new ProblemDetails
            {
                Status = StatusCodes.Status500InternalServerError,
                Title = "An error occurred while processing your request.",
                Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1"
            };

            context.Result = new ObjectResult(details)
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };

            context.ExceptionHandled = true;
        }
    }
}