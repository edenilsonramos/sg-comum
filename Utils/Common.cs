using System.IO;
using System.Text.RegularExpressions;

namespace SGComum.Utils
{
    public class Common
    {
        public static string ApenasNumeros(string value)
        {
            if (value == null)
                return string.Empty;

            return Regex.Replace(value.Trim(), @"[^\d]+", string.Empty);
        }
        public static long FileSize(string arquivo)
        {
            if (!File.Exists(arquivo))
                return 0;

            FileInfo file = new FileInfo(arquivo);
            return file.Length;
        }

        public static string BoolToSimNao(bool aBool)
        {
            return aBool ? "SIM" : "NÃO";
        }
        
        public static bool SimNaoToBool(string aString)
        {
            return aString == "SIM";
        }
    }
}
