<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="EditBranchProduct.aspx.cs" Inherits="SwiftAssetManagement.Inventory.Item.EditBranchProduct" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

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

<div class="panel">
        <header class="panel-heading">
            Product Setup
            <asp:HiddenField id="hdnproductid" runat = "server" />
            <asp:HiddenField id="hdnproduct" runat = "server" />
        </header>
        <div class="panel-body">
            <div class="row">
                <div class="col-md-12 col-sm-12">
                    <section class="panel">
                        <div class="panel-body">
                            
                            <div id="rpt" runat="server">	
                                
                            </div>  
                            <asp:Button ID="btnHidden" runat="server" OnClick="btnHidden_Click" Style="display: none" /> 
                        </div>
                    </section>
                </div>
            </div>
        </div>
    </div>

 
    
<%--<table width="100%">
                        <tr>
                            <td align="left" class="style1" valign="bottom">
                                <img src="/Images/big_bullit.gif" />&nbsp;&nbsp;Branch&nbsp;Product Setup<br />
                                <asp:HiddenField id="hdnproductid" runat = "server" />
                                <asp:HiddenField id="hdnproduct" runat = "server" />
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
                            <td>
                                &nbsp;</td>
                        </tr>
                    </table>--%>




</asp:Content>