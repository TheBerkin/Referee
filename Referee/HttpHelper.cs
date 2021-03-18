using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Referee
{
    public static class HttpHelper
    {
        public static bool IsNotFound(this HttpResponseMessage response) => response.StatusCode == HttpStatusCode.NotFound;

        public static string GetStatusCodeDescription(HttpStatusCode statusCode)
        {
            return statusCode switch
            {
                HttpStatusCode.Continue => "Continue",
                HttpStatusCode.SwitchingProtocols => "Switching Protocols",
                HttpStatusCode.Processing => "Processing",
                HttpStatusCode.EarlyHints => "Early Hints",
                HttpStatusCode.OK => "OK",
                HttpStatusCode.Created => "Created",
                HttpStatusCode.Accepted => "Accepted",
                HttpStatusCode.NonAuthoritativeInformation => "Non-Authoritative Information",
                HttpStatusCode.NoContent => "No Content",
                HttpStatusCode.ResetContent => "Reset Content",
                HttpStatusCode.PartialContent => "Partial Content",
                HttpStatusCode.MultiStatus => "Multi-Status",
                HttpStatusCode.AlreadyReported => "Already Reported",
                HttpStatusCode.IMUsed => "IM Used",
                HttpStatusCode.Ambiguous => "Ambiguous",
                HttpStatusCode.Moved => "Moved",
                HttpStatusCode.Found => "Found",
                HttpStatusCode.RedirectMethod => "See Other",
                HttpStatusCode.NotModified => "Not Modified",
                HttpStatusCode.UseProxy => "Use Proxy",
                HttpStatusCode.Unused => "Unused",
                HttpStatusCode.RedirectKeepVerb => "Temporary Redirect",
                HttpStatusCode.PermanentRedirect => "Premanent Redirect",
                HttpStatusCode.BadRequest => "Bad Request",
                HttpStatusCode.Unauthorized => "Unauthorized",
                HttpStatusCode.PaymentRequired => "Payment Required",
                HttpStatusCode.Forbidden => "Forbidden",
                HttpStatusCode.NotFound => "Not Found",
                HttpStatusCode.MethodNotAllowed => "Method Not Allowed",
                HttpStatusCode.NotAcceptable => "Not Acceptable",
                HttpStatusCode.ProxyAuthenticationRequired => "Proxy Authentication Required",
                HttpStatusCode.RequestTimeout => "Request Timeout",
                HttpStatusCode.Conflict => "Conflict",
                HttpStatusCode.Gone => "Gone",
                HttpStatusCode.LengthRequired => "Length Required",
                HttpStatusCode.PreconditionFailed => "Precondition Failed",
                HttpStatusCode.RequestEntityTooLarge => "Payload Too Large",
                HttpStatusCode.RequestUriTooLong => "URI Too Long",
                HttpStatusCode.UnsupportedMediaType => "Unsupported Media Type",
                HttpStatusCode.RequestedRangeNotSatisfiable => "Range Not Satisfiable",
                HttpStatusCode.ExpectationFailed => "Expectation Failed",
                HttpStatusCode.MisdirectedRequest => "Misdirected Request",
                HttpStatusCode.UnprocessableEntity => "Unprocessable Entity",
                HttpStatusCode.Locked => "Locked",
                HttpStatusCode.FailedDependency => "Failed Dependency",
                HttpStatusCode.UpgradeRequired => "Upgrade Required",
                HttpStatusCode.PreconditionRequired => "Precondition Required",
                HttpStatusCode.TooManyRequests => "Too Many Requests",
                HttpStatusCode.RequestHeaderFieldsTooLarge => "Request Header Fields Too Large",
                HttpStatusCode.UnavailableForLegalReasons => "Unavailable For Legal Reasons",
                HttpStatusCode.InternalServerError => "Internal Server Error",
                HttpStatusCode.NotImplemented => "Not Implemented",
                HttpStatusCode.BadGateway => "Bad Gateway",
                HttpStatusCode.ServiceUnavailable => "Service Unavailable",
                HttpStatusCode.GatewayTimeout => "Gateway Timeout",
                HttpStatusCode.HttpVersionNotSupported => "HTTP Version Not Supported",
                HttpStatusCode.VariantAlsoNegotiates => "Variant Also Negotiates",
                HttpStatusCode.InsufficientStorage => "Insufficient Storage",
                HttpStatusCode.LoopDetected => "Loop Detected",
                HttpStatusCode.NotExtended => "Not Extended",
                HttpStatusCode.NetworkAuthenticationRequired => "Network Authentication Required",
                _ => "Unknown Status"
            };
        }
    }
}
