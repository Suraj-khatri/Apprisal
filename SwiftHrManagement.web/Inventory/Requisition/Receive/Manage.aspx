<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="SwiftAssetManagement.Inventory.Requisition.Receive.Manage" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
 <div class="row">
     <div class="col-md-12">
         <section class="panel">
             <header class="panel-heading">
                 Modify Product Receival
             </header>
             <div class="panel-body">
                 <div class="form-group">
                        <div class="col-md-12">
                            <span class="txtlbl">Please enter valid data!</span> <span class="errormsg">(* are required fields!)</span>
                                <asp:Label ID="LblMsg" runat="server"></asp:Label>
                                <asp:HiddenField ID ="hdnfldAppid" runat="server" />
                        </div>
                 </div>
             </div>
         </section>
     </div>
 </div>
    <td width="91%" class="container_tmid"><div></div></td>
    <td width="8%" class="container_tr"><div></div></td>
  </tr>
      <tr>
        <td class="container_l"></td>
        <td class="container_content">
<!--################ END FORM STYLE-->
<table border="0" cellpadding="5" cellspacing="5" class="container">
        
        <tr>
            <td nowrap="nowrap"><div align="right" class="wellcome">Product Name :</div></td>
            <td nowrap="nowrap" align="left">
                <asp:Label ID="Product" runat="server" style="color:#008000;font-weight:bold;"></asp:Label>
            </td>
        </tr>
        <tr>
            <td nowrap="nowrap" colspan="2">
                <asp:CompareValidator ID="CompareValidator1" runat="server" 
                    ControlToCompare="TxtDeliveredquantity" ControlToValidate="TxtRecQuantity" 
                    Display="Dynamic" 
                    ErrorMessage="Received Quantity Cannot Be Greater Than Delivered Quantity" 
                    Operator="LessThanEqual" Type="Integer" ValidationGroup="req">
                </asp:CompareValidator>
                <asp:RequiredFieldValidator ID="rv" runat="server" 
                                ControlToValidate="TxtRecQuantity" Display="None" ErrorMessage="*" 
                                SetFocusOnError="True" ValidationGroup="req">
                </asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
             <td nowrap="nowrap"><div align="right">Total Dispatched QTY :</div></td>
             <td nowrap="nowrap">
                        <asp:TextBox ID="TxtDeliveredquantity" runat="server" CssClass="inputTextBox" 
                            Width="150px" Enabled="false"></asp:TextBox>
                        <cc1:FilteredTextBoxExtender ID="TxtDeliveredquantity_FilteredTextBoxExtender" 
                            runat="server" Enabled="True" FilterType="Numbers" 
                            TargetControlID="TxtDeliveredquantity">
                        </cc1:FilteredTextBoxExtender>
            </td>             
        <tr>
            <td nowrap="nowrap"><div align="right">Total Received QTY :</div></td>
            <td nowrap="nowrap">
                            <asp:TextBox ID="TxtRecQuantity" runat="server" CssClass="inputTextBox" 
                                Width="150px" Enabled="false"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="TxtRecQuantity_FilteredTextBoxExtender" 
                                runat="server" Enabled="True" FilterType="Numbers" 
                                TargetControlID="TxtRecQuantity">
                            </cc1:FilteredTextBoxExtender>
                            <span class="errormsg">*</span>
            </td>
        </tr>
        <tr>
            <td nowrap="nowrap"><div align="right">Remain To Receive :</div></td>
            <td nowrap="nowrap">
                            <asp:TextBox ID="txtRemainToReceive" runat="server" CssClass="inputTextBox" 
                                Width="150px"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" 
                                runat="server" Enabled="True" FilterType="Numbers" 
                                TargetControlID="txtRemainToReceive">
                            </cc1:FilteredTextBoxExtender>
                            <span class="errormsg">*</span>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="BtnSave" runat="server" CssClass="button" 
                Text="Save" ValidationGroup="req" onclick="BtnSave_Click" />
                <cc1:ConfirmButtonExtender ID="BtnSave_ConfirmButtonExtender" runat="server" 
                    ConfirmText="Confirm To Save?" Enabled="True" TargetControlID="BtnSave">
                </cc1:ConfirmButtonExtender>
                &nbsp;<asp:Button ID="BtnCancel" runat="server" CssClass="button" 
                    Text="&lt;&lt;Back" ValidationGroup="chart"/>
            </td>
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
</asp:Content>

