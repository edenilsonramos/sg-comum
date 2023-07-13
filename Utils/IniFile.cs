using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SGComum.Utils
{
    public sealed class IniFile
    {
        string Path;

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        static extern long WritePrivateProfileString(string Section, string Key, string Value, string FilePath);

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        static extern int GetPrivateProfileString(string Section, string Key, string Default, StringBuilder RetVal, int Size, string FilePath);

        public IniFile(string IniPath)
        {
            Path = new FileInfo(IniPath).FullName;
        }

        public string Read(string Section, string Key, string Default = "")
        {
            var RetVal = new StringBuilder(255);
            GetPrivateProfileString(Section, Key, "", RetVal, 255, Path);
            if (RetVal.ToString() == "")
                return Default;

            return RetVal.ToString();
        }

        public void Write(string Section, string Key, string Value)
        {
            WritePrivateProfileString(Section, Key, Value, Path);
        }

        public void DeleteKey(string Section, string Key)
        {
            Write(Key, "", Section);
        }

        public bool KeyExists(string Section, string Key)
        {
            return Read(Key, Section).Length > 0;
        }
    }
}
