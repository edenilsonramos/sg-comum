using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGComum.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SGComum.Database.Models
{
    public class ComandaAprovar
    {
        [DisplayName("Código")]
        public int Controle { get; set; }

        [DisplayName("Número mesa")]
        public int NumeroMesa { get; set; }

        [DisplayName("Cód. cliente")]
        public int CodCliente { get; set; }

        [DisplayName("Data hora cadastro")]
        public DateTime DataHoraCadastro { get; set; }

        [DisplayName("Tipo frete")]
        public string TipoFrete { get; set; }

        [DisplayName("Cód. endereço")]
        public int? CodEndereco { get; set; }

        [DisplayName("Valor frete")]
        public decimal? ValorFrete { get; set; }

        [DisplayName("Cód. comanda")]
        public int? CodComanda { get; set; }

        [DisplayName("Tipo pagamento")]
        public string TipoPagamento { get; set; }

        [DisplayName("Valor pago")]
        public decimal? ValorPago { get; set; }

        [DisplayName("Bandeira cartão")]
        public string BandeiraCartao { get; set; }

        [DisplayName("Parcelas")]
        public int? Parcelas { get; set; }

        [DisplayName("Primeiro vencimento")]
        public DateTime? PrimeiroVencimento { get; set; }

        [DisplayName("Cancelado")]
        public string GridCancelado
        {
            get
            {
                return DataTypes.BoolToSimNaoNull(Cancelado);
            }
        }

        [Browsable(false)]
        public bool? Cancelado { get; set; } = false;

        [DisplayName("DF-e enviado site")]
        public string GridDFeEnviadoSite
        {
            get
            {
                return DataTypes.BoolToSimNaoNull(DFeEnviadoSite);
            }
        }

        [Browsable(false)]
        public bool? DFeEnviadoSite { get; set; }

        [DisplayName("Disponível retirada")]
        public string GridDisponivelRetirada
        {
            get
            {
                return DataTypes.BoolToSimNaoNull(DisponivelRetirada);
            }
        }

        [Browsable(false)]
        public bool? DisponivelRetirada { get; set; }

        [DisplayName("Valor desconto")]
        public decimal? ValorDesconto { get; set; }

        [DisplayName("Cód. comanda MeuSG")]
        public int? CodComandaMeuSG { get; set; }

        [DisplayName("Data hora agendamento")]
        public DateTime? DataHoraAgendamento { get; set; }

        [Browsable(false)]
        public virtual Comanda Comanda { get; set; }

        [Browsable(false)]
        public ICollection<ItemComandaAprovar> Itens { get; set; }
    }

    public class ComandaAprovarEntityTypeConfiguration: IEntityTypeConfiguration<ComandaAprovar>
    {
        public void Configure(EntityTypeBuilder<ComandaAprovar> builder)
        {
            builder.ToTable("TCOMANDAAPROVAR");

            builder.HasKey(c => c.Controle);
            builder.Property(c => c.Controle).HasColumnName("CONTROLE").IsRequired();

            builder.Property(c => c.NumeroMesa).HasColumnName("NUMEROMESA").IsRequired();

            builder.Property(c => c.CodCliente).HasColumnName("CODCLIENTE").IsRequired();

            builder.Property(c => c.DataHoraCadastro).HasColumnName("DATAHORACADASTRO").HasDefaultValue().IsRequired();

            builder.Property(c => c.TipoFrete).HasColumnName("TIPOFRETE").HasMaxLength(1).IsRequired();

            builder.Property(c => c.CodEndereco).HasColumnName("CODENDERECO");

            builder.Property(c => c.ValorFrete).HasColumnName("VALORFRETE");

            builder.Property(c => c.CodComanda).HasColumnName("CODCOMANDA");

            builder.Property(c => c.TipoPagamento).HasColumnName("TIPOPAGAMENTO").HasMaxLength(1);

            builder.Property(c => c.ValorPago).HasColumnName("VALORPAGO");

            builder.Property(c => c.BandeiraCartao).HasColumnName("BANDEIRACARTAO").HasMaxLength(50);

            builder.Property(c => c.Parcelas).HasColumnName("PARCELAS");

            builder.Property(c => c.PrimeiroVencimento).HasColumnName("PRIMEIROVENCIMENTO");

            builder.Property(c => c.Cancelado).HasColumnName("CANCELADO").HasDefaultValue().HasConversion<string>(
                v => DataTypes.BoolToZeroUmNull(v),
                v => DataTypes.ZeroUmNullToBool(v)
            );

            builder.Property(c => c.DFeEnviadoSite).HasColumnName("DFEENVIADOSITE").HasConversion<string>(
                v => DataTypes.BoolToZeroUmNull(v),
                v => DataTypes.ZeroUmNullToBool(v)
            );

            builder.Property(c => c.DisponivelRetirada).HasColumnName("DISPONIVELRETIRADA").HasConversion<string>(
                v => DataTypes.BoolToZeroUmNull(v),
                v => DataTypes.ZeroUmNullToBool(v)
            );

            builder.Property(c => c.ValorDesconto).HasColumnName("VALORDESCONTO");

            builder.Property(c => c.CodComandaMeuSG).HasColumnName("CODCOMANDAMEUSG");

            builder.Property(c => c.DataHoraAgendamento).HasColumnName("DATAHORAAGENDAMENTO");

            builder.HasMany(c => c.Itens).WithOne(i => i.ComandaAprovar).HasForeignKey(i => i.CodComandaAprovar).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
