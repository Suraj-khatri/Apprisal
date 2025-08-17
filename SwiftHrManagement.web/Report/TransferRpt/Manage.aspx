<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SwiftHRManager.Master" CodeBehind="Manage.aspx.cs" Inherits="SwiftHrManagement.web.Report.TransferRpt.Manage" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <div class="row">
        <div class="col-md-8 col-md-offset-2">
            <section class="panel">     
                <header class="panel-heading">
                    <i class="fa fa-caret-right"></i>
                   Date Wise Transfer Report
                </header>
                <div class="panel-body">
                    <div class="form-group">
                        <label>From Date:<span class="errormsg">*</span></label>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator1"  runat="server" ValidationGroup="datewiserpt" 
                             ControlToValidate ="txtFrmDate" ErrorMessage="Required!" SetFocusOnError="True">
                         </asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtFrmDate" runat="server"  CssClass="form-control"></asp:TextBox>
                        <cc1:CalendarExtender ID="txtFromDate1_CalendarExtender" runat="server" 
                            Enabled="True" TargetControlID="txtFrmDate">
                        </cc1:CalendarExtender>                       
                    </div>
                    <div class="form-group">
                        <label>To Date:<span class="errormsg">*</span></label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="datewiserpt" 
                            ControlToValidate ="txtToDate" ErrorMessage="Required!" SetFocusOnError="True">
                        </asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtToDate" runat="server"  CssClass="form-control"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" 
                            Enabled="True" TargetControlID="txtToDate">
                        </cc1:CalendarExtender>                        
                    </div>
                    <div class="form-group">
                        <label>Transfer Type:</label>
                        <asp:DropDownList ID="ddlTransferType" runat="server"  CssClass="form-control">
                            <asp:ListItem Value="">All</asp:ListItem>
                            <asp:ListItem Value="i">Internal</asp:ListItem>
                            <asp:ListItem Value="e">External</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label>Branch:</label>
                        <asp:DropDownList ID="ddlBranch" runat="server"  CssClass="form-control" 
                             onselectedindexchanged="ddlBranch_SelectedIndexChanged" 
                            AutoPostBack="True"></asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label>Department:</label>
                        <asp:DropDownList ID="ddlDepartment" runat="server"  CssClass="form-control" 
                            onselectedindexchanged="ddlDepartment_SelectedIndexChanged" 
                            AutoPostBack="True">                   
                        </asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label>Employee:</label>
                        <asp:DropDownList ID="ddlEmployee" runat="server"  CssClass="form-control" 
                            onselectedindexchanged="ddlEmployee_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <asp:Button ID="btnViewReport" runat="server" onclick="btnViewReport_Click" CssClass="btn btn-primary" 
                            ValidationGroup="datewiserpt" Text="View Report" />
                    </div>
                </div>
            </section>
        </div>
    </div>
</asp:Content>
