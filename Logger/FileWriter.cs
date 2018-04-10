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
        string PATH = AppDomain.CurrentDomain.BaseDirectory + "\\bin\\logs";
        public void Write(DateTime dateTime, Level level, string message)
        {
            
            if (!Directory.Exists(PATH))
            {
                Directory.CreateDirectory(PATH);
            }
            var date = dateTime.ToString("ddyyyyMM");
            var logFileName = string.Format("{0}.log", date);
            using (var streamWriter = new StreamWriter(Path.Combine(PATH, logFileName), true))
            {
                var time = dateTime.ToString("HH:mm:ss.fff");
                var line = string.Format("{0}\t{1}\t{2}", time, level, message);
                streamWriter.WriteLine(line);
            }
        }
    }
}
