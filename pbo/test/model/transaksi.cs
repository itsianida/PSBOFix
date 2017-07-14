using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace test.model
{
    [Table("transaksi")]
    public partial class Transaksi
    {
        [Column("id_transaksi")]
        [Key]
        public long IdTransaksi { get; set; }
        [Column("jumlah_pembelian", TypeName = "bigint")]
        public long JumlahPembelian { get; set; }
        [Column("diskon", TypeName = "bigint")]
        public long? Diskon { get; set; }
        [Column("total_harga", TypeName = "bigint")]
        public long TotalHarga { get; set; }
        [Required]
        [Column("tanggal_trans", TypeName = "text")]
        public string TanggalTrans { get; set; }
    }
}
