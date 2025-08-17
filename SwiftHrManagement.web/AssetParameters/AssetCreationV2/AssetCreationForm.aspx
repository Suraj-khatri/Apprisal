<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master"  AutoEventWireup="true" CodeBehind="AssetCreationForm.aspx.cs" Inherits="SwiftHrManagement.web.AssetParameters.AssetCreationV2.AssetCreationForm" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/greybox/gb_styles.css" rel="stylesheet" type="text/css" media="all" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
        <script type="text/javascript" src="/ajax_func.js"> </script>  
         <script type="text/javascript">
             var GB_ROOT_DIR = "/greybox/";
        </script>
        <script type="text/javascript" src="/greybox/AJS.js"></script>
        <script type="text/javascript" src="/greybox/AJS_fx.js"></script>
        <script type="text/javascript" src="/greybox/gb_scripts.js"></script>
             <div class="col-md-10 col-md-offset-1">
        <div class="panel">
            <header class="panel-heading">
               Fixed Asset Group/Type Setup
            </header>
            <div class="panel-body">
                <div class="form-group col-md-12">
                   <span onclick="ShowProduct('1')" style="cursor:pointer;  color:#0094ff; padding-right:5px;">
                               <i class="fa fa-folder" aria-hidden="true"></i> Depreciable Asset  <span class="caret"></span></span>
                    </div>
                <div class="form-group">
                                <div id="tdshow1" ></div>
                            </div>
                <div>&nbsp;</div>
                <div class="form-group col-md-12">
                <span onclick="ShowProduct('2')" style="cursor:pointer;  color:#0094ff; padding-right:5px;"> 
                                     <i class="fa fa-folder" aria-hidden="true"></i>Non-Depreciable Asset  <span class="caret"></span></span>
                             
                                     </div>
                <div class="form-group">
                                 <div id="tdshow2"></div>
                    </div>
                            </div>
                    </div>
               </div>
          
    
   

<script language="javascript" type="text/javascript">

    function ShowProduct(Obj) {
        if ((document.getElementById('tdshow' + Obj).style.display) == "none" || (document.getElementById('tdshow' + Obj).style.display) == "") {
            document.getElementById('tdshow' + Obj).style.display = "block";

            var Alurl = 'showAssetProduct.aspx?ProdID=' + Obj;
            exec_AJAX(Alurl, 'tdshow' + Obj, '');
        }
        else {
            document.getElementById('tdshow' + Obj).style.display = "none";
        }
    }

    function showEdit(row_id, parent_id, IsProduct, product_id) {
        if (IsProduct == 'False') {
            GB_showCenter('', '/AssetParameters/Item/Manage.aspx?id=' + row_id, 410
                , 470)
        }
        else {
            GB_showCenter('', '/AssetParameters/Item/ProductSetup.aspx?item_id=' + row_id + '&product_id=' + product_id + '&group_id=' + parent_id, 410, 470)
        }
    }

    function AddNewGroup(ParentID, PrName) {
        GB_showCenter('', '/AssetParameters/Item/Manage.aspx?grpid=' + ParentID + '&product=' + PrName, 330, 500)
    }

    function AddNewProduct(Group_id, Group_Name) {
        GB_showCenter('', '/AssetParameters/Item/ProductSetup.aspx?group_id=' + Group_id + '&product_id=0', 330, 465)

    }
    function showBranchAssign(product_id) {
        GB_showCenter("", '/AssetParameters/AssetCreationV2/AssetBranchAssignProduct.aspx?product_id=' + product_id, 750, 1000)
    }
</script>
</asp:Content>