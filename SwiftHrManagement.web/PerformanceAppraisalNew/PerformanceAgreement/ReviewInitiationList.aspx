<%@ Page Title="" Language="C#" MasterPageFile="~/Apprisal.Master" AutoEventWireup="true" CodeBehind="ReviewInitiationList.aspx.cs" Inherits="SwiftHrManagement.web.PerformanceAppraisalNew.PerformanceAgreement.ReviewInitiationList" %>

<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" language="JavaScript" src="../../calendar/calendar_us.js"></script>
    <link rel="stylesheet" href="../../calendar/calendar.css"/>
    <script type="text/javascript" src="../../ui/js/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../ui/js/jquery-ui-1.10.3.min.js"></script>
    <script type="text/javascript" language="javascript">
    $(function () {
        $("#datepicker").datepicker();
    });
    $(function () {
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

    </script> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <div class="row">
        <div class="col-lg-12 col-sm-12">
            <section class="panel">
            <header class="panel-heading">
                 <i class="fa fa-caret-right" aria-hidden="true"></i> 
                Review Inititation 
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
        </div>
    </div>

</asp:Content>--%>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="/Angular/angular.js"></script>
    <script src="/Angular/helper/dirPagination.js"></script>
    <script src="/Angular/Module/VoucherModule.js"></script>
    <script src="/Angular/Service/JournalServices.js"></script>
    <script src="/Angular/Controller/ReviewInitiation.js"></script>



</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <div ng-app="VoucherModule">
        <div ng-controller="ReviewInitationCtrl">

            <div class="box box-warning direct-chat direct-chat-warning">
                <div class="box-header with-border">
                    <b>Agreement Initiation Search</b>

                    <div class="box-tools pull-right">

                        <button type="button" class="btn btn-box-tool" data-widget="collapse">
                            <i class="fa fa-minus"></i>
                        </button>

                    </div>
                </div>
                <br />
                <br />
                <div class="box-body">

                    <div class="col-md-3 form-group">

                        <select ng-model="Search.FiscalYear" class="form-control select" ng-options="item.Text for item in FiscalList track by item.Value">
                            <option value="" disabled="disabled">Select Fiscal Year</option>
                        </select>
                        <text class="text-danger">{{FiscalMgs}}</text>
                    </div>
                    <%-- <div class="col-md-3 form-group">
                          
                            <select ng-model="Search.EmpId" class="form-control select" ng-options="item.Text for item in EmployeeList track by item.Value" >
                                <option value="" disabled="disabled">Select Emp Name</option>
                            </select>

                        </div>--%>
                    <div class="col-md-3 form-group">

                        <button ng-click="FilterData(Search)" class="btn btn-primary btn-sm form-group" type="button"><i class="fa fa-search"></i>Search</button>
                        <%-- <button ng-click="Reset()" class="btn btn-default btn-sm form-group"><i class="fa fa-eraser"></i>Reset</button>--%>
                    </div>

                </div>

            </div>
            <div class="panel panel-success">


                <div class="panel-heading">
                    <b>Agreement Initiation List</b>
                    <a href="/PerformanceAppraisalNew/PerformanceAgreement/ReviewInitiation.aspx" class="pull-right btn-info btn-sm"><i class="fa fa-plus-circle"></i>  New Agreement Initiation</a>

                </div>

                <div class="panel-body  table-responsive">
                    <table class="table table-striped table-bordered table-responsive" style="overflow-x: scroll">

                        <thead>
                            <tr style="background: #1982ac; color: #fff">
                                <th>SN
                                </th>
                                <th>Appraisee Name
                                </th>
                                <th>From Date
                                </th>
                                <th>End Date
                                </th>
                                <th>Status
                                </th>
                                <th>Fiscal Year
                                </th>
                                <th>View</th>
                            </tr>

                        </thead>
                        <tr>

                            <td></td>
                            <td>
                                <input type="text" ng-model="EmpName" placeholder="Employee Name search" class="input-sm" />
                            </td>

                            <td>
                                <input type="text" ng-model="Date" placeholder="search Start Date" class="input-sm" />
                            </td>
                            <td>
                                <input type="text" ng-model="EDate" placeholder="search End Date" class="input-sm" />
                            </td>
                            <td></td>
                            <td></td>


                            <td></td>
                        </tr>

                        <tr dir-paginate="item in ReviewinitiationcList|filter:{AppriseeName: EmpName,StartDate:Date,EndDate:EDate}|orderBy : 'Sn' :reverse| itemsPerPage:50">
                             <td>{{$index +1}}</td> 
                            <td>{{item.AppriseeName}}</td>
                            <td>{{item.StartDate|date:'dd-MM-yyyy'}}</td>
                            <td>{{item.EndDate|date:'dd-MM-yyyy'}}</td>
                            <td>{{item.Status}}</td>
                            <td>{{item.Fiscalyear}}</td>
                            <td>
                                <a href="/PerformanceAppraisalNew/PerformanceAgreement/ReviewInitiation.aspx?appId={{item.AppIdEncrypt}}&empId={{item.EmpIdEncrypt}}" class="btn btn-primary btn-sm pull-right"><i class="fa fa-eye"></i></a>
                            </td>
                        </tr>

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
                        <li>Agreement Pending to Supervisor(<small>Agreement Pending to Supervisor</small>)</li>
                       
                    </ol>
                </div>
            </div>
        </div>

    </div>


</asp:Content>
