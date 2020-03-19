using System;
using System.Collections.Generic;

namespace QCHNT.Model
{
    public partial class Daozhaandcamera
    {
        public int Id { get; set; }
        public string DaoZhaName { get; set; }
        public string CameraName { get; set; }
        public string OutInSign { get; set; }
        public string CardReaderName { get; set; }
        public DateTime? Date { get; set; }
    }
}
