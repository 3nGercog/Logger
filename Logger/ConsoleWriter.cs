using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    class ConsoleWriter : IWriter
    {
        public void Write(DateTime dateTime, Level level, string message)
        {
            Console.WriteLine(string.Format("{0}\t{1}\t{2}", dateTime.ToString("yyyy.MM.dd HH: mm:ss.fff"), level, message));
        }
    }
}
