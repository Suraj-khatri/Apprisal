<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="LeaveReportYearWise.aspx.cs" Inherits="SwiftHrManagement.web.Report.Leave.LeaveReportYearWise" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <div class="panel">
        <div class="panel-body">
            <div class="row">
                <div class="col-md-12">
                    <section class="panel">
                        <div class="panel-body">
                            <div class="form-group" align="center">
                                <strong><font size="+1">
                                    <asp:Label ID="lblHeading" Text= "myHeading" runat="server"></asp:Label><br />
                                   </font></strong>
                                   <font size="-1"><strong>
                                 <asp:Label ID="lbldesc"  Text="test it " runat="server"></asp:Label></strong></font>
                                
                                <center>
                                    <b>                                       
                                        Leave Year: <asp:Label ID="lblYear"  runat="server" CssClass="txtlbl"></asp:Label></b></center>
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
