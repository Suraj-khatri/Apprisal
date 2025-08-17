<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SwiftHRManager.Master" CodeBehind="ContributionSummery.aspx.cs" Inherits="SwiftHrManagement.web.Report.Contribution_Report.ContributionSummery" %>


<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style10
        {
            color:#666666;           
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
                                <asp:Label ID="lblHeading" Text= "myHeading" runat="server"></asp:Label><br />
                                </font></strong>
                                <font size="-1"><strong>
                                <asp:Label ID="lbldesc"  Text="test it " runat="server"></asp:Label>
                                </strong></font>   
                                
                                <asp:Panel ID="Report_ContSummery" runat="server" Visible="false"> 
	  
		                            <strong><span class="style10"> Contribution Summery Report  </span></strong>  <br />                 
		                            <span class="style10">&nbsp;Fiscal Year:&nbsp;<strong><asp:Label ID="LblFiscalyear" runat="server"></asp:Label></strong></span><br />
		                            <span class="style10">&nbsp;Month :<strong><asp:Label ID="lblMonth" runat="server"></asp:Label></strong></span><br />
		                            <span class="style10">&nbsp;Branch Name : &nbsp;<strong><asp:Label ID="lblBranchName" runat="server"></asp:Label></strong></span><br />
		                            <span class="style10">&nbsp;Dept Name : &nbsp;<strong><asp:Label ID="lblDetpsumName" runat="server"></asp:Label></strong></span><br />
		                            <span class="style10">&nbsp;Emp Name : &nbsp;<strong><asp:Label ID="lblEmpsumName" runat="server"></asp:Label></strong></span><br />
	

                                </asp:Panel>

                                <asp:Panel ID="Report_ContDetail" runat="server" Visible="false">
	
		                                <strong><span class="style10"> Contribution Details Report </span></strong> <br />
		                                <span class="style10">&nbsp;Fiscal Year:&nbsp;<strong> <asp:Label ID="LblFisclYear" runat="server"></asp:Label></strong></span><br />
		                                <span class="style10">&nbsp;Month :<strong><asp:Label ID="LblMonthdetail" runat="server"></asp:Label></strong></span><br />
		                                <span class="style10">&nbsp;Branch : &nbsp;<strong><asp:Label ID="LblBranchDetail" runat="server"></asp:Label></strong></span><br />
		                                <span class="style10">&nbsp;Department : &nbsp;<strong><asp:Label ID="lblDepartment" runat="server"></asp:Label></strong></span><br />
		                                <span class="style10">&nbsp;Employee : &nbsp;<strong><asp:Label ID="lblEmployee" runat="server"></asp:Label></strong></span><br />
    
                                 </asp:Panel>
                            </div>
                            <div id="rptDiv" runat="server"></div>    
                        </div>
                    </section>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>


<%--<table width="100%" border="0" cellspacing="0" cellpadding="0" align="center" >
    <tr>
    <td>
	<div align="center">
		    <strong><font size="+1">
			    <asp:Label ID="lblHeading" Text= "myHeading" runat="server"></asp:Label><br />
		    </font></strong>
		    <font size="-1"><strong>
			    <asp:Label ID="lbldesc"  Text="test it " runat="server"></asp:Label>
		    </strong></font>
	    </div> 
	                                
    <div align="center">	
    <asp:Panel ID="Report_ContSummery" runat="server" Visible="false"> 
	  
		    <strong><span class="style10"> Contribution Summery Report  </span></strong>  <br />                 
		    <span class="style10">&nbsp;Fiscal Year:&nbsp;<strong><asp:Label ID="LblFiscalyear" runat="server"></asp:Label></strong></span><br />
		    <span class="style10">&nbsp;Month :<strong><asp:Label ID="lblMonth" runat="server"></asp:Label></strong></span><br />
		    <span class="style10">&nbsp;Branch Name : &nbsp;<strong><asp:Label ID="lblBranchName" runat="server"></asp:Label></strong></span><br />
		    <span class="style10">&nbsp;Dept Name : &nbsp;<strong><asp:Label ID="lblDetpsumName" runat="server"></asp:Label></strong></span><br />
		    <span class="style10">&nbsp;Emp Name : &nbsp;<strong><asp:Label ID="lblEmpsumName" runat="server"></asp:Label></strong></span><br />
	

    </asp:Panel>

    <asp:Panel ID="Report_ContDetail" runat="server" Visible="false">
	
		    <strong><span class="style10"> Contribution Details Report </span></strong> <br />
		    <span class="style10">&nbsp;Fiscal Year:&nbsp;<strong> <asp:Label ID="LblFisclYear" runat="server"></asp:Label></strong></span><br />
		    <span class="style10">&nbsp;Month :<strong><asp:Label ID="LblMonthdetail" runat="server"></asp:Label></strong></span><br />
		    <span class="style10">&nbsp;Branch : &nbsp;<strong><asp:Label ID="LblBranchDetail" runat="server"></asp:Label></strong></span><br />
		    <span class="style10">&nbsp;Department : &nbsp;<strong><asp:Label ID="lblDepartment" runat="server"></asp:Label></strong></span><br />
		    <span class="style10">&nbsp;Employee : &nbsp;<strong><asp:Label ID="lblEmployee" runat="server"></asp:Label></strong></span><br />
    
     </asp:Panel>	
	 </div>                                    

   

    <br/> 
    </td>
    </tr>

    <tr>
    <td>

        <div id="rptDiv" runat="server"></div>

    </td>
    </tr>

</table>--%>
</asp:Content>

