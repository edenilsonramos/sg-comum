using System;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
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
        public static string GetEnderecoMAC()
        {
            try
            {
                NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
                string enderecoMAC = string.Empty;
                foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces().Where(c => c.NetworkInterfaceType == NetworkInterfaceType.Ethernet && c.Description.Contains("Virtual") == false).ToList())
                {
                    {
                        if (nic.NetworkInterfaceType == NetworkInterfaceType.Ethernet &&
                            nic.OperationalStatus == OperationalStatus.Up)
                        {
                            enderecoMAC = nic.GetPhysicalAddress().ToString();
                        }
                    }
                }
                return enderecoMAC;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
