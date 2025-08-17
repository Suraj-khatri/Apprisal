<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewRate.aspx.cs" MasterPageFile="~/SwiftHRManager.Master" Inherits="SwiftHrManagement.web.Voucher.ViewRate" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <div class="row">
        <div class="col-md-8 col-md-offset-2">
            <section class="panel">
                <header class="panel-heading">
                    <i class="fa fa-caret-right"></i>
                     Purchase Detail
                    <asp:HiddenField ID ="hdnprod_code" runat="server" />
                    <asp:HiddenField ID ="hdnprod_Quantity" runat="server" />
                </header>
                <div class="panel-body">
                    <div class="form-group">
                        <div id="rpt" runat="server"></div>
                        <asp:Button ID="btnHidden" runat="server" OnClick="btnHidden_Click" Style="display: none" />
                    </div>
                    <div class="form-group">
                        <input class="btn btn-primary" name="btn_delete" onclick="ReturnRateAndClose();" type="button" value="Select" />
                    </div>
                </div>
            </section>
        </div>
    </div>
<script language="javascript" type="text/javascript">
//    function ReturnRateAndClose() {
//        var data = getCheckedValue(document.form1.ckID)
//        var rate = data.split("|");
//        opener.document.form1.unitprice.value = rate[1];
//        opener.document.form1.hdnPurId.value = rate[0];
//        self.close();
//        opener.document.form1.unitprice.focus();

//    }
    function ReturnRateAndClose() {
        var data = getCheckedValue(document.form1.ckID);
        window.returnValue = data;
        window.close();
    }
    function getCheckedValue(radioObj) {
        if (!radioObj)
            return "";
        var radioLength = radioObj.length;
        if (radioLength == undefined)
            if (radioObj.checked)
            return radioObj.value;
        else
            return "";

        for (var i = 0; i < radioLength; i++) {
            if (radioObj[i].checked) {
                return radioObj[i].value;
            }
        }
        return "";
    }
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
