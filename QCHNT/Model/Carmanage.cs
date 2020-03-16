using System;
using System.Collections.Generic;

namespace QCHNT.Model
{
    public partial class Carmanage
    {
        public int Id { get; set; }
        public string Icnumber { get; set; }
        public string CarNumber { get; set; }
        public string CarDriver { get; set; }
        public string CarFleet { get; set; }
        public string CarType { get; set; }
        public string ContractNumber { get; set; }
        public double? NormWeight { get; set; }
        public string FinishMark { get; set; }
        public string Operator { get; set; }
        public DateTime? Date { get; set; }
    }
}
