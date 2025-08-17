<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="SwiftHrManagement.web.Role.Manage" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <style type="text/css">
                .panel-body {
                padding: 0 3px !important;
    }
            </style>
            <div class="row">
                <div class="col-md-6 col-md-offset-3">
                    <section class="panel">
                        <header class="panel-heading">
                           <i class="fa fa-caret-right"></i>
                            ROLE SETUP
                        </header>
                        <div class="panel-body">
                            <div class="row">
                                <div class="form-group">
                                    <asp:Label ID="LblMsg" runat="server"></asp:Label>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-8 col-md-offset-2">
                                    <div class="form-group">
                             <label>  Choose Role:</label> <asp:DropDownList ID="DdlRoleList" runat="server"
                                            CssClass="form-control" OnSelectedIndexChanged="DdlRoleList_SelectedIndexChanged"
                                            AutoPostBack="True" style="margin:5px;" >
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                           
                            <div class="row">
                                <div class="form-group">
                                    <div class="col-md-12">
                                        <div class="" id="tblMain" runat="server">

                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6 col-md-offset-3">
                                    <div class="form-group">
                                        <asp:Button ID="BtnSave" runat="server" CssClass="btn btn-block btn-primary" Text="Save"
                                            OnClick="BtnSave_Click"/>
                                        <cc1:ConfirmButtonExtender ID="BtnSave_ConfirmButtonExtender" runat="server"
                                            ConfirmText="Confirm To Save?" Enabled="True" TargetControlID="BtnSave">
                                        </cc1:ConfirmButtonExtender>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </section>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
