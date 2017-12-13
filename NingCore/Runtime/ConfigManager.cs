using MingCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NingCore.Runtime
{
    public enum ConfigType
    {
        AUTHENTICATION_SERVER_CONFIG,
        REALM_SERVER_CONFIG
    }

    public class ConfigManager
    {
        private static ConfigType ct;
        private static Dictionary<string, string> configs;

        public static void LoadConfigs(ConfigType pmCT)
        {
            if (configs == null)
            {
                configs = new Dictionary<string, string>();
            }
            configs.Clear();

            ct = pmCT;
        }

        public static int GetINT(string pmName)
        {
            int result = 0;

            if (!int.TryParse(configs[pmName], out result))
            {
                MLogger.RuntimeLogger.Error("Config - " + ct.ToString() + "Get value type error : int");
            }

            return result;
        }

        public static float GetFLOAT(string pmName)
        {
            float result = 0;

            if (!float.TryParse(configs[pmName], out result))
            {
                MLogger.RuntimeLogger.Error("Config - " + ct.ToString() + "Get value type error : float");
            }

            return result;
        }

        public static double GetDOUBLE(string pmName)
        {
            double result = 0;

            if (!double.TryParse(configs[pmName], out result))
            {
                MLogger.RuntimeLogger.Error("Config - " + ct.ToString() + "Get value type error : double");
            }

            return result;
        }

        public static string GetString(string pmName)
        {
            return configs[pmName];
        }
    }
}