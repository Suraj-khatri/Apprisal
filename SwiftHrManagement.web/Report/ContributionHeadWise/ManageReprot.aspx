<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SwiftHRManager.Master"  CodeBehind="ManageReprot.aspx.cs" Inherits="SwiftHrManagement.web.Report.ContributionHeadWise.ManageReprot" %>

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

<table width="100%" border="0" cellspacing="0" cellpadding="0" align="center" >
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
   
	  
	    <strong><span class="style10"> Contribution Summery Report  </span></strong>  <br />                 
	    <span class="style10">&nbsp;Fiscal Year:&nbsp;<strong><asp:Label ID="LblFiscalyear" runat="server"></asp:Label></strong></span><br />
	   <span class="style10">&nbsp;Branch Name : &nbsp;<strong><asp:Label ID="lblBranchName" runat="server"></asp:Label></strong></span><br />
	    <span class="style10">&nbsp;Dept Name : &nbsp;<strong><asp:Label ID="lblDeptName" runat="server"></asp:Label></strong></span><br />
	    <span class="style10">&nbsp;Report  : &nbsp;<strong><asp:Label ID="lblReport" runat="server"></asp:Label></strong></span><br />

  </div>                                    

   

    <br/> 
    </td>
    </tr>

    <tr>
    <td>

        <div id="rptDiv" runat="server"></div>

    </td>
    </tr>

</table>
</asp:Content>
