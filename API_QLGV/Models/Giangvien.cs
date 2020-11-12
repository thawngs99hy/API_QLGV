using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_QLGV.Models
{
    [Table("GIANGVIEN")]
    public partial class Giangvien
    {
        public Giangvien()
        {
            Gioday = new HashSet<Gioday>();
            Hocvan = new HashSet<Hocvan>();
            Khenthuong = new HashSet<Khenthuong>();
            Khoahoc = new HashSet<Khoahoc>();
            Lichlamviec = new HashSet<Lichlamviec>();
        }

        [Key]
        [Column("MaGV")]
        public int MaGv { get; set; }
        [Column("MaBM")]
        public int MaBm { get; set; }
        [Required]
        [Column("TenGV")]
        [StringLength(50)]
        public string TenGv { get; set; }
        [Column(TypeName = "date")]
        public DateTime? NgaySinh { get; set; }
        [StringLength(50)]
        public string QueQuan { get; set; }
        [StringLength(15)]
        public string Tel { get; set; }
        [StringLength(22)]
        public string Fax { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        public string NoiLamViec { get; set; }
        public string QuaTrinhDaoTao { get; set; }
        public string MonGiangDay { get; set; }
        public string LinhvucNghienCuu { get; set; }
        public string HoSo { get; set; }
        [StringLength(30)]
        public string Img { get; set; }
        [StringLength(100)]
        public string Website { get; set; }
        public int? MaBac { get; set; }
        [Column("GIOITINH")]
        [StringLength(3)]
        public string Gioitinh { get; set; }
        [Column("NoiOHienTai")]
        [StringLength(100)]
        public string NoiOhienTai { get; set; }
        [StringLength(50)]
        public string DanToc { get; set; }
        [StringLength(50)]
        public string TonGiao { get; set; }
        [Column("CMND")]
        public int? Cmnd { get; set; }
        [Column(TypeName = "date")]
        public DateTime? NgayCap { get; set; }
        [StringLength(50)]
        public string NoiCap { get; set; }
        [Column(TypeName = "date")]
        public DateTime? NgayKetNapDang { get; set; }
        [StringLength(50)]
        public string NoiKetNap { get; set; }
        public int? TrangThai { get; set; }
        [Column("maMH")]
        public int? MaMh { get; set; }
        [Column("maCv")]
        public int? MaCv { get; set; }

        [ForeignKey(nameof(MaBm))]
        [InverseProperty(nameof(Bomontrungtam.Giangvien))]
        public virtual Bomontrungtam MaBmNavigation { get; set; }
        [ForeignKey(nameof(MaCv))]
        [InverseProperty(nameof(Chucvu.Giangvien))]
        public virtual Chucvu MaCvNavigation { get; set; }
        [InverseProperty("MaGvNavigation")]
        public virtual ICollection<Gioday> Gioday { get; set; }
        [InverseProperty("MaGvNavigation")]
        public virtual ICollection<Hocvan> Hocvan { get; set; }
        [InverseProperty("MaGvNavigation")]
        public virtual ICollection<Khenthuong> Khenthuong { get; set; }
        [InverseProperty("MaGvNavigation")]
        public virtual ICollection<Khoahoc> Khoahoc { get; set; }
        [InverseProperty("MaGvNavigation")]
        public virtual ICollection<Lichlamviec> Lichlamviec { get; set; }
    }
}
