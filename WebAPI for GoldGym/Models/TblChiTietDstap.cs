using System;
using System.Collections.Generic;

namespace WebAPI_for_GoldGym.Models
{
    public partial class TblChiTietDstap
    {
        public int IdChiTietDstap { get; set; }
        public int IdDstap { get; set; }
        public int IdBaiTap { get; set; }
        public int? SoLanTap { get; set; }
        public int? ThoiGianTap { get; set; }

    }
}
