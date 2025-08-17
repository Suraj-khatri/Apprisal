<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ApprisalPrint.aspx.cs" Inherits="SwiftHrManagement.web.PerformanceAppraisalNew.PerformanceReview.ApprisalPrint" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <link href="~/ui/css/style.css" rel="stylesheet" />
    <style>
        body {
            color: #000;
            font-family: Calibri;
        }

        .header {
            border-bottom: 2px solid #808080;
            padding: 10px;
            font-family: 'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif;
            margin: 10px,0,10px,0;
        }

        .title {
            font-family: 'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif;
            margin: 10px,0,10px,0;
        }

        .table-bordered > thead > tr > th, .table-bordered > tbody > tr > th, .table-bordered > tfoot > tr > th, .table-bordered > thead > tr > td, .table-bordered > tbody > tr > td, .table-bordered > tfoot > tr > td {
            border: 1px solid #000;
        }

        thead {
            background: #ddd;
        }
    </style>
</head>
<body style="width: 98%; margin-left: 1%;">
    <form runat="server" style="margin-top: 1px;">

        <div style="text-align: center">
            
            <h3>Siddhartha Bank Limited</h3>
            <h4>Performance Appraisal Reports</h4>
            <h4 class="title">Status: <i><%= Session["StS"].ToString() %></i> </h4>
            <h4 class="title">Fiscal Year: <i><%= Session["FiscalYear"].ToString() %></i> </h4>

        </div>
        <h4 class="header">Employee Details</h4>
        <table class="table-bordered table">
            <tr>
                <td>Name Of Appraisee</td>
                <td>
                    <asp:Label ID="lblEmpName" runat="server" Font-Bold="True"></asp:Label></td>
                <td>Date of Joining</td>
                <td>
                    <asp:Label ID="dateOfJoining" runat="server" Font-Bold="True"></asp:Label></td>
            </tr>
            <tr>
                <td>Present Location:</td>
                <td>
                    <asp:Label ID="currentBranch" runat="server" Font-Bold="True"></asp:Label></td>
                <td>Department Name:</td>
                <td>
                    <asp:Label ID="currentDepartment" runat="server" Font-Bold="True"></asp:Label></td>
            </tr>
            <tr>
                <td>Functional Designation:</td>
                <td>
                    <asp:Label ID="currentFunctionalTitle" runat="server" Font-Bold="True"></asp:Label></td>
                <td>Corporate Designation:</td>
                <td>
                    <asp:Label ID="currentPosition" runat="server" Font-Bold="True"></asp:Label></td>
            </tr>
            <tr>
                <td>Tenure in present Job:</td>
                <td>
                    <asp:Label ID="timeSpentInTheCurrentBranchDept" runat="server" Font-Bold="True"></asp:Label></td>
                <td>Tenure in present Position:</td>
                <td>
                    <asp:Label ID="timeSpentInTheCurrentPosition" runat="server" Font-Bold="True"></asp:Label></td>
            </tr>
            <tr>
                <td>Name and functional designation of Supervisor:</td>
                <td>
                    <asp:Label ID="nameAndFUnctionalDesignationOfSupervisor" runat="server" Font-Bold="True"></asp:Label></td>
             <td>Name and functional designation of Reviewing Officer:</td>
             <td>
                    <asp:Label ID="nameAndFunctionalDesignationOfReviewingOfficer" runat="server" Font-Bold="True"></asp:Label></td>
            </tr>
           
            <tr>
                <td>Performance Review effective From:</td>
                <td>
                    <asp:Label ID="effectiveFrom" runat="server" Font-Bold="True"></asp:Label></td>            
                <td >Performance Review effective To:</td>
                <td >
                    <asp:Label ID="effectiveTo" runat="server" Font-Bold="True"></asp:Label></td>
            </tr>
        </table>
        <br />
        <h4 class="header">A. Agreed KRAs and KPIs for performance measurement</h4>
        <table class="table table-bordered ">
            <thead>
                <tr>
                    <th>S.N</th>
                    <th>KRA</th>
                    <th>KPI</th>
                    <th>Weightage(%)</th>
                    <th>Variance(%)</th>
                    <th>Performance_Score </th>
                    <th>Remarks</th>
                </tr>
            </thead>
            <tbody id="kra_grid" runat="server">
            </tbody>

            <tr>
                <td colspan="2">Total</td>
                <td></td>
                <td>
                    <asp:Label runat="server" ID="kpitotaltable"></asp:Label>
                </td>
                <td></td>

                <td>
                    <asp:Label runat="server" ID="total"></asp:Label>
                </td>
            </tr>

        </table>
        <br />
        <div>
            Note:
                                <ol>
                                    <li>All Achievements will be capped at 150%. Hence the maximum score possible on the
                                        scorecard will be 150.</li>
                                    <li>Performance score for KPI assigned in number figures should be rated based on the
                                        achievement against the assigned number. </li>
                                    <li>Performance score for other KPI should be rated against the weight itself based
                                        on performance.</li>
                                </ol>
        </div>
        <h4 class="header">B. Following critical jobs are expected to be completed on a regular basis failure in completion will reduce the overall performance score of the appraisee 
                                 
        </h4>

        <table class="table table-bordered  table-responsive">
            <thead>
                <tr>
                    <th>S.N</th>
                    <th>Objectives</th>
                    <th>Deduction Score</th>
                    <th>Critical Rating</th>
                </tr>
            </thead>
            <tbody id="criticalJobs_grid" runat="server">
            </tbody>

            <tr>
                <td colspan="2"><b>Total</b></td>
                <td>
                    <asp:Label ID="lblCJTotal" runat="server" Text="0" Font-Bold="true"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblCJTotalObtained" runat="server" Text="0" Font-Bold="true"></asp:Label>
                </td>
            </tr>

        </table>
        <br />

        <div>
            Note: Total sum of “Deduction points of all allocated critical jobs” should not be more than 5. 
        </div>

        <h4 class="header">C. Performance Rating </h4>

        <table class="table table-bordered">
            <thead>
                <tr>
                    <th>Total KRA achievement score </th>
                    <th>Performance level ratings</th>
                    <th>Percenatge of Increment</th>

                </tr>
            </thead>
            <tbody id="perfRatingRef_grid" runat="server">
            </tbody>
        </table>
        <br />





        <h4 class="header">D. Competency Review</h4>


        <table class="table table-bordered ">
            <thead>
                <tr>
                    <th rowspan="2">S. No</th>
                    <th rowspan="2">Competencies</th>
                    <th style="text-align: center;">Level and Weights</th>
                    <th rowspan="2">Rating Score</th>
                </tr>
                <tr>
                    <th style="text-align: center;display:none">
                        <asp:Label ID="lblLevelHeader" runat="server"></asp:Label>
                    </th>
                </tr>
            </thead>
            <tbody id="competencies_grid" runat="server">
            </tbody>

            <tr>
                <td></td>
                <td><b>Total Score</b></td>
                <td>
                    <asp:Label ID="lblCompTotalWeight" runat="server" Font-Bold="true"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblCompTotal" runat="server" Font-Bold="true"></asp:Label>
                </td>

            </tr>

        </table>
        <br />





        <%-- Score --%>


        <h4 class="header">E. Performance Score Calculation
        </h4>

        <table class="table table-bordered">
            <thead>
                <tr>
                    <th >S. No.</th>
                    <th>KRA</th>
                    <th>Weight</th>
                    <th >Score</th>
                </tr>
            </thead>
            <tbody id="ScoreKpi_grid" runat="server">
            </tbody>

            <tr>
                <td colspan="2"><b>Total Score</b></td>
                <td>
                    <asp:Label ID="lblWeightKpiTotal" runat="server" Font-Bold="true"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblScoreKpiTotal" runat="server" Font-Bold="true"></asp:Label>
                </td>
            </tr>


        </table>
        <br />


        <table class="table table-bordered">
            <thead>
                <tr>
                    <th >S. No.</th>
                    <th >Competency</th>
                    <th >Weight</th>
                    <th >Score</th>
                </tr>
            </thead>
            <tbody id="ScoreComp_grid" runat="server">
            </tbody>

            <tr>
                <td colspan="2"><b>Total Score</b></td>
                <td>
                    <asp:Label ID="lblWeightCompTotal" runat="server" Font-Bold="true"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblScoreCompTotal" runat="server" Font-Bold="true"></asp:Label>
                </td>
            </tr>

        </table>
        <br />


        <h4 class="header">Overall Performance Score:</h4>

        <table class="table table-bordered">
            <thead>
                <tr>
                    <th>S.No</th>
                    <th>Dimensions</th>
                    <th>Weight As per level</th>
                    <th>Total Score Achieved</th>
                    <th>Total Weighted</th>
                </tr>
            </thead>
            <tr>
                <td>A</td>
                <td>Total KRAs Score</td>
                <td>
                    <asp:Label ID="lblKraWeightAsPerLevel" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblTotalKraScored" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblTotalKraWeighted" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>B</td>
                <td>Total Competencies Score</td>
                <td>
                    <asp:Label ID="lblCompWeightAsPerLevel" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblTotalCompScored" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblTotalCompWeighted" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="4"><b>Overall Performance Score</b></td>
                <td>
                    <asp:Label ID="lblOverallPerfScore" runat="server" Font-Bold="true"></asp:Label>
                </td>
            </tr>
        </table>
        <br />

        

            <table class="table table-bordered ">
                <tr>
                    <th>Overall Score Achievement</th>
                    <th>Performance Rating</th>
                    <th>Marking based on overall score</th>
                </tr>
                <tr>
                    <td>Above 115</td>
                    <td>Performance Level 5</td>
                    <td>
                        <div id="divExcellent" runat="server"></div>
                    </td>
                </tr>
                <tr>
                    <td>Above 95 to 115</td>
                    <td>Performance Level 4</td>
                    <td>
                        <div id="divVeryGood" runat="server"></div>
                    </td>
                </tr>
                <tr>
                    <td>Above 80 to 95</td>
                    <td>Performance Level 3</td>
                    <td>
                        <div id="divGood" runat="server"></div>
                    </td>
                </tr>
                <tr>
                    <td>Above 65 to 80</td>
                    <td>Performance Level 2</td>
                    <td>
                        <div id="divFair" runat="server"></div>
                    </td>
                </tr>
                <tr>
                    <td>65 and Below 65</td>
                    <td>Performance Level 1</td>
                    <td>
                        <div id="divPoor" runat="server"></div>
                    </td>
                </tr>
            </table>
        <br />


        <h4>F. Supervisor comments</h4>
        <table class="table table-bordered">
            <thead>
                <tr>
                    <th>S.N</th>

                    <th colspan="2">Critical comments by the supervisor </th>

                </tr>
            </thead>
            <tbody>

                <tr>
                    <td>1.</td>
                    <td colspan="2">What are the strong points of the appraisee in relation to various critical job dimensions mention above?
                    <br />
                        <small><b>
                            <asp:Label Text="text" runat="server" ID="txtan1" /></b></small>
                    </td>

                </tr>

                <tr>
                    <td>2.</td>
                    <td colspan="2">What are the weak points of the appraisee in relation to various critical job dimensions mentioned above? 
                    <br />
                        <small>
                            <b>
                                <asp:Label Text="text" runat="server" ID="txtan2" /></b>
                        </small>
                    </td>

                </tr>

                <tr>
                    <td>3.</td>
                    <td colspan="2">If the employee has demonstrated any outstanding performance or work of superior order indicate that. 
                    <br />
                        <small><b>
                            <asp:Label Text="text" runat="server" ID="txtan3" /></b></small>
                    </td>

                </tr>

                <tr>
                    <td>4.</td>
                    <td colspan="2">If the performance of the employee is below the minimum rating, indicate the areas and make a job improvement plan for the employees. Mention the date of submission of the plan to Human Resource Department.
                    <br />
                        <small><b>
                            <asp:Label Text="text" runat="server" ID="txtan4" /></b></small>
                    </td>

                </tr>

                <tr>
                    <td>5.</td>
                    <td colspan="2">If the employee is not yet conformed on the job, indicate whether his/her probationary period should be extended (Give reasons).
                    <br />
                        <small>
                            <b>
                                <asp:Label Text="text" runat="server" ID="txtan5" />
                            </b>
                        </small>
                    </td>

                </tr>
                <tr>
                    <td>Remarks</td>
                    <td colspan="2">
                        <small>
                            
                                <asp:Label Text="text" runat="server" ID="SupervisorRemarks" />
                            
                        </small>
                    </td>
                </tr>

            </tbody>

            <tr>
                <th rowspan="3"></th>
                <th style="width: 50%">Signature of Employee</th>
                <th style="width: 50%">Signature of Immediate Supervisor </th>
            </tr>
            <tr>

                <td style="width: 50%">Name: <%= Session["EmpName"].ToString() %></td>
                <td style="width: 50%">Name: <%= Session["supervisorName"].ToString() %></td>
            </tr>
            <tr>

                <td style="width: 50%">Date:<%= Convert.ToDateTime(Session["AppriseDate"]).ToString() %></td>
                <td style="width: 50%">Date:<%= Convert.ToDateTime(Session["SupDate"]).ToString() %> </td>
            </tr>


        </table>
        <br />

        <h4 class="header">G. Details of successfully completed trainings in last review period from
           <asp:Label ID="lblApprisalStartDate" runat="server"></asp:Label>
            to
           <asp:Label Text="text" runat="server" ID="lblApprisalEndDate" />
        </h4>


        <table class="table table-bordered ">
            <thead>
                <tr>
                    <th>S.N</th>
                    <th>Proposed Area</th>
                    <th>Training Period</th>
                    <th>Performance After Training</th>
                </tr>
            </thead>
            <tbody id="perfTranning_grid" runat="server">
            </tbody>
        </table>
        <br />


        <div>
            Note: Please rate the Appraisee performance in proposed areas after training in
                                    1 to 5 scale (“Above 4 Excellent”, “Above 3 to 4 Very Good”, “Above 2.5 to 3 Good”,
                                    “Above 2 to 2.5 Acceptable”, “Below 2 Substandard”).  0 Scale for not attend Training.
        </div>
        <br />
        <br />
        <table class="table table-bordered">
             <tr>
                <th rowspan="3"></th>
                <th style="width: 50%">Signature of Employee</th>
                <th style="width: 50%">Signature of Immediate Supervisor </th>
            </tr>
            <tr>

                <td style="width: 50%">Name: <%= Session["EmpName"].ToString() %></td>
                <td style="width: 50%">Name: <%= Session["supervisorName"].ToString() %></td>
            </tr>
            <tr>

                <td style="width: 50%">Date:<%= Convert.ToDateTime(Session["AppriseDate"]).ToString() %></td>
                <td style="width: 50%">Date:<%= Convert.ToDateTime(Session["SupDate"]).ToString() %> </td>
            </tr>
        </table>
        <br />
        <p>(Note: Appraisee and Supervisor are requested to sign in all pages of performance review form) </p>



        <h4 class="header">H. Comments of Reviewing and Executive Officers</h4>
        <table class="table table-bordered">
            <tr>
                <th colspan="2">Comment of Reviewing officer 
                    
                </th>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="txtRevOfficer" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <th colspan="2">If Appraisee is most suitable for any other position please specify with the reason for suitability……. 
               
                </th>

            </tr>
            <tr>
                <td colspan="2">
                    <b></b><asp:Label ID="txtRevReason" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Sales (Please specify the area of sales) </td>
                <td>Human resource </td>
            </tr>
            <tr>
                <td>Marketing </td>
                <td>Finance </td>
            </tr>
            <tr>
                <td>Operations </td>
                <td>HBack Office  </td>
            </tr>
            <tr>
                <td>Administration </td>
                <td>Others (please specify)……….</td>
            </tr>
            <tr>
                <td>Signature:  </td>
                
                <td>Date: <asp:Label ID="ReviewerDate" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td>Name: <%= Session["reviewerName"].ToString() %></td>
                <td>Position: <%= Session["reviewerPosition"].ToString() %></td>
            </tr>
            <tr>
                <td colspan="2">Note: Please attach a separate sheet to write comments and suggestions if needed. </td>
            </tr>
        </table>
        <br />
        <table class="table table-bordered">
            <tr>
                <td colspan="2"><u>Comment of Executive Officer </u></td>
            </tr>
            <tr>
                <td>Signature :</td>
                <td>Date:
                    </td>
            </tr>
            <tr>
                <td>Name:
                    </td>
                <td>Position:
                    </td>
            </tr>
        </table>
        <p>Note: Please attach a separate sheet to write comments and suggestions if needed. </p>

        <table class="table table-bordered ">
            <tr>
                <td colspan="3">Comment of Committee:
                    <br />
                </td>
            </tr>

            <tr>
                <th>Overall Score Achievement</th>
                <th>Performance Rating</th>
                <th>Marking based on overall score</th>
            </tr>
            <tr>
                <td>Above 115</td>
                <td>Performance Level 5</td>
                <td>
                    <div id="divExcellent1" runat="server"></div>
                </td>
            </tr>
            <tr>
                <td>Above 95 to 115</td>
                <td>Performance Level 4</td>
                <td>
                    <div id="divVeryGood1" runat="server"></div>
                </td>
            </tr>
            <tr>
                <td>Above 80 to 95</td>
                <td>Performance Level 3</td>
                <td>
                    <div id="divGood1" runat="server"></div>
                </td>
            </tr>
            <tr>
                <td>Above 65 to 80</td>
                <td>Performance Level 2</td>
                <td>
                    <div id="divFair1" runat="server"></div>
                </td>
            </tr>
            <tr>
                <td>65 and Below 65</td>
                <td>Performance Level 1</td>
                <td>
                    <div id="divPoor1" runat="server"></div>
                </td>
            </tr>
        </table>
        <br />
        <div runat="server" id="rpt"></div>
        <br />
        <h4 class="header">Instruction on actions to be initiated by Human Resource Department </h4>
        <table class="table table-bordered">
            <tr>
                <td>1. Letter Issued on 
                    <br />
                    2. Any other instructions</td>
            </tr>
        </table>

        <br />
    </form>
    <script>
        window.print();
    </script>
</body>

</html>


