<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageProductBranchAssign.aspx.cs" Inherits="SwiftHrManagement.web.Inventory.Branch_And_Product_Assign.ManageProductBranchAssign" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title></title>
<style type="text/css">

.style15
{
width: 80px;
}
    </style>
<link href="../../Css/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
<form id="form2" runat="server">    
<table border="0" cellpadding="0" cellspacing="0" height="100%" width="100%">
<tr>
<td valign="top">
<table border="0" cellpadding="0" cellspacing="0" height="100%" width="100%">
<tr>
<td valign="top">
<table border="0" cellpadding="0" cellspacing="0" width="100%">
<tr>
    <td align="left" class="wellcome" valign="bottom">
        <img height="1" src="../../../../../../../images/spacer.gif" width="5" />
        <img src="../../../../../../../images/big_bullit.gif" />&nbsp;Branch&nbsp;Assign In Product<asp:ScriptManager 
            ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    </td>
</tr>
<tr>
    <td bgcolor="#999999" height="1" valign="top">
        <img height="1" src="../../../../../../../images/spacer.gif" width="90%" />
    </td>
</tr>
</table>
<table border="0" cellpadding="0" cellspacing="0" width="70%" style="">
<tr>
    <td align="center" valign="top">
        <br />
        <table border="0" cellpadding="0" cellspacing="0" class="container" width="500">
            <tr>
                <td class="container_tl" width="1%">
                    <div>
                    </div>
                </td>
                <td class="container_tmid" width="50%">
                    <div>
                        branch assign in product</td>
                <td class="container_tr" width="8%">
                    <div>
                    </div>
                </td>
            </tr>
            <tr>
                <td class="container_l">
                </td>
                <td class="container_content">
<!--################ END FORM STYLE-->                  
                        <asp:UpdatePanel ID="updatepanel1" runat="server">
                        <ContentTemplate>    
                        <table border="0" cellpadding="5" cellspacing="5" class="container" width="500">
                            <tr>
                                <td class="style11">
                                    <span class="txtlbl">Please enter valid data</span><br />
                                    <span class="required">(* Required fields)</span><br />
                                    <asp:Label ID="LblMsg" runat="server"></asp:Label>
                                    <br />
                                           <asp:HiddenField ID="HdnProduct" runat="server" />
                                </td>
                            </tr>
                            <tr>
<%--<td><asp:Label ID="lblMonth" runat="server" Text="Select month"></asp:Label></td>--%>
                                <td nowrap="nowrap">
                                    <table style="width:50%;">
                                     
                                        <tr>
                                            <td class="" nowrap="nowrap">
                                                &nbsp;</td>
                                            <td>
                                                &nbsp;</td>
                                        </tr>
                                              <tr>
                                              
                                                 <td class="" nowrap="nowrap">
                                               <div align="right" >Branch : </div> </td>
                                            <td>
                                                <span class="errormsg">
                                                <asp:DropDownList ID="DdlBranch" runat="server" CssClass="inputTextBox" 
                                                    Width="320px">
                                                </asp:DropDownList>
                                               <span class="required">*</span>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                        ErrorMessage="Required!" ControlToValidate="DdlBranch" Display="Dynamic" 
                                        SetFocusOnError="True" ValidationGroup="Branch"></asp:RequiredFieldValidator>
                                              
                                
                                        
                                        
                                         <asp:Button ID="BtnSearch" runat="server" CssClass="button" 
                                         Text="Search" ValidationGroup="Branch" Width="68px" 
                                        onclick="BtnSearch_Click" />
                                </td>
                                <td nowrap="nowrap">
                                   
                                </td>
                                <td nowrap="nowrap" class=""><div align="right"></div></td>
                                <td >
                                &nbsp;</td>
                                
                           </tr>
                                        <tr>
                                         
                                         
                                      <td nowrap="nowrap"><div align="right">Product Name:</div></td>
                                
                                <td nowrap="nowrap">
                                 <asp:TextBox ID="product" runat="server" CssClass="inputTextBox" 
                                Width="320px" ValidationGroup="Product" AutoComplete="off"
                                ></asp:TextBox>    
                                                                                          
                             <cc1:TextBoxWatermarkExtender ID="product_TextBoxWatermarkExtender" 
                                runat="server" Enabled="True" TargetControlID="product" 
                                WatermarkCssClass="watermark" WatermarkText="Auto Complete">
                            </cc1:TextBoxWatermarkExtender> 
                                                       
                             <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server"
                                DelimiterCharacters="" Enabled="true" ServicePath="~/Autocomplete.asmx" ServiceMethod="GetProductSetListForAgent"
                                TargetControlID="product" MinimumPrefixLength="1" CompletionInterval="10"
                                EnableCaching="true" CompletionListCssClass="autocompleteTextBoxLP" OnClientItemSelected="AutocompleteOnSelected" >
                             </cc1:AutoCompleteExtender>   
                             
                                    <span class="required">*</span>
                                    <asp:RequiredFieldValidator ID="Rfgrn" runat="server" 
                                        ErrorMessage="Required!" ControlToValidate="product" Display="Dynamic" 
                                        SetFocusOnError="True" ValidationGroup="Product"></asp:RequiredFieldValidator>   
                                         
                                        
                                              
                                      &nbsp; <asp:Button ID="BtnAdd" runat="server" CssClass="button" 
                                       Text="Add" ValidationGroup="Product" Width="68px" onclick="BtnAdd_Click" />
                                       </td>
                                        </tr>
                                        </table>
                                </td>
                            </tr>
                    <tr>
                        <td width="100%">
                            <div id="rpt" runat="server">
                                <asp:Table ID="Table1" runat="server" Width="100%">
                                </asp:Table>
                            </div>
                        </td>
                        <td>&nbsp;</td>
                    </tr> 
                          <tr>
                            <td align="right">
                            <asp:Panel ID="PnDelete" runat="server">
                                <div align="right">
                                    <asp:Button ID="BtnDelete" runat="server" CssClass="button" 
                                        onclick="BtnDelete_Click" Text="Delete" Width="45" />
                                        
                                    <cc1:ConfirmButtonExtender ID="BtnDelete_ConfirmButtonExtender" runat="server" 
                                        ConfirmText="Confirm To Delete ?" Enabled="True" TargetControlID="BtnDelete">
                                    </cc1:ConfirmButtonExtender>
                                    
                                </div>
                            </asp:Panel>
                            </td>
                            <td>&nbsp;</td>
                    </tr>                                                      
                    </table>
                    </ContentTemplate>
                    </asp:UpdatePanel>
<!--################ START FORM STYLE-->
                    </td>
                <td class="container_r">
                </td>
            </tr>
            <tr>
                <td class="container_bl">
                </td>
                <td class="container_bmid">
                </td>
                <td class="container_br">
                </td>
            </tr>
        </table>

<!--################ END FORM STYLE-->


<!--		End  content	-->						
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
<script language=javascript>
    function AutocompleteOnSelected(sender, e) {

        var EmpIdArray = (e._value).split("|");
        document.getElementById("<%=HdnProduct.ClientID%>").Value = EmpIdArray[1];
        document.getElementById("<%=HdnFlag.ClientID%>").Value = EmpIdArray[2]; 
    }
</script>
</html>
