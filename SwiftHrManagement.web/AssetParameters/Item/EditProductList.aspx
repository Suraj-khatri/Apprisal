<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master"  AutoEventWireup="true" CodeBehind="EditProductList.aspx.cs" Inherits="SwiftAssetManagement.AssetParameters.Item.EditProductList" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">

    <style type="text/css">


        .style1
        {
            font-family: arial;
            color: #004D20;
            font-size: 13px;
            font-weight: bolder;
            height: 32px;
        }
    
SELECT,TEXTAREA,input { 
	font-family: Arial Narrow;
	color: #993300;
	text-decoration:none;
	font-size:13px;
	border:1px solid #999999;
	background-color:white;
	list-style:none;
}
    
input { 
	font-family: Arial Narrow;
	color: #993300;
	text-decoration:none;
	font-size:13px;
	border:1px solid #999999;
	background-color:white;
	list-style:none;
}
    </style>
    <link href="../../Css/style.css" rel="stylesheet" type="text/css" />

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

<%--</asp:Content>--%>

<%--<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">--%>
<table width="100%">
                        <tr>
                            <td align="left" class="style1" valign="bottom">
                                <img src="/Images/big_bullit.gif" />&nbsp;&nbsp;Asset&nbsp;Type&nbsp;Details</td>
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
                            <td>
                                &nbsp;</td>
                        </tr>
                    </table>

</asp:Content>

