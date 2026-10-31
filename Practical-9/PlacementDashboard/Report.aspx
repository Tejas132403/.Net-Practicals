<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Report.aspx.cs" Inherits="PlacementDashboard.Report" %>

<%-- 
    NOTE FOR SAP CRYSTAL REPORTS:
    When SAP Crystal Reports for Visual Studio is installed, register the tag prefix:
    <%@ Register Assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" 
        Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
--%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Placement Report</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            margin: 30px;
            background-color: #f4f6f9;
        }
        .container {
            max-width: 900px;
            margin: auto;
            background: white;
            padding: 30px;
            border: 1px solid #ddd;
            box-shadow: 0 2px 5px rgba(0,0,0,0.1);
        }
        h2 {
            text-align: center;
            color: #1a365d;
            border-bottom: 2px solid #1a365d;
            padding-bottom: 10px;
            margin-top: 0;
        }
        .info-box {
            background-color: #e8f4fd;
            border-left: 4px solid #007bff;
            padding: 12px;
            margin-bottom: 20px;
            font-size: 14px;
        }
        .report-table {
            width: 100%;
            border-collapse: collapse;
            margin-top: 15px;
        }
        .report-table th {
            background-color: #2b6cb0;
            color: white;
            text-align: left;
            padding: 12px;
            font-size: 14px;
        }
        .report-table td {
            padding: 10px 12px;
            border-bottom: 1px solid #e2e8f0;
            font-size: 14px;
        }
        .report-table tr:nth-child(even) {
            background-color: #f7fafc;
        }
        .back-link {
            display: inline-block;
            margin-top: 25px;
            padding: 8px 16px;
            background-color: #4a5568;
            color: white;
            text-decoration: none;
            border-radius: 4px;
        }
        .back-link:hover {
            background-color: #2d3748;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2>STUDENT PLACEMENT REPORT</h2>
            
            <div class="info-box">
                <strong>Placement Report Status:</strong> Active Data Source: <code>PlacementDB.dbo.Placements</code><br />
                <em>Crystal Report File: <code>~/Reports/PlacementReport.rpt</code></em>
            </div>

            <!-- Report Grid View matching Crystal Report tabular layout -->
            <asp:GridView ID="gvReport" runat="server" AutoGenerateColumns="False" CssClass="report-table" GridLines="None">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="ID" />
                    <asp:BoundField DataField="StudentName" HeaderText="Student Name" />
                    <asp:BoundField DataField="CompanyName" HeaderText="Company" />
                    <asp:BoundField DataField="JobRole" HeaderText="Job Role" />
                    <asp:BoundField DataField="Package" HeaderText="Package" />
                </Columns>
            </asp:GridView>

            <%-- 
                ============================================================
                SAP Crystal Reports CrystalReportViewer control markup:
                When SAP Crystal Reports is installed on the machine, uncomment:
                <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" />
                ============================================================
            --%>

            <br />
            <a href="Default.aspx" class="back-link">&larr; Back to Dashboard</a>
        </div>
    </form>
</body>
</html>
