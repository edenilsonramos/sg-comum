using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGComum.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using static SGComum.Core.DataTypes;

namespace SGComum.Database.Models
{
    public class PedidoIfood
    {
        [Browsable(false)]
        public int Controle { get; set; }

        [Browsable(false)]
        public string IdPedido { get; set; }

        [Browsable(false)]
        public string IdResumo { get; set; }

        [Browsable(false)]
        public string Mesa { get; set; }

        [Browsable(false)]
        public TipoPedidoDelivery TipoPedido { get; set; }

        [Browsable(false)]
        public string EntregaAgendada { get; set; }

        [Browsable(false)]
        public DateTime DataHoraCadastro { get; set; }

        [Browsable(false)]
        public string IdCliente { get; set; }

        [Browsable(false)]
        public string NomeCliente { get; set; }

        [Browsable(false)]
        public string CNPJCPF { get; set; }

        [Browsable(false)]
        public string Telefone { get; set; }

        [Browsable(false)]
        public string OBS { get; set; }

        [Browsable(false)]
        public decimal? ValorTotal { get; set; }

        [Browsable(false)]
        public decimal? ValorTaxaEntrega { get; set; }

        [Browsable(false)]
        public decimal? ValorLiquido { get; set; }

        [Browsable(false)]
        public decimal? ValorAdicional { get; set; }

        [Browsable(false)]
        public decimal? ValorTotalCupom { get; set; }

        [Browsable(false)]
        public decimal? ValorPago { get; set; }

        [Browsable(false)]
        public decimal? ValorAPagar { get; set; }

        [Browsable(false)]
        public DateTime? DataHoraAlteraStatus { get; set; }
        
        [Browsable(false)]
        public StatusDeliveryIfood Status { get; set; }

        [Browsable(false)]
        public DateTime? DataHoraAgendadoInicio { get; set; }

        [Browsable(false)]
        public DateTime? DataHoraAgendadoFim { get; set; }

        [Browsable(false)]
        public DateTime? DataHoraInicioPreparo { get; set; }

        [Browsable(false)]
        public string RespCupom { get; set; 
        }
        [Browsable(false)]
        public string PagamentoOnline { get; set; }

        [Browsable(false)]
        public virtual PedidoStatusIfood PedidoStatusIfood { get; set; }

        [Browsable(false)]
        public virtual EnderecoEntregaIfood EnderecoEntrega { get; set; }

        [Browsable(false)]
        public virtual ICollection<ItemPedidoIfood> Itens { get; set; }

        [Browsable(false)]
        public virtual PagamentoIfood PagamentoIfood { get; set; }

    }
    public class PedidoIfoodEntityTypeConfiguration : IEntityTypeConfiguration<PedidoIfood>
    {
        public void Configure(EntityTypeBuilder<PedidoIfood> builder)
        {
            builder.ToTable("TPEDIDOIFOOD");

            builder.HasKey(e => e.Controle);
            builder.Property(e => e.Controle).HasColumnName("CONTROLE").IsRequired();

            builder.Property(e => e.IdPedido).HasColumnName("IDPEDIDO");

            builder.Property(e => e.IdResumo).HasColumnName("IDRESUMO");

            builder.Property(e => e.Mesa).HasColumnName("MESA");

            builder.Property(e => e.TipoPedido).HasColumnName("TIPOPEDIDO").HasDefaultValue().HasConversion<string>(
                v => DataTypes.TipoPedidoDeliveryToString(v),
                v => DataTypes.StringToTipoPedidoDelivery(v)
            );

            builder.Property(e => e.EntregaAgendada).HasColumnName("ENTREGAAGENDADA");

            builder.Property(e => e.DataHoraCadastro).HasColumnName("DATAHORACADASTRO").IsRequired();

            builder.Property(e => e.IdCliente).HasColumnName("IDCLIENTE");

            builder.Property(e => e.NomeCliente).HasColumnName("NOMECLIENTE");

            builder.Property(e => e.CNPJCPF).HasColumnName("CNPJCPF");

            builder.Property(e => e.Telefone).HasColumnName("TELEFONE");

            builder.Property(e => e.OBS).HasColumnName("OBS");

            builder.Property(e => e.ValorTotal).HasColumnName("VALORTOTAL");

            builder.Property(e => e.ValorTaxaEntrega).HasColumnName("VALORTAXAENTREGA");

            builder.Property(e => e.ValorLiquido).HasColumnName("VALORLIQUIDO");

            builder.Property(e => e.ValorAdicional).HasColumnName("VALORADICIONAL");

            builder.Property(e => e.ValorTotalCupom).HasColumnName("VALORTOTALCUPOM");

            builder.Property(e => e.ValorPago).HasColumnName("VALORPAGO");

            builder.Property(e => e.ValorAPagar).HasColumnName("VALORAPAGAR");

            builder.Property(e => e.DataHoraAlteraStatus).HasColumnName("DATAHORAALTERASTATUS");

            builder.Property(e => e.Status).HasColumnName("STATUS");

            builder.Property(e => e.Status).HasColumnName("STATUS").HasDefaultValue().HasConversion<string>(
                v => DataTypes.StatusDeliveryIfoodToString(v),
                v => DataTypes.StringToStatusDeliveryIfood(v)
            );

            builder.Property(e => e.DataHoraAgendadoInicio).HasColumnName("DATAHORAAGENDADOINICIO");

            builder.Property(e => e.DataHoraAgendadoFim).HasColumnName("DATAHORAAGENDADOFIM");

            builder.Property(e => e.DataHoraInicioPreparo).HasColumnName("DATAHORAINICIOPREPARO");

            builder.Property(e => e.RespCupom).HasColumnName("RESPCUPOM");

            builder.Property(e => e.PagamentoOnline).HasColumnName("PAGAMENTOONLINE");

            builder.HasOne(c => c.PedidoStatusIfood).WithOne(i => i.PedidoIfood).HasForeignKey<PedidoStatusIfood>(i => i.CodPedido);

            builder.HasOne(c => c.EnderecoEntrega).WithOne(i => i.PedidoIfood).HasForeignKey<EnderecoEntregaIfood>(i => i.CodPedido);

            builder.HasMany(c => c.Itens).WithOne(c => c.PedidoIfood).HasForeignKey(c => c.CodPedido);

            builder.HasOne(c => c.PagamentoIfood).WithOne(i => i.PedidoIfood).HasForeignKey<PagamentoIfood>(i => i.CodPedidoIfood);

        }
    }
}