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
    
    public partial class DonThuocMauChiTiet
    {
        public int ID { get; set; }
        public string idDonThuoc { get; set; }
        public string MaThuoc { get; set; }
        public Nullable<int> SoLuong { get; set; }
        public Nullable<decimal> DonGia { get; set; }
        public Nullable<decimal> ChiPhi { get; set; }
        public string DonVi { get; set; }
        public string Sang { get; set; }
        public string Trua { get; set; }
        public string Chieu { get; set; }
        public string Toi { get; set; }
        public string GhiChu { get; set; }
    
        public virtual DonThuocMau DonThuocMau { get; set; }
        public virtual DonViTinh DonViTinh { get; set; }
    }
}
