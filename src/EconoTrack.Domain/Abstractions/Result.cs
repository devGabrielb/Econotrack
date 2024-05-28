using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace EconoTrack.Domain.Abstractions
{
    public class Result
    {
        public Result(bool isSuccess, CustomError error)
        {
            if (isSuccess && error != CustomError.None)
            {
                throw new InvalidOperationException();
            }

            if (!isSuccess && error == CustomError.None)
            {
                throw new InvalidOperationException();
            }

            IsSuccess = isSuccess;
            Error = error;
        }

        public bool IsSuccess { get; }

        public bool IsFailure => !IsSuccess;

        public CustomError Error { get; }

        public static Result Success() => new(true, CustomError.None);

        public static Result<TValue> Success<TValue>(TValue value) => new(value, true, CustomError.None);
        public static Result Failure(CustomError error) => new(false, error);
        public static Result<TValue> Failure<TValue>(CustomError error) => new(default, false, error);
        public static Result<TValue> Create<TValue>(TValue? value) =>
            value is not null ? Success(value) : Failure<TValue>(CustomError.NullValue);
    }

    public sealed class Result<TValue> : Result
    {
        private readonly TValue? _value;

        public Result(TValue? value, bool isSuccess, CustomError error)
            : base(isSuccess, error)
        {
            _value = value;
        }

        [NotNull]
        public TValue Value => IsSuccess
            ? _value!
            : throw new InvalidOperationException("The value of a failure result can not be accessed.");

        public static implicit operator Result<TValue>(TValue? value) => Create(value);

        public Result<TValue> ToResult()
        {
            throw new NotImplementedException();
        }
    }

}
