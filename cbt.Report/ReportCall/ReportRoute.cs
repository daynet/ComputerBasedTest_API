using cbt.Common;
using cbt.Report.IReport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cbt.Report.ReportCall
{
   public class ReportRoute : IReporting
    {
        string reportPath = CommonHelper.ReportPath;
        public string getScoresheet(int psid)
        {
            //HashProperty hashValue = GetHashedDateValue(dateInfor);

            string path = string.Empty;
            path = reportPath + "Form/Scoresheet.aspx?psid=" + psid.ToString();

            return path;

        }

    }
}
