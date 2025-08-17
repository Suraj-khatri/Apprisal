<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="ManageGradeSetup.aspx.cs" Inherits="SwiftHrManagement.web.Company.EmployeeWeb.Grade.ManageGradeSetup" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script language="javascript" src="../../../Jsfunc.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">

<asp:UpdatePanel ID="UpdatePanel1" runat="server" >
<ContentTemplate> 

    <table width="100%" height="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td valign="top">
                <table width="60%" height="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr> 
                        <td valign="top">
                            <table width="100%" height="30" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td valign="bottom" class="wellcome">
                                    <img src="/images/spacer.gif" width="5" height="1"><img src="/images/big_bullit.gif">&nbsp;&nbsp;Grade Setup</td>
                                </tr>
                                <tr>
                                    <td valign="top" bgcolor="#999999" height="1"><img src="/images/spacer.gif" width="100%" height="1"></td>
                                </tr>
                            </table>
                            <table width="99%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td valign="top" align="center"><br>

                                <!--		Begin content	-->

<!--START FORM STYLE-->
    <table class="container" border="0" cellpadding="0" cellspacing="0" width="40%">
        <tbody>
            <tr>
                <td width="1%" class="container_tl"><div></div></td>
                <td width="99%" class="container_tmid"><div>Grade Setup Form</div></td>
                <td width="20%" class="container_tr"><div></div></td>
            </tr>
            <tr>
                <td class="container_l"></td>
                <td class="container_content">
            
                <!--################ END FORM STYLE-->

        <table border="0" cellspacing="4" cellpadding="4" class="container">
            <tr>    
                <td colspan="3">
                <asp:Label ID="lblmsg" runat="server" CssClass="txtlbl"></asp:Label>
                <asp:HiddenField ID="HdnRowId" runat="server" />
                </td>
            </tr> 
            <tr>
                <td nowrap="nowrap"><div class="txtlbl" align="right"> Position :</div>
                <td nowrap="nowrap"><asp:DropDownList ID="DdlPosition" runat="server" 
                    CssClass="FltCMBDesign" Width="225px"></asp:DropDownList>&nbsp;<span class="errormsg">*</span>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="DdlPosition" 
                        Display="Dynamic" ErrorMessage="Required!" ValidationGroup="loan" 
                        SetFocusOnError="True">
                    </asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td nowrap="nowrap"><div class="txtlbl" align="right"> Rate(%) :</div>
                <td nowrap="nowrap"> 
                    <asp:Textbox ID="txtRate" runat="server" CssClass="FltCMBDesign" Width="100px"></asp:Textbox>&nbsp;<span class="errormsg">*</span>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtRate" 
                        Display="Dynamic" ErrorMessage="Required!" ValidationGroup="loan" 
                        SetFocusOnError="True">
                    </asp:RequiredFieldValidator>                                                               
                </td>
            </tr>
<%--            <tr>
                <td nowrap="nowrap"><div class="txtlbl"> Rate On :</div>
                <td nowrap="nowrap"> 
                    <asp:DropDownList ID="ddlRateOn" runat="server" CssClass="FltCMBDesign">
                    <asp:ListItem Value="36">Basic Salary</asp:ListItem>                   
                    </asp:DropDownList>&nbsp;<span class="errormsg">*</span>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlRateOn" 
                        Display="Dynamic" ErrorMessage="Required!" ValidationGroup="loan" 
                        SetFocusOnError="True">
                    </asp:RequiredFieldValidator>                                                               
                </td>
            </tr>--%>
            <tr>
                <td>&nbsp;</td>
                <td>
                        <asp:Button ID="btnSave" runat="server" Text=" Save " CssClass="button" 
                                onclick="btnSave_Click" /> &nbsp;

                        <asp:Button ID="BtnDelete" runat="server" CssClass="button" Text=" Delete " 
                            ValidationGroup="loan" onclick="BtnDelete_Click"  /> &nbsp;

                        <asp:Button ID="BtnBack" runat="server" CssClass="button" Text="&lt;&lt; Back" 
                            onclick="BtnBack_Click"/>
                                                                
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
<!--End FORM STYLE-->

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

</ContentTemplate>
</asp:UpdatePanel>

</asp:Content>
