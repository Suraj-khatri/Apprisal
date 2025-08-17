<%@ Page Title="" Language="C#" MasterPageFile="~/Apprisal.Master" AutoEventWireup="true" CodeBehind="ChangeSupervisor.aspx.cs" Inherits="SwiftHrManagement.web.PerformanceAppraisalNew.HRSetups.ChangeSupervisor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="../../Angular/select2.css" rel="stylesheet" />
    <script src="../../Angular/jquery-3.2.1.min.js"></script>

    <script src="../../Angular/js/select2.js"></script>
    <script src="/Angular/angular.js"></script>
    <script src="../../Angular/helper/dirPagination.js"></script>
    <script src="../../Angular/Module/Module.js"></script>
    <script src="/Angular/Service/JournalServices.js"></script>
    <script src="../../Angular/Controller/ChangeSupervisor.js"></script>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <div ng-app="VoucherModule">
        <div ng-controller="ChangeSupervisorCtrl">

            <div class="panel panel-warning">
                <div class="panel-body">

                    <div class="row">
                        <div class="col-md-3">
                            Appraisee List
                            <select class="form-control" select2="" data-ng-model="Search.EmpId" ng-options="item.Text for item in EmpList track by item.Value">
                                <option value="">Select Employee</option>
                            </select>
                        </div>
                        <div class="col-md-3">
                            Supervisor List
                            <select class="form-control" select2="" data-ng-model="Search.SuvId" ng-options="item.Text for item in SuvList track by item.Value">
                                <option value="">Select Supervisor</option>
                            </select>
                        </div>
                        <div class="col-md-3">
                            Reviewer List
                            <select class="form-control" select2="" data-ng-model="Search.RevId" ng-options="item.Text for item in RevList track by item.Value">
                                <option value="">Select Reviewer</option>
                            </select>
                        </div>
                        <div class="col-md-3">
                            <br />
                            <a class="btn btn-info" ng-click="FilterRecord(Search)"><i class="fa fa-search"></i> Search </a>
                            <button class="btn btn-default" ng-click="Crear()">Clear</button>
                        </div>
                    </div>



                </div>
            </div>
            
            <div class="panel panel-primary">


                <div class="panel-body">
                    <div class="row">
                        <div class="panel-body  table-responsive">
                            <table class="table table-striped table-bordered" style="overflow-x: scroll">

                                <thead>
                                    <tr style="background: #1982ac; color: #fff">
                                        <th>SN
                                        </th>
                                        <th>Appraisee Name
                                        </th>
                                        <th>Supervisor Name
                                        </th>
                                        <th>Reviewer Name
                                        </th>
                                        <th>Status
                                        </th>
                                        <th>Fiscal Year
                                        </th>
                                        <th>Option</th>
                                    </tr>
                                    <tr>

                                        <td></td>
                                        <th>
                                            <input type="text" ng-model="EmpName" class="input-sm" placeholder="Search Appraisee" />
                                        </th>
                                        <th>
                                            <input type="text" ng-model="SuvName" class="input-sm" placeholder="Search Supervisor" />
                                        </th>
                                        <th>
                                            <input type="text" ng-model="RevName" class="input-sm" placeholder="Search Reviewer" />
                                        </th>
                                        <th>
                                            <input type="text" ng-model="status" class="input-sm" placeholder="Search status" />
                                        </th>
                                        <th></th>


                                        <th></th>
                                    </tr>
                                </thead>

                                <tr dir-paginate="item in AppraisalList|filter:{AppriseeName: EmpName,Status:status,Supervisor:SuvName,Reviewer:RevName}|orderBy : 'Sn' :reverse| itemsPerPage:50">

                                    <td>{{item.Sn+1}}</td>
                                    <td>{{item.AppriseeName}}</td>
                                    <td>{{item.Supervisor}}</td>
                                    <td>{{item.Reviewer}}</td>
                                    <td>{{item.Status}}</td>
                                    <td>{{item.Fiscalyear}}</td>
                                    <td>
                                       <a class="btn btn-info btn-xs" ng-click="UpdateSupervisor(item.AppId,item.SupervisorId)" onclick"return false;" data-toggle="modal" data-target="#supervisor">Change Supervisor</a>
                                        <a class="btn btn-primary btn-xs" ng-click="UpdateReviewer(item.AppId,item.ReviewerId)" data-toggle="modal" data-target="#reviewer">Change Reviewer</a>
                                    </td>
                                </tr>
                                <tfoot>
                                    <tr>
                                        <td colspan="7">
                                            <div class="pull-right" style="background: #fcfcfc">
                                                <dir-pagination-controls boundary-links="true" direction-links="true"></dir-pagination-controls>
                                            </div>
                                        </td>
                                    </tr>
                                </tfoot>
                            </table>




                            <div id="supervisor" class="modal fade" role="dialog">
                                <div class="modal-dialog">

                                    <!-- Modal content-->
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                                            <h4 class="modal-title">Change Supervisor</h4>
                                        </div>
                                        <div class="modal-body">
                                            <input type="hidden" data-ng-model="SUV.APPId" />
                                            <input type="hidden" data-ng-model="SUV.SuvIdOld" />
                                            <table class="table table-bordered">
                                                <tr>
                                                    <th>
                                                        Appraisee Name
                                                        <input type="text" class="form-control" data-ng-model="SUV.EmpName" readonly="readonly"/>
                                                    </th>
                                                   <td>
                                                       Branch
                                                         <input type="text" class="form-control" data-ng-model="SUV.Branch" readonly="readonly"/>
                                                    </td>
                                                </tr>
                                                 <tr>
                                                    <td>
                                                        Department
                                                        <input type="text" class="form-control" data-ng-model="SUV.Department" readonly="readonly"/>
                                                    </td>
                                                    <td>
                                                       Position
                                                         <input type="text" class="form-control" data-ng-model="SUV.Position" readonly="readonly"/>
                                                    </td>
                                                </tr>
                                                 <tr>
                                                    <td>
                                                        StartDate
                                                        <input type="text" class="form-control" data-ng-model="SUV.StartDate" readonly="readonly"/>                                                         
                                                    </td>
                                                    <td>
                                                       EndDate
                                                           <input type="text" class="form-control" data-ng-model="SUV.EndDate" readonly="readonly"/>
                                                     
                                                    </td>
                                                </tr>
                                                 <tr>
                                                    <td>
                                                        Supervisor:
                                                        <input type="text" class="form-control" data-ng-model="SUV.Supervisor" readonly="readonly"/>
                                                    </td>
                                                    <td>
                                                      Reviewing Officer:
                                                         <input type="text" class="form-control" data-ng-model="SUV.reviewer" readonly="readonly"/>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        
                                                <b>New Supervisor</b>
                                                <select class="form-control" style="width: 100%" select2="" data-ng-model="SUV.SuvIdNew" ng-options="item.Text for item in SuvList track by item.Value">
                                                    <option value="">Select Supervisor</option>
                                                </select>
                                            
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                               <input type="checkbox" data-ng-model="SUV.ChangeAllSuv"/>
                                                Change All  <small>( <i>All Appraisal associated with current Supervisor will be updated by new supervisor</i>)</small>
                                                   <br />  <b ng-if="error" class="text-danger">{{mgs}}</b>
                                                   <br />  <b ng-if="success" class="text-success">{{mgs}}</b>

                                                    </td>
                                                </tr>
                                              
                                            </table>

                                          
                                           

                                        </div>
                                        <div class="modal-footer">
                                            <input type="button" class="btn btn-danger pull-right" value="Close" style="margin:2px" ng-click="Clear()" data-dismiss="modal"/>
                                           <input type="button" class="btn btn-info pull-right" value="Change Supervisor" style="margin:2px" ng-click="ChangeSupervisor(SUV)" />

                                        </div>
                                    </div>

                                </div>
                            </div>

                            <div id="reviewer" class="modal fade" role="dialog">
                                <div class="modal-dialog">

                                    <!-- Modal content-->
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                                            <h4 class="modal-title">Change Reviewing Officer:</h4>
                                        </div>
                                        <div class="modal-body">
                                             <input type="hidden" data-ng-model="SUV.APPId" />
                                            <input type="hidden" data-ng-model="SUV.RevIdOld" />
                                            <table class="table table-bordered">
                                                <tr>
                                                    <th>
                                                        Appraisee Name
                                                        <input type="text" class="form-control" data-ng-model="SUV.EmpName" readonly="readonly"/>
                                                    </th>
                                                    <td>
                                                       Branch
                                                         <input type="text" class="form-control" data-ng-model="SUV.Branch" readonly="readonly"/>
                                                    </td>
                                                </tr>
                                                 <tr>
                                                    <td>
                                                        Department
                                                        <input type="text" class="form-control" data-ng-model="SUV.Department" readonly="readonly"/>
                                                    </td>
                                                    <td>
                                                       Position
                                                         <input type="text" class="form-control" data-ng-model="SUV.Position" readonly="readonly"/>
                                                    </td>
                                                </tr>
                                                 <tr>
                                                    <td>
                                                         
                          
                                                        StartDate
                                                        <input type="text" class="form-control" data-ng-model="SUV.StartDate" readonly="readonly"/>
                                                      
                                                         
                                                    </td>
                                                    <td>
                                                       EndDate
                                                           <input type="text" class="form-control" data-ng-model="SUV.EndDate" readonly="readonly"/>
                                                     
                                                    </td>
                                                </tr>
                                                 <tr>
                                                    <td>
                                                        Supervisor:
                                                        <input type="text" class="form-control" data-ng-model="SUV.Supervisor" readonly="readonly"/>
                                                    </td>
                                                    <td>
                                                      Reviewing Officer:
                                                         <input type="text" class="form-control" data-ng-model="SUV.reviewer" readonly="readonly"/>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        
                                                <b>New Reviewer</b>
                                                <select class="form-control" style="width: 100%" select2="" data-ng-model="SUV.NewRevId" ng-options="item.Text for item in RevList track by item.Value">
                                                    <option value="">Select Reviewing Officer:</option>
                                                </select>
                                            
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                                                                    <div class="form-group">
                                                <input type="checkbox" data-ng-model="SUV.ChangeAllReviewer"/>
                                                Change All  <small>( <i>All Appraisal associated with current Reviewer will be updated by new supervisor</i>)</small>
                                            <br />  <b ng-if="error" class="text-danger">{{mgs}}</b>
                                             </div>

                                                    </td>
                                                </tr>
                                              
                                            </table>
                                  <%--          <div class="form-group">
                                                <b>Existing Reviewing Officer:</b>
                                                 <input type="text" readonly="readonly" class="form-control" style="width: 100%"  data-ng-model="SUV.reviewer" />
                                                   
                                                
                                                    
                                            </div>--%>
                                            



                                        </div>
                                        <div class="modal-footer">
                                            <input type="button" class="btn btn-danger pull-right" value="Close" style="margin: 2px" ng-click="Clear()" data-dismiss="modal"  />
                                            <input type="button" class="btn btn-info pull-right" value="Change Reviewer" style="margin: 2px" ng-click="ChangeReviewer(SUV)"/>

                                        </div>
                                    </div>

                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>

