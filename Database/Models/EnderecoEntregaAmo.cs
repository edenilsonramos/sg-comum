using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel;

namespace SGComum.Database.Models
{
    public class EnderecoEntregaAmo
    {
        [Browsable(false)]
        public int Controle { get; set; }

        [Browsable(false)]
        public int? CodPedido { get; set; }

        [Browsable(false)]
        public string Endereco { get; set; }

        [Browsable(false)]
        public string Numero { get; set; }

        [Browsable(false)]
        public string Bairro { get; set; }

        [Browsable(false)]
        public string Cidade { get; set; }

        [Browsable(false)]
        public string UF { get; set; }

        [Browsable(false)]
        public string Complemento { get; set; }

        [Browsable(false)]
        public virtual PedidoAmo PedidoAmo { get; set; }
    }

    public class EnderecoEntregaAmoEntityTypeConfiguration : IEntityTypeConfiguration<EnderecoEntregaAmo>
    {
        public void Configure(EntityTypeBuilder<EnderecoEntregaAmo> builder)
        {
            builder.ToTable("TENDERECOENTREGAAMO");

            builder.HasKey(e => e.Controle);

            builder.Property(e => e.Controle).HasColumnName("CONTROLE").IsRequired();

            builder.Property(e => e.CodPedido).HasColumnName("CODPEDIDO").IsRequired();

            builder.Property(e => e.Endereco).HasColumnName("ENDERECO").HasMaxLength(150);

            builder.Property(e => e.Numero).HasColumnName("NUMERO").HasMaxLength(5);

            builder.Property(e => e.Bairro).HasColumnName("BAIRRO").HasMaxLength(100);

            builder.Property(e => e.Cidade).HasColumnName("CIDADE").HasMaxLength(50);

            builder.Property(e => e.UF).HasColumnName("UF").HasMaxLength(3);

            builder.Property(e => e.Complemento).HasColumnName("COMPLEMENTO").HasMaxLength(100);
        }
    }
}
