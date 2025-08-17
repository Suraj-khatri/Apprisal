<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="ContriProjectionReport.aspx.cs" Inherits="SwiftHrManagement.web.Report.PayRollReport.ContriProjectionReport" Title="SWIFT HR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    
    <asp:UpdatePanel ID="up" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-md-12">
                    <section class="panel">
                        <div class="panel-body">
                            <div class="text-center"><strong><font size="+1">
                                <asp:Label ID="Lblcompany" Text= "Company" runat="server"></asp:Label></font></strong><br />
                                <font size="-1"><strong> <asp:Label ID="LblDesc"  Text="Description" runat="server"></asp:Label></strong></font><br />
                                <strong><asp:Label ID="Lblmonth"  Text="Month" runat="server"></asp:Label></strong><br />  
                                <strong><asp:Label ID="lblempname" runat="server"></asp:Label> </strong><br />   
                            </div>
                             <div id="rptDiv" runat="server"></div>    
                            <br/>
                            <div id="rptDivDesc" runat="server"></div>
                        </div>
                    </section>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
