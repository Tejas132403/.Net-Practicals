using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

// When SAP Crystal Reports for Visual Studio is installed, uncomment:
// using CrystalDecisions.CrystalReports.Engine;

namespace PlacementDashboard
{
    public partial class Report : System.Web.UI.Page
    {
        string cs = ConfigurationManager
            .ConnectionStrings["PlacementConnection"]
            .ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadReportData();

                /*
                // =========================================================
                // Crystal Reports Integration Code:
                // (Requires SAP Crystal Reports Runtime & Assemblies)
                // =========================================================
                ReportDocument report = new ReportDocument();
                report.Load(Server.MapPath("~/Reports/PlacementReport.rpt"));
                CrystalReportViewer1.ReportSource = report;
                Session["PlacementReport"] = report;
                */
            }
        }

        private void LoadReportData()
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                string query = "SELECT Id, StudentName, CompanyName, JobRole, Package FROM Placements";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                gvReport.DataSource = dt;
                gvReport.DataBind();
            }
        }

        protected void Page_Unload(object sender, EventArgs e)
        {
            // ReportDocument lifetime and disposal should be
            // managed according to the application's report
            // viewer lifecycle and Crystal Reports version.
            /*
            if (Session["PlacementReport"] != null)
            {
                var report = Session["PlacementReport"] as ReportDocument;
                if (report != null)
                {
                    report.Close();
                    report.Dispose();
                }
            }
            */
        }
    }
}
