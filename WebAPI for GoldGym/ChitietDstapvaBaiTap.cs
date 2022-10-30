namespace WebAPI_for_GoldGym
{
    public class ChitietDstapvaBaiTap
    {
        public int IdChiTietDstap { get; set; }
        public int IdDstap { get; set; }
        public int IdBaiTap { get; set; }
        public int? SoLanTap { get; set; }
        public int? ThoiGianTap { get; set; }
        public string BpCoThe { get; set; } = null!;
        public string TbsuDung { get; set; } = null!;
        public string Urlanh { get; set; } = null!;
        public string TenBaiTap { get; set; } = null!;
        public string NhomCo { get; set; } = null!;
    }
}
