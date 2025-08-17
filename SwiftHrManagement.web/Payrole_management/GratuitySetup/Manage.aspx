<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="SwiftHrManagement.web.Payrole_management.GratuitySetup.Manage" Title="Swift HR Management System 1.0" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <asp:UpdatePanel ID="up" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-md-6 col-md-offset-3">
                    <section class="panel">
                        <header class="panel-heading">
                            <i class="fa fa-caret-right" aria-hidden="true"></i>  
                            Gratuity Setup
                        </header>
                        <div class="panel-body">
                             Please enter valid data!<span class="required"> (* Required fields!)</span>
                            <div class="form-group">                               
                                 <asp:Label ID="lblmsg" runat="server" ></asp:Label>
                               <div id="DivMsg" runat="server"></div>
                            </div>
                            <div class="row">
                                <div class="col-md-6 form-group">
                                    <div class="form-group">
                                        <label>Start From:<span class="errormsg">*</span></label>
                                        <asp:DropDownList ID="DdlStartFrom" runat="server" CssClass="form-control" Width="100%">
                                            <asp:ListItem Value="jd">Joined Date</asp:ListItem> 
                                            <asp:ListItem Value="ad">Appointment Date</asp:ListItem>   
                                            <asp:ListItem Value="pd">Permanent Date</asp:ListItem>
                                            <asp:ListItem Value="gd">Gratuity Effective Date</asp:ListItem> 
                                        </asp:DropDownList>
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                            ErrorMessage="Required!" ControlToValidate="DdlStartFrom" AutoComplete="Off"
                                            Display="Dynamic" ValidationGroup="user" BorderColor="#FFFF66"
                                            SetFocusOnError="True">
                                        </asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="col-md-6 form-group">
                                    <div class="form-group">
                                        <label>Calculate On:<span class="errormsg">*</span></label>
                                        <asp:DropDownList ID="ddlCalculateOn" runat="server" CssClass="form-control" Width="100%">
                                            <asp:ListItem Value="36">Basic Salary</asp:ListItem>
                                            <asp:ListItem Value="36,37">Basic Salary & Grade</asp:ListItem>
                                            <asp:ListItem Value="36,37,38">Gross Salary</asp:ListItem> 
                                        </asp:DropDownList>
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                            ErrorMessage="Required!" ControlToValidate="ddlCalculateOn" AutoComplete="Off"
                                            Display="Dynamic" ValidationGroup="user" BorderColor="#FFFF66"
                                            SetFocusOnError="True">
                                        </asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                
                            </div>
                            <div class="row">
                               <div class="col-md-6 form-group">
                                    <div class="form-group">
                                        <label>Start Year:<span class="errormsg">*</span></label>
                                       <asp:textbox ID="txtStartYear" runat="server" CssClass="form-control" Width="100%"></asp:textbox>
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                            ErrorMessage="Required!" ControlToValidate="txtStartYear" AutoComplete="Off"
                                            Display="Dynamic" ValidationGroup="user" BorderColor="#FFFF66"
                                            SetFocusOnError="True">
                                        </asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="col-md-6 form-group">
                                    <div class="form-group">
                                        <label>End Year:<span class="errormsg">*</span></label>
                                       <asp:textbox ID="txtEndYear" runat="server" CssClass="form-control" Width="100%"></asp:textbox>
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                                            ErrorMessage="Required!" ControlToValidate="txtEndYear" AutoComplete="Off"
                                            Display="Dynamic" ValidationGroup="user" BorderColor="#FFFF66"
                                            SetFocusOnError="True">
                                        </asp:RequiredFieldValidator>
                                    </div>
                                </div>

                            </div>
                            
                           
                        <%-- <button type="submit" class="btn btn-primary">Submit</button>--%>
                            <div class="form-group">
                                <asp:Button ID="BtnSave" runat="server" CssClass="btn btn-primary" Text="Save"
                                    OnClick="btnSave_Click" Font-Strikeout="False" ValidationGroup="user"
                                    Width="75px" />
                             
                                <asp:Button ID="BtnBack" runat="server" CssClass="btn btn-primary"
                                    OnClick="btnBack_Click" Text=" Back" />
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
