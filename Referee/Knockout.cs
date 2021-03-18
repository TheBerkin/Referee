using Newtonsoft.Json;
using Referee.Internals;
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
        internal const string URL_BASE = "https://api.knockout.chat/";
        internal const string URL_SUBFORUM = URL_BASE + "subforum/";
        internal const string URL_THREADS = URL_BASE + "v2/threads/";
        internal const string URL_THREADS_POPULAR = URL_THREADS + "popular/";
        internal const string URL_USER = URL_BASE + "user/";

        private string? _authToken = null;

        public Knockout SetAuthenticationToken(string authToken)
        {
            _authToken = authToken;
            return this;
        }

        public async Task<IEnumerable<Subforum>> GetSubforumsAsync(CancellationToken cancellationToken = default)
        {
            var collection = await GetRequiredObjectAsync<SubforumCollection>(URL_SUBFORUM, cancellationToken);
            return collection.Subforums;
        }

        public async Task<IEnumerable<Thread>> GetPopularThreadsAsync(CancellationToken cancellationToken = default)
        {
            return await GetRequiredCollectionAsync<Thread>(URL_THREADS_POPULAR, cancellationToken);
        }

        public async Task<Thread?> GetThreadAsync(uint threadId, CancellationToken cancellationToken = default)
        {
            return await GetObjectAsync<Thread>($"{URL_THREADS}{threadId}", cancellationToken);
        }

        public async Task<User?> GetUserAsync(uint userId, CancellationToken cancellationToken = default)
        {
            return await GetObjectAsync<User>($"{URL_USER}{userId}", cancellationToken);
        }
    }
}
