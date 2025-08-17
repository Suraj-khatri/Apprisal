<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="ExtManage.aspx.cs" Inherits="SwiftHrManagement.web.ExternalTransferPlan.ExtManage" Title="Swift HRM" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


    <script type="text/javascript">
        function OnDelete(RowID) {
            if (confirm("Are you sure to Delete this message?")) {
                document.getElementById("<% =hdnSupervisorId.ClientID %>").value = RowID;
                document.getElementById("<% =btnSupervisorDelete.ClientID %>").click();
            }
        }

    </script>
    <script type="text/javascript" language="javascript">

        function GetEmpName(sender, e) {
            var EmpIdArray = (e._value).split("|");
            document.getElementById("<%=hdnEmpName.ClientID%>").Value = EmpIdArray[1];
            }

            function GetEmpID(sender, e) {
                var customerValueArray = (e._value).split("|");
                document.getElementById("<%=hddEmpId.ClientID%>").Value = customerValueArray[1];

            }


    </script>
    <script type="text/javascript" src="../../Jsfunc.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">

    <asp:Button ID="btnSupervisorDelete" runat="server" Style="display: none;" OnClick="btnSupervisorDelete_Click" />
    <asp:UpdatePanel runat="server" ID="ext">
        <ContentTemplate>
            <div class="row">
                <div class="col-md-10 col-md-offset-1">

                    <div class="panel">
                        <header class="panel-heading">
              <i class="fa fa-caret-right"></i> Employee  Transfer Details
        </header>

                        <asp:HiddenField ID="hdnEmpName" runat="server" />
                        <div class="panel-body">
                            <span class="txtlbl">Please enter valid data!</span>
                            <span class="required">(* Required fields)</span><br />
                            <asp:Label ID="lblmsg" runat="server" Text=""></asp:Label>
                            <div class="row">
                                <div class="col-md-12 form-group autocomplete-form">
                                    <label>Employee Name:</label>
                                    <asp:Label ID="lblEmpName" runat="server"></asp:Label>
                                    <asp:TextBox ID="txtEmployeeName" runat="server" CssClass="form-control"
                                        OnTextChanged="txtEmployeeName_TextChanged" AutoPostBack="true"></asp:TextBox>
                                    <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server"
                                        CompletionInterval="10" CompletionListCssClass="autocompleteTextBoxLP"
                                        DelimiterCharacters="" EnableCaching="true" Enabled="true"
                                        MinimumPrefixLength="1" ServiceMethod="GetEmployeeList"
                                        ServicePath="~/Autocomplete.asmx" TargetControlID="txtEmployeeName">
                                    </cc1:AutoCompleteExtender>
                                    <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1"
                                        runat="server" Enabled="True" TargetControlID="txtEmployeeName"
                                        WatermarkCssClass="form-control" WatermarkText="Auto Complete">
                                    </cc1:TextBoxWatermarkExtender>
                                </div>

                            </div>
                            <div class="row">
                                <div class="col-md-4 form-group">
                                    <label>
                                        From Branch: <span class="errormsg">*</span>
                                    </label>

                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server"
                                        ControlToValidate="DdlFromBranch"
                                        ErrorMessage="Required!" SetFocusOnError="True"
                                        ValidationGroup="External">
                                    </asp:RequiredFieldValidator>
                                    <asp:DropDownList ID="DdlFromBranch" runat="server" AutoPostBack="True"
                                        CssClass="form-control">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-4 form-group">
                                    <label>
                                        From Department: <span class="errormsg">*</span>
                                    </label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="DdlFromDept"
                                        SetFocusOnError="True" ValidationGroup="External"> 
                                    </asp:RequiredFieldValidator>
                                    <asp:DropDownList ID="DdlFromDept" runat="server" AutoPostBack="True"
                                        CssClass="form-control">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-4 form-group">
                                    <label>
                                        From Sub-Department: <span class="errormsg">*</span>
                                    </label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="DdlFromSubDept"
                                        SetFocusOnError="True" ValidationGroup="External"> 
                                    </asp:RequiredFieldValidator>
                                    <asp:DropDownList ID="DdlFromSubDept" runat="server" AutoPostBack="True"
                                        CssClass="form-control">
                                    </asp:DropDownList>
                                </div>  
                            </div>
                            <div class ="row">
                                <div class="col-md-4 form-group">
                                    <label>
                                        To Branch: <span class="errormsg">*</span>
                                    </label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2"
                                        runat="server" ControlToValidate="DdlToBranch"
                                        ErrorMessage="Required!" ValidationGroup="External"
                                        SetFocusOnError="True"></asp:RequiredFieldValidator><br />
                                    <asp:DropDownList ID="DdlToBranch" runat="server" AutoPostBack="True"
                                        CssClass="form-control"
                                        OnSelectedIndexChanged="DdlToBranch_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-4 form-group">
                                    <label>
                                        To Department: <span class="errormsg">*</span>
                                    </label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7"
                                        runat="server" ControlToValidate="DdlToDept"
                                        ErrorMessage="Required!" ValidationGroup="External"
                                        SetFocusOnError="True"></asp:RequiredFieldValidator><br />
                                    <asp:DropDownList ID="DdlToDept" runat="server" CssClass="form-control">
                                    </asp:DropDownList>
                                </div>
                                  <div class="col-md-4 form-group">
                                    <label>
                                        To Sub-Department: <span class="errormsg">*</span>
                                    </label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13"
                                        runat="server" ControlToValidate="DdlToSubDept"
                                        ErrorMessage="Required!" ValidationGroup="External"
                                        SetFocusOnError="True"></asp:RequiredFieldValidator><br />
                                    <asp:DropDownList ID="DdlToSubDept" runat="server" CssClass="form-control">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6 form-group">
                                    <label>Recommend By:</label>
                                    <asp:Label ID="lblRecommendBy" runat="server"></asp:Label>
                                    <asp:TextBox ID="txtRecommendBy" runat="server" CssClass="form-control" OnTextChanged="txtRecommendBy_TextChanged"
                                        AutoPostBack="true"></asp:TextBox>
                                    <cc1:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server"
                                        CompletionInterval="10" CompletionListCssClass="autocompleteTextBoxLP"
                                        DelimiterCharacters="" EnableCaching="true" Enabled="true"
                                        MinimumPrefixLength="1" ServiceMethod="GetEmployeeList"
                                        ServicePath="~/Autocomplete.asmx" TargetControlID="txtRecommendBy">
                                    </cc1:AutoCompleteExtender>
                                    <cc1:TextBoxWatermarkExtender ID="txtVendor_TextBoxWatermarkExtender"
                                        runat="server" Enabled="True" TargetControlID="txtRecommendBy"
                                        WatermarkCssClass="form-control" WatermarkText="Auto Complete">
                                    </cc1:TextBoxWatermarkExtender>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4 form-group">
                                    <label>
                                        Recommended Date: <span class="required">*</span>
                                    </label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4"
                                        runat="server" ControlToValidate="txtRecommendDate"
                                        ErrorMessage="Required!" ValidationGroup="External"
                                        SetFocusOnError="True"></asp:RequiredFieldValidator><br />
                                    <asp:TextBox ID="txtRecommendDate" runat="server" CssClass="form-control"></asp:TextBox>
                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server"
                                        Enabled="True" TargetControlID="txtRecommendDate">
                                    </cc1:CalendarExtender>
                                </div>

                                <div class="col-md-4 form-group">
                                    <label>
                                        <span>Effective Date:</span> <span class="required">*</span>
                                    </label>

                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                                        runat="server" ControlToValidate="txtEffectiveDate"
                                        ErrorMessage="Required!" ValidationGroup="External"
                                        SetFocusOnError="True"></asp:RequiredFieldValidator>

                                    <asp:TextBox ID="txtEffectiveDate" runat="server" CssClass="form-control"></asp:TextBox>
                                    <cc1:CalendarExtender ID="txtEffectiveDate_CalendarExtender" runat="server"
                                        Enabled="True" TargetControlID="txtEffectiveDate">
                                    </cc1:CalendarExtender>
                                </div>
                                <div class="col-md-4 form-group">
                                    <label>
                                        <span>Actual Reported Date: </span>
                                        <span class="required">*</span>
                                    </label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3"
                                        runat="server" ControlToValidate="txtReportedDate"
                                        ErrorMessage="Required!" ValidationGroup="External"
                                        SetFocusOnError="True"></asp:RequiredFieldValidator>
                                    <br />
                                    <asp:TextBox ID="txtReportedDate" runat="server" CssClass="form-control">
                                    </asp:TextBox>
                                    <cc1:CalendarExtender ID="txtReportedDate_CalendarExtender" runat="server"
                                        Enabled="True" TargetControlID="txtReportedDate">
                                    </cc1:CalendarExtender>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6 form-group">
                                    <label>
                                        Transfer Description <span class="errormsg">*</span>
                                    </label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5"
                                        runat="server" ControlToValidate="txtTransferDesc"
                                        ErrorMessage="Required!" ValidationGroup="External"
                                        SetFocusOnError="True">
                                    </asp:RequiredFieldValidator>
                                    <asp:TextBox ID="txtTransferDesc" runat="server"
                                        CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>

                    <asp:Panel ID="supAdd" runat="server" Visible="true">
                        <div class="panel panel-default">

                            <header class="panel-heading">
             Supervisor Assignment:
         </header>
                            <div class="panel-body">
                                <asp:HiddenField ID="hddEmpId" runat="server" />
                                <asp:HiddenField ID="hdnSupervisorId" runat="server" />
                                <asp:Label ID="lblSupervisorAssign" runat="server"></asp:Label>
                                <div class="row">
                                    <div class="col-md-4 form-group">
                                        <label>
                                            Supervisor Type:<span class="errormsg">*</span>
                                        </label>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server"
                                            ControlToValidate="ddlSupervisorType" Display="dynamic"
                                            ErrorMessage="Required!" SetFocusOnError="True"
                                            ValidationGroup="add">
                                        </asp:RequiredFieldValidator>

                                        <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control"
                                            OnSelectedIndexChanged="ddlSupervisorType_SelectedIndexChanged" AutoPostBack="true">
                                            <asp:ListItem Value='i'>Immediate Supervisor</asp:ListItem>
                                            <asp:ListItem Value='s'>Supervisor</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-md-4 form-group">
                                        <label>
                                            Supervisor Type:<span class="errormsg">*</span>
                                        </label>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"
                                            ControlToValidate="ddlSupervisorType" Display="dynamic"
                                            ErrorMessage="Required!" SetFocusOnError="True"
                                            ValidationGroup="add">
                                        </asp:RequiredFieldValidator>
                                        <br />
                                        <asp:DropDownList ID="ddlSupervisorType" runat="server" CssClass="form-control"
                                            OnSelectedIndexChanged="ddlSupervisorType_SelectedIndexChanged" AutoPostBack="true">
                                            <asp:ListItem Value='i'>Immediate Supervisor</asp:ListItem>
                                            <asp:ListItem Value='s'>Supervisor</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </asp:Panel>

                    <div class="panel panel-default">
                        <header class="panel-heading">
                  Supervisor Assignment:
              </header>
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-md-4 form-group">
                                    <label>
                                        Current Supervisor :
                                    </label>
                                    <asp:DropDownList ID="ddlCurrentSupervisor" runat="server"
                                        CssClass="form-control">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-4 form-group autocomplete-form">
                                    <label>
                                        New  Supervisor :<span class="errormsg">*</span>
                                    </label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server"
                                        ControlToValidate="txtSuperVisorName" Display="dynamic"
                                        ErrorMessage="Required!" SetFocusOnError="True"
                                        ValidationGroup="add"></asp:RequiredFieldValidator>

                                    <asp:TextBox ID="txtSuperVisorName" runat="server"
                                        CssClass="form-control" AutoPostBack="false" AutoComplete="off"></asp:TextBox>

                                    <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server"
                                        DelimiterCharacters="" Enabled="true"
                                        ServicePath="~/Autocomplete.asmx" ServiceMethod="GetEmployeeList"
                                        TargetControlID="txtSuperVisorName" MinimumPrefixLength="1" CompletionInterval="10"
                                        EnableCaching="true" CompletionListCssClass="autocompleteTextBoxLP"
                                        OnClientItemSelected="GetEmpID">
                                    </cc1:AutoCompleteExtender>

                                    <cc1:TextBoxWatermarkExtender ID="txtemployee_TextBoxWatermarkExtender"
                                        runat="server" Enabled="True" TargetControlID="txtSuperVisorName"
                                        WatermarkCssClass="form-control" WatermarkText="Auto Complete">
                                    </cc1:TextBoxWatermarkExtender>

                                </div>
                                <div class="col-md-4 form-group">
                                    <label>
                                        &nbsp;
                                    </label>
                                    <br />
                                    <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="btn btn-primary"
                                        ValidationGroup="add" OnClick="btnAdd_Click" />
                                </div>
                            </div>
                            <div id="rpt" runat="server"></div>
                            <asp:Panel ID="supDis" runat="server" Visible="false">
                                <div class="row">
                                    <div class="col-md-12" id="rptDIs" runat="server">
                                    </div>
                                </div>
                            </asp:Panel>
                            <br />
                            <asp:Button ID="Btn_Save" runat="server" CssClass="btn btn-primary"
                                OnClick="Btn_Save_Click" Text="Save" ValidationGroup="External" />
                            <cc1:ConfirmButtonExtender ID="Btn_Save_ConfirmButtonExtender" runat="server"
                                ConfirmText="Confirm To Save ?" Enabled="True" TargetControlID="Btn_Save">
                            </cc1:ConfirmButtonExtender>

                            <asp:Button ID="btnReject" runat="server" CssClass="btn btn-primary" Text="Reject"
                                OnClick="btnReject_Click" />

                            <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server"
                                ConfirmText="Confirm To Reject ?" Enabled="True" TargetControlID="btnReject">
                            </cc1:ConfirmButtonExtender>

                            <asp:Button ID="BtnDelete" runat="server" CssClass="btn btn-primary" Text="Delete"
                                OnClick="BtnDelete_Click" />
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
        </ContentTemplate>
    </asp:UpdatePanel>


</asp:Content>

