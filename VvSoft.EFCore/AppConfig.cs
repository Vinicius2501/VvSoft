using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VvSoft.EFCore
{
    public static class AppConfig
    {
        public static string GetConnection()
        {
            return "Data Source=<secret>;Initial Catalog=<secret>;Integrated Security=True;TrustServerCertificate=True;";
        }
    }
}
