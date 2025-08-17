<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="LeaveDetailedDatewise.aspx.cs" Inherits="SwiftHrManagement.web.Report.Leave.LeaveDetailedDatewise" %>
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
                                 <asp:Label ID="lbldesc"  Text="test it " runat="server"></asp:Label><br />
                                 Leave Detailed Report
                                 </strong></font>
                                <center>
                                    <b>                                       
                                        From Date: <asp:Label ID="lblFromDate"  runat="server" CssClass="txtlbl"></asp:Label> 
                                        To Date: <asp:Label ID="lblTodate" runat="server" CssClass="txtlbl"></asp:Label> 

                                    </b></center>
                            </div>
                            <div id="rptDiv" runat="server">
                            </div>
                        </div>
                    </section>
                </div>
            </div>
            <asp:HiddenField ID="Hdnflag" runat="server" />
        </div>
    </div>
</asp:Content>
