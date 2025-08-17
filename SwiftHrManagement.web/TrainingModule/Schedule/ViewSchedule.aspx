<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="ViewSchedule.aspx.cs" Inherits="SwiftHrManagement.web.TrainingModule.Schedule.ViewSchedule" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <div class="panel">
        <header class="panel-heading">
            <i class="fa fa-caret-right"></i>
            <strong>Training Schedule</strong>
            <asp:Label ID="LblEmpName" runat="server" Text=""></asp:Label>
       </header>
        <div class="panel-body">
            <div class="row">
                <div class="col-md-12 col-sm-12">
                    <section class="panel">
                        <div class="panel-body">
                            <div class="form-group">
                                <label>Training Program Name:</label>
                                <asp:Label ID="lblProgramName" runat="server" CssClass="txtlbl"></asp:Label>
                            </div>
                            <div id="rpt" runat="server"></div>
                        </div>
                    </section>
                </div>
            </div>
        </div>
    </div>					
</asp:Content>
