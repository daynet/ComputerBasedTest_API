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
                  //  int psid = 45;
                   int psid = Int32.Parse(Request.QueryString["psid"]);

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

            var JudgingDetails = ss.getJudging(psid);
           // this.ReportViewer.LocalReport.DataSources.Clear();
            ReportDataSource judgingDataSource = new ReportDataSource();
            judgingDataSource.Value = JudgingDetails;
            judgingDataSource.Name = "Judging";

            var sensitiveDetails = ss.getSensitive(psid);
           // this.ReportViewer.LocalReport.DataSources.Clear();
            ReportDataSource sensitiveDataSource = new ReportDataSource();
            sensitiveDataSource.Value = sensitiveDetails;
            sensitiveDataSource.Name = "Sensitive";


            var rating = ss.Rating(psid);
            // this.ReportViewer.LocalReport.DataSources.Clear();
            ReportDataSource ratingDataSource = new ReportDataSource();
            ratingDataSource.Value = rating;
            ratingDataSource.Name = "Rating";


            var statistic = ss.explicitValue(psid);
            // this.ReportViewer.LocalReport.DataSources.Clear();
            ReportDataSource statDataSource = new ReportDataSource();
            statDataSource.Value = statistic;
            statDataSource.Name = "Statistic";

            var xteristic1 = ss.getCharacteristics(psid);
            // this.ReportViewer.LocalReport.DataSources.Clear();
            ReportDataSource charDataSource = new ReportDataSource();
            charDataSource.Value = xteristic1;
            charDataSource.Name = "Strengths";

            var keyCharacteristic = ss.getKeyCharacteristics(psid);
            // this.ReportViewer.LocalReport.DataSources.Clear();
            ReportDataSource keyCharDataSource = new ReportDataSource();
            keyCharDataSource.Value = keyCharacteristic;
            keyCharDataSource.Name = "KeyCharacteristic";

            var relationship = ss.getRelationship(psid);
            // this.ReportViewer.LocalReport.DataSources.Clear();
            ReportDataSource relateDataSource = new ReportDataSource();
            relateDataSource.Value = relationship;
            relateDataSource.Name = "Relationship";

            var potential = ss.getPotentials(psid);
            // this.ReportViewer.LocalReport.DataSources.Clear();
            ReportDataSource potentDataSource = new ReportDataSource();
            potentDataSource.Value = potential;
            potentDataSource.Name = "Potential";

            var Ideas = ss.getIdeas(psid);
            // this.ReportViewer.LocalReport.DataSources.Clear();
            ReportDataSource ideasDataSource = new ReportDataSource();
            ideasDataSource.Value = Ideas;
            ideasDataSource.Name = "CareerIdeas";

            var Stress = ss.getStress(psid);
            // this.ReportViewer.LocalReport.DataSources.Clear();
            ReportDataSource stressDataSource = new ReportDataSource();
            stressDataSource.Value = Stress;
            stressDataSource.Name = "StressManagement";










            ReportViewer.LocalReport.DataSources.Add(studentDataSource);
            ReportViewer.LocalReport.DataSources.Add(introvertDataSource);
            ReportViewer.LocalReport.DataSources.Add(thinkingDataSource);
            ReportViewer.LocalReport.DataSources.Add(judgingDataSource);
            ReportViewer.LocalReport.DataSources.Add(sensitiveDataSource);
            ReportViewer.LocalReport.DataSources.Add(ratingDataSource);
            ReportViewer.LocalReport.DataSources.Add(statDataSource);
            ReportViewer.LocalReport.DataSources.Add(charDataSource);
            ReportViewer.LocalReport.DataSources.Add(keyCharDataSource);
            ReportViewer.LocalReport.DataSources.Add(relateDataSource); 
            ReportViewer.LocalReport.DataSources.Add(potentDataSource);
            ReportViewer.LocalReport.DataSources.Add(ideasDataSource);
            ReportViewer.LocalReport.DataSources.Add(stressDataSource);



            this.ReportViewer.LocalReport.ReportPath = Server.MapPath("~/Report/RDLC/Scoresheet.rdlc");
            ReportViewer.LocalReport.Refresh();






        }
    }
}