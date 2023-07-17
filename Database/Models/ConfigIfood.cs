using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGComum.Core;
using System.ComponentModel;

namespace SGComum.Database.Models
{
    public class ConfigIfood
    {
        public int Controle { get; set; }

        public string CodAutorizacao { get; set; }

        [Browsable(false)]
        public string CodVeriAutorizacao { get; set; }

        public string IdLoja { get; set; }

        [Browsable(false)]
        public string TokeDeAcesso { get; set; }

        [Browsable(false)]
        public string TokenDeAutorizacao { get; set; }

        public int? EmiteAoConfirmar { get; set; }

        public bool? AprovaDelivery { get; set; }

        public bool? AprovarLocal { get; set; }

        public bool? AprovarRetirada { get; set; }
    }
    public class ConfigIfoodEntityTypeConfiguration : IEntityTypeConfiguration<ConfigIfood>
    {
        public void Configure(EntityTypeBuilder<ConfigIfood> builder)
        {
            builder.ToTable("TCONFIGIFOOD");

            builder.HasKey(e => e.Controle);

            builder.Property(e => e.Controle).HasColumnName("CONTROLE").IsRequired();

            builder.Property(e => e.CodAutorizacao).HasColumnName("CODAUTORIZACAO").HasMaxLength(15);

            builder.Property(e => e.CodVeriAutorizacao).HasColumnName("CODVERIAUTORIZACAO");

            builder.Property(e => e.IdLoja).HasColumnName("IDLOJA").HasMaxLength(200);

            builder.Property(e => e.TokeDeAcesso).HasColumnName("TOKENDEACESSO");

            builder.Property(e => e.TokenDeAutorizacao).HasColumnName("TOKENDEATUALIZACAO");

            builder.Property(e => e.EmiteAoConfirmar).HasColumnName("EMITEAOCONFIRMAR");

            builder.Property(e => e.AprovaDelivery).HasColumnName("APROVARDELIVERY").HasDefaultValue().HasConversion<string>(
                v => DataTypes.BoolToZeroUmNull(v),
                v => DataTypes.ZeroUmNullToBool(v)
            );

            builder.Property(e => e.AprovarLocal).HasColumnName("APROVARLOCAL").HasDefaultValue().HasConversion<string>(
                v => DataTypes.BoolToZeroUmNull(v),
                v => DataTypes.ZeroUmNullToBool(v)
            );

            builder.Property(e => e.AprovarRetirada).HasColumnName("APROVARRETIRADA").HasDefaultValue().HasConversion<string>(
                v => DataTypes.BoolToZeroUmNull(v),
                v => DataTypes.ZeroUmNullToBool(v)
            );
        }
    }
}
