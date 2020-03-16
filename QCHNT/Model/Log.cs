using System;
using System.Collections.Generic;

namespace QCHNT.Model
{
    public partial class Log
    {
        public int Id { get; set; }
        public string LogUser { get; set; }
        public string LogContent { get; set; }
        public DateTime? Date { get; set; }
    }
}
