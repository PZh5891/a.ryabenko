using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsoleProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DateTime dt = DateTime.Now;
            DateTime beginDate;
            DateTime endDate;
            bool result;
            beginDate = new DateTime(2018, 01, 01);
            endDate = new DateTime(2018, 07, 01);
            result = false;
            Console.WriteLine("{0} {1} {2} {3}", beginDate, endDate, SomeMethod(beginDate, endDate), result);

            beginDate = new DateTime(2018, 06, 01);
            endDate = new DateTime(2019, 03, 01);
            result = false;
            Console.WriteLine("{0} {1} {2} {3}", beginDate, endDate, SomeMethod(beginDate, endDate), result);

            beginDate = new DateTime(2020, 01, 01);
            endDate = new DateTime(2020, 10, 03);
            result = true;
            Console.WriteLine("{0} {1} {2} {3}", beginDate, endDate, SomeMethod(beginDate, endDate), result);

            beginDate = new DateTime(2012, 01, 10);
            endDate = new DateTime(2013, 01, 10);
            result = true;
            Console.WriteLine("{0} {1} {2} {3}", beginDate, endDate, SomeMethod(beginDate, endDate), result);

            beginDate = new DateTime(2016, 02, 29);
            endDate = new DateTime(2017, 01, 01);
            result = true;
            Console.WriteLine("{0} {1} {2} {3}", beginDate, endDate, SomeMethod(beginDate, endDate), result);

            beginDate = new DateTime(2019, 03, 01);
            endDate = new DateTime(2020, 02, 29);
            result = true;
            Console.WriteLine("{0} {1} {2} {3}", beginDate, endDate, SomeMethod(beginDate, endDate), result);

            beginDate = new DateTime(2023, 12, 31);
            endDate = new DateTime(2024, 06, 01);
            result = true;
            Console.WriteLine("{0} {1} {2} {3}", beginDate, endDate, SomeMethod(beginDate, endDate), result);


            Console.ReadLine();
        }

        private static bool SomeMethod(DateTime beginDate, DateTime endDate)
        {
            int highYear = endDate.Year;
            if (beginDate.Year % 4 == 0)
            {
                highYear = beginDate.Year;
            }
            if (highYear % 4 == 0)
            {
                DateTime feb = new DateTime(highYear, 2, 29);
                return (feb >= beginDate && feb <= endDate);
            }
            else
            {
                return false;
            }
        }
    }
}
