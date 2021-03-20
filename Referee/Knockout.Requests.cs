using Newtonsoft.Json;
using Referee.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Referee
{
    public sealed partial class Knockout
    {
        private readonly HttpClient _http = new();

        private static void ThrowErrorForStatusCode(HttpStatusCode statusCode)
        {
            throw new KnockoutException($"Server responded with status code {(int)statusCode} (\"{HttpHelper.GetStatusCodeDescription(statusCode)}\")", KnockoutErrorType.ApiError);
        }

        internal async Task HandleErrorResponseAsync(HttpResponseMessage errorResponse, CancellationToken cancellationToken = default)
        {
            try
            {
                var errorInfo = JsonConvert.DeserializeObject<KnockoutErrorInfo>(await errorResponse.Content.ReadAsStringAsync(cancellationToken));
                throw new KnockoutException(errorInfo.Message, KnockoutErrorType.ApiError);
            }
            catch
            {
                ThrowErrorForStatusCode(errorResponse.StatusCode);
            }
        }

        private void AssignHeaders(HttpRequestMessage request)
        {
            if (_authToken != null)
            {
                request.Headers.Add("Cookie", $"knockoutJwt={_authToken}");
            }
        }

        private async Task<T> DeserializeResponseAsync<T>(HttpResponseMessage response, CancellationToken cancellationToken = default)
        {
            using (var reader = new JsonTextReader(new StreamReader(await response.Content.ReadAsStreamAsync())))
            {
                return _serializer.Deserialize<T>(reader)!;
            }
        }

        internal async Task<HttpResponseMessage> GetAsync(string url, bool throwOnError = true, CancellationToken cancellationToken = default)
        {
            try
            {
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(url),
                };

                AssignHeaders(request);

                var response = await _http.SendAsync(request, cancellationToken) ?? throw new KnockoutException("Server returned empty response.");

                return response;
            }
            catch (HttpRequestException ex)
            {
                throw new KnockoutException(ex.Message, ex, KnockoutErrorType.NetworkError);
            }
            catch (TaskCanceledException ex) when (ex.InnerException is TimeoutException)
            {
                throw new KnockoutException("Connection timed out.", ex, KnockoutErrorType.NetworkError);
            }
        }

        internal async Task<T?> GetObjectAsync<T>(string url, CancellationToken cancellationToken = default)
            where T : KnockoutObject
        {
            var response = await GetAsync(url, false, cancellationToken);

            if (response.IsSuccessStatusCode)
            {
                return (await DeserializeResponseAsync<T>(response, cancellationToken)).OwnedBy(this);
            }

            if (response.IsNotFound())
            {
                return null;
            }

            await HandleErrorResponseAsync(response, cancellationToken);
            return null;
        }

        internal async Task<T> GetRequiredObjectAsync<T>(string url, CancellationToken cancellationToken = default)
            where T : KnockoutObject
        {
            var response = await GetAsync(url, true, cancellationToken);

            return (await DeserializeResponseAsync<T>(response, cancellationToken)).OwnedBy(this);
        }

        internal async Task<IEnumerable<T>> GetRequiredCollectionAsync<T>(string url, CancellationToken cancellationToken = default)
            where T : KnockoutObject
        {
            var response = await GetAsync(url, true, cancellationToken);

            return (await DeserializeResponseAsync<List<T>>(response, cancellationToken)).OwnedBy(this);
        }
    }
}
