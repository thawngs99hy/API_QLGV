using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_QLGV.Models
{
    [Table("HOCVAN")]
    public partial class Hocvan
    {
        [Key]
        [Column("maHV")]
        public int MaHv { get; set; }
        [Column("MaGV")]
        public int MaGv { get; set; }
        [Required]
        [Column("tenHV")]
        [StringLength(100)]
        public string TenHv { get; set; }
        [Column(TypeName = "date")]
        public DateTime? NamTotNghiep { get; set; }
        [Column(TypeName = "ntext")]
        public string ChungChiSuPham { get; set; }
        [Column(TypeName = "ntext")]
        public string ChuyenNganhDaoTao { get; set; }
        [Column(TypeName = "ntext")]
        public string DonViCongTac { get; set; }
        [Column(TypeName = "ntext")]
        public string TrinhDoTinHoc { get; set; }
        [Column(TypeName = "ntext")]
        public string TrinhdoNgoaiNgu { get; set; }
        public int? TrangThai { get; set; }

        [ForeignKey(nameof(MaGv))]
        [InverseProperty(nameof(Giangvien.Hocvan))]
        public virtual Giangvien MaGvNavigation { get; set; }
    }
}
