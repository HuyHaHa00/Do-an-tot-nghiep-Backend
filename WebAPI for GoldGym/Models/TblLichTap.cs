using System;
using System.Collections.Generic;

namespace WebAPI_for_GoldGym.Models
{
    public partial class TblLichTap
    {

        public int IdLichTap { get; set; }
        public int IdTaiKhoan { get; set; }
        public string TenLichTap { get; set; } = null!;
        public string? MoTaLichTap { get; set; }
        public DateTime? NgayTap { get; set; }
        public string? TrangThai { get; set; }

    }
}
