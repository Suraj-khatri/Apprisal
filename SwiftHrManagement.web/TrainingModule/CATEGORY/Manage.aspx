<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="SwiftHrManagement.web.TrainingModule.CATEGORY.Manage" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <div class="row">
        <div class="col-md-8 col-md-offset-2">
            <section class="panel">
                <header class="panel-heading">
                    <i class="fa fa-caret-right"></i>
                    Training Category Entry Details
                </header>
                <div class="panel-body">
                    <div class="form-group">
                        <span class="txtlbl">Please enter valid data</span>
                        <span class="required" >(* Required fields)</span>
                        <asp:Label ID="LblMsg" runat="server"></asp:Label>
                    </div>
                    <div class="form-group">
                        <label>Category Title:<span class="errormsg">*</span></label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TxtTrnName" 
                            Display="None" ErrorMessage="*" ValidationGroup="List"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="TxtTrnName" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Category Content:<span class="errormsg">*</span></label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TxtTranCnt" 
                            Display="None" ErrorMessage="*" ValidationGroup="List"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="TxtTranCnt" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Description:<span class="errormsg">*</span></label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TxtDsgFor" 
                            Display="None" ErrorMessage="*" ValidationGroup="List"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="TxtDsgFor" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:Button ID="Btn_Save" runat="server" CssClass="btn btn-primary" onclick="Btn_Save_Click" Text="Save"
                             ValidationGroup="List" />
                        <cc1:ConfirmButtonExtender ID="Btn_Save_ConfirmButtonExtender" runat="server" 
                            ConfirmText="Confirm to save?" Enabled="True" TargetControlID="Btn_Save">
                        </cc1:ConfirmButtonExtender>
                        <asp:Button ID="BtnDelete" runat="server" CssClass="btn btn-primary" onclick="BtnDelete_Click" Text="Delete" />
                        <cc1:ConfirmButtonExtender ID="BtnDelete_ConfirmButtonExtender" runat="server" 
                            ConfirmText="Are you sure to delete?" Enabled="True" TargetControlID="BtnDelete">
                        </cc1:ConfirmButtonExtender>
                        <asp:Button ID="BtnBack" runat="server" CssClass="btn btn-primary" onclick="BtnBack_Click" Text="Back" />
                    </div>
                </div>
            </section>
        </div>
    </div>
</asp:Content>