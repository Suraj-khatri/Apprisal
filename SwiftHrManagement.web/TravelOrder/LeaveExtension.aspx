<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="LeaveExtension.aspx.cs" Inherits="SwiftHrManagement.web.TravelOrder.LeaveExtension" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../ui/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../ui/css/style.css" rel="stylesheet" />

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
            <asp:Button ID="btnDeleteRecord" runat="server" Text="Delete" OnClick="btnDeleteRecord_Click" Style="display: none;" />
            <div class="panel">
                <header class="panel-heading">
            <i class="fa fa-caret-right"></i>
            Employee Leave Request Details Entry
        </header>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-sm-12">
                            <asp:Label ID="LblMsg" runat="server" CssClass="errormsg"></asp:Label>
                            <asp:HiddenField ID="HiddenFieldEmpEmail" runat="server" />
                            <asp:HiddenField ID="hdnReqDays" runat="server" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-12">
                            <label><strong>Employee Leave Detail:</strong></label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-12">
                            <label>Employee Name:</label>
                            <asp:Label ID="lblEmpName" runat="server"></asp:Label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-4 form-group">
                            <label>Leave Type:</label>
                            <asp:RequiredFieldValidator ID="Rfd1" runat="server"
                                ControlToValidate="DdlLeaveName" Display="Dynamic" ErrorMessage="*"
                                ValidationGroup="Request" SetFocusOnError="True"></asp:RequiredFieldValidator><br />
                            <asp:DropDownList ID="DdlLeaveName" runat="server" CssClass="form-control"
                                OnSelectedIndexChanged="DdlLeaveName_SelectedIndexChanged" AutoPostBack="true">
                            </asp:DropDownList>
                        </div>
                        <div class="col-sm-4 form-group">
                            <label>Remaining Days:</label>
                            <asp:TextBox ID="TxtRemainingDays" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                        </div>
                        <div class="col-sm-4 form-group">
                            <label>Max Days / Request:</label>
                            <asp:TextBox ID="TxtMaxReqDays" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-12">
                            <label><strong>Request Detail:</strong></label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-3 form-group">
                            <label>From Date: <span class="errormsg">*</span></label>
                            <asp:RequiredFieldValidator ID="rfd3" runat="server"
                                ControlToValidate="TxtFromDate" Display="Dynamic" ErrorMessage="Required!"
                                ValidationGroup="Request" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <br />
                            <asp:TextBox ID="TxtFromDate" runat="server" CssClass="form-control"
                                OnTextChanged="TxtFromDate_TextChanged" AutoPostBack="True"></asp:TextBox>
                            <cc1:CalendarExtender ID="TxtFromDate_CalendarExtender" runat="server"
                                Enabled="True" TargetControlID="TxtFromDate">
                            </cc1:CalendarExtender>
                        </div>
                        <div class="col-sm-3 form-group">
                            <label>To Date: <span class="errormsg">*</span></label>
                            <asp:RequiredFieldValidator
                                ID="rfd4" runat="server" ControlToValidate="TxtToDate"
                                Display="Dynamic" ErrorMessage="Required!" ValidationGroup="Request"
                                SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <asp:Label ID="LblDateMsg" runat="server" CssClass="errormsg"></asp:Label>
                            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="TxtFromDate" ControlToValidate="TxtToDate"
                                Display="Dynamic" ErrorMessage="Invalid Date" Operator="GreaterThanEqual"
                                SetFocusOnError="True"></asp:CompareValidator>
                            <br />
                            <asp:TextBox ID="TxtToDate" runat="server" CssClass="form-control"
                                OnTextChanged="TxtToDate_TextChanged" AutoPostBack="True"></asp:TextBox>
                            <cc1:CalendarExtender ID="TxtToDate_CalendarExtender" runat="server"
                                Enabled="True" TargetControlID="TxtToDate">
                            </cc1:CalendarExtender>
                        </div>
                        <div class="col-sm-3 form-group">
                            <label>Requested Days:</label>
                            <asp:TextBox ID="TxtrequestDays" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                        </div>
                        <div class="col-sm-3 form-group">
                            <label>Request Half Day:</label>
                            <asp:DropDownList ID="DdlrequestedHalfDay" runat="server" CssClass="form-control"
                                AutoPostBack="true" OnSelectedIndexChanged="DdlrequestedHalfDay_SelectedIndexChanged">
                                <asp:ListItem Value="0">None</asp:ListItem>
                                <asp:ListItem Value="1">1st Half</asp:ListItem>
                                <asp:ListItem Value="2">2nd Half</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="row form-group">
                        <%--<asp:Panel ID="Panel2" runat="server" Visible="false">--%>
                        <asp:Panel ID="PnlIsLFA" runat="server" Visible="false">
                            <div class="col-sm-4 form-group">LFA :
                                  <asp:DropDownList ID="DdlLFA" runat="server" CssClass="form-control"
                                      AutoPostBack="true">
                                      <asp:ListItem Value="0">No</asp:ListItem>
                                      <asp:ListItem Value="1">Yes</asp:ListItem>
                                  </asp:DropDownList>
                            </div>
                        </asp:Panel>
                        <%--<asp:Panel ID="Panel2" runat="server" Visible="false">--%>
                        <asp:Panel ID="PnlSubDate" runat="server" Visible="false">
                            <div class="col-sm-4">Substituted Date: 
                             <asp:TextBox ID="TxtSubstitutedDate" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </asp:Panel>
                    </div>
                    <div class="row">
                        <div class="col-sm-12 autocomplete-form">
                            <div class="form-group">
                                <label>Relieving Arrangement:</label>
                                <asp:Label ID="lblSubstEmpName" runat="server"></asp:Label>
                                <asp:TextBox ID="TxtSubstitutedBy" runat="server" AutoComplete="Off"
                                    AutoPostBack="true" CssClass="form-control" OnTextChanged="TxtSubstitutedBy_TextChanged"></asp:TextBox>
                                <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server"
                                    CompletionInterval="10" CompletionListCssClass="autocompleteTextBoxLP"
                                    DelimiterCharacters="" EnableCaching="true" Enabled="true"
                                    MinimumPrefixLength="1" ServiceMethod="GetEmployeeListByNameORId"
                                    ServicePath="~/Autocomplete.asmx" TargetControlID="TxtSubstitutedBy">
                                </cc1:AutoCompleteExtender>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-4 form-group">
                            <label>Leave Status:</label>
                            <asp:TextBox ID="TxtLeaveStatus" runat="server" CssClass="form-control" Enabled="False" Text="Pending"></asp:TextBox>
                        </div>
                        <div class="col-sm-4 form-group">
                            <label>Recommended By:<span class="errormsg">*</span></label>
                            <asp:RequiredFieldValidator ID="rfd5" runat="server"
                                ControlToValidate="DdlRecommendedBy" Display="Dynamic" ErrorMessage="Required!"
                                ValidationGroup="Request" SetFocusOnError="True">
                            </asp:RequiredFieldValidator>
                            <br />
                            <asp:DropDownList ID="DdlRecommendedBy" runat="server" CssClass="form-control"></asp:DropDownList>
                        </div>
                        <div class="col-sm-4 form-group">
                            <label>Approved By: <span class="errormsg">*</span></label>
                            <asp:RequiredFieldValidator ID="rfd6" runat="server"
                                ControlToValidate="DdlApprovedBy" Display="Dynamic" ErrorMessage="Required!"
                                ValidationGroup="Request" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <br />
                            <asp:DropDownList ID="DdlApprovedBy" runat="server" CssClass="form-control">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-12 form-group">
                            <label>Description: <span class="errormsg">*</span></label>
                            <asp:RequiredFieldValidator ID="sdcsdc" runat="server"
                                ControlToValidate="TxtDescription" Display="Dynamic" ErrorMessage="Required!"
                                ValidationGroup="Request" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <asp:TextBox ID="TxtDescription" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                        </div>
                    </div>

                    <%--<asp:Panel ID="Panel2" runat="server" Visible="false">--%>
                    <asp:Panel ID="PnlFileUpload" runat="server" Visible="false">
                        <div class="row">
                            <div class="col-sm-12">
                                <label><strong>Upload File:</strong></label><br />
                                <asp:Label ID="lblMessage" runat="server"></asp:Label>
                            </div>
                            <div class="col-sm-4 form-group">
                                <label>File Description:<span class="errormsg">*</span> </label>
                                <asp:RequiredFieldValidator ID="rfv2" runat="server" ErrorMessage="Required!"
                                    ValidationGroup="uploader" ControlToValidate="TxtFileName" Display="Dynamic"
                                    SetFocusOnError="True">
                                </asp:RequiredFieldValidator>
                                <asp:TextBox ID="TxtFileName" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-sm-4 form-group">
                                <label>File Name:</label>
                                <asp:RequiredFieldValidator ID="rfv1" runat="server" ErrorMessage="Required!"
                                    ValidationGroup="uploader" ControlToValidate="fileUpload" Display="Dynamic"
                                    SetFocusOnError="True">
                                </asp:RequiredFieldValidator>
                                <input id="fileUpload" runat="server" name="fileUpload" type="file" size="20" class="form-control" />
                            </div>
                            <div class="col-sm-4">
                                <asp:Button ID="btnAdd" runat="server" Text="Add File"
                                    CssClass="btn btn-primary" ValidationGroup="uploader" OnClick="btnAdd_Click" />
                            </div>
                            <div class="row">
                                <div ID="rpt" runat="server"></div>
                            </div>
                        </div>
                    </asp:Panel>

                    <%--<asp:Panel ID="Panel2" runat="server" Visible="false">--%>
                    <asp:Panel ID="PnlApprovedDetails" runat="server" Visible="false">
                        <div class="row">
                            <div class="col-sm-12">
                                <label><strong>Detail:</strong> </label>
                            </div>
                            <div class="col-sm-4 form-group">
                                <label>Approved From:</label>
                                <asp:TextBox ID="TxtApprovedFrom" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-sm-4 form-group">
                                <label>Approved To:</label>
                                <asp:TextBox ID="TxtApprovedTo" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-sm-4 form-group">
                                <label>Approved Days:</label>
                                <asp:TextBox ID="TxtApprovedDays" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </asp:Panel>
                    <div class="row">
                        <div class="col-sm-12">
                            <div id="rptDiv" runat="server"></div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-12">
                            <asp:Button ID="BtnSave" runat="server" CssClass="btn btn-primary" Text="Save"
                                ValidationGroup="Request" OnClick="BtnSave_Click" />
                            <cc1:ConfirmButtonExtender ID="BtnSave_ConfirmButtonExtender" runat="server"
                                ConfirmText="Confirm To Save ?" Enabled="True" TargetControlID="BtnSave">
                            </cc1:ConfirmButtonExtender>
                            &nbsp;<asp:Button ID="BtnDelete" runat="server" CssClass="button"
                                Text="Delete" OnClick="BtnDelete_Click" />
                            <cc1:ConfirmButtonExtender ID="BtnDelete_ConfirmButtonExtender" runat="server"
                                ConfirmText="Confirm To Delete ?" Enabled="True" TargetControlID="BtnDelete">
                            </cc1:ConfirmButtonExtender>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
