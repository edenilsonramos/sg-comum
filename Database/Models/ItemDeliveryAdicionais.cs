using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel;

namespace SGComum.Database.Models
{
    public class ItemDeliveryAdicionais
    {
        [Browsable(false)]
        public int Controle { get; set; }

        [Browsable(false)]
        public int CodItemPedidoIfood { get; set; }

        [Browsable(false)]
        public int CodItemPedidoAmo { get; set; }

        [Browsable(false)]
        public string Descricao { get; set; }

        [Browsable(false)]
        public decimal? QTDE { get; set; }

        [Browsable(false)]
        public decimal? ValorUnitario { get; set; }

        [Browsable(false)]
        public decimal? ValorAcrescimo { get; set; }

        [Browsable(false)]
        public decimal? ValorLiquido { get; set; }

        [Browsable(false)]
        public virtual ItemPedidoAmo ItemPedidoAmo { get; set; }
    }

    public class ItemDeliveryAdicionaisEntityTypeConfiguration : IEntityTypeConfiguration<ItemDeliveryAdicionais>
    {
        public void Configure(EntityTypeBuilder<ItemDeliveryAdicionais> builder)
        {
            builder.ToTable("TITEMDELIVERYADICIONAIS");

            builder.HasKey(e => e.Controle);

            builder.Property(e => e.Controle).HasColumnName("CONTROLE").IsRequired();

            builder.Property(e => e.CodItemPedidoIfood).HasColumnName("CODITEMPEDIDOIFOOD");

            builder.Property(e => e.CodItemPedidoAmo).HasColumnName("CODITEMPEDIDOAMO");

            builder.Property(e => e.Descricao).HasColumnName("DESCRICAO").HasMaxLength(50);
            
            builder.Property(e => e.QTDE).HasColumnName("QTDE");

            builder.Property(e => e.ValorUnitario).HasColumnName("VALORUNITARIO");

            builder.Property(e => e.ValorAcrescimo).HasColumnName("VALORACRESCIMO");

            builder.Property(e => e.ValorLiquido).HasColumnName("VALORLIQUIDO");

        }
    }
}
