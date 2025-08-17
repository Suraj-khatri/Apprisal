<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="EmpSupReport.aspx.cs" Inherits="SwiftHrManagement.web.Report.EmployeeDetails.EmpSupReport" %>
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
                                </font></strong>
                                <font size="-1"><strong>
                                   <asp:Label ID="lbldesc"  Text="test it " runat="server"></asp:Label></strong><br />
                                </font>
                                <font size="-1">
                                    Print Date: <asp:Label ID="lblPrintDate" runat="server" CssClass="txtlbl"></asp:Label></font>
                            </div>
                            <div id="rptDiv" runat="server"></div>   
                        </div>
                    </section>
                </div>
            </div>
        </div>
    </div>
</asp:Content>