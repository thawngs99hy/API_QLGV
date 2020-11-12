using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_QLGV.Models
{
    [Table("KHENTHUONG")]
    public partial class Khenthuong
    {
        [Key]
        [Column("maKT")]
        public int MaKt { get; set; }
        [Column("MaGV")]
        public int MaGv { get; set; }
        [Required]
        [StringLength(100)]
        public string Ten { get; set; }
        [Column(TypeName = "ntext")]
        public string LyDo { get; set; }
        [Column(TypeName = "date")]
        public DateTime? Ngay { get; set; }
        [Column(TypeName = "ntext")]
        public string HinhThuc { get; set; }
        [Column(TypeName = "ntext")]
        public string GhiChu { get; set; }
        public int? TrangThai { get; set; }

        [ForeignKey(nameof(MaGv))]
        [InverseProperty(nameof(Giangvien.Khenthuong))]
        public virtual Giangvien MaGvNavigation { get; set; }
    }
}
