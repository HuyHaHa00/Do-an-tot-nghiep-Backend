using System;
using System.Collections.Generic;

namespace WebAPI_for_GoldGym.Models
{
    public partial class TblDonGd
    {
        public int IdDonGd { get; set; }
        public int IdTaiKhoan { get; set; }
        public DateTime TgguiDon { get; set; }
        public string MaGd { get; set; } = null!;
        public string? TtpheDuyet { get; set; }

    }
}
