using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    [Serializable]
    public class Log
    {
        public Guid Id { get; set; }
        public DateTime CreateOn { get; set; }
        public Level Lvl { get; set; }
        public string Message { get; set; }
    }
}
