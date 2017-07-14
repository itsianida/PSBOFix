using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace test.model
{
    [Table("daftarpegawai")]
    public partial class Daftarpegawai
    {
        [Column("id_pegawai")]
        [Key]
        public long IdPegawai { get; set; }
        [Required]
        [Column("nama_lengkap", TypeName = "text")]
        public string NamaLengkap { get; set; }
        [Required]
        [Column("tanggal_lahir", TypeName = "text")]
        public string TanggalLahir { get; set; }
        [Required]
        [Column("alamat_rumah", TypeName = "text")]
        public string AlamatRumah { get; set; }
        [Required]
        [Column("alamat_asal", TypeName = "text")]
        public string AlamatAsal { get; set; }
        [Required]
        [Column("no_hp", TypeName = "numeric(53,0)")]
        public string NoHp { get; set; }
        [Required]
        [Column("username", TypeName = "text")]
        public string Username { get; set; }
        [Required]
        [Column("password", TypeName = "text")]
        public string Password { get; set; }
        [Required]
        [Column("no_pegawai", TypeName = "numeric(53,0)")]
        public string NoPegawai { get; set; }
    }
}
