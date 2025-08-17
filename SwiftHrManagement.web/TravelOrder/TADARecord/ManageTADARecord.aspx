<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true"
    CodeBehind="ManageTADARecord.aspx.cs" Inherits="SwiftHrManagement.web.TravelOrder.TADARecord.ManageTADARecord" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var GB_ROOT_DIR = "/greybox/";
    </script>
    <script type="text/javascript" src="../../Jsfunc.js"></script>
    <script type="text/javascript" src="/greybox/AJS.js"></script>
    <script type="text/javascript" src="/greybox/gb_scripts.js"></script>
    <link href="/greybox/gb_styles.css" rel="stylesheet" type="text/css" media="all" />
    <script type="text/javascript" language="javascript">

        function validation() {
            if (!window.Page_ClientValidate('tada'))
                return false;
        }
   
        function LeaveExtendPopup() {

            var empIdres = document.getElementById("<%=txtEmpName.ClientID %>").value.split('|');
            var empId = empIdres[1];
            var fromdate = document.getElementById("<%=txtdurex_from.ClientID%>").value;
            var todate = document.getElementById("<%=txtdurexto.ClientID%>").value;

            GB_showCenter("Leave Management module", "/LeaveManagementModule/LeaveRecord/Manage.aspx?isMasterPageLess=Y&emp_id=" + empId + "&from=" + fromdate + "&to=" + todate, 520, 645, "");

        }
        function IsDelete(id) {
            if (confirm("Confirm Delete?")) {
                document.getElementById("<% =hdnId.ClientID %>").value = id;
                document.getElementById("<% =btnDeleteRecord.ClientID %>").click();
            }
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
    <asp:HiddenField ID="hdnId" runat="server" />
    <asp:Button ID="btnDeleteRecord" runat="server" Text="Delete" OnClick="btnDeleteRecord_Click"
        Style="display: none;" />
    <asp:UpdatePanel ID="ccList" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-md-10 col-md-offset-1">
                    <section class="panel">
                        <header class="panel-heading">
                            <i class="fa fa-caret-right" aria-hidden="true"></i>  
                                Travel Authorization Form All
                        </header>
                        <div class="panel-body">
                            <div class="form-group">
                                <asp:Label ID="printMsg" runat="server" Text="Messag:" Visible="false"></asp:Label>
                            </div>
                            <div class="form-group">  
                                <span class="txtlbl">Please enter valid data!</span><span class="required"> (* Required fields!) </span><br/>
                                <asp:Label ID="LblMsg" runat="server"></asp:Label>
                                <asp:HiddenField ID="HiddenFieldEmpEmail" runat="server" />
                            </div>
                    
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group autocomplete-form">
                                        <label>Employee Name:<span class="errormsg">*</span></label>
                                        <asp:Label ID="LblEmpName" runat="server"/> <br/>                 
                                        <asp:TextBox ID="txtEmpName" runat="server"
                                            AutoPostBack="true"  CssClass="form-control" 
                                            ontextchanged="txtEmpName_TextChanged" />
                                        <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" 
                                            CompletionInterval="10" CompletionListCssClass="autocompleteTextBoxLP" 
                                            DelimiterCharacters="" EnableCaching="true" Enabled="true" 
                                            MinimumPrefixLength="1" ServiceMethod="GetEmployeeListByNameORId" 
                                            ServicePath="~/Autocomplete.asmx" TargetControlID="txtEmpName" />
                                        <cc1:TextBoxWatermarkExtender ID="vendor_TextBoxWatermarkExtender" 
                                            runat="server" Enabled="True" TargetControlID="txtEmpName" 
                                            WatermarkCssClass="watermark" WatermarkText="All Employee" />
                                    </div>
                                    <br/>
                                    <div class="row">
                                        <div class="col-md-6">
                                            Branch: <asp:Label ID="txtbranch" runat="server" ReadOnly="true"  />
                                        </div>
                                        <div class="col-md-6">
                                            Department: <asp:Label ID="txtdepartment" runat="server" ReadOnly="true" />
                                        </div>
                                    </div>
                                    <br/>
                                    <div class="row">
                                        <div class="col-md-6">
                                            Position: <asp:Label ID="txtposition" runat="server" ReadOnly="true" />
                                        </div>
                                    </div>
                                    <br/>

                                    <div class="row">
                                        <div class="col-md-6">
                                            Country: <span class="errormsg">*</span>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="DdlCountry"
                                                    ErrorMessage="Required!" SetFocusOnError="True" ValidationGroup="tada" />
                                            <asp:DropDownList ID="DdlCountry" runat="server" CssClass="form-control"  />
                                        </div>
                                        <div class="col-md-6">
                                            City: <span class="errormsg">*</span>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtdestinationcity"
                                                     ErrorMessage="Required!" SetFocusOnError="True" ValidationGroup="tada" />
                                            <asp:TextBox ID="txtdestinationcity" runat="server" CssClass="form-control" />
                                        </div>
                                    </div>
                                    <br/>

                                    <div class="row">
                                        <div class="col-md-6">
                                            Reason for Travel: <span class="errormsg">*</span>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="DdlTravelReason"
                                                    ErrorMessage="Required!" SetFocusOnError="True" ValidationGroup="tada" />
                                            <asp:DropDownList ID="DdlTravelReason" runat="server" CssClass="form-control" OnSelectedIndexChanged="DdlTravelReason_SelectedIndexChanged"  />
                                        </div>
                                        <div class="col-md-6">
                                            Travel Description: 
                                            <asp:TextBox ID="txtTravelDescription" runat="server" CssClass="form-control" TextMode="MultiLine" />
                                        </div>
                                    </div>
                                    <br/>

                                    <div class="row" id="divtraveldate" runat="server" visible="true">
                                        <div class="col-md-6">
                                            From Date: <span class="errormsg">*</span>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtdurationto"
                                                ErrorMessage="Required!" SetFocusOnError="True" ValidationGroup="tada" />
                                            <asp:TextBox ID="txtdurationfrom" runat="server" CssClass="form-control" />
                                            <cc1:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtdurationfrom" />
                                        </div>
                                        <div class="col-md-6">
                                            To Date:<span class="errormsg">*</span>
                                     
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtdurationto"
                                                ErrorMessage="Required!" SetFocusOnError="True" ValidationGroup="tada" />
                                            <asp:Label ID="lbldate" runat="server" ForeColor="#CC0000" />                                           
                                            <asp:TextBox ID="txtdurationto" runat="server" AutoPostBack="true" CssClass="form-control" />
                                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtdurationto" />
                                        </div>
                                    </div>
                                    <br/>

                                    <div class="row">
                                        <div class="col-md-6">
                                            Extension of Visit: <span class="errormsg">*</span>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="Ddlex"
                                                    ErrorMessage="Required!" SetFocusOnError="True" ValidationGroup="tada" />
                                             <asp:Label ID="lblexterror" runat="server" ForeColor="#CC0000" />
                                            <asp:DropDownList ID="Ddlex" runat="server" CssClass="form-control" OnSelectedIndexChanged="Ddlex_SelectedIndexChanged" AutoPostBack="True">
                                                <asp:ListItem Value="">Select</asp:ListItem>
                                                <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                                <asp:ListItem Value="No">No</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <br/>

                                    <div class="row" id="divIsExtVisit" runat="server" visible="false">
                                        <div class="col-md-6 form-group">
                                            From: <span class="errormsg">*</span>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtdurex_from"
                                                ErrorMessage="Required!" SetFocusOnError="True" ValidationGroup="tada" />
                                            <asp:TextBox ID="txtdurex_from" runat="server" AutoPostBack="True" CssClass="form-control"/>
                                            <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtdurex_from" />
                                        </div>
                                        <div class="col-md-6 form-group">
                                            To:<span class="errormsg">*</span>
                                     
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtdurexto"
                                                ErrorMessage="Required!" SetFocusOnError="True" ValidationGroup="tada" />
                                            <asp:Label ID="lblerrordate" runat="server" ForeColor="#CC0000" />                                           
                                            <asp:TextBox ID="txtdurexto" runat="server" AutoPostBack="true" CssClass="form-control" OnTextChanged="txtdurexto_TextChanged" />
                                            <cc1:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtdurexto" />
                                        </div>
                                        <div class="clearfix">&nbsp;</div>
                                            <div class="col-md-6 form-group">
                                                City: <span class="errormsg">*</span>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtdurexcity"
                                                        ErrorMessage="Required!" SetFocusOnError="True" ValidationGroup="tada" />
                                                <asp:TextBox ID="txtdurexcity" runat="server"  CssClass="form-control" />

                                            </div>
                                            <div class="col-md-6 form-group">
                                                Country: <span class="errormsg">*</span>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="DdlCountry2"
                                                    ErrorMessage="Required!" SetFocusOnError="True" ValidationGroup="tada" />
                                                <asp:DropDownList ID="DdlCountry2" runat="server" CssClass="form-control" />
                                            </div>
                                       
                                       <div class="clearfix">&nbsp;</div>
                                            <div class="col-md-6 form-group">
                                               No Of. Days:  <asp:Label ID="lblnoofdays" runat="server"/>
                                            </div>
                                        <div class="clearfix">&nbsp;</div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-6">
                                           Mode of Travel:<span class="errormsg">*</span>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="Ddlmode"
                                                ErrorMessage="Required!" SetFocusOnError="True" ValidationGroup="tada" />
                                            <asp:DropDownList ID="Ddlmode" runat="server" AutoPostBack="true" CssClass="form-control"
                                                OnSelectedIndexChanged="Ddlmode_SelectedIndexChanged1"  />
                                        </div>
                                    </div>
                                    <br/>

                                    <div class="row">
                                        <div class="col-md-6">
                                           Transportation Arrangement:<span class="errormsg">*</span>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="Ddltransportation"
                                                ErrorMessage="Required!" SetFocusOnError="True" ValidationGroup="tada" />
                                            <asp:DropDownList ID="Ddltransportation" runat="server" AutoPostBack="true" CssClass="form-control"
                                                OnSelectedIndexChanged="Ddltransportation_SelectedIndexChanged"  />
                                        </div>
                                    </div>
                                    <br/>

                                    <div class="row"  id="divFlightDetails" runat="server" visible="false">
                                        <div class="col-md-12">
                                            <fieldset>
                                                <legend>Flight Details</legend>
                                                <div class="row">
                                                    <div class="col-md-6">
                                                        Flight Date:
                                                        <asp:TextBox ID="txtFlightDate" runat="server" CssClass="form-control"  />
                                                        <cc1:CalendarExtender ID="ceFlightDate" runat="server" TargetControlID="txtFlightDate" /> 
                                                    </div>
                                                     <div class="col-md-6">
                                                        From (Place):
                                                        <asp:TextBox ID="txtFromPlace" runat="server" CssClass="form-control"  />
                                                    </div>
                                           
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-6">
                                                        To (Place):
                                                        <asp:TextBox ID="txtToPlace" runat="server" CssClass="form-control"  />
                                                    </div>
                                                     <div class="col-md-6">
                                                        Flight Time/Schedule:
                                                        <asp:TextBox ID="txtFlightTime" runat="server" CssClass="form-control"  />
                                                    </div>
                                           
                                                </div>
                                            </fieldset>
                                        </div>
                                        <br/>

                                        <div class="col-md-12">
                                            <fieldset>
                                                <legend>Return Flight Details</legend>
                                                <div class="row">
                                                    <div class="col-md-6">
                                                        Flight Date:
                                                        <asp:TextBox ID="txtReturnFlightDate" runat="server" CssClass="form-control"  />
                                                        <cc1:CalendarExtender ID="CalendarExtender5" runat="server" TargetControlID="txtReturnFlightDate" /> 
                                                    </div>
                                                     <div class="col-md-6">
                                                        From (Place):
                                                        <asp:TextBox ID="txtReturnFrom" runat="server" CssClass="form-control"  />
                                                    </div>
                                           
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-6">
                                                        To (Place):
                                                        <asp:TextBox ID="txtReturnTo" runat="server" CssClass="form-control"  />
                                                    </div>
                                                     <div class="col-md-6">
                                                        Flight Time/Schedule:
                                                        <asp:TextBox ID="txtReturnFlightTime" runat="server" CssClass="form-control"  />
                                                    </div>
                                           
                                                </div>
                                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                    <ContentTemplate>
                                                        <div class="row" id="showcc" runat="server">
                                                            <fieldset class="text-center" style="list-style-type: circle; height: 130px; margin-bottom: 0px;">
                                                                <legend>Email Recipient:</legend>
                                                                <table class="table borderless" style="height: 125px">
                                                                    <tr>
                                                                        <td class="style12" valign="top">
                                                                            <iframe id="notificationList" frameborder="0" scrolling="auto" src="../../cc/cc.aspx"
                                                                                width="400"></iframe>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </fieldset>
                                                        </div>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </fieldset>
                                        </div>
                                    </div>
                                    
                                    <div class="row">
                                        <div class="col-md-6">
                                           Accomodation:<span class="errormsg">*</span>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="DdlAccomodation"
                                                ErrorMessage="Required!" SetFocusOnError="True" ValidationGroup="tada" />
                                            <asp:DropDownList ID="DdlAccomodation" runat="server" AutoPostBack="true" CssClass="form-control"/>
                                        </div>
                                    </div>
                                    <br/>

                                    <div class="row">
                                        <div class="col-md-6">
                                           Fooding:<span class="errormsg">*</span>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="DdlFooding"
                                                ErrorMessage="Required!" SetFocusOnError="True" ValidationGroup="tada" />
                                            <asp:DropDownList ID="DdlFooding" runat="server" AutoPostBack="true" CssClass="form-control"/>
                                        </div>
                                    </div>
                                    <br/>
                                    
                                    <div class="row">
                                        <div class="col-md-6">
                                           Cash Advance Against TADA:<span class="errormsg">*</span>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="DdlCashAdvance"
                                                ErrorMessage="Required!" SetFocusOnError="True" ValidationGroup="tada" />
                                            <br />
                                            <asp:DropDownList ID="DdlCashAdvance" runat="server" AutoPostBack="true" CssClass="form-control"
                                                OnSelectedIndexChanged="DdlCashAdvance_SelectedIndexChanged">
                                                <asp:ListItem Value="">Select</asp:ListItem>
                                                <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                                <asp:ListItem Value="No">No</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <br/>
                                    
                                    <div class="row" id="divIsAdvance" runat="server" visible="false">
                                        <div class="col-md-6">
                                            Currency:
                                            <asp:DropDownList ID="Ddlcurrency" runat="server" CssClass="form-control"  />
                                        </div>
                                        <div class="col-md-4">
                                            Amount:
                                            <asp:TextBox ID="txtamount" runat="server" CssClass="form-control"  />
                                            
                                            <asp:HiddenField ID="hdnCurrency" runat="server" />
                                        </div>
                                        <div class="col-md-1">
                                            <br/>
                                            <asp:Button ID="btnAddCurrency" runat="server" CssClass="btn btn-primary" OnClick="btnAddCurrency_Click" Text="Add"/>  
                                        </div>
                                        
                                        <div class="col-md-12">
                                            <div id="rpt2" runat="server" class="form-group"></div>
                                        </div>
                                    </div>

                                    <div class="row" >
                                        <div class="col-md-10 autocomplete-form">
                                            Authorized By:
                                            <asp:Label ID="lblAuthorisedBy" runat="server" Font-Bold="true" Font-Size="13px" />
                                            <asp:TextBox ID="txtAuthorisedBy" runat="server" AutoPostBack="true" CssClass="form-control" ValidationGroup="tada" />
                                            
                                            <cc1:AutoCompleteExtender ID="aceAuthorisedBy" runat="server" CompletionInterval="10"
                                                CompletionListCssClass="autocompleteTextBoxLP" DelimiterCharacters="" EnableCaching="true"
                                                Enabled="true" MinimumPrefixLength="1" ServiceMethod="GetEmployeeListByNameORId"
                                                ServicePath="~/Autocomplete.asmx" TargetControlID="txtAuthorisedBy" />
                                            <cc1:TextBoxWatermarkExtender ID="wmeEmpName" runat="server" Enabled="True" TargetControlID="txtAuthorisedBy"
                                                WatermarkCssClass="watermark" WatermarkText="Auto Complete" />
                                            <asp:HiddenField ID="hdnAuthorisedBy" runat="server" />
                                        </div>
                                        <div class="col-md-1">
                                            <br/>
                                            <asp:Button ID="btnAdd" runat="server" CssClass="btn btn-primary" OnClick="btnAdd_Click" Text="Add" />
                                        </div>
                                        <div class="clearfix"></div>
                                        <div class="col-md-12">
                                            <div id="rpt" runat="server" class="form-group"></div>
                                        </div>
                                    </div>
                                    <br/>
                                    
                                    <div class="row" >
                                        <div class="col-md-6 ">
                                            Reimbursement Expenses:
                                            <asp:DropDownList ID="DdlReimbursement" runat="server" CssClass="form-control" OnSelectedIndexChanged="DdlReimbursement_SelectedIndexChanged" AutoPostBack="true">
                                                <asp:ListItem Value="N">No</asp:ListItem>
                                                <asp:ListItem Value="Y">Yes</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        
                                    </div>
                                    <br/>
                                    
                                    <div class="row"  id="reimburse" runat="server" visible="false">
                                        <div class="col-md-12">
                                            <fieldset>
                                                <legend>Reimbursement</legend>
                                                <div class="row">
                                                    <div class="col-md-6">
                                                        From Date:<span class="errormsg">*</span>
                                                        <asp:RequiredFieldValidator ID="rfvfromdate" runat="server" ControlToValidate="txtFromDate"
                                                            ErrorMessage="Required!" ValidationGroup="Reimbursement" SetFocusOnError="True" />
                                                        <asp:TextBox ID="txtFromDate" runat="server" AutoPostBack="true" CssClass="form-control"/>
                                                        <cc1:CalendarExtender ID="ceFromDate" runat="server" Enabled="True" TargetControlID="txtFromDate">
                                                        </cc1:CalendarExtender>
                                                    </div>
                                                     <div class="col-md-6">
                                                        To Date:<span class="errormsg">*</span>
                                                        <asp:RequiredFieldValidator ID="rfvtodate" runat="server" ControlToValidate="txtToDate"
                                                            ErrorMessage="Required!" ValidationGroup="Reimbursement" SetFocusOnError="True" />
                                                        <asp:TextBox ID="txtToDate" runat="server" AutoPostBack="true" CssClass="form-control"/>
                                                        <cc1:CalendarExtender ID="CalendarExtender6" runat="server" Enabled="True" TargetControlID="txtToDate">
                                                        </cc1:CalendarExtender>
                                                    </div>
                                           
                                                </div>
                                                <br/>

                                                <div class="row">
                                                    <div class="col-md-6">
                                                        Currency:<span class="errormsg">*</span>
                                                        <asp:RequiredFieldValidator ID="rfvcurrency" runat="server" ControlToValidate="ddlHeadCurrency"
                                                            ErrorMessage="Required!" ValidationGroup="Reimbursement" SetFocusOnError="True" />
                                                        <asp:DropDownList ID="ddlHeadCurrency" runat="server" CssClass="form-control"  />
                                                    </div>
                                                     <div class="col-md-6">
                                                        Expense Head:<span class="errormsg">*</span>
                                                        <asp:RequiredFieldValidator ID="rfvexpe" runat="server" ControlToValidate="ddlHead"
                                                            ErrorMessage="Required!" ValidationGroup="Reimbursement" SetFocusOnError="True" />
                                                        <asp:DropDownList ID="ddlHead" runat="server" AutoPostBack="True"
                                                            CssClass="form-control" OnSelectedIndexChanged="ddlHead_SelectedIndexChanged" />
                                                    </div>
                                           
                                                </div>
                                                <br/>
                                                <div class="row">
                                                    <div class="col-md-6">
                                                        Per Day Entitlement:
                                                        <asp:TextBox ID="txtPerDayEntitlement" runat="server" CssClass="form-control"  />

                                                    </div>
                                                     <div class="col-md-6">
                                                        Total Entitlement:
                                                        <asp:TextBox ID="txtTotalEntitlement" runat="server" CssClass="form-control"  />
                                                    </div>
                                                </div>
                                                <br/>
                                                
                                                <div class="row">
                                                    <div class="col-md-6">
                                                        Bills to be enclosed:<span class="errormsg">*</span>
                                                        <asp:RequiredFieldValidator ID="rfvbill" runat="server" ControlToValidate="ddlBillEnclosed"
                                                            ErrorMessage="Required!" ValidationGroup="Reimbursement" SetFocusOnError="True" />
                                                        <asp:DropDownList ID="ddlBillEnclosed" runat="server" AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="ddlBillEnclosed_SelectedIndexChanged">                                                 
                                                            <asp:ListItem Value="">Select</asp:ListItem>
                                                            <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                                            <asp:ListItem Value="No">No</asp:ListItem>
                                                        </asp:DropDownList>

                                                    </div>
                                                </div>
                                                <br/>
                                                <div id="divclaimamount"  class="row" runat="server" visible="False">
                                                    <div class="col-md-6">
                                                        Claim amount:
                                                        <asp:RequiredFieldValidator ID="rfvclaim" runat="server" ControlToValidate="txtClaimAmount"
                                                            ErrorMessage="Required!" ValidationGroup="Reimbursement" SetFocusOnError="True" />
                                                        <asp:TextBox ID="txtClaimAmount" runat="server" CssClass="form-control"  />
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-10">
                                                        Remarks:<span class="errormsg">*</span>
                                                        <asp:RequiredFieldValidator ID="rfvrema" runat="server" ControlToValidate="txtRemarks"
                                                            ErrorMessage="Required!" ValidationGroup="Reimbursement" SetFocusOnError="True" />
                                                        <asp:TextBox ID="txtRemarks" runat="server" CssClass="form-control" TextMode="MultiLine"/>
                                                        </div>
                                                    <div class="col-md-2">
                                                        <br/>
                                                        <asp:Button ID="btnAddNewClaim" runat="server" CssClass="btn btn-primary" Text="Add New" ValidationGroup="Reimbursement" OnClick="btnAddNewClaim_Click" />                                      
                                                        <asp:Label ID="msgLbl" runat="server" />
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-12 ">
                                                        <div id="disReimbersement" runat="server" class="form-group table table-responsive"></div>
                                                    </div>
                                                </div>
                                                <br/>
                                                <div class="row">
                                                    <div class="col-md-6">
                                                        Other Expenses:<span class="errormsg">*</span>
                                                        <asp:RequiredFieldValidator ID="rfvoe" runat="server" ControlToValidate="txtOtherExpenses"
                                                            ErrorMessage="Required!" ValidationGroup="Oe" SetFocusOnError="True" />
                                                        <asp:TextBox ID="txtOtherExpenses" runat="server" CssClass="form-control" />
                                                    </div>
                                                    <div class="col-md-6">
                                                        Claim Amount:<span class="errormsg">*</span>
                                                        <asp:RequiredFieldValidator ID="rfvco" runat="server" ControlToValidate="txtAmountClaimOther" ErrorMessage="Required!" ValidationGroup="Oe" SetFocusOnError="True" />
                                                        <asp:TextBox ID="txtAmountClaimOther" runat="server" CssClass="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <br/>
                                                <div class="row">
                                                    <div class="col-md-6">
                                                        Currency:<span class="errormsg">*</span>
                                                        <asp:RequiredFieldValidator ID="rfvoc" runat="server" ControlToValidate="ddlothercurrency"
                                                            ErrorMessage="Required!" ValidationGroup="Oe" SetFocusOnError="True" />
                                                        <asp:DropDownList ID="ddlothercurrency" runat="server" CssClass="form-control">
                                                        </asp:DropDownList><br/>
                                                        <asp:Button ID="btnAddNew" runat="server" CssClass="btn btn-primary" Text="Add Claim" OnClick="btnAddNew_Click" ValidationGroup="Oe" />
                                                                                                    
                                                        <asp:Label ID="lblMsgOther" runat="server" CssClass="txtlbl" />
                                                    </div>
                                                </div>
                                                <br/>
                                                <div class="clearfix"></div>
                                                <div class="row">
                                                    <div class="col-md-12 ">
                                                        <div id="disOtherExpenses" runat="server" class="form-group"></div>
                                                    </div>
                                                </div>
                                            </fieldset>
                                        </div>

                                </div> 
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Button ID="BtnSave" runat="server" CssClass="btn btn-primary" OnClick="BtnSave_Click"
                                Text="Save" ValidationGroup="tada" Onclientclick="validation();" />
                            <cc1:ConfirmButtonExtender ID="BtnSave_ConfirmButtonExtender" runat="server" ConfirmText="Confirm To Save?"
                                Enabled="True" TargetControlID="BtnSave" />
                            <asp:Button ID="BtnDelete" runat="server" CssClass="btn btn-primary" OnClick="BtnDelete_Click" Text="Delete" />
                            <cc1:ConfirmButtonExtender ID="BtnDelete_ConfirmButtonExtender" runat="server" ConfirmText="Confirm To Delete?"
                                Enabled="True" TargetControlID="BtnDelete" />
                            <asp:Button ID="BtnBack" runat="server" CssClass="btn btn-primary" OnClick="BtnBack_Click1" Text="Back"/>
                            <asp:Button ID="btnDeleteAuthorisation" runat="server" CssClass="btn-primary" OnClick="btnDeleteAuthorisation_Click"
                                Style="display: none;" Text="" />
                            <asp:Button ID="btnDeleteCurrency" runat="server" CssClass="btn-primary" OnClick="btnDeleteCurrency_Click"
                                Style="display: none;" Text="" />
                        </div>
                    </section>
        
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

   
</asp:Content>
