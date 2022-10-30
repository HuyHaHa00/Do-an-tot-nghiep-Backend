using System;
using System.Collections.Generic;

namespace WebAPI_for_GoldGym.Models
{
    public partial class TblChiTietLichTap
    {
        public int IdChiTietLichTap { get; set; }
        public int IdLichTap { get; set; }
        public int? IdDstap { get; set; }
        public int BuoiTap { get; set; }

    }
}
