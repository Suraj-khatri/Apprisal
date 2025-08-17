<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="ManageRequest.aspx.cs" Inherits="SwiftHrManagement.web.TravelOrder.ManageRequest" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var GB_ROOT_DIR = "/greybox/";
    </script>
    <script type="text/javascript" src="/greybox/AJS.js"></script>
    <script type="text/javascript" src="/greybox/gb_scripts.js"></script>
    <link href="/greybox/gb_styles.css" rel="stylesheet" type="text/css" media="all" />

    <script type="text/javascript" language="javascript">
        function LeaveExtendPopup() {

            var empId = document.getElementById("<%=hdnID.ClientID %>").value;
            var fromdate = document.getElementById("<%=txtdurex_from.ClientID%>").value;
            var todate = document.getElementById("<%=txtdurexto.ClientID%>").value;

            GB_showCenter("Leave Management module", "/TravelOrder/LeaveExtension.aspx?isMasterPageLess=Y&emp_id=" + empId + "&from=" + fromdate + "&to=" + todate, 520, 645, "");

        }
        function OnDelete(ID) {
            if (confirm("Are you sure to Delete this?")) {
                document.getElementById("<% =hdnAuthorisedBy.ClientID %>").value = ID;
                document.getElementById("<%=btnDeleteAuthorisation.ClientID %>").click();
            }
        }

        function DeleteCurrency(ID) {
            if (confirm("Are you sure to Delete this?")) {
                document.getElementById("<% =hdnCurrency.ClientID %>").value = ID;
                document.getElementById("<%=btnDeleteCurrency.ClientID %>").click();
            }
        }

        function GetId() {
            var notificationList = document.getElementById("notificationList");
            var ids = notificationList.contentWindow.GetIdListForNotification();
            //            alert(ids);
            var HiddenFieldempEmail = document.getElementById("<%=HiddenFieldEmpEmail.ClientID %>");
            HiddenFieldempEmail.value = ids;
            //            alert(HiddenFieldempEmail.value);
            return false;
        }

    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">

    <head>
        <script type="text/javascript" src="../../Jsfunc.js"></script>
    </head>
    <asp:UpdatePanel runat="server" ID="pnl1">
        <ContentTemplate>
            <div class="row">
                <div class="col-md-10 col-md-offset-1">
            <div class="panel">
                <header class="panel-heading">
            <i class="fa fa-caret-right"></i>
            Travel Authorization Form
        </header>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-md-12">
                            <asp:Label ID="printMsg" runat="server" Text="Message:" Visible="false"></asp:Label>
                        </div>
                        <div class="col-md-12">
                            Please enter valid data!
                    <asp:HiddenField ID="hdnID" runat="server" />
                            <asp:HiddenField ID="HiddenFieldEmpEmail" runat="server" />
                            <asp:Label ID="LblMsg" runat="server" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6 form-group">
                            <label>Employee Name:</label>
                            <asp:Label ID="LblEmpName" runat="server" />
                        </div>
                        <div class="col-md-6 autocomplete-form form-group">
                            <asp:TextBox ID="txtEmpName" runat="server" AutoComplete="Off"
                                AutoPostBack="true" CssClass="form-control"
                                OnTextChanged="txtEmpName_TextChanged" />
                            <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server"
                                CompletionInterval="10" CompletionListCssClass="autocompleteTextBoxLP"
                                DelimiterCharacters="" EnableCaching="true" Enabled="true"
                                MinimumPrefixLength="1" ServiceMethod="GetEmployeeListByNameORId"
                                ServicePath="~/Autocomplete.asmx" TargetControlID="txtEmpName" />
                            <cc1:TextBoxWatermarkExtender ID="vendor_TextBoxWatermarkExtender"
                                runat="server" Enabled="True" TargetControlID="txtEmpName"
                                WatermarkCssClass="form-control" WatermarkText="All Employee" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6 form-group">
                            <label>Branch:</label>
                            <asp:Label ID="txtbranch" runat="server" ReadOnly="true" />
                        </div>
                        <div class="col-md-6 form-group">
                            <label>Department:</label>
                            <asp:Label ID="txtdepartment" runat="server" ReadOnly="true" />
                        </div>
                        <div class="col-md-6 form-group">
                            <label>Position:</label>
                            <asp:Label ID="txtposition" runat="server" ReadOnly="true" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-4 form-group">
                            <label>Country:<span class="required">*</span></label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                ControlToValidate="DdlCountry" ErrorMessage="Required!" ValidationGroup="tada"
                                SetFocusOnError="True" />
                            <asp:DropDownList ID="DdlCountry" runat="server" CssClass="form-control" />
                        </div>
                        <div class="col-md-4 form-group">
                            <label>City:<span class="required">*</span></label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                ControlToValidate="txtdestinationcity" ErrorMessage="Required!" ValidationGroup="tada"
                                SetFocusOnError="True" />
                            <asp:TextBox ID="txtdestinationcity" runat="server" CssClass="form-control" />
                        </div>
                    
                        <div class="col-md-4 form-group">
                            <label>Reason for Travel:<span class="required">*</span></label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                                ControlToValidate="DdlTravelReason" ErrorMessage="Required!" ValidationGroup="tada"
                                SetFocusOnError="True" />
                            <asp:DropDownList ID="DdlTravelReason" runat="server" CssClass="form-control"
                                AutoPostBack="true" OnSelectedIndexChanged="DdlTravelReason_SelectedIndexChanged" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6 form-group">
                            <label>Travel Description:</label>
                            <asp:TextBox ID="txtTravelDescription" runat="server"
                                CssClass="form-control" TextMode="MultiLine" />
                        </div>
                    </div>

                    <div id="divtraveldate" class="row" runat="server" visible="true">
                        <div class="col-md-4 form-group">
                            <label>From Date:<span class="required">*</span></label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                ControlToValidate="txtdurationto" ErrorMessage="Required!" ValidationGroup="tada"
                                SetFocusOnError="True" />
                            <asp:TextBox ID="txtdurationfrom" runat="server" CssClass="form-control" />
                            <cc1:CalendarExtender ID="CalendarExtender3" runat="server"
                                TargetControlID="txtdurationfrom" />
                        </div>
                        <div class="col-md-4 form-group">
                            <label>To Date:<span class="required">*</span></label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                                ControlToValidate="txtdurationto" ErrorMessage="Required!" ValidationGroup="tada"
                                SetFocusOnError="True" />
                            <asp:Label ID="lbldate" runat="server" ForeColor="#CC0000" />
                            <asp:TextBox ID="txtdurationto" runat="server" CssClass="form-control"
                                OnTextChanged="txtdurationto_TextChanged1" AutoPostBack="true" />
                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server"
                                TargetControlID="txtdurationto" />
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-4 form-group">
                            <label>Extension of Visit:<span class="required">*</span></label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"
                                ControlToValidate="Ddlex" ErrorMessage="Required!" ValidationGroup="tada"
                                SetFocusOnError="True" />
                            <asp:Label ID="lblexterror" runat="server" ForeColor="#CC0000" />
                            <asp:DropDownList ID="Ddlex" runat="server" CssClass="form-control" AutoPostBack="true"
                                OnSelectedIndexChanged="Ddlex_SelectedIndexChanged">
                                <asp:ListItem Value="">Select</asp:ListItem>
                                <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                <asp:ListItem Value="No">No</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <!--################ START EXTENSION OF VISIT-->
                    <div id="divIsExtVisit" class="row" runat="server" visible="false">
                        <div class="col-md-4 form-group">
                            <label>From:<span class="required">*</span></label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server"
                                ControlToValidate="txtdurex_from" ErrorMessage="Required!" ValidationGroup="tada"
                                SetFocusOnError="True" />
                            <asp:TextBox ID="txtdurex_from" runat="server" CssClass="form-control"
                                AutoPostBack="True" />
                            <cc1:CalendarExtender ID="CalendarExtender2" runat="server"
                                TargetControlID="txtdurex_from" />
                        </div>
                        <div class="col-md-4 form-group">
                            <label>To:<span class="required">*</span></label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server"
                                ControlToValidate="txtdurexto" ErrorMessage="Required!" ValidationGroup="tada"
                                SetFocusOnError="True" />
                            <asp:Label ID="lblerrordate" runat="server" ForeColor="#CC0000" />
                            <asp:TextBox ID="txtdurexto" runat="server" CssClass="form-control"
                                AutoPostBack="True" OnTextChanged="txtdurationto_TextChanged" />
                            <cc1:CalendarExtender ID="CalendarExtender4" runat="server"
                                TargetControlID="txtdurexto" />
                        </div>
                        <div class="row">
                            <div class="col-md-4 form-group">
                                <label>Country:<span class="required">*</span></label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server"
                                    ControlToValidate="DdlCountry2" ErrorMessage="Required!" ValidationGroup="tada"
                                    SetFocusOnError="True" />
                                <asp:DropDownList ID="DdlCountry2" runat="server" CssClass="form-control" />
                            </div>
                            <div class="col-md-4 form-group">
                                City :<span class="required">*</span>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server"
                                    ControlToValidate="txtdurexcity" ErrorMessage="Required!" ValidationGroup="tada"
                                    SetFocusOnError="True" />
                                <asp:TextBox ID="txtdurexcity" runat="server" CssClass="form-control" />
                            </div>
                        </div>
                        <div class="col-md-4 form-group">
                            <label>No Of Days:</label>
                            <asp:Label ID="lblnoofdays" runat="server" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-4 form-group">
                            <label>Mode of Travel:<span class="required">*</span></label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server"
                                ControlToValidate="Ddlmode" ErrorMessage="Required!" ValidationGroup="tada"
                                SetFocusOnError="True" />
                            <asp:DropDownList ID="Ddlmode" runat="server" CssClass="form-control"
                                OnSelectedIndexChanged="Ddlmode_SelectedIndexChanged1" AutoPostBack="true" />
                        </div>
                        <div class="col-md-4 form-group">
                            <label>Transportation Arrangement:<span class="required">*</span></label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server"
                                ControlToValidate="Ddltransportation" ErrorMessage="Required!" ValidationGroup="tada"
                                SetFocusOnError="True" />
                            <asp:DropDownList ID="Ddltransportation" runat="server" CssClass="form-control"
                                OnSelectedIndexChanged="Ddltransportation_SelectedIndexChanged" AutoPostBack="true" />
                        </div>
                    </div>
                    <!--################ START FLIGHT DETAILS FORM-->
                    <div id="divFlightDetails" class="row" runat="server" visible="false">
                        <div class="col-md-12">
                            <label><strong>Flight Details</strong></label>
                        </div>
                        <div class="col-md-4 form-group">
                            <label>Flight Date:</label>
                            <asp:TextBox ID="txtFlightDate" runat="server" CssClass="form-control" />
                            <cc1:CalendarExtender ID="ceFlightDate" runat="server"
                                TargetControlID="txtFlightDate" />
                        </div>
                        <div class="col-md-4 form-group">
                            <label>From (Place):</label>
                            <asp:TextBox ID="txtFromPlace" runat="server" CssClass="form-control" />
                        </div>
                        <div class="row">
                            <div class="col-md-4 form-group">
                                <label>To (Place):</label>
                                <asp:TextBox ID="txtToPlace" runat="server" CssClass="form-control" />
                            </div>
                            <div class="col-md-4 form-group">
                                <label>Flight Time/Schedule:</label>
                                <asp:TextBox ID="txtFlightTime" runat="server" CssClass="form-control" />
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <label><strong>Return Flight Details</strong></label>
                        </div>
                        <div class="col-md-4 form-group">
                            <label>Flight Date:</label>
                            <asp:TextBox ID="txtReturnFlightDate" runat="server" CssClass="form-control" />
                            <cc1:CalendarExtender ID="CalendarExtender5" runat="server" TargetControlID="txtReturnFlightDate" />
                        </div>
                        <div class="col-md-4 form-group">
                            <label>From (Place):</label>
                            <asp:TextBox ID="txtReturnFrom" runat="server" CssClass="form-control" />
                        </div>
                    
                        <div class="col-md-4 form-group">
                            <label>To (Place):</label>
                            <asp:TextBox ID="txtReturnTo" runat="server" CssClass="form-control" />
                        </div>
                        <div class="col-md-4 form-group">
                            <label>Flight Time/Schedule:</label>
                            <asp:TextBox ID="txtReturnFlightTime" runat="server" CssClass="form-control" />
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-4 form-group">
                            <label>Accomodation :<span class="required">*</span></label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server"
                                ControlToValidate="DdlAccomodation" ErrorMessage="Required!" ValidationGroup="tada"
                                SetFocusOnError="True" />
                            <asp:DropDownList ID="DdlAccomodation" runat="server" CssClass="form-control" />
                        </div>
                        <div class="col-md-4 form-group">
                            <label>Fooding:<span class="required">*</span></label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server"
                                ControlToValidate="DdlFooding" ErrorMessage="Required!" ValidationGroup="tada"
                                SetFocusOnError="True" />
                            <asp:DropDownList ID="DdlFooding" runat="server" CssClass="form-control" />
                        </div>
                    
                        <div class="col-md-4 form-group">
                            <label>Cash Advance Against TADA:<span class="required">*</span></label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server"
                                ControlToValidate="DdlCashAdvance" ErrorMessage="Required!" ValidationGroup="tada"
                                SetFocusOnError="True" />
                            <asp:DropDownList ID="DdlCashAdvance" runat="server" CssClass="form-control"
                                AutoPostBack="true" OnSelectedIndexChanged="DdlCashAdvance_SelectedIndexChanged">
                                <asp:ListItem Value="">Select</asp:ListItem>
                                <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                <asp:ListItem Value="No">No</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div id="divIsAdvance" class="row" runat="server" visible="false">
                        <div class="col-md-4">
                            <label>Currency:</label>
                            <asp:DropDownList ID="Ddlcurrency" runat="server" CssClass="form-control" />
                        </div>
                        <div class="col-md-4">
                            <label>Amount:</label>
                            <asp:TextBox ID="txtamount" runat="server" CssClass="form-control" />
                            <asp:HiddenField ID="hdnCurrency" runat="server" />
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <asp:Button ID="btnAddCurrency" runat="server" Width="50" CssClass="btn btn-primary" Text="Add"
                                    OnClick="btnAddCurrency_Click" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <div id="rpt2" runat="server"></div>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-4 form-group autocomplete-form">
                            <label>Authorized By:<span class="required">*</span></label>
                            <asp:Label ID="lblAuthorisedBy" runat="server" Font-Bold="true" /><br />

                            <asp:TextBox ID="txtAuthorisedBy" runat="server" CssClass="form-control"
                                AutoPostBack="true" />
                            <cc1:AutoCompleteExtender ID="aceAuthorisedBy" runat="server"
                                CompletionInterval="10" CompletionListCssClass="autocompleteTextBoxLP"
                                DelimiterCharacters="" EnableCaching="true" Enabled="true"
                                MinimumPrefixLength="1" ServiceMethod="GetEmployeeListByNameORId"
                                ServicePath="~/Autocomplete.asmx" TargetControlID="txtAuthorisedBy" />
                            <cc1:TextBoxWatermarkExtender ID="wmeEmpName"
                                runat="server" Enabled="True" TargetControlID="txtAuthorisedBy"
                                WatermarkCssClass="form-control" WatermarkText="Auto Complete" />
                            <asp:HiddenField ID="hdnAuthorisedBy" runat="server" />
                        </div>
                        <div class="col-md-4">
                            <label>&nbsp;</label><br />
                            <asp:Button ID="btnAdd" runat="server" CssClass="btn btn-primary" Text="Add"
                                ValidationGroup="tada" OnClick="btnAdd_Click" />
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <div id="rpt" runat="server">
                                </div>
                            </div>
                        </div>
                    </div>


                    <asp:Button ID="BtnSave" runat="server" CssClass="btn btn-primary"
                        OnClick="BtnSave_Click" Visible="false" Text="Save" />
                    <cc1:ConfirmButtonExtender ID="BtnSave_ConfirmButtonExtender" runat="server"
                        ConfirmText="Confirm To Save?" Enabled="True" TargetControlID="BtnSave" />
                    <asp:Button ID="BtnDelete" runat="server" CssClass="btn btn-primary"
                        OnClick="BtnDelete_Click" Text="Delete" />
                    <cc1:ConfirmButtonExtender ID="BtnDelete_ConfirmButtonExtender" runat="server"
                        ConfirmText="Confirm To Delete?" Enabled="True" TargetControlID="BtnDelete" />
                    <asp:Button ID="BtnBack" runat="server" CssClass="btn btn-primary"
                        OnClick="BtnBack_Click1" Text="Back" />
                    <asp:Button ID="btnDeleteAuthorisation" runat="server" CssClass="btn btn-primary"
                        Text="" OnClick="btnDeleteAuthorisation_Click" Style="display: none;" />
                    <asp:Button ID="btnDeleteCurrency" runat="server" CssClass="btn btn-primary"
                        Text="" OnClick="btnDeleteCurrency_Click" Style="display: none;" />

                </div>
            </div>
                    </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
