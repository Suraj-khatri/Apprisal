<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="BranchWiseEmployeeReport.aspx.cs" Inherits="SwiftHrManagement.web.Report.EmployeeDetails.BranchWiseEmployeeReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <div class="panel">
        <div class="panel-body">
            <section class="panel">
                <div class="row">
                    <div class="col-md-12 col-sm-12">
                        <div align="center">
                            <strong>
                                <font size="+1">
                                    <asp:Label ID="lblHeading" Text= "myHeading" runat="server"></asp:Label><br />
                                </font>
                                <font size="-1">
                                    <asp:Label ID="lbldesc"  Text="test it " runat="server"></asp:Label>
                                </font>
                            </strong>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12 col-sm-12" align="center">
                        <asp:Panel ID="Leave_TypeDetails" runat="server" Visible="true">  
                            <strong>
                                <asp:Label ID="lblSubDesc" runat="server"></asp:Label>
                            </strong>
                            <strong>
                                Employee List as of <asp:Label ID="lblDate" runat="server"></asp:Label>
                            </strong>
                        </asp:Panel> 
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12 col-sm-12">
                        <div id="rptDiv" runat="server"></div>
                    </div>
                </div>
        </section>
        </div>
    </div>
</asp:Content>
