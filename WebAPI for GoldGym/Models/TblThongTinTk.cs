using System;
using System.Collections.Generic;

namespace WebAPI_for_GoldGym.Models
{
    public partial class TblThongTinTk
    {
        public int IdThongTinTk { get; set; }
        public int IdTaiKhoan { get; set; }
        public string? HoTen { get; set; }
        public string? GioiTinh { get; set; }
        public int? Tuoi { get; set; }
        public string? Sdt { get; set; }
        public string? Email { get; set; }

    }
}
