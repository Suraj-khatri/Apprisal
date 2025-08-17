<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="ManageTemporaryTransfer.aspx.cs" Inherits="SwiftHrManagement.web.EmployeeMovement.TemporaryTransferPlan.ManageTemporaryTransfer" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
    <script type="text/javascript" src="../../Jsfunc.js"></script>
    </head>
     <div class="row">
        <div class="col-md-10 col-md-offset-1">
    
     <div class="panel">
        <header class="panel-heading">
              <i class="fa fa-caret-right"></i> Temporary Transfer
        </header>
        <div class="panel-body">
            <span class="txtlbl" >Please enter valid  data</span><br />
            <span class="required" >(* Required fields)</span><br />
            <asp:Label ID="lblmsg" runat="server" Text=""></asp:Label>
            <div class="row">
                <div class="col-md-4 form-group">
                    <label>
            Transfer Type:<span class="errormsg">*</span>
                    </label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                ControlToValidate="DdlTransferType" Display="None" 
                ErrorMessage="RequiredFieldValidator" SetFocusOnError="True" 
                ValidationGroup="External"></asp:RequiredFieldValidator>
            <br />
            <asp:DropDownList ID="DdlTransferType" runat="server" CssClass="form-control"
              onselectedindexchanged="DdlOperationType_SelectedIndexChanged" 
                AutoPostBack="True">
                 <asp:ListItem Value="">Select</asp:ListItem>
                <asp:ListItem Value="T">Temporary Transfer</asp:ListItem>
                <asp:ListItem Value="AR">Additional Responsibility</asp:ListItem>
                <asp:ListItem Value="A">Assignment</asp:ListItem>
                <asp:ListItem Value="TA">Temporary Assignment</asp:ListItem>               
            </asp:DropDownList>
                </div>
                </div> 
            <div class="row">
                <div class="col-md-6 form-group">
                    <label>
                           Employee Name : 
                    </label>
                             <asp:Label ID="lblEmpName" runat="server" CssClass="form-control"></asp:Label>
                             <asp:HiddenField ID="hdnEmpName" runat="server" />
                    </div>
                <div class="col-md-6 autocomplete-form"><label>&nbsp;</label><br />
                        <asp:TextBox ID="txtEmployee" runat="server" AutoComplete="on" 
                            AutoPostBack="true" ontextchanged="txtEmployee_TextChanged" CssClass="form-control"></asp:TextBox>
                        <cc1:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server"  
                            CompletionInterval="10" CompletionListCssClass="autocompleteTextBoxLP" 
                            DelimiterCharacters="" EnableCaching="true" Enabled="true" 
                            MinimumPrefixLength="1" ServiceMethod="GetEmployeeList" 
                            ServicePath="~/Autocomplete.asmx" TargetControlID="txtEmployee"
                            OnClientItemSelected="GetEmpName">
                        </cc1:AutoCompleteExtender>   
                    <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2"
                                    runat="server" Enabled="True" TargetControlID="txtEmployee"
                                    WatermarkCssClass="form-control" WatermarkText="Auto Complete">
                                </cc1:TextBoxWatermarkExtender>
                </div>
        </div>
    </div>
    </div>
    <div class="panel panel-default">
        <header class="panel">
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
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="ddlSupervisorType" Display="dynamic" 
                        ErrorMessage="Required!" SetFocusOnError="True" 
                        ValidationGroup="add"></asp:RequiredFieldValidator>
                        <br />
                        <asp:DropDownList ID="ddlSupervisorType" runat="server" CssClass="form-control" 
                          onselectedindexchanged="ddlSupervisorType_SelectedIndexChanged" >
                         <asp:ListItem Value='i'>Immediate Supervisor</asp:ListItem>
                          <asp:ListItem Value='s'>Supervisor</asp:ListItem>
                         
                        </asp:DropDownList>
                </div>
                <div class="col-md-4 form-group">
                    <label>
                  Current Supervisor :
                    </label> <%--<span class="errormsg">*</span>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                        ControlToValidate="ddlSupervisorType" Display="dynamic" 
                        ErrorMessage="Required!" SetFocusOnError="True" 
                        ValidationGroup="add"></asp:RequiredFieldValidator>--%>
                       
                        <asp:DropDownList ID="ddlCurrentSupervisor" runat="server" width="100%"
                         CssClass="form-control">
                         </asp:DropDownList>
                </div>
                <div class="col-md-12" id="showHide" runat="server">
            </div>
                </div>
            <br />
            <div class="row">
                <div class="col-md-8 form-group autocomplete-form">
                    <label>
                           Supervisor Name:<span class="errormsg">*</span>
                    </label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                            ControlToValidate="txtSuperVisorName" Display="dynamic" 
                            ErrorMessage="Required!" SetFocusOnError="True" 
                            ValidationGroup="add"></asp:RequiredFieldValidator>
                     <asp:TextBox ID="txtSuperVisorName" runat="server" 
                          CssClass="form-control" AutoPostBack="false" AutoComplete="off"></asp:TextBox>
                <%--</div>--%>
