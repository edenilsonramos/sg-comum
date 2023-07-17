using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel;

namespace SGComum.Database.Models
{
    public class ItemPedidoAmo
    {
        [Browsable(false)]
        public int Controle { get; set; }

        [Browsable(false)]
        public int? CodPedido { get; set; }

        [Browsable(false)]
        public int? CodProduto { get; set; }

        [Browsable(false)]
        public string Referencia { get; set; }
        
        [Browsable(false)]
        public string Produto { get; set; }

        [Browsable(false)]
        public decimal? QTDE { get; set; }

        [Browsable(false)]
        public string UN { get; set; }

        [Browsable(false)]
        public decimal? ValorUnitario { get; set; }

        [Browsable(false)]
        public decimal? valorDesconto { get; set; }

        [Browsable(false)]
        public decimal? ValorLiquido { get; set; }

        [Browsable(false)]
        public decimal? ValorTotal { get; set; }

        [Browsable(false)]
        public decimal? ValorAdicional { get; set; }

        [Browsable(false)]
        public string OBS { get; set; }

        [Browsable(false)]
        public string Descricao { get; set; }

        [Browsable(false)]
        public string IDProduto { get; set; }
        
        [Browsable(false)]
        public virtual PedidoAmo PedidoAmo { get; set; }
    }
    public class ItemPedidoAmoEntityTypeConfiguration : IEntityTypeConfiguration<ItemPedidoAmo>
    {
        public void Configure(EntityTypeBuilder<ItemPedidoAmo> builder)
        {
            builder.ToTable("TITEMPEDIDOAMO");

            builder.HasKey(e => e.Controle);
            builder.Property(e => e.Controle).HasColumnName("CONTROLE").IsRequired();

            builder.Property(e => e.CodPedido).HasColumnName("CODPEDIDO");

            builder.Property(e => e.CodProduto).HasColumnName("CODPRODUTO");

            builder.Property(e => e.Referencia).HasColumnName("REFERENCIA").HasMaxLength(100);

            builder.Property(e => e.Produto).HasColumnName("PRODUTO").HasMaxLength(100);

            builder.Property(e => e.QTDE).HasColumnName("QTDE");

            builder.Property(e => e.UN).HasColumnName("UN");

            builder.Property(e => e.ValorUnitario).HasColumnName("VALORUNITARIO");

            builder.Property(e => e.valorDesconto).HasColumnName("VALORDESCONTO");

            builder.Property(e => e.ValorLiquido).HasColumnName("VALORLIQUIDO");

            builder.Property(e => e.ValorTotal).HasColumnName("VALORTOTAL");

            builder.Property(e => e.ValorAdicional).HasColumnName("VALORADICIONAL");

            builder.Property(e => e.OBS).HasColumnName("OBS");

            builder.Property(e => e.Descricao).HasColumnName("DESCRICAO").HasMaxLength(50);

            builder.Property(e => e.IDProduto).HasColumnName("IDPRODUTO");
        }
    }
}
