using System;
using System.Collections.Generic;
using System.Text;
using TaskManager.BLL.Enums;

namespace TaskManager.BLL.Extensions
{
    public static class TaskStatusEnumExtensions
    {
        public static TaskStatusEnum ToStatusEnum(this int statusId)
        {
            return (TaskStatusEnum)statusId;
        }

        public static int ToInt(this TaskStatusEnum status)
        {
            return (int)status;
        }
    }
}
