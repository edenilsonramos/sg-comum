using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.ComponentModel;

namespace SGComum.Database.Models
{
    public class ItemComandaAdicional
    {
        public int Controle { get; set; }

        [Browsable(false)]
        public int? CodItemComanda { get; set; }

        [Browsable(false)]
        public int? CodComanda { get; set; }

        [Browsable(false)]
        public int? CodProduto { get; set; }

        [DisplayName("Produto")]
        public string Produto { get; set; }

        [DisplayName("Adicional")]
        public string Adicional { get; set; }

        [Browsable(false)]
        public decimal? Valor { get; set; }

        [Browsable(false)]
        public decimal? QTDE { get; set; }

        [Browsable(false)]
        public DateTime DataHoraCadastro { get; set; }

        [Browsable(false)]
        public int? CodAdicional { get; set; }

        [Browsable(false)]
        public int? ControleBaseMobile { get; set; }

        [Browsable(false)]
        public string IMEIMobile { get; set; }

        [Browsable(false)]
        public int? TipoAdicional { get; set; }

        public virtual ItemComanda ItemComanda { get; set; }
    }
    public class ItemComandaAdicionalEntityTypeConfiguration : IEntityTypeConfiguration<ItemComandaAdicional>
    {
        public void Configure(EntityTypeBuilder<ItemComandaAdicional> builder)
        {
            builder.ToTable("TITEMCOMANDAADICIONAL");

            builder.HasKey(e => e.Controle);
            builder.Property(e => e.Controle).HasColumnName("CONTROLE").IsRequired();

            builder.Property(e => e.CodItemComanda).HasColumnName("CODITEMCOMANDA");

            builder.Property(e => e.CodComanda).HasColumnName("CODCOMANDA");

            builder.Property(e => e.CodProduto).HasColumnName("CODPRODUTO");

            builder.Property(e => e.Produto).HasColumnName("PRODUTO").HasMaxLength(100);

            builder.Property(e => e.Valor).HasColumnName("VALOR");

            builder.Property(e => e.QTDE).HasColumnName("QTDE");

            builder.Property(e => e.DataHoraCadastro).HasColumnName("DATAEHORACADASTRO").IsRequired();
            
            builder.Property(e => e.Adicional).HasColumnName("ADICIONAL").HasMaxLength(100);

            builder.Property(e => e.CodAdicional).HasColumnName("CODADICIONAL");

            builder.Property(e => e.ControleBaseMobile).HasColumnName("CONTROLEBASEMOBILE");

            builder.Property(e => e.IMEIMobile).HasColumnName("IMEIMOBILE").HasMaxLength(15);

            builder.Property(e => e.TipoAdicional).HasColumnName("TIPOADICIONAL");
        }
    }
}