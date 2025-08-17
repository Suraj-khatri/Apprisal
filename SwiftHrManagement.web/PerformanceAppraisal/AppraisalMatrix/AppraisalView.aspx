<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="AppraisalView.aspx.cs" Inherits="SwiftHrManagement.web.PerformanceAppraisal.AppraisalMatrix.AppraisalView" %>
<%@ Import Namespace="System.Data"%>
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
    <asp:UpdatePanel ID="updtpnl" runat="server">
    <ContentTemplate>   
    
<table width="100%">

    <tr>
            <td align="left" class="wellcome" valign="bottom">
                <img src="../../Images/big_bullit.gif"/>&nbsp;Appraisal Matrix Details
            </td>
        </tr>
        <tr>
            <td bgcolor="#999999" valign="top">
            </td>
        </tr>
         <tr>
            <td>&nbsp;
            </td>
        </tr>
         <tr>
            <td align="center"><div class="subheading"> Position Wise Appraisal Matrix :
                <asp:DropDownList ID="DdlPosition" runat="server" CssClass="CMBDesign" 
                    AutoPostBack="True" onselectedindexchanged="DdlPosition_SelectedIndexChanged">
                </asp:DropDownList>
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
            <td><div style="width:710px;text-align:right;"><B>Total Weight : <asp:Label ID="lblWeight" runat="server" Text=""></asp:Label></B></div></td>
        </tr>
    
</table>

    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
