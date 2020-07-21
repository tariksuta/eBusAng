using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace eBus.WebApi.Database
{
    public partial class _170048Context : DbContext
    {
        public _170048Context()
        {
        }

        public _170048Context(DbContextOptions<_170048Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Angazuje> Angazuje { get; set; }
        public virtual DbSet<Cijena> Cijena { get; set; }
        public virtual DbSet<Drzava> Drzava { get; set; }
        public virtual DbSet<Grad> Grad { get; set; }
        public virtual DbSet<Karta> Karta { get; set; }
        public virtual DbSet<Kompanija> Kompanija { get; set; }
        public virtual DbSet<Korisnici> Korisnici { get; set; }
        public virtual DbSet<KorisniciUloge> KorisniciUloge { get; set; }
        public virtual DbSet<Linija> Linija { get; set; }
        public virtual DbSet<Notifikacije> Notifikacije { get; set; }
        public virtual DbSet<Novosti> Novosti { get; set; }
        public virtual DbSet<Ocjena> Ocjena { get; set; }
        public virtual DbSet<Putnik> Putnik { get; set; }
        public virtual DbSet<PutnikNotifikacije> PutnikNotifikacije { get; set; }
        public virtual DbSet<Rezervacija> Rezervacija { get; set; }
        public virtual DbSet<Sjediste> Sjediste { get; set; }
        public virtual DbSet<Uloga> Uloga { get; set; }
        public virtual DbSet<Vozilo> Vozilo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Server=.;Database=170048;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Angazuje>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DatumAngazovanja).HasColumnType("datetime");

                entity.Property(e => e.DatumIsteka).HasColumnType("datetime");

                entity.Property(e => e.LinijaId).HasColumnName("LinijaID");

                entity.Property(e => e.VoziloId).HasColumnName("VoziloID");

                entity.HasOne(d => d.Linija)
                    .WithMany(p => p.Angazuje)
                    .HasForeignKey(d => d.LinijaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Angazuje_Linija");

                entity.HasOne(d => d.Vozilo)
                    .WithMany(p => p.Angazuje)
                    .HasForeignKey(d => d.VoziloId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Anagazuje_Vozilo");
            });

            modelBuilder.Entity<Cijena>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Iznos).HasColumnType("decimal(8, 2)");

                entity.Property(e => e.KompanijaId).HasColumnName("KompanijaID");

                entity.Property(e => e.LinijaId).HasColumnName("LinijaID");

                entity.HasOne(d => d.Kompanija)
                    .WithMany(p => p.Cijena)
                    .HasForeignKey(d => d.KompanijaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cijena_Kompanija");

                entity.HasOne(d => d.Linija)
                    .WithMany(p => p.Cijena)
                    .HasForeignKey(d => d.LinijaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cijena_Linija");
            });

            modelBuilder.Entity<Drzava>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Grad>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DrzavaId).HasColumnName("DrzavaID");

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Drzava)
                    .WithMany(p => p.Grad)
                    .HasForeignKey(d => d.DrzavaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Grad_Drzava");
            });

            modelBuilder.Entity<Karta>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AngazujeId).HasColumnName("AngazujeID");

                entity.Property(e => e.BrojKarte)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.DatumIzdavanja).HasColumnType("datetime");

                entity.Property(e => e.SjedisteId).HasColumnName("SjedisteID");

                entity.Property(e => e.VrijemeDolaska).HasColumnType("time(0)");

                entity.Property(e => e.VrijemePolaska).HasColumnType("time(0)");

                entity.HasOne(d => d.Angazuje)
                    .WithMany(p => p.Karta)
                    .HasForeignKey(d => d.AngazujeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Karta_angazuje");

                entity.HasOne(d => d.Sjediste)
                    .WithMany(p => p.Karta)
                    .HasForeignKey(d => d.SjedisteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Karta_Sjediste");
            });

            modelBuilder.Entity<Kompanija>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Adresa).HasMaxLength(50);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.GradId).HasColumnName("GradID");

                entity.Property(e => e.KontaktBroj)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Grad)
                    .WithMany(p => p.Kompanija)
                    .HasForeignKey(d => d.GradId)
                    .HasConstraintName("FK_Kompanija_Grad");
            });

            modelBuilder.Entity<Korisnici>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.Ime)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.KorisnickoIme)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LozinkaHash).IsRequired();

                entity.Property(e => e.LozinkaSalt).IsRequired();

                entity.Property(e => e.Prezime)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<KorisniciUloge>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DatumIzmjene).HasColumnType("datetime");

                entity.Property(e => e.KorisnikId).HasColumnName("KorisnikID");

                entity.Property(e => e.UlogaId).HasColumnName("UlogaID");

                entity.HasOne(d => d.Korisnik)
                    .WithMany(p => p.KorisniciUloge)
                    .HasForeignKey(d => d.KorisnikId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KorisniciUloge_Korisnik");

                entity.HasOne(d => d.Uloga)
                    .WithMany(p => p.KorisniciUloge)
                    .HasForeignKey(d => d.UlogaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KorisniciUloge_Uloga");
            });

            modelBuilder.Entity<Linija>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.KorisnikId).HasColumnName("KorisnikID");

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.OdredisteId).HasColumnName("OdredisteID");

                entity.Property(e => e.PolazisteId).HasColumnName("PolazisteID");

                entity.HasOne(d => d.Korisnik)
                    .WithMany(p => p.Linija)
                    .HasForeignKey(d => d.KorisnikId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Linija_Korisnici");

                entity.HasOne(d => d.Odrediste)
                    .WithMany(p => p.LinijaOdrediste)
                    .HasForeignKey(d => d.OdredisteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Linija_Grad1");

                entity.HasOne(d => d.Polaziste)
                    .WithMany(p => p.LinijaPolaziste)
                    .HasForeignKey(d => d.PolazisteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Linija_Grad");
            });

            modelBuilder.Entity<Notifikacije>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DatumSlanja).HasColumnType("datetime");

                entity.Property(e => e.Naslov)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.NovostId).HasColumnName("NovostID");

                entity.HasOne(d => d.Novost)
                    .WithMany(p => p.Notifikacije)
                    .HasForeignKey(d => d.NovostId)
                    .HasConstraintName("FK_Notifikacije_Novosti");
            });

            modelBuilder.Entity<Novosti>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DatumObjave).HasColumnType("datetime");

                entity.Property(e => e.KorisnikId).HasColumnName("KorisnikID");

                entity.Property(e => e.Naslov)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Sadrzaj)
                    .IsRequired()
                    .HasColumnType("text");

                entity.HasOne(d => d.Korisnik)
                    .WithMany(p => p.Novosti)
                    .HasForeignKey(d => d.KorisnikId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Novosti_Korisnici");
            });

            modelBuilder.Entity<Ocjena>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Komentar).HasColumnType("text");

                entity.Property(e => e.KompanijaId).HasColumnName("KompanijaID");

                entity.Property(e => e.PutnikId).HasColumnName("PutnikID");

                entity.HasOne(d => d.Kompanija)
                    .WithMany(p => p.Ocjena)
                    .HasForeignKey(d => d.KompanijaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ocjena_Kompanija");

                entity.HasOne(d => d.Putnik)
                    .WithMany(p => p.Ocjena)
                    .HasForeignKey(d => d.PutnikId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ocjena_Putnik");
            });

            modelBuilder.Entity<Putnik>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DatumRegistracije).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.Ime)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.KorisnickoIme)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LozinkaHash).IsRequired();

                entity.Property(e => e.LozinkaSalt).IsRequired();

                entity.Property(e => e.Prezime)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<PutnikNotifikacije>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.NotifikacijaId).HasColumnName("NotifikacijaID");

                entity.Property(e => e.PutnikId).HasColumnName("PutnikID");

                entity.HasOne(d => d.Notifikacija)
                    .WithMany(p => p.PutnikNotifikacije)
                    .HasForeignKey(d => d.NotifikacijaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PutnikNotifikacija_notif");

                entity.HasOne(d => d.Putnik)
                    .WithMany(p => p.PutnikNotifikacije)
                    .HasForeignKey(d => d.PutnikId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PutnikNOtifikaicja_putnik");
            });

            modelBuilder.Entity<Rezervacija>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DatumIsteka).HasColumnType("datetime");

                entity.Property(e => e.DatumKreiranja).HasColumnType("datetime");

                entity.Property(e => e.KartaId).HasColumnName("KartaID");

                entity.Property(e => e.PutnikId).HasColumnName("PutnikID");

                entity.Property(e => e.Qrcode)
                    .IsRequired()
                    .HasColumnName("QRcode");

                entity.HasOne(d => d.Karta)
                    .WithMany(p => p.Rezervacija)
                    .HasForeignKey(d => d.KartaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Rezervacija_Karta");

                entity.HasOne(d => d.Putnik)
                    .WithMany(p => p.Rezervacija)
                    .HasForeignKey(d => d.PutnikId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Rezervacija_Putnik");
            });

            modelBuilder.Entity<Sjediste>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.VoziloId).HasColumnName("VoziloID");

                entity.HasOne(d => d.Vozilo)
                    .WithMany(p => p.Sjediste)
                    .HasForeignKey(d => d.VoziloId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sjediste_Vozilo");
            });

            modelBuilder.Entity<Uloga>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Vozilo>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.KompanijaId).HasColumnName("KompanijaID");

                entity.Property(e => e.Model)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Proizvodjac)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Registracija)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.HasOne(d => d.Kompanija)
                    .WithMany(p => p.Vozilo)
                    .HasForeignKey(d => d.KompanijaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Vozilo_Kompanija");
            });

            
            
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
