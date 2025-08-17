<%@ Page Language="C#" MasterPageFile="~/Apprisal.Master" AutoEventWireup="true" CodeBehind="ReviewInitiation.aspx.cs" Inherits="SwiftHrManagement.web.PerformanceAppraisalNew.PerformanceAgreement.ReviewInitiation" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="../CapsLock.js"></script>
    <script type="text/javascript" language="javascript">
        function GetEmpName(sender, e) {
            //alert("ss");
            var EmpIdArray = (e._value).split("|");
            document.getElementById("<%=hdnEmpName.ClientID%>").value = EmpIdArray[1];
        }

        function GetSuperVisorId(sender, e) {
                //alert("ss");
                var EmpIdArray = (e._value).split("|");
                document.getElementById("<%=hdnSupervisorId.ClientID%>").value = EmpIdArray[1];
            }
        function GetReviewerId(sender, e) {
                //alert("ss");
                var EmpIdArray = (e._value).split("|");
                document.getElementById("<%=hdnReviewerId.ClientID%>").value = EmpIdArray[1];
        }
        function Delete() {
            confirm

        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <div class="row">
        <asp:Label ID="abc" runat="server"></asp:Label>
        <div class="col-md-12">
            <asp:HiddenField ID="EmpType" runat="server" />
            <section class="panel">
                <header class="panel-heading">
                    <i class="fa fa-caret-right" aria-hidden="true"></i>  
                    Employee Details
                </header>
                <div class="panel-body">                           
                    <div class="form-group autocomplete-form" >
                        <label>Name Of Appraisee:<span class="errormsg">*</span></label>
                        <asp:Label ID="lblEmpName" runat="server" Font-Bold="True"></asp:Label>
                        <asp:HiddenField ID="hdnEmpName" runat="server" />
                        <br />
                        <asp:TextBox ID="txtEmployee" runat="server" AutoComplete="Off" AutoPostBack="true"
                            OnTextChanged="txtEmployee_TextChanged" CssClass="form-control" Width="100%"></asp:TextBox>
                        <cc1:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server"
                            CompletionInterval="10" 
                            DelimiterCharacters="" EnableCaching="true" Enabled="true"
                            MinimumPrefixLength="1" ServiceMethod="GetEmployeeListJD"
                            ServicePath="~/Autocomplete.asmx" TargetControlID="txtEmployee"
                            OnClientItemSelected="GetEmpName"  UseContextKey="True">
                        </cc1:AutoCompleteExtender>
                        <cc1:TextBoxWatermarkExtender ID="txtEmployee_TextBoxWatermarkExtender"
                            runat="server" Enabled="True" TargetControlID="txtEmployee"
                            WatermarkCssClass="form-control" WatermarkText="Auto Complete">
                        </cc1:TextBoxWatermarkExtender>
                    </div>
                    <div class="form-group">     
                    <div class="form-group row" >
                        <div class="col-md-3">  <label>Present Location:</label></div>
                        <div class="col-md-3"> <asp:TextBox ID="currentBranchId" runat="server" CssClass="form-control" ReadOnly="true" ></asp:TextBox></div>
                        <div class="col-md-3"> <label>Department Name:</label></div>
                        <div class="col-md-3"><asp:TextBox ID="currDeptId" runat="server" CssClass="form-control"  ReadOnly="true"></asp:TextBox></div>
                    </div> 
                       <div class=" form-group row">
                        <div class="col-md-3"> <label>Sub Department1 Name:</label></div>
                        <div class="col-md-3"><asp:TextBox ID="currSubDeptID1" runat="server" CssClass="form-control"  ReadOnly="true"></asp:TextBox></div>
                           <div class="col-md-3"> <label>Functional Title:</label></div>
                        <div class="col-md-3"><asp:TextBox ID="currFuncTitle" runat="server" CssClass="form-control"  ReadOnly="true"></asp:TextBox></div>
                        
                    </div>  
                       <div class="form-group row">
                            
                        <div class="col-md-3"> <label>Corporate Designation:</label></div>
                        <div class="col-md-3"><asp:TextBox ID="currPosition" runat="server" CssClass="form-control"  ReadOnly="true"></asp:TextBox></div>
                       <div class="col-md-3"> <label>Date of Joining at SBL:</label></div>
                        <div class="col-md-3"><asp:TextBox ID="joiningDate" runat="server" CssClass="form-control"  ReadOnly="true"></asp:TextBox></div>
                        
                    </div>   
                       <div class="form-group row">
                            
                           <div class="col-md-3"> <label>Tenure in Present Job:</label></div>
                        <div class="col-md-3"><asp:TextBox ID="timeSpentInTheCurrentBranchDept" runat="server" CssClass="form-control"  ReadOnly="true"></asp:TextBox></div>
                        <div class="col-md-3"> <label>Tenure in Present Position:</label></div>
                        <div class="col-md-3"><asp:TextBox ID="timeSpentInTheCurrentPosition" runat="server" CssClass="form-control"  ReadOnly="true"></asp:TextBox></div>
                        
                    </div> 
                    <div class="form-group col-md-12">
                        <asp:HiddenField runat="server" ID="hdnSupervisorId"/>
                        <label>Name and functional designation of Supervisor:</label>
                        <asp:TextBox ID="supervisorId" runat="server" CssClass="form-control" AutoPostBack="True"
                             OnTextChanged="supervisorId_OnTextChanged" ></asp:TextBox>  
                         <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server"
                            CompletionInterval="10" CompletionListCssClass="form-control"
                            DelimiterCharacters="" EnableCaching="true" Enabled="true"
                            MinimumPrefixLength="1" ServiceMethod="GetSupervisorList"
                            ServicePath="~/Autocomplete.asmx" TargetControlID="supervisorId"
                            OnClientItemSelected="GetSuperVisorId" UseContextKey="True" >
                        </cc1:AutoCompleteExtender>
                        <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1"
                            runat="server" Enabled="True" TargetControlID="supervisorId"
                            WatermarkCssClass="form-control" WatermarkText="Auto Complete">
                        </cc1:TextBoxWatermarkExtender>
                                                                 
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="supervisorId" Display="Dynamic" 
                            ErrorMessage="Required!" ValidationGroup="PerformanceRating">
                        </asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group col-md-12">
                         <asp:HiddenField runat="server" ID="hdnReviewerId"/>                       
                        <label>Name and functional designation of Reviewing Officer:</label>
                        <asp:TextBox ID="reviewerId" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>       
                        <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server"
                            CompletionInterval="10" CompletionListCssClass="form-control"
                            DelimiterCharacters="" UseContextKey="True" ContextKey="" EnableCaching="true" Enabled="true"
                            MinimumPrefixLength="1" ServiceMethod="GetEmployeeListAppraisal"
                            ServicePath="~/Autocomplete.asmx" TargetControlID="reviewerId"
                            OnClientItemSelected="GetReviewerId">
                        </cc1:AutoCompleteExtender>
                        <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2"
                            runat="server" Enabled="True" TargetControlID="reviewerId"
                            WatermarkCssClass="form-control" WatermarkText="Auto Complete">
                        </cc1:TextBoxWatermarkExtender>                                    
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="reviewerId" Display="Dynamic" 
                            ErrorMessage="Required!" ValidationGroup="PerformanceRating">
                        </asp:RequiredFieldValidator>
                    </div>                     
                       
                       

                    <div class="form-group row">
                        <div class="col-md-3"> <label>Performance Agreement effective From:</label></div>
                        <div class="col-md-3"><asp:TextBox ID="appraisalStartDate" runat="server" CssClass="form-control"  ValidationGroup="PerformanceRating"  ></asp:TextBox>
                              <cc1:CalendarExtender ID="appraisalStartDate_CalendarExtender" 
                        runat="server" Enabled="True" TargetControlID="appraisalStartDate">
                                    </cc1:CalendarExtender>
                                   <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="appraisalStartDate" Display="Dynamic" 
                            ErrorMessage="Required!" ValidationGroup="PerformanceRating">
                        </asp:RequiredFieldValidator>
                  
                        </div>
                        <div class="col-md-3"> <label>Performance Agreement effective To:</label></div>
                        <div class="col-md-3"><asp:TextBox ID="appraisalEndDate" runat="server"  CssClass="form-control" ValidationGroup="PerformanceRating"  ></asp:TextBox>
                            <cc1:CalendarExtender ID="appraisalEndDate_CalendarExtender" 
                        runat="server" Enabled="True" TargetControlID="appraisalEndDate">
                    </cc1:CalendarExtender>
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="appraisalEndDate" Display="Dynamic" 
                            ErrorMessage="Required!" ValidationGroup="PerformanceRating">
                        </asp:RequiredFieldValidator>
                        </div>
                    </div>
                         <asp:Button ID="saveBtn" runat="server" Text="Save" CssClass="btn btn-primary" ValidationGroup="PerformanceRating" OnClick="saveBtn_Click" /> 
                         <asp:Button ID="deleteBtn" runat="server" Text="Delete" CssClass="btn btn-primary"  OnClick="deleteBtn_OnClick" OnClientClick="return confirm('Are you sure you want to delete this item?');" Visible="False"/>  
                         <asp:Button ID="cancelBtn" runat="server" Text="Cancel" CssClass="btn btn-primary"  OnClick="cancelBtn_OnClick" />  

                          
                    </div>      
                   </div>
                 </section>

        </div>
    </div>
    <asp:HiddenField ID="hdnDeptId" runat="server" />
    <asp:HiddenField ID="hdnFunctionalTitle" runat="server" />
    <asp:HiddenField ID="hdnSubDeptId" runat="server" />
    <asp:HiddenField ID="hdnSubDeptId2" runat="server" />
    <asp:HiddenField ID="hdnPositionId" runat="server" />
    <asp:HiddenField ID="hdnOldPositionId" runat="server" />
    <asp:HiddenField ID="hdnOldBrachId" runat="server" />
    <asp:HiddenField ID="hdnLastPromotedDate" runat="server" />
    <asp:HiddenField ID="hdnBrachId" runat="server" />
</asp:Content>
