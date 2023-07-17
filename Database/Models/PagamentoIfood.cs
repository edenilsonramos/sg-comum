using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel;

namespace SGComum.Database.Models
{
    public class PagamentoIfood
    {
        [Browsable(false)]
        public int Controle { get; set; }

        [Browsable(false)]
        public int CodPedidoIfood { get; set; }

        [Browsable(false)]
        public string BandeiraDoCartao { get; set; }

        [Browsable(false)]
        public decimal? Troco { get; set; }

        [Browsable(false)]
        public string Especie { get; set; }

        [Browsable(false)]
        public bool? Pago { get; set; }

        [Browsable(false)]
        public decimal? Valor { get; set; }

        [Browsable(false)]
        public virtual PedidoIfood PedidoIfood { get; set; }
    }
    public class PagamentoIfoodEntityTypeConfiguration : IEntityTypeConfiguration<PagamentoIfood>
    {
        public void Configure(EntityTypeBuilder<PagamentoIfood> builder)
        {
            builder.ToTable("TPAGAMENTOIFOOD");

            builder.HasKey(e => e.Controle);
            builder.Property(e => e.Controle).HasColumnName("CONTROLE").IsRequired();

            builder.Property(e => e.CodPedidoIfood).HasColumnName("CODPEDIDOIFOOD").IsRequired();

            builder.Property(e => e.BandeiraDoCartao).HasColumnName("BANDEIRADOCARTAO").HasMaxLength(50);

            builder.Property(e => e.Troco).HasColumnName("TROCO");

            builder.Property(e => e.Especie).HasColumnName("ESPECIE").HasMaxLength(50);

            builder.Property(e => e.Pago).HasColumnName("PAGO").HasConversion<string>(
            v => DataTypes.BoolToZeroUmNull(v),
            v => DataTypes.ZeroUmNullToBool(v)
            );

            builder.Property(e => e.Valor).HasColumnName("VALOR");
        }
    }
}