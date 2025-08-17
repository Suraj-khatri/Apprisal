<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Gatepassreport.aspx.cs" Inherits="SwiftHrManagement.web.Report.Gatepassreport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Gatepass Report</title>

    <link href="../Css/style.css" rel="stylesheet" type="text/css" />
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
                                    <asp:Label ID="lbldesc"  Text="Gatepass" runat="server"></asp:Label>
                                    <br />
                                    </strong></font>
                                 </div>                             
                             </td>
                        </tr>
                        <tr>
                            <td>
                              <div style="text-align:center; margin-top:-5px;">
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
<table border="0" style="width: 442px">
        <tr>
            <td align="left">
                                 <span class="txtlbl">Gatepass No : </span>
                                  <asp:Label ID="lblGatepassno" runat="server" 
                                      CssClass="txtlbl"></asp:Label></td>
            <td align="right">
                                 <span class="txtlbl">Gatepass Date : </span><asp:Label ID="lbldeliveredDate" runat="server" 
                                      CssClass="txtlbl"></asp:Label></td>
        </tr>   
        <tr>
            <td align="left">
                                 <span class="txtlbl">Branch : </span>
                                  <asp:Label ID="lblbranch" runat="server" 
                                      CssClass="txtlbl"></asp:Label></td>
            <td align="right">
                                 &nbsp;</td>
        </tr>   
        <tr>
            <td align="left">
                                  &nbsp;</td>
            <td align="right">
                                  &nbsp;</td>
        </tr>   
        <tr>
            <td colspan="2">
                <asp:Table ID="tblMain" runat="server" CellPadding="0" CellSpacing="0">
                </asp:Table>
            </td>
        </tr>   
        <tr>
            <td colspan="2">
                <div id="rptDiv1" runat="server">
                </div>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <div id="rptDiv" runat="server">
                </div>
            </td>
        </tr>
        <tr>
            <td colspan="2" align "left" style="text-align: left">
                <br />
                <span class="txtlbl">Narration :</span><br />
                <asp:Label ID="lbloutMsg" runat="server" CssClass="label"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="2" align "left" style="text-align: left">
                &nbsp;</td>
        </tr>
        <tr>
            <td align "left" style="text-align: left">
                ---------------------------------------------                 <br />
                <asp:Label 
               ID="lblpreparedby1" runat="server"  CssClass="txtlbl">Delivered To :</asp:Label>
            &nbsp;</td>
            <td align "left" style="text-align: right">
                -                ------------------------------------------------------<br />
                <asp:Label 
               ID="lblpreparedby0" runat="server"  CssClass="txtlbl">Prepared by :</asp:Label>
            &nbsp;</td>
        </tr>
        <tr>
            <td align "left" style="text-align: left">
                <asp:Label runat="server" ID="lbldeliveredto" CssClass="txtlbl"></asp:Label></td>
            <td align "left" style="text-align: right">
                <asp:Label 
               ID="lblpreparedby" runat="server"  CssClass="txtlbl"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align "left" style="text-align: left">
                &nbsp;</td>
            <td align "left" style="text-align: right">
                <asp:Label ID="lblPreparedDate" runat="server"  CssClass="txtlbl"></asp:Label>
            </td>
        </tr>
        </table>
</div>
</td>
</tr>
</table>
</form>
</body>
</html>
