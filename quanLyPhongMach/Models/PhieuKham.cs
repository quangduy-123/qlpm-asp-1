//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace quanLyPhongMach.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class PhieuKham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PhieuKham()
        {
            this.DonThuocs = new HashSet<DonThuoc>();
            this.HoaDons = new HashSet<HoaDon>();
        }
    
        public int MaChiTiet { get; set; }
        public string MaHS { get; set; }
        public short LanKham { get; set; }
        public Nullable<System.DateTime> NgayKham { get; set; }
        public Nullable<short> MaNV { get; set; }
        public string NDDieuTri { get; set; }
        public Nullable<decimal> ChiPhiKham { get; set; }
        public string GhiChu { get; set; }
        public bool Status { get; set; }
        public Nullable<short> Mach { get; set; }
        public Nullable<double> NhietDo { get; set; }
        public string HuyetAp { get; set; }
        public Nullable<short> NhipTho { get; set; }
        public Nullable<double> CanNang { get; set; }
        public Nullable<double> ChieuCao { get; set; }
        public Nullable<double> BMI { get; set; }
        public Nullable<bool> HuyKham { get; set; }
        public string CanLamSang { get; set; }
        public string TrieuChung { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DonThuoc> DonThuocs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDon> HoaDons { get; set; }
        public virtual NhanVien NhanVien { get; set; }
    }
}
