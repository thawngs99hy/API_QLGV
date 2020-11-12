using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_QLGV.Models
{
    [Table("GIODAY")]
    public partial class Gioday
    {
        [Key]
        [Column("maGD")]
        public int MaGd { get; set; }
        [Column("MaGV")]
        public int MaGv { get; set; }
        [Column("NgayBD", TypeName = "date")]
        public DateTime NgayBd { get; set; }
        [Column(TypeName = "ntext")]
        public string GhiChu { get; set; }
        public int? TrangThai { get; set; }

        [ForeignKey(nameof(MaGv))]
        [InverseProperty(nameof(Giangvien.Gioday))]
        public virtual Giangvien MaGvNavigation { get; set; }
    }
}
