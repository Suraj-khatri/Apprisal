<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="AttendanceTimeWiseRpt.aspx.cs" Inherits="SwiftHrManagement.web.Report.AttendanceDetails.AttendanceTimeWiseRpt" Title="" %>
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
                                    <asp:Label ID="lbldesc"  Text="test it " runat="server"></asp:Label><br />
                                </font>
                                <font size="-1"><strong>
                                    Attendence <asp:Label ID="lblrptNature" runat="server" CssClass="txtlbl"></asp:Label><br /> Report From:
                                    <asp:Label ID="lblFromDate"  Text="test it " runat="server"></asp:Label> 
                                    To:
                                    <asp:Label ID="lblToDate"  Text="test" runat="server"></asp:Label></strong></font>
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
