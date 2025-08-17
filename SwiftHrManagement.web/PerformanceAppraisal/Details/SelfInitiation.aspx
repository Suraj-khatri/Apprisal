<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/ProjectMaster.Master" CodeBehind="SelfInitiation.aspx.cs" Inherits="SwiftHrManagement.web.PerformanceAppraisal.Details.SelfInitiation" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<%--<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">--%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">
        function AutocompleteOnSelected(sender, e) {
            var customerValueArray = (e._value).split("|");
            document.getElementById("<%= hdnEmpId.ClientID %>").value = customerValueArray[1];

        }
        function chooseSupervisor(sender, e) {
            var customerValueArray = (e._value).split("|");
            document.getElementById("<%= hdnSupId.ClientID %>").value = customerValueArray[1];

        }
        function chooseReviewer(sender, e) {
            var customerValueArray = (e._value).split("|");
            document.getElementById("<%= hdnReviewerId.ClientID %>").value = customerValueArray[1];

        }
        function chooseChief(sender, e) {
            var customerValueArray = (e._value).split("|");
            document.getElementById("<%= hdnChiefId.ClientID %>").value = customerValueArray[1];

        }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <asp:HiddenField ID="hdnSupId" runat="server" />
    <asp:HiddenField ID="hdnReviewerId" runat="server" />
    <asp:HiddenField ID="hdnChiefId" runat="server" />
