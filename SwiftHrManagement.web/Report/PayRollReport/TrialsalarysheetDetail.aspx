<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TrialsalarysheetDetail.aspx.cs" Inherits="SwiftHrManagement.web.Report.PayRollReport.TrialsalarysheetDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <style type="text/css">
        .border
        {
            border:solid 1px black; 
        }
        .style2
        {
            height: 26px;
        }
        .style1
        {
            text-align: center;
        }
        </style>
    <link href="../../Css/style.css" rel="stylesheet" type="text/css" />
    <link href="../../Css/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
 <table width="100%" border="0" cellspacing="0" cellpadding="0">
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
                        <td class="style2">
                            <div align="center"><strong><font size="+1">
                                    <asp:Label ID="Lblcompany" Text= "Company" runat="server"></asp:Label><br />
                                   </font></strong>
                                   <font size="-1"><strong>
                                 <asp:Label ID="LblDesc"  Text="Description" runat="server"></asp:Label></strong></font>
                            </div>                             
                        </td>
                    </tr>
                   
                    <tr>                       
                        <td>
                            <div align="center">
                                <strong><span class=""> Salary Advice As of :</span> 
                                    <asp:Label ID="LblMonth" runat="server" Text="Label"></asp:Label><span class=""> &nbsp;</span>,&nbsp;<asp:Label ID="Lblyear"  Text="Year" runat="server"></asp:Label></strong></div>                                    
                        </td>
                        
                    </tr>
                    <tr>
                        <td align="center" class="style1">
                                <strong><span class=""> Employee Name : </span>                            
                               
                                <asp:Label 
                                ID="LblEmpName" runat="server"></asp:Label></strong></td>
                    </tr>
                    <tr>
                        <td align="center" class="style1">
                                <strong><span class=""> Employee Code :&nbsp; </span>                            
                               
                                <asp:Label 
                                ID="LblEmpId" runat="server"></asp:Label></strong></td>
                    </tr>
                    <tr>
                        <td>
                            <div align="center">                           
                            <table>                                       
                            <tr>
                                <td>
                                    <div id="rptSalary" runat="server">
                                       
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
    </table>	
    </form>
</body>
</html>
