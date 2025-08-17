<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SwiftHRManager.Master" CodeBehind="Manage.aspx.cs" Inherits="SwiftHrManagement.web.LeaveManagementModule.LeaveRequestIndivisual.Manage" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script language="javascript">

        function GetId() {
            var notificationList = document.getElementById("notificationList");
            var ids = notificationList.contentWindow.GetIdListForNotification();
            var HiddenFieldempEmail = document.getElementById("<%=HiddenFieldEmpEmail.ClientID %>");
            HiddenFieldempEmail.value = ids;
            return false;
        }
        function IsDelete(id) {
            if (confirm("Confirm Delete?")) {
                document.getElementById("<% =hdnId.ClientID %>").value = id;
                document.getElementById("<% =btnDeleteRecord.ClientID %>").click();
            }
        }


    </script>
    <style type="text/css">
        .style10 {
            width: 104px;
        }

        .style12 {
            width: 407px;
            height: 315px;
        }

        #notificationList {
            width: 397px;
            margin-right: 0px;
            height: 284px;
            margin-top: 2px;
            margin-bottom: 0px;
        }
    </style>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <asp:UpdatePanel ID="Panel1" runat="server">
        <ContentTemplate>
            <asp:HiddenField ID="hdnId" runat="server" />
            <asp:HiddenField ID="hdnLeaveStatus" runat="server" />
            <asp:HiddenField ID="HiddenFieldEmpEmail" runat="server" />
            <asp:HiddenField ID="hdnReqDays" runat="server" />
            <asp:Button ID="btnDeleteRecord" runat="server" Text="Delete" OnClick="btnDeleteRecord_Click" Style="display: none;" />
            <div class="row autocomplete-form">
                <div class="col-md-8 col-md-offset-2">
                    <div class="panel">
                        <header class="panel-heading">
                 <i class="fa fa-caret-right"></i>
                            Leave Request Details
                 </header>
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-md-12">
                                    <span class="txtlbl">Please enter valid data! </b></span>
                                    <span class="required">(* Required fields)</span>
                                    <asp:Label ID="LblMsg" runat="server"></asp:Label>
                                </div>
                                <div class="col-md-12">
                                    <label><strong>Employee Leave Detail:</strong></label>
                                </div>
                                <div class="col-md-12 form-group">
                                    <label>Employee Name:</label>
                                    <asp:Label ID="lblEmpName" runat="server"></asp:Label>
                                </div>
                                <div class="col-md-4 form-group">
                                    <label>Leave Type:</label>
                                    <asp:RequiredFieldValidator ID="Rfd1" runat="server"
                                        ControlToValidate="DdlLeaveName" Display="Dynamic" ErrorMessage="*"
                                        ValidationGroup="Request" SetFocusOnError="True"></asp:RequiredFieldValidator><br />
                                    <asp:DropDownList ID="DdlLeaveName" runat="server" CssClass="form-control"
                                        OnSelectedIndexChanged="DdlLeaveName_SelectedIndexChanged" AutoPostBack="true">
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
                                    <asp:TextBox ID="TxtFromDate" runat="server" CssClass="form-control" OnTextChanged="TxtFromDate_TextChanged"
                                        AutoPostBack="True"></asp:TextBox>
                                    <cc1:CalendarExtender ID="TxtFromDate_CalendarExtender" runat="server"
                                        Enabled="True" TargetControlID="TxtFromDate">
                                    </cc1:CalendarExtender>
                                </div>
                                <div class="col-md-4 form-group">
                                    <label>To Date: <span class="errormsg">*</span></label>
                                    <asp:RequiredFieldValidator
                                        ID="rfd4" runat="server" ControlToValidate="TxtToDate"
                                        Display="Dynamic" ErrorMessage="Required!" ValidationGroup="Request"
                                        SetFocusOnError="True"></asp:RequiredFieldValidator>
                                    <asp:Label ID="LblDateMsg" runat="server" CssClass="errormsg"></asp:Label>
                                    <asp:TextBox ID="TxtToDate" runat="server" CssClass="form-control"
                                        OnTextChanged="TxtToDate_TextChanged" AutoPostBack="True"></asp:TextBox>
                                    <cc1:CalendarExtender ID="TxtToDate_CalendarExtender" runat="server"
                                        Enabled="True" TargetControlID="TxtToDate">
                                    </cc1:CalendarExtender>
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
                                    <label>Requested Days:</label>
                                    <asp:TextBox ID="TxtrequestDays" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                </div>
                                
                                <div class="col-md-4 form-group">
                                    <asp:Panel ID="PnlIsLFA" runat="server" Visible="false">
                                        <label>LFA:</label>
                                        <asp:DropDownList ID="DdlLFA" runat="server" CssClass="form-control"
                                            AutoPostBack="true">
                                            <asp:ListItem Value="0">No</asp:ListItem>
                                            <asp:ListItem Value="1">Yes</asp:ListItem>
                                        </asp:DropDownList>
                                    </asp:Panel>
                                </div>
                                <div class="col-md-4 form-group">
                                    <asp:Panel ID="PnlSubDate" runat="server" Visible="false">
                                        <div align="left">Substituted Date : </div>
                                        <asp:TextBox ID="TxtSubstitutedDate" runat="server" CssClass="form-control" Width="150px"></asp:TextBox>
                                    </asp:Panel>
                                </div>
                                <div class="col-md-12 form-group">
                                    <label>Relieving Arrangement:</label>
                                    <asp:Label ID="lblSubstEmpName" runat="server" CssClass="txtlbl"></asp:Label>
                                    <asp:TextBox ID="TxtSubstitutedBy" runat="server" AutoComplete="Off"
                                        AutoPostBack="true" CssClass="form-control" OnTextChanged="TxtSubstitutedBy_TextChanged"></asp:TextBox>
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
                                    <label>Approved By:</label>
                                    <asp:RequiredFieldValidator ID="rfd6" runat="server"
                                        ControlToValidate="DdlApprovedBy" Display="Dynamic" ErrorMessage="Required!"
                                        ValidationGroup="Request" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                    <asp:DropDownList ID="DdlApprovedBy" runat="server" CssClass="form-control">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-6 form-group">
                                    <label>Description:<span class="errormsg">*</span></label>
                                    <asp:RequiredFieldValidator ID="sdcsdc" runat="server"
                                        ControlToValidate="TxtDescription" Display="Dynamic" ErrorMessage="Required!"
                                        ValidationGroup="Request" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                    <asp:TextBox ID="TxtDescription" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                </div>
                                <div class="col-md-12 form-group">
                                    <asp:Panel ID="PnlFileUpload" runat="server" Visible="false">
                                        <div class="row form-group">
                                            <div class="col-md-12 form-group">
                                                <label><strong>Upload File:</strong></label>
                                                <asp:Label ID="lblMessage" runat="server" CssClass="txtlbl"></asp:Label>
                                            </div>
                                            <div class="col-md-4 form-group">
                                                <label>File Description:<span class="errormsg">*</span></label>
                                                <asp:RequiredFieldValidator ID="rfv2" runat="server" ErrorMessage="Required!"
                                                    ValidationGroup="uploader" ControlToValidate="TxtFileName" Display="Dynamic"
                                                    SetFocusOnError="True">
                                                </asp:RequiredFieldValidator>
                                                <asp:TextBox ID="TxtFileName" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                            <div class="col-md-4 form-group">
                                                <label>File Name:<span class="errormsg">*</span></label>
                                                <asp:RequiredFieldValidator ID="rfv1" runat="server" ErrorMessage="Required!"
                                                    ValidationGroup="uploader" ControlToValidate="fileUpload" Display="Dynamic"
                                                    SetFocusOnError="True">
                                                </asp:RequiredFieldValidator>
                                                <input id="fileUpload" runat="server" name="fileUpload" type="file" class="form-control" />
                                            </div>
                                            <div class="col-md-4 form-group">
                                                <asp:Button ID="btnAdd" runat="server" Text="Add File" CssClass="btn btn-primary" ValidationGroup="uploader" OnClick="btnAdd_Click" />
                                            </div>
                                            <div class="col-md-12 form-group">
                                                <div id="rpt" runat="server"></div>
                                            </div>
                                        </div>
                                    </asp:Panel>
                                </div>
                                <div class="col-md-12">
                                    <asp:Panel ID="PnlApprovedDetails" runat="server" Visible="false">
                                        <label><strong>Detail:</strong></label>
                                        <div class="row form-group">
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
                                        </div>
                                    </asp:Panel>
                                </div>
                                <div class="col-md-12 form-group">
                                    <div id="rptDiv" runat="server"></div>
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
