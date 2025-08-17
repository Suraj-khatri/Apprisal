<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="DynamicBranchRpt.aspx.cs" Inherits="SwiftHrManagement.web.Report.DynamicBranchRpt" %>
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
                                    <asp:Label ID="lbldesc"  Text="test it " runat="server"></asp:Label></strong></font><br />  
                                </font>
                                <font size="-1"><strong>
                                    <asp:Label ID="lbldesc0"  Text="Company Summary Report" runat="server"></asp:Label>
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
