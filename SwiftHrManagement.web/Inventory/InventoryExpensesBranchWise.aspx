<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InventoryExpensesBranchWise.aspx.cs" Inherits="SwiftHrManagement.web.Inventory.InventoryExpensesBranchWise" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Untitled Page</title>

    
    <link href="../Css/style.css" rel="Stylesheet" type="text/css" />
    
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="style1" >
            <tr>
                <td colspan="2" style="text-align: center"><div id="divCompany" class="ReportHeader" runat="server"></div>
                <div id="Div1" class="ReportSubHeader">Inventory Expenses Report Branch Wise<br />
                    Branch Name: <asp:Label ID="lblBranchName" runat="server" CssClass="txtlbl"></asp:Label><br/>
                    
                    Department Name: <asp:Label ID="lblDeptName" runat="server" CssClass="txtlbl"></asp:Label>
                    
                    
                    </div>                   
                    <div style="text-align: right" class="ReportSubHeader">
                       Report Date : <asp:Label ID="lblprintDate" runat="server" Text="Label"  CssClass="txtlbl"></asp:Label>
                    </div>
                    
                     </td>
            </tr>
            <tr>
                <td colspan="2"><div id="rpt" runat="server"></div>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>