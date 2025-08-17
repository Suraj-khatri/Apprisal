<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="SwiftHrManagement.web.Customer.Manage" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <div class="col-md-10 col-md-offset-1 ">
        <section class="panel">
                <header class="panel-heading"> 
                    <i class="fa fa-caret-right"></i>
                    Vendor Entry Details
                </header>
                <div class="panel-body">
                        <span class="txtlbl">Please enter valid data!</span><span class="required"> (* Required fields!) </span>
                        <asp:Label ID="LblMsg" runat="server"></asp:Label>
                    <fieldset>
                        <label>Vendor General Information:</label>
                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Vendor Name:</label>
                                    <span class="errormsg">*</span>
                                    <asp:TextBox ID="TxtCustName" runat="server"
                                        CssClass="form-control" Width="100%" ></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RV2" runat="server" ControlToValidate="TxtCustName" ErrorMessage="Required" ValidationGroup="vendor" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Address:</label>
                                    <asp:TextBox ID="TxtAddress" runat="server"
                                        CssClass="form-control" Width="100%"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RV3"
                                        runat="server" ControlToValidate="TxtAddress"
                                        ErrorMessage="Required" ValidationGroup="vendor" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Tel. No 1:</label>
                                    <asp:TextBox ID="TxtTelNo" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                                </div>
                            </div>
                            </div>

                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Tel. No 2:</label>
                                    <asp:TextBox ID="TxtTelNo2" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                                </div>
                            </div>
                             <div class="col-md-4">
                                <div class="form-group">
                                    <label>Fax Number:</label>
                                    <asp:TextBox ID="TxtFaxNo" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>PAN Number:</label>
                                    <asp:TextBox ID="TxtPANNo" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                                </div>
                                </div>
                            </div>
                        <div class="row">
                             <div class="col-md-4">
                                <div class="form-group">
                                    <label>Email Addres:</label>
                                    <asp:TextBox ID="TxtEmail" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                                </div>

                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Website:</label>
                                    <asp:TextBox ID="TxtWebsite" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                                </div>
                                </div>
                           
                           </div>
                        <div class="row">
                             <div class="col-md-12">
                                <div class="form-group">
                                    <label>Business Details:</label>
                                    <asp:TextBox ID="TxtBusinessDetails" runat="server" CssClass="form-control" TextMode="MultiLine" Width="100%"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-12">
                                <div class="form-group">
                                    <label>Is Active:</label>
                                    <asp:CheckBox ID="ChkIsActive" runat="server" />
                                </div>
                            </div>
                        </div>
                    </fieldset>

                    <fieldset>
                        <label>Vendor Contact Person Information:</label>
                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Contact Person-I:</label>
                                    <asp:TextBox ID="TxtContact1" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Mobile Number:</label>
                                    <asp:TextBox ID="TxtMobile1" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Email:</label>
                                    <asp:TextBox ID="TxtEmail1" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Contact Person-II:</label>
                                    <asp:TextBox ID="TxtContact2" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Mobile Number:</label>
                                    <asp:TextBox ID="TxtMobile2" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Email:</label>
                                    <asp:TextBox ID="TxtEmail2" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Contact Person-III:</label>
                                    <asp:TextBox ID="TxtContact3" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Mobile Number:</label>
                                    <asp:TextBox ID="TxtMobile3" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Email:</label>
                                    <asp:TextBox ID="TxtEmail3" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                       
                                <asp:Button ID="Btn_Save" runat="server" CssClass="btn btn-primary"
                                    OnClick="Btn_Save_Click" Text="Save" ValidationGroup="vendor" />
                                <cc1:ConfirmButtonExtender ID="Btn_Save_ConfirmButtonExtender" runat="server"
                                    ConfirmText="Confirm To Save?" Enabled="True" TargetControlID="Btn_Save">
                                </cc1:ConfirmButtonExtender>
                                <asp:Button ID="BtnDelete" runat="server" CssClass="btn btn-primary"
                                    OnClick="BtnDelete_Click" Text="Delete" />
                                <cc1:ConfirmButtonExtender ID="BtnDelete_ConfirmButtonExtender" runat="server"
                                    ConfirmText="Confirm To Delete?" Enabled="True" TargetControlID="BtnDelete">
                                </cc1:ConfirmButtonExtender>
                                <asp:Button ID="BtnBack" runat="server" CssClass="btn btn-primary"
                                    OnClick="BtnBack_Click" Text="Back" />
                           
                    </fieldset>
          
                </div> 
            </section>
    </div>

</asp:Content>
