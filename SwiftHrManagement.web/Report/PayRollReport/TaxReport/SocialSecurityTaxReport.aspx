<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="SocialSecurityTaxReport.aspx.cs" Inherits="SwiftHrManagement.web.Report.PayRollReport.TaxReport.SocialSecurityTaxReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    
    <asp:UpdatePanel ID="up" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-md-12">
                    <section class="panel">
                        <div class="panel-body">
                            <div class="text-center">
                                <strong><font size="+1">
                                    <asp:Label ID="lblHeading" Text= "myHeading" runat="server"></asp:Label><br />
                                   </font></strong>
                                   <font size="-1"><strong>
                                 <asp:Label ID="lbldesc"  Text="test it " runat="server"></asp:Label></strong></font>
                                
                                <asp:Panel ID="Tax" runat="server" Visible="true">
                                    <strong>
                                
                                        <span> Social Security Tax Report </span> 
                                         <br />
                                        <span >&nbsp;Fiscal Year : </span>
                                        <asp:Label ID="lblYear" runat="server"></asp:Label>
                                        <br />
                                        <span >&nbsp;Month Name : </span>
                                        <asp:Label ID="lblMonthName" runat="server"></asp:Label>
                                     </strong>
                                </asp:Panel> 
                            </div>
                             <div id="rptDiv" runat="server"></div>    
                        </div>
                    </section>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
