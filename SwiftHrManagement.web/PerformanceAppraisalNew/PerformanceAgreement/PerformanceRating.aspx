<%@ Page Language="C#" MasterPageFile="~/Apprisal.Master" AutoEventWireup="true" CodeBehind="PerformanceRating.aspx.cs" Inherits="SwiftHrManagement.web.PerformanceAppraisalNew.PerformanceAgreement.PerformanceRating" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="../CapsLock.js"></script>
    <script type="text/javascript" language="javascript">
        function GetEmpName(sender, e) {
            var EmpIdArray = (e._value).split("|");
            document.getElementById("<%=hdnEmpName.ClientID%>").Value = EmpIdArray[1];
        }

    </script>


    <style type="text/css">
        .tabmenu-content-holder {
            background: #FFF;
        }

        .note-section {
            height: 80px;
            padding-left: 0px !important;
            background: #CCC;
        }

            .note-section p {
                padding-left: 5px;
                padding-top: 2px;
                padding-bottom: 2px;
            }

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
                             <br/>
                        <div class="col-md-12"><asp:TextBox ID="nameAndFUnctionalDesignationOfSupervisor" runat="server" CssClass="form-control"  ></asp:TextBox></div>
                             </div>
                         <div class="form-group row">
                        <div class="col-md-8"> <label>Name and functional designation of Reviewing Officer:</label></div>
                             <br/>
                        <div class="col-md-12"><asp:TextBox ID="nameAndFunctionalDesignationOfReviewingOfficer" runat="server" CssClass="form-control"  ></asp:TextBox></div>
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
                <li><a href="CriticalJobs.aspx">Critical jobs</a></li>
                <li class="active"><a href="PerformanceRating.aspx">Performance Rating</a></li>
                <li><a href="Acknowledgement.aspx">Acknowledgement</a></li>
            </ul>


            <div class="tab-content">

                <div id="performanceRating" class="tab-pane active">
                    <section class="panel">
                        <div class="panel-body">
                        <div class="col-md-12 note-section">
                            <p>C. Performance Rating</p>
                            <p>
                                1. Evaluation of the Performance Agreement at the end of the agreement period will be done on the basis of the agreed KRAs and KPIs set before with the following  evaluation guidelines
                            </p>
                        </div>

                        <div class="col-md-12 row padding-top-10">
                            <table class="table table-bordered ">
                                <thead>
                                    <tr>
                                        <th>Total KRA achievement score </th>
                                        <th>Performance level ratings</th>
                                        <th>Performance Percentage Increment</th>
                                    </tr>
                                </thead>
                                 <tbody id="perfRatingRef_grid" runat="server">

                                </tbody>
                               <%-- <tr>
                                    <td>Pull data from Performance Rating Setup</td>
                                    <td></td>
                                </tr>--%>
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
                             <div class="form-group row">
                                <div class="col-md-3"> Proposed Area:<span class="errormsg">*
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtProposedArea"
                                                   ErrorMessage="Required!" ValidationGroup="trainning" Display="Dynamic">
                                                </asp:RequiredFieldValidator></span>
                                </div>
                                <div class="col-md-3"> Criticality:<span class="errormsg">*
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlCriticality"
                                                ErrorMessage="Required!" ValidationGroup="trainning" Display="Dynamic">
                                            </asp:RequiredFieldValidator></span>
                                </div>
                                <div class="col-md-3"> Date:<span class="errormsg">*
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtDate"
                                                ErrorMessage="Required!" ValidationGroup="trainning" Display="Dynamic">
                                            </asp:RequiredFieldValidator>
                                    <asp:RangeValidator ID = "rvDate" runat = "server" ControlToValidate = "txtDate" ErrorMessage = "Invalid Date!"
                                            Type = "Date" MinimumValue = "01/01/1900" MaximumValue = "01/01/2100" Display = "Dynamic" > </asp:RangeValidator></span>
                                </div>
                            
                                 </div>
                               <div class="form-group row">
                                <div class="col-md-3"><asp:TextBox ID="txtProposedArea" runat="server" CssClass="form-control"></asp:TextBox></div>                      
                                <div class="col-md-3"> <asp:DropDownList ID="ddlCriticality" runat="server"  CssClass="form-control" >
                                                    </asp:DropDownList> </div>
                                <div class="col-md-3"><asp:TextBox ID="txtDate" runat="server" CssClass="form-control" ></asp:TextBox>
                                                        <cc1:CalendarExtender ID="txtDate_CalendarExtender" 
                                                runat="server" Enabled="True" TargetControlID="txtDate">
                                            </cc1:CalendarExtender>
                                </div>                          
                                <div class="col-md-3"> <asp:Button ID="BtnSave" runat="server" CssClass="btn btn-primary" Text="Add"
                                            Font-Strikeout="False" ValidationGroup="trainning" Width="75px"   OnClick="BtnSave_OnClick"/></div>
                            </div>                  
                             <hr />
                           <div class="row">
                                <div class="form-group col-md-12 table-responsive" >
                                    <table class="table table-bordered table-striped table-condensed">
                                        <thead>
                                            <tr>
                                                <th>SNO</th>
                                                <th>Proposed Area</th>
                                                <th>Criticality</th>
                                                <th>Specify the date by when training should be provided</th>
                                            </tr>
                                        </thead>
                                        <tbody id="perfTranning_grid" runat="server">

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
                    <div class="clearfix"></div>
                </div>

            </div>
        </div>
    </div>
</asp:Content>

