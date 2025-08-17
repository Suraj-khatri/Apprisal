<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="Confirm.aspx.cs" Inherits="SwiftHrManagement.web.Payrole_management.GradeIncrement.Confirm" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">

    <asp:UpdatePanel ID="up" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-md-12">
                    <section class="panel">
                        <header class="panel-heading">
                            <i class="fa fa-caret-right" aria-hidden="true"></i>  
                             Grade Increment Confirmation
                        </header>
                        <div class="panel-body">
                            <div class="form-group">
                                <asp:Label ID="lblMsgDis" runat="server"></asp:Label>
                            </div>
                             <div id="rpt" runat="server" class="table-responsive"></div>   
                             <div class="form-group">
                                <asp:Button ID="btnConfirm" runat="server" CssClass="btn btn-primary" Text="Apply In Payroll"
                                    OnClick="btnConfirm_Click" Font-Strikeout="False" />
                               <cc1:confirmbuttonextender ID="BtnSave_ConfirmButtonExtender" runat="server" 
                                        ConfirmText="Confirm To Apply?" Enabled="True" 
                                        TargetControlID="btnConfirm">
                                </cc1:confirmbuttonextender>
                            </div>
                        </div>
                    </section>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
