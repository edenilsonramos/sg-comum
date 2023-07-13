using System;
using System.Diagnostics;
using System.IO;
using SGComum.Utils;

namespace SGComum.Utils
{
    public class Log
    {
        private static readonly object _locker = new object();
        private static DateTime _dataUltimaLinha = DateTime.Now;

        public static void Write(string conteudo, string nomeArquivo)
        {
            string dirPadrao = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory.ToString()) + "\\Logs\\";

            if (Directory.Exists(dirPadrao) == false)
                Directory.CreateDirectory(dirPadrao);

            string caminhoArquivo = dirPadrao + nomeArquivo + ".log";
            lock(_locker)
            {
                if (File.Exists(caminhoArquivo) && Common.FileSize(caminhoArquivo) >= 2097152)
                    File.Delete(caminhoArquivo);
                File.AppendAllText(caminhoArquivo, $"[{DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss.ff")} - {DateTime.Now - _dataUltimaLinha}]: {Process.GetCurrentProcess().ProcessName} - {conteudo}\n");
            }
        }
    }
}
