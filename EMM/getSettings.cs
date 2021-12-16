using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace EMM
{
    static class getSettings
    {
        static public string GetConnection(string name)
        {
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["mysql"];
            return settings.ConnectionString;
        }
    }
}
