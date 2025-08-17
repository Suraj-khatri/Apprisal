<%@ Page Title="Apprisal Mangement System" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="SwiftHrManagement.web.Main" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .numbers_today {
            background-color: #0073ab !important;
        }

            .numbers_today .numbers {
                color: #fff !important;
            }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <script type="text/javascript" src="http:/ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js">
    </script>
    <script type="text/javascript">
        window.setInterval(function () {
            ShowLocalDate();
        }, 1000);
        function ShowLocalDate() {
            var dNow = new Date();
            var localdate = (dNow.getMonth() + 1) + '/' + dNow.getDate() + '/' + dNow.getFullYear() + ' ' + dNow.getHours() + ':' + dNow.getMinutes() + ':' + dNow.getSeconds();
            var localTime = dNow.getHours() + ':' + dNow.getMinutes() + ':' + dNow.getSeconds();
            $('#currentDate').text(localTime)
        }

    </script>
    <script type="text/javascript" language="javascript">

        function moveMonth(nav) {
            var ddlMonth = "<%=month.ClientID%>";
            var ddlYear = "<%=year.ClientID%>";
            var btnGo = "<%=btnGo.ClientID%>";


            var m = document.getElementById(ddlMonth);
            var y = document.getElementById(ddlYear);
            var b = document.getElementById(btnGo);


            if (m != null && y != null && b != null) {

                if (nav == "p") {
                    if (m.selectedIndex == 0) {
                        if (y.selectedIndex == 0)
                            return;

                        m.selectedIndex = 11;

                        if (y.selectedIndex > 0) {
                            y.selectedIndex = y.selectedIndex - 1;
                        }
                    }
                    else {
                        m.selectedIndex = m.selectedIndex - 1;
                    }
                    b.click();
                }
                else {
                    if (m.selectedIndex >= 11) {
                        if (y.selectedIndex == y.options.length - 1)
                            return;
                        m.selectedIndex = 0;

                        if (y.selectedIndex < y.options.length - 1) {
                            y.selectedIndex = y.selectedIndex + 1;
                        }
                    }
                    else {
                        m.selectedIndex = m.selectedIndex + 1;
                    }
                    b.click();
                }
            }
        }
    </script>


    <div id="page-wrapper">

        <!-- /.row -->
        <div class="row">
            <div class="states-info">
                <div class="col-md-3">
                    <div class="panel common-bg yellow-bg ">
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-xs-4">
                                    <img src="ui/images/l3.png" class="img-responsive" />
                                </div>
                                <div class="col-xs-8 text-right p-l-0">
                                    <span class="state-title">
                                        <asp:Label ID="attendanceCnt" runat="server"></asp:Label></span>
                                    <h6><a style="text-decoration: none; color: #fff;" target="_blank" href="/AttendenceWeb/AttendanceRequest.aspx">Missing Attendance</a> </h6>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-3">
                    <div class="panel common-bg blue-bg">
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-xs-4">
                                    <img src="ui/images/l1.png" class="img-responsive" />
                                </div>
                                <div class="col-xs-8 text-right p-l-0">
                                    <span class="state-title">
                                        <asp:Label ID="leaveAvailable" runat="server"></asp:Label></span>
                                    <h6>Available Total Leave </h6>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-3">
                    <div class="panel common-bg green-bg">
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-xs-4">
                                    <img src="ui/images/l2.png" class="img-responsive" />
                                </div>
                                <div class="col-xs-8 text-right p-l-0">
                                    <span class="state-title">
                                        <asp:Label ID="getLeave" runat="server"></asp:Label></span>
                                    <h6><a style="text-decoration: none; color: #fff;" target="_blank" href="LeaveManagementModule/LeaveRequestIndivisual/List.aspx">Pending Leave for Approval</a></h6>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-3">
                    <div class="panel common-bg red-bg">
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-xs-4">
                                    <img src="ui/images/l4.png" class="img-responsive" />
                                </div>
                                <div class="col-xs-8 text-right p-l-0">
                                    <span class="state-title1">
                                        <asp:Label runat="server" ID="getReqCnt"></asp:Label></span>
                                    <h6><a style="text-decoration: none; color: #fff;" target="_blank" href="/Inventory/Requisition/RequisitionList.aspx">Pending Requisition</a></h6>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
        </div>
        <!-- body starts from here-->

        <!-- main body starts from here-->
        <div class="row ">
            <div class="col-md-8">
                <!-- <div class="row">
                    <div class="col-md-12 ">
                        <div class="panel">
                            <div class="panel-body" align="center">
                                <i class="fa fa-thumbs-up pull-left" aria-hidden="true"></i>
                                <h4>Employee Of the Month is <strong>Ms. Srijan Sedhai</strong></h4>
                            </div>
                        </div>
                    </div>
                </div>-->
                <!-- calender starts from here-->
                <div class="calender-wrapper">
                    <div class="well well-md">
                        <center>
                            <h4>Pending Task </h4>
                        </center>
                         <ul class="nav nav-tabs" >

                                <li class="active">
                                    <a data-toggle="tab" target="_blank" href="#menu1" >Performance Agreement <span class="badge badge-warning">5</span></a></li>
                                <li>
                                    <a data-toggle="tab" target="_blank" href="#menu2">Performance Apprisal <span class="badge badge-warning">18</span></a></li>
                            </ul>
                    </div>


                   
                           
                        <div class="panel panel-primary">

                        <div class="panel-body">
                            <div class="tab-content">
                                <div id="menu1" class="tab-pane fade in active">
                                    <table class="table table-advance table-condensed">
                                        <tr class="label-info">
                                            <th>SN</th>
                                            <th>Pending Task</th>
                                            <th>Quantity</th>
                                            <th>Pending Since</th>
                                            <th>Avg Time </th>
                                            <th>Link</th>
                                        </tr>
                                        <tbody>
                                            <tr>
                                                <td>1</td>
                                                <th>Performance Agreement to Supervise</th>
                                                <td>1</td>
                                                <td>24 Days</td>
                                                <td>7 Days</td>
                                                <td>
                                                    <a class="btn btn-xs btn-info" target="_blank" href="/PerformanceAppraisalNew/Performanceagreement/SearchPerformanceAgreement.aspx" title="">View All</a>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>2</td>
                                                <th>Performance Agreement to Aggree</th>
                                                <td>3</td>
                                                <td>21 Days</td>
                                                <td>6 Days</td>
                                                <td>
                                                    <a class="btn btn-xs btn-info" target="_blank" href="/PerformanceAppraisalNew/Performanceagreement/SearchPerformanceAgreement.aspx" title="">View All</a>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>3</td>
                                                <th>Performance Agreement to review</th>
                                                <td>6</td>
                                                <td>21 Days</td>
                                                <td>7 Days</td>
                                                <td>
                                                    <a class="btn btn-xs btn-info" target="_blank" href="/PerformanceAppraisalNew/Performanceagreement/SearchPerformanceAgreement.aspx" title="">View All</a>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>4</td>
                                                <th>PA to review</th>
                                                <td>8</td>
                                                <td>21 Days</td>
                                                <td>7 Days</td>
                                                <td>
                                                    <a class="btn btn-xs btn-info" target="_blank" href="/PerformanceAppraisalNew/Performanceagreement/SearchPerformanceAgreement.aspx" title="">View All</a>
                                                </td>
                                            </tr>
                                        </tbody>

                                    </table>
                                </div>
                                <div id="menu2" class="tab-pane fade">
                                    <table class="table table-advance table-condensed">
                                        <tr class="label-info">
                                            <th>SN</th>
                                            <th>Pending Task</th>
                                            <th>Quantity</th>
                                            <th>Pending Since</th>
                                            <th>Avg Time </th>
                                            <th>Link</th>
                                        </tr>
                                        <tbody>
                                            <tr>
                                                <td>1</td>
                                                <th>Performance Review to Supervise</th>
                                                <td>1</td>
                                                <td>24 Days</td>
                                                <td>7 Days</td>
                                                <td>
                                                    <a class="btn btn-xs btn-info" target="_blank" href="/PerformanceAppraisalNew/Performanceagreement/SearchPerformanceAgreement.aspx" title="">View All</a>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>2</td>
                                                <th>Performance Review to Aggree</th>
                                                <td>3</td>
                                                <td>21 Days</td>
                                                <td>6 Days</td>
                                                <td>
                                                    <a class="btn btn-xs btn-info" target="_blank" href="/PerformanceAppraisalNew/Performanceagreement/SearchPerformanceAgreement.aspx" title="">View All</a>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>3</td>
                                                <th>Performance Review to review</th>
                                                <td>6</td>
                                                <td>21 Days</td>
                                                <td>7 Days</td>
                                                <td>
                                                    <a class="btn btn-xs btn-info" target="_blank" href="/PerformanceAppraisalNew/Performanceagreement/SearchPerformanceAgreement.aspx" title="">View All</a>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>4</td>
                                                <th>PA to review</th>
                                                <td>8</td>
                                                <td>21 Days</td>
                                                <td>7 Days</td>
                                                <td>
                                                    <a class="btn btn-xs btn-info" target="_blank" href="/PerformanceAppraisalNew/Performanceagreement/SearchPerformanceAgreement.aspx" title="">View All</a>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                                
                            </div>

                        </div>
                    </div>


                    <div class="well well-md" style="display:none">
                        <center>
                            <h4>Event/Holiday Calendar</h4>
                        </center>
                    </div>
                    <div class="row" style="display:none">
                        <div class="col-md-12">
                            <div class="form-inline calinfo" align="center">
                                <div class="form-group">
                                    <label>Year:</label>
                                    <asp:DropDownList ID="year" runat="server" CssClass="form-control">
                                    </asp:DropDownList>
                                </div>
                                <div class="form-group">
                                    <label for="exampleInputEmail2">Month:</label>
                                    <asp:DropDownList ID="month" runat="server" CssClass="form-control">
                                    </asp:DropDownList>
                                </div>
                                <asp:Button ID="btnGo" runat="server" OnClick="btnGo_Click" Text="GO" Class="btn btn-primary btn-sm" />
                            </div>
                        </div>
                    </div>
                    <div class="row" style="display:none">

                        <div class="col-md-12">
                            <asp:UpdatePanel ID="upd1" runat="server">
                                <ContentTemplate>
                                    <div id="divEvents" runat="server">
                                        <asp:Button ID="btnEventShow" runat="server" OnClick="btnEventShow_Click" Style="display: none" />
                                        <asp:HiddenField ID="hddDate" runat="server" Value="" />
                                    </div>
                                    <div id="cal" runat="server" class="responsive-calender">
                                    </div>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="btnGo" EventName="Click" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
            </div>
            <!--sidebar notification-->
            <div class="col-md-4 blog">
                <div class="Short-notification">
                    <div class="panel">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                    <img src="ui/images/birth.gif" class="img-responsive" />
                                </div>
                                <div class="col-xs-9">
                                    <h4>Today's Birthday</h4>
                                </div>
                            </div>
                        </div>
                        <div class="panel-body">
                            <div class="panel-body birthdaylist">
                                <div id="BIRTH_LIST" runat="server"></div>
                            </div>
                        </div>
                    </div>

                    <div class="panel">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                    <i class="fa fa-male"></i>
                                </div>
                                <div class="col-xs-9">
                                    <h4>Employee on leave</h4>
                                </div>
                            </div>
                        </div>
                        <div class="panel-body leave">
                            <div id="onLeave" runat="server"></div>
                        </div>
                    </div>
                    
                    <div class="panel">
                        <div class="panel-body">
                            <div class="blog-post" id="circulars" runat="server">
                                <i class="fa fa-flag pull-left" aria-hidden="true"></i>
                                <h3>Circular And Documents</h3>
                                <div class="media">
                                </div>
                            </div>
                        </div>
                        <div class="row notification">
                            <div id="notifyPwd" runat="server" style="font-size: 14px; font-weight: bold; color: #FF3300;">
                            </div>
                            <div id="rptDivHr" runat="server" style="display: none;">
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <!--end of frame pages-->
        <div align="center">
            <div id="rptMessage" runat="server"></div>
        </div>
    </div>
    <script type="text/javascript" src="ui/js/jquery.marquee.js"></script>
    <script type="text/javascript">

        $(function () {

            $('#marquee-vertical').marquee();

        });

    </script>
    <script type="text/javascript">
        function popitup(url) {
            newwindow = window.open(url, 'Events', 'height=500,width=1000');
            if (window.focus) { newwindow.focus() }
            return false;
        }
        $(document).ready(function () {
            $(".responsive-calendar").responsiveCalendar({
                time: '2013-05',
                events: {
                    "2013-04-30": { "number": 5, "url": "http:/w3widgets.com/responsive-slider" },
                    "2013-04-26": { "number": 1, "url": "http:/w3widgets.com" },
                    "2013-05-03": { "number": 1 },
                    "2013-06-12": {}
                }
            });
        });
    </script>
    <script src="ui/js/responsive-calendar.min.js"></script>
</asp:Content>

