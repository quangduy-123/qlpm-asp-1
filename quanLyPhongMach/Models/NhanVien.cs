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
    
    public partial class NhanVien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NhanVien()
        {
            this.HoaDons = new HashSet<HoaDon>();
            this.PhieuKhams = new HashSet<PhieuKham>();
            this.PhieuHens = new HashSet<PhieuHen>();
            this.PhieuThuChiTiets = new HashSet<PhieuThuChiTiet>();
        }
    
        public short MaNV { get; set; }
        public string TenNV { get; set; }
        public string Phai { get; set; }
        public Nullable<System.DateTime> NgaySinh { get; set; }
        public string DiaChi { get; set; }
        public string DienThoai { get; set; }
        public string ChuyenMon { get; set; }
        public string NgoaiNgu { get; set; }
        public Nullable<decimal> MucLuong { get; set; }
        public string ChucVu { get; set; }
        public string TaiKhoan { get; set; }
        public string MatKhauTC { get; set; }
        public string GhiChu { get; set; }
        public byte[] Hinh { get; set; }
        public Nullable<int> DonVi { get; set; }
    
        public virtual DonViSuDung DonViSuDung { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDon> HoaDons { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhieuKham> PhieuKhams { get; set; }
        public virtual NhanVienQuyen NhanVienQuyen { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhieuHen> PhieuHens { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhieuThuChiTiet> PhieuThuChiTiets { get; set; }
    }
}
