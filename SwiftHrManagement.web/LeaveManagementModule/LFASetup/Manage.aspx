<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="SwiftHrManagement.web.LeaveManagementModule.LFASetup.Manage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">

    <asp:UpdatePanel ID="Panel1" runat="server">
        <ContentTemplate>
            <div class="form-group autocomplete-form">
                <div class="col-md-10 col-md-offset-1">
                    <div class="panel">
                        <header class="panel-heading">
                            <i class="fa fa-caret-right"></i>
                            LFA Amount Setup
                        </header>
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-md-12">
                                    <div id="rptDiv" runat="server"></div>
                                </div>
                                <div class="col-md-12">
                                    <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" Text=" Save "
                                        OnClick="btnSave_Click"></asp:Button>
                                    <asp:Label ID="lblMsg" runat="server" CssClass="txtlbl"></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
