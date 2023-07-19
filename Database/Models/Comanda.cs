using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGComum.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SGComum.Database.Models
{
    public class Comanda
    {
        [DisplayName("Mesa")]
        public int? NumeroMesa { get; set; }

        [DisplayName("Senha comanda")]
        public int? SenhaComanda { get; set; }

        [DisplayName("Cód. cliente")]
        public string GridCodCliente => CodCliente?.ToString("D6");
        [Browsable(false)]
        public int? CodCliente { get; set; }

        [DisplayName("Cliente")]
        public string Cliente { get; set; }

        [DisplayName("Valor total")]
        public string GridValorTotal => ValorTotal.ToString("N2");
        [Browsable(false)]
        public decimal ValorTotal { get; set; }

        [DisplayName("Status")]
        public string Status { get; set; }

        [DisplayName("Data de abertura")]
        public string GridDataAbertura => DataAbertura?.ToString("dd/MM/yyyy");
        [Browsable(false)]
        public DateTime? DataAbertura { get; set; }

        public string GridHoraAbertura => HoraAbertura.ToString(@"hh\:mm\:ss");
        
        [Browsable(false)]
        public TimeSpan HoraAbertura { get; set; } 

        [DisplayName("Data hora cadastro")]
        public DateTime DataHoraCadastro { get; set; } = DateTime.Now;

        [DisplayName("Cód. funcionário")]
        public string GridCodFuncionario => CodFuncionario?.ToString("D6");
        [Browsable(false)]
        public int? CodFuncionario { get; set; }

        [DisplayName("Funcionário")]
        public string Funcionario { get; set; }

        [DisplayName("Valor produtos")]
        public string GridValorProdutos => ValorProdutos?.ToString("N2");
        [Browsable(false)]
        public decimal? ValorProdutos { get; set; }

        [DisplayName("CPF")]
        public string CPF { get; set; }

        [DisplayName("CNPJ")]
        public string CNPJ { get; set; }

        [DisplayName("Telefone")]
        public string Telefone { get; set; }

        [DisplayName("Celular")]
        public string Celular { get; set; }

        [DisplayName("Pedido")]
        public string GridPedido
        {
            get
            {
                return DataTypes.BoolToSimNaoNull(Pedido);
            }
        }

        [Browsable(false)]
        public bool? Pedido { get; set; }

        [DisplayName("Código")]
        public int Controle { get; set; }

        [Browsable(false)]
        public DateTime? DataFechamento { get; set; }

        [Browsable(false)]
        public TimeSpan? HoraFechamento { get; set; }

        [Browsable(false)]
        public decimal? ValorDesconto { get; set; }

        [Browsable(false)]
        public decimal? ValorAcrescimo { get; set; }

        [Browsable(false)]
        public decimal? ValorComissao { get; set; }

        [Browsable(false)]
        public string SerieECFCF { get; set; }

        [Browsable(false)]
        public string COOCF { get; set; }

        [Browsable(false)]
        public string SerieECFRG { get; set; }

        [Browsable(false)]
        public string COORG { get; set; }

        [Browsable(false)]
        public int? Ocupantes { get; set; }

        [Browsable(false)]
        public decimal? ValorOcupante { get; set; }

        [Browsable(false)]
        public int? CER { get; set; }

        [Browsable(false)]
        public int? NumeroECFConfMesa { get; set; }

        [Browsable(false)]
        public int? COOConfMesa { get; set; }

        [Browsable(false)]
        public DateTime? DataHoraAberturaOrigem { get; set; }

        [Browsable(false)]
        public DateTime? DataMovimento { get; set; }

        [Browsable(false)]
        public string Endereco { get; set; }

        [Browsable(false)]
        public string Numero { get; set; }

        [Browsable(false)]
        public string Bairro { get; set; }

        [Browsable(false)]
        public string Complemento { get; set; }

        [Browsable(false)]
        public string CodBarras { get; set; }

        [Browsable(false)]
        public decimal? PercComissao { get; set; }

        [Browsable(false)]
        public decimal? TaxaServico { get; set; }

        [Browsable(false)]
        public string Obs { get; set; }

        [Browsable(false)]
        public string MD5 { get; set; }

        [Browsable(false)]
        public int? CodMobile { get; set; }

        [Browsable(false)]
        public string IMEIMobile { get; set; }

        [Browsable(false)]
        public string Indicador { get; set; }

        [Browsable(false)]
        public decimal? ValorCredito { get; set; }

        [Browsable(false)]
        public string TipoPedido { get; set; }

        [Browsable(false)]
        public int? CodPedido { get; set; }

        [Browsable(false)]
        public string OrigemPedido { get; set; }

        [Browsable(false)]
        public string GridEnviadoSGNaWeb
        {
            get
            {
                return DataTypes.BoolToZeroUmNull(EnviadoSGNaWeb);
            }
        }

        [Browsable(false)]
        public bool? EnviadoSGNaWeb { get; set; } = false;


        [Browsable(false)]
        public ICollection<ItemComanda> Itens { get; set; }

        [Browsable(false)]
        public ComandaAprovar ComandaAprovar { get; set; }

        [Browsable(false)]
        public MesaReserva MesaReserva { get; set; }

        [Browsable(false)]
        public ICollection<FormaPagamentoComanda> FormasPagamento { get; set; }

    }

    public class ComandaEntityTypeConfiguration: IEntityTypeConfiguration<Comanda>
    {
        public void Configure(EntityTypeBuilder<Comanda> builder)
        {
            builder.ToTable("TCOMANDA");

            builder.HasKey(c => c.Controle);
            builder.Property(c => c.Controle).HasColumnName("CONTROLE").IsRequired();

            builder.Property(c => c.NumeroMesa).HasColumnName("NUMEROMESA").IsRequired();

            builder.Property(c => c.CodFuncionario).HasColumnName("CODFUNCIONARIO");

            builder.Property(c => c.Funcionario).HasColumnName("FUNCIONARIO").HasMaxLength(100);

            builder.Property(c => c.CodCliente).HasColumnName("CODCLIENTE");

            builder.Property(c => c.Cliente).HasColumnName("CLIENTE").HasMaxLength(100);

            builder.Property(c => c.Status).HasColumnName("STATUS").HasMaxLength(25);

            builder.Property(c => c.DataAbertura).HasColumnName("DATAABERTURA");

            builder.Property(c => c.HoraAbertura).HasColumnName("HORAABERTURA");

            builder.Property(c => c.DataFechamento).HasColumnName("DATAFECHAMENTO");

            builder.Property(c => c.HoraFechamento).HasColumnName("HORAFECHAMENTO");

            builder.Property(c => c.ValorTotal).HasColumnName("VALORTOTAL");

            builder.Property(c => c.ValorDesconto).HasColumnName("VALORDESCONTO");

            builder.Property(c => c.ValorAcrescimo).HasColumnName("VALORACRESCIMO");

            builder.Property(c => c.ValorComissao).HasColumnName("VALORCOMISSAO");

            builder.Property(c => c.SerieECFCF).HasColumnName("SERIEECFCF").HasMaxLength(20);

            builder.Property(c => c.COOCF).HasColumnName("COOCF").HasMaxLength(9);

            builder.Property(c => c.SerieECFRG).HasColumnName("SERIEECFRG").HasMaxLength(20);

            builder.Property(c => c.COORG).HasColumnName("COORG").HasMaxLength(9);

            builder.Property(c => c.Ocupantes).HasColumnName("OCUPANTES");

            builder.Property(c => c.ValorOcupante).HasColumnName("VALOROCUPANTE");

            builder.Property(c => c.ValorProdutos).HasColumnName("VALORPRODUTOS");

            builder.Property(c => c.CER).HasColumnName("CER");

            builder.Property(c => c.NumeroECFConfMesa).HasColumnName("NUMEROECFCONFERENCIAMESA");

            builder.Property(c => c.COOConfMesa).HasColumnName("COOCONFERENCIAMESA");

            builder.Property(c => c.DataHoraAberturaOrigem).HasColumnName("DATAEHORAABERTURAORIGEM").HasDefaultValue();

            builder.Property(c => c.DataMovimento).HasColumnName("DATAMOVIMENTO");

            builder.Property(c => c.Endereco).HasColumnName("ENDERECO").HasMaxLength(250);

            builder.Property(c => c.Numero).HasColumnName("NUMERO").HasMaxLength(10);

            builder.Property(c => c.Bairro).HasColumnName("BAIRRO").HasMaxLength(80);

            builder.Property(c => c.Telefone).HasColumnName("TELEFONE").HasMaxLength(20);

            builder.Property(c => c.Celular).HasColumnName("CELULAR").HasMaxLength(20);

            builder.Property(c => c.Pedido).HasColumnName("PEDIDO").HasConversion<string>(
                v => DataTypes.BoolToSimNaoNull(v),
                v => DataTypes.SimNaoNullToBool(v)
            );

            builder.Property(c => c.Complemento).HasColumnName("COMPLEMENTO").HasMaxLength(250);

            builder.Property(c => c.DataHoraCadastro).HasColumnName("DATAEHORACADASTRO").HasDefaultValue();

            builder.Property(c => c.CPF).HasColumnName("CPF").HasMaxLength(15);

            builder.Property(c => c.CNPJ).HasColumnName("CNPJ").HasMaxLength(20);

            builder.Property(c => c.CodBarras).HasColumnName("CODBARRAS").HasMaxLength(20);

            builder.Property(c => c.PercComissao).HasColumnName("PERCCOMISSAO");

            builder.Property(c => c.TaxaServico).HasColumnName("TAXASERVICO");

            builder.Property(c => c.Obs).HasColumnName("OBS");

            builder.Property(c => c.SenhaComanda).HasColumnName("SENHACOMANDA");

            builder.Property(c => c.MD5).HasColumnName("MD5").HasMaxLength(200);

            builder.Property(c => c.CodMobile).HasColumnName("CONTROLEBASEMOBILE");

            builder.Property(c => c.IMEIMobile).HasColumnName("IMEIMOBILE").HasMaxLength(15);

            builder.Property(c => c.Indicador).HasColumnName("INDICADOR").HasMaxLength(100);

            builder.Property(c => c.ValorCredito).HasColumnName("VALORCREDITO");

            builder.Property(c => c.TipoPedido).HasColumnName("TIPOPEDIDO");

            builder.Property(c => c.CodPedido).HasColumnName("CODPEDIDO");

            builder.Property(c => c.OrigemPedido).HasColumnName("ORIGEMPEDIDO").HasMaxLength(1);

            builder.Property(c => c.EnviadoSGNaWeb).HasColumnName("ENVIADOSGNAWEB").HasDefaultValue().HasConversion<string>(
                v => DataTypes.BoolToZeroUmNull(v),
                v => DataTypes.ZeroUmNullToBool(v)
            );

            builder.HasMany(c => c.Itens).WithOne(i => i.Comanda).HasForeignKey(i => i.CodComanda).OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(c => c.ComandaAprovar).WithOne(i => i.Comanda).HasForeignKey<ComandaAprovar>(i => i.CodComanda).OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(c => c.MesaReserva).WithOne(i => i.Comanda).HasForeignKey<MesaReserva>(i => i.CodComanda).OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(c => c.FormasPagamento).WithOne(i => i.Comanda).HasForeignKey(i => i.CodComanda);
        }
    }
}
