﻿using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace IMDB.src.Api.Config
{
    public class BearerAuthenticationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var allowAnon = context.ApiDescription.CustomAttributes().Any(attr => attr.GetType() == typeof(AllowAnonymousAttribute));
            var authorize = context.ApiDescription.CustomAttributes().Any(attr => attr.GetType() == typeof(AuthorizeAttribute));

            if (allowAnon || !authorize) return;

            operation.Security = new List<OpenApiSecurityRequirement>
            {
                new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new List<string>()
                    }
                }
            };
        }
    }
}