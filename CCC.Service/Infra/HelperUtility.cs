using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
