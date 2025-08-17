<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="SwiftHrManagement.web.Inventory.ReqSchedule.Manage" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">

<div class="row">
    <div class="col-md-10 col-md-offset-1">
        <section class="panel">
            <header class="panel-heading">
                <i class="fa fa-caret-right"></i>
                Requisition Schedule Setup</header>
            <div class="panel-body">
                <asp:UpdatePanel ID="upanel" runat="server">
                    <ContentTemplate>
                            <span class="txtlbl">Please enter valid data!</span><span class="required"> (* Required fields!) </span>
                            <br />
                            <asp:Label ID="LblMsg" runat="server"></asp:Label>
                            <div class="row">
                                 <div class="col-md-6 form-group">
                            <label>Branch Name:</label><span class="errormsg">*</span>
                            <asp:DropDownList ID="ddlBranch" runat="server" CssClass="form-control"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ErrorMessage="Required!" ControlToValidate="ddlBranch" 
                                Display="Dynamic" ValidationGroup="sch" 
                                SetFocusOnError="True">
                            </asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-6 form-group">
                            <label>Nepali Day Number:</label><span class="errormsg">*</span>
                            <asp:TextBox ID="txtDayNum" runat="server" CssClass="form-control">
                            </asp:TextBox>
                            <asp:RequiredFieldValidator ID="Rfvproduct" runat="server" 
                                ControlToValidate="txtDayNum" ErrorMessage="Required!" 
                                SetFocusOnError="True" ValidationGroup="sch">
                            </asp:RequiredFieldValidator>     
                        </div>
                            </div>
                       
                       <div class="form-group">
                            <asp:Button ID="BtnSave" runat="server" CssClass="btn btn-primary" Text=" Save " 
                            onclick="BtnSave_Click" ValidationGroup="sch"/>

                            <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" 
                            ConfirmText="Confirm To Save ?" Enabled="True" 
                            TargetControlID="BtnSave">
                            </cc1:ConfirmButtonExtender>

                            <asp:Button ID="BtnDelete" runat="server" CssClass="btn btn-primary" Text=" Delete " 
                            onclick="BtnDelete_Click"/>

                            <cc1:ConfirmButtonExtender ID="BtnDelete_ConfirmButtonExtender" runat="server" 
                            ConfirmText="Confirm To Delete ?" Enabled="True" 
                            TargetControlID="BtnDelete">
                            </cc1:ConfirmButtonExtender>

                            <asp:Button ID="BtnBack" runat="server" CssClass="btn btn-primary" 
                            onclick="BtnBack_Click" Text="Back"/> 
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                    
            </div>
        </section>
    </div>
</div>

</asp:Content>
