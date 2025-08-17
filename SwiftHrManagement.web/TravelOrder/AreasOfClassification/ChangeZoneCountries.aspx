<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SwiftHRManager.Master"  CodeBehind="ChangeZoneCountries.aspx.cs" Inherits="SwiftHrManagement.web.TravelOrder.AreasOfClassification.ChangeZoneCountries" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <div class="row">
        <div class="col-md-6 col-md-offset-3">
            <section class="panel">     
                <header class="panel-heading">
                       &nbsp;&nbsp;Change Catagory Of Position
                </header>
                <div class="panel-body">
                    <div class="form-group">
                        <strong>&nbsp;Edit Details</strong>
                    </div>
                    <div class="form-group">
                        <label>Zone Name :<span class="errormsg">*</span></label>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="DdlZone"
                             ErrorMessage="Required!" ValidationGroup="zone" SetFocusOnError="True"></asp:RequiredFieldValidator>
                         <asp:DropDownList ID="DdlZone" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label>Countries Name :<span class="errormsg">*</span></label>
                         <asp:DropDownList ID="DdlCountries" runat="server" CssClass="form-control" Enabled="false" 
                             onselectedindexchanged="DdlCountries_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label>Is Active :<span class="errormsg">*</span></label>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="DdlisActive" 
                             ErrorMessage="Required!" ValidationGroup="zone" SetFocusOnError="True"></asp:RequiredFieldValidator>
                         <asp:DropDownList ID="DdlisActive" runat="server" CssClass="form-control" onselectedindexchanged="DdlisActive_SelectedIndexChanged" >
                             <asp:ListItem Value="">Select</asp:ListItem>
                            <asp:ListItem Value="Yes">Yes</asp:ListItem>
                            <asp:ListItem Value="No">No</asp:ListItem>
                         </asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <asp:Button ID="BtnSave" runat="server" CssClass="btn btn-primary" onclick="BtnSave_Click" Text="Save" 
                            ValidationGroup="zone" />
                        <cc1:ConfirmButtonExtender ID="BtnSave_ConfirmButtonExtender" runat="server" ConfirmText="Confirm To Save?"
                            Enabled="True" TargetControlID="BtnSave"></cc1:ConfirmButtonExtender>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="lblmsg" runat="server"></asp:Label>
                    </div>
                </div>
            </section>
        </div>
    </div>
</asp:Content>
