<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PlacementDashboard._Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Placement Dashboard</title>
    <style>
        body {
            font-family: Arial;
            margin: 30px;
            background-color: #f4f6f9;
        }
        h1 {
            color: darkblue;
        }
        .card {
            background-color: white;
            padding: 20px;
            margin-bottom: 20px;
            border: 1px solid #ddd;
        }
        .button {
            padding: 10px 20px;
            margin-top: 15px;
            background-color: #007bff;
            color: white;
            border: none;
            cursor: pointer;
            border-radius: 4px;
        }
        .button:hover {
            background-color: #0056b3;
        }
        .grid {
            background-color: white;
            width: 100%;
        }
        .report-link {
            display: inline-block;
            margin-top: 10px;
            color: #007bff;
            text-decoration: underline;
            font-weight: bold;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Placement Dashboard</h1>

        <div class="card">
            <h3>Total Students Placed</h3>
            <asp:Label ID="lblTotal" runat="server" Font-Size="XX-Large" ForeColor="Green">
            </asp:Label>
        </div>

        <div class="card">
            <h2>Student Placement Details</h2>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="true" CssClass="grid" CellPadding="10" BorderWidth="1">
            </asp:GridView>
        </div>

        <div class="card">
            <h2>Placement Report</h2>
            <asp:Button ID="btnReport" runat="server" Text="Generate Crystal Report" CssClass="button" OnClick="btnReport_Click" />
            <br /><br />
            <asp:Label ID="lblMessage" runat="server" ForeColor="Red">
            </asp:Label>
            <br /><br />
            <asp:HyperLink ID="lnkReport" runat="server" NavigateUrl="~/Report.aspx" Text="View Placement Report Page" CssClass="report-link" />
        </div>
    </form>
</body>
</html>
