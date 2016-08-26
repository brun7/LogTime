using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogTime
{
    public class DateTimeProvider 
    {
        public static Func<DateTime> DateProvider = () => DateTime.Now;
        public static DateTime Now {  get { return DateProvider(); } }
    }
}
