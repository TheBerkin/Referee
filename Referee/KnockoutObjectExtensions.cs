using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Referee
{
    public static class KnockoutObjectExtensions
    {
        public static T OwnedBy<T>(this T koObj, Knockout owner) where T : KnockoutObject
        {
            koObj.Owner = owner;
            return koObj;
        }

        public static IEnumerable<T> OwnedBy<T>(this IEnumerable<T> koObjects, Knockout owner) where T : KnockoutObject
        {
            return koObjects.Select(o =>
            {
                o.Owner = owner;
                return o;
            });
        }
    }
}
