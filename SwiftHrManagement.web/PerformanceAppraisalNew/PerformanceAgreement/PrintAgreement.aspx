<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrintAgreement.aspx.cs" Inherits="SwiftHrManagement.web.PerformanceAppraisalNew.PerformanceAgreement.PrintAgreement" %>

<!DOCTYPE html>
<style type="text/css">
    body {
        margin: 0px 0px 0px 0px;
        font-family: Tahoma;
        color: #000;
        zoom: 90%;
    }

    .label {
        margin-bottom: 0px;
        padding: 1px;
        color: Black;
        font-weight: normal;
        font-size: 12px;
        font-family: arial;
    }

    .prg {
        white-space: pre-line;
        margin-left: 2%;
    }

    table {
        border-collapse: collapse;
        font-family: Calibri,'Lucida Sans', 'Lucida Sans Regular', 'Lucida Grande', 'Lucida Sans Unicode', Geneva, Verdana, sans-serif;
    }

        table > tr > th, td,
        table > tr > td, th {
            padding: 10px;
            border: 1px solid #070202;
            text-align: left;
        }
</style>
<link href="../../../Content/bootstrap.css" rel="stylesheet" />
<head runat="server">
    <title>Print Agreement</title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align: center">
            <h3>
                <img src="../../../Content/images/SidLogo.png" class="img-responsive img-rounded text-center" style="height: 50px; display: block; margin-left: auto; margin-right: auto;" alt="Siddhartha Bank Limited" /></h3>

            <h3 style="width: 100%">Performance Agreement </h3>
            <h4 style="width: 100%">Fiscal Year: <asp:Label ID="lblFiscal" runat="server"></asp:Label>
            </h4>
        </div>
        <table border="1" style="width: 100%">
            <tr>
                <th>Job Holder:</th>
                <td>
                    <asp:Label ID="txtJobHolder" runat="server"></asp:Label>
                </td>
                <th>Date of joining :</th>
                <td>
                    <asp:Label ID="lbljoiningDate" runat="server"></asp:Label></td>

            </tr>
            <tr>
                <th>Functional Title: </th>
                <td>
                    <asp:Label ID="lblFuncTitle" runat="server"></asp:Label></td>
                <th>Corpoerate Title:</th>
                <td>
                    <asp:Label ID="lblCorpTitle" runat="server"></asp:Label></td>

            </tr>
            <tr>
                <th>Tenure in present Job: </th>
                <td>
                    <asp:Label ID="timeSpentInTheCurrentBranchDept" runat="server"></asp:Label></td>
                <th>Tenure in present Position:</th>
                <td>
                    <asp:Label ID="timeSpentInTheCurrentPosition" runat="server"></asp:Label></td>

            </tr>
            <tr>
                <th>Present Branch:</th>
                <td>
                    <asp:Label ID="currentBranch" runat="server"></asp:Label></td>
                <th>Present Department:</th>
                <td>
                    <asp:Label ID="currentDepartment" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <th>Supervisor: </th>
                <td>
                    <asp:Label ID="txtSuperVis" runat="server"></asp:Label></td>
                <th>Reviewing Officer:</th>
                <td>
                    <asp:Label ID="LblReviewingOfficer" runat="server"></asp:Label>

                </td>
            </tr>
            <tr>
                <th>Start Date:</th>
                <td>
                    <asp:Label ID="startDate" runat="server"></asp:Label></td>
                <th>End Date:</th>
                <td>
                    <asp:Label ID="endDate" runat="server"></asp:Label></td>
            </tr>
        </table>
        <br />
        <h4><b>A. Agreed KRAs and KPIs for performance measurement</b></h4>
        <table border="1" style="width: 100%">
            <tr>
                <th>SN</th>
                <th>Key Result Areas </th>
                <th>Key Performance Indicators</th>
                <th>Weight</th>
            </tr>
            <tbody id="kra_grid" runat="server"></tbody>
        </table>
        <p class="prg">
            <span>Note:</span>
            <ol>
                <li>KRAs for performance measurement should not be more than 10 with specific KPIs for each KRA. </li>
                <li>Total weight of all KRAs should be 100, weight of each KRA depends upon its importance and accordingly higher weight should be given to prime KRA.</li>
                <li>All Achievements will be capped at 150%. Hence the maximum score possible on the scorecard will be 150. </li>
            </ol>
        </p>
        <br />
        <h4><b>B. Following critical jobs are expected to be completed on a regular basis failure in completion will reduce the overall performance score of the appraisee </b></h4>
        <table border="1" style="width: 100%">
            <tr>
                <th>SN</th>
                <th>Objectives </th>
                <th>Deduction in overall performance score by</th>
            </tr>
            <tbody ID="criticalJobs_grid" runat="server">

            </tbody>
        </table>
        <span>Note: Total sum of <b>“Deduction points of all allocated critical jobs”</b> should not be more than 5. 
        </span>

        <h4><b>C. Performance Rating </b></h4>
        <ol>
            <li>Evaluation of the Performance Agreement at the end of the agreement period will be done on the basis of the agreed KRAs and KPIs set above with the following evaluation guidelines.
            </li>
            <table border="1" style="width: 100%">
                <tr>
                    <th>Total KRA achievement score </th>
                    <th>Performance level ratings</th>
                </tr>
                <tbody runat="server" ID="perfRatingRef_grid">

                </tbody>
            </table>
            <br />
            <li>
                In addition to the above competencies of the individual will also be evaluated by the supervisor at the time of performance review as defined in the “SOP for Performance Management System” and the overall performance will be rated accordingly 
            </li>
            <h4>
                C. Training assessment for the Year 
            </h4> 
            <br />
            <table border="1" style="width: 100%">
                <tr>
                    <th>S.N</th>
                    <th>Proposed Area</th>
                    <th>Criticality </th>
                    <th>Specify the date by when training should be provided</th>
                </tr>
                <tbody runat="server" ID="perfTranning_grid">

                </tbody>
            </table>
        </ol>
        <div class="pager">
            
        </div>

      
     
        <p class="prg">
            Criticality Rating "1, 2, 3"
            <ol>
                <li>High critical required at the earliest.</li>
                <li>Medium critical would help in better performance "Not required immediately"</li>
                <li>Good to know</li>
            </ol>
            <br />
            Note:<i>Supervisor can recommend maximum 3 trainings for the year; more than 3 trainings need to be justified.</i>
        </p>

        <table border="1" style="width: 100%">
            <tr>
                <th>Signature of Employee:</th>
                <td></td>
                <th>Signature of Immediate Supervisor: </th>
                <td></td>
            </tr>
            <tr>
                <th>Name:</th>
                <td> 
                    <asp:Label ID="SigName"  runat="server" />

                </td>
                <th>Name: </th>
                <td> <asp:Label ID="SigSuv"  runat="server" /></td>
            </tr>
            <tr>
                <th>Date:</th>
                <td> <asp:Label ID="SigNameDate"  runat="server" /></td>
                <th>Date: </th>
                <td> <asp:Label ID="SigSuvDate"  runat="server" /></td>
            </tr>
        </table>
        <br />
        <hr />
        <table border="1" style="width: 100%">
            <tr>
                <th>Signature of Reviewing Officer:</th>
                <td></td>
            </tr>
            <tr>
                <th>Name:</th>
                <td>
                    <asp:Label ID="SigRev"  runat="server" />
</td>

            </tr>
            <tr>
                <th>Date:</th>
                <td>
                    <asp:Label ID="SigRevDate"  runat="server" />
</td>
            </tr>
            <tr>
                <th>Specific comment if any: </th>
                <td>
                    <asp:Label ID="txt_disReason"  runat="server" />
                </td>
            </tr>
        </table>
        <br />
        <hr />
        <h4 class="prg">Received by HR on <i style="font-weight:700;color:#c83737"><asp:Label ID="hrdDate"  runat="server" /></i>  </h4>
        <table border="1" style="width: 100%">
            <tr>
                <th>Signature of Head of HR Department:</th>
                <td></td>
            </tr>
            <tr>
                <th>Name:</th>
                <td>  <asp:Label ID="HrdName"  runat="server" /></td>

            </tr>
            <tr>
                <th>Specific comment if any: </th>
                <td><asp:Label ID="HrdComment"  runat="server" /></td>
            </tr>
        </table>
        <p class="prg">
            (Note: <i>Appraisee and Supervisor are requested to sign in all pages of performance agreement form</i>) 
        </p>
    </form>
</body>

