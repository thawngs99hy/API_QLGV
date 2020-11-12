using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_QLGV.Models
{
    [Table("CHUCVU")]
    public partial class Chucvu
    {
        public Chucvu()
        {
            Giangvien = new HashSet<Giangvien>();
        }

        [Key]
        [Column("maCV")]
        public int MaCv { get; set; }
        [Column("tenCV")]
        [StringLength(100)]
        public string TenCv { get; set; }

        [InverseProperty("MaCvNavigation")]
        public virtual ICollection<Giangvien> Giangvien { get; set; }
    }
}
