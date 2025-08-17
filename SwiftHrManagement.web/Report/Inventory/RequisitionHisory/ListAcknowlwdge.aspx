<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="ListAcknowlwdge.aspx.cs" Inherits="SwiftAssetManagement.Report.Inventory.RequisitionHisory.ListAcknowlwdge" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
<table width="100%">
                        <tr>
                            <td align="left" class="wellcome" valign="bottom">
                                <img src="/Images/big_bullit.gif" />&nbsp;Acknowledgement History<br />
                            <asp:HiddenField ID="hdnapid" runat="server" />
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
                                                   <asp:Panel ID="PnApprove" runat="server" BorderStyle="None" CssClass="txtlbl" 
                                                       GroupingText="Approval Message" Height="105px" Width="689px">
                                                       <table class="style2">
                                                           <tr>
                                                               <td style="text-align: left" nowrap="nowrap">
                                                                   <br />
                                                                   <asp:TextBox ID="TxtAppMessage" runat="server" CssClass="inputTextBoxLP" 
                                                                       Height="66px" TextMode="MultiLine" Width="671px"></asp:TextBox>
                                                                   <br />
                                                                   <br />
                                                               </td>
                                                           </tr>
                                                           <tr>
                                                               <td>
                                                                   &nbsp;</td>
                                                           </tr>
                                                       </table>
                                                   </asp:Panel>
                                             </td>
                                         </tr>
                    </table>

<%--</asp:Content>--%>
</asp:Content>