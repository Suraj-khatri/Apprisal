<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true"
    CodeBehind="onSiteDutyManage.aspx.cs" Inherits="SwiftHrManagement.web.EmployeeMovement.onSiteDuty.onSiteDutyManage" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <head>
        <script type="text/javascript" src="../../Jsfunc.js"></script>
    </head>
    <asp:HiddenField ID="hdnDetailId" runat="server" />
    <asp:Button ID="btnDeleteDetail" runat="server" Text="Delete" OnClick="btnDeleteDetail_Click" Style="display: none;" />
     <div class="row">
        <div class="col-md-10 col-md-offset-1">
    
    <div class="panel">
        <header class="panel-heading">
              <i class="fa fa-caret-right"></i> Onsite Duty Record
        </header>
        <div class="panel-body">
            OnSite Duty Entry
            <span class="txtlbl">Please enter valid data</span> <span class="required">(* Required fields)</span><br />
            <asp:Label ID="lblmsg" runat="server" Text=""></asp:Label>
            <asp:HiddenField ID="HiddenEmpid" runat="server" />

            <div class="row">
                <div class="col-md-4 autocomplete-form form-group">
                    <label>
                        Employee Name : <span class="errormsg">*</span>
                    </label>

                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEmpId"
                        ErrorMessage="Required" ValidationGroup="onsiteduty" AutoPostBack="false">
                    </asp:RequiredFieldValidator>

                    <asp:TextBox ID="txtEmpId" runat="server" CssClass="form-control" 
                        AutoComplete="Off"></asp:TextBox>
                    <cc1:AutoCompleteExtender ID="txtEmpId_AutoCompleteExtender" runat="server" DelimiterCharacters=""
                        Enabled="True" TargetControlID="txtEmpId" CompletionListCssClass="autocompleteTextBoxLP"
                        ServicePath="~/Autocomplete.asmx" ServiceMethod="GetEmployeeList" MinimumPrefixLength="1"
                        CompletionInterval="10" EnableCaching="true" OnClientItemSelected="AutocompleteOnSelected">
                    </cc1:AutoCompleteExtender>
                </div>
                <div class="col-md-4 form-group">
                    <label>
                        &nbsp;
                    </label>
                    <br />
                    <asp:Button runat="server" ID="btnAdd" CssClass="btn btn-primary" Text="Add"
                        ValidationGroup="onsiteduty" OnClick="btnAdd_Click" />
                </div>
            </div>

            <div class="row">
            <div class="col-md-12">
                <div id="rptOnsiteDetail" runat="server">
                </div>
            </div>
                </div>

            <div class="row">
                <div class="col-md-4 form-group">
                    <label>
                        From Date : <span class="errormsg">*</span>
                    </label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtDateFrom"
                        ErrorMessage="Required" ValidationGroup="detail"></asp:RequiredFieldValidator>
                
                <asp:TextBox ID="txtDateFrom" runat="server" CssClass="form-control"></asp:TextBox>
                <cc1:CalendarExtender ID="txtDateFrom_CalendarExtender" runat="server" TargetControlID="txtDateFrom">
                </cc1:CalendarExtender>
            </div>
            <div class="col-md-4 form-group">
                <label>
                    To Date : <span class="errormsg">*</span>
                </label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtDateTo"
                    ErrorMessage="Required" ValidationGroup="detail"></asp:RequiredFieldValidator>
            
            <asp:TextBox ID="txtDateTo" runat="server" CssClass="form-control"></asp:TextBox>
            <cc1:CalendarExtender ID="txtDateTo_CalendarExtender" runat="server" TargetControlID="txtDateTo">
            </cc1:CalendarExtender>
        </div>
        <div class="col-md-4 form-group">
            <label>
                Location : <span class="errormsg">*</span>
            </label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtLocation"
                ErrorMessage="Required" ValidationGroup="detail"></asp:RequiredFieldValidator>
        <asp:TextBox ID="txtLocation" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    </div>

     <div class="row">
         <div class="col-md-4 form-group">
             <label>
                 Purpose : <span class="errormsg">*</span>
             </label>
             <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtPurpose"
                 ErrorMessage="Required" ValidationGroup="detail"></asp:RequiredFieldValidator>
         <asp:TextBox ID="txtPurpose" runat="server" CssClass="form-control"></asp:TextBox>
     </div>
    <div class="col-md-4 form-group">
        <label>
            Approve By : <span class="errormsg">*</span>
        </label>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtApproveBy"
            ErrorMessage="Required" ValidationGroup="detail"></asp:RequiredFieldValidator>
   
    <asp:TextBox ID="txtApproveBy" runat="server" CssClass="form-control"></asp:TextBox>
    <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" DelimiterCharacters=""
        Enabled="True" TargetControlID="txtApproveBy" CompletionListCssClass="autocompleteTextBoxLP"
        ServicePath="~/Autocomplete.asmx" ServiceMethod="GetEmployeeList" MinimumPrefixLength="1"
        CompletionInterval="10" EnableCaching="true" OnClientItemSelected="AutocompleteOnSelected">
    </cc1:AutoCompleteExtender>
    </div>
    <%--<div id="Div1" runat="server"></div>--%>
     <div id="approvedDate" runat="server">
    <div class="col-md-4 form-group">
        <label>
            Approved Date :
        </label>

        <asp:TextBox ID="txtApprovedDate" runat="server" CssClass="form-control" />
        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtApprovedDate" />
    </div>
    </div>
    </div>
        <div class="row">
            <div class="col-md-12">
                <div id="Div2" runat="server">
            </div>
            </div>
        </div>
    
   
        <div class="row">
            <div class="col-md-6 form-group">
                <label>
                    Description : <span class="errormsg">*</span>
                </label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtDesc"
                    ErrorMessage="Required" ValidationGroup="detail"></asp:RequiredFieldValidator>
                <asp:TextBox ID="txtDesc" runat="server" CssClass="form-control" Width="100%" TextMode="MultiLine"></asp:TextBox>
            </div>
            </div>
     <div id="ApprovedRemarks" runat="server">
         <div class="row">
        <div class="col-md-6 form-group">
            <label>
              Approved Remarks :
            </label>
             <asp:TextBox ID="txtAppRemarks" runat="server" CssClass="form-control" Width="100%" TextMode="MultiLine"/>
        </div>
       
    </div>
    </div>
        <br/>
     <asp:Button ID="Btn_Save" runat="server" CssClass="btn btn-primary" Text="Save" ValidationGroup="detail"
         OnClick="Btn_Save_Click" />
    <cc1:ConfirmButtonExtender ID="btnSave_ConfirmButtonExtender" runat="server" ConfirmText="Confirm to Save?"
        Enabled="True" TargetControlID="Btn_Save">
    </cc1:ConfirmButtonExtender>
    <asp:Button ID="BtnDelete" runat="server" CssClass="btn btn-primary" Text="Delete" OnClick="BtnDelete_Click" />
    <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" ConfirmText="Confirm to Delete?"
        Enabled="True" TargetControlID="BtnDelete">
    </cc1:ConfirmButtonExtender>
    <asp:Button ID="BtnBack" runat="server" CssClass="btn btn-primary" Text="Back" OnClick="BtnBack_Click" />
    </div>
  </div>
        </div>
            </div>
      
    <script language="javascript" type="text/javascript">

        function AutocompleteOnSelected(sender, e) {
            var customerValueArray = (e._value).split("|");
            document.getElementById("<%=HiddenEmpid.ClientID%>").value = customerValueArray[1];
        }
        function IsDeleteDetail(id) {
            if (confirm("Confirm Delete?")) {
                document.getElementById("<% =hdnDetailId.ClientID %>").value = id;
                document.getElementById("<% =btnDeleteDetail.ClientID %>").click();
            }
        }
    </script>
</asp:Content>
