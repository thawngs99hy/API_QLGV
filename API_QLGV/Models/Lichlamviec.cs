using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_QLGV.Models
{
    [Table("LICHLAMVIEC")]
    public partial class Lichlamviec
    {
        [Key]
        [Column("MaLLV")]
        public int MaLlv { get; set; }
        [Column("MaGV")]
        public int MaGv { get; set; }
        [Column("NgayBD", TypeName = "date")]
        public DateTime? NgayBd { get; set; }
        [Column("NgayKT", TypeName = "date")]
        public DateTime? NgayKt { get; set; }
        [Column(TypeName = "text")]
        public string CongViec { get; set; }
        [StringLength(15)]
        public string Thu { get; set; }
        [StringLength(10)]
        public string Tuan { get; set; }
        [StringLength(50)]
        public string DiaChi { get; set; }

        [ForeignKey(nameof(MaGv))]
        [InverseProperty(nameof(Giangvien.Lichlamviec))]
        public virtual Giangvien MaGvNavigation { get; set; }
    }
}
