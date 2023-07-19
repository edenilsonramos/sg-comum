using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace SGComum.Database.Models
{
    public class ItemComandaAprovar
    {
        [DisplayName("Checado")]
        [NotMapped]
        public virtual bool GridChecado
        {
            get => Checado != null ? (bool)Checado : false;
            set => Checado = value;
        }

        [Browsable(false)]
        [NotMapped]
        public bool Checado { get; set; }

        [Browsable(false)]
        public int Controle { get; set; }

        [Browsable(false)]
        public int CodComandaAprovar { get; set; }

        [DisplayName("Cód. produto")]
        public int CodProduto { get; set; }

        [DisplayName("Data hora cadastro")]
        public DateTime DataHoraCadastro { get; set; }

        [DisplayName("Valor unitário")]
        public decimal? ValorUnitario { get; set; }

        [DisplayName("Qtde")]
        public decimal? QTDE { get; set; }

        [DisplayName("Total desconto")]
        public decimal? TotalDesconto { get; set; }

        [DisplayName("Total acréscimo")]
        public decimal? TotalAcrescimo { get; set; }

        [Browsable(false)]
        public int? CodItemComanda { get; set; }

        [Browsable(false)]
        public string OBSItem { get; set; }

        [Browsable(false)]
        public int? CodItemMeuSG { get; set; }

        [Browsable(false)]
        public string Tipo { get; set; }

        public ComandaAprovar ComandaAprovar { get; set; }


        [Browsable(false)]
        public ItemComanda ItemComanda { get; set; }

    }

    public class ItemComandaAprovarEntityTypeConfiguration : IEntityTypeConfiguration<ItemComandaAprovar>
    {
        public void Configure(EntityTypeBuilder<ItemComandaAprovar> builder)
        {
            builder.ToTable("TITEMCOMANDAAPROVAR");

            builder.HasKey(c => c.Controle);

            builder.Property(c => c.Controle).HasColumnName("CONTROLE").IsRequired();

            builder.Property(c => c.CodComandaAprovar).HasColumnName("CODCOMANDAAPROVAR");

            builder.Property(c => c.CodProduto).HasColumnName("CODPRODUTO");

            builder.Property(c => c.DataHoraCadastro).HasColumnName("DATAHORACADASTRO");

            builder.Property(c => c.QTDE).HasColumnName("QTDE");

            builder.Property(c => c.ValorUnitario).HasColumnName("VALORUNITARIO");

            builder.Property(c => c.TotalDesconto).HasColumnName("TOTALDESCONTO");

            builder.Property(c => c.TotalAcrescimo).HasColumnName("TOTALACRESCIMO");

            builder.Property(c => c.CodItemComanda).HasColumnName("CODITEMCOMANDA");

            builder.Property(c => c.OBSItem).HasColumnName("OBSITEM");

            builder.Property(c => c.CodItemMeuSG).HasColumnName("CODITEMMEUSG");

            builder.Property(c => c.Tipo).HasColumnName("TIPO").HasMaxLength(3);
        }
    }
}