<asp:UpdatePanel ID="up" runat="server">
<ContentTemplate>
     <div class="row">
        <div class="col-md-10 col-md-offset-1">
            <section class="panel">
                <header class="panel-heading">
                    <i class="fa fa-caret-right"></i>
                    Appraisal for Employee 
                </header>
                <div class="panel-body">
                    <div class="form-group">
                        <span class="txtlbl">Please enter valid data</span>
                        <span class="errormsg">(* Required Fields) </span>
                        <asp:Label ID="LblMsg" runat="server"></asp:Label>
                        <asp:HiddenField ID="hdnEmpId" runat="server" />
                        <label>Shift Name:</label>
                    </div>
                  
                          <div class="row">
                    <div class="col-md-8 form-group">
                        <label>Employee Name:<span class="errormsg">*</span></label>
                        <asp:RequiredFieldValidator ID="rfv3" runat="server" ControlToValidate="txtEmp" Display="Dynamic" 
                            ErrorMessage="Required" ValidationGroup="evaluate" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtEmp" runat="server" CssClass="form-control" AutoPostBack="true" AutoComplete="Off" ReadOnly="true"></asp:TextBox>  
                    </div>
                    <div class="col-md-4 form-group">
                        <label>Days:<span class="errormsg">*</span></label>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtSelfDays" Display="Dynamic" 
                             ErrorMessage="Required" ValidationGroup="evaluate"></asp:RequiredFieldValidator><br />
                        <asp:TextBox runat="server" ID="txtSelfDays" CssClass="form-control"></asp:TextBox>
                    </div>
                              </div>
                          <div class="row">
                    <div class="col-md-4 form-group">
                        <label>Branch Name:</label>
                        <asp:DropDownList ID="DdlBranchName" runat="server" CssClass="form-control" AutoPostBack="true"  
                             onselectedindexchanged="DdlBranchName_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                    <div class="col-md-4 form-group">
                        <label>Department Name:</label>
                         <asp:DropDownList ID="DdlDeptName" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>
                    <div class="col-md-4 form-group">
                        <label>  Academic Qualification:</label>
                        <asp:TextBox ID="TxtAcademicQualification" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                    </div>
                              </div>
                          <div class="row">
                    <div class="col-md-4 form-group">
                        <label>Appraisal From Date:<span class="errormsg">*</span></label>
                        <asp:RequiredFieldValidator ID="rfv2" runat="server" ControlToValidate="TxtFromDate" Display="Dynamic" 
                            ErrorMessage="Required" ValidationGroup="evaluate" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="TxtFromDate" runat="server" CssClass="form-control"></asp:TextBox>
                        <cc1:CalendarExtender ID="TxtFromDate_CalendarExtender" runat="server" 
                            Enabled="True" TargetControlID="TxtFromDate">
                        </cc1:CalendarExtender>
                    </div>
                    <div class="col-md-4 form-group">
                        <label>Appraisal To Date:<span class="errormsg">*</span></label>                        
                        <asp:RequiredFieldValidator ID="rfv" runat="server" ControlToValidate="TxtTodate" Display="Dynamic" 
                            ErrorMessage="Required" ValidationGroup="evaluate" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToCompare="TxtFromDate" ControlToValidate="TxtTodate" 
                            ErrorMessage="Invalid Date!" Operator="GreaterThanEqual" SetFocusOnError="True" ValidationGroup="evaluate" 
                            Display="Dynamic" Type="Date"></asp:CompareValidator>
                        <asp:TextBox ID="TxtTodate" runat="server" CssClass="form-control"></asp:TextBox>
                        <cc1:CalendarExtender ID="TxtTodate_CalendarExtender" runat="server" 
                            Enabled="True" TargetControlID="TxtTodate">
                        </cc1:CalendarExtender>
                    </div>
                    <div class="col-md-4 form-group">
                        <label>Date of Appointment:<span class="errormsg">*</span></label>
                        <%--<asp:RequiredFieldValidator ID="rfv1" runat="server" 
                      ErrorMessage="Required!" ControlToValidate="TxtDateOfAppoinment" 
                      Display="Dynamic" ValidationGroup="evaluate"></asp:RequiredFieldValidator>--%>
                        <asp:TextBox ID="TxtDateOfAppoinment" runat="server" CssClass="form-control" Enabled="false" ValidationGroup="evaluate">
                        </asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True" TargetControlID="TxtDateOfAppoinment">
                        </cc1:CalendarExtender>
                    </div>
                              </div>
                          <div class="row">
                    <div class="col-md-4 form-group">
                        <label>Appraisal Position:</label>
                        <span class="errormsg">*</span>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="DdlPositionAtAppointment" 
                            Display="Dynamic" ErrorMessage="Required" ValidationGroup="evaluate" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <asp:DropDownList ID="DdlPositionAtAppointment" runat="server" CssClass="form-control" ValidationGroup="evaluate"></asp:DropDownList>
                    </div>
                    <div class="col-md-4 form-group">
                        <label>Probation Period From:</label>
                        <asp:TextBox ID="TxtPrbPrdFromDate" runat="server" CssClass="form-control"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender4" runat="server" Enabled="True" TargetControlID="TxtPrbPrdFromDate">
                        </cc1:CalendarExtender>
                    </div>
                    <div class="col-md-4 form-group">
                        <label>Probation Period To:</label>
                         <asp:TextBox ID="TxtPrbPrdToDate" runat="server" CssClass="form-control"></asp:TextBox>
                         <cc1:CalendarExtender ID="CalendarExtender3" runat="server" Enabled="True" TargetControlID="TxtPrbPrdToDate">
                         </cc1:CalendarExtender>
                    </div>
                              </div>
                          <div class="row">
                    <div class="col-md-4 form-group">
                        <label>Current Position:</label>
                         <asp:DropDownList ID="DdlCurrentPosition" runat="server" CssClass="form-control" Enabled="false"></asp:DropDownList>
                    </div>
                    <div class="col-md-4 form-group">
                        <label>Permanent as (Position):</label>
                        <asp:DropDownList ID="DdlPermanentPosition" runat="server" CssClass="form-control" Enabled="false"></asp:DropDownList>
                    </div>
                    <div class="col-md-4 form-group">
                        <label>Permanent Date:</label>
                        <asp:TextBox ID="TxtEffectiveDate" runat="server" CssClass="form-control" Enabled="false" ></asp:TextBox> 
                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" TargetControlID="TxtEffectiveDate">
                        </cc1:CalendarExtender>
                    </div>
                              </div>
                          <div class="row">
                    <div class="col-md-8 form-group autocomplete-form">
                        <label>Supervisor Name:<span class="errormsg">*</span></label>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtSup" Display="Dynamic" 
                             ErrorMessage="Required" ValidationGroup="evaluate"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtSup" runat="server" CssClass="form-control" AutoComplete="Off"></asp:TextBox>
                        <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" runat="server" Enabled="True" TargetControlID="txtSup" 
                            WatermarkCssClass="form-control" WatermarkText="Auto Complete">
                        </cc1:TextBoxWatermarkExtender>
                        <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" CompletionInterval="10" 
                            CompletionListCssClass="autocompleteTextBoxLP" DelimiterCharacters="" EnableCaching="true" Enabled="true" 
                            MinimumPrefixLength="1" OnClientItemSelected="chooseSupervisor" ServiceMethod="GetEmployeeList" 
                            ServicePath="~/Autocomplete.asmx" TargetControlID="txtSup">
                        </cc1:AutoCompleteExtender>
                    </div>
                    <div class="col-md-4 form-group">
                        <label>Days:<span class="errormsg">*</span></label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtSupDays" Display="Dynamic" 
                            ErrorMessage="Required" ValidationGroup="evaluate"></asp:RequiredFieldValidator>
                        <asp:TextBox runat="server" ID="txtSupDays" CssClass="form-control"></asp:TextBox>
                    </div>
                              </div>
                          <div class="row">
                    <div class="col-md-8 form-group autocomplete-form">
                        <label>Reviewer Name:<span class="errormsg">*</span></label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtReviewer" Display="Dynamic" 
                            ErrorMessage="Required" ValidationGroup="evaluate"></asp:RequiredFieldValidator><br />
                        <asp:TextBox ID="txtReviewer" runat="server" CssClass="form-control" AutoComplete="Off"></asp:TextBox>
                        <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender3" runat="server" Enabled="True" TargetControlID="txtReviewer" 
                            WatermarkCssClass="form-control" WatermarkText="Auto Complete">
                        </cc1:TextBoxWatermarkExtender>
                        <cc1:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server" CompletionInterval="10" 
                            CompletionListCssClass="autocompleteTextBoxLP" DelimiterCharacters="" EnableCaching="true" Enabled="true" 
                            MinimumPrefixLength="1" OnClientItemSelected="chooseReviewer" ServiceMethod="GetEmployeeList" 
                            ServicePath="~/Autocomplete.asmx" TargetControlID="txtReviewer">
                        </cc1:AutoCompleteExtender>
                    </div>
                    <div class="col-md-4 form-group">
                        <label>Days:<span class="errormsg">*</span></label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtRevDays" Display="Dynamic" 
                            ErrorMessage="Required" ValidationGroup="evaluate">
                        </asp:RequiredFieldValidator>
                        <asp:TextBox runat="server" ID="txtRevDays" CssClass="form-control"></asp:TextBox>
                    </div>
                              </div>
                          <div class="row">
                    <div id = "salaryDetail" runat="server">
                        <div class="form-group">
                            <strong>Salary Details:</strong>
                            <label>Basic Salary:</label>
                            <asp:Label ID="lblBasicSalary" runat="server"></asp:Label>
                        </div>
                        <div class="form-group">
                            <label>Grade (s):</label>
                            <asp:Label ID="lblGrade" runat="server"></asp:Label> 
                        </div>
                        <div class="form-group">
                            <label>Total Basic Salary:</label>
                            <asp:Label ID="lblTotalBasicSalary" runat="server"></asp:Label>
                        </div>
                        <div class="form-group">
                            <label>Other Allowance:</label>
                            <asp:Label ID="lblOtherAllowance" runat="server"></asp:Label>
                        </div>
                        <div class="form-group">
                            <label>Gross Salary:</label>
                            <asp:Label ID="lblGrossSalary" runat="server"></asp:Label>
                        </div>
                    </div>                   
                    <div class="col-md-12 form-group">
                        <label>A. Transfer Record:</label>
                        <asp:TextBox ID="TxtTransferRecord" runat="server" CssClass="form-control" Textmode="MultiLine"></asp:TextBox>
                        <%--<div id="transferRecord" runat="server"  style="border:solid 1px gray"></div>--%>
                    </div>
                    <div class="col-md-12 form-group">
                        <label>B. Promotion Record:</label>
                        <asp:TextBox ID="TxtPromotionRecord" runat="server" CssClass="form-control" Textmode="MultiLine"></asp:TextBox>
                      <%--<div id="promotionRecord" runat="server"  style="border:solid 1px gray"></div>--%>
                    </div>
                    <div class="col-md-12 form-group">
                        <label>C. Training Record:</label>
                        <asp:TextBox ID="TxtTrainingRecord" runat="server" CssClass="form-control" Textmode="MultiLine"></asp:TextBox>
                      <%--<div id="trainingRecord" runat="server"  style="border:solid 1px gray"></div>--%>
                    </div>
                    <div class="col-md-12 form-group">
                        <label>D. Notes on file: Commendation/ Complaints/ Disciplinary Action:</label>
                        <asp:TextBox ID="TxtNotesonfile" runat="server" CssClass="form-control" Textmode="MultiLine"></asp:TextBox>
                    </div>
                     </div>
                        <asp:Button ID="BtnSave" runat="server" CssClass="btn btn-primary" onclick="BtnSave_Click" Text="Save" 
                            ValidationGroup="evaluate" />
                        <cc1:ConfirmButtonExtender ID="BtnSave_ConfirmButtonExtender" runat="server" ConfirmText="Are You Sure to Save?" 
                            Enabled="True" TargetControlID="BtnSave">
                        </cc1:ConfirmButtonExtender>
                        <asp:Button ID="BtnDelete" runat="server" CssClass="btn btn-primary" onclick="BtnDelete_Click" Text="Delete" />
                        <cc1:ConfirmButtonExtender ID="BtnDelete_ConfirmButtonExtender" runat="server" 
                            ConfirmText="Are You Sure to Delete?" Enabled="True" TargetControlID="BtnDelete">
                        </cc1:ConfirmButtonExtender>
                        <asp:Button ID="BtnBack" runat="server" CssClass="btn btn-primary" onclick="BtnBack_Click" Text="Back" />
                 
                
            </section>
        </div>
    </div>
</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>
