using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OrienteeringUkraine.Application.Infrastructure.Validation.Extensions
{
    public static class MvcBuilderExension
    {
        public static IMvcBuilder AddCustomValidation(this IMvcBuilder builder)
        {
            builder.AddFluentValidation(conf =>
            {
                conf.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
                conf.ValidatorOptions.LanguageManager = new OrienteeringUkraineLanguageManager();
            });
            return builder;
        }
    }
}
