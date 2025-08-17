<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SwiftHRManager.Master" CodeBehind="Manage.aspx.cs" Inherits="SwiftHrManagement.web.LeaveManagementModule.LeaveRequest.Manage" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <asp:UpdatePanel ID="Panel1" runat="server">
        <ContentTemplate>
            <div class="row autocomplete-form">
                <div class="col-md-8 col-md-offset-2">
                    <div class="panel">
                        <header class="panel-heading">
                       <i class="fa fa-caret-right"></i>
                            Employee Leave Request Details Entry
                       </header>
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-md-12">
                                    Please enter valid data!
                                 <asp:Label ID="LblMsg" runat="server"></asp:Label>
                                </div>
                                <div class="col-md-12">
                                    <label><strong>Employee Leave Detail:</strong></label>
                                </div>
                                <div class="col-md-12 form-group">
                                    <label>Employee Name:</label>
                                    <asp:Label ID="lblEmpName" runat="server"></asp:Label>
                                    <asp:TextBox ID="txtEmployee" runat="server" AutoComplete="Off" AutoPostBack="true"
                                        CssClass="form-control" OnTextChanged="txtEmployee_TextChanged"></asp:TextBox>
                                    <cc1:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server"
                                        CompletionInterval="10" CompletionListCssClass="autocompleteTextBoxLP"
                                        DelimiterCharacters="" EnableCaching="true" Enabled="true"
                                        MinimumPrefixLength="1" ServiceMethod="GetEmployeeList"
                                        ServicePath="~/Autocomplete.asmx" TargetControlID="txtEmployee">
                                    </cc1:AutoCompleteExtender>
                                    <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1"
                                    runat="server" Enabled="True" TargetControlID="txtEmployee"
                                    WatermarkCssClass="form-control" WatermarkText="Auto Complete">
                                </cc1:TextBoxWatermarkExtender>
                                </div>
                                <div class="col-md-4 form-group">
                                    <label>Leave Type:</label>
                                    <asp:RequiredFieldValidator ID="Rfd1" runat="server" ControlToValidate="DdlLeaveName" Display="Dynamic" ErrorMessage="*"
                                        ValidationGroup="Request" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                    <asp:DropDownList ID="DdlLeaveName" runat="server" CssClass="form-control" AutoPostBack="true"
                                        OnSelectedIndexChanged="DdlLeaveName_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-4 form-group">
                                    <label>Remaining Days:</label>
                                    <asp:TextBox ID="TxtRemainingDays" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                </div>
                                <div class="col-md-4 form-group">
                                    <label>Max Days / Request:</label>
                                    <asp:TextBox ID="TxtMaxReqDays" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                </div>
                                <div class="col-md-12">
                                    <label><strong>Request Detail:</strong></label>
                                </div>
                                <div class="col-md-4 form-group">
                                    <label>From Date:<span class="errormsg">*</span></label>
                                    <asp:RequiredFieldValidator ID="rfd3" runat="server"
                                        ControlToValidate="TxtFromDate" Display="Dynamic" ErrorMessage="Required!"
                                        ValidationGroup="Request" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                    <asp:TextBox ID="TxtFromDate" runat="server" CssClass="form-control"
                                        AutoPostBack="True" OnTextChanged="TxtFromDate_TextChanged"></asp:TextBox>
                                    <cc1:CalendarExtender ID="TxtFromDate_CalendarExtender" runat="server"
                                        Enabled="True" TargetControlID="TxtFromDate">
                                    </cc1:CalendarExtender>
                                </div>
                                <div class="col-md-4 form-group">
                                    <label>To Date:<span class="errormsg">*</span></label>
                                    <asp:RequiredFieldValidator ID="rfd4" runat="server" ControlToValidate="TxtToDate"
                                        Display="Dynamic" ErrorMessage="Required!" ValidationGroup="Request"
                                        SetFocusOnError="True"></asp:RequiredFieldValidator>
                                    <asp:Label ID="LblDateMsg" runat="server"></asp:Label>
                                    <br />
                                    <asp:TextBox ID="TxtToDate" runat="server" CssClass="form-control"
                                        AutoPostBack="True" OnTextChanged="TxtToDate_TextChanged"></asp:TextBox>
                                    <cc1:CalendarExtender ID="TxtToDate_CalendarExtender" runat="server"
                                        Enabled="True" TargetControlID="TxtToDate">
                                    </cc1:CalendarExtender>
                                </div>
                                <div class="col-md-4 form-group">
                                    <label>Requested Days:</label>
                                    <asp:TextBox ID="TxtrequestDays" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                </div>
                                <div class="col-md-4 form-group">
                                    <label>Request Half Day:</label>
                                    <asp:DropDownList ID="DdlrequestedHalfDay" runat="server" CssClass="form-control"
                                        AutoPostBack="true" OnSelectedIndexChanged="DdlrequestedHalfDay_SelectedIndexChanged">
                                        <asp:ListItem Value="0">None</asp:ListItem>
                                        <asp:ListItem Value="1">1st Half</asp:ListItem>
                                        <asp:ListItem Value="2">2nd Half</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-4 form-group">
                                    <asp:Panel ID="PnlIsLFA" runat="server" Visible="false">
                                        <label>LFA:</label>
                                        <asp:DropDownList ID="DdlLFA" runat="server" CssClass="form-control"
                                            AutoPostBack="true">
                                            <asp:ListItem Value="0">NO</asp:ListItem>
                                            <asp:ListItem Value="1">YES</asp:ListItem>
                                        </asp:DropDownList>
                                    </asp:Panel>
                                </div>
                                <div class="col-md-3 form-group">
                                    <asp:Panel ID="PnlSubDate" runat="server" Visible="false">
                                        <label>Substituted Date : </label>
                                        <asp:TextBox ID="TxtSubstitutedDate" runat="server" CssClass="form-control" Width="206px"></asp:TextBox>
                                    </asp:Panel>
                                </div>
                                <div class="col-md-12 form-group">
                                    <label>Relieving Arrangement:</label>
                                    <asp:Label ID="lblSubstEmpName" runat="server" CssClass="txtlbl"></asp:Label>
                                    <asp:TextBox ID="TxtSubstitutedBy" runat="server" AutoComplete="Off"
                                        AutoPostBack="true" CssClass="form-control"
                                        OnTextChanged="TxtSubstitutedBy_TextChanged"></asp:TextBox>
                                    <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server"
                                        CompletionInterval="10" CompletionListCssClass="autocompleteTextBoxLP"
                                        DelimiterCharacters="" EnableCaching="true" Enabled="true"
                                        MinimumPrefixLength="1" ServiceMethod="GetEmployeeList"
                                        ServicePath="~/Autocomplete.asmx" TargetControlID="TxtSubstitutedBy">
                                    </cc1:AutoCompleteExtender>
                                    <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2"
                                    runat="server" Enabled="True" TargetControlID="TxtSubstitutedBy"
                                    WatermarkCssClass="form-control" WatermarkText="Auto Complete">
                                </cc1:TextBoxWatermarkExtender>
                                    
                                </div>
                                <div class="col-md-4 form-group">
                                    <label>Leave Status:</label>
                                    <asp:TextBox ID="TxtLeaveStatus" runat="server" CssClass="form-control" Enabled="False">Pending</asp:TextBox>
                                </div>
                                <div class="col-md-4 form-group">
                                    <label>Recommended By:<span class="errormsg">*</span></label>
                                    <asp:RequiredFieldValidator ID="rfd5" runat="server"
                                        ControlToValidate="DdlRecommendedBy" Display="Dynamic" ErrorMessage="Required!"
                                        ValidationGroup="Request" SetFocusOnError="True">
                                    </asp:RequiredFieldValidator>
                                    <asp:DropDownList ID="DdlRecommendedBy" runat="server" CssClass="form-control"></asp:DropDownList>
                                </div>
                                <div class="col-md-4 form-group">
                                    <label>Approved By: <span class="errormsg">*</span></label>
                                    <asp:RequiredFieldValidator ID="rfd6" runat="server" ControlToValidate="DdlApprovedBy" Display="Dynamic" ErrorMessage="Required!"
                                        ValidationGroup="Request" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                    <asp:DropDownList ID="DdlApprovedBy" runat="server" CssClass="form-control">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-12 form-group">
                                    <label>Description: <span class="errormsg">*</span></label>
                                    <asp:RequiredFieldValidator ID="rfd7" runat="server"
                                        ControlToValidate="TxtDescription" Display="Dynamic" ErrorMessage="Required!!!"
                                        ValidationGroup="Request" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                    <asp:TextBox ID="TxtDescription" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                </div>
                                <div class="col-md-12">
                                    <asp:Panel ID="PnlApprovedDetails" runat="server" Visible="false">
                                        <label><strong>Approved Detail:</strong></label>
                                        <div class="col-md-4 form-group">
                                            <label>Approved From:</label>
                                            <asp:TextBox ID="TxtApprovedFrom" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                        <div class="col-md-4 form-group">
                                            <label>Approved To:</label>
                                            <asp:TextBox ID="TxtApprovedTo" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                        <div class="col-md-4 form-group">
                                            <label>Approved Days:</label>
                                            <asp:TextBox ID="TxtApprovedDays" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </asp:Panel>
                                </div>
                                <div class="col-md-12">
                                    <div id="rptDiv" runat="server"></div>
                                </div>
                                <div class="col-md-12">
                                    <asp:Panel ID="PnlFileUpload" runat="server" Visible="false">
                                        <label>Attached Documents:</label>
                                        <div id="rpt" runat="server"></div>
                                    </asp:Panel>
                                </div>
                                <div class="col-md-12">
                                     <asp:Button ID="BtnSave" runat="server" CssClass="btn btn-primary" Text="Save"
                                             ValidationGroup="Request" OnClick="BtnSave_Click" />
                                         <cc1:ConfirmButtonExtender ID="BtnSave_ConfirmButtonExtender" runat="server"
                                             ConfirmText="Confirm To Save ?" Enabled="True" TargetControlID="BtnSave">
                                         </cc1:ConfirmButtonExtender>
                                         <asp:Button ID="BtnDelete" runat="server" CssClass="btn btn-primary"
                                             Text="Delete" OnClick="BtnDelete_Click" />
                                         <cc1:ConfirmButtonExtender ID="BtnDelete_ConfirmButtonExtender" runat="server"
                                             ConfirmText="Confirm To Delete ?" Enabled="True" TargetControlID="BtnDelete">
                                         </cc1:ConfirmButtonExtender>
                                         <asp:Button ID="BtnBack" runat="server" CssClass="btn btn-primary"
                                             Text="Back" OnClick="BtnBack_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
