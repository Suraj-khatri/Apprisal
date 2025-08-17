<%@ Page Language="C#" MasterPageFile="~/Apprisal.Master" AutoEventWireup="true"
    CodeBehind="KRAKPI.aspx.cs" Inherits="SwiftHrManagement.web.PerformanceAppraisalNew.PerformanceAgreement.KRAKPI" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="../CapsLock.js"></script>
    <%--<script type="text/javascript" language="javascript">
        function GetEmpName(sender, e) {
            var EmpIdArray = (e._value).split("|");
            document.getElementById("<%=hdnEmpName.ClientID%>").value = EmpIdArray[1];
        }

    </script>--%>
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

        function LoadGridCJ(_EVENT) {
            document.getElementById("<% =universalId.ClientID%>").value = _EVENT;
            if (_EVENT == 0) {
                document.getElementById("<% =LoadKRAKPIGrid.ClientID%>").click();
            }
            else if (_EVENT == 1) {
                document.getElementById("<% =LoadCJGrid.ClientID%>").click();
            }
            else if (_EVENT == 2) {

                document.getElementById("<% =LoadRatingGrid.ClientID%>").click();
            }
            else if (_EVENT == 3) {
                document.getElementById("<% =LoadAckGrid.ClientID%>").click();
            }

}
//Criticle Job
function onDeleteCJ(id) {
    if (confirm("Confirm Delete?")) {
        document.getElementById("<% =hdnId1CJ.ClientID%>").value = id;
        document.getElementById("<% =BtnDeleteRecordCJ.ClientID%>").click();
    }
}
function onEditCJ(id) {
    document.getElementById("<% =hdnId2CJ.ClientID%>").value = id;
    document.getElementById("<% =BtnEditRecordCJ.ClientID%>").click();
}
function EditDataCJ(id) {
    if (confirm("Are you sure, you want to save?")) {
        document.getElementById("<% =hdnId2CJ.ClientID%>").value = id;
        document.getElementById("<% =saveBtnCJ.ClientID%>").click();
    }
}
function CancelCJ() {
    //if (confirm("Are you sure, you want to cancel?")) {
    document.getElementById("<% =cancelCJ.ClientID%>").click();
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

// performance rating
function onDeletePR(id) {
    if (confirm("Confirm Delete?")) {
        document.getElementById("<% =hdnPrRowId1.ClientID%>").value = id;
        document.getElementById("<% =BtnDeleteRecordPR.ClientID%>").click();
    }
}
function onEditPR(id) {
    document.getElementById("<% =hdnPrRowId2.ClientID%>").value = id;
    document.getElementById("<% =BtnEditRecordPR.ClientID%>").click();
}
function EditDataPR(id) {
    if (confirm("Are you sure, you want to save?")) {
        document.getElementById("<% =hdnPrRowId1.ClientID%>").value = id;
        document.getElementById("<% =BtnSavePR.ClientID%>").click();
    }
}

function onViewPR(id) {
    document.getElementById("<% =hdnPrRowId1.ClientID%>").value = id;
            document.getElementById("<% =BtnViewPR.ClientID%>").click();
        }

        function CancelPR() {
            //if (confirm("Are you sure, you want to cancel?")) {
            document.getElementById("<% =BtnCancelPR.ClientID%>").click();
            //}
        }
    </script>
    <script  src="<%=ResolveUrl("/Theme/bower_components/jquery/dist/jquery.js") %>" ></script>
     <script src="<%=ResolveUrl("/Theme/bower_components/dist/js/bootstrap-datepicker.js")%>" ></script>
   
    <script>
        $(document).ready(function () {
            $('.datepicker').datepicker();
        })
    </script>
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
                        <%--<br />
                        <asp:TextBox ID="txtEmployee" runat="server" AutoComplete="Off" AutoPostBack="true"
                            OnTextChanged="txtEmployee_TextChanged" CssClass="form-control" Width="100%"></asp:TextBox>
                        <cc1:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server"
                            CompletionInterval="10" CompletionListCssClass="form-control"
                            DelimiterCharacters="" EnableCaching="true" Enabled="true"
                            MinimumPrefixLength="1" ServiceMethod="GetEmployeeList"
                            ServicePath="~/Autocomplete.asmx" TargetControlID="txtEmployee"
                            OnClientItemSelected="GetEmpName">
                        </cc1:AutoCompleteExtender>
                        <cc1:TextBoxWatermarkExtender ID="txtEmployee_TextBoxWatermarkExtender"
                            runat="server" Enabled="True" TargetControlID="txtEmployee"
                            WatermarkCssClass="form-control" WatermarkText="Auto Complete">
                        </cc1:TextBoxWatermarkExtender>--%>
                    </div>
                    <div class="form-group">     
                    <div class="form-group row" >
                        <div class="col-md-3">  <label>Present Location:</label></div>
                        <div class="col-md-3"> <asp:TextBox ID="currentBranch" runat="server" CssClass="form-control" ReadOnly="true" ></asp:TextBox></div>
                        <div class="col-md-3"> <label>Department Name:</label></div>
                        <div class="col-md-3"><asp:TextBox ID="currentDepartment" runat="server" CssClass="form-control"  ReadOnly="true"></asp:TextBox></div>
                    </div> 
                       <div class=" form-group row">
                        <div class="col-md-3"> <label>Sub Department1 Name:</label></div>
                        <div class="col-md-3"><asp:TextBox ID="currSubDeptID" runat="server" CssClass="form-control"  ReadOnly="true"></asp:TextBox></div>
                            <div class="col-md-3"> <label>Sub Department2 Name:</label></div>
                        <div class="col-md-3"><asp:TextBox ID="currSubDeptID2" runat="server" CssClass="form-control"  ReadOnly="true"></asp:TextBox></div>
                        </div>  
                       <div class="form-group row">
                          
                        <div class="col-md-3"> <label>Functional Title:</label></div>
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
                             <br/>
                        <div class="col-md-12"><asp:TextBox ID="nameAndFUnctionalDesignationOfSupervisor" runat="server" CssClass="form-control"   ReadOnly="true"></asp:TextBox></div>
                             </div>
                         <div class="form-group row">
                        <div class="col-md-8"> <label>Name and functional designation of Reviewing Officer:</label></div>
                             <br/>
                        <div class="col-md-12"><asp:TextBox ID="nameAndFunctionalDesignationOfReviewingOfficer" runat="server" CssClass="form-control"  ReadOnly="true"></asp:TextBox></div>
                             </div>

                        <div class="form-group row">
                        <div class="col-md-3"> <label>Performance Agreement effective From:</label></div>
                        <div class="col-md-3"><asp:TextBox ID="effectiveFrom" runat="server" CssClass="form-control"   ReadOnly="true"></asp:TextBox></div>
                        <div class="col-md-3"> <label>Performance Agreement effective To:</label></div>
                        <div class="col-md-3"><asp:TextBox ID="effectiveTo" runat="server" CssClass="form-control"   ReadOnly="true"></asp:TextBox></div>
                    </div>  
                    </div>      
                   </div>
                 </section>
            <ul class="nav nav-tabs" role="tablist">
                <li role="presentation" class="active" id="tab1" runat="server"><a href="#KRAKPIDiv"
                    aria-controls="KRA /KPI" role="tab" data-toggle="tab" onclick="LoadGridCJ('0');">KRA /KPI</a></li>
                <li role="presentation" id="tab2" runat="server"><a href="#criticalJobs" aria-controls="Critical Jobs"
                    role="tab" data-toggle="tab" onclick="LoadGridCJ('1');">Critical Jobs</a></li>
                <li role="presentation" id="tab3" runat="server"><a href="#PerformanceRating" aria-controls="Performance Rating"
                    role="tab" data-toggle="tab" name="Rating" onclick="LoadGridCJ('2');">Performance
                    Rating</a></li>
                <li role="presentation" id="tab4" runat="server"><a href="#Acknowledgement" aria-controls="Acknowledgement"
                    role="tab" data-toggle="tab" name="ack" onclick="LoadGridCJ('3');">Acknowledgement</a>
                </li>
            </ul>

            <%-- <ul class="nav nav-tabs">
                <li class="active"><a href="KRAKPI.aspx">KRA /KPI</a></li>
                <li><a href="CriticalJobs.aspx">Critical jobs</a></li>
                <li><a href="PerformanceRating.aspx">Performance Rating</a></li>
                <li><a href="Acknowledgement.aspx">Acknowledgement</a></li>
            </ul> --%>
            <div class="tab-content">
                <%--KRAKPI START --%>
                <div id="KRAKPIDiv" class="tab-pane active" runat="server">
                    <section class="panel">               
                        <div class="panel-heading">Agreed KRAs and KPIs for performance measurement</div>           
                     <div class="panel-body">   
                         <div runat="server" id="divAddKRAKPI" Visible="False">
                         <div class="form-group row">
                            <div class="col-md-4"> <label>KRA Topic:
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="kraTopic" Display="Dynamic" 
                                ErrorMessage="Required!" ValidationGroup="PerformanceMeasurement">
                        </asp:RequiredFieldValidator></label>
                            </div>
                              <div class="col-md-4"> <label>Weight(%): 100
                                  <asp:RequiredFieldValidator ID="RFVkraWeight" runat="server" ControlToValidate="kraWeight" Display="Dynamic" 
                                ErrorMessage="Required!" ValidationGroup="PerformanceMeasurement"> </asp:RequiredFieldValidator></label>
                              </div>
                             </div>
                           <div class="form-group row">
                            <div class="col-md-4"><asp:TextBox ID="kraTopic" runat="server" CssClass="form-control" ></asp:TextBox>
                            </div>                      
                            <div class="col-md-4"><asp:TextBox ID="kraWeight" runat="server" CssClass="form-control"  onkeyup="CheckDecimal(event)"></asp:TextBox>
                                 <%--<cc1:FilteredTextBoxExtender runat="server" FilterType="Numbers,Custom" TargetControlID="kraWeight" ValidChars="."/>--%>
                            </div>

                        </div>  
                         <div class="form-group row">
                            <div class="col-md-4"> <label>KPI Topic:
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="kpiTopic" Display="Dynamic" 
                                ErrorMessage="Required!" ValidationGroup="PerformanceMeasurement"></asp:RequiredFieldValidator></label>
                            </div>
                              <div class="col-md-4"> <label>Weight(%): 
                                  <asp:RequiredFieldValidator ID="RFVkpiWeight" runat="server" ControlToValidate="kpiWeight" Display="Dynamic" 
                                ErrorMessage="Required!" ValidationGroup="PerformanceMeasurement"></asp:RequiredFieldValidator></label></div>
                             </div>
                           <div class="form-group row">
                            <div class="col-md-4"><asp:TextBox ID="kpiTopic" runat="server" CssClass="form-control"  ></asp:TextBox></div>                      
                            <div class="col-md-4"><asp:TextBox ID="kpiWeight" runat="server" CssClass="form-control"  onkeyup="CheckDecimal(event)"></asp:TextBox>
                                <%--<cc1:FilteredTextBoxExtender runat="server" FilterType="Numbers,Custom" TargetControlID="kpiWeight" ValidChars="."/>--%>
                            </div>
                            <div class="col-md-4"> <asp:Button ID="BtnSave" runat="server" CssClass="btn btn-primary" Text="Add"
                                        Font-Strikeout="False" ValidationGroup="PerformanceMeasurement"
                                        Width="75px" OnClick="BtnSave_Click" /></div>
                        </div> 
                             </div>
                          
                         <hr />
                       <div class="row">
                            <div class="form-group col-md-12 table-responsive" >
                                <table class="table table-bordered ">
                                    <thead>
                                        <tr>
                                            <th>SNO</th>
                                            <th>KRA</th>
                                            <th>Weightage (%)</th>
                                            <th>KPI</th>
                                            <th>Weightage (%)</th>
                                            <th>Action</th>
                                        </tr>
                                    </thead>
                                    <tbody id="kra_grid" runat="server">

                                    </tbody>
                                </table>
                            </div>
                            <asp:HiddenField ID="hdnId2" runat="server" />
                            <asp:HiddenField ID="hdnId1" runat="server" />
                            <asp:Button ID="BtnEditRecord" runat="server" onclick="BtnEditRecord_Click" style="display:none;" />
                            <asp:Button ID="saveBtn" runat="server" onclick="saveBtn_Click" style="display:none;" />
                            <asp:Button ID="cancel" runat="server" onclick="cancel_Click" style="display:none;" />
                            <asp:Button ID="BtnDeleteRecord" runat="server" onclick="BtnDeleteRecord_Click" style="display:none;" />
                        </div>
                            <div class="form-group row">
                            <div class="col-md-4"  ><p>Note:</p></div>
                        </div>
                         <div class="form-group row">
                            <div class="col-md-12" ><p>1. KRAs for performance measurement should not be more than 10 with specific KPIs for each KRA.</p></div>
                        </div>
                         <div class="form-group row">
                            <div class="col-md-12" ><p>2. Total weight of all KRAs should be 100, weight of each KRA depends upon its importance and accordingly higher weight should be given to prime KRA. </p></div>
                        </div>
                         <div class="form-group row">
                            <div class="col-md-12" ><p>3. All Achievements will be capped at 150%. Hence the maximum score possible on the scorecard will be 150. </p></div>
                        </div>
                        </div>
                    </section>
                </div>
                <asp:Button ID="LoadKRAKPIGrid" runat="server" OnClick="LoadKRAKPIGrid_Click" Style="display: none;" />
                <%--KRAKPI END --%>

                <%--CRITICAL JOB START --%>
                <div id="criticalJobs" runat="server">
                    <section class="panel">               
                  <div><div class="container"><div style="padding:10px;position:relative;"> <span style="position:absolute;left:-5px;top:10px">B.</span> Following critical jobs are expected to be completed on a regular basis failure in completion will <br />  reduce the overall performance score of the appraisee </div></div>
                </div>
                <div class="panel-body">
                    <div runat="server" id="divAddCriticalJobs" Visible="False">
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
                            <asp:TextBox ID="txtDeductionScore" runat="server" CssClass="form-control" onkeyup="CheckDecimal(event)"></asp:TextBox>
                        </div>
                        <div class="col-md-3">
                            <asp:Button ID="btnAdd" runat="server" CssClass="btn btn-primary" Text="Add"
                                Font-Strikeout="False" ValidationGroup="user" OnClick="BtnSaveCJ_Click"
                                Width="75px" />
                        </div>
                    </div>
                        </div>

                    <div class="clearfix"></div>

                    <table class="table table-bordered mtop10">
                        <thead>
                            <tr>
                                <th>SNO</th>
                                <th>Objectives</th>
                                <th>Deduction Score</th>
                                <th>Action</th>
                            </tr>
                        </thead>
                        <tbody id="criticalJobs_grid" runat="server">
                        </tbody>
                    </table>

                    <%--<p>Note:Total sum of “Deduction points of all allocated critical jobs” should not be more than 5. </p>--%>
                </div>
                </section>
                </div>

                <asp:HiddenField ID="hdnId2CJ" runat="server" />
                <asp:HiddenField ID="hdnId1CJ" runat="server" />
                <asp:Button ID="BtnEditRecordCJ" runat="server" OnClick="BtnEditRecordCJ_Click" Style="display: none;" />
                <asp:Button ID="saveBtnCJ" runat="server" OnClick="saveBtnCJ_Click" Style="display: none;" />
                <asp:Button ID="cancelCJ" runat="server" OnClick="cancelCJ_Click" Style="display: none;" />
                <asp:Button ID="LoadCJGrid" runat="server" OnClick="LoadCJGrid_Click" Style="display: none;" />
                <asp:Button ID="BtnDeleteRecordCJ" runat="server" OnClick="BtnDeleteRecordCJ_Click"
                    Style="display: none;" />
                <%--CRITICAL JOB END --%>

                <%--PERFORMANCE RATING START --%>
                <div id="PerformanceRating" runat="server">
                    <section class="panel">               
                  <div><div class="container"><div style="padding:10px;position:relative;"> <span style="position:absolute;left:-5px;top:10px">C.</span> Performance Rating  </div></div>
                </div>
                    <div class="panel-body">
                       <div class="col-md-12 note-section">
                            <p>
                                1. Evaluation of the Performance Agreement at the end of the agreement period will be done on the basis of the agreed KRAs and KPIs set before with the following  evaluation guidelines
                            </p>
                        </div>

                        <div class="col-md-12 row padding-top-10">
                            <table class="table table-bordered table-striped table-condensed">
                                <thead>
                                    <tr>
                                        <th>Total KRA achievement score </th>
                                        <th>Performance level ratings</th>
                                        <th>Performance Percentage Increment</th>
                                    </tr>
                                </thead>
                                 <tbody id="perfRatingRef_grid" runat="server">

                                </tbody>
                              </table>
                        </div>
 
                        <div class="col-md-12 note-section">
                            <p>
                                2. In addition to the above competencies of the individual will also be evaluated by the supervisor at the time of performance review as defined in the “SOP for Performance Management System” and the overall performance will be rated accordingly                             
                            </p>
                        </div>

                        <div class="clearfix"></div>
                        <div class="panel-heading padding-top-10">Training assessment for the Year</div>           
                         <div class="panel-body"> 
                             <div runat="server" id="divAddTraining" Visible="False">
                             <div class="form-group row">
                                <div class="col-md-3"> Proposed Area:<span class="errormsg">*
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtProposedArea"
                                                   ErrorMessage="Required!" ValidationGroup="trainning" Display="Dynamic">
                                                </asp:RequiredFieldValidator></span>
                                </div>
                                <div class="col-md-3"> Criticality:<span class="errormsg">*
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddlCriticality"
                                                ErrorMessage="Required!" ValidationGroup="trainning" Display="Dynamic">
                                            </asp:RequiredFieldValidator></span>
                                </div>
                                <div class="col-md-3"> Date:<span class="errormsg">*
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtPrDate"
                                                ErrorMessage="Required!" ValidationGroup="trainning" Display="Dynamic">
                                            </asp:RequiredFieldValidator>
                                    <asp:RangeValidator ID = "rvDate" runat = "server" ControlToValidate = "txtPrDate" ErrorMessage = "Invalid Date!"
                                            Type = "Date" MinimumValue = "01/01/1900" MaximumValue = "01/01/2100" Display = "Dynamic" > </asp:RangeValidator></span>
                                </div>
                            
                                 </div>
                                
                             
                                <div class="form-group row">
                                    <div class="col-md-3"><asp:TextBox ID="txtProposedArea" runat="server" CssClass="form-control"></asp:TextBox></div>                      
                                    <div class="col-md-3"> <asp:DropDownList ID="ddlCriticality" runat="server"  CssClass="form-control" >
                                                        </asp:DropDownList> </div>
                                    <div class="col-md-3"><asp:TextBox ID="txtPrDate" runat="server" CssClass="form-control datepicker" placeholder="MM/DD/YYYY" ></asp:TextBox>
                                                           <%-- <cc1:CalendarExtender ID="txtDate_CalendarExtender" 
                                                    runat="server" Enabled="True" TargetControlID="txtPrDate">
                                                </cc1:CalendarExtender>--%>
                                    </div>                          
                                    <div class="col-md-3"> <asp:Button ID="BtnPerfRatingAdd" runat="server" CssClass="btn btn-primary" Text="Add"
                                                Font-Strikeout="False" ValidationGroup="trainning" Width="75px" OnClick="BtnPerfRatingAdd_OnClick"/></div>
                                </div> 
                                 </div>  
                             <div id="divRemarks" runat="server" Visible="False">
                                 <div class="form-group row">
                                        <div class="col-md-3">
                                             Remarks:<span class="errormsg">*
                                                  <asp:RequiredFieldValidator ID="RFVRemarks" runat="server" ControlToValidate="txtPrRemarks"
                                                ErrorMessage="Required!" ValidationGroup="trainning" Display="Dynamic" Visible="False">
                                            </asp:RequiredFieldValidator>
                                                     </span>
                                        </div>
                                </div> 
                                <div class="form-group row">
                                    <div class="col-md-9">
                                        <asp:TextBox ID="txtPrRemarks" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>  
                             </div>
                                               
                             <hr />
                           <div class="row">
                            <asp:UpdatePanel ID="pfTrainingUp" runat="server">
                                <ContentTemplate>
                                <div class="form-group col-md-12 table-responsive" >
                                    <table class="table table-bordered table-striped table-condensed">
                                        <thead>
                                            <tr>
                                                <th>SNO</th>
                                                <th>Proposed Area</th>
                                                <th>Criticality</th>
                                                <th>Proposed Training Date</th>
                                                <th>Action</th>
                                            </tr>
                                        </thead>
                                        <tbody id="perfTranning_grid" runat="server">
                                        </tbody>
                                    </table>
                                </div>
                                </ContentTemplate>
                                <Triggers>
                                   <asp:AsyncPostBackTrigger ControlID="BtnEditRecordPR" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="BtnSavePR" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="BtnPerfRatingAdd" EventName="Click" />
                                </Triggers>
                            </asp:UpdatePanel>
                                <asp:HiddenField ID="hdnPrRowId1" runat="server" />
                                <asp:HiddenField ID="hdnPrRowId2" runat="server" />
                                <asp:Button ID="BtnEditRecordPR" runat="server" onclick="BtnEditRecordPR_Click" style="display:none;" />
                                <asp:Button ID="BtnSavePR" runat="server" onclick="BtnSavePR_Click" style="display:none;" />
                                <asp:Button ID="BtnCancelPR" runat="server" onclick="BtnCancelPR_Click" style="display:none;" />
                                <asp:Button ID="BtnViewPR" runat="server" onclick="BtnViewPR_Click" style="display:none;" />
                                <asp:Button ID="BtnDeleteRecordPR" runat="server" onclick="BtnDeleteRecordPR_Click" style="display:none;" />
                            </div>  
                         
                             <div class="form-group row">
                                <div class="col-md-12"  ><p>Criticality Rating "1, 2, 3" </p></div>                         
                            </div>
                               <div class="form-group row">
                                <div class="col-md-12"  ><p>1. High critical required at the earliest  </p></div>                         
                            </div>
                               <div class="form-group row">
                                <div class="col-md-12"  ><p>2. Medium critical would help in better performance "Not required immediately" </p></div>                         
                            </div>
                               <div class="form-group row">
                                <div class="col-md-12"  ><p>3. Good to know  </p></div>                         
                            </div>
                              <div class="form-group row">
                                <div class="col-md-12" ><p>Note: Supervisor can recommend maximum 3 trainings for the year; more than 3 trainings need to be justified. 
                                </p></div>                         
                            </div>
                    </div>
                     </div>
                </section>
                </div>
                <asp:Button ID="LoadRatingGrid" runat="server" OnClick="LoadRatingGrid_Click" Style="display: none;" />
                <%--PERFORMANCE RATING END --%>

                <%--ACKNOWLEDGEMENT START --%>
                <div id="Acknowledgement" runat="server">
                    <section class="panel">      
                         <div class="panel-heading">Acknowledgement</div>           
                           <div class="panel-body">  
                                  <div class="row">
                            <div class="col-md-12 form-group ">
                                <asp:CheckBox runat="server" ID="chkSupervisor" Text="I Acknowledge and agree to the all the points mentioned in this agreement. (By Supervisor)"/>
                                 <div class="col-md-12 form-group ">
                                     <br />
                                     <asp:Label runat="server" ID="AckSuvDate" CssClass="text-blue text-bold"></asp:Label>
                              </div>
                     </div>
                                 
                     </div>
                         <div class="row">
                            <div class="col-md-12 form-group ">
                                <asp:CheckBox runat="server" ID="chkAppraisee" Text="I Acknowledge and agree to the all the points mentioned in this agreement. (By Appraisee)"/>
                              
                                         <asp:TextBox runat="server" ID="txt_disReason" TextMode="MultiLine" CssClass="form-control" Width="500px" placeholder="Disagree reason"></asp:TextBox>
                                  
                                <br />
                                <asp:Label runat="server" ID="AckAppraiseeDate" CssClass="text-blue text-bold" ></asp:Label>
                              </div>
                    
                                 
                     </div>
                                <div class="form-group row">
                            <fieldset>
                            <div class="col-md-12">
                                <asp:CheckBox runat="server" ID="chkRevOfficer" Text="I Acknowledge the points mentioned in the agreement. (By Reviewing Officer)"/>
                                 </div>
                                 <div class="col-md-12 form-group">
                                <asp:TextBox runat="server" ID="txtRevOfficer" TextMode="MultiLine" CssClass="form-control" Width="500px"></asp:TextBox>
                                      <%--<asp:Button ID="btnSaveReviewOfficer" runat="server" CssClass="btn btn-primary" Text="Save"  OnClick="btnSaveReviewOfficer_OnClick"/>--%>
                                     <br />
                                     <asp:Label runat="server" ID="AckRevOfficerDate" CssClass="text-bold text-blue"></asp:Label>
                                </div>
                                
                                 </fieldset>
                     </div>
                                <div class="form-group row">
                            <fieldset>
                            <div class="col-md-12">
                                <asp:CheckBox runat="server" ID="chkHRD" Text="I Acknowledge the points mentioned in the agreement. (By HR)"/>
                                 </div>
                                 <div class="col-md-12 from-group">
                                <asp:TextBox runat="server" ID="txtHRD" TextMode="MultiLine" CssClass="form-control" Width="500px"></asp:TextBox>
                                 <br />
                                <asp:Label runat="server" ID="AckHrdDate" CssClass="text-bold text-blue" ></asp:Label>     
                                 </div>

                                 </fieldset>
                     </div>
                                <fieldset>
                              
                         </fieldset>
                                <div class="form-group row">
                                     <div class="col-md-12">
                                      <asp:Button ID="btnSaveHRD" runat="server" CssClass="btn btn-success" Text="Acknowledge" OnClick="btnSaveHRD_OnClick" />
                                     <asp:Button ID="Btn_Disagree" runat="server" CssClass="btn btn-danger" Text="Disagree" OnClick="btnDisagree_OnClick" />
                                      </div>
                                    </div> </div>
                </section>
                </div>
                <asp:Button ID="LoadAckGrid" runat="server" OnClick="LoadAckGrid_OnClick" Style="display: none;" />
                <%--ACKNOWLEDGEMENT END --%>
            </div>
        </div>
    </div>
    <asp:HiddenField runat="server" ID="hdnSupervisorId" />
    <asp:HiddenField runat="server" ID="hdnReviewerId" />
    <asp:HiddenField runat="server" ID="hdnFlagSup" />
    <asp:HiddenField runat="server" ID="hdnFlagRev" />
    <asp:HiddenField runat="server" ID="hdnFlagAppraise" />
    <asp:HiddenField runat="server" ID="hdnFlagHRD" />
    <asp:HiddenField runat="server" ID="hdnStatus" />
    <asp:HiddenField ID="universalId" runat="server" Value="0" />
    <script type="text/javascript" src="../../js/functions.js"></script>
</asp:Content>

