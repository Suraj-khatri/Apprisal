<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="DetailedRpt.aspx.cs" Inherits="SwiftHrManagement.web.Report.TrainingRpt.DetailedRpt" %>
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
                                    </font>
                                    <font size="-1">
                                        <asp:Label ID="lbldesc"  Text="test it " runat="server"></asp:Label></font>
                                </strong>
                                <center>
                                    <asp:Panel ID="Leave_TypeDetails" runat="server" Visible="true">  
                                    <strong>
                                        <asp:Label ID="lblSubDesc" runat="server"></asp:Label>
                                    </strong>
                                    <strong><br />
                                      Training Detailed Date Wise Report <br /> From Date <asp:Label ID="lblFromDate" runat="server" CssClass="txtlbl"></asp:Label>  
                                      To <asp:Label ID="lblToDate" runat="server" CssClass="txtlbl"></asp:Label>  <br />                  
                                      Print Date: <asp:Label ID="lblDate" runat="server" CssClass="txtlbl"></asp:Label>
                                    </strong>
                                    </asp:Panel>
                                    <br /></center>
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
