<%@ Page Title="" Language="C#" MasterPageFile="~/ProjectMaster.Master" AutoEventWireup="true" CodeBehind="ListEventDetails.aspx.cs" Inherits="SwiftHrManagement.web.Company.EmployeeWeb.Promotion.ListEventDetails" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <div class="panel">
        <header class="panel-heading">
   <i class="fa fa-caret-right"></i>  Employee Service Events History
        </header>
        <div class="panel-body">
            <div id="rpt" runat="server"></div>
        </div>
    </div>

</asp:Content>
