<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="SwiftHrManagement.web.TrainingModule.Record.Manage" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <script src="/js/Swift_grid.js" type="text/javascript"> </script>
    <script src="/js/functions.js" type="text/javascript"> </script>
    <script language="javascript">
        function AutocompleteOnSelected(sender, e) {
            var CustodianValueArray = (e._value).split("|");
            var HiddenFieldEmpID = document.getElementById("<%=hdnEmpId.ClientID %>");
            hdnEmpId.value = CustodianValueArray[1];
        }
        function GetForwardEmployee(sender, e) {
            var CustodianValueArray = (e._value).split("|");
            var HiddenFieldEmpID = document.getElementById("<%=hdnForwardEmp.ClientID %>");
            hdnForwardEmp.value = CustodianValueArray[1];
        }
        function OnDelete(id) {
            if (confirm("Confirm To Delete?")) {
                document.getElementById("<% =hdnId.ClientID %>").value = id;
                document.getElementById("<% =btnDeleteNominee.ClientID %>").click();
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">

    <asp:HiddenField ID="hdnEmpId" runat="server" />
    <asp:HiddenField ID="hdnId" runat="server" />    
    <asp:HiddenField ID="hdnForwardEmp" runat="server" />
    <asp:Button ID="btnDeleteNominee" runat="server" Text="Button" onclick="btnDeleteNominee_Click" style="display:none;"/>
    
    <div class="row">
            <div class="col-md-12">
                <section class="panel">
                    <header class="panel-heading">
                        <i class="fa fa-caret-right"></i>
                        Training Program Details <asp:Label ID="LblEmpName" runat="server" Text=""></asp:Label>
                    </header>
                    <div class="panel-body">
                        <div id="Div1" runat="server">
                            <div class="form-group">                            
                                <span class="txtlbl">Please Enter Valid Data!</span>
                                <span class="required" >(* Required fields)</span>
                                <asp:Label ID="LblMsg" runat="server"></asp:Label>
                                <asp:HiddenField ID="HiddenFieldEmpID" runat="server" />
                                <asp:HiddenField ID="HiddenFieldEmpEmail" runat="server" />
                            </div>
                            <div id="formArea" runat="server">
                                <div class="row">
                                    <div class="col-md-4 form-group form-inline">                            
                                        <label>Training Category:<span class="errormsg">*</span></label>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" 
                                                runat="server" ControlToValidate="ddlCategory" Display="dynamic" 
                                                ErrorMessage="Required" ValidationGroup="training" 
                                                SetFocusOnError="True"></asp:RequiredFieldValidator>
                                        <asp:DropDownList ID="ddlCategory" runat="server" CssClass="form-control">
                                            </asp:DropDownList>
                                    </div>
                                     <div class="col-md-4 form-group form-inline">                            
                                        <label>Program Type :<span class="errormsg">*</span></label>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" 
                                                runat="server" ControlToValidate="ddlProgramType" Display="dynamic" 
                                                ErrorMessage="Required" ValidationGroup="training" SetFocusOnError="True">
                                            </asp:RequiredFieldValidator>                
                                            <asp:DropDownList ID="ddlProgramType" runat="server" CssClass="form-control"></asp:DropDownList>
                                    </div>
                                     <div class="col-md-4 form-group form-inline">                            
                                        <label>Status:<span class="errormsg">*</span></label>
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator13" 
                                            runat="server" ControlToValidate="ddlStatus" Display="dynamic" 
                                            ErrorMessage="Required" ValidationGroup="training" 
                                            SetFocusOnError="True">
                                        </asp:RequiredFieldValidator>                
                                        <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control" 
                                            AutoPostBack="True">
                                        <asp:ListItem Value="Recorded">Recorded</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-4 form-group">                            
                                        <label>Conducted By:<span class="errormsg">*</span></label>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" 
                                            runat="server" ControlToValidate="txtConductedBy" Display="dynamic" 
                                            ErrorMessage="Required" ValidationGroup="training" 
                                            SetFocusOnError="True">
                                        </asp:RequiredFieldValidator>
                                        <asp:TextBox ID="txtConductedBy" runat="server" CssClass="form-control"></asp:TextBox> 
                                    </div>
                                     <div class="col-md-4 form-group">                            
                                        <label>Program Name:<span class="errormsg">*</span></label>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" 
                                            runat="server" ControlToValidate="TxtProgramName" Display="dynamic" 
                                            ErrorMessage="Required" ValidationGroup="training" 
                                            SetFocusOnError="True">
                                        </asp:RequiredFieldValidator>
                                        <asp:TextBox ID="TxtProgramName" runat="server" CssClass="form-control"></asp:TextBox>     
                                    </div>
                                     <div class="col-md-4 form-group">                            
                                        <label>Estimated Cost:</label>
                                        <asp:TextBox ID="TxtCostEstimate" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-4 form-group">                            
                                        <label>Planned Start Date:<span class="errormsg">*</span></label>
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator7" 
                                            runat="server" ControlToValidate="txtPlannedStartDate" Display="dynamic" 
                                            ErrorMessage="Required" ValidationGroup="training" 
                                            SetFocusOnError="True">
                                        </asp:RequiredFieldValidator>                
                                        <asp:TextBox ID="txtPlannedStartDate" runat="server" CssClass="form-control"></asp:TextBox>          
                                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" 
                                            TargetControlID="txtPlannedStartDate">
                                        </cc1:CalendarExtender>
                                    </div>
                                     <div class="col-md-4 form-group">                            
                                        <label>Planned End Date:<span class="errormsg">*</span></label>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" 
                                             runat="server" ControlToValidate="txtPlannedEndDate" Display="dynamic" 
                                             ErrorMessage="Required" ValidationGroup="training" 
                                             SetFocusOnError="True">
                                        </asp:RequiredFieldValidator>
                                        <asp:CompareValidator ID="CompareValidator3" ControlToValidate="txtPlannedEndDate" 
                                            ControlToCompare="txtPlannedStartDate" runat="server" 
                                            ErrorMessage="End Date Must be greater than start Date" Display="Dynamic" 
                                            Enabled="true" Operator="GreaterThanEqual" Type="Date" ValidationGroup="training">
                                        </asp:CompareValidator>
                                        <asp:TextBox ID="txtPlannedEndDate" runat="server" CssClass="form-control">
                                        </asp:TextBox>           
                                         <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True" 
                                             TargetControlID="txtPlannedEndDate">
                                         </cc1:CalendarExtender>           
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-4 form-group">                            
                                        <label>Start Date:<span class="errormsg">*</span></label>
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator5" 
                                            runat="server" ControlToValidate="txtStartDate" Display="dynamic" 
                                            ErrorMessage="Required" ValidationGroup="training" 
                                            SetFocusOnError="True">
                                        </asp:RequiredFieldValidator>                
                                        <asp:TextBox ID="txtStartDate" runat="server" CssClass="form-control"></asp:TextBox>            
                                       <cc1:CalendarExtender ID="StartDate_CalendarExtender" runat="server" Enabled="True" 
                                           TargetControlID="txtStartDate">
                                       </cc1:CalendarExtender>
                                    </div>
                                     <div class="col-md-4 form-group">                            
                                        <label>End Date:<span class="errormsg">*</span></label>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" 
                                                runat="server" ControlToValidate="txtEndDate" Display="dynamic" 
                                                ErrorMessage="Required" ValidationGroup="training" 
                                                SetFocusOnError="True">
                                        </asp:RequiredFieldValidator>
                                        <asp:CompareValidator ID="CompareValidator1" ControlToValidate="txtEndDate" 
                                            ControlToCompare="txtStartDate" runat="server" 
                                            ErrorMessage="End Date Must be greater than start Date" Display="Dynamic" 
                                            Enabled="true" Operator="GreaterThanEqual" Type="Date" ValidationGroup="training">
                                        </asp:CompareValidator>
                                        <asp:TextBox ID="txtEndDate" runat="server" CssClass="form-control" 
                                            ontextchanged="txtEndDate_TextChanged" AutoPostBack="true">
                                        </asp:TextBox>          
                                        <cc1:CalendarExtender ID="EndDate_CalendarExtender" runat="server" 
                                            Enabled="True" TargetControlID="txtEndDate">
                                        </cc1:CalendarExtender>
                                    </div>
                                    <div class="col-md-4 form-group">                            
                                        <label>Nominate Within:<span class="errormsg">*</span></label>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" 
                                             runat="server" ControlToValidate="txtNominateWithin" Display="dynamic" 
                                             ErrorMessage="Required" ValidationGroup="training" 
                                             SetFocusOnError="True">
                                        </asp:RequiredFieldValidator>                     
                                        <asp:CompareValidator ID="CompareValidator2" ControlToValidate="txtNominateWithin" 
                                            ControlToCompare="txtStartDate" runat="server" 
                                            ErrorMessage="Nominate Date Must be smaller than start Date" Display="Dynamic" Enabled="true" 
                                            Operator="LessThan" Type="Date" ValidationGroup="training"> 
                                        </asp:CompareValidator>  
                                        <asp:TextBox ID="txtNominateWithin" runat="server" CssClass="form-control"></asp:TextBox>   
                                        <cc1:CalendarExtender ID="txtNominateWithin_CalendarExtender" runat="server" Enabled="True" 
                                            TargetControlID="txtNominateWithin">
                                        </cc1:CalendarExtender>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-4 form-group">                            
                                        <label>No. Of Days:</label>
                                         <asp:TextBox ID="txtNoOfDays" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                     <div class="col-md-4 form-group">                            
                                        <label>No. of Hours/Day:</label>
                                          <asp:TextBox ID="txtNoOfHOurs" runat="server" CssClass="form-control"></asp:TextBox> 
                                    </div>
                                    <div class="col-md-4 form-group">                            
                                        <label>Total Capacity:</label>
                                         <asp:TextBox ID="txtTotalCapacity" runat="server" CssClass="form-control" AutoPostBack="True" 
                                             ontextchanged="txtTotalCapacity_TextChanged"></asp:TextBox>   
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-4 form-group">                            
                                        <label>Country:</label>
                                        <asp:TextBox ID="txtCountry" runat="server" CssClass="form-control"></asp:TextBox>    
                                    </div>
                                    <div class="col-md-4 form-group">                            
                                        <label>City:</label>
                                        <asp:TextBox ID="txtCity" runat="server" CssClass="form-control"></asp:TextBox>   
                                    </div>
                                    <div class="col-md-4 form-group">                            
                                        <label>Venue:<span class="errormsg">*</span></label>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtVenue" 
                                             Display="dynamic" ErrorMessage="Required" ValidationGroup="training" SetFocusOnError="True">
                                        </asp:RequiredFieldValidator> 
                                        <asp:TextBox ID="txtVenue" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12 form-group">                            
                                        <label>Program Description:<span class="errormsg">*</span></label>
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator9" 
                                            runat="server" ControlToValidate="txtProgramDesc" Display="dynamic" 
                                            ErrorMessage="Required" ValidationGroup="training" 
                                            SetFocusOnError="True">
                                        </asp:RequiredFieldValidator>   
                                        <asp:TextBox ID="txtProgramDesc" runat="server" TextMode="MultiLine" CssClass="form-control" EnableViewState="False">
                                        </asp:TextBox>    
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12 form-group">                            
                                        <strong>Actual Cost Of Training:</strong>  
                                    </div>  
                                    <div class="col-md-6 form-group">                       
                                        <label>Trainer Cost:</label>
                                        <asp:TextBox ID="txtTrainerCost" runat="server" CssClass="form-control" AutoPostBack="True" Text="0" 
                                             ontextchanged="txtTrainerCost_TextChanged"></asp:TextBox>
                                    </div>
                                    <div class="col-md-6 form-group">                            
                                        <label> Cost of Food/Venue :</label>
                                        <asp:TextBox ID="txtFoodCostVenue" runat="server" CssClass="form-control" AutoPostBack="True" Text="0" 
                                            ontextchanged="txtFoodCostVenue_TextChanged"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-6 form-group">                            
                                        <label> Other Cost:</label>
                                         <asp:TextBox ID="txtOtherCost" runat="server" CssClass="form-control" AutoPostBack="True"  Text="0" 
                                             ontextchanged="txtOtherCost_TextChanged"></asp:TextBox>
                                    </div>
                                    <div class="col-md-6 form-group">                            
                                        <label> Cost of Per Person</label>
                                          <asp:TextBox ID="txtCostPerPerson" Text="0" runat="server" CssClass="form-control" 
                                              ontextchanged="txtCostPerPerson_TextChanged"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12 form-group autocomplete-form">                            
                                        <label>Approved By:<span class="errormsg">*</span></label>
                                        <asp:TextBox ID="txtForwardWith" runat="server" CssClass="form-control" AutoComplete="Off"></asp:TextBox>                
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtForwardWith" Display="dynamic" 
                                            ErrorMessage="Required" ValidationGroup="training" SetFocusOnError="True">
                                        </asp:RequiredFieldValidator>                
                                        <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" 
                                            runat="server" Enabled="True" TargetControlID="txtForwardWith"
                                            WatermarkCssClass="form-control" WatermarkText="Auto Complete">
                                        </cc1:TextBoxWatermarkExtender>                  
                                        <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" 
                                            DelimiterCharacters="" Enabled="True" ServicePath="~/Autocomplete.asmx" 
                                            ServiceMethod="GetEmployeeList" TargetControlID="txtForwardWith"
                                            MinimumPrefixLength="1" CompletionInterval="10"
                                            EnableCaching="true" CompletionListCssClass="autocompleteTextBoxLP" 
                                            OnClientItemSelected="GetForwardEmployee">
                                        </cc1:AutoCompleteExtender>
                                    </div>
                                </div>
                            </div>
                            <div id="displayArea" runat="server">
                                <div class="row">
                                    <div class="col-md-12 form-group">
                                        <strong>Training Program Information:</strong>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12 form-group">
                                        <label>Training Category:</label>
                                        <asp:Label ID="lblCategory" runat="server"></asp:Label>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-2 form-group">                            
                                        <label>Program Type:</label>
                                    </div>
                                    <div class="col-md-4 form-group">
                                       <asp:Label ID="lblProgramType" runat="server"></asp:Label> 
                                    </div>
                                    <div class="col-md-2 form-group">                            
                                        <label>Conducted By:</label>
                                    </div>
                                    <div class="col-md-4 form-group">
                                       <asp:Label ID="lblConductedBy" runat="server"></asp:Label> 
                                    </div>
                                </div>
                                 <div class="row">
                                    <div class="col-md-2 form-group">                            
                                        <label>Program Name:</label>
                                    </div>
                                    <div class="col-md-4 form-group">
                                        <asp:Label ID="lblProgramName" runat="server"></asp:Label>
                                    </div>
                                    <div class="col-md-2 form-group">                            
                                        <label>Estimated Cost:</label>
                                    </div>
                                    <div class="col-md-4 form-group">
                                       <asp:Label ID="lblEstimatedCost" runat="server"></asp:Label>
                                    </div>
                                 </div>
                                 <div class="row">
                                    <div class="col-md-2 form-group">                            
                                        <label>Planned Start Date:</label>
                                    </div>
                                    <div class="col-md-4 form-group">
                                        <asp:Label ID="lblPlannedStartDate" runat="server"></asp:Label>
                                    </div>
                                    <div class="col-md-2 form-group">                            
                                        <label>Planned End Date:</label>
                                    </div>
                                    <div class="col-md-4 form-group">
                                       <asp:Label ID="lblPlannedEndDate" runat="server"></asp:Label>
                                    </div>
                                 </div>
                                 <div class="row">
                                    <div class="col-md-2 form-group">                            
                                        <label>Start Date:</label>
                                    </div>
                                    <div class="col-md-4 form-group">
                                        <asp:Label ID="lblStartDate" runat="server"></asp:Label>
                                    </div>
                                    <div class="col-md-2 form-group">                            
                                        <label>End Date:</label>
                                    </div>
                                    <div class="col-md-4 form-group">
                                        <asp:Label ID="lblEndDate" runat="server"></asp:Label>
                                    </div>
                                 </div>
                                <div class="row">
                                    <div class="col-md-2 form-group">                            
                                        <label>No Of Hours:</label>
                                    </div>
                                    <div class="col-md-4 form-group">
                                         <asp:Label ID="lblNoOfHours" runat="server"></asp:Label>
                                    </div>
                                    <div class="col-md-2 form-group">                            
                                        <label>No Of Days:</label>
                                    </div>
                                    <div class="col-md-4 form-group">
                                       <asp:Label ID="lblNoOfDays" runat="server"></asp:Label>
                                    </div>
                                 </div>
                                 <div class="row">
                                    <div class="col-md-2 form-group">                            
                                        <label>Nominee Within:</label>
                                    </div>
                                    <div class="col-md-4 form-group">
                                         <asp:Label ID="lblNomineeWithin" runat="server"></asp:Label>
                                    </div>
                                    <div class="col-md-2 form-group">                            
                                        <label>Total Capacity:</label>
                                    </div>
                                    <div class="col-md-4 form-group">
                                       <asp:Label ID="lblTotCapacity" runat="server"></asp:Label>
                                    </div>
                                 </div>
                                 <div class="row">
                                    <div class="col-md-2 form-group">                            
                                        <label>Country:</label>
                                    </div>
                                    <div class="col-md-4 form-group">
                                        <asp:Label ID="lblCountry" runat="server"></asp:Label>
                                    </div>
                                    <div class="col-md-2 form-group">                            
                                        <label>City:</label>
                                    </div>
                                    <div class="col-md-4 form-group">
                                        <asp:Label ID="lblCity" runat="server"></asp:Label>
                                    </div>
                                 </div>
                                 <div class="row">
                                    <div class="col-md-2 form-group">                            
                                        <label>Venue:</label>
                                    </div>
                                    <div class="col-md-4 form-group">
                                        <asp:Label ID="lblVenue" runat="server"></asp:Label>
                                    </div>
                                    <div class="col-md-2 form-group">                            
                                        <label>Created By:</label>
                                    </div>
                                    <div class="col-md-4 form-group">
                                        <asp:Label ID="lblCreatedBy" runat="server"></asp:Label>
                                    </div>
                                 </div>
                                <div class="row">
                                    <div class="col-md-2 form-group">                            
                                        <label>Created Date:</label>
                                    </div>
                                    <div class="col-md-4 form-group">
                                        <asp:Label ID="lblCreatedDate" runat="server"></asp:Label>
                                    </div>
                                    <div class="col-md-2 form-group">                            
                                        <label>Status:</label>
                                    </div>
                                    <div class="col-md-4 form-group">
                                        <asp:Label ID="lblStatus" runat="server"></asp:Label>
                                    </div>
                                </div>
                                 <div class="row">
                                    <div class="col-md-2 form-group">                            
                                        <label>Approved By:</label>
                                    </div>
                                    <div class="col-md-4 form-group">
                                        <asp:Label ID="lblApprovedby" runat="server"></asp:Label>
                                    </div>
                                    <div class="col-md-2 form-group">                            
                                        <label>Approved Date:</label>
                                    </div>
                                    <div class="col-md-4 form-group">
                                        <asp:Label ID="lblApprovedDate" runat="server"></asp:Label> 
                                    </div>
                                 </div>                                
                                <div class="row">
                                    <div class="col-md-2 form-group">                            
                                        <label>Trainer Cost:</label>
                                    </div>
                                    <div class="col-md-4 form-group">
                                        <asp:Label ID="lblTrainerCost" runat="server"></asp:Label>
                                    </div>                                 
                                    <div class="col-md-2 form-group">                            
                                        <label>Cost of Food/Venue:</label>
                                    </div>
                                    <div class="col-md-4 form-group">
                                        <asp:Label ID="lblFoodVenueCost" runat="server"></asp:Label>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-2 form-group">                            
                                        <label>Cost of Per Person:</label>
                                    </div>
                                    <div class="col-md-4 form-group">
                                        <asp:Label ID="lblPerPersonCost" runat="server"></asp:Label>
                                    </div>
                                    <div class="col-md-2 form-group">                            
                                        <label>Other Cost:</label>
                                    </div>
                                    <div class="col-md-4 form-group">
                                        <asp:Label ID="lblOtherCost" runat="server"></asp:Label> 
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-2 form-group">                            
                                        <label>Total Cost:</label>
                                    </div>
                                    <div class="col-md-4 form-group">
                                       <asp:Label ID="lblTotalCost" runat="server"></asp:Label>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-2 form-group">                            
                                        <label>Narration:</label>
                                    </div>
                                    <div class="col-md-10 form-group">
                                      <asp:Label ID="lblNarration" runat="server"></asp:Label>
                                    </div>
                                </div>
                            </div>
                            <div id="addNominee" runat="server">
                                 <div class="row">
                                     <div class="col-md-12 form-group">
                                        <strong>Add Nominees Information:</strong>
                                    </div>
                                    <div class="col-md-10 form-group autocomplete-form">
                                        <label>Employee Name:</label>
                                        <asp:TextBox ID="txtEmployeeName" runat="server" CssClass="form-control" AutoComplete="Off"></asp:TextBox>               
                                        <cc1:TextBoxWatermarkExtender ID="txtEmployeeName_TextBoxWatermarkExtender" runat="server" Enabled="True" 
                                            TargetControlID="txtEmployeeName" WatermarkCssClass="form-control" WatermarkText="Auto Complete">
                                        </cc1:TextBoxWatermarkExtender>                  
                                        <cc1:AutoCompleteExtender ID="txtEmployeeName_AutoCompleteExtender" runat="server" 
                                            DelimiterCharacters="" Enabled="True" ServicePath="~/Autocomplete.asmx" 
                                            ServiceMethod="GetEmployeeList" TargetControlID="txtEmployeeName"
                                            MinimumPrefixLength="1" CompletionInterval="10"
                                            EnableCaching="true" CompletionListCssClass="autocompleteTextBoxLP" 
                                            OnClientItemSelected="AutocompleteOnSelected">
                                        </cc1:AutoCompleteExtender>                                       
                                    </div>
                                    <div class="col-md-2 form-group">
                                        <label>&nbsp;</label><br />
                                      <asp:Button ID="btnAddNominee" runat="server" Text="Add New" class="btn btn-primary" onclick="btnAddNominee_Click"/>
                                    </div>
                                </div>
                                <div id="displayNomniee" runat="server"></div>
                            </div>
                            <div id="dis_nominee" runat="server">
                                <strong>Nominees (Participation) Information:</strong>
                                <div id="rptNominee" runat="server"></div>
                            </div>
                            <div class="form-group"> 
                                <asp:Button ID="btnSave" runat="server" Text=" Save " CssClass="btn btn-primary" onclick="btnSave_Click" 
                                    ValidationGroup="training"/>
                                <cc1:ConfirmButtonExtender ID="BtnSave_ConfirmButtonExtender" runat="server" 
                                    ConfirmText="Confirm to Save?" Enabled="True" TargetControlID="btnSave">
                                </cc1:ConfirmButtonExtender>
                                <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-primary" onclick="btnDelete_Click"/>
                                <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" ConfirmText="Confirm to Delete?" 
                                    Enabled="True" TargetControlID="btnDelete">
                                </cc1:ConfirmButtonExtender>
                                <asp:Button ID="btnBack" runat="server" Text="Back"  CssClass="btn btn-primary" onclick="btnBack_Click"/>                
                            </div>
                        </div>
                    </div>
                </section>
            </div>
        </div>
</asp:Content>
