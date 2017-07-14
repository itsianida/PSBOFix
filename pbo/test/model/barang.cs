using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace test.model
{
    [Table("barang")]
    public partial class Barang
    {
        [Column("id_barang")]
        [Key]
        public long IdBarang { get; set; }
        [Required]
        [Column("nama_barang", TypeName = "text")]
        public string NamaBarang { get; set; }
        [Column("jumlah_barang", TypeName = "bigint")]
        public long JumlahBarang { get; set; }
        [Column("harga_barang", TypeName = "bigint")]
        public long HargaBarang { get; set; }
        [Required]
        [Column("id_produk", TypeName = "text")]
        public string IdProduk { get; set; }
    }
}
