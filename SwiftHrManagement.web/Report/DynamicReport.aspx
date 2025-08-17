<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="DynamicReport.aspx.cs" Inherits="SwiftHrManagement.web.Report.DynamicReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
<asp:UpdatePanel ID ="pnlreport" runat ="server" >
    <ContentTemplate>
            <div class="row">
            <div class="col-md-8 col-md-offset-2">
                <section class="panel">     
                    <header class="panel-heading">
                        <i class="fa fa-caret-right"></i>
                        Company Information Report
                    </header>
                    <div class="panel-body">
                    <div class="form-group">
                        <label> Dynamic Report For :</label>
                        <asp:DropDownList ID="DdlDynamicRpt" runat="server" CssClass="form-control" AutoPostBack="True" 
                            onselectedindexchanged="DdlDynamicRpt_SelectedIndexChanged">
                        <asp:ListItem Value="Select">Select</asp:ListItem>
                        <asp:ListItem Value="Branches">Branches</asp:ListItem>
                        <asp:ListItem Value="Departments">Departments</asp:ListItem>
                        <asp:ListItem Value="Company">Company</asp:ListItem>
                        <asp:ListItem Value="Employee">Employee</asp:ListItem>
                        <asp:ListItem Value="Insurance">Insurance</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <asp:Button ID="btnShowReport" Text="Show Report" runat="server" onclick="btnShowReport_Click" 
                            CssClass="btn btn-primary" />     
                        <asp:Button ID="btnExportToExcel" Text=" Export To Excel " runat="server" CssClass="btn btn-primary" 
                            onclick="btnExportToExcel_Click" />
                    </div>
                        <div class="form-group">
                            <asp:Table ID="tblMain" runat="server" CellPadding="0" CellSpacing="0"></asp:Table>
                        </div>
                    <div class="form-group">
                        <div id="rptDiv" runat="server"></div>
                    </div>
                </div>
            </section>
        </div>
    </div>        
</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>
   

