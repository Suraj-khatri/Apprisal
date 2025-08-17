<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SwiftHRManager.Master" CodeBehind="LeaveStatusReport.aspx.cs" Inherits="SwiftHrManagement.web.Report.Leave.LeaveStatusReport" %>
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
                                    <asp:Label ID="Lblcompany" Text= "myHeading" runat="server"></asp:Label><br />
                                    </font></strong>
                                    <font size="-1"><strong>
                                    <asp:Label ID="LblDesc"  Text="test it " runat="server"></asp:Label></strong></font>
                                
                                <center><b>
                                    Branch:
                                    <asp:Label ID="lblbranch" runat="server"></asp:Label>
                                    <br />
                                    Departmant:
                                    <asp:Label ID="lbldepartmant" runat="server"></asp:Label>
                                    <br />
                                    Employee Name:
               	                    <asp:Label ID="lblEmployeeName"  runat="server"></asp:Label>
                                    <br />
               	                    <asp:Label ID="LblBsDate"  runat="server"></asp:Label>
                                    <br /></b></center>
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