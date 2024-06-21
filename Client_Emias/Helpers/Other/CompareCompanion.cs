using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client_Emias.Helpers.Other
{
    static class CompareCompanion
    {
        public static bool IsDateEarlier(DateTime date, DateOnly sourceDate, TimeOnly sourceTime)
        {
            return sourceDate.Year > date.Year ||
                sourceDate.Year == date.Year && sourceDate.Month > date.Month ||
                sourceDate.Year == date.Year && sourceDate.Month == date.Month && sourceDate.Day > date.Day ||
                sourceDate.Year == date.Year && sourceDate.Month == date.Month && sourceDate.Day == date.Day && sourceTime.Ticks > date.TimeOfDay.Ticks;
        }
    }
}
