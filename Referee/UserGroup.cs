using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Referee
{
    public enum UserGroup : byte
    {
        Member = 1,
        GoldMember = 2,
        Moderator = 3,
        Admin = 4,
        Staff = 5,
        ModeratorInTraining = 6,
        Banned = 0,
    }
}
