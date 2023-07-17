using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGComum.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using static SGComum.Core.DataTypes;

namespace SGComum.Database.Models
{
    public class PedidoAmo
    {
        [Browsable(false)]
        public int Controle { get; set; }

        [Browsable(false)]
        public DateTime DataHoraCadastro { get; set; }

        [Browsable(false)]
        public DateTime? DataAgendamento { get; set; }

        [Browsable(false)]
        public DateTime? DataHoraAlteraStatus { get; set; }

        [Browsable(false)]
        public string IdPedido { get; set; }

        [Browsable(false)]
        public string IdResumo { get; set; }

        [Browsable(false)]
        public TipoPedidoDelivery TipoPedido { get; set; }

        [Browsable(false)]
        public decimal? ValorTaxaEntrega { get; set; }

        [Browsable(false)]
        public decimal? ValorEmbalagem { get; set; }

        [Browsable(false)]
        public decimal? ValorTotalCupom { get; set; }

        [Browsable(false)]
        public decimal? ValorAdicional { get; set; }

        [Browsable(false)]
        public decimal? ValorDesconto { get; set; }

        [Browsable(false)]
        public decimal? ValorLiquido { get; set; }

        [Browsable(false)]
        public decimal? ValorAPagar { get; set; }

        [Browsable(false)]
        public decimal? ValorPago { get; set; }

        [Browsable(false)]
        public decimal? ValorTotal { get; set; }

        [Browsable(false)]
        public string TipoDesconto { get; set; }

        [Browsable(false)]
        public string OBS { get; set; }
        
        [Browsable(false)]
        public AmoOfertasOrderStatus Status { get; set; }

        [Browsable(false)]
        public string NomeCliente { get; set; }

        [Browsable(false)]
        public string Email { get; set; }

        [Browsable(false)]
        public string Telefone { get; set; }

        [Browsable(false)]
        public string CNPJCPF { get; set; }

        [Browsable(false)]
        public virtual PedidoStatusAmo PedidoStatusAmo { get; set; }
        
        [Browsable(false)]
        public virtual EnderecoEntregaAmo EnderecoEntrega { get; set; }
        
        [Browsable(false)]
        public virtual ICollection<ItemPedidoAmo> Itens { get; set; }
        
        [Browsable(false)]
        public virtual PagamentoAmo PagamentoAmo { get; set; }
        
    }
    public class PedidoAmoEntityTypeConfiguration : IEntityTypeConfiguration<PedidoAmo>
    {
        public void Configure(EntityTypeBuilder<PedidoAmo> builder)
        {
            builder.ToTable("TPEDIDOAMO");

            builder.HasKey(e => e.Controle);
            builder.Property(e => e.Controle).HasColumnName("CONTROLE").IsRequired();

            builder.Property(e => e.DataHoraCadastro).HasColumnName("DATAHORACADASTRO").IsRequired();

            builder.Property(e => e.DataAgendamento).HasColumnName("DATAAGENDAMENTO");

            builder.Property(e => e.DataHoraAlteraStatus).HasColumnName("DATAHORAALTERASTATUS");

            builder.Property(e => e.IdPedido).HasColumnName("IDPEDIDO");

            builder.Property(e => e.IdResumo).HasColumnName("IDRESUMO");

            builder.Property(e => e.TipoPedido).HasColumnName("TIPOPEDIDO");

            builder.Property(e => e.TipoPedido).HasColumnName("TIPOPEDIDO").HasDefaultValue().HasConversion<string>(
                v => DataTypes.TipoPedidoDeliveryToString(v),
                v => DataTypes.StringToTipoPedidoDelivery(v)
            );

            builder.Property(e => e.ValorTaxaEntrega).HasColumnName("VALORTAXAENTREGA");

            builder.Property(e => e.ValorEmbalagem).HasColumnName("VALOREMBALAGEM");

            builder.Property(e => e.ValorTotalCupom).HasColumnName("VALORTOTALCUPOM");

            builder.Property(e => e.ValorAdicional).HasColumnName("VALORADICIONAL");

            builder.Property(e => e.ValorLiquido).HasColumnName("VALORLIQUIDO");

            builder.Property(e => e.ValorPago).HasColumnName("VALORPAGO");

            builder.Property(e => e.ValorTotal).HasColumnName("VALORTOTAL");

            builder.Property(e => e.ValorAPagar).HasColumnName("VALORAPAGAR");

            builder.Property(e => e.TipoDesconto).HasColumnName("TIPODESCONTO").HasMaxLength(10);

            builder.Property(e => e.OBS).HasColumnName("OBS");

            builder.Property(e => e.Status).HasColumnName("STATUS").HasMaxLength(20);

            builder.Property(e => e.NomeCliente).HasColumnName("NOMECLIENTE").HasMaxLength(100);

            builder.Property(e => e.Email).HasColumnName("EMAIL").HasMaxLength(100);

            builder.Property(e => e.Telefone).HasColumnName("TELEFONE").HasMaxLength(20);

            builder.Property(e => e.CNPJCPF).HasColumnName("CNPJCPF").HasMaxLength(14);

            builder.HasOne(c => c.PedidoStatusAmo).WithOne(i => i.PedidoAmo).HasForeignKey<PedidoStatusAmo>(i => i.CodPedido);

            builder.HasOne(c => c.EnderecoEntrega).WithOne(i => i.PedidoAmo).HasForeignKey<EnderecoEntregaAmo>(i => i.CodPedido);

            builder.HasMany(c => c.Itens).WithOne(c => c.PedidoAmo).HasForeignKey(c => c.CodPedido);
            
            builder.HasOne(c => c.PagamentoAmo).WithOne(i => i.PedidoAmo).HasForeignKey<PagamentoAmo>(i => i.CodPedido);
        }
    }
}