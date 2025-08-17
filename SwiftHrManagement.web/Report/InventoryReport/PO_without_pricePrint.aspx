<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PO_without_pricePrint.aspx.cs" Inherits="SwiftHrManagement.web.Report.InventoryReport.PO_without_pricePrint" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <link href="../../Css/style.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            height: 59px;
        }
        .style2
        {
            height: 16px;
        }
        .style3
        {
            width: 190px;
            height: 17px;
        }
        .style4
        {
            height: 50px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
					  <table border="0" cellspacing="3" width="100%" height="30" cellpadding="0" style="margin-top:20px;" align="center">
                        <tr>
                              <td class="style4">
                                <div align="center">
                                    <strong><font size="+1">
                                    <asp:Label ID="lblHeading" Text= "Heading" runat="server"></asp:Label><br />
                                    </font></strong>
                                    <font size="-1"><strong>
                                    <asp:Label ID="lbldesc"  Text="Description" runat="server"></asp:Label></strong></font>
                                 </div>                             
                             </td>
                        </tr>
                        <tr>
                            <td>
                              <div style="text-align:center; margin-top:-5px;">
                               <font size="-1"><strong>
                                  <br />
                                <asp:Label ID="lbldesc0"  Text="Purchase Order" runat="server"></asp:Label></strong></font>
                              </div>
                            </td>
                        </tr>                     
                        <tr>
                              <td>
                                  <div style="text-align:center; margin-top:-2px;">
                                  </div>                             
                             </td>
                        </tr>
                          <td>
<div align="center">                           
<table border="0" width="650px">
        <tr>
            <td>
                <asp:Table ID="tblMain" runat="server" CellPadding="0" CellSpacing="0">
                </asp:Table>
            </td>
        </tr>   
        <tr>
            <td>
                <div id="rptDiv1" runat="server">
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <div id="rptDiv" runat="server">
                </div>
            </td>
        </tr>
</table>
</div>
</td>
</tr>
<tr><td colspan="4">&nbsp;</td></tr>
<tr>
<td>
  <div align="center">   
    <table align="center" width="650px"> 
      <tr>
         <td colspan="3" align="left" class="style1" valign="top"><asp:Label ID="Desc" runat="server"></asp:Label></td>
      </tr>
      <tr><td colspan="3">&nbsp;</td></tr>
      <tr><td colspan="3">&nbsp;</td></tr>
      <tr>
         <td class="style2"><div align="left" class="txtlbl">------------------------------------------------</div></td>                                               
        
         <td class="style2"><div align="right" class="txtlbl">-----------------------------------------------</div></td>
     </tr>
     <tr> 
       <td class="style3"><div align="left" class="txtlbl"><asp:Label runat="server" ID="lblOrderBy" CssClass="txtlbl"></asp:Label></div></td>
     
       <td class="style3"><div align="right" class="txtlbl"><asp:Label ID="lblApproveBy" runat="server" CssClass="txtlbl"></asp:Label></div></td>
     </tr>
     <tr>
       <td style="width:225px"><div align="left" class="txtlbl"><asp:Label ID="lblOrderDate" runat="server" CssClass="txtlbl"></asp:Label></div></td>
       <td><div align="right" class="txtlbl"><asp:Label ID="lblApproveDate" runat="server"  CssClass="txtlbl"></asp:Label></div></td>
     </tr>
   </table>
   </div>
   </td>
   </tr>
</table>
</form>
</body>
</html>