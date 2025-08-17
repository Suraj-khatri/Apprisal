<%@ Page Title="" Language="C#" MasterPageFile="~/Apprisal.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="SwiftHrManagement.web.StaticView.FiscalMonthSetup.Manage" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
<table width="100%" height="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td valign="top">
		<table width="60%" height="100%" border="0" cellspacing="0" cellpadding="0">
		  <tr> 
			<td valign="top">
				<table width="100%" height="30" border="0" cellspacing="0" cellpadding="0">
					<tr>
						<td valign="bottom" class="wellcome">
						<img src="/images/spacer.gif" width="5" height="1"><img src="/images/big_bullit.gif">&nbsp;Fiscal Month 
                            Setting</td>
					</tr>
					<tr>
						<td valign="top" bgcolor="#999999" height="1"><img src="/images/spacer.gif" width="100%" height="1"></td>
					</tr>
				</table>
				<table width="99%" border="0" cellspacing="0" cellpadding="0">
					<tr>
						<td valign="top" align="center"><br>

						<!--		Begin content	-->

						
<!--################ START FORM STYLE-->
 <table class="container" border="0" cellpadding="0" cellspacing="0" width="40%">
  <tbody><tr>
    <td width="1%" class="container_tl"><div></div></td>
    <td width="91%" class="container_tmid"><div>Fiscal Month 
                            Setting</div></td>
    <td width="8%" class="container_tr"><div></div></td>
  </tr>
      <tr>
        <td class="container_l"></td>
        <td class="container_content">
        
