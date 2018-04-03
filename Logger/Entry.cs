using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    class Entry
    {
        DateTime dateTime;
        Level level;
        string message;
        ConsoleWriter cWriter;
        FileWriter fileWriter;
        DataBaseWriter dbWriter;
        EventLogWriter elWriter;

        public Entry(DateTime dateTime, Level level, string message)
        {
            this.dateTime = dateTime;
            this.level = level;
            this.message = message.Replace("\t", "|").Replace("\r", "|").Replace("\n", "|");
            cWriter = new ConsoleWriter();
            fileWriter = new FileWriter();
            dbWriter = new DataBaseWriter();
            elWriter = new EventLogWriter();
        }
 
        public DateTime DateTime { get { return dateTime; } }
        public Level Level { get { return level; } }
        public string Message { get { return message; } }

        public void WriteToConsole()
        {
            cWriter.Write(DateTime, Level, Message);
        }
        public void WriteToFile()
        {
            fileWriter.Write(DateTime, Level, Message);
        }
        public void WriteToDataBase()
        {
            dbWriter.Write(DateTime, Level, Message);
        }
        public void WriteToEventLog()
        {
            elWriter.Write(DateTime, Level, Message);
        }
        public void WriteToOutput()
        {
#if DEBUG
            Debug.WriteLine(string.Format("{0}\t{1}\t{2}", DateTime, Level, Message));
#endif
        }
    }
}
