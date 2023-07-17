using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGComum.Core;
using System.ComponentModel;

namespace SGComum.Database.Models
{
    public class ConfigAmo
    {
        [DisplayName("Controle")]
        public int Controle { get; set; }

        [DisplayName("ID estabelecimento")]
        public string IDEstabelecimento { get; set; }

        [Browsable(false)]
        public string Token { get; set; }

        [Browsable(false)]
        public int? EmiteAoConfirmar { get; set; }

        [DisplayName("Aprovar delivery")]
        public string GridAprovarDelivery { get { return DataTypes.BoolToSimNaoNull(AprovarDelivery); } }
        
        [Browsable(false)]
        public bool? AprovarDelivery { get; set; }

        [DisplayName("Aprovar local")]
        public string GridAprovarLocal { get { return DataTypes.BoolToSimNaoNull(AprovarLocal); } }

        [Browsable(false)]
        public bool? AprovarLocal { get; set; }

        [DisplayName("Aprovar retirada")]
        public string GridAprovarRetirada { get { return DataTypes.BoolToSimNaoNull(AprovarRetirada); } }

        [Browsable(false)]
        public bool? AprovarRetirada { get; set; }

    }

    public class ConfigAmoEntityTypeConfiguration : IEntityTypeConfiguration<ConfigAmo>
    {
        public void Configure(EntityTypeBuilder<ConfigAmo> builder)
        {
            builder.ToTable("TCONFIGAMO");

            builder.HasKey(e => e.Controle);

            builder.Property(e => e.Controle).HasColumnName("CONTROLE").IsRequired();

            builder.Property(e => e.IDEstabelecimento).HasColumnName("IDESTABELECIMENTO").HasMaxLength(200);

            builder.Property(e => e.Token).HasColumnName("TOKEN");

            builder.Property(e => e.EmiteAoConfirmar).HasColumnName("EMITEAOCONFIRMAR");

            builder.Property(e => e.AprovarDelivery).HasColumnName("APROVARDELIVERY").HasDefaultValue().HasConversion<string>(
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