<!--################ END FORM STYLE-->

    <table>
        <tr style="height:30px;">
            <td colspan="3">
                <span class="txtlbl" >Please enter valid data</span><br />
                <span class="required" >(* Required fields)</span><br />
                <asp:Label ID="lblMessage" runat="server"></asp:Label>
            </td>
        </tr>
        <tr style="height:30px;">
            <td>Nepali Year<span class="errormsg">*</span><asp:RequiredFieldValidator ID="rfnm" runat="server" 
                    ControlToValidate="TxtNepYear" Display="None" ErrorMessage="*" 
                    SetFocusOnError="True" ValidationGroup="fismonth"></asp:RequiredFieldValidator>
            </td>
            <td><asp:TextBox ID="TxtNepYear" runat="server" Text="" MaxLength="15"></asp:TextBox></td>
            <td>&nbsp;</td>
        </tr>
        <tr style="height:30px;">
            <td>Baisakh 1st(Eng. Date)<span class="errormsg">*</span><asp:RequiredFieldValidator ID="rfed" runat="server" 
                    ControlToValidate="TxtEngDate" Display="None" ErrorMessage="*" 
                    SetFocusOnError="True" ValidationGroup="fismonth"></asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:TextBox ID="TxtEngDate" runat="server" Text="" MaxLength="15"></asp:TextBox>
                <cc1:CalendarExtender ID="TxtEngDate_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="TxtEngDate">
                </cc1:CalendarExtender>
            </td>
            <td></td>
        </tr>
        <tr>
            <td><b><asp:Label ID="Label13" runat="server" Text="Month Name"></asp:Label></b></td>
            <td><b><asp:Label ID="Label14" runat="server" Text="Number of Days"></asp:Label></b></td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>Baisakh<span class="errormsg">*</span> <asp:RequiredFieldValidator ID="rf1" 
                    runat="server" Display="None" 
                    ErrorMessage="*" ControlToValidate="txtMonth1" SetFocusOnError="True" 
                    ValidationGroup="fismonth"></asp:RequiredFieldValidator>
            </td>
            <td>                 
                <asp:TextBox ID="txtMonth1" runat="server" Text="" MaxLength="15"></asp:TextBox>
                 <asp:RangeValidator ID="RV1" runat="server" 
                  ControlToValidate="txtMonth1" ErrorMessage="29-32" 
                  MaximumValue="32" MinimumValue="29" ValidationGroup="fismonth" Type="Integer"></asp:RangeValidator>                 
                   <cc1:FilteredTextBoxExtender ID="VN1" 
                        runat="server" Enabled="True" FilterType="Numbers" 
                        TargetControlID="txtMonth1">
                    </cc1:FilteredTextBoxExtender>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>Jestha<span class="errormsg">*</span><asp:RequiredFieldValidator ID="Rf2" runat="server" 
                    ControlToValidate="txtMonth2" Display="None" ErrorMessage="*" 
                    SetFocusOnError="True" ValidationGroup="fismonth"></asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:TextBox ID="txtMonth2" runat="server" Text="" MaxLength="15"></asp:TextBox>
                <asp:RangeValidator ID="RV2" runat="server" 
                  ControlToValidate="txtMonth2" ErrorMessage="29-32" 
                  MaximumValue="32" MinimumValue="29" ValidationGroup="fismonth" Type="Integer"></asp:RangeValidator>
                 <cc1:FilteredTextBoxExtender ID="VN2" 
                        runat="server" Enabled="True" FilterType="Numbers" 
                        TargetControlID="txtMonth2">
                 </cc1:FilteredTextBoxExtender>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>Ashad<span class="errormsg">*</span><asp:RequiredFieldValidator ID="rf3" runat="server" 
                    ControlToValidate="txtMonth3" Display="None" ErrorMessage="*" 
                    SetFocusOnError="True" ValidationGroup="fismonth"></asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:TextBox ID="txtMonth3" runat="server" Text="" MaxLength="15"></asp:TextBox>
                 <asp:RangeValidator ID="RV3" runat="server" 
                  ControlToValidate="txtMonth3" ErrorMessage="29-32" 
                  MaximumValue="32" MinimumValue="29" ValidationGroup="fismonth" Type="Integer"></asp:RangeValidator>
                <cc1:FilteredTextBoxExtender ID="VN3" 
                        runat="server" Enabled="True" FilterType="Numbers" 
                        TargetControlID="txtMonth3">
                 </cc1:FilteredTextBoxExtender>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>Shrawan<span class="errormsg">*</span><asp:RequiredFieldValidator ID="rf4" runat="server" 
                    ControlToValidate="txtMonth4" Display="None" ErrorMessage="*" 
                    SetFocusOnError="True" ValidationGroup="fismonth"></asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:TextBox ID="txtMonth4" runat="server" Text="" MaxLength="15"></asp:TextBox>
                 <asp:RangeValidator ID="RV4" runat="server" 
                  ControlToValidate="txtMonth4" ErrorMessage="29-32" 
                  MaximumValue="32" MinimumValue="29" ValidationGroup="fismonth" Type="Integer"></asp:RangeValidator>
                <cc1:FilteredTextBoxExtender ID="VN4" 
                        runat="server" Enabled="True" FilterType="Numbers" 
                        TargetControlID="txtMonth4">
                </cc1:FilteredTextBoxExtender>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>Bhadra<span class ="errormsg">*</span><asp:RequiredFieldValidator ID="rf5" runat="server" 
                    ControlToValidate="txtMonth5" Display="None" ErrorMessage="*" 
                    SetFocusOnError="True" ValidationGroup="fismonth"></asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:TextBox ID="txtMonth5" runat="server" Text="" MaxLength="15"></asp:TextBox>
                <asp:RangeValidator ID="RV5" runat="server" 
                  ControlToValidate="txtMonth5" ErrorMessage="29-32" 
                  MaximumValue="32" MinimumValue="29" ValidationGroup="fismonth" Type="Integer"></asp:RangeValidator>
                 <cc1:FilteredTextBoxExtender ID="VN5" 
                        runat="server" Enabled="True" FilterType="Numbers" 
                        TargetControlID="txtMonth5">
                </cc1:FilteredTextBoxExtender>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>Ashwin<span class="errormsg">*</span><asp:RequiredFieldValidator ID="rf6" 
                    runat="server" Display="None" 
                    ErrorMessage="*" SetFocusOnError="True" ValidationGroup="fismonth" 
                    ControlToValidate="txtMonth6"></asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:TextBox ID="txtMonth6" runat="server" Text="" MaxLength="15"></asp:TextBox>
                 <asp:RangeValidator ID="RV6" runat="server" 
                  ControlToValidate="txtMonth6" ErrorMessage="29-32" 
                  MaximumValue="32" MinimumValue="29" ValidationGroup="fismonth" Type="Integer"></asp:RangeValidator>
                <cc1:FilteredTextBoxExtender ID="VN6" 
                        runat="server" Enabled="True" FilterType="Numbers" 
                        TargetControlID="txtMonth6">
                </cc1:FilteredTextBoxExtender>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>Kartik<span class="errormsg">*</span><asp:RequiredFieldValidator ID="rf7" runat="server" 
                    ControlToValidate="txtMonth7" Display="None" ErrorMessage="*" 
                    SetFocusOnError="True" ValidationGroup="fismonth"></asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:TextBox ID="txtMonth7" runat="server" Text="" MaxLength="15"></asp:TextBox>              
                <asp:RangeValidator ID="RangeValidator5" runat="server" 
                  ControlToValidate="txtMonth7" ErrorMessage="29-32" 
                  MaximumValue="32" MinimumValue="29" ValidationGroup="fismonth" Type="Integer"></asp:RangeValidator>
                <cc1:FilteredTextBoxExtender ID="VN7" 
                        runat="server" Enabled="True" FilterType="Numbers" 
                        TargetControlID="txtMonth7">
                </cc1:FilteredTextBoxExtender>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>Mangsir<span class ="errormsg">*</span><asp:RequiredFieldValidator ID="rf8" runat="server" 
                    ControlToValidate="txtMonth8" Display="None" ErrorMessage="*" 
                    SetFocusOnError="True" ValidationGroup="fismonth"></asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:TextBox ID="txtMonth8" runat="server" Text="" MaxLength="15"></asp:TextBox>
                 <asp:RangeValidator ID="RV8" runat="server" 
                  ControlToValidate="txtMonth8" ErrorMessage="29-32" 
                  MaximumValue="32" MinimumValue="29" ValidationGroup="fismonth" Type="Integer"></asp:RangeValidator>
                 <cc1:FilteredTextBoxExtender ID="VN8" 
                        runat="server" Enabled="True" FilterType="Numbers" 
                        TargetControlID="txtMonth8">
                 </cc1:FilteredTextBoxExtender>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>Poush<span class ="errormsg">*</span><asp:RequiredFieldValidator ID="rf9" runat="server" 
                    ControlToValidate="txtMonth9" Display="None" ErrorMessage="*" 
                    SetFocusOnError="True" ValidationGroup="fismonth"></asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:TextBox ID="txtMonth9" runat="server" Text="" MaxLength="15"></asp:TextBox>
                <asp:RangeValidator ID="RV9" runat="server" 
                  ControlToValidate="txtMonth9" ErrorMessage="29-32" 
                  MaximumValue="32" MinimumValue="29" ValidationGroup="fismonth" Type="Integer"></asp:RangeValidator>                
                <cc1:FilteredTextBoxExtender ID="VN9" 
                        runat="server" Enabled="True" FilterType="Numbers" 
                        TargetControlID="txtMonth9">
                 </cc1:FilteredTextBoxExtender>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>Magh<span class="errormsg">*</span><asp:RequiredFieldValidator ID="rf10" runat="server" 
                    ControlToValidate="txtMonth10" Display="None" ErrorMessage="*" 
                    SetFocusOnError="True" ValidationGroup="fismonth"></asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:TextBox ID="txtMonth10" runat="server" Text="" MaxLength="15"></asp:TextBox>
                <asp:RangeValidator ID="RV10" runat="server" 
                  ControlToValidate="txtMonth10" ErrorMessage="29-32" 
                  MaximumValue="32" MinimumValue="29" ValidationGroup="fismonth" Type="Integer"></asp:RangeValidator>
                <cc1:FilteredTextBoxExtender ID="VN10" 
                        runat="server" Enabled="True" FilterType="Numbers"
                        TargetControlID="txtMonth10">
                 </cc1:FilteredTextBoxExtender>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>Falgun<span class="errormsg">*</span><asp:RequiredFieldValidator ID="rf11" runat="server" 
                    ControlToValidate="txtMonth11" Display="None" ErrorMessage="*" 
                    ValidationGroup="fismonth"></asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:TextBox ID="txtMonth11" runat="server" Text="" MaxLength="15"></asp:TextBox>
                <asp:RangeValidator ID="RV11" runat="server" 
                  ControlToValidate="txtMonth11" ErrorMessage="29-32" 
                  MaximumValue="32" MinimumValue="29" ValidationGroup="fismonth" Type="Integer"></asp:RangeValidator>
                 <cc1:FilteredTextBoxExtender ID="VN11" 
                        runat="server" Enabled="True" FilterType="Numbers" 
                        TargetControlID="txtMonth11">
                 </cc1:FilteredTextBoxExtender>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>Chaitra<span class="errormsg">*</span><asp:RequiredFieldValidator ID="rf12" runat="server" 
                    ControlToValidate="txtMonth12" Display="None" ErrorMessage="*" 
                    SetFocusOnError="True" ValidationGroup="fismonth"></asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:TextBox ID="txtMonth12" runat="server" Text="" MaxLength="15"></asp:TextBox>
                <asp:RangeValidator ID="RV12" runat="server" 
                  ControlToValidate="txtMonth12" ErrorMessage="29-32" 
                  MaximumValue="32" MinimumValue="29" ValidationGroup="fismonth" Type="Integer"></asp:RangeValidator>
                <cc1:FilteredTextBoxExtender ID="VN12" 
                        runat="server" Enabled="True" FilterType="Numbers" 
                        TargetControlID="txtMonth12">
                 </cc1:FilteredTextBoxExtender>
            </td>
            <td>&nbsp;</td>
        </tr>        
        <tr>
            <td>
                <asp:Button ID="BtnSave" runat="server" CssClass="button" Text="Save" 
                    onclick="BtnSave_Click" ValidationGroup="fismonth" />
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
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
    <asp:UpdatePanel ID="updPanel1" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false" RenderMode="Inline">
        <ContentTemplate>
            <asp:Button ID="btnUpdate" runat="server" style="display:none" />
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnUpdate" EventName="click" />
        </Triggers>        
    </asp:UpdatePanel>
    
</asp:Content>
