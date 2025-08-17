<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="DirectDispatch.aspx.cs" Inherits="SwiftHrManagement.web.Inventory.Requisition.DirectDispatch" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script language="javascript" type="text/javascript">
        function AutocompleteOnSelected(sender, e) {

            var EmpIdArray = (e._value).split("|");
            document.getElementById("<%=hdnProductId.ClientID%>").Value = EmpIdArray[1];

        }
        function AutocompleteOnSelected(sender, e) {
            var EmpIdArray = (e._value).split("|");
            document.getElementById("<%=HdnEmpid.ClientID%>").Value = EmpIdArray[1];
        }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <asp:UpdatePanel ID="UPDPANEL" runat="server">
    <ContentTemplate>
<table width="100%" height="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td valign="top">
        <table width="100%" height="100%" border="0" cellspacing="0" cellpadding="0">
          <tr> 
	        <td valign="top">
		        <table width="100%" border="0" cellspacing="0" cellpadding="0">
			        <tr>
				        <td valign="bottom" class="wellcome"><img src="/images/spacer.gif" width="5" height="1">
				        <img src="/images/big_bullit.gif">&nbsp;Place Requisition-Manual</td>
			        </tr>
			        <tr>
				        <td valign="top" bgcolor="#999999" height="1"><img src="/images/spacer.gif" width="100%" height="1"></td>
			        </tr>
		        </table>
		        <table width="80%" border="0" cellspacing="0" cellpadding="0">
			    <tr>
				    <td valign="top" align="center">
				
				
<!--################ START FORM STYLE-->
  <table class="container" border="0" cellpadding="0" cellspacing="0" width="35%">
  <tbody><tr>
    <td width="1%" class="container_tl"><div></div></td>
    <td width="91%" class="container_tmid"><div>&nbsp;Place Requisition-Manual</div></td>
    <td width="8%" class="container_tr"><div></div></td>
  </tr>
      <tr>
        <td class="container_l"></td>
        <td class="container_content">
        
