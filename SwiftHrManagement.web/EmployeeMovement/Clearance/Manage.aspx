<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="SwiftHrManagement.web.EmployeeMovement.Clearance.Manage" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
     <div class="panel">
        <header class="panel-heading">
             <i class="fa fa-caret-right"></i>  Clearing Sheet Form
        </header>
        <div class="panel-body">
            <div align="center"><asp:Label ID="compInfo" runat="server" CssClass="ReportHeader"></asp:Label></div>
            <div class="row">
                <div class="col-md-12 form-group">
                    <label>Name</label>
               <asp:Label ID="lblName" runat="server" CssClass="txtlbl"></asp:Label>
                    </div>
                <div class="col-md-12 form-group">
                    <label>Designation</label>
                <asp:Label ID="lblPost" runat="server" CssClass="txtlbl"></asp:Label>
                </div>
                <div class="col-md-12 form-group">
                    <label>Branch / Department</label>
               <asp:Label ID="lblBranchDept" runat="server" CssClass="txtlbl"></asp:Label>
                </div>
                <div class="col-md-12 form-group">
                     <label>Resignation Effective Date</label> 
                <asp:Label ID="lblEffectiveDate" runat="server" CssClass="txtlbl"></asp:Label>
                </div>
                <asp:Label ID="lblMsg" runat="server" CssClass="txtlbl"></asp:Label>
            </div>
            <div class="row">
                    <div class="col-md-12">
                         <div id="clearanceForm" runat="server"></div>
                    </div>
            </div>
            <br />
             <asp:Button ID="btnSave" runat="server" Text=" Save " CssClass="btn btn-primary" 
                    onclick="btnSave_Click"/>

                <cc1:confirmbuttonextender ID="btnSave_ConfirmButtonExtender" runat="server" 
                    ConfirmText="Confirm To Save ?" Enabled="True" TargetControlID="btnSave">
                </cc1:confirmbuttonextender>
        
        </div>
    </div>

</asp:Content>

