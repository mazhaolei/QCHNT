using System;
using System.Collections.Generic;

namespace QCHNT.Model
{
    public partial class Weighinginstrument
    {
        public int Id { get; set; }
        public string MainCom { get; set; }
        public string StandbyCom { get; set; }
        public string MainBaute { get; set; }
        public string StandbyBaute { get; set; }
        public DateTime? Date { get; set; }
    }
}
