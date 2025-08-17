<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master"  AutoEventWireup="true" CodeBehind="EditBranchProduct.aspx.cs" Inherits="SwiftAssetManagement.AssetParameters.Item.EditBranchProduct" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <asp:HiddenField id="hdnproductid" runat = "server" />
    <asp:HiddenField id="hdnproduct" runat = "server" />
    <div class="panel">
        <header class="panel-heading">
            <i class="fa fa-caret-right"></i>
          Asset Branch Product Setup
        </header>
        <div class="panel-body"> 
            <div class="row">
                <div class="col-md-12 col-sm-12">
                    <section class="panel">
                        <div class="panel-body">
                            <div id="rpt" runat="server"></div>
                            <asp:Button ID="btnHidden" runat="server" OnClick="btnHidden_Click" Style="display: none" />
                        </div>
                    </section>
                </div>
            </div>
        </div>
    </div>

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

    <%--<style type="text/css">

.errormsg
{
	color:red;
}--%>

<%--SELECT,TEXTAREA,input { 
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
    <link href="../../Css/style.css" rel="stylesheet" type="text/css" />--%>



</asp:Content>
