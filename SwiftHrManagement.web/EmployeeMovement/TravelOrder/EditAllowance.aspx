<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/ProjectMaster.Master" CodeBehind="EditAllowance.aspx.cs" Inherits="SwiftHrManagement.web.EmployeeMovement.TravelOrder.EditAllowance" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

  <script type="text/javascript">
      function Total() {
          var perdays = document.getElementById("<%=txtPerDays.ClientID%>").value;
          var days = document.getElementById("<%=txtDays.ClientID%>").value;
          document.getElementById("<%=txtTotal.ClientID%>").value = parseInt(perdays) * parseInt(days);
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
                            Width="150px">
                        </asp:DropDownList>
                    </td>
                     <td align="left"> Days : <span class="required">*</span>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                ControlToValidate="txtDays" ErrorMessage="Required"  
                                ValidationGroup="add"></asp:RequiredFieldValidator><br />                        
                            <asp:TextBox ID="txtDays" runat="server" CssClass="inputTextBox" 
                                Width="100px"></asp:TextBox>                                
                     </td>
                   <td align="left">Per Days : <span class="required">*</span><asp:RequiredFieldValidator ID="RfvQuantity" runat="server" 
                                ControlToValidate="txtPerDays" ErrorMessage="Required"  
                                ValidationGroup="add"></asp:RequiredFieldValidator><br />                        
                            <asp:TextBox ID="txtPerDays" runat="server" CssClass="inputTextBox" 
                                Width="100px"></asp:TextBox>                                
                     </td>
                    <td align="left">
                               Total : <span class="required">*</span>
                               <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                ControlToValidate="txtTotal" ErrorMessage="Required"  
                                ValidationGroup="add"></asp:RequiredFieldValidator><br />                        
                                <asp:TextBox ID="txtTotal" runat="server" CssClass="inputTextBox" 
                                Width="100px"></asp:TextBox>                                
                         
                        </td>
                  
                        <td valign="bottom">
                            <asp:Button ID="BtnAdd" runat="server" CssClass="button" Text="Add" 
                            ValidationGroup="add" onclick="BtnAdd_Click" Width="50" />
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