using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace E_Commerce_Elis_MVC.Models
{
    public partial class NegozioDbContext : DbContext
    {
        //public DbSet<Prodotto> Prodotti { get; set; }

        public NegozioDbContext()
        {
        }

        public NegozioDbContext(DbContextOptions<NegozioDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Prodotto> Prodotti { get; set; }
        public virtual DbSet<Utente> Utenti { get; set; }
        public virtual DbSet<Carrello> Carrelli { get; set; }
        public virtual DbSet<Negozio> Negozi { get; set; }
        public object ListaProdotti { get; internal set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Prodotto>(entity =>
            {
                entity.HasKey(e => e.IdProdotto);

                entity.ToTable("Prodotto");

                entity.Property(e => e.IdProdotto).ValueGeneratedNever();

                entity.Property(e => e.Prezzo).HasColumnType("money");

                entity.Property(e => e.NomeProdotto)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Quantita);
            });

            modelBuilder.Entity<Utente>(entity =>
            {
                entity.HasKey(e => e.IdUtente);

                entity.ToTable("Utente");

                entity.Property(e => e.IdUtente).ValueGeneratedNever();

                entity.Property(e => e.Nome)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Carrello);

            });

            modelBuilder.Entity<Carrello>(entity =>
            {
                entity.HasKey(e => e.IdCarrello);

                entity.ToTable("Carrello");

                entity.Property(e => e.ProdottiNelCarrello);

            });

            modelBuilder.Entity<Negozio>(entity =>
            {
                entity.HasKey(e => e.ListaProdotti);
            });

            OnModelCreatingGeneratedProcedures(modelBuilder);
            OnModelCreatingPartial(modelBuilder);
        }

        private void OnModelCreatingGeneratedProcedures(ModelBuilder modelBuilder)
        {
            throw new NotImplementedException();
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
