<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="SwiftHrManagement.web.LeaveManagementModule.Deduction.List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript" language="javascript">
    function IsUnpaidApprove(id) {
        if (confirm("Confirm To Approve?")) {
            document.getElementById("<% =hdnLeaveId.ClientID %>").value = id;
          
            var moneyIndex = document.getElementById("amt_" + id);
            var moneyValue = moneyIndex.value;
            document.getElementById("<% =hdnAmt.ClientID%>").value = moneyValue;
            document.getElementById("<% =btnLeaveApprove.ClientID %>").click();            
        }
    }
    function OnReject(id) {
        if (confirm("Confirm To Reject?")) {
            document.getElementById("<% =hdnLeaveId.ClientID %>").value = id;
            document.getElementById("<% =btnReject.ClientID %>").click();
        }
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">

<asp:HiddenField ID="hdnLeaveId" runat="server" />
<asp:HiddenField ID="hdnAmt" runat="server" />
<asp:Button ID="btnLeaveApprove" runat="server" Text="Button" onclick="btnLeaveApprove_Click" style="display:none;"/>
<asp:Button ID="btnReject" runat="server" Text="Button" onclick="btnReject_Click" style="display:none;"/>

<table border="0" align="center">
    <tr>
        <td>
            <div align="center">
                <asp:Label ID="Lblcompany" Text= "Company" runat="server" CssClass="ReportHeader"></asp:Label><br />
                <asp:Label ID="LblDesc"  Text="Description" runat="server" CssClass="ReportSubHeader"></asp:Label><br />  
                <div class="txtlbl">Unpaid Leave & Absent Details From                                                
                    <asp:Label ID="lblFromDate"  runat="server" CssClass="ReportSubHeader"></asp:Label> To
                    <asp:Label ID="lblToDate" runat="server" CssClass="ReportSubHeader"></asp:Label><br />
                </div>                                  
            </div>                             
        </td>   
    </tr>
    <tr>
        <td><div class="txtlbl">Unpaid leave History</div></td>
    </tr>
    <tr>
        <td><div id="rptDivLeave" runat="server"></div></td>
    </tr>
    <tr>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td><div class="txtlbl">Employee Absent History</div></td>
    </tr>
    <tr>
        <td><div id="rptDivAbsent" runat="server"></div></td>
    </tr>
    <tr>
        <td>&nbsp;</td>
    </tr>
</table>
</asp:Content>
