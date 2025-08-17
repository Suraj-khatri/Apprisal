<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="LeaveSummary.aspx.cs" Inherits="SwiftHrManagement.web.Report.Leave.LeaveSummary" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
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
                                <asp:Panel ID="Report_History" runat="server">
                                 <strong>Leave Report</strong>
                                </asp:Panel>
                                <asp:Panel ID="Report_Summary" runat="server" Visible="false">
                                    <strong>Leave Summary Report</strong> 
                                </asp:Panel>
                                 
                                <center>
                                    <b>                                       
                                        From Date: <asp:Label ID="From_Date"  runat="server" CssClass="txtlbl"></asp:Label> 
                                        To Date: <asp:Label ID="To_Date" runat="server" CssClass="txtlbl"></asp:Label> 

                                    </b></center>
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
