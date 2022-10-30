using System;
using System.Collections.Generic;

namespace WebAPI_for_GoldGym.Models
{
    public partial class TblDstap
    {

        public int IdDstap { get; set; }
        public int IdTaiKhoan { get; set; }
        public string TenDstap { get; set; } = null!;
        public string? MoTaDstap { get; set; }
        public string LoaiDstap { get; set; } = null!;

    }
}
