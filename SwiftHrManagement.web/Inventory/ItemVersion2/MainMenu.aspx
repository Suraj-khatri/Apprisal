<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="MainMenu.aspx.cs" Inherits="SwiftHrManagement.web.Inventory.ItemVersion2.MainMenu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="/greybox/gb_styles.css" rel="stylesheet" type="text/css" media="all" />
    <script type="text/javascript" src="/ajax_func.js"> </script>
    <script type="text/javascript">
        var GB_ROOT_DIR = "/greybox/";
    </script>

    <script type="text/javascript" src="/greybox/AJS.js"></script>
    <script type="text/javascript" src="/greybox/gb_scripts.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">

    <div class="row">
        <div class="col-md-10 col-md-offset-1">
            <section class="panel">
                <header class="panel-heading">
                    <i class="fa fa-caret-right"></i>
                           Inventory Group/Product Setup     
                </header>
                <div class="panel-body">
                    <div class="form-group">
                            <span onclick="ShowProduct('1')" style="cursor:pointer; color:#0094ff; padding-right:5px;"> 
                            <i class="fa fa-folder" aria-hidden="true"></i>  INVENTORY PRODUCT <span><i class="fa fa-caret-down" aria-hidden="true" style="padding-left:10px;"></i></span>
</span>
                    </div>
                    <div class="form-group">
                            <div ID="tdshow1">    
                            </div>
                    </div>
                </div>
            </section>
        </div>
    </div>

    <script language="javascript" type="text/javascript">

        function ShowProduct(Obj) {           
            if ((document.getElementById('tdshow' + Obj).style.display) == "none" || (document.getElementById('tdshow' + Obj).style.display) == "") {
                document.getElementById('tdshow' + Obj).style.display = "block";
                var Alurl = 'showProduct.aspx?ProdID=' + Obj;
                exec_AJAX(Alurl, 'tdshow' + Obj, '');
            }
            else {
                document.getElementById('tdshow' + Obj).style.display = "none";
            }
        }
        function showEdit(row_id, parent_id, IsProduct, product_id) {
           
            if (IsProduct == 'False') {
                //GB_showCenter('', 'showProduct.aspx?id=' + row_id, 300, 450);
                GB_showCenter('', '../Inventory/Item/Manage.aspx?id=' + row_id, 400,400);
            }
            else {
                GB_showCenter('', '../Inventory/Item/ProductSetup.aspx?item_id=' + row_id + '&product_id=' + product_id + '&group_id=' + parent_id, 802, 1000);
            }
        }

        function AddNewGroup(ParentID, PrName) {
            GB_showCenter('Add Product', '../Inventory/Item/Manage.aspx?grpid=' + ParentID + '&id=0', 400, 400);
        }

        function AddNewProduct(Group_id, Group_Name) {
            GB_showCenter('Add Product', '../Inventory/Item/ProductSetup.aspx?group_id=' + Group_id + '&product_id=0', 804, 1000);
        }

        function showBranchAssign(product_id) {
            GB_showCenter("", '../Inventory/Branch And Product Assign/BranchAssignProduct.aspx?product_id=' + product_id, 805, 1000);
        }

        function showVendorAssign(product_id) {
            GB_showCenter('', '../Inventory/ItemVersion2/Vendor Assign Product/VendorAssignProduct.aspx?product_id=' + product_id, 500, 800);
        }

    </script>
</asp:Content>
