using cbt.Report;
using cbt.viewModel.CBT;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace cbt.api.Report.Form
{
    public partial class Scoresheet : System.Web.UI.Page
    {
        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    if (!IsPostBack)
        //    {
        //        try
        //        {
        //            int psid = Int32.Parse(Request.QueryString["psid"]);                  
                    
        //            ScoreSheet resheet = new ScoreSheet();
        //            var data = resheet.getProspectiveStudentDetails(psid);



        //            this.ReportViewer.LocalReport.DataSources.Clear();
        //            ReportDataSource reportDataSource = new ReportDataSource();
        //            reportDataSource.Value = data;
        //            reportDataSource.Name = "StudentDetails";

        //            //ReportParameter sDate = new ReportParameter("startDate", startDate.ToString());
        //            //ReportParameter eDate = new ReportParameter("endDate", endDate.ToString());

        //            this.ReportViewer.LocalReport.DataSources.Add(reportDataSource);
        //            this.ReportViewer.LocalReport.ReportPath = Server.MapPath("~/Report/RDLC/Scoresheet.rdlc");
        //            //ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { sDate, eDate });
        //            ReportViewer.LocalReport.Refresh();
        //        }
        //        catch (Exception ex)
        //        {
        //            this.ReportViewer.LocalReport.ReportPath = Server.MapPath("~/Report/RDLC/error.rdlc");
        //            this.ReportViewer.LocalReport.Refresh();
        //            return;
        //        }
        //    }
        //}


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    int psid = 6;
                  // psid = Int32.Parse(Request.QueryString["psid"]);

                    GenerateScoreSheet(psid);


                }
                catch (Exception ex)
                {
                    //throw new Exception(ex.Message);
                    this.ReportViewer.LocalReport.ReportPath = Server.MapPath("~/Report/RDLC/error.rdlc");
                    this.ReportViewer.LocalReport.Refresh();
                    return;
                }
            }

        }

        void GenerateScoreSheet(int psid)
        {
            ScoreSheet ss = new ScoreSheet();


            var studentDeatails = ss.getProspectiveStudentDetails(psid);
            this.ReportViewer.LocalReport.DataSources.Clear();
            ReportDataSource studentDataSource = new ReportDataSource();
            studentDataSource.Value = studentDeatails;
            studentDataSource.Name = "StudentDetails";

            var IntrovertDetails = ss.getIntrovert(psid);
           // this.ReportViewer.LocalReport.DataSources.Clear();
            ReportDataSource introvertDataSource = new ReportDataSource();
            introvertDataSource.Value = IntrovertDetails;
            introvertDataSource.Name = "Introvert";

            var thinkingDetails = ss.getThinking(psid);
           // this.ReportViewer.LocalReport.DataSources.Clear();
            ReportDataSource thinkingDataSource = new ReportDataSource();
            thinkingDataSource.Value = thinkingDetails;
            thinkingDataSource.Name = "Thinking";

            var JudgingDetails = ss.getThinking(psid);
           // this.ReportViewer.LocalReport.DataSources.Clear();
            ReportDataSource judgingDataSource = new ReportDataSource();
            judgingDataSource.Value = JudgingDetails;
            judgingDataSource.Name = "Judging";

            var sensitiveDetails = ss.getThinking(psid);
           // this.ReportViewer.LocalReport.DataSources.Clear();
            ReportDataSource sensitiveDataSource = new ReportDataSource();
            sensitiveDataSource.Value = sensitiveDetails;
            sensitiveDataSource.Name = "Sensitive";


           

            ReportViewer.LocalReport.DataSources.Add(studentDataSource);
            ReportViewer.LocalReport.DataSources.Add(introvertDataSource);
            ReportViewer.LocalReport.DataSources.Add(thinkingDataSource);
            ReportViewer.LocalReport.DataSources.Add(judgingDataSource);
            ReportViewer.LocalReport.DataSources.Add(sensitiveDataSource);

            this.ReportViewer.LocalReport.ReportPath = Server.MapPath("~/Report/RDLC/Scoresheet.rdlc");
            ReportViewer.LocalReport.Refresh();






        }
    }
}