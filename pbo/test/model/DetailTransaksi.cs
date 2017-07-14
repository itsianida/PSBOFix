using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace test.model
{
    [Table("detail_transaksi")]
    public partial class DetailTransaksi
    {
        [Column("id_dt")]
        [Key]
        public long IdDt { get; set; }
        [Column("id_trans", TypeName = "bigint")]
        public long IdTrans { get; set; }
        [Column("id_barang", TypeName = "bigint")]
        public long IdBarang { get; set; }
        [Column("jumlah_barang", TypeName = "bigint")]
        public long JumlahBarang { get; set; }
        [Column("harga_barang", TypeName = "bigint")]
        public long HargaBarang { get; set; }
        [Required]
        [Column("nama_barang", TypeName = "string")]
        public string NamaBarang { get; set; }
    }
}
