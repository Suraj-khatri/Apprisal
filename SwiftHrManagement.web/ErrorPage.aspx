<%@ Page Title="" Language="C#" MasterPageFile="~/Apprisal.Master" AutoEventWireup="true" CodeBehind="ErrorPage.aspx.cs" Inherits="SwiftHrManagement.web.ErrorPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">

    <div class="panel">
        <div class="panel-body" style="margin:50px">
            <h3 style="color:#ff0000">
                Sorry! Seems something is wrong or  You are not authorized to access this page.
          please contact your administrator for support, Thank You.</h3>
        </div>

        <br />
        <a href="\Dashboard.aspx" class="btn btn-sm btn-primary margin-bottom margin-r-5 margin">Back to Dashboard</a>
    </div>
     

    
    
</asp:Content>
