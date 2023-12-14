using System.Globalization;

namespace CCC.Service.Infra
{
	public static class HelperUtility
    {
        public static string GetMonthName(int monthNumber)
        {
            DateTimeFormatInfo mfi = new DateTimeFormatInfo();
            return mfi.GetMonthName(monthNumber).ToString();
        }
    }
}
