using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_QLGV.Models
{
    [Table("LUONG")]
    public partial class Luong
    {
        [Key]
        [Column("maLuong")]
        public int MaLuong { get; set; }
        [Column("maBac")]
        public int MaBac { get; set; }
        public int? MucLuong { get; set; }
        [Column("LuongCB", TypeName = "money")]
        public decimal? LuongCb { get; set; }
        [Column("LuongPC", TypeName = "money")]
        public decimal? LuongPc { get; set; }
        [Column(TypeName = "date")]
        public DateTime? NgayHuongLuong { get; set; }
        [Column(TypeName = "date")]
        public DateTime? NgayTangLuong { get; set; }
        public int? TrangThai { get; set; }

        [ForeignKey(nameof(MaBac))]
        [InverseProperty(nameof(Bacluong.Luong))]
        public virtual Bacluong MaBacNavigation { get; set; }
    }
}
