using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace test.model
{
    public partial class PsboContext : DbContext
    {
        public virtual DbSet<Akun> Akun { get; set; }
        public virtual DbSet<Barang> Barang { get; set; }
        public virtual DbSet<DetailTransaksi> DetailTransaksi { get; set; }
        public virtual DbSet<Transaksi> Transaksi { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseSqlite(@"data source=""C:\Users\stndn\Documents\Visual Studio 2015\Projects\PSBO-Sayang\pbo\psbo.db""");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}