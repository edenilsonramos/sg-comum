using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.ComponentModel;

namespace SGComum.Database.Models
{
    public class PedidoStatusAmo
    {
        [Browsable(false)]
        public int Controle { get; set; }

        [Browsable(false)]
        public int CodPedido { get; set; }

        [Browsable(false)]
        public DateTime DataHoraCadastro { get; set; }

        [Browsable(false)]
        public DateTime? DataHoraConfirmado { get; set; }

        [Browsable(false)]
        public DateTime? DataHoraDespachado { get; set; }

        [Browsable(false)]
        public DateTime? DataHoraCancelado { get; set; }

        [Browsable(false)]
        public DateTime? DataHoraConcluido { get; set; }

        [Browsable(false)]
        public PedidoAmo PedidoAmo { get; set; }
    }

    public class PedidoStatusAmoEntityTypeConfiguration : IEntityTypeConfiguration<PedidoStatusAmo>
    {
        public void Configure(EntityTypeBuilder<PedidoStatusAmo> builder)
        {
            builder.ToTable("TPEDIDOSTATUSAMO");

            builder.HasKey(e => e.Controle);
            builder.Property(e => e.Controle).HasColumnName("CONTROLE").IsRequired();

            builder.Property(e => e.CodPedido).HasColumnName("CODPEDIDO").IsRequired();

            builder.Property(e => e.DataHoraCadastro).HasColumnName("DATAHORACADASTRO").IsRequired();

            builder.Property(e => e.DataHoraConfirmado).HasColumnName("DATAHORACONFIRMADO");

            builder.Property(e => e.DataHoraDespachado).HasColumnName("DATAHORADESPACHADO");

            builder.Property(e => e.DataHoraCancelado).HasColumnName("DATAHORACANCELADO");

            builder.Property(e => e.DataHoraConcluido).HasColumnName("DATAHORACONCLUIDO");
        }
    }
}