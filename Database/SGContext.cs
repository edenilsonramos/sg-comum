using Microsoft.EntityFrameworkCore;
using SGComum.Database.Models;
using SGMeuSG.Core;
using System;
using System.Collections.Generic;

namespace SGComum.Database
{
    public class SGContext : DbContext
    {
        public ConnectionParams ConnectionParams { get; set; }

        public SGContext(ConnectionParams connectionParams) : base()
        {
            ConnectionParams = connectionParams;
        }

        public DbSet<Comanda> Comanda { get; set; }

        public DbSet<ItemComanda> ItemComanda { get; set; }

        public DbSet<ComandaAprovar> ComandaAprovar { get; set; }

        public DbSet<ItemComandaAprovar> ItemComandaAprovar { get; set; }

        public DbSet<ConfigAmo> ConfigAmo { get; set; }

        public DbSet<ConfigIfood> ConfigIfood { get; set; }

        public DbSet<PedidoAmo> PedidoAmo { get; set; }

        public DbSet<ItemPedidoAmo> ItemPedidoAmo { get; set; }

        public DbSet<PedidoIfood> PedidoIfood { get; set; }

        public DbSet<ItemPedidoIfood> ItemPedidoIfood { get; set; }

        public DbSet<EnderecoEntregaAmo> EnderecoEntregaAmo { get; set; }

        public DbSet<EnderecoEntregaIfood> EnderecoEntregaIfood { get; set; }

        public DbSet<PedidoStatusIfood> PedidoStatusIfood { get; set; }

        public DbSet<PedidoStatusAmo> PedidoStatusAmo { get; set; }

        public DbSet<PagamentoIfood> PagamentoIfood { get; set; }

        public DbSet<PagamentoAmo> PagamentoAmo { get; set; }

        public DbSet<ItemDeliveryAdicionais> ItemDeliveryAdicionais { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            new ComandaAprovarEntityTypeConfiguration().Configure(modelBuilder.Entity<ComandaAprovar>());

            new ItemComandaEntityTypeConfiguration().Configure(modelBuilder.Entity<ItemComanda>());

            new ComandaAprovarEntityTypeConfiguration().Configure(modelBuilder.Entity<ComandaAprovar>());

            new ConfigIfoodEntityTypeConfiguration().Configure(modelBuilder.Entity<ConfigIfood>());

            new ConfigAmoEntityTypeConfiguration().Configure(modelBuilder.Entity<ConfigAmo>());

            new PedidoAmoEntityTypeConfiguration().Configure(modelBuilder.Entity<PedidoAmo>());

            new ItemPedidoAmoEntityTypeConfiguration().Configure(modelBuilder.Entity<ItemPedidoAmo>());

            new PedidoStatusAmoEntityTypeConfiguration().Configure(modelBuilder.Entity<PedidoStatusAmo>());

            new EnderecoEntregaAmoEntityTypeConfiguration().Configure(modelBuilder.Entity<EnderecoEntregaAmo>());

            new PagamentoAmoEntityTypeConfiguration().Configure(modelBuilder.Entity<PagamentoAmo>());

            new PedidoIfoodEntityTypeConfiguration().Configure(modelBuilder.Entity<PedidoIfood>());

            new ItemPedidoIfoodEntityTypeConfiguration().Configure(modelBuilder.Entity<ItemPedidoIfood>());

            new PedidoStatusIfoodEntityTypeConfiguration().Configure(modelBuilder.Entity<PedidoStatusIfood>());

            new EnderecoEntregaIfoodEntityTypeConfiguration().Configure(modelBuilder.Entity<EnderecoEntregaIfood>());

            new PagamentoIfoodEntityTypeConfiguration().Configure(modelBuilder.Entity<PagamentoIfood>());

            new ItemDeliveryAdicionaisEntityTypeConfiguration().Configure(modelBuilder.Entity<ItemDeliveryAdicionais>());    

        }

        public List<Dictionary<string, dynamic>> ExecuteRawQuery(string Query)
        {
            using (var command = Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = Query;
                command.CommandType = System.Data.CommandType.Text;

                Database.OpenConnection();
                var lista = new List<Dictionary<string, dynamic>>();
                using (var result = command.ExecuteReader())
                {
                    while (result.Read())
                    {
                        var rec = new Dictionary<string, dynamic>(StringComparer.OrdinalIgnoreCase);
                        for (var i = 0; i < result.FieldCount; i++)
                            rec.Add(result.GetName(i), result.GetFieldValue<dynamic>(i));
                        lista.Add(rec);
                    }
                }
                return lista;
            }
        }

        public void ExecuteSqlCommand(string Query)
        {
            using (var command = Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = Query;
                command.CommandType = System.Data.CommandType.Text;

                Database.OpenConnection();
                
                command.ExecuteNonQuery();
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging(true);

            base.OnConfiguring(optionsBuilder);

            switch (ConnectionParams.Driver)
            {
                case TipoDriver.MySql:
                    {
                        optionsBuilder.UseMySQL(ConnectionParams.ConnectionString);
                        break;
                    }
                default:
                    {
                        optionsBuilder.UseFirebird(ConnectionParams.ConnectionString);
                        break;
                    }
            }
        }
    }
}
