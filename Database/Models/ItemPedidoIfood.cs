using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel;

namespace SGComum.Database.Models
{
    public class ItemPedidoIfood
    {
        [Browsable(false)]
        public int Controle { get; set; }
        
        [Browsable(false)]
        public int? CodPedido { get; set; }

        [Browsable(false)]
        public int? CodProduto { get; set; }

        [Browsable(false)]
        public string Codbarras { get; set; }

        [Browsable(false)]
        public decimal? QTDE { get; set; }

        [Browsable(false)]
        public string UN { get; set; }

        [Browsable(false)]
        public decimal? ValorUnitario { get; set; }

        [Browsable(false)]
        public decimal? ValorAdicional { get; set; }

        [Browsable(false)]
        public decimal? ValorTotal { get; set; }

        [Browsable(false)]
        public decimal? ValorComplemento { get; set; }

        [Browsable(false)]
        public decimal? ValorLiquido { get; set; }

        [Browsable(false)]
        public string OBS { get; set; }

        [Browsable(false)]
        public string IDProduto { get; set; }
        
        [Browsable(false)]
        public string Produto { get; set; }

        [Browsable(false)]
        public virtual PedidoIfood PedidoIfood { get; set; }
    }
    public class ItemPedidoIfoodEntityTypeConfiguration : IEntityTypeConfiguration<ItemPedidoIfood>
    {
        public void Configure(EntityTypeBuilder<ItemPedidoIfood> builder)
        {
            builder.ToTable("TITEMPEDIDOIFOOD");

            builder.HasKey(e => e.Controle);
            builder.Property(e => e.Controle).HasColumnName("CONTROLE").IsRequired();

            builder.Property(e => e.CodPedido).HasColumnName("CODPEDIDO");

            builder.Property(e => e.CodProduto).HasColumnName("CODPRODUTO");

            builder.Property(e => e.Codbarras).HasColumnName("CODBARRAS").HasMaxLength(15);

            builder.Property(e => e.QTDE).HasColumnName("QTDE");

            builder.Property(e => e.UN).HasColumnName("UN");

            builder.Property(e => e.ValorUnitario).HasColumnName("VALORUNITARIO");

            builder.Property(e => e.ValorAdicional).HasColumnName("VALORADICIONAL");

            builder.Property(e => e.ValorTotal).HasColumnName("VALORTOTAL");

            builder.Property(e => e.ValorComplemento).HasColumnName("VALORCOMPLEMENTO");

            builder.Property(e => e.ValorLiquido).HasColumnName("VALORLIQUIDO");

            builder.Property(e => e.OBS).HasColumnName("OBS");

            builder.Property(e => e.IDProduto).HasColumnName("IDPRODUTO").HasMaxLength(50);

            builder.Property(e => e.Produto).HasColumnName("PRODUTO").HasMaxLength(150);
        }
    }
}
