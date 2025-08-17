<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SwiftHRManager.Master"  CodeBehind="ManageApproval.aspx.cs" Inherits="SwiftHrManagement.web.AssetManagement.ManageApproval" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
     <asp:UpdatePanel ID="upd" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-lg-10 col-lg-offset-1">
                     <section class="panel">
                        <header class="panel-heading">
                            <i class="fa fa-caret-right"></i>
                          Approval Actions
                        </header>
                        <div class="panel-body">
                                <label>Approval Actions</label>
                                <asp:Label ID="lblmsg" runat="server"></asp:Label>
                                <asp:HiddenField ID="hdnTableName" runat="server" />
                                <asp:HiddenField ID="hdnId" runat="server" />
                            <div class="form-group">
                                <div class="col-md-6">
                                    <label>Requested Date :</label>
                                    <asp:Label ID = "createdDate" runat="server"></asp:Label>
                                </div>
                                <div class="col-md-6">
                                    <label>Requested By :</label>
                                    <asp:Label ID = "createdBy" runat="server"></asp:Label>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-md-6">
                                    <label> Requested Type :</label>
                                    <asp:Label ID = "tableName" runat="server"></asp:Label>
                                </div>
                                <div class="col-md-6">
                                    <label>Requested Mode :</label>
                                    <asp:Label ID = "modType" runat="server"></asp:Label>
                                </div>
                            </div>
                            <br/>
                                <div class="col-md-12">
                                    <div id = "changeDetails" runat ="server">
                                        <label>Data Details :</label>
                                        <div id = "rpt_grid" runat = "server"></div>
                                    </div>
                                </div>
                            
                            <div class="form-group col-md-12">
                                <strong> Remarks(Only if rejected):</strong>
                                <asp:TextBox ID = "reasonForRejection" runat = "server" Rows = "3" TextMode="MultiLine" 
                                    CssClass = "form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID = "RequiredFieldValidator1" runat = "server" 
                                    ControlToValidate = "reasonForRejection" ErrorMessage = "*" CssClass = "errormsg" 
                                    ValidationGroup="reject"></asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group col-md-12">
                               <input id="Button1" type="button" value="Back" class="btn btn-primary" 
                                   onclick="javascript: history.back(1); return false;"/>
                                <asp:Button ID = "btnApprove" runat = "server" Text = "Approve" onclick="btnApprove_Click" 
                                    CssClass="btn btn-primary"/>
                                <cc1:ConfirmButtonExtender ID="btnApprove_ConfirmButtonExtender" runat="server" 
                                    ConfirmText="Confirm To Approve ?" Enabled="True" TargetControlID="btnApprove"/> 
                                <asp:Button ID = "btnReject" runat = "server" Text = "Reject" onclick="btnReject_Click" 
                                    ValidationGroup="reject" CssClass="btn btn-primary"/>
                                <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" 
                                    ConfirmText="Confirm To Reject ?" Enabled="True" TargetControlID="btnReject"/>
                                <asp:Button ID = "btnTerminate" runat = "server" Text = "Terminate" onclick="btnTerminate_Click" 
                                    CssClass="btn btn-primary"/>
                                <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender2" runat="server" 
                                    ConfirmText="Confirm To Terminate ?" Enabled="True" TargetControlID="btnTerminate"/>
                            </div>
                        </div>
                    </section>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>