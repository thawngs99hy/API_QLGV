using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_QLGV.Models
{
    [Table("KHOA")]
    public partial class Khoa
    {
        [Key]
        [Column("maKhoa")]
        public int MaKhoa { get; set; }
        [Required]
        [Column("tenKhoa")]
        [StringLength(100)]
        public string TenKhoa { get; set; }
        [StringLength(50)]
        public string DiaChiKhoa { get; set; }
        [StringLength(50)]
        public string TruongKhoa { get; set; }
        [StringLength(50)]
        public string WebsiteKhoa { get; set; }
    }
}
