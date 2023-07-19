using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGComum.Core;
using System;
using System.ComponentModel;

namespace SGComum.Database.Models
{
    public class FormaPagamentoComanda
    {
        [DisplayName("Controle")]
        [Browsable(false)]
        public int Controle { get; set; }

        [DisplayName("Cód. Espécie")]
        [Browsable(false)]
        public int? CodEspecie { get; set; }

        [DisplayName("Espécie")]
        public string Especie { get; set; }

        [DisplayName("Cód. Plano conta")]
        [Browsable(false)]
        public int? CodPlanoConta { get; set; }

        [DisplayName("Plano conta")]
        [Browsable(false)]
        public string PlanoConta { get; set; }

        [DisplayName("Cód. Comanda")]
        [Browsable(false)]
        public int? CodComanda { get; set; }

        [DisplayName("Tipo lançamento financeiro")]
        [Browsable(false)]
        public string TipoLancamentoFinanceiro { get; set; }

        [DisplayName("Tipo cartão")]
        [Browsable(false)]
        public string TipoCartao { get; set; }

        [DisplayName("Tipo associação")]
        [Browsable(false)]
        public string TipoAssociacao { get; set; }

        [DisplayName("Valor troco")]
        [Browsable(false)]
        public decimal? ValorTroco { get; set; }

        [DisplayName("Data lançamento")]
        [Browsable(false)]
        public DateTime? DataLancamento { get; set; }

        [DisplayName("Valor pago")]
        public string ValorPagoVarchar { get; set; }

        [DisplayName("Valor pago")]
        [Browsable(false)]
        public decimal? ValorPago { get; set; }

        [Browsable(false)]
        public bool? Pago { get; set; }

        [DisplayName("Cód. Divisão")]
        [Browsable(false)]
        public int? CodDivisao { get; set; }

        [Browsable(false)]
        public Comanda Comanda { get; set; }

    }
    public class FormaPagamentoComandaEntityTypeConfiguration : IEntityTypeConfiguration<FormaPagamentoComanda>
    {
        public void Configure(EntityTypeBuilder<FormaPagamentoComanda> builder)
        {
            builder.ToTable("TFORMAPAGAMENTOCOMANDA");

            builder.HasKey(e => e.Controle);

            builder.Property(e => e.Controle).HasColumnName("CONTROLE").IsRequired();

            builder.Property(e => e.CodEspecie).HasColumnName("CODESPECIE");

            builder.Property(e => e.Especie).HasColumnName("ESPECIE").HasMaxLength(100);

            builder.Property(e => e.CodPlanoConta).HasColumnName("CODPLANOCONTA").HasMaxLength(100);

            builder.Property(e => e.PlanoConta).HasColumnName("PLANOCONTA").HasMaxLength(100);

            builder.Property(e => e.CodComanda).HasColumnName("CODCOMANDA");

            builder.Property(e => e.TipoLancamentoFinanceiro).HasColumnName("TIPOLANCAMENTOFINANCEIRO").HasMaxLength(25);

            builder.Property(e => e.TipoCartao).HasColumnName("TIPOCARTAO").HasMaxLength(25);

            builder.Property(e => e.TipoAssociacao).HasColumnName("TIPOASSOCIACAO").HasMaxLength(30);

            builder.Property(e => e.ValorTroco).HasColumnName("VALORTROCO");

            builder.Property(e => e.DataLancamento).HasColumnName("DATALANCAMENTO");

            builder.Property(e => e.ValorPagoVarchar).HasColumnName("VALORPAGOVARCHAR").HasMaxLength(25);

            builder.Property(e => e.ValorPago).HasColumnName("VALORPAGO");

            builder.Property(e => e.Pago).HasColumnName("PAGO").HasDefaultValue().HasConversion<string>(
                v => DataTypes.BoolToZeroUmNull(v),
                v => DataTypes.ZeroUmNullToBool(v)
            );

            builder.Property(e => e.CodDivisao).HasColumnName("CODDIVISAO");
        }
    }

}
