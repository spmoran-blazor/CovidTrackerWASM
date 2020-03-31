using System;
using System.Collections.Generic;
using System.Text;

namespace CovidTrackerWASM.Shared.Common
{
    public static class Helper
    {
        public static DateTime ConvertFromEpochMilliseconds(long epoch)
        {
            DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeMilliseconds(epoch);
            DateTime dateTime = dateTimeOffset.UtcDateTime;
            return dateTime;
        }
    }
}
