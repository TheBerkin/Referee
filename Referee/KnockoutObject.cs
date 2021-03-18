using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Referee
{
    public abstract class KnockoutObject
    {
        public Knockout Owner { get; internal set; }
    }
}
