using System;
using System.IO;

namespace SGComum.Utils
{
    public static class Constants
    {

        public const string TOKEN_MEUSG = "5L/8K//}#$@dwKgf/)XqqQB6ZnrhFHX4qm[Y*=wX&%sxSvU5S;nsBm&U=K=7";

        public const string URLMeuSG = "https://meusg.com.br/";

        private static string _sistema;
        public static string Sistema
        {
            get
            {
                if (string.IsNullOrEmpty(_sistema))
                {
                    if (File.Exists($"{Environment.CurrentDirectory}//Certo.ini"))
                        _sistema = "Certo MEI";
                    else
                        _sistema = "SGBr Sistemas";
                }

                return _sistema;
            }
        }

    }
}
