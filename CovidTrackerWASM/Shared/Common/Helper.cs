using System;

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

        public static string TransformEpochDate(Int64 epoch)
        {
            Int64 val = Convert.ToInt64(epoch);
            var tmpDate = ConvertFromEpochMilliseconds(val);
            string _convertedDate = tmpDate.ToLongDateString() + " - " + tmpDate.ToShortTimeString() + " UTC";
            return _convertedDate;
        }
    }
}