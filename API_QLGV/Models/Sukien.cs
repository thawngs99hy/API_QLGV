using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_QLGV.Models
{
    [Table("SUKIEN")]
    public partial class Sukien
    {
        [Key]
        [Column("MaSK")]
        public int MaSk { get; set; }
        [Column("TenSK")]
        [StringLength(150)]
        public string TenSk { get; set; }
        [Column(TypeName = "text")]
        public string NoiDung { get; set; }
        [Column("NgayBD", TypeName = "datetime")]
        public DateTime? NgayBd { get; set; }
        [Column("NgayKT", TypeName = "datetime")]
        public DateTime? NgayKt { get; set; }
    }
}
