using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_QLGV.Models
{
    [Table("BOMONTRUNGTAM")]
    public partial class Bomontrungtam
    {
        public Bomontrungtam()
        {
            Giangvien = new HashSet<Giangvien>();
        }

        [Key]
        [Column("MABM")]
        public int Mabm { get; set; }
        [Required]
        [Column("TenBM")]
        [StringLength(100)]
        public string TenBm { get; set; }
        public string DiaChi { get; set; }
        [StringLength(11)]
        public string Fax { get; set; }
        public string ThongTin { get; set; }
        public string NhiemVuChuyenMon { get; set; }
        public string HuongNghienCuu { get; set; }
        public string DoiNguGiangVien { get; set; }

        [InverseProperty("MaBmNavigation")]
        public virtual ICollection<Giangvien> Giangvien { get; set; }
    }
}
