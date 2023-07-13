using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Common
{
    internal class Arquivos
    {
        public static long FileSize(string arquivo)
        {
            if (!File.Exists(arquivo))
                return 0;

            FileInfo file = new FileInfo(arquivo);
            return file.Length;
        }
    }
}
