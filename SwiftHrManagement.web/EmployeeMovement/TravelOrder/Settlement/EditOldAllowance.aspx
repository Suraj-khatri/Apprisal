<%@ Page Title="" Language="C#" MasterPageFile="~/ProjectMaster.Master" AutoEventWireup="true" CodeBehind="EditOldAllowance.aspx.cs" Inherits="SwiftHrManagement.web.EmployeeMovement.TravelOrder.Settlement.EditOldAllowance" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../../Css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">

        function TotalAllowance() {

            var days = document.getElementById("<%=txtDays.ClientID%>").value;
            var rate = document.getElementById("<%=txtRate.ClientID%>").value;
            var total = days * rate;
            document.getElementById("<%=txtTotal.ClientID%>").value = parseInt(total);

        }
    
    </script>
    
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
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
                        Travel Order Allowance Edit</td>
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
                                <td>
                                    <asp:Label ID="LblMsg" runat="server"></asp:Label>
                                    
                                </td>
                            </tr>
                            <tr>
                                <td nowrap="nowrap">
                                    <table style="width:50%;">
                                     
                               
                                        



                 <tr>
                 
                  <td align="left">Allowance Type :   
                        <span class="required">*</span>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ErrorMessage="Required!" ControlToValidate="ddlAllowanceType" Display="Dynamic" 
                        SetFocusOnError="True" ValidationGroup="add"></asp:RequiredFieldValidator><br /> 
                  
                       
                        <asp:DropDownList ID="ddlAllowanceType" runat="server" CssClass="inputTextBox" 
                            Width="250px">
                        </asp:DropDownList>
                    </td>
                    <td align="left">Days :<span class="required">*</span><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                ControlToValidate="txtRate" ErrorMessage="Required"  
                                ValidationGroup="add"></asp:RequiredFieldValidator><br />
                            <asp:TextBox ID="txtDays" runat="server" CssClass="inputTextBox"
                                Width="100px"></asp:TextBox> 
                    </td>
                   <td align="left">Rate : <span class="required">*</span><asp:RequiredFieldValidator ID="RfvQuantity" runat="server" 
                                ControlToValidate="txtRate" ErrorMessage="Required"  
                                ValidationGroup="add"></asp:RequiredFieldValidator><br />                        
                            <asp:TextBox ID="txtRate" runat="server" CssClass="inputTextBox" 
                                Width="100px" ontextchanged="txtRate_TextChanged"></asp:TextBox>                                
                     </td>
                    <td align="left">
                               Total : <span class="required">*</span>
                               <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                ControlToValidate="txtTotal" ErrorMessage="Required"  
                                ValidationGroup="add"></asp:RequiredFieldValidator><br />                        
                                <asp:TextBox ID="txtTotal" runat="server" CssClass="inputTextBox" 
                                Width="100px" ReadOnly="true"></asp:TextBox>                                
                         
                        </td>
                  
                        <td valign="bottom">
                            <asp:Button ID="BtnAdd" runat="server" CssClass="button" Text="Add" 
                            ValidationGroup="add" Width="50" onclick="BtnAdd_Click" />
                        </td>
                    </tr>
              </table>
                                </td>
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
</asp:Content>
