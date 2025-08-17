<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SwiftHRManager.Master" CodeBehind="Manage.aspx.cs" Inherits="SwiftHrManagement.web.LeaveManagementModule.LeaveApprove.Manage" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <asp:UpdatePanel ID="LeaveApprove" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-md-8 col-md-offset-2">
                    <section class="panel">
                    <header class="panel-heading">
                        <i class="fa fa-caret-right"></i>
                         Employee Leave Approve Details
                    </header>
                    <div class="panel-body">
                        <div class="row form-group">
                            <div class="col-md-12">
                                    Please enter valid data!
                                  <asp:Label ID="LblMsg" runat="server"></asp:Label>
                                </div>
                            <div class="col-md-12">
                                <label>Requested By:</label>
                                 <asp:Label ID="LblRequestedBy" runat="server"></asp:Label>
                            </div>
                            <div class="col-md-12">
                                <label><strong>Leave Detail:</strong></label>
                            </div>
                            <div class="col-md-6">
                                <label>Leave Type:</label>
                                <asp:DropDownList ID="DdlLeaveName" runat="server" CssClass="form-control"></asp:DropDownList>
                            </div>
                            <div class="col-md-6">
                                <label>Remaining Days:</label>
                                 <asp:TextBox ID="TxtRemainingDays" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-6">
                                <label>Leave Status:</label>
                                <asp:TextBox ID="TxtLeaveStatus" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-12">
                                <label><strong>Request Detail:</strong></label>
                            </div>
                            <div class="col-md-6">
                                <label>From Date:</label>
                                <asp:TextBox ID="TxtFromDate" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-6">
                                <label>To Date:</label>
                            <asp:TextBox ID="TxtToDate" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-6">
                                <label>Requested Days:</label>
                                <asp:TextBox ID="TxtrequestDays" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-6">
                                <label>Request Half Day:</label>
                                  <asp:DropDownList ID="DdlrequestedHours" runat="server" CssClass="form-control"
                                     AutoPostBack="true" Enabled="False">
                                    <asp:ListItem Value="0">None</asp:ListItem>
                                    <asp:ListItem Value="1">1st Half</asp:ListItem>
                                    <asp:ListItem Value="2">2nd Half</asp:ListItem>
                                    <asp:ListItem></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="col-md-12">
                                <asp:Panel ID="PnlSubtitutedate" runat="server" Visible="false">
                                        <label>Substituted Date: </label>
                                        <asp:TextBox ID="TxtSubstitutedDate" runat="server" CssClass="form-control"></asp:TextBox>
                                        <cc1:CalendarExtender ID="TxtSubstitutedDate_CalendarExtender" runat="server"
                                            Enabled="True" TargetControlID="TxtSubstitutedDate">
                                        </cc1:CalendarExtender>
                               </asp:Panel>
                                </div>
                                <div class="col-md-6">
                                    <label>Leave Purpose:</label>
                                    <asp:TextBox ID="TxtLeavePurpose" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                </div>
                                <div class="col-md-6">
                                    <asp:Panel ID="PnlIsLFA" runat="server" Visible="false">
                                    <label>Is LFA? </label>
                                            <asp:DropDownList ID="DdlLFA" runat="server" CssClass="form-control"
                                                AutoPostBack="true" Enabled="False">
                                                <asp:ListItem Value="0">No</asp:ListItem>
                                                <asp:ListItem Value="1">Yes</asp:ListItem>
                                                <asp:ListItem></asp:ListItem>
                                            </asp:DropDownList>
                                </asp:Panel>
                                </div>
                            
                                <div class="col-md-12">
                                    <label><strong>Recommend/Approve Detail:</strong></label>
                                </div>
                                <div class="col-md-6">
                                    <label>From Date:</label>
                                     <asp:TextBox ID="txtApprovedFrom" runat="server" CssClass="form-control"
                                         AutoPostBack="true" OnTextChanged="txtApprovedFrom_TextChanged"></asp:TextBox>
                                     <cc1:CalendarExtender ID="txtApprovedFrom_CalendarExtender" runat="server"
                                         Enabled="True" TargetControlID="txtApprovedFrom">
                                     </cc1:CalendarExtender>
                                </div>
                                <div class="col-md-6">
                                    <label>To Date:</label>
                                    <asp:TextBox ID="txtApprovedTo" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtApprovedTo_TextChanged"></asp:TextBox>
                                     <cc1:CalendarExtender ID="txtApprovedTo_CalendarExtender" runat="server"
                                         Enabled="True" TargetControlID="txtApprovedTo">
                                     </cc1:CalendarExtender>
                                </div>
                                <div class="col-md-6">
                                    <label>Approved Days:</label>
                                    <asp:TextBox ID="txtApprovedDays" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col-md-6">
                                    <label>Approved Half Day:</label>
                                     <asp:DropDownList ID="DdlApprovedHalfday" runat="server" CssClass="form-control"
                                         AutoPostBack="true" Enabled="False">
                                         <asp:ListItem Value="0">None</asp:ListItem>
                                         <asp:ListItem Value="1">1st Half</asp:ListItem>
                                         <asp:ListItem Value="2">2nd Half</asp:ListItem>
                                         <asp:ListItem></asp:ListItem>
                                     </asp:DropDownList>
                                </div>
                                <div class="col-md-6">
                                    <asp:Panel ID="PnlSubtitutedate2" runat="server" Visible="false">
                                            <label>Substituted Date: </label>
                                            <asp:TextBox ID="TxtSubstitutedDate2" runat="server" CssClass="form-control"></asp:TextBox>
                                   </asp:Panel>
                                </div>
                                <div class="col-md-6">
                                    <asp:Panel ID="PnlIsLfa2" runat="server" Visible="false">
                                        <label>Is LFA? </label>
                                        <asp:CheckBox ID="chkIsLfa2" runat="server" />&nbsp;
                                   </asp:Panel>
                                </div>
                                <div class="col-md-6">
                                    <label>Recommended By:</label>
                                     <asp:DropDownList ID="DdlRecommendedBy" runat="server" CssClass="form-control"></asp:DropDownList>
                                </div>
                                <div class="col-md-6">
                                    <label>Approved By:</label>
                                    <asp:DropDownList ID="DdlApprovedBy" runat="server" CssClass="form-control">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-6">
                                    <label>Relieving Arrangement:</label>
                                    <asp:Label ID="lblSubstitutedBy" runat="server" CssClass="txtlbl"></asp:Label>
                                     <asp:TextBox ID="TxtSubstitutedBy" runat="server" AutoComplete="Off"
                                       AutoPostBack="true" CssClass="form-control"
                                       OnTextChanged="TxtSubstitutedBy_TextChanged"></asp:TextBox>
                                   <cc1:AutoCompleteExtender ID="TxtSubstitutedBy_AutoCompleteExtender"
                                       runat="server" CompletionInterval="10" CompletionListCssClass="autocompleteTextBoxLP"
                                       DelimiterCharacters="" EnableCaching="true" Enabled="true"
                                       MinimumPrefixLength="1" ServiceMethod="GetEmployeeListByNameORId"
                                       ServicePath="~/Autocomplete.asmx" TargetControlID="TxtSubstitutedBy">
                                   </cc1:AutoCompleteExtender>
                               </div>
                                <div class="col-md-6">
                                <asp:Label ID="LblRecRemarks" runat="server" Text="Recommended Remarks:"></asp:Label>
                                <asp:TextBox ID="txtRecRemarks" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                </div>
                                <div class="col-md-6">
                                   <asp:Label ID="LblAppRemarks" runat="server" Text="Approved Remarks :"></asp:Label>
                                   <asp:TextBox ID="txtAppRemarks" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                </div>
                                <div class="col-md-12">
                                    <asp:Panel ID="PnlFileUpload" runat="server" Visible="false">
                                               <label>Attached Documents :</label>
                                                  <div class="col-md-12">
                                                           <div id="rpt" runat="server"></div>
                                                      </div>
                                    </asp:Panel>
                                </div>
                                <div class="col-md-12">
                                    <asp:Button ID="BtnSave" runat="server" CssClass="btn btn-primary" Text="Recommend"
                                        ValidationGroup="Request" OnClick="BtnSave_Click" />
                                    <cc1:ConfirmButtonExtender ID="BtnSave_ConfirmButtonExtender" runat="server"
                                        ConfirmText="Confirm To Recommend ?" Enabled="True" TargetControlID="BtnSave">
                                    </cc1:ConfirmButtonExtender>
                                   <asp:Button ID="BtnApprove" runat="server" CssClass="btn btn-primary" Text="Approve"
                                        ValidationGroup="Request" OnClick="BtnSave_Click" />
                                    <cc1:ConfirmButtonExtender ID="BtnSave_ConfirmButtonExtender2" runat="server"
                                        ConfirmText="Confirm To Approve ?" Enabled="True" TargetControlID="BtnApprove">
                                    </cc1:ConfirmButtonExtender>
                                  
                                   <asp:Button ID="BtnReject" runat="server" CssClass="btn btn-primary"
                                        Text="Reject" OnClick="BtnReject_Click" />
                                    <cc1:ConfirmButtonExtender ID="BtnDelete_ConfirmButtonExtender" runat="server"
                                        ConfirmText="Confirm To Reject ?" Enabled="True" TargetControlID="BtnReject">
                                    </cc1:ConfirmButtonExtender>
                                    <asp:Button ID="BtnBack" runat="server" CssClass="btn btn-primary"
                                         Text="Back" OnClick="BtnBack_Click" />
                                </div>
                            </div>
                        </div>
                </div>
                </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
