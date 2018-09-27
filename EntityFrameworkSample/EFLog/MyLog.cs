using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkSample.EFLog
{
  public  class MyLog
    {
        public static void Log(string application, string message)
        {
            Console.WriteLine($"Application: {application}, EF Message: {message}");
        }

    }
}
