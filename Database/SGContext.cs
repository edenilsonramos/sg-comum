using Microsoft.EntityFrameworkCore;
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
