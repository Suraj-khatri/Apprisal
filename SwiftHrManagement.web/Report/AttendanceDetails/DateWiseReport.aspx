<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="DateWiseReport.aspx.cs" Inherits="SwiftHrManagement.web.Report.AttendanceDetails.DateWiseReport" Title="Swift HRM" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <div class="panel">
        <div class="panel-body">
            <div class="row">
                <div class="col-md-12 col-sm-12">
                    <section class="panel">
                        <div class="panel-body">
                            <div class="form-group" align="center">
                                <strong><font size="+1">
                                    <asp:Label ID="lblHeading" Text= "myHeading" runat="server"></asp:Label><br />
                                    <asp:Label ID="lbldesc"  Text="test it " runat="server"></asp:Label>
                                </font></strong>
                                <font size="-1"><strong>
                                    <asp:Panel ID="summaryReport" runat="server" Visible="false">
                                        <span class="style10">Attendence Report From: </span> 
                                        <asp:Label ID="lblFromDate"  Text="test it " runat="server"></asp:Label> 
                                        <span class="style10"> To: </span>
                                        <asp:Label ID="lblToDate"  Text="test" runat="server"></asp:Label>
                                    </asp:Panel>
                                    <asp:Panel ID="DailyReport" runat="server" Visible="false">                          
                                        <span class="style10">Daily Attendence Report on: </span>  
                                        <asp:Label ID="lblReportDate"  Text="test it " runat="server"></asp:Label> 
                                    </asp:Panel></strong></font>
                            </div>
                            <div id="rptDiv" runat="server"></div>   
                        </div>
                    </section>
                </div>
            </div>
            <asp:HiddenField ID="Hdnflag" runat="server" />
        </div>
    </div>
</asp:Content>
