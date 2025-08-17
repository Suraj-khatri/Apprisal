<%@ Page Title="" Language="C#" MasterPageFile="~/Apprisal.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="SwiftHrManagement.web.Company.EmployeeWeb.JobDescription.List" %>
<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" language="javascript">
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
     <div class="panel">
        <header class="panel-heading">
            <i class="fa fa-caret-right"></i>
           Job Description Details
        </header>
        <div class="panel-body">
            <div class="row">
                <div class="col-md-12 col-sm-12">
                    <section class="panel">
                        <div class="panel-body">
                                    <div id="rpt" runat="server"></div>
                                    <asp:Button ID="btnHidden" runat="server" OnClick="btnHidden_OnClick" Style="display: none" />
                                </div>
                    </section>
                </div>
            </div>
        </div>
    </div>
</asp:Content>--%>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="/Angular/angular.js"></script>
    <script src="/Angular/helper/dirPagination.js"></script>
    <script src="/Angular/Module/VoucherModule.js"></script>
    <script src="/Angular/Service/JournalServices.js"></script>
    <script src="/Angular/Controller/JobDescription.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <div ng-app="VoucherModule">
        <div ng-controller="JdListCtrl">

            <div class="box box-warning direct-chat direct-chat-warning">
                <div class="box-header with-border">
                    <b>Job Description Search</b>

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
                         <input type="hidden" ng-model="Search.status" value="Self" />
                        <select ng-model="Search.FiscalYear" class="form-control select" ng-options="item.Text for item in FiscalList track by item.Value">
                            <option value="" disabled="disabled">Select Fiscal Year</option>
                        </select>
                        <text class="text-danger">{{FiscalMgs}}</text>
                    </div>
                 
                    <div class="col-md-3 form-group">

                        <button ng-click="FilterData(Search)" class="btn btn-primary btn-sm form-group" type="button"><i class="fa fa-search"></i>Search</button>
                        <button ng-click="Reset()" class="btn btn-default btn-sm form-group"><i class="fa fa-eraser"></i>Reset</button>
                    </div>

                </div>

            </div>
            <div class="panel panel-success">


                <div class="panel-heading">
                    <b>Job Description List</b>
                   <%-- <a href="/Company/EmployeeWeb/JobDescription/JobDescription.aspx" class="pull-right btn-info btn-sm"><i class="fa fa-plus-circle"></i>New Job Description</a>--%>

                </div>

                <div class="panel-body  table-responsive table-bordered">
                    <table class="table table-striped table-bordered table-responsive" style="overflow-x: scroll">

                        <thead>
                            <tr style="background: #1982ac; color: #fff">
                                <th>Employee</th>
                                <th>Supervisor</th>
                                <th>Position</th>
                                <th>SDate</th>
                                <th>EndDate</th>
                                <th>Status</th>
                                <th>Fiscal</th>
                                <th>View</th>
                            </tr>
                             <tr>
                                <td>
                                    <input type="text" ng-model="EmpName" style="padding: 4px; border: 1px solid #808080; width: 100%" placeholder="Search Employee" /></td>
                                <td>
                                    <input type="text" ng-model="suv" style="padding: 4px; border: 1px solid #808080; width: 100%" placeholder="Search Supervisor" />
                                </td>
                                <td>
                                    <input type="text" ng-model="pos" style="padding: 4px; border: 1px solid #808080; width: 100%" placeholder="Search Position" />

                                </td>
                                <td>

                                </td>
                                <td></td>
                                <td>
                                    <input type="text" ng-model="status" style="padding: 4px; border: 1px solid #808080; width: 100%" placeholder="Search Status" />

                                </td>
                                <td>
                                    <input type="text" ng-model="Fiscal" style="padding: 4px; border: 1px solid #808080; width: 100%" placeholder="Search Fiscal Year" />

                                </td>
                                <td></td>
                            </tr>
                        </thead>
                     
                        <tr dir-paginate="item in JobDescriptionList|filter:{EmployeeName: EmpName,Sataus:status,FiscalYear:fiscal,SupervisorName:suv,Position:pos}|orderBy : 'Sn' :reverse| itemsPerPage:50">
                            <td>{{item.EmployeeName}}</td>
                            <td>{{item.SupervisorName}}</td>
                            <td>{{item.Position}}</td>
                            <td>{{item.StatrtDate|date:'dd-MM-yyyy'}}</td>
                            <td>{{item.EndDate|date:'dd-MM-yyyy'}}</td>
                            <td>{{item.Sataus}}</td>
                            <td>{{item.FiscalYear}}</td>
                            <td>
                               <a href="/Company/EmployeeWeb/JobDescription/JobDescription.aspx?Id={{item.AppIdEncrypt}}&flag={{item.EmpIdEncrypt}}" class="btn btn-primary btn-sm pull-right"><i class="fa fa-eye"></i></a>
                                    <button class='btn btn-sm btn-info' ng-click="printPdf(item.AppId)" type="button"><i class='fa fa-print'></i></button>
                              </td>
                        </tr>

                    </table>
                    <div class="pull-right" style="background: #fcfcfc">
                        <dir-pagination-controls boundary-links="true" direction-links="true">

                        </dir-pagination-controls>
                    </div>
                </div>

            </div>
        </div>
        <div class="panel">
                <div class="panel-body">
                    <b style="margin-bottom: 10px;">Status in Job Description</b>
                    <br />
                    <ol>
                        <li>ACCEPTED(<small>Job Description Pending to Supervisor</small>)</li>
                        <li>PENDING(<small>Job Description Pending to Appraisee</small>)</li>
                        <li>Disagreed(<small>Job Description Disagreed by User</small>)</li>
                        <li>APPROVED(<small>Job Description ready to Review Initiation </small>)</li>
                       
                    </ol>
                </div>
            </div>
    </div>
</asp:Content>
