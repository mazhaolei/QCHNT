using System;
using System.Collections.Generic;

namespace QCHNT.Model
{
    public partial class Cameraconfig
    {
        public int Id { get; set; }
        public string CameraIp { get; set; }
        public string CameraUser { get; set; }
        public string CameraPassword { get; set; }
        public DateTime? Date { get; set; }
    }
}