<%--                <div class="col-md-4 form-group autocomplete-form">
                    <label>
                        &nbsp;
                    </label><br />--%>
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
                <div class="col-md-4 form-group pull-right">
                   <label>
                        &nbsp;
                    </label><br />
                     <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="btn btn-primary" 
                           ValidationGroup="add" onclick="btnAdd_Click" />
                </div>
            </div>
              <div id="rpt" runat="server">
                     </div>

            <div class="row">
                <div class="col-md-4 form-group">
                    <label>
                        From Branch: <span class="errormsg">*</span>
                    </label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
                ControlToValidate="DdlFromBranch" Display="None" 
                ErrorMessage="RequiredFieldValidator" SetFocusOnError="True" 
                ValidationGroup="External"></asp:RequiredFieldValidator>
            <br />
            <asp:DropDownList ID="DdlFromBranch" runat="server" Enabled="false" CssClass="form-control">
            </asp:DropDownList>
                </div>
                <div class="col-md-4 form-group">
                    <label>
                         From Department: <span class="errormsg">*</span>
                    </label>
            <asp:RequiredFieldValidator 
                 ID="RequiredFieldValidator11" runat="server" ControlToValidate="DdlFromDept" 
                 Display="None" ErrorMessage="RequiredFieldValidator" 
                 SetFocusOnError="True" ValidationGroup="External">
            </asp:RequiredFieldValidator>
                 <br />
            <asp:DropDownList ID="DdlFromDept" runat="server" AutoPostBack="True" 
                 CssClass="form-control">
            </asp:DropDownList>
                </div>
                <div class="col-md-4 form-group">
                    <label>
                         Transfer Branch: <span class="errormsg">*</span>
                    </label>
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator2" 
                runat="server" ControlToValidate="DdlToBranch" Display="None" 
                ErrorMessage="RequiredFieldValidator" ValidationGroup="External" 
                SetFocusOnError="True"></asp:RequiredFieldValidator><br />
            <asp:DropDownList ID="DdlToBranch" runat="server" AutoPostBack="True" 
                CssClass="form-control" onselectedindexchanged="DdlToBranch_SelectedIndexChanged1"
                >
            </asp:DropDownList>
                </div>
            </div>
            <div class="row">
                <div class="col-md-4 form-group">
                    <label>
                         Transfer Department: <span class="errormsg">*</span>
                    </label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" 
                    runat="server" ControlToValidate="DdlToDept" Display="None" 
                    ErrorMessage="RequiredFieldValidator" ValidationGroup="External" 
                    SetFocusOnError="True"></asp:RequiredFieldValidator><br />
                <asp:DropDownList ID="DdlToDept" runat="server" CssClass="form-control">
                </asp:DropDownList>
                </div>
                <div class="col-md-4 form-group">
                    <label>
                         <span>Effective Date:</span>  <span class="errormsg">*</span>
                    </label>
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator3" 
                    runat="server" ControlToValidate="txtEffectiveDate" Display="dynamic" 
                    ErrorMessage="RequiredFieldValidator" ValidationGroup="External" 
                    SetFocusOnError="True"></asp:RequiredFieldValidator><br />
                <asp:TextBox ID="txtEffectiveDate" runat="server" CssClass="form-control" ></asp:TextBox>
                <cc1:CalendarExtender ID="txtEffectiveDate_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="txtEffectiveDate">
                </cc1:CalendarExtender>
                </div>
                <div class="col-md-4 form-group">
                    <label>
                        To Date: 
                    </label>        
                    <asp:CompareValidator ID="CompareValidator1" runat="server" 
                    ControlToCompare="txtEffectiveDate" ControlToValidate="txtToDate" 
                    ErrorMessage="Invalid Date!" Operator="GreaterThanEqual" SetFocusOnError="True"  Type="Date"
                    ValidationGroup="External"></asp:CompareValidator><br />
                <asp:TextBox ID="txtToDate" runat="server" CssClass="form-control" ></asp:TextBox>
                <cc1:CalendarExtender ID="txtToDate_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="txtToDate">
                </cc1:CalendarExtender>
                </div>
            </div>
            <div class="row">
                <div class="col-md-6 form-group">
                    <label>
                        Transfer Description: <span class="errormsg">*</span>
                    </label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" 
                    runat="server" ControlToValidate="txtTransferDesc" Display="none" 
                    ErrorMessage="RequiredFieldValidator" ValidationGroup="External" 
                    SetFocusOnError="True"></asp:RequiredFieldValidator><br />
                <asp:TextBox ID="txtTransferDesc" runat="server" 
                    CssClass="form-control" TextMode="MultiLine" ></asp:TextBox>
                </div>
                </div>
            <br />
                 <asp:Button ID="Btn_Save" runat="server" CssClass="btn btn-primary" 
                     Text="Save" ValidationGroup="External" onclick="Btn_Save_Click" />
                <cc1:ConfirmButtonExtender ID="Btn_Save_ConfirmButtonExtender" runat="server" 
                    ConfirmText="Confirm To Save ?" Enabled="True" TargetControlID="Btn_Save">
                </cc1:ConfirmButtonExtender>
                <asp:Button ID="BtnDelete" runat="server" CssClass="btn btn-primary" Text="Delete" onclick="BtnDelete_Click" 
                     />
                <cc1:ConfirmButtonExtender ID="BtnDelete_ConfirmButtonExtender" runat="server" 
                    ConfirmText="Confirm To Delete ?" Enabled="True" TargetControlID="BtnDelete">
                </cc1:ConfirmButtonExtender>
                <asp:Button ID="BtnBack" runat="server" CssClass="btn btn-primary" 
                    Text="Back" onclick="BtnBack_Click"  />
                         <asp:Button ID="btnSupervisorDelete" runat="server" CssClass="btn btn-primary" 
                    Text="" onclick="btnSupervisorDelete_Click" style="display:none;" />
            </div>

        </div>
    </div>
</asp:Content>
