using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Arkitektur.Business.Base
{
    public class BaseResult<T>
    {
        public T? Data { get; set; }
        public IEnumerable<object> Errors { get; set; }

        public bool IsSuccessful =>Errors == null || !Errors.Any();

        public bool IsFailure => !IsSuccessful;

        public static BaseResult<T> Success(T? data)
        {
            return new BaseResult<T> { Data = data };
        }
        public static BaseResult<T> Success()
        {
            return new BaseResult<T> { Errors = null };
        }
        public static BaseResult<T> Fail(string errorMessage)
        {
            return new BaseResult<T> { Errors = new[] { new { ErrorMessage = errorMessage } } };
        }
        public static BaseResult<T> Fail(List<ValidationFailure> errorMessage)
        {
            IEnumerable<object> errors = (from error in errorMessage
                                          select new
                                          {
                                              PropertyName=error.PropertyName,
                                              ErrorMessage=error.ErrorMessage

                                          }).ToList();
            return new BaseResult<T> { Errors = errors  };
        }
        public static BaseResult<T> Fail(IEnumerable<IdentityError> errorMessage)
        {
            IEnumerable<object> errors = (from error in errorMessage
                                          select new
                                          {
                                              PropertyName = error.Code,
                                              ErrorMessage = error.Description

                                          }).ToList();
            return new BaseResult<T> { Errors = errors };
        }
    }
}
