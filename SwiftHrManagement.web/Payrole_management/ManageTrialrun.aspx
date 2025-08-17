<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="ManageTrialrun.aspx.cs" Inherits="SwiftHrManagement.web.Payrole_management.ManageTrialrun" Title="Swift HR Management System 1.0" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">

<asp:UpdatePanel ID = "updtpnl" runat ="server">
</asp:UpdatePanel>
    <div class="row">
        <div class="col-lg-6 col-md-offset-3">
            <section class="panel">
                <header class="panel-heading">
                    <i class="fa fa-caret-right"></i>
                    Trial Salary Sheet Generation
                </header>
                <div class="panel-body">
                    <div class="form-group">
                        <asp:Label ID="lblMes" runat="server"  style="color:Red;font-family:Verdana;text-align:right;"></asp:Label>
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label>Select Fiscal Year :</label>
                                <asp:DropDownList ID="DdlFY" runat="server" CssClass="form-control">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label>Select Month:</label>
                                <asp:DropDownList ID="ddlMonth" runat="server" CssClass="form-control">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label>Select Branch :</label>
                                <asp:DropDownList ID="DdlBranch" runat="server" CssClass="form-control" 
                                    AutoPostBack="True" 
                                    onselectedindexchanged="DdlBranch_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label>Select Employee:</label>
                                <asp:DropDownList ID="ddlEmployee" runat="server" CssClass="form-control">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <asp:Button ID="btnGenerate" runat="server" Text="Generate" 
                                    CssClass="btn btn-primary" onclick="btnGenerate_Click" />
                                <cc1:ConfirmButtonExtender ID="btnGenerate_ConfirmButtonExtender" 
                                    runat="server" ConfirmText="Confirm To Generate Trial Salary?" Enabled="True" 
                                    TargetControlID="btnGenerate">
                                </cc1:ConfirmButtonExtender>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <asp:Button ID="btnViewreport" runat="server" CssClass="btn btn-primary" 
                                    Text="View Report" onclick="btnViewreport_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </section>
        </div>
    </div>
</asp:Content>
