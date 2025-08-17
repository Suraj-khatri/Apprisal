<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SwiftHRManager.Master" CodeBehind="Manage.aspx.cs" Inherits="SwiftHrManagement.web.LeaveManagementModule.LeaveAssignment.Manage" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <script type="text/javascript" language="javascript">
        function GetEmpName(sender, e) {
            var EmpIdArray = (e._value).split("|");
            document.getElementById("<%=hdnEmpName.ClientID%>").Value = EmpIdArray[1];
        }
        function showHelp(val) {
            var msg;
            if (val == "LeaveDetails")
                msg = "Leave Details"
                        + "\nCashable: The unused Leave days gets cashed at the end of the Year/ Tenure."
                        + "\nHalf Day: The Leave Request can be applied as a half day."
                        + "\nSaturday: If applied leave has a saturday in between the leave start date and the leave end date,"
                        + "\n\t\tYes- includes saturday as a leave day."
                        + "\n\t\tNo - excludes Saturday from the leave."
                        + "\nHoliday: If applied leave has a holiday in between the leave start date and the leave end date,"
                        + "\n\t\tYes- Includes holiday as a leave day."
                        + "\n\t\tNo - Excludes holiday from the leave."
                        + "\nUnlimited: Allows to apply leave for any no. of days."
                        + "\nSubstitute: Allows to apply leave for the day(Saturday/holiday), the employee worked";

            alert(msg);
        }
       

    </script>
   <style>
       .btn span.glyphicon {    			
	opacity: 0;				
}
.btn.active span.glyphicon {				
	opacity: 1;				
}
   </style>
    <asp:UpdatePanel ID="AssignDetail" runat="server" UpdateMode="Conditional" RenderMode="block">
        <ContentTemplate>
            <div class="row">
                <div class="col-md-8 col-md-offset-2">
                    <section class="panel">
                    <header class="panel-heading">
                        <i class="fa fa-caret-right"></i>
                        Employee Leave Details Entry
                    </header>
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-md-12">
                            <asp:Label ID="LblMsg" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div class="row">
                                <div class="col-md-12">
                                    <label><strong> Leave Assignment Details:</strong></label>
                                </div>
                                <div class="col-md-12 autocomplete-form">
                                       <div class="form-group">
                                    <label>Employee Name :</label>
                                    <asp:Label ID="lblEmpName" runat="server"></asp:Label>
                                    <asp:TextBox ID="txtEmployee" runat="server" AutoComplete="Off"
                                        CssClass="form-control" AutoPostBack="true" OnTextChanged="txtEmployee_TextChanged"></asp:TextBox>
                                    <cc1:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server"
                                        CompletionInterval="10" DelimiterCharacters="" EnableCaching="true" Enabled="true"
                                        MinimumPrefixLength="1" ServiceMethod="GetEmployeeList" ServicePath="~/Autocomplete.asmx"
                                        TargetControlID="txtEmployee" OnClientItemSelected="GetEmpName" CompletionListCssClass="autocompleteTextBoxLP">
                                    </cc1:AutoCompleteExtender>
                                    <cc1:TextBoxWatermarkExtender ID="txtProduct_TextBoxWatermarkExtender"
                                        runat="server" Enabled="True" TargetControlID="txtEmployee"
                                        WatermarkText="Auto Complete" WatermarkCssClass="form-control">
                                    </cc1:TextBoxWatermarkExtender>
                                    <asp:HiddenField ID="hdnEmpName" runat="server" />
                                </div>
                                    </div>
                            </div>
                        <div class="row">
                                <div class="col-md-4">
                                       <div class="form-group">
                                    <label>Leave Type: </label>
                                    <asp:DropDownList ID="DdlLeaveName" runat="server" CssClass="form-control"
                                        OnSelectedIndexChanged="DdlLeaveName_SelectedIndexChanged" AutoPostBack="true">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="Rfd1" runat="server" ControlToValidate="DdlLeaveName"
                                        Display="Dynamic" ErrorMessage="*"
                                        ValidationGroup="LeaveAssign" SetFocusOnError="True">
                                    </asp:RequiredFieldValidator>
                                </div>
                                    </div>
                                <div class="col-md-4">
                                       <div class="form-group">
                                    <label>Is Active:</label>
                                    <asp:DropDownList ID="DdlIsActive" runat="server" CssClass="form-control">
                                        <asp:ListItem Value="1">Yes</asp:ListItem>
                                        <asp:ListItem Value="0">No</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                    </div>
                                <div class="col-md-4 form-group">
                                    <br/>
                                        <label >Default Days for Nxt Yr:</label>
                                        
                                    <asp:CheckBox ID="chkNxtYrValue" runat="server" OnCheckedChanged="chkNxtYrValue_CheckedChanged" AutoPostBack="true"></asp:CheckBox>
                                </div>
                               </div>
                            <div class="row">
                                <div class="col-md-4 form-group">
                               <asp:Panel ID="NextYearDays" runat="server">
                                        <label>Nxt Year Leave:</label>
                                        <asp:Label ID="lblNxtYrDays" runat="server"></asp:Label>
                                        <asp:TextBox ID="txtNextYearDays" runat="server" CssClass="form-control"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="Regexp5" runat="server" Display="Dynamic"
                                            ErrorMessage="Invalid Days" ControlToValidate="txtNextYearDays" ValidationGroup="LeaveAssign"
                                            ValidationExpression="(^\d{0,3}[.]?\d{0,2}$)" SetFocusOnError="True"></asp:RegularExpressionValidator>
                               </asp:Panel>
                                    </div>
                                <div class="col-md-4 form-group">
                                    <label>From Date: <span class="errormsg">*</span></label>
                                    <asp:RequiredFieldValidator ID="rfd3" runat="server"
                                        ControlToValidate="TxtFromDate" Display="Dynamic" ErrorMessage="Required!"
                                        ValidationGroup="LeaveAssign" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                    <asp:TextBox ID="TxtFromDate" runat="server" CssClass="form-control"></asp:TextBox>
                                    <cc1:CalendarExtender ID="TxtFromDate_CalendarExtender" runat="server"
                                        Enabled="True" TargetControlID="TxtFromDate">
                                    </cc1:CalendarExtender>
                                </div>
                                <div class="col-md-4 form-group">
                                    <label>To Date: <span class="errormsg">*</span></label>
                                    <asp:RequiredFieldValidator
                                        ID="rfd4" runat="server" ControlToValidate="TxtToDate"
                                        Display="Dynamic" ErrorMessage="Required!" ValidationGroup="LeaveAssign"
                                        SetFocusOnError="True"></asp:RequiredFieldValidator>
                                    <asp:Label ID="LblDateMsg" runat="server" CssClass="errormsg"></asp:Label>
                                    <asp:TextBox ID="TxtToDate" runat="server" CssClass="form-control"></asp:TextBox>
                                    <cc1:CalendarExtender ID="TxtToDate_CalendarExtender" runat="server"
                                        Enabled="True" TargetControlID="TxtToDate">
                                    </cc1:CalendarExtender>
                                </div>
                                </div>
                            <div class="row">
                                <div class="col-md-4 form-group">
                                    <label>Max. Days Per Request</label>
                                    <asp:TextBox ID="txtMaxDaysReq" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col-md-4 form-group">
                                    <label>Min. Days Per Request</label>
                                    <asp:TextBox ID="txtMinDaysReq" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                           </div>
                            
                            <asp:Panel ID="Days" runat="server">
                                <div class="row">
                                <div class="col-md-12">
                                <label><strong>Days:</strong></label>
                                    </div>
                                <div class="col-md-4 form-group">
                                    <label>Default Days:</label>
                                    <asp:Label ID="lblDefultDays" runat="server"></asp:Label>
                                    <asp:TextBox ID="TxtDefaultDays" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="Rgexp1" runat="server" Display="Dynamic"
                                        ErrorMessage="Invalid Days" ControlToValidate="TxtDefaultDays" ValidationGroup="LeaveAssign"
                                        ValidationExpression="(^\d{0,3}[.]?\d{0,2}$)" SetFocusOnError="True">
                                    </asp:RegularExpressionValidator>
                                </div>
                                <div class="col-md-4 form-group">
                                    <label>Last Yr Leave:</label>
                                    <asp:TextBox ID="TxtLastYrLeave" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="Regexp2" runat="server" Display="Dynamic"
                                        ErrorMessage="Invalid Days" ControlToValidate="TxtLastYrLeave" ValidationGroup="LeaveAssign"
                                        ValidationExpression="(^\d{0,3}[.]?\d{0,2}$)" SetFocusOnError="True">
                                    </asp:RegularExpressionValidator>
                                </div>
                                <div class="col-md-4 form-group">
                                    <label>Apply LFA:</label>
                                    <asp:DropDownList ID="DdlApplyLFA" runat="server" CssClass="form-control"
                                        OnSelectedIndexChanged="DdlApplyLFA_SelectedIndexChanged" AutoPostBack="true">
                                        <asp:ListItem Value="0">No</asp:ListItem>
                                        <asp:ListItem Value="1">Yes</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                

                                </div>
                                <div class="row">
                                        <div class="col-md-4 form-group">
                                    <asp:Panel ID="LFA" runat="server">
                                        <div>
                                            <label>LFA days:</label><asp:Label ID="lblLfadays" runat="server"></asp:Label>
                                        </div>
                                        <asp:TextBox ID="TxtNoofLfadays" runat="server" CssClass="form-control"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="Regexp3" runat="server" Display="Dynamic"
                                            ErrorMessage="Invalid Days" ControlToValidate="TxtNoofLfadays" ValidationGroup="LeaveAssign"
                                            ValidationExpression="^([0-9]*)(.([0,5]))?$" SetFocusOnError="True"></asp:RegularExpressionValidator>
                                    </asp:Panel>
                                </div>

                                </div>
                                 </asp:Panel>
                                
                                
                                <div class="row">
                                 <div class="col-md-12">
                                <label><strong>
                                    Leave Details:<a title='Click to see help' onclick="showHelp('LeaveDetails');"  style="text-decoration:none;">&nbsp;&nbsp;<i class="fa fa-question-circle" style="font-size:18px; text-decoration:none; cursor:pointer;"></i></a></strong>
                                </label>
                                 </div>
                                <div class="col-md-4 form-group">
                                    <label>Cashable</label>
                                    <asp:DropDownList ID="DdlCashable" runat="server" CssClass="form-control">
                                        <asp:ListItem Value="0">No</asp:ListItem>
                                        <asp:ListItem Value="1">Yes</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-4 form-group">
                                    <label>Half Day:</label>
                                    <asp:DropDownList ID="DdlHalfDay" runat="server" CssClass="form-control">
                                        <asp:ListItem Value="0">No</asp:ListItem>
                                        <asp:ListItem Value="1">Yes</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-4 form-group">
                                    <label>Saturday:</label>
                                    <asp:DropDownList ID="DdlSaturday" runat="server" CssClass="form-control">
                                        <asp:ListItem Value="0">No</asp:ListItem>
                                        <asp:ListItem Value="1">Yes</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                
                                    </div>
                            <div class="row">
                                <div class="col-md-4 form-group">
                                    <label>Holiday:</label>
                                    <asp:DropDownList ID="DdlHoliday" runat="server" CssClass="form-control">
                                        <asp:ListItem Value="0">No</asp:ListItem>
                                        <asp:ListItem Value="1">Yes</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-4 form-group">
                                    <label>Unlimited:</label>
                                    <asp:DropDownList ID="DdlUnlimited" runat="server" CssClass="form-control">
                                        <asp:ListItem Value="0">No</asp:ListItem>
                                        <asp:ListItem Value="1">Yes</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-4 form-group">
                                    <label>Substitute:</label>
                                    <asp:DropDownList ID="DdlSubstitute" runat="server" CssClass="form-control">
                                        <asp:ListItem Value="0">No</asp:ListItem>
                                        <asp:ListItem Value="1">Yes</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-4 form-group">
                                    <label>Relieving Arrangement:</label>
                                    <asp:DropDownList ID="DdlRelieving" runat="server" CssClass="form-control">
                                        <asp:ListItem Value="0">No</asp:ListItem>
                                        <asp:ListItem Value="1">Yes</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                               
                <div class="col-md-12">
                    <div id="rptDiv" runat="server"></div>
                </div>
                                 </div>
              
                    <asp:Button ID="BtnSave" runat="server" CssClass="btn btn-primary" Text="Save"
                        ValidationGroup="LeaveAssign" OnClick="BtnSave_Click" />
                    <cc1:ConfirmButtonExtender ID="BtnSave_ConfirmButtonExtender" runat="server"
                        ConfirmText="Confirm To Save ?" Enabled="True" TargetControlID="BtnSave">
                    </cc1:ConfirmButtonExtender>
                    <asp:Button ID="BtnDelete" runat="server" CssClass="btn btn-primary"
                        Text="Delete" OnClick="BtnDelete_Click" />
                    <cc1:ConfirmButtonExtender ID="BtnDelete_ConfirmButtonExtender" runat="server"
                        ConfirmText="Confirm To Delete ?" Enabled="True" TargetControlID="BtnDelete">
                    </cc1:ConfirmButtonExtender>
                    <asp:Button ID="BtnAssignNext" runat="server" CssClass="btn btn-primary"
                        Text="Assign Next" OnClick="BtnAssignNext_Click" />
                    <asp:Button ID="BtnBack" runat="server" CssClass="btn btn-primary"
                        Text="Back" OnClick="BtnBack_Click" />
              
            </div>
                </div>
                </section>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="txtEmployee" EventName="TextChanged" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
