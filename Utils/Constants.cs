using System;
using System.IO;

namespace SGComum.Utils
{
    public static class Constants
    {
        public const string URLAmoOfertas = "https://api.amo.delivery/";

        public const string URLStageAmoOfertas = "https://api.stage.amo.delivery/";

        public const string TOKEN_AMO = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1lIjoiTWFyY29zIEdpb3JkYW5pIiwiZW1haWwiOiJxdWFsaWRhZGVAc2dici5jb20uYnIiLCJ0b2tlbl9pZCI6IjY0NDA0ODZiMWFkMTA2MDAxYTBjNDFmNyIsImNsaWVudF90eXBlIjoicmVzdCIsInNjb3BlIjoiZXN0YWJsaXNobWVudCIsImVzdGFibGlzaG1lbnRfaWQiOiI2NDNkNzY5MTQxNzEyMDAwMWFmOTkwZWMiLCJpYXQiOjE2ODE5MzQ0NDN9.6E35UzVsoQhyz7_y10tsi3YdE1VwwegYJL9gR1SDJH0";

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
