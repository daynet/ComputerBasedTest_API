using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cbt.Common
{
    public class CommonHelper
    {
        public static string ReportPath
        {
            get
            {
                return ConfigurationManager.AppSettings["reportPath"];
            }
        }
    }
}
