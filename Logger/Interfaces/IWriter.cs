using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    interface IWriter
    {
        void Write(DateTime dateTime, Level level, string message);
    }
}
