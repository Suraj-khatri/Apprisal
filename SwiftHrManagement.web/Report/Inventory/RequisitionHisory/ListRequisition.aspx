<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="ListRequisition.aspx.cs" Inherits="SwiftAssetManagement.Report.Inventory.RequisitionHisory.ListRequisition" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <div class="panel">
        <header class="panel-heading">
            <i class="fa fa-caret-right"></i>
            Requesition History
            <asp:HiddenField ID="hdnapid" runat="server" />
        </header>
        <div class="panel-body">
            <div class="row">
                <div class="col-md-12 col-sm-12">
                    <section class="panel">
                        <div class="panel-body">
                            <div id="rpt" runat="server"></div>
                            <asp:Button ID="btnHidden" runat="server" OnClick="btnHidden_Click" Style="display: none" />
                            <label>Requested Message :</label>
                            <asp:Panel ID="PnApprove" runat="server" BorderStyle="None" CssClass="txtlbl">
                                <asp:TextBox ID="TxtAppMessage" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                            </asp:Panel>
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
</asp:Content>
<%--<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
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
        }

    
    </style>
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
    <link href="../../../Css/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
<form id = "form1" runat="server">
<table width="100%">
                        <tr>
                            <td align="left" class="style1" valign="bottom">
                                <img src="/Images/big_bullit.gif" />&nbsp;&nbsp;Requesition History<asp:HiddenField 
                                    ID="hdnapid" runat="server" />
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
                                                       GroupingText="Requested Message" Height="105px" Width="689px">
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
                        <tr>
                            <td>
                                &nbsp;</td>
                        </tr>
                    </table>

</asp:Content>
</form>
</body>
</html>
--%>