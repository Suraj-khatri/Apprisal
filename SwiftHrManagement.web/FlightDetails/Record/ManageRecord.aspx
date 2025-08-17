<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="ManageRecord.aspx.cs" Inherits="SwiftHrManagement.web.FlightDetails.Record.ManageRecord" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
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
        function OnDelete(ID) {
            if (confirm("Are you sure to Delete this?")) {
                document.getElementById("<% =hdnAuthorisedBy.ClientID %>").value = ID;
                document.getElementById("<%=btnDeleteAuthorisation.ClientID %>").click();
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
 <asp:UpdatePanel runat="server" ID="pnl1">
    <ContentTemplate>
        <div class="row">
            <div class="col-md-8 col-md-offset-2">
                <section class="panel">
                    <header class="panel-heading">
                        <i class="fa fa-caret-right" aria-hidden="true"></i>  
                            Flight Details Request
                    </header>
                    <div class="panel-body">

                        <div class="form-group">
                            <span class="txtlbl">Please enter valid data!</span><span class="required"> (* Required fields!) </span><br />   
                            <asp:Label ID="LblMsg" runat="server"></asp:Label>
                        </div>
                        
                        <div class="row">
                            <div class="col-md-12">
                                <fieldset>
                                <legend>Employee Information</legend>
                                <div class="form-group autocomplete-form">
                                    <label>Employee Name:<span class="errormsg">*</span></label>
                                    <asp:Label ID="LblEmpName" runat="server"/>                  
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
                                <div class="row">
                                    <div class="col-md-4">
                                        Branch: <asp:Label ID="lblBranch" runat="server" ReadOnly="true"/>
                                    </div>
                                    <div class="col-md-4">
                                        Department: <asp:Label ID="lblDepartment" runat="server" ReadOnly="true"/>
                                    </div>
                                    <div class="col-md-4">
                                         Position: <asp:Label ID="lblPosition" runat="server" ReadOnly="true"/>
                                    </div>
                                </div>
                            </fieldset>
                            </div> 
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <fieldset>
                                    <legend>Flight Details</legend>
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label>Flight Date:<span class="errormsg">*</span></label>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                                    ErrorMessage="Required!" ControlToValidate="txtFlightDate" AutoComplete="Off"
                                                    Display="Dynamic" ValidationGroup="flight" BorderColor="#FFFF66"
                                                    SetFocusOnError="True">
                                                </asp:RequiredFieldValidator>
                                                <asp:TextBox ID="txtFlightDate" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                                                <cc1:CalendarExtender ID="ceFlightDate" runat="server" TargetControlID="txtFlightDate" />
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label>From (Place):<span class="errormsg">*</span></label>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                                    ErrorMessage="Required!" ControlToValidate="txtFrom" AutoComplete="Off"
                                                    Display="Dynamic" ValidationGroup="flight" BorderColor="#FFFF66"
                                                    SetFocusOnError="True">
                                                </asp:RequiredFieldValidator>
                                                <asp:TextBox ID="txtFrom" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label>To (Place):<span class="errormsg">*</span></label>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                                    ErrorMessage="Required!" ControlToValidate="txtTo" AutoComplete="Off"
                                                    Display="Dynamic" ValidationGroup="flight" BorderColor="#FFFF66"
                                                    SetFocusOnError="True">
                                                </asp:RequiredFieldValidator>
                                                <asp:TextBox ID="txtTo" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label>Flight Time/Schedule:<span class="errormsg">*</span></label>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                                                    ErrorMessage="Required!" ControlToValidate="txtFlightTime" AutoComplete="Off"
                                                    Display="Dynamic" ValidationGroup="flight" BorderColor="#FFFF66"
                                                    SetFocusOnError="True">
                                                </asp:RequiredFieldValidator>
                                                <asp:TextBox ID="txtFlightTime" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </fieldset>
                            </div>
                        </div>
                        
                        <div class="row">
                            <div class="col-md-12">
                                <fieldset>
                                    <legend>Return Flight Details</legend>
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label>Flight Date:</label>
                                                <asp:TextBox ID="txtReturnFlightDate" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtReturnFlightDate" />
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label>From (Place):</label>
                                                <asp:TextBox ID="txtReturnFrom" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label>To (Place):</label>
                                                <asp:TextBox ID="txtReturnTo" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label>Flight Time/Schedule:</label>
                                                <asp:TextBox ID="txtReturnFlightTime" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </fieldset>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <fieldset>
                                <legend>Purpose</legend>
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <asp:TextBox runat="server" ID="txtPurpose" CssClass="form-control" TextMode="MultiLine" />
                                        </div>
                                    </div>
                                </div>
                            </fieldset>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <fieldset>
                                    <legend>Approval Details</legend>
                                    <div class="row">
                                        <div class="col-md-10">
                                            <div class="form-group autocomplete-form">
                                                <label>Authorized By:<span class="errormsg">*</span></label>
                                                <asp:Label ID="lblAuthorisedBy" runat="server" Font-Bold="true" Font-Size="13px" /><br />
                                                <asp:TextBox ID="txtAuthorisedBy" runat="server" CssClass="form-control" AutoPostBack="true" />
                                                <cc1:AutoCompleteExtender ID="aceAuthorisedBy" runat="server" 
                                                    CompletionInterval="10" CompletionListCssClass="autocompleteTextBoxLP" 
                                                    DelimiterCharacters="" EnableCaching="true" Enabled="true" 
                                                    MinimumPrefixLength="1" ServiceMethod="GetEmployeeListByNameORId" 
                                                    ServicePath="~/Autocomplete.asmx" TargetControlID="txtAuthorisedBy" />
                                                <cc1:TextBoxWatermarkExtender ID="wmeEmpName" 
                                                    runat="server" Enabled="True" TargetControlID="txtAuthorisedBy" 
                                                    WatermarkCssClass="watermark" WatermarkText="Auto Complete" />
                                                <asp:HiddenField ID="hdnAuthorisedBy" runat="server" />
                                            </div>
                                        </div>
                                        <div class="col-md-2">
                                            <div class="form-group">
                                                <br/>
                                                 <asp:Button ID="btnAdd" runat="server" CssClass="btn btn-primary" Text="Add" ValidationGroup="tada" onclick="btnAdd_Click" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-12">
                                             <div id="rpt" runat="server"> </div>
                                        </div>
                                    </div>
                                </fieldset>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Button ID="BtnSave" runat="server" CssClass="btn btn-primary" Text="Save"
                                OnClick="BtnSave_Click" Font-Strikeout="False" ValidationGroup="flight"
                               OnClientClick="validation();"/>
                            <asp:Button ID="BtnDelete" runat="server" CssClass="btn btn-primary" Text="Delete"
                                OnClick="BtnDelete_Click" />
                            <cc1:ConfirmButtonExtender ID="BtnDelete_ConfirmButtonExtender" runat="server"
                                ConfirmText="Confirm To Delete ?" Enabled="True"
                                TargetControlID="BtnDelete">
                            </cc1:ConfirmButtonExtender>
                            <asp:Button ID="BtnBack" runat="server" CssClass="btn btn-primary"
                                OnClick="BtnBack_Click1" Text=" Back" />
                            <cc1:ConfirmButtonExtender ID="BtnSave_ConfirmButtonExtender" runat="server"
                                ConfirmText="Confirm To Save ?" Enabled="True" TargetControlID="BtnSave">
                            </cc1:ConfirmButtonExtender>
                             <asp:Button ID="btnDeleteAuthorisation" runat="server" Text="" OnClick="btnDeleteAuthorisation_Click" style="display:none;" />
                        </div>
                    </div>
                </section>
            </div>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>

                                                  
</asp:Content>
