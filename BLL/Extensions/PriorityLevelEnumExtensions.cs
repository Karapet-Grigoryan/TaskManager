using System;
using System.Collections.Generic;
using System.Text;
using TaskManager.BLL.Enums;

namespace TaskManager.BLL.Extensions
{
    public static class PriorityLevelEnumExtensions
    {
        public static PriorityLevelEnum ToPriorityEnum(this int priorityId)
        {
            return (PriorityLevelEnum)priorityId;
        }

        public static int ToInt(this PriorityLevelEnum priority)
        {
            return (int)priority;
        }
    }
}
