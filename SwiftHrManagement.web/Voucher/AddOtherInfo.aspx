<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddOtherInfo.aspx.cs" Inherits="SwiftAssetManagement.Voucher.AddOtherInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
         <link href="../Css/style.css" rel="Stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
<table width="100%" height="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td valign="top">
		<table width="100%" height="100%" border="0" cellspacing="0" cellpadding="0">
		  <tr> 
			<td valign="top">

				<table width="100%" border="0" cellspacing="0" cellpadding="0">
					<tr>
						<td valign="top" align="center"><br>

						<!--		Begin content	-->

						
<!--################ START FORM STYLE-->
 <table class="container" border="0" cellpadding="0" cellspacing="0" width="20%">
  <tbody>
    <tr>
        <td width="1%" class="container_tl"><div></div></td>
        <td width="91%" class="container_tmid"><div>product other information</div></td>
        <td width="8%" class="container_tr"><div></div></td>
    </tr>
    <tr>
        <td class="container_l"></td>
        <td class="container_content">
        
<!--################ END FORM STYLE-->
<table border="0" cellpadding="5" cellspacing="5" class="container"> 
<tr>
    <td><asp:Label ID="LblMsg" runat="server"></asp:Label></td>
</tr>
<tr>
    <td nowrap="nowrap"> Product Name: <asp:Label ID="lblProductName" runat="server" CssClass="lblText"></asp:Label> &nbsp;&nbsp;&nbsp;Total Qty: <asp:Label ID="lblqty" runat="server" CssClass="lblText"></asp:Label>
        <asp:HiddenField ID="hdnQty" runat="server" />
    </td>
</tr>
<tr>
    <td>  
    <fieldset style="list-style:circle; list-style-type:circle; width:98%;"><legend class="style2">
        Other Information:</legend>    
        <div>        
            <table border="0" cellpadding="2" cellspacing="2">
            <tr>    
                <td nowrap valign="middle" width="52">
                    Qty:</td>            
                <td nowrap valign="middle" width="1">S.N. From:</td>
                <td nowrap valign="middle" width="27">
                    S.N. To:</td>
                <td nowrap valign="middle" width="32">
                    Batch:</td>
                
                <td nowrap width="70">
                    &nbsp;</td>
            </tr>
            <tr>         
                <td nowrap="nowrap">
                    <asp:TextBox ID="qty" runat="server" size="15" CssClass="inputTextBox"></asp:TextBox></td>      
                <td nowrap="nowrap">
                    <asp:TextBox id="sn_from" name="sn_from" size="20" runat="server" 
                        CssClass="inputTextBox" AutoPostBack="True" 
                        ontextchanged="sn_from_TextChanged"></asp:TextBox></td>
                <td nowrap="nowrap">
                    <asp:TextBox id="sn_to" name="sn_to" size="20" runat="server" 
                        CssClass="inputTextBox"></asp:TextBox></td>
                <td nowrap="nowrap">
                    <asp:TextBox ID="batch" runat="server" size="20" CssClass="inputTextBox"></asp:TextBox></td>
                
                <td nowrap="nowrap">
                    <label>
                    <asp:Button ID="BtnAdd" runat="server" CssClass="button" Text="Add" 
                        onclick="BtnAdd_Click"/>
                       
                    </label>
                </td>
           
            </tr>
            <tr>
                <td colspan="6"><div id="rpt" runat="server"></div></td>
            </tr>
             <tr>
                <td colspan="6"><div align="right">
                    <p>
                        <asp:Button ID="BtnDelProduct" runat="server" Text="Delete" CssClass="button" 
                        onclick="BtnDelProduct_Click"/>
                    </p>
                    </div></td>
            </tr>
        </table>        
        </div>
    </fieldset>
    </td> 
</tr>
<tr>
    <td>
                &nbsp;
                <asp:Button ID="Button1" runat="server" CssClass="button" 
                    onclick="Button1_Click" Text="Save" Width="75px" />
</tr>
    
</table>   
<!--################ START FORM STYLE-->
	    </td>
        <td class="container_r"></td>
  </tr>
  <tr>
    <td class="container_bl"></td>
    <td class="container_bmid"></td>
    <td class="container_br"></td>
  </tr>
	</tbody>
  </table>

<!--################ END FORM STYLE-->


	<!--		End  content	-->						</td>
					</tr>
			  </table>			</td>
		  </tr>
	</table>	</td>
  </tr>
</table>

</form>
</body>
</html>
