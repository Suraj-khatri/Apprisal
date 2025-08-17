<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SwiftHRManager.Master" CodeBehind="AppraisalAllInfo.aspx.cs" Inherits="SwiftHrManagement.web.PerformanceAppraisal.AppraisalAllInfo" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Import Namespace="System.Data" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%-- <style>
    div.floating-menu {position:fixed;background:#fff4c8;border:1px solid #ffcc00;width:205px;z-index:100; margin-left:890px;}
    div.floating-menu a, div.floating-menu h3 {display:block;margin:0 0.5em; }
</style>--%>
    <%--<script language = "javascript">

//function GetCtrlId() {
//    return "<%=ratingCalculateMain.ClientID%>";
//}

//function GetDivOveralllId() {
//    return "<%=DivOverall.ClientID%>";
//}

</script>--%>

    <style type="text/css">
        .borderless td, .borderless th {
            border: none;
        }

        .borderlesscolumn {
            border-top: none !important;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">

    <%--<div class="floating-menu" align="center">
        <b>Percentage: </b>
        <div ID="ratingCalculateMain" runat="server"></div>
        <b>Overall Rating: </b>
        <div ID="DivOverall" runat="server"></div>
    </div>
    --%>



    <% int appraisalId = 0;
       appraisalId = GetAppraisalId();
       int positionId = 0;
       positionId = GetPositionId();
       int ratingTypeId = 0;
       ratingTypeId = GetRatingTypeId();
       int EmpIdFromSupervisor = 0;
       EmpIdFromSupervisor = GetEmployeeId();
 

    %>
    <div class="row">
        <div class="col-md-12">
            <section class="panel">
                <header class="panel-heading">
                    <i class="fa fa-caret-right" aria-hidden="true"></i>  
                    Appraisal FeedBack
                </header>
                <div class="panel-body">
                    <div class="form-group">
                        <asp:Label ID="LblEmpName" runat="server" CssClass="wellcome"></asp:Label>
                    </div>
                    <div class="form-group table-responsive">
                        <table class="table borderless">
                            <tbody>
                                <tr>
                                    <td class="borderlesscolumn">Employee Name:&nbsp;<asp:Label ID="lblEmployeeName" runat="server" class="txtlbl"></asp:Label></td>
                                    <td class="borderlesscolumn">Branch Name:&nbsp;<asp:Label ID="lblBranchName" runat="server" class="txtlbl"></asp:Label></td>
                                    <td class="borderlesscolumn">Department Name:&nbsp;<asp:Label ID="lblDeptName" runat="server" class="txtlbl"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="borderlesscolumn">Designation:&nbsp;<asp:Label ID="lblDesignation" runat="server" class="txtlbl"></asp:Label></td>
                                    <td class="borderlesscolumn">Functional Title:&nbsp;<asp:Label ID="lblFunctionalTitel" runat="server" class="txtlbl"></asp:Label></td>
                                    <td class="borderlesscolumn">Total Period in the Bank(In Days):&nbsp;<asp:Label ID="lblTotalBankPeriod" runat="server" class="txtlbl"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="borderlesscolumn">Review Period From:&nbsp;<asp:Label ID="lblPeriodFrom" runat="server" class="txtlbl"></asp:Label></td>
                                    <td class="borderlesscolumn">Review Period To:&nbsp;<asp:Label ID="lblPeriodTo" runat="server" class="txtlbl"></asp:Label></td>
                                    <td class="borderlesscolumn">Date of Previous Appraisal (if any):&nbsp;<asp:Label ID="lblPreviousAppraisal" runat="server" class="txtlbl"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="borderlesscolumn">Supervisor:&nbsp;<asp:Label ID="lblSupervisor" runat="server" class="txtlbl"></asp:Label></td>
                                    <td class="borderlesscolumn">Reviewer:&nbsp;<asp:Label ID="lblReviewer" runat="server" class="txtlbl"></asp:Label></td>
                                    <td class="borderlesscolumn">&nbsp;</td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                    <div class="form-group">
                        <cc1:TabContainer ID="TabContainer2" runat="server" CssClass="visoft__tab_xpie7"> <!--ActiveTabIndex="0"-->
         
         <cc1:TabPanel ID="TabAppraiseeTask" runat="server" HeaderText="Appraisee's Task">
            <HeaderTemplate>
               Appraisee's Task
            </HeaderTemplate>
            <ContentTemplate>
             <asp:UpdatePanel ID="updatePanel9" runat="server">
               <ContentTemplate>
                 <iframe src="/PerformanceAppraisal/AppraisalFeedback/AppraiseeTask.aspx?appraisalId=<% Response.Write(appraisalId); %>&positionId=<% Response.Write(positionId); %>&employeeId=<% Response.Write(GetEmployeeId()); %>&ratingTypeId=<% Response.Write(ratingTypeId); %>&EmpIdType=<% Response.Write(GetEmployeeTypeId()); %>" 
                  frameborder="0" height="1000px" width="100%" > </iframe>            
                </ContentTemplate>
                    </asp:UpdatePanel>
            </ContentTemplate>
</cc1:TabPanel>  
            
        <cc1:TabPanel runat="server" HeaderText="Appraisee" ID="TabPanel1">
             <ContentTemplate>
                    <asp:UpdatePanel ID="updatePanel1" runat="server">
                        <ContentTemplate>
  <iframe src="/PerformanceAppraisal/Details/ManageMatrix.aspx?appraisalId=<% Response.Write(appraisalId); %>&positionId=<% Response.Write(positionId); %>&employeeId=<% Response.Write(GetEmployeeId()); %>&ratingTypeId=<% Response.Write(ratingTypeId);%> " 
                            frameborder="0" height="1000px" width="100%"> </iframe>
                        </ContentTemplate>
                    </asp:UpdatePanel>
            </ContentTemplate>
        
            </cc1:TabPanel>
        

        <cc1:TabPanel ID="TabPanel10" runat="server" HeaderText="Supervisor">
            <ContentTemplate>
            <asp:UpdatePanel ID="updatePanel10" runat="server">
                        <ContentTemplate>
                   <iframe src="/PerformanceAppraisal/AppraisalFeedback/SupervisorFeedback.aspx?appraisalId=<% Response.Write(appraisalId); %>&positionId=<% Response.Write(positionId); %>&employeeId=<% Response.Write(GetEmployeeId()); %>&ratingTypeId=<% Response.Write(ratingTypeId); %>&EmpIdType=<% Response.Write(GetEmployeeTypeId()); %>" 
                   frameborder="0" height="1000px" width="100%" > </iframe>
                </ContentTemplate>
                    </asp:UpdatePanel>
                
                
            </ContentTemplate>
        
</cc1:TabPanel>
        
        <cc1:TabPanel ID="TabPanel3" runat="server" HeaderText="Reviewer">
            <ContentTemplate>
            <asp:UpdatePanel ID="updatePanel4" runat="server">
                        <ContentTemplate>
                 <iframe src="/PerformanceAppraisal/AppraisalFeedback/ReviewerFeedback.aspx?appraisalId=<% Response.Write(appraisalId); %>&positionId=<% Response.Write(positionId); %>&employeeId=<% Response.Write(GetEmployeeId()); %>&ratingTypeId=<% Response.Write(ratingTypeId); %>&EmpIdType=<% Response.Write(GetEmployeeTypeId()); %>" 
                 frameborder="0" height="1000px" width="100%" > </iframe>
            
                </ContentTemplate>
                    </asp:UpdatePanel>
            
            
            </ContentTemplate>
        
</cc1:TabPanel>
        <cc1:TabPanel ID="TabPanel4" runat="server" HeaderText="Review Committee">
            <ContentTemplate>
             <asp:UpdatePanel ID="updatePanel5" runat="server">
                        <ContentTemplate>
                 <iframe src="/PerformanceAppraisal/AppraisalFeedback/HRFeedback.aspx?appraisalId=<% Response.Write(appraisalId); %>&positionId=<% Response.Write(positionId); %>&employeeId=<% Response.Write(GetEmployeeId()); %>&ratingTypeId=<% Response.Write(ratingTypeId); %>" 
                 frameborder="0" height="1000px" width="100%" > </iframe>
            
                </ContentTemplate>
                    </asp:UpdatePanel>
            
            
            </ContentTemplate>
        
</cc1:TabPanel>
        
        <cc1:TabPanel ID="TabPanel6" runat="server" HeaderText="CEO">
            <HeaderTemplate>
                HR Department
            </HeaderTemplate>
            <ContentTemplate>
             <asp:UpdatePanel ID="updatePanel6" runat="server">
                        <ContentTemplate>
                 <iframe src="/PerformanceAppraisal/AppraisalFeedback/CEOFeedback.aspx?appraisalId=<% Response.Write(appraisalId); %>&positionId=<% Response.Write(positionId); %>&employeeId=<% Response.Write(GetEmployeeId()); %>&ratingTypeId=<% Response.Write(ratingTypeId); %>"
                  frameborder="0" height="1000px" width="100%" > </iframe>
                                </ContentTemplate>
                                </asp:UpdatePanel>
                            </ContentTemplate>
                        </cc1:TabPanel>
                    </cc1:TabContainer>
                    </div>
                </div>
            </section>
        </div>
    </div>
</asp:Content>

