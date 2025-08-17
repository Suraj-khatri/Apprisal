<%@ Page Language="C#" MasterPageFile="~/Apprisal.Master" AutoEventWireup="true" CodeBehind="CriticalJobs.aspx.cs" Inherits="SwiftHrManagement.web.PerformanceAppraisalNew.PerformanceAgreement.CriticalJobs" MaintainScrollPositionOnPostback="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="../CapsLock.js"></script>
    <script type="text/javascript" language="javascript">
        function GetEmpName(sender, e) {
            var EmpIdArray = (e._value).split("|");
            document.getElementById("<%=hdnEmpName.ClientID%>").Value = EmpIdArray[1];
        }

    </script>
    <script type="text/javascript">
        function onDelete(id) {
            if (confirm("Confirm Delete?")) {
                document.getElementById("<% =hdnId1.ClientID%>").value = id;
                document.getElementById("<% =BtnDeleteRecord.ClientID%>").click();
            }
        }
        function onEdit(id) {
            document.getElementById("<% =hdnId2.ClientID%>").value = id;
            document.getElementById("<% =BtnEditRecord.ClientID%>").click();
        }
        function EditData(id) {
            if (confirm("Are you sure, you want to save?")) {
                document.getElementById("<% =hdnId2.ClientID%>").value = id;
                document.getElementById("<% =saveBtn.ClientID%>").click();
            }
        }
        function Cancel() {
            //if (confirm("Are you sure, you want to cancel?")) {
            document.getElementById("<% =cancel.ClientID%>").click();
              //}
        }
        function isNumber(evt) {
            evt = (evt) ? evt : window.event;
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57)) {
                return false;
            }
            return true;
        }
    </script>

    <style type="text/css">
        .padding-top-10 {
            padding-top: 10px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <div class="row">
        <asp:Label ID="abc" runat="server"></asp:Label>
        <div class="col-md-12">
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
                            CompletionInterval="10" CompletionListCssClass="form-control"
                            DelimiterCharacters="" EnableCaching="true" Enabled="true"
                            MinimumPrefixLength="1" ServiceMethod="GetEmployeeListByNameORId"
                            ServicePath="~/Autocomplete.asmx" TargetControlID="txtEmployee"
                            OnClientItemSelected="GetEmpName">
                        </cc1:AutoCompleteExtender>
                        <cc1:TextBoxWatermarkExtender ID="txtEmployee_TextBoxWatermarkExtender"
                            runat="server" Enabled="True" TargetControlID="txtEmployee"
                            WatermarkCssClass="form-control" WatermarkText="Auto Complete">
                        </cc1:TextBoxWatermarkExtender>
                    </div>
                    <div class="form-group">     
                    <div class="form-group row" >
                        <div class="col-md-3">  <label>Present Location:</label></div>
                        <div class="col-md-3"> <asp:TextBox ID="currentBranch" runat="server" CssClass="form-control" ReadOnly="true" ></asp:TextBox></div>
                        <div class="col-md-3"> <label>Department Name:</label></div>
                        <div class="col-md-3"><asp:TextBox ID="currentDepartment" runat="server" CssClass="form-control"  ReadOnly="true"></asp:TextBox></div>
                    </div> 
                       <div class=" form-group row">
                        <div class="col-md-3"> <label>Functional Designation:</label></div>
                        <div class="col-md-3"><asp:TextBox ID="currentFunctionalTitle" runat="server" CssClass="form-control"  ReadOnly="true"></asp:TextBox></div>
                        <div class="col-md-3"> <label>Corporate Designation:</label></div>
                        <div class="col-md-3"><asp:TextBox ID="currentPosition" runat="server" CssClass="form-control"  ReadOnly="true"></asp:TextBox></div>
                    </div>  
                       <div class="form-group row">
                        <div class="col-md-3"> <label>Date of Joining at SBL:</label></div>
                        <div class="col-md-3"><asp:TextBox ID="dateOfJoining" runat="server" CssClass="form-control"  ReadOnly="true"></asp:TextBox></div>
                        <div class="col-md-3"> <label>Tenure in Present Job:</label></div>
                        <div class="col-md-3"><asp:TextBox ID="timeSpentInTheCurrentBranchDept" runat="server" CssClass="form-control"  ReadOnly="true"></asp:TextBox></div>
                    </div>   
                       <div class="form-group row">
                        <div class="col-md-3"> <label>Tenure in Present Position:</label></div>
                        <div class="col-md-3"><asp:TextBox ID="timeSpentInTheCurrentPosition" runat="server" CssClass="form-control"  ReadOnly="true"></asp:TextBox></div>
                        
                    </div> 
                         <div class="form-group row">
                        <div class="col-md-3"> <label>Name and functional designation of Supervisor:</label></div>
                             </br>
                        <div class="col-md-12"><asp:TextBox ID="nameAndFUnctionalDesignationOfSupervisor" runat="server" CssClass="form-control"  ></asp:TextBox></div>
                             </div>
                         <div class="form-group row">
                        <div class="col-md-8"> <label>Name and functional designation of Reviewing Officer:</label></div>
                             </br>
                        <div class="col-md-12"><asp:TextBox ID="nameAndFunctionalDesignationOfReviewingOfficer" runat="server" CssClass="form-control"  
                            ></asp:TextBox></div>
                             </div>

                        <div class="form-group row">
                        <div class="col-md-3"> <label>Performance Agreement effective From:</label></div>
                        <div class="col-md-3"><asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"  ></asp:TextBox></div>
                        <div class="col-md-3"> <label>Performance Agreement effective To:</label></div>
                        <div class="col-md-3"><asp:TextBox ID="TextBox2" runat="server" CssClass="form-control"  ></asp:TextBox></div>
                    </div>  
                    </div>      
                   </div>
                 </section>
            <ul class="nav nav-tabs">
                <li><a href="KRAKPI.aspx">KRA /KPI</a></li>
                <li class="active"><a href="CriticalJobs.aspx">Critical jobs</a></li>
                <li><a href="PerformanceRating.aspx">Performance Rating</a></li>
                <li><a href="Acknowledgement.aspx">Acknowledgement</a></li>
            </ul>

            <div class="tab-content">
                <div id="criticalJobs" class="tab-pane active">
                    <section class="panel">               
                  <div><div class="container"><div style="padding:10px;position:relative;"> <span style="position:absolute;left:-5px;top:10px">B.</span> Following critical jobs are expected to be completed on a regular basis failure in completion will <br />  reduce the overall performance score of the appraisee </div></div>
                </div>
                <div class="panel-body">
                    <div class="form-group row">
                        <div class="col-md-6">
                            <label>Objectives:</label>
                            <span class="errormsg">*</span>
                            <asp:RequiredFieldValidator
                                ID="RFV1" runat="server" ControlToValidate="txtObjectives"
                                Display="Dynamic" ErrorMessage="Required!" ValidationGroup="user"
                                SetFocusOnError="True" CssClass="danger"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-4">
                            <label>Deduction Score:</label>
                            <span class="errormsg">*</span>
                            <asp:RequiredFieldValidator
                                ID="RFV2" runat="server" ControlToValidate="txtDeductionScore"
                                Display="Dynamic" ErrorMessage="Required!" ValidationGroup="user"
                                SetFocusOnError="True" CssClass="danger"></asp:RequiredFieldValidator>

                        </div>
                    </div>
                    <div class="form-group row">
                        <div class="col-md-6">
                            <asp:TextBox ID="txtObjectives" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtDeductionScore" runat="server" CssClass="form-control" onkeypress="return isNumber(event)"></asp:TextBox>
                        </div>
                        <div class="col-md-3">
                            <asp:Button ID="btnAdd" runat="server" CssClass="btn btn-primary" Text="Add"
                                Font-Strikeout="False" ValidationGroup="user" OnClick="BtnSave_Click"
                                Width="75px" />
                        </div>
                    </div>

                    <div class="clearfix"></div>

                    <table class="table table-bordered mtop10">
                        <thead>
                            <tr>
                                <th>SNO</th>
                                <th>Objectives</th>
                                <th>Deduction Score</th>
                                <th></th>
                            </tr>
                        </thead>
                        <tbody id="criticalJobs_grid" runat="server">
                        </tbody>
                    </table>

                    <%--<p>Note:Total sum of “Deduction points of all allocated critical jobs” should not be more than 5. </p>--%>
                </div>
                </section>
            </div>




            <asp:HiddenField ID="hdnId2" runat="server" />
            <asp:HiddenField ID="hdnId1" runat="server" />
            <asp:Button ID="BtnEditRecord" runat="server" OnClick="BtnEditRecord_Click" Style="display: none;" />
            <asp:Button ID="saveBtn" runat="server" OnClick="saveBtn_Click" Style="display: none;" />
            <asp:Button ID="cancel" runat="server" OnClick="cancel_Click" Style="display: none;" />
            <asp:Button ID="BtnDeleteRecord" runat="server" OnClick="BtnDeleteRecord_Click" Style="display: none;" />
        </div>
        <div class="form-group row">
            <div class="col-md-12">
            </div>
        </div>
    </div>

</asp:Content>

