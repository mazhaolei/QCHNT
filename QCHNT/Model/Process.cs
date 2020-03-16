using System;
using System.Collections.Generic;

namespace QCHNT.Model
{
    public partial class Process
    {
        public int Id { get; set; }
        public string WeightListNumber { get; set; }
        public string ProcessTime { get; set; }
        public string Flow { get; set; }
        public string Area { get; set; }
        public DateTime? InsertTime { get; set; }
        public string FinishMark { get; set; }
        public string Icnumber { get; set; }
        public string CarNumber { get; set; }
        public DateTime? UpdateTime { get; set; }
        public DateTime? Date { get; set; }
    }
}
