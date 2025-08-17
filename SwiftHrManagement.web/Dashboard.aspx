<%@ Page Title="" Language="C#" MasterPageFile="~/Apprisal.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="SwiftHrManagement.web.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="/Angular/angular.js"></script>
    <script src="/Angular/helper/dirPagination.js"></script>
    <script src="/Angular/Module/VoucherModule.js"></script>
    <script src="/Angular/Service/JournalServices.js"></script>
    <script src="/Angular/Controller/DashBoard.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <div ng-app="VoucherModule">
        <div ng-controller="DashBoardCtrl">
            <div class="col-md-12">
                <h5>Pending Task</h5>
            </div>
            <div class="col-lg-4 col-xs-6">
                <!-- small box -->
                <div class="small-box bg-yellow">
                    <div class="inner">
                        <h3 runat="server" id="JdCount"><sup style="font-size: 20px"></sup></h3>

                        <p>Job Description</p>
                    </div>
                    <asp:HyperLink ID="JdLink" runat="server" class="small-box-footer">View List <i class="fa fa-arrow-circle-right"></i></asp:HyperLink>


                </div>
            </div>
            <div class="col-lg-4 col-xs-6">
                <div class="small-box bg-yellow">
                    <div class="inner">
                        <h3 runat="server" id="PACount">0</h3>
                        <p>Performance Agreement</p>
                    </div>

                    <a href="/PerformanceAppraisalNew/Performanceagreement/SearchPerformanceAgreement.aspx" class="small-box-footer">View List <i class="fa fa-arrow-circle-right"></i></a>
                </div>
            </div>
            <div class="col-lg-4 col-xs-6">
                <!-- small box -->
                <div class="small-box bg-yellow">
                    <div class="inner">
                        <h3 runat="server" id="PRCount">0</h3>

                        <p>Performance Review</p>
                    </div>

                    <a href="/PerformanceAppraisalNew/PerformanceReview/SearchPerformanceReview.aspx" class="small-box-footer">View List <i class="fa fa-arrow-circle-right"></i></a>
                </div>
            </div>

            <div class="row">
                <div ng-show="IsSupervisor">
                    <div class="col-md-6">

                        <div class="box box-warning direct-chat direct-chat-warning">
                            <div class="box-header with-border">

                                <b><a href="/Company/EmployeeWeb/JobDescription/JDList.aspx">Job Description To Assign</a></b>
                                <div class="box-tools pull-right">

                                    <button type="button" class="btn btn-box-tool" data-widget="collapse">
                                        <i class="fa fa-minus"></i>
                                    </button>

                                </div>
                            </div>

                            <div class="box-body">
                                <table class="table">
                                    <tr style="background: #1982ac; color: #fff">
                                        <th>Emp Name</th>
                                        <th>Position</th>
                                        <th>Branch</th>
                                        <th>Assign</th>
                                    </tr>
                                    <tbody>
                                        <tr dir-paginate="item in JdtoAssignList|orderBy : 'Sn' | itemsPerPage:5">
                                            <td>{{item.EmployeeName}}</td>
                                            <td>{{item.Position}}</td>
                                            <td>{{item.Branch}}</td>
                                            <td><a href="/Company/EmployeeWeb/JobDescription/JobDescription.aspx" class="btn btn-xs btn-warning"><i class="fa fa-plus-circle"></i>Add</a></td>

                                        </tr>
                                    </tbody>
                                </table>
                            </div>

                        </div>
                    </div>
                    <div class="col-md-6">

                        <div class="box box-warning direct-chat direct-chat-warning">
                            <div class="box-header with-border">

                                <b><a href="/Company/EmployeeWeb/JobDescription/JDList.aspx">Pending To Agreement Initiate</a></b>
                                <div class="box-tools pull-right">

                                    <button type="button" class="btn btn-box-tool" data-widget="collapse">
                                        <i class="fa fa-minus"></i>
                                    </button>

                                </div>
                            </div>

                            <div class="box-body">
                                <table class="table">
                                    <tr style="background: #1982ac; color: #fff">
                                        <th>Emp Name</th>
                                        <th>Position</th>
                                        <th>Branch</th>
                                        <th>Initiate</th>
                                    </tr>
                                    <tbody>
                                        <tr dir-paginate="item in JdtoAssignList|orderBy : 'Sn'| itemsPerPage:5">
                                            <td>{{item.EmployeeName}}</td>
                                            <td>{{item.Position}}</td>
                                            <td>{{item.Branch}}</td>
                                            <td><a href="/PerformanceAppraisalNew/PerformanceAgreement/ReviewInitiation.aspx" class="btn btn-xs btn-warning"><i class="fa fa-plus-circle"></i>Add</a></td>

                                        </tr>
                                    </tbody>
                                </table>
                            </div>

                        </div>
                    </div>
                </div>
            </div>

            <div>
                <div class="row" ng-show="IsReviewer">
                    <div class="col-md-6">

                        <div class="box box-warning direct-chat direct-chat-warning">
                            <div class="box-header with-border">
                                <b>Perfomance Agreement for Reviewer</b>
                                <div class="box-tools pull-right">

                                    <button type="button" class="btn btn-box-tool" data-widget="collapse">
                                        <i class="fa fa-minus"></i>
                                    </button>

                                </div>
                            </div>

                            <div class="box-body">
                                <div ng-show="!PAforReviewer.length">No Record available</div>
                               
                                 <table class="table" ng-show="PAforReviewer.length">
                                    <tr style="background: #1982ac; color: #fff">
                                        <th>Emp Name</th>
                                        <th>Position</th>
                                        <th>Branch</th>
                                        <th>Review</th>
                                    </tr>
                                     <tr>
                                     <td>Search:</td>
                                     <td colspan="3"><input placeholder="serach employee" ng-model="search"/></td>

                                     </tr>
                                     
                                    <tbody>
                                        <tr  ng-repeat="item in PAforReviewer|filter:{AppriseeName: search}|orderBy : 'Sn' :reverse| limitTo:5">
                                            <td>{{item.AppriseeName}}</td>
                                            <td>{{item.Position}}</td>
                                            <td>{{item.Branch}}</td>
                                            <td><a href="/PerformanceAppraisalNew/PerformanceAgreement/KRAKPI.aspx?appId={{item.AppIdEncrypt}}&empId={{item.EmpIdEncrypt}}" class="btn btn-primary btn-sm"><i class="fa fa-eye"></i></a></td>

                                        </tr>
                                    </tbody>
                                </table>
                            </div>

                        </div>
                    </div>
                    <div class="col-md-6">

                        <div class="box box-warning direct-chat direct-chat-warning">
                            <div class="box-header with-border">
                                <b>Performance Review to Reviewer</b>

                                <div class="box-tools pull-right">

                                    <button type="button" class="btn btn-box-tool" data-widget="collapse">
                                        <i class="fa fa-minus"></i>
                                    </button>

                                </div>
                            </div>


                            <div class="box-body">
                                 <div ng-show="!PRforReviewer.length">No Record available</div>
                                <table class="table" ng-show="PRforReviewer.length">
                                    <tr style="background: #1982ac; color: #fff">
                                        <th>Emp Name</th>
                                        <th>Position</th>
                                        <th>Branch</th>
                                        <th>Review</th>
                                    </tr>
                                     <tr>
                                     <td>Search Employee:</td>
                                     <td colspan="3"><input  placeholder="serach employee" ng-model="searchPr"/></td>

                                     </tr>
                                    <tbody>
                                        <tr  ng-repeat="item in PRforReviewer|filter:{AppriseeName: searchPr}| limitTo:5">
                                            <td>{{item.AppriseeName}}</td>
                                            <td>{{item.Position}}</td>
                                            <td>{{item.Branch}}</td>
                                            <td><a href="/PerformanceAppraisalNew/PerformanceReview/Main.aspx?appId={{item.AppIdEncrypt}}&empId={{item.EmpIdEncrypt}}" class="btn btn-primary btn-sm"><i class="fa fa-eye"></i></a></td>

                                        </tr>
                                    </tbody>
                                </table>

                            </div>


                        </div>
                    </div>
                </div>
            </div>

            <div class="clearfix"></div>
            <div class="row">
                <div ng-show="IsComeetee" class="col-md-12">

                    <div class="box box-warning direct-chat direct-chat-warning">
                        <div class="box-header with-border">
                            <b>Performance Review for Review Committee </b>

                            <div class="box-tools pull-right">

                                <button type="button" class="btn btn-box-tool" data-widget="collapse">
                                    <i class="fa fa-minus"></i>
                                </button>

                            </div>
                        </div>


                        <div class="box-body table-responsive">
                            <table class="table" style="overflow-x: scroll; margin: 10px">

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
                                        <th>Position</th>
                                        <th>Status
                                        </th>
                                        <th>Fiscal Year
                                        </th>
                                        <th>View/Print</th>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <th>
                                            <input type="text" ng-model="EmpName" style="padding: 4px; border: 1px solid #808080; width: 100%" placeholder="Search Name" />
                                        </th>

                                        <th></th>
                                        <th></th>
                                        <th>
                                            <input type="text" ng-model="status" style="padding: 4px; border: 1px solid #808080; width: 80%" placeholder="Search status" />
                                        </th>
                                        <th></th>

                                    </tr>
                                </thead>


                                <tr dir-paginate="item in PRforCommitee|filter:{AppriseeName: EmpName,Status:status}|orderBy : 'Sn'| itemsPerPage:5">
                                    <td>{{item.Sn}}</td>
                                    <td>{{item.AppriseeName}}</td>
                                    <td>{{item.StartDate|date:'dd-MM-yyyy'}}</td>
                                    <td>{{item.EndDate|date:'dd-MM-yyyy'}}</td>
                                    <td>{{item.Position}}</td>
                                    <td>{{item.Status}}</td>
                                    <td>{{item.Fiscalyear}}</td>
                                    <td>
                                        <a href="/PerformanceAppraisalNew/PerformanceReview/Main.aspx?appId={{item.AppIdEncrypt}}&empId={{item.EmpIdEncrypt}}" class="btn btn-primary btn-sm"><i class="fa fa-eye"></i></a>
                                    </td>
                                </tr>

                            </table>
                            <div class="pull-right" style="background: #fcfcfc">
                                <dir-pagination-controls boundary-links="true" direction-links="true"></dir-pagination-controls>
                            </div>
                        </div>



                    </div>

                </div>
            </div>
            <div class="clearfix"></div>
        </div>
    </div>

  <%--  <div id="myModal" class="modal fade">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header label-warning">
                        <h3 class="modal-title">User Alert </h3>
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                    </div>
                    <div class="modal-body" >
                        <h5 style="font-family:Calibri;font-size:20px">Dear User, <br /> <br /> <span> If you are facing problem in loading Performance Agreement/ Performance Review in PMS software, please press CTRL + F5 while the browser displays loading. </span> </h5>
                        
                    </div>
                </div>
            </div>
        </div>--%>
</asp:Content>
