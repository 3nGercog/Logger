using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    class FileWriter : IWriter
    {
        public void Write(DateTime dateTime, Level level, string message)
        {
            var date = dateTime.ToString("ddyyyyMM");
            var logFileName = string.Format("{0}.log", date);
            using (var streamWriter = new StreamWriter(logFileName, true))
            {
                var time = dateTime.ToString("HH:mm:ss.fff");
                var line = string.Format("{0}\t{1}\t{2}", time, level, message);
                streamWriter.WriteLine(line);
            }
        }
    }
}
