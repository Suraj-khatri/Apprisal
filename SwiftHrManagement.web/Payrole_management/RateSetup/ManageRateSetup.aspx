<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="ManageRateSetup.aspx.cs" Inherits="SwiftHrManagement.web.Payrole_management.RateSetup.ManageRateSetup" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <asp:UpdatePanel ID="up" runat="server">
        <ContentTemplate>
            <div class="row">
                <asp:Label ID="abc" runat="server"></asp:Label>
                <div class="col-md-6 col-md-offset-3">
                    <section class="panel">
                        <header class="panel-heading">
                            <i class="fa fa-caret-right" aria-hidden="true"></i>  
                            Rate Setup
                        </header>
                        <div class="panel-body">
                            <div class="form-group">
                                <span class="txtlbl">Please enter valid data!</span><span class="required"> (* Required fields!) </span><br/>
                                <asp:Label ID="LblMsg" runat="server"></asp:Label>
                            </div>
                            <div class="row">
                                <div class="col-md-6 form-group">
                                    <div class="form-group">
                                        <label>Category For:<span class="errormsg">*</span></label>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                            ErrorMessage="Required!" ControlToValidate="ddlCategoryFor" AutoComplete="Off"
                                            Display="Dynamic" ValidationGroup="user" BorderColor="#FFFF66"
                                            SetFocusOnError="True">
                                        </asp:RequiredFieldValidator>
                                        <asp:DropDownList ID="ddlCategoryFor" runat="server" CssClass="form-control" Width="100%"> 
                                        </asp:DropDownList>
                                         
                                    </div>
                                </div>
                                
                                <div class="col-md-6 form-group">
                                    <div class="form-group">
                                        <label>Category:<span class="errormsg">*</span></label>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                            ErrorMessage="Required!" ControlToValidate="ddlCategory" AutoComplete="Off"
                                            Display="Dynamic" ValidationGroup="user" BorderColor="#FFFF66"
                                            SetFocusOnError="True">
                                        </asp:RequiredFieldValidator>
                                        <asp:DropDownList ID="ddlCategory" runat="server" CssClass="form-control" Width="100%"> 
                                        </asp:DropDownList>                                         
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6 form-group">
                                    <div class="form-group">
                                        <label>Amount:<span class="errormsg">*</span></label>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                            ErrorMessage="Required!" ControlToValidate="txtAmount" AutoComplete="Off"
                                            Display="Dynamic" ValidationGroup="user" BorderColor="#FFFF66"
                                            SetFocusOnError="True">
                                        </asp:RequiredFieldValidator>
                                       <asp:textbox ID="txtAmount" runat="server" CssClass="form-control" Width="100%"></asp:textbox>                                         
                                    </div>
                                </div>    
                            </div> 
                            <div class="row">                           
                                <div class="col-md-6 form-group">
                                    <div class="form-group">
                                        <label>Is Active:</label>&nbsp;
                                        <asp:CheckBox ID="ChkActive" runat="server" AutoPostBack="True"/>
                                    </div>
                                </div>
                            </div>                           
                        <%-- <button type="submit" class="btn btn-primary">Submit</button>--%>
                            <div class="form-group">
                                <asp:Button ID="BtnSave" runat="server" CssClass="btn btn-primary" Text="Save"
                                    OnClick="BtnSave_Click" Font-Strikeout="False" ValidationGroup="user"
                                    Width="75px" />
                                <asp:Button ID="BtnDelete" runat="server" CssClass="btn btn-primary" Text="Delete"
                                    OnClick="BtnDelete_Click" />
                                <cc1:ConfirmButtonExtender ID="BtnDelete_ConfirmButtonExtender" runat="server"
                                    ConfirmText="Confirm To Delete ?" Enabled="True"
                                    TargetControlID="BtnDelete">
                                </cc1:ConfirmButtonExtender>
                                <asp:Button ID="BtnBack" runat="server" CssClass="btn btn-primary"
                                    OnClick="BtnBack_OnClick" Text=" Back" />
                                <cc1:ConfirmButtonExtender ID="BtnSave_ConfirmButtonExtender" runat="server"
                                    ConfirmText="Confirm To Save ?" Enabled="True" TargetControlID="BtnSave">
                                </cc1:ConfirmButtonExtender>
                            </div>
                        </div>
                    </section>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
