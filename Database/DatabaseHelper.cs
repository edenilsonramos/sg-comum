using System;
using System.IO;
using System.Linq;

namespace SGComum.Database
{
    public class DatabaseHelper
    {
        private static ConnectionParams _connectionParams;

        public static ConnectionParams GetDefaultConnectionParams()
        {
            if (_connectionParams == null)
            {
                _connectionParams = new ConnectionParams();
                if (File.Exists($"{Environment.CurrentDirectory}//Certo.ini"))
                    _connectionParams.LoadFromIniFile($"{Environment.CurrentDirectory}//Certo.ini");
                else
                    _connectionParams.LoadFromIniFile($"{Environment.CurrentDirectory}//ConfigSoftMaster.ini");
            }

            return _connectionParams;
        }
        public static void SetConnectionParams(ConnectionParams aConnectionParams)
        {
            _connectionParams = aConnectionParams;
        }

        public static void Duplicar<T>(T baseModel, T newModel, string[] exceptionFields) where T : class
        {
            foreach (var field in baseModel.GetType().GetProperties().Where(p => !p.Name.ToUpper().Contains("GRID") && Array.IndexOf(exceptionFields, p.Name.ToUpper()) == -1))
            {
                newModel.GetType().GetProperty(field.Name).SetValue(newModel, baseModel.GetType().GetProperty(field.Name).GetValue(baseModel));
            }

            return;
        }
    }
}
