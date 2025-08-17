<%@ Page Title="Swift HRM" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="SwiftHrManagement.web.Company.EmployeeWeb.Promotion.Manage" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="/js/functions.js" type="text/javascript"> </script>
    <style type="text/css">
        .Nodisplay {
            display: none;
        }

        .display {
            display: block;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <script type="text/javascript" language="javascript">

        function GetEmpName(sender, e) {
            var EmpIdArray = (e._value).split("|");
            document.getElementById("<%=hdnEmpName.ClientID%>").Value = EmpIdArray[1];
        }

        function GetEmpID(sender, e) {
            var customerValueArray = (e._value).split("|");
            document.getElementById("hddEmpId").Value = customerValueArray[1];

        }
        function OnDelete(RowID) {
            if (confirm("Are you sure to Delete this message?")) {
                document.getElementById("<% =hdnSupervisorId.ClientID %>").value = RowID;
                document.getElementById("<% =btnSupervisorDelete.ClientID %>").click();
            }
        }


    </script>


    <head>
        <script type="text/javascript" src="/js/Jsfunc.js"></script>
    </head>
    <asp:HiddenField ID="hdnBasic" runat="server" />
    <asp:HiddenField ID="hdnGrade" runat="server" />
    <div class="row">
        <div class="col-md-10 col-md-offset-1">
    
    <div class="panel">
        <header class="panel-heading">
               <i class="fa fa-caret-right"></i>
            Employee Promotion Details
        </header>
        <div class="panel-body">
            Promotion Form
            <span class="txtlbl">Plese enter valid data! <span class="required">&nbsp;(* Required fields)</span></span><br />
            <div>
                <asp:Label ID="LblMsg" runat="server"></asp:Label>
            </div>
            <br />
            <asp:Button ID="btnSupervisorDelete" runat="server" CssClass="btn btn-primary"
                Text="" OnClick="btnSupervisorDelete_Click" Style="display: none;" />
            <div class="row">
                <div class="col-md-8 form-group autocomplete-form">
                    <label>
                        Employee Name :
                    </label>
                    <asp:Label ID="lblEmpName" runat="server"></asp:Label>
                    <asp:HiddenField ID="hdnEmpName" runat="server" />
                    <asp:TextBox ID="txtEmployee" runat="server" AutoComplete="on"
                        Width="100%"
                        AutoPostBack="true" OnTextChanged="txtEmployee_TextChanged" CssClass="form-control"></asp:TextBox>
                    <cc1:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server"
                        CompletionInterval="10" CompletionListCssClass="autocompleteTextBoxLP"
                        DelimiterCharacters="" EnableCaching="true" Enabled="true"
                        MinimumPrefixLength="1" ServiceMethod="GetEmployeeList"
                        ServicePath="~/Autocomplete.asmx" TargetControlID="txtEmployee"
                        OnClientItemSelected="GetEmpName">
                    </cc1:AutoCompleteExtender>
                </div>
            </div>
            <div class="row">
                <div class="col-md-4 form-group">
                    <label>
                        Effective Date:<span class="errormsg">*</span>
                    </label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                        ControlToValidate="TxtPromotionDate" Display="dynamic"
                        ErrorMessage="Required!" SetFocusOnError="True"
                        ValidationGroup="promotion"></asp:RequiredFieldValidator>

                    <asp:TextBox ID="TxtPromotionDate" runat="server" CssClass="form-control"></asp:TextBox>
                    <cc1:CalendarExtender ID="TxtPromotionDate_CalendarExtender" runat="server"
                        Enabled="True" TargetControlID="TxtPromotionDate">
                    </cc1:CalendarExtender>
                </div>
                <div class="col-md-4 form-group">
                    <label>
                        Apply On:<span class="errormsg">*</span>
                    </label>

                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                        ControlToValidate="txtApplyOn" Display="dynamic"
                        ErrorMessage="Required!" SetFocusOnError="True"
                        ValidationGroup="promotion"></asp:RequiredFieldValidator>

                    <asp:TextBox ID="txtApplyOn" runat="server" CssClass="form-control"></asp:TextBox>
                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server"
                        Enabled="True" TargetControlID="txtApplyOn">
                    </cc1:CalendarExtender>
                </div>
                <div class="col-md-4 form-group">
                    <label>
                        Branch:
                    </label>

                    <asp:DropDownList ID="DdlBranch" runat="server" CssClass="form-control">
                    </asp:DropDownList>
                </div>
               
            </div>
            <div class="row">
                 <div class="col-md-4 form-group">
                    <label>
                        Department:
                    </label>
                    <asp:DropDownList ID="DdlDepartment" runat="server" CssClass="form-control">
                    </asp:DropDownList>
                </div>
                 <div id="subdept" runat="server" class="col-md-4 form-group" Visible="False">
                    <label>
                        Sub-Department:
                    </label>
                    <asp:DropDownList ID="DdlSubDepartment" runat="server" CssClass="form-control">
                    </asp:DropDownList>
                </div>
                <div class="col-md-4 form-group">
                    <label>
                        Current Position:
                    </label>
                    <asp:DropDownList ID="DdlCurPosition" runat="server" CssClass="form-control">
                    </asp:DropDownList>
                </div>
                <div class="col-md-4 form-group">
                    <label>Promoted To:<span class="errormsg">*</span></label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                        ControlToValidate="DdlpromPosition" Display="dynamic"
                        ErrorMessage="Required!" SetFocusOnError="True"
                        ValidationGroup="promotion"></asp:RequiredFieldValidator>
                    <br />
                    <asp:DropDownList
                        ID="DdlpromPosition" runat="server"
                        CssClass="form-control" AutoPostBack="true">
                    </asp:DropDownList>
                </div>
            </div>
        <div class="row">
            <div class="col-md-12">
                <label>Promotion With New Supervisor</label>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12 form-group">
                <asp:HiddenField ID="hddEmpId" runat="server" />
                <asp:HiddenField ID="hdnSupervisorId" runat="server" />
                <asp:Label ID="lblSupervisorAssign" runat="server"></asp:Label>
            </div>
        </div>
        <div class="row">
            <div class="col-md-4 form-group">
                <label>
                    Supervisor Type:<span class="errormsg">*</span>
                </label>

                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                    ControlToValidate="ddlSupervisorType" Display="dynamic"
                    ErrorMessage="Required!" SetFocusOnError="True"
                    ValidationGroup="add"></asp:RequiredFieldValidator>
                <br />
                <asp:DropDownList ID="ddlSupervisorType" runat="server" CssClass="form-control"
                    Width="100%" OnSelectedIndexChanged="ddlSupervisorType_SelectedIndexChanged" AutoPostBack="true">
                    <asp:ListItem Value='i'>Immediate Supervisor</asp:ListItem>
                    <asp:ListItem Value='s'>Supervisor</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-md-4 form-group">
                <label>
                    Current Supervisor :
                </label>
                <asp:DropDownList ID="ddlCurrentSupervisor" runat="server"
                    CssClass="form-control" Width="100%">
                </asp:DropDownList>
            </div>
            <div class="col-md-4 form-group autocomplete-form">
                <label>
                    New  Supervisor :
                </label>
                <asp:TextBox ID="txtSuperVisorName" runat="server" Width="100%"
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
                    WatermarkCssClass="watermark" WatermarkText="Auto Complete">
                </cc1:TextBoxWatermarkExtender>
            </div>
        </div>
            <br />
            <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="btn btn-primary"
                ValidationGroup="add" OnClick="btnAdd_Click" />

            <br />
           
            <div class="row" id="Salary" runat="server" visible="false">
                <div class="col-md-12 form-group">
                    <div id="rpt" runat="server">
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <label>Promotion With New Salary Set & Grade:</label>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12 form-group">
                    <label>
                        Old Salary Detail
                    </label>
                    <div id="oldSal" runat="server"></div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12 form-group">
                    <label>
                        New Salary Detail<span class="errormsg">*</span>
                         <label>Salary Set</label>
                    </label>
                    <label>&nbsp;</label><br />
                    <asp:DropDownList ID="salarySet" runat="server" CssClass="form-control"
                        AutoPostBack="True" OnSelectedIndexChanged="salarySet_SelectedIndexChanged">
                    </asp:DropDownList>
                    
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                        ControlToValidate="salarySet" Display="dynamic"
                        ErrorMessage="Required!" SetFocusOnError="True"
                        ValidationGroup="promotion"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12 form-group">
                     <div id="newSal" runat="server"></div>
                </div>
            </div>
               
                <asp:Button ID="BtnSave" runat="server" CssClass="btn btn-primary" Text="Save"
                    OnClick="BtnSave_Click" ValidationGroup="promotion" />
                <cc1:ConfirmButtonExtender ID="BtnSave_ConfirmButtonExtender" runat="server"
                    ConfirmText="Confirm To Save?" Enabled="True" TargetControlID="BtnSave">
                </cc1:ConfirmButtonExtender>
                &nbsp;<asp:Button ID="BtnDelete" runat="server" CssClass="btn btn-primary" Text="Delete" OnClick="BtnDelete_Click" Visible="False" />
                <cc1:ConfirmButtonExtender ID="BtnDelete_ConfirmButtonExtender" runat="server"
                    ConfirmText="Confirm To Delete?" Enabled="True" TargetControlID="BtnDelete">
                </cc1:ConfirmButtonExtender>
                &nbsp;<asp:Button ID="BtnCancel" runat="server" CssClass="btn btn-primary"
                    Text="Back" OnClick="BtnCancel_Click" />
             </div>
    </div>
            </div>
    </div>
</asp:Content>
