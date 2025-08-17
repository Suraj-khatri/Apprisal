<%@ Page Title="" Language="C#" MasterPageFile="~/Apprisal.Master" AutoEventWireup="true" CodeBehind="SearchPerformanceAgreement.aspx.cs" Inherits="SwiftHrManagement.web.PerformanceAppraisalNew.PerformanceAgreement.SearchPerformanceAgreement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="/Angular/angular.js"></script>
    <script src="/Angular/helper/dirPagination.js"></script>
    <script src="/Angular/Module/VoucherModule.js"></script>
    <script src="/Angular/Service/JournalServices.js"></script>
    <script src="/Angular/Controller/PerformanceAgreement.js"></script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <div ng-app="VoucherModule">
        <div ng-controller="PerformanceAgreemnetCtrl">

            <div class="panel panel-success">


                <div class="panel-heading">
                    <b>Performance Agrement Search</b>

                </div>
                <div class="panel-body ">

                    <div class="row">
                        <div class="col-md-3 form-group">
                            <label>Apprisal Status</label>
                            <select class="form-control select" ng-model="Search.Status" ng-options="item.Text for item in ApprisalList track by item.Value">
                                <option value="" disabled="disabled">Select Status</option>
                            </select>

                        </div>
                        <div class="col-md-3 form-group">
                            <label>Fiscal Year</label>
                            <select ng-model="Search.FiscalYear" class="form-control select" ng-options="item.Text for item in FiscalList track by item.Value" required="required">
                                <option value="" disabled="disabled">Select Fiscal Year</option>
                            </select>
                            <text class="text-danger">{{FiscalMgs}}</text>
                        </div>
                        <%--<div class="col-md-3 form-group">
                            <label>Employee Name</label>
                            <select ng-model="Search.EmpId" class="form-control select" ng-options="item.Text for item in EmployeeList track by item.Value">
                                <option value="" disabled="disabled">Select Emp Name</option>
                            </select>

                        </div>--%>
                        <div class="col-md-3 form-group">
                            <br />
                            <button ng-click="FilterData(Search)" class="btn btn-primary btn-sm form-group" type="button"><i class="fa fa-search"></i>Search</button>
                            <button ng-click="Reset()" class="btn btn-default btn-sm form-group"><i class="fa fa-eraser"></i>Reset</button>
                        </div>

                    </div>

                </div>

            </div>

            <div class="panel panel-success">


                <div class="panel-heading">
                    <b>Performance Agreement List</b>

                </div>

                <div class="panel-body  table-responsive">
                    <table class="table table-striped table-bordered table-responsive" style="overflow-x: scroll">

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
                                <th>View/Close</th>
                            </tr>

                        </thead>
                        <tr>

                           
                            <td>
                                <input type="text" ng-model="EmpName" placeholder="Employee Name search" class="input-sm" />
                            </td>

                            <td>
                                <input type="text" ng-model="Date" placeholder="search Start Date" class="input-sm" />
                            </td>
                            <td>
                                <input type="text" ng-model="EDate" placeholder="search End Date" class="input-sm" />
                            </td>
                             <th><input type="text" ng-model="Supervisor"  placeholder="Search Supervisor" class="input-sm"/> </th>
                             <th><input type="text" ng-model="Reviewer"  placeholder="Search Reviewer" class="input-sm" />  </th>

                            <td>
                                <input type="text" ng-model="sts" placeholder="Status search" class="input-sm" />
                            </td>
                            <td></td>


                            <td></td>
                        </tr>
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
                            <tr dir-paginate="item in ApprisalAgreementList|filter:{AppriseeName: EmpName,StartDate:Date,Status:sts,Supervisor:Supervisor,Reviewer:Reviewer}| itemsPerPage:50">
                             
                                <td>{{item.AppriseeName}}</td>
                                <td>{{item.StartDate|date:'dd-MM-yyyy'}}</td>
                                <td>{{item.EndDate|date:'dd-MM-yyyy'}}</td>
                                 <td>{{item.Supervisor}}</td>
                                <td>{{item.Reviewer}}</td>
                                <td>{{item.Status}}</td>
                                <td>{{item.Fiscalyear}}</td>
                                <td>
                                    <a href="/PerformanceAppraisalNew/PerformanceAgreement/KRAKPI.aspx?appId={{item.AppIdEncrypt}}&empId={{item.EmpIdEncrypt}}" class="btn btn-primary btn-xs" target="_blank"><i class="fa fa-eye"></i></a>
                                    <snap ng-show="item.statusCode>1">
                                        <button  class='btn btn-xs btn-info'   ng-click="printPdf(item.AppIdEncrypt,item.EmpIdEncrypt,item.Status)" type="button"><i class='fa fa-print'></i></button>
                                   </snap>
                                     <snap ng-show="item.statusCode==1">
                                        <button  class='btn btn-xs btn-info'   ng-click="notvalid()" type="button"><i class='fa fa-print'></i></button>
                                   </snap>
                                    <snap ng-show="IsAdmin">
                                        <a ng-click="Discard(item.AppId)" class="btn btn-danger btn-xs" ><i class="fa fa-remove"></i></a>
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
                    <b style="margin-bottom: 10px;">Status in Performance Agreement</b>
                    <br />
                    <ol>
                        <li ng-repeat="x in ApprisalList">{{x.Text}}(<small>{{x.Description}}</small>)</li>
                    </ol>
                </div>
            </div>
        </div>

    </div>



</asp:Content>




