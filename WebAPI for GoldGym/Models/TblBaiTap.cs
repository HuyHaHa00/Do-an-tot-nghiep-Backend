using System;
using System.Collections.Generic;

namespace WebAPI_for_GoldGym.Models
{
    public partial class TblBaiTap
    {

        public string BpCoThe { get; set; } = null!;
        public string TbsuDung { get; set; } = null!;
        public string Urlanh { get; set; } = null!;
        public int IdBaiTap { get; set; }
        public string TenBaiTap { get; set; } = null!;
        public string NhomCo { get; set; } = null!;

    }
}
