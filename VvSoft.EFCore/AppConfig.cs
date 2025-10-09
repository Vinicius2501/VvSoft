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
            return "Data Source=vinicius\\sqlexpress;Initial Catalog=VvSoftDataBase;Integrated Security=True;TrustServerCertificate=True;";
        }
}
}