<%@ Page Title="Swift HRM" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="SwiftHrManagement.web.PerformanceAppraisal.AppraisalMatrix.Manage" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
  <table width="100%" height="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td valign="top">
		<table width="100%" height="100%" border="0" cellspacing="0" cellpadding="0">
		  <tr> 
			<td valign="top">
				<table width="100%" border="0" cellspacing="0" cellpadding="0" style="margin-top:10px;">
					<tr>
						<td valign="bottom" class="wellcome"><img src="/images/spacer.gif" width="5" height="1">
						<img src="/images/big_bullit.gif">&nbsp;Appraisal Matrix Entry Details</td>
					</tr>
					<tr>
						<td valign="top" bgcolor="#999999" height="1"><img src="/images/spacer.gif" width="100%" height="1"></td>
					</tr>
				</table>
				<table width="80%" border="0" cellspacing="0" cellpadding="0">
					<tr>
						<td valign="top" align="center"><br>

						<!--		Begin content	-->

						
<!--################ START FORM STYLE-->
 <table class="container" border="0" cellpadding="0" cellspacing="0" width="40%">
  <tbody><tr>
    <td width="1%" class="container_tl"><div></div></td>
    <td width="91%" class="container_tmid"><div>Appraisal Matrix&nbsp; Details&nbsp; 
        entry</div></td>
    <td width="8%" class="container_tr"><div></div></td>
  </tr>
      <tr>
        <td class="container_l"></td>
        <td class="container_content">
        
