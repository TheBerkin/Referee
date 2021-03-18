using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Referee
{
    public class KnockoutException : Exception
    {
        public KnockoutErrorType ErrorType { get; init; } = KnockoutErrorType.ApiError;

        public KnockoutException(KnockoutErrorType errorType = default)
        {
            ErrorType = errorType;
        }

        public KnockoutException(string? message, KnockoutErrorType errorType = default) : base(message)
        {
            ErrorType = errorType;
        }

        public KnockoutException(string? message, Exception? innerException, KnockoutErrorType errorType = default) : base(message, innerException)
        {
            ErrorType = errorType;
        }

        protected KnockoutException(SerializationInfo info, StreamingContext context, KnockoutErrorType errorType = default) : base(info, context)
        {
            ErrorType = errorType;
        }

        public override string Message => $"[{GetErrorTypeName()}] {base.Message}";

        private string GetErrorTypeName()
        {
            return ErrorType switch
            {
                KnockoutErrorType.NetworkError => "Network Error",
                KnockoutErrorType.AuthError => "Auth Error",
                KnockoutErrorType.ApiError => "API Error",
            };
        }
    }
}
