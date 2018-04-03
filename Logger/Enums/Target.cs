using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    [Flags]
    public enum Target
    {
        Console = 0x1,
        File = 0x2,
        DataBase = 0x4,
        EventLog = 0x8,
        Output = 0x10
    }
}