<!--################ END FORM STYLE-->

                                                        <asp:UpdatePanel ID="updatepanel1" runat="server">
                                                        <ContentTemplate>                                                        
                                                        <table border="0" cellspacing="5" cellpadding="5" class="container">
                                                            <tr>
                                                                <td>
                                                                    <span class="txtlbl" >Please enter valid  data</span><br />
                                                                    <span class="required" >(* Required fields)</span><br />
                                                                    <asp:Label ID="LblMsg" runat="server"></asp:Label>
                                                                </td>
                                                                <td class="style13">
                                                                    &nbsp;</td>
                                                            </tr>
                                                            <tr>
                                                                <td class="txtlbl">
                                                                    Position<span class="errormsg">*</span><asp:RequiredFieldValidator 
                                                                        ID="RFVposition" runat="server" 
                                                                        ControlToValidate="DdlPosition" ErrorMessage="*" SetFocusOnError="True" 
                                                                        Display="None" ValidationGroup="Matrix"></asp:RequiredFieldValidator><br />
                                                                    <asp:DropDownList ID="DdlPosition" runat="server" CssClass="CMBDesign" 
                                                                        onselectedindexchanged="DdlPosition_SelectedIndexChanged" AutoPostBack="true">
                                                                    </asp:DropDownList>
                                                                    <br />
                                                                </td>
                                                                <td class="style12">
                                                                    &nbsp;</td>
                                                            </tr>
                                                            <tr>
                                                                <td class="txtlbl">
                                                                    Topic<span class="errormsg">*</span><asp:RequiredFieldValidator ID="RFVTopic" runat="server" 
                                                                        ErrorMessage="*" ControlToValidate="DdlTopic" Display="None" 
                                                                        SetFocusOnError="True" ValidationGroup="Matrix"></asp:RequiredFieldValidator><br />
                                                                    <asp:DropDownList ID="DdlTopic" runat="server" CssClass="CMBDesign" 
                                                                        Height="22px" Width="482px">
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td class="style12">
                                                                    &nbsp;</td>
                                                            </tr>
                                                            <tr>
                                                                <td class="style10">
                                                                    Sub Topic<span class="errormsg">*</span><asp:RequiredFieldValidator ID="RFVSubtopic" 
                                                                        runat="server" ErrorMessage="*" ControlToValidate="DdlSubtopic" 
                                                                        Display="None" SetFocusOnError="True" ValidationGroup="Matrix"></asp:RequiredFieldValidator><br />
                                                                    <asp:DropDownList ID="DdlSubtopic" runat="server" CssClass="CMBDesign" 
                                                                        Height="22px" Width="481px">
                                                                    </asp:DropDownList>
                                                                    <br />
                                                                </td>
                                                                <td class="style14">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="txtlbl" colspan="2">
                &nbsp;Job Elements<span class="errormsg">*</span><asp:RequiredFieldValidator ID="RFVJobElement" runat="server" ErrorMessage="*" 
                                                                        ControlToValidate="DdlJobElement" Display="None" SetFocusOnError="True" 
                                                                        ValidationGroup="Matrix"></asp:RequiredFieldValidator><br />
                                                                    <asp:DropDownList ID="DdlJobElement" runat="server" CssClass="CMBDesign" 
                                                                        Width="479px">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="txtlbl" colspan="2">
                                                                    Weightage<span class="errormsg">*</span><asp:RequiredFieldValidator ID="RFVWeightage" 
                                                                        runat="server" ErrorMessage="*" ControlToValidate="TxtWeightage" 
                                                                        Display="None" SetFocusOnError="True" ValidationGroup="Matrix"></asp:RequiredFieldValidator><asp:RangeValidator ID="RNGValidator" runat="server" 
                                                                        ControlToValidate="TxtWeightage" 
                                                                        ErrorMessage="Weightage must be in between 1 - 100" MaximumValue="100" 
                                                                        MinimumValue="0.01" SetFocusOnError="True" ValidationGroup="Matrix" 
                                                                        Display="Dynamic" Type="Double"></asp:RangeValidator><br />
                                                                    <asp:TextBox ID="TxtWeightage" runat="server" CssClass="inputTextBoxLP1" Width="100px"></asp:TextBox>
                                                                    <cc1:FilteredTextBoxExtender ID="TxtWeightage_FilteredTextBoxExtender" 
                                                                        runat="server" Enabled="True" FilterType="Numbers" 
                                                                        TargetControlID="TxtWeightage">
                                                                    </cc1:FilteredTextBoxExtender>
                                                                    <asp:HiddenField ID="hdnField" runat="server" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="txtlbl" colspan="2">
                                                                    Display Order<span class="errormsg">*</span><asp:RequiredFieldValidator ID="RFVDispOrder" 
                                                                        runat="server" ErrorMessage="*" ControlToValidate="TxtDispOrder" 
                                                                        Display="None" ValidationGroup="Matrix" SetFocusOnError="True"></asp:RequiredFieldValidator><br />
                                                                    <asp:TextBox ID="TxtDispOrder" runat="server" CssClass="inputTextBoxLP1" Width="100px"></asp:TextBox>
                                                                    <cc1:FilteredTextBoxExtender ID="TxtDispOrder_FilteredTextBoxExtender" 
                                                                        runat="server" Enabled="True" FilterType="Numbers" 
                                                                        TargetControlID="TxtDispOrder">
                                                                    </cc1:FilteredTextBoxExtender>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Button ID="BtnSave" runat="server" CssClass="button" 
                    onclick="BtnSave_Click" Text="Save" ValidationGroup="Matrix" Width="55px" />
                                                                    <cc1:ConfirmButtonExtender ID="BtnSave_ConfirmButtonExtender" runat="server" 
                                                                        ConfirmText="Confirm To Save?" Enabled="True" TargetControlID="BtnSave">
                                                                    </cc1:ConfirmButtonExtender>
&nbsp;<asp:Button ID="BtnDelete" runat="server" CssClass="button" 
                    onclick="BtnDelete_Click" Text="Delete" />
                                                                    <cc1:ConfirmButtonExtender ID="BtnDelete_ConfirmButtonExtender" runat="server" 
                                                                        ConfirmText="Confirm To Delete?" Enabled="True" TargetControlID="BtnDelete">
                                                                    </cc1:ConfirmButtonExtender>
&nbsp;<asp:Button ID="BtnCancel" runat="server" CssClass="button" 
                    onclick="BtnBack_Click" Text="&lt;&lt; Back" />
                                                                </td>
                                                                <td class="style13">
                                                                    &nbsp;</td>
                                                            </tr>
                                                        </table>
                                                        </ContentTemplate>
                                                        </asp:UpdatePanel>

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
