using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.ComponentModel;

namespace SGComum.Database.Models
{
    public class MesaReserva
    {
        [DisplayName("Código")]
        [Browsable(false)]
        public int Controle { get; set; }

        [DisplayName("Data hora cadastro")]
        [Browsable(false)]
        public DateTime DataHoraCadastro { get; set; }

        //[DisplayName("Cód. cliente")]
        //[Browsable(false)]
        //public Cliente Cliente { get; set; }

        [DisplayName("Número mesa")]
        [Browsable(false)]
        public int NumeroMesa { get; set; }

        [DisplayName("Cód. comanda")]
        [Browsable(false)]
        public int CodComanda { get; set; }

        [DisplayName("Ocupantes")]
        [Browsable(false)]
        public int Ocupantes { get; set; }

        [DisplayName("Data reserva")]
        [Browsable(false)]
        public DateTime DataReserva { get; set; }

        [DisplayName("Hora reserva")]
        [Browsable(false)]
        public DateTime HoraReserva { get; set; }

        [DisplayName("Hora máxima chegada")]
        [Browsable(false)]
        public DateTime HoraMaximaChegada { get; set; }

        [DisplayName("Hora inicial reserva")]
        [Browsable(false)]
        public DateTime HoraInicialReserva { get; set; }

        [DisplayName("Hora previsão chegada")]
        [Browsable(false)]
        public DateTime HoraPrevisaoChegada { get; set; }

        [DisplayName("Cód. aprovação")]
        [Browsable(false)]
        public DateTime CodAprovacao { get; set; }

        [Browsable(false)]
        public Comanda Comanda { get; set; }
    }

    public class MesaReservaEntityTypeConfiguration : IEntityTypeConfiguration<MesaReserva>
    {
        public void Configure(EntityTypeBuilder<MesaReserva> builder)
        {
            builder.ToTable("TMESARESERVA");

            builder.HasKey(e => e.Controle);
            builder.Property(c => c.Controle).HasColumnName("CONTROLE").IsRequired();

            builder.Property(c => c.DataHoraCadastro).HasColumnName("DATAHORACADASTRO");

            //builder.HasOne(c => c.Cliente).WithMany(c => c.MesaReserva).HasForeignKey(c => c.Controle);

            builder.Property(c => c.NumeroMesa).HasColumnName("NUMEROMESA").IsRequired();

            builder.Property(c => c.CodComanda).HasColumnName("CODCOMANDA");

            builder.Property(c => c.Ocupantes).HasColumnName("OCUPANTES").IsRequired(); 

            builder.Property(c => c.DataReserva).HasColumnName("DATARESERVA").IsRequired();

            builder.Property(c => c.HoraReserva).HasColumnName("HORARESERVA").IsRequired();

            builder.Property(c => c.HoraMaximaChegada).HasColumnName("HORAMAXIMACHEGADA").IsRequired();

            builder.Property(c => c.HoraInicialReserva).HasColumnName("HORAINICIALRESERVA").IsRequired();

            builder.Property(c => c.HoraPrevisaoChegada).HasColumnName("HORAPREVISAOCHEGADA").IsRequired();

            builder.Property(c => c.CodAprovacao).HasColumnName("CODAPROVACAO");
        }
    }
}
