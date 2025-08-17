<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="ProductSearch.aspx.cs" Inherits="SwiftAssetManagement.Inventory.Item.ProductSearch" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

   <asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
<%--<script language="javascript" type="text/javascript">

   function ReturnAndClose() {
        var data = getCheckedValue(document.getElementById("ckID"));
        var productId = data.split("|");
        opener.document.form1.hdnProductId.value = productId[1];
        opener.document.form1.txtProduct.value = document.getElementById("ckID").value;
        self.close();
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

</script>--%>
    <div class="row">
        <div class="col-md-8 col-md-offset-2">
            <section class="panel">
                <header class="panel-heading">
                     &nbsp;Product Search Details
                </header>
                <div class="panel-body">
                    <strong> Product Search</strong>
                    <div class="form-group">
                        <h4>Product Search Information:</h4>
                    </div>
                    <div class="form-group">
                        <asp:HiddenField ID ="hdnprod_code" runat="server" />
                    </div>
                    <div class="col-md-4">
                        <div class="form-group">
                            <label>Product Code :</label>
                            <asp:TextBox ID="txtCode" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="form-group">
                            <label>Product Name :</label>
                             <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="form-group">
                            <label>Product Group :</label>
                            <asp:TextBox ID="txtGroup" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                     <div class="form-group">
                        <div id="rpt" runat="server"></div>
                        <asp:Button ID="BtnSeacrh" runat="server" Text="Search" CssClass="btn btn-primary" OnClick="BtnSeacrh_Click" />
                        <input class="btn btn-primary" name="btn_delete" onclick="ReturnAndClose();" type="button" value="Select" />
                    </div>
                </div>
            </section>
        </div>
    </div>


     
    <script language="javascript" type="text/javascript">
        //    function ReturnAndClose() {
        //        var data = getCheckedValue(document.frm1.ckID)
        //        opener.document.frm1.txtProduct.value = data;
        //        self.close();
        //        opener.document.frm1.txtProduct.focus();

        //    }
        //    function getCheckedValue(radioObj) {
        //        if (!radioObj)
        //            return "";
        //        var radioLength = radioObj.length;
        //        if (radioLength == undefined)
        //            if (radioObj.checked)
        //            return radioObj.value;
        //        else
        //            return "";

        //        for (var i = 0; i < radioLength; i++) {
        //            if (radioObj[i].checked) {
        //                return radioObj[i].value;
        //            }
        //        }
        //        return "";
        //    }

        function ReturnAndClose() {
            var data = getCheckedValue(document.frm1.ckID);
            var productId = data.split("|");
            opener.document.frm1.hdnProductId.value = productId[1];
            //opener.document.frm1.txtProduct.focus();
            opener.document.frm1.txtProduct.value = data;
            self.close();
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

</script>
</asp:Content>