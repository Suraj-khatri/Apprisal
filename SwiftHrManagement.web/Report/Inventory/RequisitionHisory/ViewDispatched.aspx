<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="ViewDispatched.aspx.cs" Inherits="SwiftHrManagement.web.Report.Inventory.RequisitionHisory.ViewDispatched" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript" language="javascript">
    function submit_form() {
        var btn = document.getElementById("<%=btnHidden.ClientID %>");
        if (btn != null)
            btn.click();
    }

    function nav(page) {
        var hdd = document.getElementById("hdd_curr_page");
        if (hdd != null)
            hdd.value = page;

        submit_form();
    }

    function newTableToggle(idTD, idImg) {
        var td = document.getElementById(idTD);
        var img = document.getElementById(idImg);
        if (td != null && img != null) {
            var isHidden = td.style.display == "none" ? true : false;
            img.src = isHidden ? "/images/icon_hide.gif" : "/images/icon_show.gif";
            img.alt = isHidden ? "Hide" : "Show";
            td.style.display = isHidden ? "" : "none";
        }
    }
    </script> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
<table width="100%">
    <tr>
        <td align="left" class="wellcome" valign="bottom">
            <i class="fa fa-caret-right"></i>
            Dispatch History
            <asp:HiddenField ID="hdnapid" runat="server" />
        </td>                            
    </tr>
    <tr>
        <td bgcolor="#999999" valign="top"></td>
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
                GroupingText="Dispatched Message" Height="105px" Width="689px">
                <table class="style2">
                    <tr>
                        <td style="text-align: left" nowrap="nowrap">
                            <br />
                            <asp:TextBox ID="txtDispatchedMsg" runat="server" CssClass="inputTextBoxLP" 
                                Height="66px" TextMode="MultiLine" Width="671px"></asp:TextBox>
                            <br />
                            <br />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
</table>
</asp:Content>
