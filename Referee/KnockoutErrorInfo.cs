﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Referee
{
    [DataContract]
    internal sealed class KnockoutErrorInfo
    {
        [DataMember(Name = "error", IsRequired = true)]
        public string Message { get; init; }
    }
}