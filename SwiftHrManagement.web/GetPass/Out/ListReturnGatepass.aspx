<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master"  AutoEventWireup="true" CodeBehind="ListReturnGatepass.aspx.cs" Inherits="SwiftAssetManagement.GetPass.Out.ListReturnGatepass" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">

    <title></title>
    <style type="text/css">


.style1
{
    font-family: arial;
    color: #004D20;
    font-size: 13px;
    font-weight: bolder;
    height: 32px;
}

        
        .style2
        {
            width: 100%;
            height: 169px;
        }

    
        .style3
        {
            height: 17px;
            text-align: left;
        }
        .style6
        {
            width: 98px;
        }

    
    </style>
    <link href="../../Css/style.css" rel="stylesheet" type="text/css" />
    <link href="../../Css/style.css" rel="stylesheet" type="text/css" />

<%--<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">--%>
<table width="100%">
                        <tr>
                            <td align="left" class="style1" valign="bottom">
                                <img src="/Images/big_bullit.gif" />&nbsp;&nbsp;Getpass Details<br />
                                <%--<asp:ScriptManager ID="ScriptManager1" runat="server">
                                </asp:ScriptManager>--%>
                            </td>
                        </tr>
                        <tr>
                            <td bgcolor="#999999" valign="top">
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                 <div>
                                    <div id="rpt" runat="server"></div>
                                    <asp:Button ID="btnHidden" runat="server" OnClick="btnHidden_Click" Style="display: none" />
                                </div>
                            </td>
                        </tr>
                        <tr>
                                             <td align="center">
                                                   <asp:Panel ID="PnReturngatepass" runat="server" BorderStyle="None" CssClass="txtlbl" 
                                                       GroupingText="Retuen Message" Height="213px" Width="689px">
                                                       <table class="style2">
                                                           
                                                           <tr>
                                                               <td nowrap="nowrap" style="text-align: left">
                                                                   <span class="txtlbl">Please enter valid data<br />
                                                                   <span class="required">(* Required fields)</span><br />
                                                                   <asp:Label ID="LblMsg" runat="server"></asp:Label>
                                                                   <br />
                                                                   <asp:RequiredFieldValidator ID="RfvMsg" runat="server" 
                                                                       ControlToValidate="TxtAppMessage" Display="None" ErrorMessage="*" 
                                                                       SetFocusOnError="True" ValidationGroup="approve"></asp:RequiredFieldValidator>
                                                                   </span>
                                                                   <br />
                                                                   <br />
                                                                   <tr>
                                                                        <td class="style3">
                                                                            <table style="width:100%;">
                                                                                <tr>
                                                                                    <td class="style6">
                                                                                        <div style="text-align: right">
                                                                                            Date :</div>
                                                                                    </td>
                                                                                    <td colspan="2">
                                                                                        <asp:TextBox ID="TxtReturnDate" runat="server" CssClass="inputTextBox"></asp:TextBox>
                                                                                        <cc1:CalendarExtender ID="TxtReturnDate_CalendarExtender" runat="server" 
                                                                                            Enabled="True" TargetControlID="TxtReturnDate">
                                                                                        </cc1:CalendarExtender>
                                                                                        <span class=errormsg>*</span><asp:RequiredFieldValidator ID="RvDate" runat="server" 
                                                                                            ControlToValidate="TxtReturnDate" Display="None" ErrorMessage="*" 
                                                                                            SetFocusOnError="True" ValidationGroup="return"></asp:RequiredFieldValidator>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="style6">
                                                                                        <div style="text-align: right; height: 51px; width: 96px">
                                                                                            Message :</div>
                                                                                    </td>
                                                                                    <td colspan="2">
                                                                                        <asp:TextBox ID="TxtAppMessage" runat="server" CssClass="inputTextBox" 
                                                                                            Height="59px" ontextchanged="TxtAppMessage_TextChanged" TextMode="MultiLine" 
                                                                                            Width="574px"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="style6">
                                                                                        &nbsp;</td>
                                                                                    <td>
                                                                                        <asp:Button ID="BtnSave" runat="server" CssClass="button" 
                                                                                            onclick="BtnSave_Click" Text="Return" ValidationGroup="return" />
                                                                                        <cc1:ConfirmButtonExtender ID="BtnSave_ConfirmButtonExtender" runat="server" 
                                                                                            ConfirmText="Confirm To Save?" Enabled="True" TargetControlID="BtnSave">
                                                                                        </cc1:ConfirmButtonExtender>
                                                                                        &nbsp;<asp:Button ID="BtnCancel" runat="server" CssClass="button" 
                                                                                            Text="&lt;&lt;Back" ValidationGroup="chart" />
                                                                                    </td>
                                                                                    <td>
                                                                                        &nbsp;</td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                   </tr>
                                                                
                                                                       
                                                               </td>
                                                           </tr>
                                                       </table>
                                                   </asp:Panel>
                                             </td>
                                         </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                        </tr>
                    </table>

</asp:Content>