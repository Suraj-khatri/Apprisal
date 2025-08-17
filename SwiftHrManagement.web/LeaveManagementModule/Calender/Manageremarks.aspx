<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SwiftHRManager.Master"CodeBehind="Manageremarks.aspx.cs" Inherits="SwiftHrManagement.web.LeaveManagementModule.Calender.Manageremarks" %>

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
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td valign="bottom" class="wellcome">
                                        <img src="/images/spacer.gif" width="5" height="1"><img src="/images/big_bullit.gif">&nbsp;&nbsp;Holiday 
                                        Remarks Entry</td>
                                </tr>
                                <tr>
                                    <td valign="top" bgcolor="#999999" height="1">
                                        <img src="/images/spacer.gif" width="100%" height="1"></td>
                                </tr>
                            </table>
                            <table width="80%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td valign="top" align="center">
                                        <br>

						<!--		Begin content	-->

						
<!--################ START FORM STYLE-->
                                        <table class="container" border="0" cellpadding="0" cellspacing="0" width="40%">
                                            <tbody>
                                                <tr>
                                                    <td width="1%" class="container_tl">
                                                        <div>
                                                        </div>
                                                    </td>
                                                    <td width="91%" class="container_tmid">
                                                        <div>
                                                            Holiday remarks</div>
                                                    </td>
                                                    <td width="8%" class="container_tr">
                                                        <div>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="container_l">
                                                    </td>
                                                    <td class="container_content">
        
<!--################ END FORM STYLE-->

 
                                                        <table border="0" cellspacing="5" cellpadding="5" class="container">
                                                            <tr>
                                                                <td colspan="2">
                                                                    <span class="txtlbl" >Please enter valid data! </span><span class="required" >&nbsp;(* Required fields)<br />
                                                                    </span>
                                                                    <br />
                                                                    <asp:Label ID="LblMsg" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="txtlbl">
                                                                    Remarks<br />
                                                                    <asp:TextBox ID="TxtLeaveremarks" runat="server" CssClass="inputTextBox" 
                                                                        Width="392px" Height="55px" TextMode="MultiLine"></asp:TextBox>
                                                                </td>
                                                                <td class="txtlbl">
                                                                    &nbsp;</td>
                                                            </tr>
                                                            <tr>
                                                                <td class="style10">
                                                                    <asp:Button ID="BtnSave" runat="server" CssClass="button" Text="Save" 
                    onclick="BtnSave_Click" ValidationGroup="Leave" Width="75px" />
                                                                    <cc1:ConfirmButtonExtender ID="BtnSave_ConfirmButtonExtender" runat="server" 
                    ConfirmText="Confirm To Save?" Enabled="True" TargetControlID="BtnSave">
                                                                    </cc1:ConfirmButtonExtender>
                                                                    <asp:Button ID="btnDelete" runat="server" CssClass="button" 
                    onclick="btnDelete_Click" Text="Delete" Width="75px" />
                                                                    <cc1:ConfirmButtonExtender ID="btnDelete_ConfirmButtonExtender" runat="server" 
                    BehaviorID="btnDelete_Cm onfirmButtonExtender" ConfirmText="Confirm To Delete?" 
                    Enabled="True" TargetControlID="btnDelete">
                                                                    </cc1:ConfirmButtonExtender>
                                                                    <asp:Button ID="BtnBack" runat="server" CssClass="button" 
                    onclick="BtnBack_Click" Text="&lt;&lt; Back" Width="75px" />
                                                                </td>
                                                                <td class="style10">
                                                                </td>
                                                            </tr>
                                                        </table>
  
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
                                            </tbody>
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