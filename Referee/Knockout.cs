using Newtonsoft.Json;
using Referee.Internals;
using Referee.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Referee
{
    public sealed partial class Knockout
    {
        private const string COOKIE_KEY_JWT = "knockoutJwt";

        internal const string URL_BASE = "https://api.knockout.chat/";
        internal const string URL_SUBFORUM = URL_BASE + "subforum/";
        internal const string URL_THREADS = URL_BASE + "v2/threads/";
        internal const string URL_THREADS_POPULAR = URL_THREADS + "popular/";
        internal const string URL_USER = URL_BASE + "user/";
        internal const string URL_POST = URL_BASE + "post/";

        private readonly HttpClient _http;
        private readonly HttpClientHandler _httpHandler;
        private readonly KnockoutJsonSerializer _serializer;

        private string? _authToken = null;
        private string userAgent = "Referee";

        public string UserAgent 
        { 
            get => userAgent;
            set 
            {
                userAgent = value ?? throw new ArgumentNullException(nameof(value));
            }
        }

        public Knockout()
        {
            _httpHandler = new HttpClientHandler
            {
                UseCookies = true
            };
            _http = new HttpClient(_httpHandler);
            _serializer = new KnockoutJsonSerializer(this);
        }

        public Knockout SetAuthenticationToken(string authToken)
        {
            _authToken = authToken;
            _httpHandler.CookieContainer.Add(new System.Net.Cookie(COOKIE_KEY_JWT, authToken));
            return this;
        }

        public Task<Subforum?> GetSubforumAsync(uint subforumId, int page = 1, CancellationToken cancellationToken = default)
        {
            return GetObjectAsync<Subforum>($"{URL_SUBFORUM}{subforumId}/{page}", cancellationToken);
        }

        public async Task<IEnumerable<Subforum>> GetSubforumsAsync(CancellationToken cancellationToken = default)
        {
            var collection = await GetRequiredObjectAsync<SubforumCollection>(URL_SUBFORUM, cancellationToken);
            return collection.Subforums;
        }

        public Task<IEnumerable<Thread>> GetPopularThreadsAsync(CancellationToken cancellationToken = default)
        {
            return GetRequiredCollectionAsync<Thread>(URL_THREADS_POPULAR, cancellationToken);
        }

        public Task<Thread?> GetThreadAsync(uint threadId, CancellationToken cancellationToken = default)
        {
            return GetObjectAsync<Thread>($"{URL_THREADS}{threadId}", cancellationToken);
        }

        public Task<User?> GetUserAsync(uint userId, CancellationToken cancellationToken = default)
        {
            return GetObjectAsync<User>($"{URL_USER}{userId}", cancellationToken);
        }
    }
}
