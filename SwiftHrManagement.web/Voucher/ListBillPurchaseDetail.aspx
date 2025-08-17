<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true"
    CodeBehind="ListBillPurchaseDetail.aspx.cs"
    Inherits="SwiftHrManagement.web.Voucher.ListBillPurchaseDetail" %>

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
    function DeleteRecord(id) {
        if (confirm("Confirm To Delete?")) {
            document.getElementById("<% =hdnId.ClientID %>").value = id;
                document.getElementById("<% =btnDelete.ClientID %>").click();
            }
        }
        function IsPaid(id) {
            if (confirm("Confirm To Pay?")) {
                document.getElementById("<% =hdnId1.ClientID %>").value = id;
                document.getElementById("<% =btnPay.ClientID %>").click();
            }
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">

    <asp:HiddenField ID="hdnId" runat="server" />
    <asp:Button ID="btnDelete" runat="server" Text="Button" OnClick="btnDelete_Click"
        Style="display: none;" />
    <asp:HiddenField ID="hdnId1" runat="server" />
    <asp:Button ID="btnPay" runat="server" Text="Button" OnClick="btnPay_Click" Style="display: none;" />
    <div class="panel">
        <header class="panel-heading">
            <i class="fa fa-caret-right"></i>
            Purchase Bill List
        </header>
        <div class="panel-body">
            <div class="row">
                <div class="col-md-12 col-sm-12">
                    <section class="panel">
                        <asp:Label ID="lblMsg" runat="server"  CssClass="wellcome"></asp:Label> 
                        <div class="panel-body">
                           <div id="rpt" runat="server"></div>
                                <asp:Button ID="btnHidden" runat="server" OnClick="btnHidden_Click" Style="display: none" />
                        </div>
                    </section>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

