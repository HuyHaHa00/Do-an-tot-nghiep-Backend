namespace WebAPI_for_GoldGym
{
    public class CTLichTapVaDSTap
    {
        public int IdChiTietLichTap { get; set; }
        public int IdLichTap { get; set; }
        public int IdDstap { get; set; }
        public int BuoiTap { get; set; }
        public string TenDstap { get; set; } = null!;
        public string? MoTaDstap { get; set; }
        public string LoaiDstap { get; set; } = null!;
        public int? TrangThaiBuoiTap { get; set; }

    }
}
