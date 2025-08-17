<%@ Page Title="" EnableEventValidation="false" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="SwiftHrManagement.web.OrganoChart.Manage" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" language="javascript">
        function getreference() 
        {
            b.click();    
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <div class="panel">
        <header class="panel-heading">
            <i class="fa fa-caret-right"></i>
            Organizational chart
        </header>
        <div class="panel-body">
                <span class="txtlbl">Please enter valid data! </b></span>
                <span class="required">(* Required fields)</span>           
                <asp:Label ID="LblMsg" runat="server"></asp:Label>
        </div>
    </div>
    <div class="panel panel-default">
        <div class="panel-body">
            <form class="form-inline">
                <div class="col-md-6 form-group">
                    <label>Under Group<span class="errormsg">*</span></label>
                     <asp:RequiredFieldValidator 
                       ID="Rfvnewitem" runat="server" 
                       ControlToValidate="DdlItems" Display="None" ErrorMessage="*" 
                       SetFocusOnError="True" ValidationGroup="chart"></asp:RequiredFieldValidator>
                       <asp:DropDownList ID="DdlItems" runat="server" CssClass="form-control" Enabled="false">
                </asp:DropDownList>
                </div>
                <div class="col-md-6 form-group">
                     <label>Enter New Group</label>
                    <asp:RequiredFieldValidator ID="Rfvitem" runat="server" 
                     ControlToValidate="TxtNewItems" Display="None" ErrorMessage="*" 
                     SetFocusOnError="True" ValidationGroup="chart"></asp:RequiredFieldValidator><asp:TextBox ID="TxtNewItems" runat="server" 
                         CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-6 form-group">
            <label> Group Description</label>
                    <asp:TextBox ID="TxtDecs" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-6 form-group">
                    <label> Employee</label>
                    <asp:DropDownList ID="Ddlempname" runat="server" CssClass="form-control" >
                    </asp:DropDownList>
                </div>
                <div class="col-md-12">
                     <asp:Button ID="btnSave" runat="server" Text="Save" onclick="btnSave_Click" 
                     CssClass="btn btn-primary" ValidationGroup="chart" />
                     &nbsp;<asp:Button ID="BtnDelete" runat="server" CssClass="btn btn-primary" Text="Delete" 
                     ValidationGroup="chart" onclick="BtnDelete_Click" />
                     <cc1:ConfirmButtonExtender ID="BtnDelete_ConfirmButtonExtender" runat="server" 
                    ConfirmText="Confirm To Delete?" Enabled="True" TargetControlID="BtnDelete">
                    </cc1:ConfirmButtonExtender>
                     &nbsp;<asp:Button ID="BtnCancel" runat="server" CssClass="btn btn-primary" Text="Back" ValidationGroup="chart" />
                 </div>
            </form>
        </div>
    </div>
   
</asp:Content>
