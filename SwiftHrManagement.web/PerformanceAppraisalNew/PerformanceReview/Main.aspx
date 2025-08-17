<%@ Page Title="" Language="C#" MasterPageFile="~/Apprisal.Master" AutoEventWireup="true"  CodeBehind="Main.aspx.cs" Inherits="SwiftHrManagement.web.PerformanceAppraisalNew.PerformanceReview.Main" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="../../js/functions.js"></script>
    <script type="text/javascript">
        function EditFunction(id) {
            if (confirm("Do you want to edit?") == true) {
                $("#<%=hdnId1.ClientID%>").val(id);
                $("#<%=BtnEdit.ClientID%>").click();
            }

        };
        function DeleteFunction(id) {
            if (confirm("Do you want to delete?") == true)
            {
                $("#<%=hdnId1.ClientID%>").val(id);
                $("#<%=BtnDelete1.ClientID%>").click();
            }
        };
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode;
            //if (charCode > 31 && (charCode < 48 || charCode > 57))
            if (charCode > 31 && (charCode != 46 && (charCode < 48 || charCode > 57)))
                return false;
            return true;
        }
        function TCalculation(val, rval, name) {
            var value = parseFloat(val);
            var realValue = parseFloat(rval);
            if (value > realValue) {
                alert("You cannot insert more than" + realValue.toFixed(2));
                //$('input[name="CompReview' + window.row + '"]').val('0');
                $('input[name="' + name + '"]').val('0');
                return false;
            }

            var totalStr = $('input[id="CompReview"]').map(function () {
                return this.parseFloat(value).toFixed(2);
            }).get();

            var total = 0;
            $.each(totalStr, function (index, value) {
                if (value) {
                    
                    total += parseFloat(value.toFixed(2)).toFixed(2);
                }
            });
            $('#<%=lblCompTotal.ClientID%>').html(total.toFixed(2));
            return true;

        }
        function CJcalculation(val, rval, name) {
            //alert(val);
            var value = parseFloat(val).toFixed(2);
            var realValue = parseFloat(rval).toFixed(2);
            if (value > realValue) {
                alert("You cannot insert more than" + realValue.toFixed(2));
                //$('input[name="CompReview' + window.row + '"]').val('0');
                $("input[name='" + name + "']").val('0');
                return false;
            }
            var totalStr = $('input[id="CJR"]').map(function () {
                return parseFloat(this.value);
            }).get();

            var total = 0;
            $.each(totalStr, function (index, value) {
                if (value) {
                    total += parseFloat(value).toFixed(2);
                }
            });
            $('#<%=lblCJTotalObtained.ClientID%>').html(total.toFixed(2));
            return true;
        }


        function PACalculation(val, rowid, wei, rating) {
            var paValue = parseFloat(val);
            var weight = parseFloat(wei);
            var weightCon = weight * rating;

            if (paValue > weightCon) {
                alert("You cannot insert more than " + weightCon.toFixed(2));
                $('input[name="PA' + rowid + '"]').val('');
                $('input[name="V' + rowid + '"]').val('0');
                $('input[name="PS' + rowid + '"]').val('0');
                return false;
            }
            var varience = Math.round(((paValue - weight) / weight) * 1000) / 1000;
            var perScore = Math.round(((1 + parseFloat(varience)) * weight) * 1000) / 1000;

            $('input[name="V' + rowid + '"]').val(parseFloat(varience).toFixed(2));
            $('input[name="PS' + rowid + '"]').val(parseFloat(perScore).toFixed(2));
            debugger
            //var total = $('input[name="PS"]').val();
            var totalStr = $('input[id="PS"]').map(function () {
               
                return (parseFloat(this.value));
            }).get();

            //alert(totalStr);
            //var totalArray = new Array();
            //totalArray =  totalStr.toString().split(',');

            //alert(totalarray);

            var total = 0;
            $.each(totalStr, function (index, value) {
                if (value)
                {
                    debugger;
                    total = parseFloat(parseFloat(total)+ parseFloat(value)).toFixed(2);
                }

            });

            $('#<%=total.ClientID%>').html(parseFloat(total).toFixed(2));
            return true;

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
            else if (_EVENT == 5) {
                document.getElementById("<% =LoadCommentGrid.ClientID%>").click();
            }
            else if (_EVENT == 3) {
                document.getElementById("<% =LoadCompetencyGrid.ClientID%>").click();
            }
            else if (_EVENT == 4) {
                document.getElementById("<% =LoadScoreGrid.ClientID%>").click();
            }
}

