using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_QLGV.Models
{
    [Table("MONHOC")]
    public partial class Monhoc
    {
        [Key]
        [Column("maMH")]
        public int MaMh { get; set; }
        [Required]
        [Column("tenMH")]
        [StringLength(100)]
        public string TenMh { get; set; }
        [Column("SoTCLT")]
        public int? SoTclt { get; set; }
        [Column("SoTCTH")]
        public int? SoTcth { get; set; }
        public int? TrangThai { get; set; }
    }
}
