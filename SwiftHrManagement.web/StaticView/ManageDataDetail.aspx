<%@ Page Language="C#" MasterPageFile="~/Apprisal.Master" AutoEventWireup="true" CodeBehind="ManageDataDetail.aspx.cs" Inherits="SwiftHrManagement.web.StaticView.ManageDataDetail" Title="Swift HRM" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">

    <div class="row">
        <div class="col-md-6 col-md-offset-3">
            <section class="panel">
                <header class="panel-heading">
                    <i class="fa fa-caret-right" aria-hidden="true"></i>
                    Add New Data
                </header>
                <div class="panel-body">
                    <div>
                        <span class="subheading">
                            <asp:Label ID="LblEmpName" runat="server" Text=""></asp:Label>
                        </span>
                    </div>
                    <div>
                        <span class="txtlbl">Please enter valid  data!</span><span class="required"> (* Required fields)</span>
                        <asp:Label ID="LblMsg" runat="server"></asp:Label>
                    </div>
                    <div class="form-group">
                        <label>Category :</label>
                        <asp:TextBox ID="TxtDataType" runat="server" CssClass="form-control"
                            Enabled="False"></asp:TextBox>
                        <asp:TextBox ID="TxtTypeId" runat="server" Enabled="False"
                                Style="margin-left: 0px" Visible="False"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Title :<span class="errormsg">*</span></label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                            ControlToValidate="TxtDetailTitle" Display="None"
                            ErrorMessage="Required!" ValidationGroup="Data"
                            SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="TxtDetailTitle" runat="server" CssClass="form-control"
                            MaxLength="100"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Description :<span class="errormsg">*</span></label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                            ControlToValidate="TxtDetailDesc" Display="None"
                            ErrorMessage="Required!" ValidationGroup="Data"
                            SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="TxtDetailDesc" runat="server" CssClass="form-control"
                            MaxLength="100" TextMode="MultiLine"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <div id="divAppOT" runat="server">
                            <label>Applicable to OT :</label>
                            <asp:DropDownList ID="ddlOT" runat="server" CssClass="form-control">
                                <asp:ListItem Text="Select" />
                                <asp:ListItem Value="Y">Yes</asp:ListItem>
                                <asp:ListItem Value="N">No</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <%--<tr>
                    <td class="txtlbl">
                        Applicable to OT <span class="errormsg">*</span>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                            ControlToValidate="ddlapplyOT" Display="None" 
                            ErrorMessage="RequiredFieldValidator" ValidationGroup="Data" 
                            SetFocusOnError="True" Width="100%"></asp:RequiredFieldValidator>
                
                        <asp:TextBox ID="ddlapplyOT" runat="server" CssClass="inputTextBoxLP" 
                        MaxLength="100" TextMode="MultiLine" Height="57px" Width="272px"></asp:TextBox>
                    </td>
            </tr>--%>
               
                    <div class="form-group">
                        <asp:Button ID="BtnSave" runat="server" CssClass="btn btn-primary"
                            OnClick="BtnSave_Click" Text="Save" ValidationGroup="Data" />
                        <cc1:ConfirmButtonExtender ID="BtnSave_ConfirmButtonExtender" runat="server"
                            ConfirmText="Confirm To Save?" Enabled="True" TargetControlID="BtnSave">
                        </cc1:ConfirmButtonExtender>
                        <asp:Button ID="BtnDelete" runat="server" CssClass="btn btn-primary"
                            OnClick="BtnDelete_Click" Text="Delete" />
                        <cc1:ConfirmButtonExtender ID="BtnDelete_ConfirmButtonExtender" runat="server"
                            ConfirmText="Confirm To Delete?" Enabled="True" TargetControlID="BtnDelete">
                        </cc1:ConfirmButtonExtender>
                        <asp:Button ID="BtnBack" runat="server" CssClass="btn btn-primary"
                            OnClick="BtnBack_Click" Text="Back" />

                    </div>
                </div>
            </section>
        </div>
    </div>


</asp:Content>

