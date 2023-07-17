using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGComum.Core;
using System.ComponentModel;

namespace SGComum.Database.Models
{
    public class PagamentoAmo
    {
        [Browsable(false)]
        public int Controle { get; set; }

        [Browsable(false)]
        public int CodPedido { get; set; }

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
        public int? CodEspecie { get; set; }
        
        [Browsable(false)]
        public virtual PedidoAmo PedidoAmo { get; set; }
    }
    public class PagamentoAmoEntityTypeConfiguration : IEntityTypeConfiguration<PagamentoAmo>
    {
        public void Configure(EntityTypeBuilder<PagamentoAmo> builder)
        {
            builder.ToTable("TPAGAMENTOAMO");

            builder.HasKey(e => e.Controle);
            builder.Property(e => e.Controle).HasColumnName("CONTROLE").IsRequired();

            builder.Property(e => e.CodPedido).HasColumnName("CODPEDIDO").IsRequired();

            builder.Property(e => e.BandeiraDoCartao).HasColumnName("BANDEIRADOCARTAO").HasMaxLength(50);

            builder.Property(e => e.Troco).HasColumnName("TROCO");

            builder.Property(e => e.Especie).HasColumnName("ESPECIE").HasMaxLength(50);

            builder.Property(e => e.Pago).HasColumnName("PAGO").HasConversion<string>(
            v => DataTypes.BoolToZeroUmNull(v),
            v => DataTypes.ZeroUmNullToBool(v)
            );

            builder.Property(e => e.Valor).HasColumnName("VALOR");

            builder.Property(e => e.CodEspecie).HasColumnName("CODESPECIE");
        }
    }
}