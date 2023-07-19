using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGComum.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace SGComum.Database.Models
{
    public class ItemComanda
    {

        [DisplayName("#")]
        [NotMapped]
        public virtual bool GridChecado
        {
            get => Checado != null ? (bool)Checado : false;
            set => Checado = value;
        }

        [Browsable(false)]
        public bool Checado { get; set; }

        [DisplayName("Cód. produto")]
        public int CodProduto { get; set; }

        [DisplayName("Produto")]
        public string Produto { get; set; }

        [Browsable(false)]
        public decimal? Qtde { get; set; }

        [Browsable(false)]
        public decimal? ValorUnitario { get; set; }

        [Browsable(false)]
        public decimal? ValorTotal { get; set; }

        [Browsable(false)]
        public decimal? ValorDesconto { get; set; }

        [Browsable(false)]
        public decimal? ValorAcrescimo { get; set; }

        [DisplayName("Controle")]
        public int Controle { get; set; }

        [DisplayName("Cód. comanda")]
        public int CodComanda { get; set; }

        [DisplayName("Status")]
        public string Status { get; set; }

        [DisplayName("Código barras")]
        public string CodBarra { get; set; }

        [DisplayName("Valor adicional")]
        public decimal? ValorAdicional { get; set; }

        [DisplayName("Cancelado")]
        public string GridCancelado => DataTypes.BoolToSimNao(Cancelado);

        [Browsable(false)]
        public bool Cancelado { get; set; }

        [DisplayName("Cód. funcionário")]
        public int? CodFuncionario { get; set; }

        [DisplayName("Funcionário")]
        public string Funcionario { get; set; }

        [DisplayName("Transferido")]
        public string GridTransferido => DataTypes.BoolToSimNao(Transferido);

        [Browsable(false)]
        public bool Transferido { get; set; }

        [DisplayName("Mesa origem")]
        public int? MesaOrigem { get; set; }

        [DisplayName("Mesa destino")]
        public int? MesaDestino { get; set; }

        [DisplayName("Data lançamento")]
        public DateTime? DataLancamento { get; set; }

        [DisplayName("Hora lançamento")]
        public TimeSpan? HoraLancamento { get; set; }

        [DisplayName("UN")]
        public string UN { get; set; }

        [DisplayName("Confirmado")]
        public string GridConfirmado => DataTypes.BoolToSimNao(Confirmado);

        [Browsable(false)]
        public bool Confirmado { get; set; }

        [DisplayName("Impresso")]
        public string Impresso { get; set; }

        [DisplayName("Obs item")]
        public string ObsItem { get; set; }

        [DisplayName("Data hora cancelamento")]
        public DateTime? DataHoraCancelamento { get; set; }

        [DisplayName("Data hora cadastro")]
        public DateTime DataHoraCadastro { get; set; }

        [DisplayName("Descrição transferência")]
        public string DescricaoTransferencia { get; set; }

        [Browsable(false)]
        public string Adicionais { get; set; }

        [Browsable(false)]
        public string Impressora { get; set; }

        [Browsable(false)]
        public string NomeMaquina { get; set; }

        [Browsable(false)]
        public string Md5 { get; set; }

        [Browsable(false)]
        public int? ControleBaseMobile { get; set; }

        [Browsable(false)]
        public string ImeiMobile { get; set; }

        [Browsable(false)]
        public string CancelamentoImpresso { get; set; }

        [Browsable(false)]
        public string Produzido { get; set; }

        [Browsable(false)]
        public int? CodPedidoItemDelivery { get; set; }

        [Browsable(false)]
        public int? CardapioControle { get; set; }

        [Browsable(false)]
        public string CardapioNome { get; set; }

        [Browsable(false)]
        public string CardapioGrupo { get; set; }

        [Browsable(false)]
        public string CardapioTamanho { get; set; }

        [Browsable(false)]
        public string ProdutoNome { get; set; }

        [Browsable(false)]
        public string PizzaToken { get; set; }

        [Browsable(false)]
        public int? ItemLider { get; set; }

        public Comanda Comanda { get; set; }

        [Browsable(false)]
        public virtual ItemComandaAprovar ComandaAprovar { get; set; }

        [Browsable(false)]
        public virtual ICollection<ItemComandaAdicional> ItemAdicionais { get; set; }
    }
    public class ItemComandaEntityTypeConfiguration : IEntityTypeConfiguration<ItemComanda>
    {
        public void Configure(EntityTypeBuilder<ItemComanda> builder)
        {
            builder.ToTable("TITEMCOMANDA");

            builder.HasKey(e => e.Controle);
            builder.Property(c => c.Controle).HasColumnName("CONTROLE").IsRequired();

            builder.Property(c => c.CodComanda).HasColumnName("CODCOMANDA").IsRequired();

            builder.Property(c => c.CodProduto).HasColumnName("CODPRODUTO").IsRequired();

            builder.Property(c => c.Produto).HasColumnName("PRODUTO").HasMaxLength(100);

            builder.Property(c => c.CodBarra).HasColumnName("CODIGOBARRA").HasMaxLength(200);

            builder.Property(c => c.ValorUnitario).HasColumnName("VALORUNITARIO");

            builder.Property(c => c.ValorAdicional).HasColumnName("VALORADICIONAL");

            builder.Property(c => c.ValorTotal).HasColumnName("VALORTOTAL");

            builder.Property(c => c.Cancelado).HasColumnName("CANCELADO").IsRequired().HasConversion<string>(
                v => DataTypes.BoolToSimNao(v),
                v => DataTypes.SimNaoToBool(v)
            );

            builder.Property(c => c.CodFuncionario).HasColumnName("CODFUNCIONARIO");

            builder.Property(c => c.Funcionario).HasColumnName("FUNCIONARIO").HasMaxLength(100);

            builder.Property(c => c.Transferido).HasColumnName("TRASFERIDO").IsRequired().HasConversion<string>(
                v => DataTypes.BoolToSimNao(v),
                v => DataTypes.SimNaoToBool(v)
            );

            builder.Property(c => c.MesaOrigem).HasColumnName("MESAORIGEM");

            builder.Property(c => c.MesaDestino).HasColumnName("MESADESTINO");

            builder.Property(c => c.DataLancamento).HasColumnName("DATALANCAMENTO");

            builder.Property(c => c.HoraLancamento).HasColumnName("HORALANCAMENTO");

            builder.Property(c => c.ValorDesconto).HasColumnName("VALORDESCONTO");

            builder.Property(c => c.ValorAcrescimo).HasColumnName("VALORACRESCIMO");

            builder.Property(c => c.UN).HasColumnName("UN").HasMaxLength(6);

            builder.Property(c => c.Checado).HasColumnName("CHECADO").IsRequired().HasConversion<string>(
                v => DataTypes.BoolToSimNao(v),
                v => DataTypes.SimNaoToBool(v)
            );

            builder.Property(c => c.DescricaoTransferencia).HasColumnName("DESCRICAOTRANSFERENCIA").HasMaxLength(100);

            builder.Property(c => c.Status).HasColumnName("STATUS").HasMaxLength(25);

            builder.Property(c => c.Adicionais).HasColumnName("ADICIONAIS").HasMaxLength(250);

            builder.Property(c => c.Confirmado).HasColumnName("CONFIRMADO").IsRequired().HasConversion<string>(
                v => DataTypes.BoolToSimNao(v),
                v => DataTypes.SimNaoToBool(v)
            );

            builder.Property(c => c.Impresso).HasColumnName("IMPRESSO").HasMaxLength(3);

            builder.Property(c => c.ObsItem).HasColumnName("OBSITEM").HasMaxLength(250);

            builder.Property(c => c.Impressora).HasColumnName("IMPRESSORA").HasMaxLength(30);

            builder.Property(c => c.Qtde).HasColumnName("QTDE");

            builder.Property(c => c.NomeMaquina).HasColumnName("NOMEPC").HasMaxLength(30);

            builder.Property(c => c.DataHoraCancelamento).HasColumnName("DATAEHORACANCELAMENTO");

            builder.Property(c => c.DataHoraCadastro).HasColumnName("DATAEHORACADASTRO");

            builder.Property(c => c.Md5).HasColumnName("MD5").HasMaxLength(200);

            builder.Property(c => c.ControleBaseMobile).HasColumnName("CONTROLEBASEMOBILE");

            builder.Property(c => c.ImeiMobile).HasColumnName("IMEIMOBILE").HasMaxLength(15);

            builder.Property(c => c.CancelamentoImpresso).HasColumnName("CANCELAMENTOIMPRESSO").HasMaxLength(3);

            builder.Property(c => c.Produzido).HasColumnName("PRODUZIDO").HasMaxLength(1);

            builder.Property(c => c.CodPedidoItemDelivery).HasColumnName("CODITEMPEDIDODELIVERY");

            builder.Property(c => c.CardapioControle).HasColumnName("CARDAPIOCONTROLE");

            builder.Property(c => c.CardapioNome).HasColumnName("CARDAPIONOME").HasMaxLength(100);

            builder.Property(c => c.CardapioGrupo).HasColumnName("CARDAPIOGRUPO").HasMaxLength(100);

            builder.Property(c => c.CardapioTamanho).HasColumnName("CARDAPIOTAMANHO").HasMaxLength(100);

            builder.Property(c => c.ProdutoNome).HasColumnName("PRODUTONOME").HasMaxLength(100);

            builder.Property(c => c.PizzaToken).HasColumnName("PIZZATOKEN").HasMaxLength(100);

            builder.Property(c => c.ItemLider).HasColumnName("ITEMLIDER");

            builder.HasMany(c => c.ItemAdicionais).WithOne(i => i.ItemComanda).HasForeignKey(i => i.CodItemComanda).OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(c => c.ComandaAprovar).WithOne(i => i.ItemComanda).HasForeignKey<ItemComandaAprovar>(i => i.CodItemComanda).OnDelete(DeleteBehavior.Cascade);

        }
    }
}
