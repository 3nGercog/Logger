using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    class DataBaseWriter : IWriter
    {
        private class LogContext: DbContext
        {
            public DbSet<Log> Logs { get; set; }
        }
        Log log;

        public void Write(DateTime dateTime, Level level, string message)
        {
            log = new Log
            {
                Id = Guid.NewGuid(),
                CreateOn = dateTime,
                Lvl = level,
                Message = message
            };
            using (var context = new LogContext())
            {
                context.Logs.Add(log);
                context.SaveChangesAsync();
            }
        }
    }
}
