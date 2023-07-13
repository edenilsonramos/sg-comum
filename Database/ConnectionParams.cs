using SGComum.Utils;
using SGMeuSG.Core;
using System;
using System.Text.RegularExpressions;

namespace SGComum.Database
{
    public class ConnectionParams
    {
        public string Host { get; set; } = "localhost";
        public string Database { get; set; } = "BASESGMASTER1";
        public int Port { get; set; } = 3345;
        public string Username { get; set; } = "root";
        public string Password { get; set; } = "masterkey";
        public TipoDriver Driver { get; set; } = TipoDriver.MySql;

        public void LoadFromIniFile(string aIniFilePath)
        {
            IniFile iniFile = new IniFile(aIniFilePath);

            Driver = iniFile.Read("Busca BD", "Firebird", "1") == "1" ? TipoDriver.Firebird : TipoDriver.MySql;

            if (Driver == TipoDriver.Firebird)
            {
                string database = iniFile.Read("Busca BD", "Conexao", "C:\\SGBr\\Master\\BD\\BASESGMASTER.FDB").ToUpper();

                Database = RetornaDatabase(Driver, database);
                Host = RetornaHost(database);
                Port = 3050;
                Username = "SYSDBA";
                Password = "masterkey";

            }
            else
            {
                Host = iniFile.Read("Busca BD", "Conexao", "localhost");
                Port = Int32.TryParse(iniFile.Read("Busca BD", "Porta"), out int j) ? j : 3345;
                Database = iniFile.Read("Busca BD", "NomeBD", "basesgmaster");
                Username = iniFile.Read("Busca BD", "UsuárioBD", "root");
                Password = iniFile.Read("Busca BD", "SenhaBD");
            }


        }
        public static string RetornaHost(string host)
        {
            if (host.Contains(@"\\"))
                host = host.Remove(0, 2);

            var regex = new Regex(@"((:|\\)?[a-zA-Z]:)");
            var match = regex.Match(host);
            var ocorrencia = match.Success ? match.Value : null;

            int posicao = 0;
            if (!String.IsNullOrEmpty(ocorrencia))
                posicao = host.IndexOf(ocorrencia);

            string hostAtualizado = host.Substring(0, posicao/* - ocorrencia.Length*/);
            if (!String.IsNullOrEmpty(ocorrencia))
            {
                if (!String.IsNullOrEmpty(hostAtualizado))
                    return hostAtualizado;
                else
                    return "localhost";
            }
            return host;
        }

        public static string RetornaDatabase(TipoDriver tipoBanco, string caminhoBanco, string nomeBanco = null)
        {
            var regex = new Regex(@"([a-zA-Z]:\\)");
            var match = regex.Match(caminhoBanco);

            string database ;
            if (TipoDriver.Firebird == tipoBanco)
            {
                database = caminhoBanco;
                var ocorrencia = match.Success ? match.Value : null;
                int posicao = caminhoBanco.IndexOf(ocorrencia);
                if (posicao > 0)
                    database = caminhoBanco.Substring(posicao, caminhoBanco.Length - posicao);

                if (!string.IsNullOrEmpty(nomeBanco))
                {
                    var caminhoBancoCompleto = $@"{caminhoBanco}{nomeBanco}";
                    database = caminhoBancoCompleto;
                }
            }
            else
                database = nomeBanco.ToUpper().Replace(".SQL", "");

            return database;
        }

        public string ConnectionString
        {
            get
            {
                switch (Driver)
                {
                    case TipoDriver.MySql:
                        {
                            return $"Server={Host};Database={Database};Port={Port};Uid={Username};Pwd={Password};Convert Zero Datetime=True";
                        }
                    default:
                        {
                            return $"DataSource={Host};Database={Database};Port={Port};User={Username};Password={Password};Charset=utf8;Dialect=3;Connection lifetime=15;Packet Size=8192;Server Type=0";
                        }
                }
            }
        }
    }
}
