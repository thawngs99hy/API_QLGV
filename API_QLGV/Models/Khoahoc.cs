using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_QLGV.Models
{
    [Table("KHOAHOC")]
    public partial class Khoahoc
    {
        [Key]
        [Column("maKH")]
        public int MaKh { get; set; }
        [Column("MaGV")]
        public int MaGv { get; set; }
        [Required]
        [Column("tenKH")]
        [StringLength(100)]
        public string TenKh { get; set; }
        [Column("loaiKH")]
        [StringLength(255)]
        public string LoaiKh { get; set; }
        [Column(TypeName = "text")]
        public string Link { get; set; }
        [Column(TypeName = "text")]
        public string GhiChu { get; set; }
        public int? TrangThai { get; set; }

        [ForeignKey(nameof(MaGv))]
        [InverseProperty(nameof(Giangvien.Khoahoc))]
        public virtual Giangvien MaGvNavigation { get; set; }
    }
}
