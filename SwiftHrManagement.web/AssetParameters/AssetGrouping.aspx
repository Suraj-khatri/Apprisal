<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master"  AutoEventWireup="true" CodeBehind="AssetGrouping.aspx.cs" Inherits="SwiftAssetManagement.AssetParameters.AssetGrouping" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">

    <title></title>    
    <link href="../Css/style.css" rel="stylesheet" type="text/css" />
  
   <script type="text/javascript">
       var GB_ROOT_DIR = "greybox/";
    </script>

    <script type="text/javascript" src="greybox/AJS.js"></script>
    <script type="text/javascript" src="greybox/AJS_fx.js"></script>
    <script type="text/javascript" src="greybox/gb_scripts.js"></script>
    <link href="greybox/gb_styles.css" rel="stylesheet" type="text/css" media="all" />


    <style type="text/css">
        .style1
        {
            width: 100px;
        }
    </style>


    <style type="text/css">
        .style1
        {
            width: 82px;
        }
    </style>



    <%--<asp:ScriptManager ID="sm" runat="server"></asp:ScriptManager>--%>
<table width="100%">
                        <tr>
                            <td align="left" class="wellcome" valign="bottom">
                                <img src="../../Images/big_bullit.gif" />&nbsp;Asset Details
                            </td>
                        </tr>
                        
                        <tr>
                            <td bgcolor="#999999" valign="top">
                            </td>
                        </tr>
                        
                        <tr>
                            <td>
                                <div> 
                                    <asp:TextBox ID="txtNodeSearch" runat="server" Width="391px"></asp:TextBox> 
                                    <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass ="button" 
                                        onclick="btnSearch_Click" />
                                    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                                </div>
                                 <div>
                                    <div id="rpt" runat="server" 
                                         style="height:350px; width:573px; overflow:auto; background-color:ButtonFace; " 
                                         align="left">
                                    <asp:UpdatePanel ID ="updtpnl" runat = "server">
                                        <ContentTemplate>
                                            <asp:TreeView ID="TvItem" runat="server"
                                                OnTreeNodePopulate="TvItem_TreeNodePopulate" ExpandDepth="0" 
                                                 ShowLines="True" onselectednodechanged="TvItem_SelectedNodeChanged">
                                                 <NodeStyle Font-Names="Arial" Font-Size="10pt" ForeColor="DarkBlue" HorizontalPadding="5"/>
                                                  <RootNodeStyle Font-Bold="True" Font-Size="10pt"/>
                                                  <HoverNodeStyle Font-UnderLine="True" />
                                                  <Nodes>
                                                  </Nodes>
                                        </asp:TreeView>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>                                                                                
                                     </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>                             
                                <input  type="button" value="Add Product Group" onclick="AddProductGroup()" class="button" style="width:150px;" />
                                <input  type="button" value="Add Product" onclick="AddProduct()" class="button" style="width:150px;" />                                  
                                <input  type="button" value="View Detail" onclick="EditProductGroup()" class="button" style="width:150px;" />
                                <input  type="button" value="Branch Detail" onclick="ProductBranch()" class="button" style="width:110px;" />
                                &nbsp;</td>
                        </tr>
                        <tr> <td>                                                   
                            <asp:UpdatePanel ID="UpdProductMSG" runat="server">
                               <ContentTemplate>
                              
                            <table id="Table1" style="width: 100%;" runat="server">
                                <tr>
                                    <td class="style1"> Group Code: </td>
                                    <td> <div ID="lblProductCode" runat="server" ></div></td>
                                    
                                </tr>
                                  <tr>
                                    <td class="style1"> Group Name: </td>
                                    <td>  <div ID="lblProductName" runat="server" ></div> </td>
                                    
                                </tr>
                                  <tr>
                                    <td class="style1"> Group/Product: </td>
                                    <td> <div ID="lblIsProduct" runat="server" ></div> </td>
                                    
                                </tr>
                                </tr>
                                  <tr>
                                    <td class="style1"> Product ID: </td>
                                    <td> <div ID="lblProductID" runat="server" ></div> </td>
                                    
                                </tr>
                            </table>
                            </ContentTemplate>
                            </asp:UpdatePanel> 
                         
                               
                         </td>
                        </tr>
                    </table>

    <div>
    
    </div>
   
 <script type="text/javascript">

     function AddProductGroup() {
         var IsProduct = document.getElementById("lblIsProduct").innerHTML;

         if (IsProduct == "") {
             alert('Please select the node first.');
             return false;
         }
         
         if (IsProduct == "Product") {
             alert("Sorry, Product Can not have further node !");
             return false;
         }
  
         var URL = "../Item/Manage.aspx?grpid=" + document.getElementById("lblProductCode").innerHTML + "&product=" + document.getElementById("lblProductName").innerHTML;
         GB_show("Add Asset Prodcut Group ", URL,350, 700);
     }

     function ProductBranch() {

         var IsProduct = document.getElementById("lblIsProduct").innerHTML;

         if (IsProduct == "") {
             alert('Please select the node first.');
             return false;
         }
         
         
         if (IsProduct != "Product") {
             alert("Sorry, Product Need to Select !");
             return false;
         }

         var URL = "../Item/EditBranchProduct.aspx?ProductId=" + document.getElementById("lblProductID").innerHTML + "&product=" + document.getElementById("lblProductName").innerHTML;
         GB_show("Asset Branch Product Information", URL,450, 800);
         
     }

     function AddProduct() {

         var IsProduct = document.getElementById("lblIsProduct").innerHTML;
         
         if (IsProduct == "") {
             alert('Please select the node first.');
             return false;
         }
         
         if (IsProduct == "Product") {
             alert("Sorry, Product Can not have further node !");
             return false;
         }
       
         var URL = "../Item/ProductSetup.aspx?ItemId=" + document.getElementById("lblProductCode").innerHTML + "&product=" + document.getElementById("lblProductName").innerHTML;
         GB_show("Add Asset Prodcut ", URL, 400, 700);
     }

     function EditProductGroup() 
     {
         var IsProduct = document.getElementById("lblIsProduct").innerHTML;
            
             if (IsProduct == "") {
                 alert('Please select the node first.');
                 return false;
             }
                 
             if (IsProduct == "Product") {
                 var URL = "../Item/ProductSetup.aspx?ItemId=" + document.getElementById("lblProductCode").innerHTML + "&product=" + document.getElementById("lblProductName").innerHTML + "&ProductId=" + document.getElementById("lblProductID").innerHTML + "&gbox=" + 1;
             }
             else {
           
                 var URL = "../Item/Manage.aspx?id=" + document.getElementById("lblProductCode").innerHTML + "&product=" + document.getElementById("lblProductName").innerHTML + document.getElementById("lblProductID").innerHTML + "&gbox=" + 1;
             }
             GB_show("Add Asset Prodcut Group", URL,400,700);
     }

     function doHighlight(searchTerm, highlightStartTag, highlightEndTag) {

         if (searchTerm == "") {
             return false;
         }
         
         var bodyText = document.body.innerHTML;
         
         // the highlightStartTag and highlightEndTag parameters are optional
         if ((!highlightStartTag) || (!highlightEndTag)) {
             highlightStartTag = "<font style='color:blue; background-color:#ACF2F0;'>";
             highlightEndTag = "</font>";
         }

         var newText = "";
         var i = -1;
         var lcSearchTerm = searchTerm.toLowerCase();
         var lcBodyText = bodyText.toLowerCase();

         while (bodyText.length > 0) {
             i = lcBodyText.indexOf(lcSearchTerm, i + 1);
             if (i < 0) {
                 newText += bodyText;
                 bodyText = "";
             } else {
                 // skip anything inside an HTML tag
                 if (bodyText.lastIndexOf(">", i) >= bodyText.lastIndexOf("<", i)) {
                     // skip anything inside a <script> block
                     if (lcBodyText.lastIndexOf("/script>", i) >= lcBodyText.lastIndexOf("<script", i)) {
                         newText += bodyText.substring(0, i) + highlightStartTag + bodyText.substr(i, searchTerm.length) + highlightEndTag;
                         bodyText = bodyText.substr(i + searchTerm.length);
                         lcBodyText = bodyText.toLowerCase();
                         i = -1;
                     }
                 }
             }
         }
         document.body.innerHTML = newText;
         return true;
     }
     
     

     doHighlight(document.getElementById("txtNodeSearch").value);
     
 </script>

 </asp:Content>