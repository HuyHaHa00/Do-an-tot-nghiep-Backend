using System;
using System.Collections.Generic;

namespace WebAPI_for_GoldGym.Models
{
    public partial class TblTaiKhoan
    {
        
        public int IdTaiKhoan { get; set; }
        public string TenDangNhap { get; set; } = null!;
        public string MatKhau { get; set; } = null!;
        public string Quyen { get; set; } = null!;
        public string? TrangThaiPremium { get; set; }
        public DateTime ThoiGianDk { get; set; }

    }
}
