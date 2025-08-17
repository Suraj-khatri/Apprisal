<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="Inv_consolidated_report.aspx.cs" Inherits="SwiftHrManagement.web.Report.PayRollReport.Inv_consolidated_report" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">

    <asp:UpdatePanel ID="up" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-md-8 col-md-offset-2">
                    <section class="panel">
                        <div class="panel-body">
                            <div class="text-center">
                                <strong><font size="+1">
                                <asp:Label ID="Lblcompany" Text= "Company" runat="server" ></asp:Label>
                                    </font></strong>
                                    <br />
                                <strong><asp:Label ID="LblDesc"  Text="Description" runat="server" ></asp:Label><br />                                                        
                                <asp:Label ID="Lblmonth"  Text="Month" runat="server" ></asp:Label><br />
                                <asp:Label ID="lblBranchName" runat="server" ></asp:Label><br /> </strong>
                            </div>
                             <div id="rptDiv" runat="server"></div>    
                        </div>
                    </section>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
