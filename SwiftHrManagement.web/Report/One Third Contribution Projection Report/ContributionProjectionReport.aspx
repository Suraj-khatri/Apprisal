<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SwiftHRManager.Master" CodeBehind="ContributionProjectionReport.aspx.cs" Inherits="SwiftHrManagement.web.Report.One_Third_Contribution_Projection_Report.ContributionProjectionReport" %>


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
                            <div class="text-center"><strong><font size="+1">
                                <asp:Label ID="Lblcompany" Text= "Company" runat="server"></asp:Label></font></strong><br />
                                <font size="-1"><strong> <asp:Label ID="LblDesc"  Text="Description" runat="server"></asp:Label></strong></font><br />
                                 <strong><span class=""> Fiscal Year : </span> 
                                   <asp:Label ID="LblFiscalyear"  Text="" runat="server"></asp:Label></strong><br />
                               <strong><span class="">Month: </span> 
                                   <asp:Label ID="lblMonth" runat="server"></asp:Label> </strong> <br />
                                   
                                   <strong><span class="">Branch Name: </span> 
                                   <asp:Label ID="LblBranch" runat="server"></asp:Label></strong><br />
                                   
                                            <strong><span class="">Department Name: </span> 
                                   <asp:Label ID="LblDeptName" runat="server"></asp:Label></strong><br />
                                   
                                            <strong><span class="">Employee Name: </span> 
                                   <asp:Label ID="LblEmpName" runat="server"></asp:Label></strong><br />  
                            </div>
                            <br/>
                             <div id="rptDiv" runat="server"></div>    
                        </div>
                    </section>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>