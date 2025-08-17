<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="ManageReport.aspx.cs" Inherits="SwiftHrManagement.web.MedicalClaim.ManageReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">


    <div class="row">
        <div class="col-lg-6 col-md-offset-3">
            <section class="panel">
                        <header class="panel-heading">
                         Manage Medical Claim Report 
                        </header>
                        <div class="panel-body">
                            <div class="form-group">
                                 <label> From Date:<span class="required">*</span></label> 
            <asp:TextBox ID="txtFromDate" runat="server" CssClass="form-control" 
                    ValidationGroup="summary"></asp:TextBox>
                <cc1:CalendarExtender ID="txtFromDate_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="txtFromDate">
                </cc1:CalendarExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="txtFromDate" Display="Dynamic" ErrorMessage="Required!" 
                    SetFocusOnError="True" ValidationGroup="summary"></asp:RequiredFieldValidator>
                                
                                 <div class="form-group">
                                 <label>To Date: <span class="required">*</span></label> 
           
            <<asp:TextBox ID="txtToDate" runat="server" CssClass="form-control" 
                    ValidationGroup="summary"></asp:TextBox>
                <cc1:CalendarExtender ID="txtToDate_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="txtToDate">
                </cc1:CalendarExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                    ControlToValidate="txtToDate" Display="Dynamic" ErrorMessage="Required!" 
                    SetFocusOnError="True" ValidationGroup="summary"></asp:RequiredFieldValidator>
            </div>
                                 <div class="form-group">
                                 <label>Claim Type :</label> 
                <asp:DropDownList ID="ddlClaimType" runat="server" CssClass="form-control" Width="150px">
                <asp:ListItem Value="">All</asp:ListItem>
                <asp:ListItem Value="Bank">Bank</asp:ListItem>
                <asp:ListItem Value="NLGI">NLGI</asp:ListItem>
                </asp:DropDownList>      
             </div>
                <div class="form-group">
                                 <label>Claim Status :</label> 
                <asp:DropDownList ID="ddlClaimStatus" runat="server" CssClass="form-control" Width="150px">
                <asp:ListItem Value="">All</asp:ListItem>
                <asp:ListItem Value="Requested">Requested</asp:ListItem>
                <asp:ListItem Value="On Process">On Process</asp:ListItem>
                <asp:ListItem Value="Approved">Approved</asp:ListItem>
                <asp:ListItem Value="Rejected">Rejected</asp:ListItem>
                </asp:DropDownList>      
           </div>
                                <div class="form-group">
                <asp:Button ID="btnShow" runat="server" CssClass="btn btn-primary"  Text=" Search " 
                    ValidationGroup="summary" OnClientClick="return showReport();" />
      
           </div>
                                </div>
                                </div>
                </section>
        </div>
    </div>



    <script type="text/javascript">
        function showReport() {

            if (!Page_ClientValidate('summary'))
                return false;
            var fromDate = GetDateValue("<% =txtFromDate.ClientID%>");
                var toDate = GetDateValue("<% =txtToDate.ClientID%>");
                var claimType = GetValue("<% =ddlClaimType.ClientID %>");
                var ddlClaimStatus = GetValue("<% =ddlClaimStatus.ClientID %>");
                var url = "/Report/Report.aspx?reportName=medicalreport&fromdate=" + fromDate +
                "&todate=" + toDate +
                "&claimType=" + claimType +
                "&ddlClaimStatus=" + ddlClaimStatus;

                OpenInNewWindow(url);
                return false;
            }
    </script>
</asp:Content>
