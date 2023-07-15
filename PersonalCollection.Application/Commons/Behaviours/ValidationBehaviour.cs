using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;

namespace PersonalCollection.Application.Commons.Behaviours
{
    public class ValidationBehaviour<TRequest, TResponse> :IPipelineBehavior<TRequest, TResponse> where TRequest : notnull 
    {
        private readonly IEnumerable<IValidator<>>
    }
}