function LoadGridComment(_EVENT) {
    document.getElementById("<% =universalCommentId.ClientID%>").value = _EVENT;
    if (_EVENT == 0) {
        document.getElementById("<% =LoadSupCommentGrid.ClientID%>").click();
    }
    else if (_EVENT == 1) {
        document.getElementById("<% =LoadappraiseeGrid.ClientID%>").click();
    }
    else if (_EVENT == 2) {
        document.getElementById("<% =LoadRevCommentGrid.ClientID%>").click();
    } else if (_EVENT == 3) {
        document.getElementById("<% =LoadComMemberCommentGrid.ClientID%>").click();
    }
}

    </script>
      <script  src="<%=ResolveUrl("/Theme/bower_components/jquery/dist/jquery.js") %>" ></script>
     <script src="<%=ResolveUrl("/Theme/bower_components/dist/js/bootstrap-datepicker.js")%>" ></script>
   
    <script>
        $(document).ready(function () {
            $('.datepicker').datepicker();
        })
    </script>
    <style type="text/css">
        .naveget .form-group label {
            font-size: 13px !important;
        }

        .naveget .form-inline .checkbox {
            padding-left: 30px !important;
        }

        .naveget .form-inline .form-group {
            margin-bottom: 5px;
        }

        .heading h4 {
            padding: 0;
        }
        .auto-style1 {
            width: 216px;
        }
        .auto-style2 {
            width: 116px;
        }
        .auto-style3 {
            width: 216px;
            height: 34px;
        }
        .auto-style4 {
            height: 34px;
        }
        .auto-style5 {
            width: 116px;
            height: 34px;
        }
        .auto-style6 {
            height: 33px;
        }
        .auto-style7 {
            height: 52px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <asp:HiddenField runat="server" ID="hdnId1" />
    
    <asp:Button runat="server" ID="BtnDelete1" Style="display: none" />

    <asp:Button runat="server" ID="BtnEdit" Style="display: none" />

    <div class="row">
        <div class="col-md-12">
            <section class="panel">
                <header class="panel-heading">
                    <i class="fa fa-caret-right"></i>              
                    Employee Details
                </header>
                <div class="panel-body">                           
                    <div class="form-group autocomplete-form" >
                        <label>Name Of Appraisee:<span class="errormsg">*</span></label>
                        <asp:Label ID="lblEmpName" runat="server" Font-Bold="True"></asp:Label>
                        <asp:HiddenField ID="hdnEmpName" runat="server" />
                    </div>
                    <div class="form-group">     
                    <div class="form-group row" >
                        <div class="col-md-3">  <label>Present Location:</label></div>
                        <div class="col-md-3"> <asp:TextBox ID="currentBranch" runat="server" CssClass="form-control" ReadOnly="true" ></asp:TextBox></div>
                        <div class="col-md-3"> <label>Department Name:</label></div>
                        <div class="col-md-3"><asp:TextBox ID="currentDepartment" runat="server" CssClass="form-control"  ReadOnly="true"></asp:TextBox></div>
                    </div> 
                       <div class=" form-group row">
                        <div class="col-md-3"> <label>Sub Department Name:</label></div>
                        <div class="col-md-3"><asp:TextBox ID="currSubDeptID" runat="server" CssClass="form-control"  ReadOnly="true"></asp:TextBox></div>
                        <div class="col-md-3"> <label>Functional Title:</label></div>
                        <div class="col-md-3"><asp:TextBox ID="currentFunctionalTitle" runat="server" CssClass="form-control"  ReadOnly="true"></asp:TextBox></div>
                       
                    </div>  
                       <div class="form-group row">
                        <div class="col-md-3"> <label>Corporate Designation:</label></div>
                        <div class="col-md-3"><asp:TextBox ID="currentPosition" runat="server" CssClass="form-control"  ReadOnly="true"></asp:TextBox></div>
                        <div class="col-md-3"> <label>Date of Joining at SBL:</label></div>
                        <div class="col-md-3"><asp:TextBox ID="dateOfJoining" runat="server" CssClass="form-control"  ReadOnly="true"></asp:TextBox></div>
                        
                    </div>   
                       <div class="form-group row">
                        <div class="col-md-3"> <label>Tenure in Present Job:</label></div>
                        <div class="col-md-3"><asp:TextBox ID="timeSpentInTheCurrentBranchDept" runat="server" CssClass="form-control"  ReadOnly="true"></asp:TextBox></div>
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
                        <div class="col-md-3"> <label>Performance Review effective From:</label></div>
                        <div class="col-md-3"><asp:TextBox ID="effectiveFrom" runat="server" CssClass="form-control"   ReadOnly="true"></asp:TextBox></div>
                        <div class="col-md-3"> <label>Performance Review effective To:</label></div>
                        <div class="col-md-3"><asp:TextBox ID="effectiveTo" runat="server" CssClass="form-control"   ReadOnly="true"></asp:TextBox></div>
                    </div>  
                    </div>      
                   </div>
                </section>

            <div class="panel panel-default">
                <div class="panel-body naveget">
                    <ul class="nav nav-tabs" role="tablist">
                        <li role="presentation" class="active" id="tab1" runat="server"><a href="#KRAKPIDiv"
                            aria-controls="KRA /KPI" role="tab" data-toggle="tab" onclick="LoadGridCJ('0');">KRA /KPI</a></li>
                        <li role="presentation" id="tab2" runat="server"><a href="#criticalJobs" aria-controls="Critical Jobs"
                            role="tab" data-toggle="tab" onclick="LoadGridCJ('1');">Critical Jobs</a></li>
                        <li role="presentation" id="tab3" runat="server"><a href="#PerformanceRating" aria-controls="Performance Rating"
                            role="tab" data-toggle="tab" name="Rating" onclick="LoadGridCJ('2');">Performance
                            Rating</a></li>
                        <li role="presentation" id="tab5" runat="server"><a href="#Competency" aria-controls="Competency"
                            role="tab" data-toggle="tab" name="ack" onclick="LoadGridCJ('3');">Competency</a>
                        </li>
                        <li role="presentation" id="tab6" runat="server"><a href="#Score" aria-controls="Score"
                            role="tab" data-toggle="tab" name="ack" onclick="LoadGridCJ('4');">Score</a>
                        </li>
                        <li role="presentation" id="tab4" runat="server"><a href="#supervisorcomment" aria-controls="Comments"
                            role="tab" data-toggle="tab" name="ack" onclick="LoadGridCJ('5');">Comments</a>
                        </li>

                    </ul>
                    <div class="tab-content">
                        <div id="KRAKPIDiv" class="tab-pane active" runat="server">
                            <%-- <div role="tabpanel" class="tab-pane fade in active" id="kraKpi">--%>

                            <div class="col-md-12">
                                <div class="panel panel-default">
                                    <div class="panel-heading">
                                        A. Agreed KRAs and KPIs for performance measurement
                                    </div>
                                    <div class="panel-body">
                                        <div class="table-responsive ">
                                            <table class="table table-bordered table-striped table-responsive">
                                                <thead>
                                                    <tr>
                                                        <th>SNO</th>
                                                        <th>KRA</th>
                                                        <th>Weigh<br />
                                                            tage
                                                            <br />
                                                            (%)</th>
                                                        <th>KPI</th>
                                                        <th>Weigh<br />
                                                            tage 
                                                            <br />
                                                            (%)</th>
                                                        <th>Perfo Achieve<br />
                                                            (%)</th>
                                                        <th>Remarks (Reason)*</th>
                                                        <th>Variance (%)</th>
                                                        <th>Performance Score </th>
                                                    </tr>
                                                </thead>
                                                <tbody id="kra_grid" runat="server">
                                                </tbody>
                                                <tfoot>
                                                    <tr>
                                                        <td colspan="2" align="right">Total</td>
                                                        <td>
                                                            <asp:Label runat="server" ID="kratotaltable"></asp:Label></td>
                                                        <td></td>
                                                        <td>
                                                            <asp:Label runat="server" ID="kpitotaltable"></asp:Label></td>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
                                                        <td>
                                                            <asp:Label runat="server" ID="total"></asp:Label></td>
                                                    </tr>
                                                </tfoot>
                                            </table>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-12">
                                <div class="bg-info">
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
                                <div style="margin-top: 20px; margin-bottom: 20px;">
                                    <asp:Button ID="btnSaveKRAKPI" OnClick="btnSaveKRAKPI_OnClick" CssClass="btn btn-primary"
                                        runat="server" Text="Save"></asp:Button>
                                    <asp:Button runat="server" ID="krakpiNext" CssClass="btn btn-primary" OnClick="krakpiNext_Click" Text="Next" Visible="false"></asp:Button>
                                </div>
                            </div>
                        </div>
                        <asp:Button ID="LoadKRAKPIGrid" runat="server" OnClick="LoadKRAKPIGrid_OnClick" Style="display: none;" />
                        <%--/* Critical JObs start*/--%>
                        <div id="criticalJobs" runat="server">
                            <%--<div role="tabpanel" class="tab-pane fade" id="criticalJobs">--%>
                            <div class="col-md-12">
                                <div class="panel panel-default">
                                    <div class="panel-heading">
                                        B. Following critical jobs are expected to be completed on a regular basis failure in completion will reduce the overall performance score of the appraisee 
                                 <asp:Button ID="LoadCJGrid" runat="server" OnClick="LoadCJGrid_OnClick" Style="display: none;" />
                                    </div>
                                    <div class="panel-body">
                                        <div class="table-responsive ">
                                            <table class="table table-bordered table-striped table-responsive">
                                                <thead>
                                                    <tr>
                                                        <th>SNO</th>
                                                        <th>Objectives</th>
                                                        <th>Deduction Score</th>
                                                        <th>Critical Rating</th>
                                                    </tr>
                                                </thead>
                                                <tbody id="criticalJobs_grid" runat="server">
                                                </tbody>
                                                <tfoot>
                                                    <tr>
                                                        <td colspan="2"><b>Total</b></td>
                                                        <td>
                                                            <asp:Label ID="lblCJTotal" runat="server" Text="0" Font-Bold="true"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblCJTotalObtained" runat="server" Text="0" Font-Bold="true"></asp:Label></td>
                                                    </tr>
                                                </tfoot>
                                            </table>
                                        </div>
                                    </div>
                                </div>

                            </div>
                            <div class="col-md-12">
                                <div class="bg-info">
                                    Note: Total sum of “Deduction points of all allocated critical jobs” should not
                                    be more than 5. 
                                </div>
                            </div>
                            <br />
                            <div class="col-md-12">
                                <asp:Button runat="server" ID="CriticleJobNext" Text="Save & Next" CssClass="btn btn-primary" OnClick="CriticleJobNext_Click" />&nbsp;
                        <asp:Button runat="server" ID="CriticleJobBack" Text="Back" CssClass="btn btn-primary" OnClick="CriticleJobBack_Click" />
                                <asp:Button runat="server" ID="nextCriticalJob" CssClass="btn btn-primary" OnClick="nextCriticalJob_Click" Text="Next" Visible="false"></asp:Button>

                            </div>
                        </div>
                        <%-- third Performance Rating --%>
                        <div id="PerformanceRating" runat="server">
                            <%-- <div role="tabpanel" class="tab-pane fade" id="Performance">--%>
                            <div class="col-md-12">
                                <div class="panel panel-default" hidden="hidden">
                                    <div class="panel-heading">
                                        C. Performance Rating 
                                    </div>
                                    <div class="panel-body">
                                        <div class="table-responsive ">
                                            <table class="table table-bordered table-striped">
                                                <thead>
                                                    <tr>
                                                        <th>Total KRA Achievement Score </th>
                                                        <th>Performance Level Ratings</th>
                                                        <th hidden="hidden">Percenatge of Increment</th>
                                                        <%--<th>Please mark based on KRA achievement score</th>--%>
                                                    </tr>
                                                </thead>
                                                <tbody id="perfRatingRef_grid" runat="server">
                                                </tbody>
                                            </table>
                                        </div>
                                    </div>
                                </div>
                            </div>


                            <div class="col-md-12">
                                <div class="panel panel-default">
                                    <div class="panel-heading">
                                        C. Details of successfully completed trainings in last review period from
                                        <asp:Label ID="lblApprisalStartDate" BackColor="#c0c0c0" runat="server" Text="2016-01-01"></asp:Label>
                                        to
                                        <asp:Label ID="lblApprisalEndDate" runat="server" BackColor="#c0c0c0" Text="2016-07-31"></asp:Label>
                                    </div>
                                    <div class="panel-body">
                                        <div class="table-responsive ">
                                            <table class="table table-bordered table-striped">
                                                <thead>
                                                    <tr>
                                                        <th>SNO</th>
                                                        <th>Proposed Area</th>
                                                        <th>Training Period</th>
                                                        <th>Performance After Training</th>
                                                    </tr>
                                                </thead>
                                                <tbody id="perfTranning_grid" runat="server">
                                                </tbody>
                                            </table>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-12">
                                <div class="bg-info">
                                    Note: Please rate the Appraisee performance in proposed areas after training in
                                    1 to 5 scale (“Above 4 Excellent”, “Above 3 to 4 Very Good”, “Above 2.5 to 3 Good”,
                                    “Above 2 to 2.5 Acceptable”, “Below 2 Substandard”).  0 Scale for not attend Training.
                                </div>
                            </div>
                            <div class="col-md-12">
                                <header class="heading">
                                  <h4> Aknowledgement</h4>
                             </header>
                                <asp:CheckBox ID="chkAknowledgement" runat="server"></asp:CheckBox>
                                I Acknowledge and agree to the all the points mentioned in this agreement.(By&nbsp; Supervisor)
                               <div style="margin-top: 20px; margin-bottom: 20px;">
                                   <asp:Button ID="btnPerformanceRatingSave" OnClick="btnPerformanceRatingSave_OnClick" CssClass="btn btn-primary" runat="server" Text="Save & Next"></asp:Button>&nbsp;
                                   <asp:Button runat="server" ID="PerformanceRatingBack" Text="Back" CssClass="btn btn-primary" OnClick="PerformanceRatingBack_Click" />
                                   <asp:Button runat="server" ID="nextPerformanceRating" CssClass="btn btn-primary" OnClick="nextPerformanceRating_Click" Text="Next" Visible="false"></asp:Button>

                               </div>
                            </div>
                        </div>
                        <asp:HiddenField ID="hdnKraAchieveScore" runat="server" />
                        <asp:Button ID="LoadRatingGrid" runat="server" OnClick="LoadRatingGrid_Click" Style="display: none;" />
                        <%-- Performance Rating end --%>

                        <%-- Competency Review --%>
                        <div id="Competency" runat="server">


                            <div class="col-md-12">
                                <div class="panel panel-default">
                                    <div class="panel-heading">
                                        D. Competency Review
                                    &nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;<asp:Label ID="PRMessage" runat="server" Text="** Please, Acknowledge Performance Rating First.**" ForeColor="Red" Font-Size="Smaller" Visible="false"></asp:Label>
                                    </div>
                                    <div class="panel-body">

                                        <div class="table-responsive ">
                                            <table class="table table-bordered table-striped">
                                                <thead>
                                                    <tr>
                                                        <th rowspan="2" width="5%">S. No</th>
                                                        <th rowspan="2" width="60%">Competencies(Technical &amp; Behavioral Skills)</th>
                                                        <th nowrap="nowrap" style="text-align: center;" width="15%">Level and Weights</th>
                                                        <th width="20%">Rating Score</th>
                                                    </tr>
                                                    <tr>
                                                        <th style="text-align: center;display:none">
                                                            <asp:Label ID="lblLevelHeader" runat="server" Visible="False"></asp:Label></th>
                                                    </tr>
                                                </thead>
                                                <tbody id="competencies_grid" runat="server">
                                                </tbody>
                                                <tfoot>
                                                    <tr>
                                                        <td class="auto-style6"></td>
                                                        <td colspan="2" class="auto-style6"><b>Total Score</b></td>
                                                        <td class="auto-style6">
                                                            <asp:Label ID="lblCompTotal" runat="server" Font-Bold="true"></asp:Label></td>
                                                    </tr>
                                                </tfoot>
                                            </table>
                                        </div>
                                        <div style="margin-top: 20px; margin-bottom: 20px;">
                                            <asp:Button ID="BtnCompReviewSave" OnClick="BtnCompReviewSave_Click" CssClass="btn btn-primary"
                                                runat="server" Text="Save & Next"></asp:Button>
                                            &nbsp;
                                     <asp:Button runat="server" ID="CompReviewBack" Text="Back" CssClass="btn btn-primary" OnClick="CompReviewBack_Click" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <asp:Button ID="LoadCompetencyGrid" runat="server" OnClick="LoadCompetencyGrid_Click" Style="display: none;" />
                        <%-- Score --%>
                        <div id="Score" runat="server">

                            <div class="col-md-12">
                                <div class="panel panel-default">
                                    <div class="panel-heading">
                                        E. Performance Score Calculation
                                    </div>
                                    <div class="panel-body">
                                        <div class="table-responsive ">
                                            <table class="table table-bordered table-striped">
                                                <thead>
                                                    <tr>
                                                        <th width="6%">S. No.</th>
                                                        <th width="50%">KRA</th>
                                                        <th width="22%">Weight</th>
                                                        <th width="22%">Score</th>
                                                    </tr>
                                                </thead>
                                                <tbody id="ScoreKpi_grid" runat="server">
                                                </tbody>
                                                <tfoot>
                                                    <tr>
                                                        <td colspan="2"><b>Total Score</b></td>
                                                        <td>
                                                            <asp:Label ID="lblWeightKpiTotal" runat="server" Font-Bold="true"></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="lblScoreKpiTotal" runat="server" Font-Bold="true"></asp:Label></td>
                                                    </tr>
                                                </tfoot>

                                            </table>
                                        </div>
                                        <div class="table-responsive ">
                                            <table class="table table-bordered table-striped">
                                                <thead>
                                                    <tr>
                                                        <th width="6%" class="auto-style7">S. No.</th>
                                                        <th width="50%" class="auto-style7">Competency</th>
                                                        <th width="22%" class="auto-style7">Weight</th>
                                                        <th width="22%" class="auto-style7">Score</th>
                                                    </tr>
                                                </thead>
                                                <tbody id="ScoreComp_grid" runat="server">
                                                </tbody>
                                                <tfoot>
                                                    <tr>
                                                        <%--<td colspan="2" style="text-align: center;"><b>Total Score</b></td>--%>
                                                        <td colspan="2"><b>Total Score</b></td>
                                                        <td>
                                                            <asp:Label ID="lblWeightCompTotal" runat="server" Font-Bold="true"></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="lblScoreCompTotal" runat="server" Font-Bold="true"></asp:Label></td>
                                                    </tr>
                                                </tfoot>
                                            </table>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-12">
                                <header class="heading">
                             <h4>Overall Performance Score:</h4>
                            </header>
                                <div class="table-responsive ">
                                    <table class="table table-bordered table-striped">
                                        <thead>
                                            <tr>
                                                <th width="6%">S.No</th>
                                                <th width="34%">Dimensions</th>
                                                <th width="20%">Weight As per level</th>
                                                <th width="20%">Total Score Achieved</th>
                                                <th width="20%">Total Weighted</th>
                                            </tr>
                                        </thead>
                                        <tr>
                                            <td>A</td>
                                            <td>Total KRAs Score</td>
                                            <td>
                                                <asp:Label ID="lblKraWeightAsPerLevel" runat="server"></asp:Label></td>
                                            <td>
                                                <asp:Label ID="lblTotalKraScored" runat="server"></asp:Label></td>
                                            <td>
                                                <asp:Label ID="lblTotalKraWeighted" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td>B</td>
                                            <td>Total Competencies Score</td>
                                            <td>
                                                <asp:Label ID="lblCompWeightAsPerLevel" runat="server"></asp:Label></td>
                                            <td>
                                                <asp:Label ID="lblTotalCompScored" runat="server"></asp:Label></td>
                                            <td>
                                                <asp:Label ID="lblTotalCompWeighted" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td colspan="4"><b>Overall Performance Score</b></td>
                                            <td>
                                                <asp:Label ID="lblOverallPerfScore" runat="server" Font-Bold="true"></asp:Label></td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                            <div class="col-md-12">
                                <div class="table-responsive ">
                                    <table class="table table-bordered table-striped">
                                        <tr>
                                            <th class="auto-style3" style="text-align: center">Overall Score Achievement</th>
                                            <th class="auto-style4" style="text-align: center">Performance Rating</th>
                                            <th class="auto-style5" style="text-align: center">Increment Rate(%)</th>
                                            <th class="auto-style4" style="text-align: center">Based on Overall Score</th>
                                        </tr>
                                        <tr>
                                            
                                            <td class="auto-style1 range" style="text-align: center">
                                                <div class="range" runat="server" id="rangeDiv5">Above 115</div>
                                            </td>
                                            
                                            <td class="level" runat="server" id="levelDiv5" style="text-align: center">Performance Level 5</td>
                                                <td class="auto-style2" style="text-align: center" runat="server" id="percentDiv5">10</td>

                                            <td style="text-align: center">
                                                <div id="divExcellent" runat="server"></div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style1 range" style="text-align: center">
                                                <div class="range" runat="server" id="rangeDiv4">Above 95 to 115</div>
                                            </td>
                                            <td class="level" runat="server" id="levelDiv4" style="text-align: center">Performance Level 4</td>
                                            <td class="auto-style2" style="text-align: center" runat="server" id="percentDiv4">8</td>

                                            <td style="text-align: center">
                                                <div id="divVeryGood" runat="server"></div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style1 range" style="text-align: center">
                                                <div class="range" runat="server" id="rangeDiv3">Above 80 to 95</div>
                                            </td>
                                            <td class="level" runat="server" id="levelDiv3" style="text-align: center">Performance Level 3</td>
                                                <td class="auto-style2" style="text-align: center" runat="server" id="percentDiv3">7</td>

                                            <td style="text-align: center">
                                                <div id="divGood" runat="server"></div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style1 range" style="text-align: center">
                                                <div class="range" runat="server" id="rangeDiv2">Above 65 to 80</div>
                                            </td>
                                            <td class="level" runat="server" id="levelDiv2" style="text-align: center">Performance Level 2</td>                                            
                                            <td class="auto-style2" style="text-align: center" runat="server" id="percentDiv2">6</td>

                                            <td style="text-align: center">
                                                <div id="divFair" runat="server"></div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style1 range" style="text-align: center">
                                                <div class="range" runat="server" id="rangeDiv1">65 and Below 65</div>
                                            </td>
                                            <td class="level" runat="server" id="levelDiv1" style="text-align: center">Performance Level 1</td>
                                                <td class="auto-style2" style="text-align: center" runat="server" id="percentDiv1">1.67</td>

                                            <td style="text-align: center">
                                                <div id="divPoor" runat="server"></div>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <asp:Button runat="server" ID="LoadScoreNext" Text="Next" CssClass="btn btn-primary" OnClick="LoadScoreNext_Click" />&nbsp;
                            <asp:Button runat="server" ID="LoadScoreBack" Text="Back" CssClass="btn btn-primary" OnClick="LoadScoreBack_Click" />
                            </div>

                        </div>
                        <asp:Button ID="LoadScoreGrid" runat="server" OnClick="LoadScoreGrid_Click" Style="display: none;" />

                        <%-- comment |Start --%>
                        <div id="Comments" runat="server">
                            <%-- <div role="tabpanel" class="tab-pane fade naveget" id="Comments">--%>
                            <ul class="nav nav-tabs">
                                <li role="presentation" id="sComment" runat="server" class="active"><a href="#supervisorcomment" aria-controls="Supervisor"
                                    role="tab" data-toggle="tab" onclick="LoadGridComment('0')">Supervisor Comment</a></li>
                                <li role="presentation" id="Acomment" runat="server"><a href="#appraisee" aria-controls="appraisee"
                                    role="tab" data-toggle="tab" onclick="LoadGridComment('1')">Appraisee  Comment</a></li>
                                <li role="presentation" id="rComment" runat="server"><a href="#reviewercomment" aria-controls="Reviewer"
                                    role="tab" data-toggle="tab" onclick="LoadGridComment('2')">Reviewer Comment</a></li>
                                <li role="presentation" id="cMComment" runat="server"><a href="#comitteemembercomment" aria-controls="Performance"
                                    role="tab" data-toggle="tab" onclick="LoadGridComment('3')">Comittee Member Comment</a></li>
                            </ul>

                            <div class="tab-content">
                                <div role="tabpanel" class="tab-pane active" id="supervisorcomment" runat="server">
                                    <div class="panel panel-default">
                                        <div class="panel-heading">
                                            F. Supervisor Comments
                                        </div>
                                        <div class="panel-body">
                                            <h5>Critical Comments by the Supervisor</h5>
                                            <div class="form-group">
                                                <div class="col-md-12">
                                                    <label>
                                                        1. What are the strong points of the appraisee in relation to various critical
                                                job dimensions mention above?</label>
                                                    <asp:TextBox ID="txtan1" runat="server" CssClass="form-control" AutoComplete="Off" TextMode="MultiLine"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <div class="col-md-12">
                                                    <label>
                                                        2. What are the weak points of the appraisee in relation to various critical
                                                job dimensions mention above?</label>
                                                    <asp:TextBox ID="txtan2" runat="server" CssClass="form-control" AutoComplete="Off"
                                                        TextMode="MultiLine"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <div class="col-md-12">
                                                    <label>
                                                        3. If the employee has demonstrated any outstanding performance or work of supervisor
                                                order indicate that.</label>
                                                    <asp:TextBox ID="txtan3" runat="server" CssClass="form-control" AutoComplete="Off"
                                                        TextMode="MultiLine"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <div class="col-md-12">
                                                    <label>
                                                        4. If the performance of the employee is below the minimum rating, indicate the
                                                areas and  make a job improvement plan for the employees. Mention the date of submission
                                                of the plan to Human Resource Department.
                                                    </label>
                                                    <asp:TextBox ID="txtan4" runat="server" CssClass="form-control" AutoComplete="Off"
                                                        TextMode="MultiLine"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <div class="col-md-12">
                                                    <label>
                                                        5. If the employee is not yet conformed on the job, indicate whether his/her
                                                probationary period should be extended (Give reasons).
                                                    </label>
                                                    <asp:TextBox ID="txtan5" runat="server" CssClass="form-control" AutoComplete="Off"
                                                        TextMode="MultiLine"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <div class="col-md-12">
                                                    <header class="heading">            
                                              <h4>Agreement</h4>
                                            </header>
                                                    <asp:CheckBox ID="chkIagreeSupervisorComment" runat="server"></asp:CheckBox>
                                                    I Acknowledge and agree to the all the points mentioned in this agreement.
                                                    (By Supervisor)
                                                    <br />
                                                    <br />
                                                    <asp:Label runat="server" ID="SupAckDate" CssClass="text-bold text-blue"></asp:Label>
                                                <br /><br />
                                                <br /><br />
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <div class="col-md-12 ">
                                                    <label>Remarks </label>
                                                    <asp:TextBox ID="SupRemarks" runat="server" CssClass="form-control" AutoComplete="Off"
                                                        TextMode="MultiLine"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <div class="col-md-12">
                                                    <div class="bg-info">
                                                        Note: Should be done by Supervisor. 
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <div class="col-md-12">
                                                    <div style="margin-top: 20px; margin-bottom: 20px;">
                                                        <asp:Button ID="btnSupervisorComment" OnClick="btnSupervisorComment_OnClick" CssClass="btn btn-primary"
                                                            runat="server" Text="Save"></asp:Button>
                                                    </div>
                                                </div>
                                            </div>
                                            <asp:Button ID="LoadSupCommentGrid" runat="server" OnClick="LoadSupCommentGrid_OnClick"
                                                Style="display: none;" />

                                        </div>
                                    </div>
                                </div>
                                <div role="tabpanel" class="tab-pane appraisee" id="appraisee" runat="server">
                                    <div class="panel panel-default">
                                        <div class="panel-heading">
                                            Appraisee  Comments
                                        </div>
                                        <div class="panel-body">
                                            <div class="form-group">
                                                <div class="form-inline">
                                                    <div class="checkbox">
                                                        <label>
                                                            <asp:CheckBox ID="Chk_Apr_agree" runat="server" Text=" I Agree the points mentioned in the above."></asp:CheckBox>
                                                        </label>

                                                         <br />
                                                         <br />
                                                  <asp:Label runat="server" ID="ApreeAckDate" CssClass="text-bold text-blue"></asp:Label>
                                           <br />
                                           
                                                    </div>
                                                   
                                                </div>
                                                
                                                 </div>
                                            <br />
                                            <div class="form-group">
                                                <div class="form-inline">
                                                    <div class="checkbox">
                                                        <label>
                                                            <asp:CheckBox ID="Chk_Disagree_appraisee" runat="server" Text=" Disagree (Please Specify reason of disagree)"></asp:CheckBox>
                                                        </label>
                                                    </div>

                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <div class="col-md-12">
                                                    <label>Disagree of Reason(*)</label>
                                                    <asp:TextBox ID="Txt_DisagreeReason" runat="server" CssClass="form-control" AutoComplete="Off" Width="400px" Height="100px" placeholder="Please Specify reason of disagree "></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="clearfix"></div>
                                            <div class="form-group">
                                                <div class="col-md-12 ">

                                                    <br />
                                                    <asp:Button ID="btn_Appraisee_Save" OnClick="btnSaveAppraisee_OnClick" CssClass="btn btn-primary" runat="server" Text="Save"></asp:Button>
                                                </div>
                                            </div>
                                            <asp:Button ID="LoadappraiseeGrid" runat="server" OnClick="LoadappraiseeGrid_OnClick"
                                                Style="display: none;"></asp:Button>
                                        </div>
                                    </div>
                                </div>
                                <div role="tabpanel" class="tab-pane reviwer" id="reviewercomment" runat="server">
                                    <div class="panel panel-default">
                                        <div class="panel-heading">
                                            H. Reviewing Officer Comments
                                        </div>
                                        <div class="panel-body">
                                            <div class="form-group">
                                                <div class="col-md-12">
                                                    <label>Comment of Reviewing Officer</label>
                                                    <asp:TextBox ID="txtRevOfficer" runat="server" CssClass="form-control" AutoComplete="Off" TextMode="MultiLine"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <div class="col-md-12">
                                                    <label>
                                                        If Appraisee is most suitable for any other position please specify with the
                                                reason for suitability........</label>
                                                    <div class="form-group">
                                                        <asp:TextBox ID="txtRevReason" runat="server" CssClass="form-control" AutoComplete="Off" TextMode="MultiLine"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="form-group">
                                                    <div class="form-inline">
                                                        <div class="checkbox">
                                                            <label>
                                                                <asp:CheckBox ID="chkSales" runat="server" Text=" Sales (Please Specify the area of sales)"></asp:CheckBox>
                                                            </label>
                                                        </div>
                                                        <div class="form-group">
                                                            <asp:TextBox ID="txtSales" runat="server" CssClass="form-control"></asp:TextBox>
                                                        </div>
                                                        <div class="checkbox">
                                                            <label>
                                                                <asp:CheckBox ID="chkOperation" runat="server" Text=" Operations"></asp:CheckBox>
                                                            </label>
                                                        </div>
                                                        <div class="checkbox">
                                                            <label>
                                                                <asp:CheckBox ID="chkHR" runat="server" Text=" Human Resource"></asp:CheckBox></label>
                                                        </div>
                                                        <div class="checkbox">
                                                            <label>
                                                                <asp:CheckBox ID="chkBackOffice" runat="server" Text=" Back Office"></asp:CheckBox></label>
                                                        </div>
                                                    </div>

                                                    <div class="form-inline">
                                                        <div class="checkbox">
                                                            <label>
                                                                <asp:CheckBox ID="chkMarketing" runat="server" Text=" Marketing"></asp:CheckBox></label>
                                                        </div>
                                                        <div class="checkbox">
                                                            <label>
                                                                <asp:CheckBox ID="chkAdministration" runat="server" Text=" Administration"></asp:CheckBox></label>
                                                        </div>
                                                        <div class="checkbox">
                                                            <label>
                                                                <asp:CheckBox ID="chkFinance" runat="server" Text=" Finance"></asp:CheckBox></label>
                                                        </div>
                                                        <div class="checkbox">
                                                            <label>
                                                                <asp:CheckBox ID="chkOthers" runat="server" Text=" Others (Please Specify)"></asp:CheckBox></label>
                                                        </div>
                                                        <div class="form-group">
                                                            <asp:TextBox ID="txtOthers" runat="server" CssClass="form-control"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <div class="col-md-12">
                                                    <header class="heading">            
                                              <h4>Agreement</h4>
                                                <hr />
                                            </header>
                                                </div>
                                                <div class="col-md-12">
                                                    <asp:CheckBox ID="chkRevCommentAgree" runat="server"></asp:CheckBox>
                                                    I Agree the points mentioned in the above.
                                                    <br />
                                                    <br />
                                                    <asp:Label runat="server" ID="RevAckDate" CssClass="text-bold text-blue margin-bottom"></asp:Label>
                                                       <br />   <br />
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <div class="col-md-12 ">
                                                    <label>Remarks<small>(Reason of Disagreement)</small>  </label>
                                                    <asp:TextBox ID="txtRevCommentReason" runat="server" CssClass="form-control" AutoComplete="Off" TextMode="MultiLine"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <div class="col-md-12">
                                                    <div class="bg-info">
                                                        Note: Should be done by Reviewing Officer. 
                                                    </div>
                                                    <asp:Button ID="btnDisagree" OnClick="btnDisagree_OnClick" CssClass="btn btn-primary"
                                                        runat="server" Text="Disagree"></asp:Button>
                                                    <asp:Button ID="btnSaveRevComment" OnClick="btnSaveRevComment_OnClick" CssClass="btn btn-primary"
                                                        runat="server" Text="Save"></asp:Button>
                                                </div>
                                            </div>
                                            <asp:Button ID="LoadRevCommentGrid" runat="server" OnClick="LoadRevCommentGrid_OnClick"
                                                Style="display: none;"></asp:Button>
                                        </div>
                                    </div>
                                </div>
                                <div role="tabpanel" class="tab-pane" id="comitteemembercomment" runat="server">
                                    <div class="panel panel-default">
                                        <div class="panel-heading">
                                            I. Executive Officer Comments
                                        </div>
                                        <div class="panel-body">
                                            <div class="form-group">
                                                <div class="col-md-12">
                                                    <label>Comment of Executive Officer</label>
                                                    <asp:TextBox ID="txtCEO" runat="server" CssClass="form-control" AutoComplete="Off" TextMode="MultiLine"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <div class="col-md-12">
                                                    <asp:Button ID="btnSaveCEOComment" CssClass="btn btn-primary" OnClick="btnSaveCEOComment_OnClick"
                                                        runat="server" Text="Save" Visible="False"></asp:Button>
                                                </div>
                                            </div>

                                        </div>
                                    </div>

                                    <div class="panel panel-default">
                                        <div class="panel-heading">
                                            J. Comment of Comittee
                                        </div>
                                        <div class="panel-body">
                                            
                                            <div class="form-group">
                                                <div class="col-md-12">
                                                    <div class="table-responsive ">
                                                        <table class="table table-bordered table-striped">
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
                                                    </div>

                                                </div>
                                            </div>
                                            <%-- <div class="col-md-12">
                                        <div class="table-responsive ">
                                            <table class="table table-bordered table-striped">
                                                <tr>
                                                    <th>S. No.</th>
                                                    <th>Committee Member Name</th>
                                                    <th>Functional Title</th>
                                                </tr>
                                                <tr>
                                                    <td></td>
                                                    <td></td>
                                                    <td></td>

                                                </tr>
                                                <tr>
                                                    <td></td>
                                                    <td></td>
                                                    <td></td>
                                                </tr>
                                            </table>
                                        </div>
                                    </div>--%>
                                            <div class="col-md-12">
                                                <div id="rpt" runat="server">
                                                </div>
                                            </div>


                                        <div class="panel-body">
                                            
                                        
                                            <div class="form-group">
                                                <div class="row">
                                                    
                                                <div class="col-md-9">
                                                    <label class="col-lg-3 control-label">Comment of Committee</label>
                                                    <div class="col-md-9">
                                                            <div class="form-group">
                                                               <asp:TextBox ID="txtComMember" runat="server" CssClass="form-control" AutoComplete="Off" TextMode="MultiLine"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    
                                                </div>
                                          
                                                    <div class="col-md-9">
                                                        <label class="col-lg-3 control-label">
                                                            1. Letter issued on  </label>
                                                        <div class="col-md-9">
                                                            <div class="form-group">
                                                                <asp:TextBox ID="txtIssueddate" runat="server" CssClass="form-control datepicker"></asp:TextBox>
                                                              <%--  <cc1:CalendarExtender ID="txtIssueddate_CalendarExtender"
                                                                    runat="server" Enabled="True" TargetControlID="txtIssueddate">
                                                                </cc1:CalendarExtender>--%>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-9">
                                                        <label class="col-md-3 control-label">
                                                            2. Any other instructions:
                                                        </label>
                                                        <div class="col-md-9">
                                                            <div class="form-group">
                                                                <asp:TextBox ID="txtInstructions" runat="server" CssClass="form-control" Width="100%" TextMode="MultiLine">
                                                                </asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="form-group">
                                                <div class="col-md-12">
                                                    <header class="heading">            
                                              <h4>Agreement</h4>
                                                <hr />
                                            </header>
                                                </div>
                                                <div class="col-md-6">
                                                    <asp:CheckBox ID="chkComMemberAgree" runat="server"></asp:CheckBox>
                                                    I Agree the points mentioned in the above.
                                                </div>
                                                <div class="col-md-6">
                                                    <asp:CheckBox ID="chkFreeze" runat="server"></asp:CheckBox>
                                                    Freeze
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <div class="col-md-12 ">
                                                    <label>Remarks </label>
                                                    <asp:TextBox ID="txtComMemberRemark" runat="server" CssClass="form-control" AutoComplete="Off" TextMode="MultiLine"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <div class="col-md-12">
                                                    <div class="bg-info">
                                                        Note: Should be done by Reviewing Comittee. 
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <div class="col-md-12">

                                                    <asp:Button ID="btnSaveComMember" CssClass="btn btn-primary" OnClick="btnSaveComMember_OnClick" runat="server" Text="Save"></asp:Button>
                                                    <asp:Button ID="btnEditComment" CssClass="btn btn-primary" runat="server" Text="Update" OnClick="btnEditComment_Click" Visible="false"></asp:Button>
                                                </div>
                                            </div>
                                        </div>
                                    </div>


                                    <asp:Button ID="LoadComMemberCommentGrid" runat="server" OnClick="LoadComMemberCommentGrid_OnClick"
                                        Style="display: none;" />
                                </div>

                            </div>
                            <asp:Button ID="LoadCommentGrid" runat="server" OnClick="LoadCommentGrid_OnClick" Style="display: none;" />
                            &nbsp;
                            <div class="col-md-6">
                                <div class="col-md-6">
                                    <asp:Button runat="server" ID="CommentsBack" CssClass="btn btn-primary" Text="Back" OnClick="CommentsBack_Click" Visible="false" />
                                </div>
                            </div>
                        </div>

                    </div>
                </div>

            </div>
        </div>
    </div>

    <asp:HiddenField ID="universalCommentId" runat="server" Value="0" />
    <asp:HiddenField ID="universalId" runat="server" Value="0" />
    <asp:HiddenField runat="server" ID="hdnReviewAgreedByReviewer" Value="0" />
    <asp:HiddenField runat="server" ID="hdnDisagreedByReviewer" Value="0" />
    <asp:HiddenField runat="server" ID="hdnReviewerId" />  
    <asp:HiddenField runat="server" ID="hdnSupervisorId" />

</asp:Content>
