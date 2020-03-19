using System;
using System.Collections.Generic;

namespace QCHNT.Model
{
    public partial class Contract
    {
        public int Id { get; set; }
        public string ContractNumber { get; set; }
        public string GoodsName { get; set; }
        public string ContractType { get; set; }
        public string Area { get; set; }
        public string SupplyUnit { get; set; }
        public string ReceiveUnit { get; set; }
        public double? TotalContract { get; set; }
        public double? ContractReduction { get; set; }
        public double? ResidualContract { get; set; }
        public DateTime? Date { get; set; }
    }
}
