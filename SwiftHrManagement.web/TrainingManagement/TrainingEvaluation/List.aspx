<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="SwiftHrManagement.web.TrainingManagement.TrainingEvaluation.List" Title="Swift HRM" %>
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
        <td valign="bottom" class="wellcome" align="left">
        <img src="/images/spacer.gif" width="5" height="1">
        <img src="/images/big_bullit.gif"> Training Program Evaluation Details, Category :  <span class="subheading">
        <asp:Label ID="LblTrainList" runat="server" ></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;Program Title : 
        <asp:Label ID="LblProgramTitle" runat="server" ></asp:Label></span> </td>
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
            <td>&nbsp;</td>
        </tr>
</table>
</asp:Content>
