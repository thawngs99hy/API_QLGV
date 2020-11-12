using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_QLGV.Models
{
    [Table("BACLUONG")]
    public partial class Bacluong
    {
        public Bacluong()
        {
            Luong = new HashSet<Luong>();
        }

        [Key]
        [Column("maBac")]
        public int MaBac { get; set; }
        [Required]
        [Column("tenBac")]
        [StringLength(50)]
        public string TenBac { get; set; }
        [Column("HSBacLuong")]
        public int? HsbacLuong { get; set; }
        [StringLength(50)]
        public string NhomBac { get; set; }

        [InverseProperty("MaBacNavigation")]
        public virtual ICollection<Luong> Luong { get; set; }
    }
}
