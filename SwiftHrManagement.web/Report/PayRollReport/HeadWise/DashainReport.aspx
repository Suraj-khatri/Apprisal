<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true"
    CodeBehind="DashainReport.aspx.cs" Inherits="SwiftHrManagement.web.Report.PayRollReport.HeadWise.DashainReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">

    <div class="row">
        <div class="col-lg-6 col-md-offset-3">
            <section class="panel">
            <header class="panel-heading">
                <i class="fa fa-caret-right" aria-hidden="true"></i> 
                           Dashain Allowance
                        </header>
            <div class="panel-body">
                <div class="form-group">
                    <label>Fiscal Year : <span class="errormsg">*</span></label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic"
                        ControlToValidate="DdlFiscalYear"
                        SetFocusOnError="True" ErrorMessage="Required" ValidationGroup="contribution"></asp:RequiredFieldValidator>
                    <asp:DropDownList ID="DdlFiscalYear" runat="server" CssClass="form-control"
                        Width="250px">
                    </asp:DropDownList>
                    
                </div>
                <div class="form-group">
                    <asp:Button ID="BtnSearch" runat="server" CssClass="btn btn-primary" Text="Search"
                        ValidationGroup="contribution" OnClick="BtnSearch_Click" />
                </div>
            </div>
                </section>
        </div>
    </div>
</asp:Content>
