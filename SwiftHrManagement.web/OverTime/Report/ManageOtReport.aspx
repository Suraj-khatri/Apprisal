<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SwiftHRManager.Master" CodeBehind="ManageOtReport.aspx.cs" Inherits="SwiftHrManagement.web.OverTime.Report.ManageOtReport" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript" src="../../js/functions.js"></script>
    <script src="../../js/jquery/jquery-1.4.1.js" type="text/javascript"></script>
    <script type="text/javascript">
        function ShowReport() {
            if (!Page_ClientValidate("ot")) {
                return false;
            }
            var url = "ViewReportForOT.aspx?";
                url += "BranchId=" + GetValue("<%=DdlBranchName.ClientID %>");
                url += "&DeptId=" + GetValue("<%=DdlDeptName.ClientID %>");
                url += "&empId=" + GetValue("<%=DdlEmpName.ClientID %>"); 
                url += "&FromDate=" + GetValue("<%=txtFrom.ClientID %>");
                url += "&ToDate=" + GetValue("<%=txtTo.ClientID %>");
                OpenInNewWindow(url)
        }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
<asp:UpdatePanel ID="UpdatePanel1" runat="server" >
<ContentTemplate> 
    <div class="row">
        <div class="col-md-8 col-md-offset-2">
            <div class="panel">     
                <header class="panel-heading">
                    <i class="fa fa-caret-right"></i>
                    Over Time Report
                </header>
            </div>
            <div class="panel panel-default">
                <header class="panel-heading">
                    OT Report
                </header>
                <div class="panel-body">
                    <div class="form-group">
                            <label>Branch :</label>
                         <asp:DropDownList ID="DdlBranchName" runat="server" CssClass="form-control" AutoPostBack="True" 
                             onselectedindexchanged="DdlBranchName_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label>Department :</label>
                        <asp:DropDownList ID="DdlDeptName" runat="server" CssClass="form-control" AutoPostBack="True" 
                            onselectedindexchanged="DdlDeptName_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label>Employee :</label>
                        <asp:DropDownList ID="DdlEmpName" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label>From Date :</label>
                        <asp:TextBox ID="txtFrom" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFrom" 
                            Display="Dynamic" ErrorMessage="Required!" SetFocusOnError="True" ValidationGroup="ot"></asp:RequiredFieldValidator>       
                        <cc1:CalendarExtender ID="txtFrom_CalendarExtender" runat="server" Enabled="True" TargetControlID="txtFrom">
                        </cc1:CalendarExtender>
                    </div>
                    <div class="form-group">
                        <label>To Date :</label>
                        <asp:TextBox ID="txtTo" runat="server" CssClass="form-control"></asp:TextBox> 
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtTo" 
                            Display="Dynamic" ErrorMessage="Required!" SetFocusOnError="True" ValidationGroup="ot"></asp:RequiredFieldValidator>            
                        <cc1:CalendarExtender ID="txtTo_CalendarExtender" runat="server" Enabled="True" TargetControlID="txtTo">
                        </cc1:CalendarExtender>
                    </div>
                    <div class="form-group">
                        <asp:Button ID="Btn_ShowReport" runat="server" Text="Show Report" CssClass="btn btn-primary" ValidationGroup="ot" 
                            OnClientClick="return ShowReport();"/> <!--onclick="Btn_ShowReport_Click"-->
                        <asp:Button ID="Btn_ExportToExcel" runat="server" CssClass="btn btn-primary" ValidationGroup="ot" Visible="false"
                            Text="Export To Excel" onclick="Btn_ExportToExcel_Click" />
                    </div>
                </div>
            </div>
            <div class="panel panel-default">
                <header class="panel-heading">
                    Date Wise OT Summary Report
                </header>
                <div class="panel-body">
                    <div class="form-group">
                        <label>From Date:<span class="required">*</span></label>
                        <asp:TextBox ID="txtFromDate" runat="server" CssClass="form-control" ValidationGroup="summary"></asp:TextBox>
                        <cc1:CalendarExtender ID="txtFromDate_CalendarExtender" runat="server" Enabled="True" 
                            TargetControlID="txtFromDate"></cc1:CalendarExtender>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtFromDate" 
                            Display="Dynamic" ErrorMessage="Required!" SetFocusOnError="True" ValidationGroup="summary"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label>To Date:<span class="required">*</span></label>
                        <asp:TextBox ID="txtToDate" runat="server" CssClass="form-control" ValidationGroup="summary"></asp:TextBox>
                        <cc1:CalendarExtender ID="txtToDate_CalendarExtender" runat="server" Enabled="True" 
                            TargetControlID="txtToDate"></cc1:CalendarExtender>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtToDate"
                                Display="Dynamic" ErrorMessage="Required!" SetFocusOnError="True" ValidationGroup="summary"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                         <asp:Button ID="BtnSummaryRpt" runat="server" CssClass="btn btn-primary" onclick="BtnSummaryRpt_Click" 
                             Text=" Show Report " ValidationGroup="summary" />
                    </div>
            </div>
        </div>
    </div>
</div>  
</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>
