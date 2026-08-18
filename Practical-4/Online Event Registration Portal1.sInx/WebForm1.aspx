<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Online_Event_Registration_Portal.WebForm1" UnobtrusiveValidationMode="None" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 189px;
        }
        .auto-style3 {
            width: 189px;
            height: 26px;
        }
        .auto-style4 {
            height: 26px;
        }
        .auto-style5 {
            width: 269px;
        }
        .auto-style6 {
            height: 26px;
            width: 269px;
        }
        .draggable { padding:6px; margin:4px; background:#e7f3ff; border:1px solid #9ec9ff; cursor:move; width:200px }
        #dropZone { min-height:60px; padding:8px; border:2px dashed #bbb; background:#fafafa; width:220px }
    </style>
    <script type="text/javascript">
        // @ts-nocheck
        function dragStart(ev) {
            ev.dataTransfer.setData('text/plain', ev.target.dataset.value);
        }

        function allowDrop(ev) {
            ev.preventDefault();
        }

        function dropItem(ev) {
            ev.preventDefault();
            var value = ev.dataTransfer.getData('text/plain');
            if (!value) return;
            var dropZone = document.getElementById('dropZone');
            // prevent duplicates
            if (Array.from(dropZone.querySelectorAll('.d-item')).some(function(n){return n.dataset.value===value})) return;
            var div = document.createElement('div');
            div.className = 'd-item';
            div.dataset.value = value;
            div.textContent = value;
            dropZone.appendChild(div);
            updateHidden();
        }

        function updateHidden() {
            var dropZone = document.getElementById('dropZone');
            var items = Array.from(dropZone.querySelectorAll('.d-item')).map(function(n){return n.dataset.value});
            // Guard the server-side expression to avoid NullReference during render if the control is missing
            var hidden = document.getElementById('<%= (HiddenSelectedEvents != null ? HiddenSelectedEvents.ClientID : "") %>');
            if (!hidden) return; // nothing to update on the client
            if (hidden) hidden.value = items.join(',');
        }

        function clearSelection() {
            var dropZone = document.getElementById('dropZone');
            while (dropZone.firstChild) dropZone.removeChild(dropZone.firstChild);
            updateHidden();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            ONLINE EVENT REGISTRATION</div>
&nbsp;<table class="auto-style1">
            <tr>
                <td class="auto-style2">Student Name :</td>
                <td class="auto-style5"><asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="Name is required" Display="Dynamic" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Enrollment No :
            </td>
                <td class="auto-style5">
                    <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox5" ErrorMessage="En no is require" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Email :</td>
                <td class="auto-style5">
                    <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox6" ErrorMessage="Email is Require" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Mobile Number :</td>
                <td class="auto-style5">
                    <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox7" ErrorMessage="Enter mobile no" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Department :</td>
                <td class="auto-style5">
                    <asp:DropDownList ID="DropDownList2" runat="server">
                        <asp:ListItem>SELECT</asp:ListItem>
                        <asp:ListItem>CE</asp:ListItem>
                        <asp:ListItem>CSE</asp:ListItem>
                        <asp:ListItem>IT</asp:ListItem>
                        <asp:ListItem>ICT</asp:ListItem>
                        <asp:ListItem>EC</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="DropDownList2" ErrorMessage="select department" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Semester:</td>
                <td class="auto-style5">
                    <asp:DropDownList ID="DropDownList3" runat="server">
                        <asp:ListItem>SELECT</asp:ListItem>
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                        <asp:ListItem>6</asp:ListItem>
                        <asp:ListItem>7</asp:ListItem>
                        <asp:ListItem>8</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="DropDownList3" ErrorMessage="select your sem" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Division:</td>
                <td class="auto-style5">
                    <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="TextBox8" ErrorMessage="select your department" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Event:</td>
                <td class="auto-style5">
                    <asp:DropDownList ID="DropDownList4" runat="server">
                        <asp:ListItem>SELECT</asp:ListItem>
                        <asp:ListItem>KBC</asp:ListItem>
                        <asp:ListItem>Back to Bachapan</asp:ListItem>
                        <asp:ListItem>Treasure Hunt</asp:ListItem>
                        <asp:ListItem>Tech Hunt</asp:ListItem>
                        <asp:ListItem>Tech quiz</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="DropDownList4" ErrorMessage="select any Event" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Gender:</td>
                <td class="auto-style5">
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True">
                        <asp:ListItem>Male</asp:ListItem>
                        <asp:ListItem>Female</asp:ListItem>
                        <asp:ListItem>Other</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="RadioButtonList1" ErrorMessage="Select your gender" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style5">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3"></td>
                <td class="auto-style6"></td>
                <td class="auto-style4"></td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style5">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style5">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style5">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style5">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Register" Width="225px" />
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Reset" Width="216px" />
        <br />
        <br />
        <asp:HiddenField ID="HiddenSelectedEvents" runat="server" />
    </form>
</body>
</html>
