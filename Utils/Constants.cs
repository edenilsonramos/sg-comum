using System;
using System.IO;

namespace SGComum.Utils
{
    public static class Constants
    {
        public const string URLAmoOfertas = "https://api.amo.delivery/";

        public const string URLStageAmoOfertas = "https://api.stage.amo.delivery/";

        public const string TOKEN_AMO = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1lIjoiU0dCciIsImVtYWlsIjoiZGVzZW52b2x2aW1lbnRvM0BzZ2JyLmNvbSIsInRva2VuX2lkIjoiNjEwODM1ZGE2OWVkY2EwMDEzODRiYzYwIiwiY2xpZW50X3R5cGUiOiJyZXN0Iiwic2NvcGUiOiJlc3RhYmxpc2htZW50IiwiZXN0YWJsaXNobWVudF9pZCI6IjVmYzAwM2ZmOThkN2YyMDAyM2Q2ZTc1NyIsImlhdCI6MTYyNzkyODAyNn0.IeuNfqyQ_4EtBtPDXLq4KUaGIP-jWQFVnGbOebqZhb0";

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
