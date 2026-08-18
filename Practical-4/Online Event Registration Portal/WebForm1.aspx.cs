using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Online_Event_Registration_Portal
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // Show filled values in a client-side popup when registration succeeds
            if (!Page.IsValid) return;

            string name = TextBox1 != null ? TextBox1.Text.Trim() : string.Empty;
            string enrollment = TextBox5 != null ? TextBox5.Text.Trim() : string.Empty;
            string email = TextBox6 != null ? TextBox6.Text.Trim() : string.Empty;
            string mobile = TextBox7 != null ? TextBox7.Text.Trim() : string.Empty;
            string division = TextBox8 != null ? TextBox8.Text.Trim() : string.Empty;
            string department = DropDownList2 != null ? DropDownList2.SelectedValue : string.Empty;
            string semester = DropDownList3 != null ? DropDownList3.SelectedValue : string.Empty;
            string section = DropDownList4 != null ? DropDownList4.SelectedValue : string.Empty;
            string gender = RadioButtonList1 != null ? RadioButtonList1.SelectedValue : string.Empty;
            string events = HiddenSelectedEvents != null ? HiddenSelectedEvents.Value : string.Empty;

            string message = "Registration Successful!\n\n" +
                $"Name: {name}\n" +
                $"Enrollment No: {enrollment}\n" +
                $"Email: {email}\n" +
                $"Mobile: {mobile}\n" +
                $"Department: {department}\n" +
                $"Semester: {semester}\n" +
                $"Division: {division}\n" +
                $"Section: {section}\n" +
                $"Gender: {gender}\n" +
                $"Selected Events: {events}";

            // Encode for JavaScript and show in an alert popup
            string js = $"alert('{System.Web.HttpUtility.JavaScriptStringEncode(message)}');";
            ClientScript.RegisterStartupScript(this.GetType(), "regSuccess", js, true);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            // Reset form fields to defaults
            TextBox1.Text = string.Empty;
            TextBox5.Text = string.Empty;
            TextBox6.Text = string.Empty;
            TextBox7.Text = string.Empty;
            TextBox8.Text = string.Empty;
            if (DropDownList2 != null) DropDownList2.SelectedIndex = 0;
            if (DropDownList3 != null) DropDownList3.SelectedIndex = 0;
            if (DropDownList4 != null) DropDownList4.SelectedIndex = 0;
            if (RadioButtonList1 != null) RadioButtonList1.ClearSelection();
            if (HiddenSelectedEvents != null) HiddenSelectedEvents.Value = string.Empty;
        }
    }
}