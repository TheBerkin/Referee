using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Referee.Serialization
{
    internal sealed class KnockoutJsonSerializer : JsonSerializer
    {
        public KnockoutJsonSerializer(Knockout knockoutContext) : base()
        {
            KnockoutContext = knockoutContext ?? throw new ArgumentNullException(nameof(knockoutContext));

            Context = new StreamingContext(StreamingContextStates.All, KnockoutContext);
        }

        public Knockout KnockoutContext { get; }
    }
}
