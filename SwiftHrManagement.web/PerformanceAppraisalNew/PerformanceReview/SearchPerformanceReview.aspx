<%@ Page Title="" Language="C#" MasterPageFile="~/Apprisal.Master" AutoEventWireup="true" CodeBehind="SearchPerformanceReview.aspx.cs" Inherits="SwiftHrManagement.web.PerformanceAppraisalNew.PerformanceReview.SearchPerformanceReview" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


    <script src="/Angular/angular.js"></script>
    <script src="/Angular/helper/dirPagination.js"></script>
    <script src="/Angular/Module/ReviewModule.js"></script>
    <script src="/Angular/Service/JournalServices.js"></script>
    <script src="../../Angular/Controller/PerformanceReview.js"></script>
    <%--  <script type="text/javascript" language="JavaScript" src="../../calendar/calendar_us.js"></script>
    <link rel="stylesheet" href="../../calendar/calendar.css" />
    <script type="text/javascript" src="../../ui/js/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../ui/js/jquery-ui-1.10.3.min.js"></script>
    <script type="text/javascript" language="javascript">
        $(function () {
            $("#datepicker").datepicker();
        });
        $(f 1yukjl;
        =/-unction () {
            $("#datepicker2").datepicker();
        });
        function submit_form() {
            var btn = document.getElementById("<%=btnHidden.ClientID %>");
            if (btn != null)
                btn.click();
        }

        function nav(page) {
            var hdd = document.getElementById("hdd_curr_page");
            if (hdd != null)
                hdd.value = page;

            submit_form();
        }

        function newTableToggle(idTD, idImg) {
            var td = document.getElementById(idTD);
            var img = document.getElementById(idImg);
            if (td != null && img != null) {
                var isHidden = td.style.display == "none" ? true : false;
                img.src = isHidden ? "/images/icon_hide.gif" : "/images/icon_show.gif";
                img.alt = isHidden ? "Hide" : "Show";
                td.style.display = isHidden ? "" : "none";
            }
        }

        var POP;
        function pop(Emp,id)
        {
           window.open('/PerformanceAppraisalNew/PerformanceReview/ApprisalPrint.aspx?empId='+Emp+'&appId='+id, 'ApprisalPrint', "width="+screen.availWidth+",height="+screen.availHeight);
            return false;
            
        }

    --%>
    <%--  printPdf = function (url) {
        var iframe = this._printIframe;
        if (!this._printIframe) {
            iframe = this._printIframe = document.createElement('iframe');
            document.body.appendChild(iframe);

            iframe.style.display = 'none';
            iframe.onload = function () {
                setTimeout(function () {
                    iframe.focus();
                    iframe.contentWindow.print();
                }, 1);
            };
        }

        iframe.src = url;
        return false;
    }
    </script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <%--<div class="row">
        <div class="col-lg-12 col-sm-12">
            <section class="panel">
            <header class="panel-heading">
                 <i class="fa fa-caret-right" aria-hidden="true"></i> 
                Performance Review Search
            </header>
            <div class="panel-body">
                <div class="row">
                    <div class="col-md-12 col-sm-12">
                         <section class="panel">
                        <div class="panel-body">
                            <div id="rpt" runat="server">	
                                
                            </div>   
                            <asp:Button ID="btnHidden" runat="server" OnClick="btnHidden_Click" Style="display: none" />
                        </div>
                    </section>
                    </div>
                </div>
            </div>
        </section>
            <div class="panel">
                <div class="panel-body">
                    <b style="margin-bottom: 10px;">Status in Performance Review (PR) except Disagree</b>
                    <br />
                    <ol>
                        <li>Reviewed by Supervisor (PR Reviewed and comments by Supervisor)</li>
                        <li>Agreed by Appraisee (PR Agreed by Appraisee)</li>
                        <li>Agreed by Reviewer (PR Agreed and comments by Reviewing Officer)</li>
                        <li>Reviewed by Committee members (PR Reviewed and comments by Reviewing Committee members)</li>
                    </ol>
                </div>
            </div>
        </div>--%>


    <div ng-app="ReviewModule">
        <div ng-controller="PerformanceReviewCtrl">

            <div class="panel panel-success">


                <div class="panel-heading">
                    <b>Performnce Review Search</b>

                </div>
                <div class="panel-body ">

                    <div class="row">
                        <div class="col-md-3 form-group">
                            <label>Apprisal Status</label>
                            <select class="form-control select" ng-model="Search.Status" ng-options="item.Text for item in ApprisalList track by item.Value">
                                <option value="" disabled="disabled">Status</option>
                            </select>

                        </div>
                        <div class="col-md-3 form-group">
                            <label>Fiscal Year</label>
                            <select ng-model="Search.FiscalYear" class="form-control select" ng-options="item.Text for item in FiscalList track by item.Value" required="required">
                                <option value="" disabled="disabled">Fiscal Year</option>
                            </select>

                        </div>
                        <%-- <div class="col-md-3 form-group">
                        <label>Employee Name</label>
                        <select ng-model="Search.EmpId" class="form-control select" ng-options="item.Text for item in EmployeeList track by item.Value" >
                            <option value="" disabled="disabled">Employee Name</option>
                        </select>

                    </div>--%>
                        <div class="col-md-3 form-group">
                            <br />
                            <button ng-click="FilterData(Search)" class="btn btn-primary btn-sm form-group" type="button"><i class="fa fa-search"></i>Search</button>
                            <%-- <button ng-click="Reset()" class="btn btn-default btn-sm form-group"><i class="fa fa-eraser"></i> Reset</button>--%>
                        </div>
                        <div class="col-md-6 form-group">
                            <text class="text-danger"> {{ErrorMgs}}</text>
                        </div>
                    </div>

                </div>

            </div>

            <div class="panel panel-success">


                <div class="panel-heading">
                    <b>Performance Review List</b>

                </div>

                <div class="panel-body  table-responsive">
                    <table class="table table-striped table-bordered" style="overflow-x: scroll">

                        <thead>
                            <tr style="background: #1982ac; color: #fff">
                               
                                <th>Appraisee Name
                                </th>

                                <th>From Date
                                </th>
                                <th>End Date
                                </th>
                                <th>Supervisor </th>
                                <th>Reviewer  </th>
                                <th>Status
                                </th>
                                <th>Fiscal Year
                                </th>


                                <th style="width:15% !important">View/Print</th>
                            </tr>
                            <tr>

                             
                                <th>
                                    <input type="text" ng-model="EmpName"  placeholder="Search Name" class="input-sm" />
                                </th>

                                <th></th>
                                <th></th>
                                 <th><input type="text" ng-model="Supervisor"  placeholder="Search Supervisor" class="input-sm " /> </th>
                                <th><input type="text" ng-model="Reviewer" placeholder="Search Reviewer" class="input-sm" />  </th>
                                <th>
                                    <input type="text" ng-model="status"  placeholder="Search status" class="input-sm" />
                                </th>
                                <th></th>


                                <th></th>
                            </tr>
                        </thead>


                        <tbody ng-show="!loading">
                            <tr>
                                <td colspan="8">
                                    <div class="overlay" style="text-align: center">
                                        Please Wait.. 
                                    </div>
                                </td>
                            </tr>

                        </tbody>
                        <tbody ng-show="loading">
                            <tr dir-paginate="item in PerformanceReviewList|filter:{AppriseeName: EmpName,Status:status,Supervisor:Supervisor,Reviewer:Reviewer}| itemsPerPage:50">
                               <td>{{item.AppriseeName}}</td>
                                <td>{{item.StartDate|date:'dd-MM-yyyy'}}</td>
                                <td>{{item.EndDate|date:'dd-MM-yyyy'}}</td>                               
                                <td>{{item.Supervisor}}</td>
                                <td>{{item.Reviewer}}</td>
                                 <td>{{item.Status}}</td>
                                <td>{{item.Fiscalyear}}</td>
                                <td>
                                    <a href="/PerformanceAppraisalNew/PerformanceReview/Main.aspx?appId={{item.AppIdEncrypt}}&empId={{item.EmpIdEncrypt}}" class="btn btn-primary btn-xs"><i class="fa fa-eye"></i></a>
                                    <button class='btn btn-xs btn-info' ng-click="printPdf(item.AppId,item.EmpId,item.Status)" type="button"><i class='fa fa-print'></i></button>
                                    <snap ng-show="IsAdmin">
                                    <a ng-click="Discard(item.AppId,item.EmpId)" class="btn btn-danger btn-xs" title="Discard Appraisal"><i class="fa fa-remove"></i></a>
                                    </snap>
                                </td>
                            </tr>
                        </tbody>


                    </table>
                    <div class="pull-right" style="background: #fcfcfc">
                        <dir-pagination-controls boundary-links="true" direction-links="true"></dir-pagination-controls>
                    </div>
                </div>

            </div>


            <div class="panel">
                <div class="panel-body">
                    <b style="margin-bottom: 10px;">Status in Performance Review</b>
                    <br />
                    <ol>
                        <li ng-repeat="x in ApprisalList">{{x.Text}}(<small>{{x.Description}}</small>)</li>
                    </ol>
                </div>
            </div>
        </div>


    </div>



</asp:Content>
