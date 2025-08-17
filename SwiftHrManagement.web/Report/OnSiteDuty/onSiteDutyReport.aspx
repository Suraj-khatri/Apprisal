<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master"  AutoEventWireup="true" CodeBehind="onSiteDutyReport.aspx.cs" Inherits="SwiftHrManagement.web.Report.OnSiteDuty.onSiteDutyReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
     <div class="panel">
        <header class="panel-heading">
             <asp:Label ID="lblHeading" CssClass="ReportHeader" Text= "myHeading" runat="server"></asp:Label>
            <asp:Label ID="lbldesc"  CssClass="ReportHeader" runat="server"></asp:Label><br />
             <span class="ReportSubHeader"> OnSite Duty Summary Report </span>
        </header>
        <div class="panel-body">
            <div class="row">
                <div class="col-md-12 form-group">
                    <label>
                    <span class="txtlbl">&nbsp;Branch Name : </span>
                     <asp:Label ID="lblBranchName" class="txtlbl" runat="server"></asp:Label>
                    </label>
                </div>
                <div class="col-md-12 form-group">
                    <label>
                    <span class="txtlbl">&nbsp;Departmant Name : </span>
                    <asp:Label ID="lblDeptName" class="txtlbl" runat="server"></asp:Label>
                    </label>
                </div>
                <div class="col-md-12 form-group">
                    <label>
                    Report From Date: 
                     <asp:Label ID="From_Date1" CssClass="txtlbl"  runat="server"></asp:Label> To Date: 
                     <asp:Label ID="To_Date1" CssClass="txtlbl" runat="server"></asp:Label>
                    </label>
                </div>
               
                                        
            </div>
            <div id="rptDiv" runat="server"></div>  
        </div>
    </div>

	
	
	
	
</asp:Content>

