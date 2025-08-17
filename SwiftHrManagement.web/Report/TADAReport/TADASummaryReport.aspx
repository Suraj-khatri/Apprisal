<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="TADASummaryReport.aspx.cs" Inherits="SwiftHrManagement.web.Report.TADAReport.TADASummaryReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">

<%--<table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td valign="top">
		    <table width="100%" border="0" cellspacing="0" cellpadding="0">
		      <tr> 
			    <td valign="top">
				<table width="100%" border="0" cellspacing="0" cellpadding="0">
				    <tr>
					<td valign="top">
					<table border="0" cellspacing="3" width="100%" cellpadding="0" style="margin-top:20px;" align="center">
                    <tr>
                        <td class="style10">
                            <div align="center"><strong><font size="+1">
                                    <asp:Label ID="Lblcompany" Text= "Company" runat="server"></asp:Label><br />
                                   </font></strong>
                                   <font size="-1"><strong>
                                 <asp:Label ID="LblDesc"  Text="Description" runat="server"></asp:Label></strong></font><br />
                                  <strong><span class=""> Travel Authorisation Summary Report </span></strong><br /> <br />                                
                            </div>                             
                        </td>
                    </tr>  
                     <tr>
                        <td>
                            <div align="center">                           
                                <table border="0">  
                                    <tr>
                                        <td>
                                            <div id="divreport" runat="server">
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                    </table>
				    </td>
			    </tr>
				</table>
			    </td>
		      </tr>
	        </table>	
        </td>
      </tr>
    </table>	--%>
<asp:UpdatePanel ID="up" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-md-12">
                    <section class="panel">
                        <div class="panel-body">
                            <div class="text-center">
				                    <strong><font size="+1">
                                    <asp:Label ID="Lblcompany" Text= "Company" runat="server"></asp:Label><br />
                                    </font></strong>
                                    <font size="-1"><strong>
                                    <asp:Label ID="LblDesc"  Text="Description" runat="server"></asp:Label></strong></font><br />
                                    <strong><span class=""> Travel Authorisation Summary Report </span></strong><br /> <br />     
                            </div>
                             <div id="divreport" runat="server" class="table-responsive branchlist"></div>    
                        </div>
                    </section>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>





                         



</asp:Content>