<!--################ END FORM STYLE-->
        <table border="0" cellpadding="2" cellspacing="2" class="container">
        <tr>
            <td colspan="2">
                <span class="txtlbl">Please enter valid data! <span class="errormsg">(* are required fields!)</span><br />
                <asp:Label ID="LblMsg" runat="server" CssClass="errormsg"></asp:Label>
                <asp:HiddenField ID = "hdnitem" runat="server" />                         
                <asp:HiddenField ID="hdnProductId" runat="server" />
                           
            </td>
        </tr>
        <tr>
            <td nowrap="nowrap">Branch Name:<br />   
                <asp:DropDownList ID="branch" runat="server" CssClass="CMBDesign" Width="300px" 
                    AutoPostBack="True" onselectedindexchanged="branch_SelectedIndexChanged"></asp:DropDownList>&nbsp;<span class="errormsg">*</span>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                ControlToValidate="branch" ErrorMessage="Required!" 
                                SetFocusOnError="True" ValidationGroup="req" Display="Dynamic"></asp:RequiredFieldValidator> 
            </td>
            <td nowrap="nowrap">Department Name:<br />   
                <asp:DropDownList ID="DEPT" runat="server" CssClass="CMBDesign" Width="350px"></asp:DropDownList>&nbsp;<span class="errormsg">*</span>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                ControlToValidate="DEPT" ErrorMessage="Required!" 
                                SetFocusOnError="True" ValidationGroup="req" Display="Dynamic"></asp:RequiredFieldValidator> 
            </td>
        </tr>
        <tr>
            <td nowrap="nowrap" colspan="2">                
                <asp:Panel ID="ProductListPanel" runat="server" GroupingText="Product Information" CssClass="legend">
                    <table cellpadding="2" cellspacing="2">
                    <tr>
                        <td align="left">Product Name:<asp:RequiredFieldValidator ID="Rfvproduct" runat="server" 
                                ControlToValidate="product" ErrorMessage="Required" 
                                SetFocusOnError="True" ValidationGroup="add"></asp:RequiredFieldValidator><br /> 
                                                     
                            <asp:TextBox ID="product" runat="server" CssClass="inputTextBox" 
                                Width="400px" ValidationGroup="requistion" AutoComplete="off" 
                                ontextchanged="product_TextChanged" AutoPostBack="True" ></asp:TextBox>    
                                                                                          
                             <cc1:TextBoxWatermarkExtender ID="product_TextBoxWatermarkExtender" 
                                runat="server" Enabled="True" TargetControlID="product" 
                                WatermarkCssClass="watermark" WatermarkText="Auto Complete">
                            </cc1:TextBoxWatermarkExtender> 
                                                       
                             <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server"
                                DelimiterCharacters="" Enabled="true" ServicePath="~/Autocomplete.asmx" ServiceMethod="GetProductList"
                                TargetControlID="product" MinimumPrefixLength="1" CompletionInterval="10"
                                EnableCaching="true" CompletionListCssClass="autocompleteTextBoxLP" OnClientItemSelected="AutocompleteOnSelected" >
                             </cc1:AutoCompleteExtender>                   
                        </td>
                        <td align="left">Unit of Mesurement :<br />
                             <asp:TextBox ID="txtUnit" runat="server" CssClass="inputTextBox" 
                                Width="100px" ValidationGroup="requistion"></asp:TextBox>
                        </td>
                        <td align="left">Qty :<asp:RequiredFieldValidator ID="RfvQuantity" runat="server" 
                                ControlToValidate="quantity" ErrorMessage="Required"  
                                ValidationGroup="add"></asp:RequiredFieldValidator><br />                        
                            <asp:TextBox ID="quantity" runat="server" CssClass="inputTextBox" 
                                Width="100px"></asp:TextBox>                                
                            <cc1:FilteredTextBoxExtender ID="quantity_FilteredTextBoxExtender" 
                                runat="server" Enabled="True" FilterType="Numbers" TargetControlID="quantity">
                            </cc1:FilteredTextBoxExtender>                            
                        </td>
                        <td valign="bottom">
                            <asp:Button ID="BtnAdd" runat="server" CssClass="button" Text="Add" 
                            ValidationGroup="add" onclick="BtnAdd_Click" Width="50" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" width="100%">
                            <div id="rpt" runat="server">
                                <asp:Table ID="Table1" runat="server" Width="100%">
                                </asp:Table>
                            </div>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                            <td colspan="3" align="right">
                            <asp:Panel ID="PnDelete" runat="server">
                                <div align="right">
                                    <asp:Button ID="BtnDelete" runat="server" CssClass="button" 
                                        onclick="BtnDelete_Click" Text="Delete" Width="50" />
                                        
                                    <cc1:ConfirmButtonExtender ID="BtnDelete_ConfirmButtonExtender" runat="server" 
                                        ConfirmText="Confirm To Delete ?" Enabled="True" TargetControlID="BtnDelete">
                                    </cc1:ConfirmButtonExtender>
                                    
                                </div>
                            </asp:Panel>
                            </td>
                            <td>&nbsp;</td>
                    </tr>
                    </table> 
                </asp:Panel>                   
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Panel ID="downPanel" runat="server" GroupingText="Other Information" CssClass="">
                <table cellpadding="2px" cellspacing="2px">
                <tr>
                    <td valign="top" nowrap="nowrap"><div align="right">Requisition Message:</div></td>
                    <td nowrap="nowrap" align="left" valign="top" colspan="3">
                    
                         <asp:TextBox ID="TxtMessage" runat="server" CssClass="inputTextBox" 
                        Height="45px" TextMode="MultiLine" Width="550px"></asp:TextBox>
                        <span class="required">*</span>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ControlToValidate="TxtMessage" ErrorMessage="Required!" 
                                SetFocusOnError="True" ValidationGroup="req" Display="Dynamic"></asp:RequiredFieldValidator>   
                    </td>                    
                </tr>    
                <tr>
                    <td nowrap="nowrap"><div align="right">Request With Branch:</div></td>
                    <td nowrap="nowrap" align="left" colspan="3">
                        <span class="errormsg"><asp:DropDownList ID="DdlBranchRqe" runat="server" CssClass="CMBDesign" 
                                Width="553px">
                        </asp:DropDownList>&nbsp;*</span>  
                                              
                        <asp:RequiredFieldValidator ID="rfvDdlForward" runat="server" 
                            ControlToValidate="DdlBranchRqe" ErrorMessage="Required!" 
                            SetFocusOnError="True" ValidationGroup="req" Display="Dynamic"></asp:RequiredFieldValidator>
                    </td>                              
                </tr>
                 <tr>
                     <td nowrap="nowrap"><div align="right">Recommend With:</div></td>
                     <td nowrap="nowrap" align="left" >
                     
                            <asp:TextBox ID="TxtEmpname" runat="server" CssClass="inputTextBox" 
                                Width="550px" AutoComplete="off"></asp:TextBox>&nbsp;<span class="errormsg">*</span>
                                
                             <asp:RequiredFieldValidator ID="rfvEmpid" runat="server" 
                                ControlToValidate="TxtEmpname" ErrorMessage="Required!" 
                                SetFocusOnError="True" ValidationGroup="req" Display="Dynamic"></asp:RequiredFieldValidator>   
                                 
                            <cc1:TextBoxWatermarkExtender ID="TxtEmpname_TextBoxWatermarkExtender" 
                                runat="server" Enabled="True" TargetControlID="TxtEmpname" 
                                WatermarkCssClass="watermark" WatermarkText="Auto Complete">
                            </cc1:TextBoxWatermarkExtender>
                            
                            <cc1:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server" 
                                CompletionInterval="10" CompletionListCssClass="autocompleteTextBoxLP" 
                                DelimiterCharacters="" EnableCaching="true" Enabled="true" 
                                MinimumPrefixLength="1" OnClientItemSelected="AutocompleteOnSelected" 
                                ServiceMethod="GetEmployeeList" ServicePath="~/Autocomplete.asmx" 
                                TargetControlID="TxtEmpname">
                            </cc1:AutoCompleteExtender>
                            <br />
                            <asp:HiddenField ID="HdnEmpid" runat="server" />                           
                    </td>
                </tr>
                <tr>
                    <td nowrap="nowrap"><div align="right">Priority:</div></td>
                    <td nowrap="nowrap" align="left">
                         <asp:DropDownList ID="Ddlpriority" runat="server" CssClass="inputTextBox" Width="100">
                                     <asp:ListItem Value="N">Normal</asp:ListItem>
                                     <asp:ListItem Value="L">Low</asp:ListItem>
                                     <asp:ListItem Value="H">High</asp:ListItem>
                         </asp:DropDownList>
                    </td>   
                </tr>
                <%--
                <tr>
                     <td nowrap="nowrap"><div align="right">Recommend With Employee:</div></td>
                     <td nowrap="nowrap" width="380px">                     
                         <asp:DropDownList ID="DdlEmpName" runat="server" CssClass="CMBDesign" Width="350px">
                         </asp:DropDownList> <span class="required">*</span><asp:RequiredFieldValidator ID="RequiredFieldValidator4"
                             runat="server" ErrorMessage="Required!" ControlToValidate="DdlEmpName" 
                             Display="Dynamic" SetFocusOnError="True" ValidationGroup="req"></asp:RequiredFieldValidator></td>
                     <td nowrap="nowrap"><div align="right">Priority:</div></td>
                    <td nowrap="nowrap" align="left">
                         <asp:DropDownList ID="Ddlpriority" runat="server" CssClass="inputTextBox" Width="100">
                                     <asp:ListItem Value="N">Normal</asp:ListItem>
                                     <asp:ListItem Value="L">Low</asp:ListItem>
                                     <asp:ListItem Value="H">High</asp:ListItem>
                         </asp:DropDownList>
                    </td>    
                </tr>--%>
                </table>
                </asp:Panel>
            </td>
        </tr> 
    
        <tr>
            <td align="left" colspan="2">
                <asp:Button ID="btnSave" runat="server" CssClass="button" 
                    Text="Save" onclick="btnSave_Click" ValidationGroup="req" Width="75px"/>
                <cc1:ConfirmButtonExtender ID="btnSave_ConfirmButtonExtender" runat="server" 
                    ConfirmText="Confirm To Save ?" Enabled="True" TargetControlID="btnSave">
                </cc1:ConfirmButtonExtender>
                &nbsp;<asp:Button ID="BtnCancel" runat="server" CssClass="button" 
                    Text="&lt;&lt;Back" ValidationGroup="chart" Width="75px"/>
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
<!--################ START FORM STYLE-->
                        </td>
                </tr>
                </table>
            </td>
            </tr>
        </table>
    </td>
    </tr>
</table>

<!--################ START FORM STYLE-->
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
