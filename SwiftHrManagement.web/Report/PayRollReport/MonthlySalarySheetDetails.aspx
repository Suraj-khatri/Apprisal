<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="MonthlySalarySheetDetails.aspx.cs" Inherits="SwiftHrManagement.web.Report.PayRollReport.MonthlySalarySheetDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <style type="text/css">
        .style10
        {
            height: 50px;
        }
        .style11
        {
            height: 16px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
<asp:UpdatePanel ID="up" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-md-12">
                    <section class="panel">
                        <div class="panel-body">
                            <div class="text-center">
                                <strong><font size="+1">
                                <asp:Label ID="Lblcompany" Text= "Company" runat="server"></asp:Label></font></strong><br />
                                <font size="-1"><strong> <asp:Label ID="LblDesc"  Text="Description" runat="server"></asp:Label></strong></font><br />
                                <strong><span > Salary Sheet Details For the Month : </span><asp:Label ID="Lblmonth"  Text="Month" runat="server"></asp:Label></strong><br />  
                                <strong><span ><asp:Label ID="lblDepartmentName" runat="server"></asp:Label> </span></strong><br />   
                            </div>
                             <div id="rptDiv" runat="server"></div>    
                        </div>
                    </section>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
